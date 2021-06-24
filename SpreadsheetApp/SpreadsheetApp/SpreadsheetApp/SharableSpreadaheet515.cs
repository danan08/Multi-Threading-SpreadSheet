using System;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;


class ShareableSpreadSheet
{
    public String [,] Spreadsheet;
    int nRows;
    int nCols;
    Semaphore semaphore;
    int semMax;
    Semaphore[] mut_Rows;
    Semaphore[] mut_Cols;
    Mutex Write = new Mutex();
    Mutex SemaphoreCreate = new Mutex();
    bool IsSemaphoreExist = false;
    int semCount = 0;
    int searchCount = 0;

    public ShareableSpreadSheet(int nRows, int nCols)
    {
        // construct a nRows*nCols spreadsheet
        this.Spreadsheet = new string[nRows+1, nCols+1];
        this.nCols = nCols+1;
        this.nRows = nRows+1;
        this.mut_Rows = new Semaphore[this.nRows];
        this.mut_Cols = new Semaphore[this.nCols];

        //mut_Rows
        for (int j = 0; j < this.nRows; j++)
        {
            this.mut_Rows[j] = new Semaphore(0, 1);
            this.mut_Rows[j].Release(1);
        }
        //mut_Cols
        for (int k = 0; k < this.nCols; k++)
        {
            this.mut_Cols[k] = new Semaphore(0, 1);
            this.mut_Cols[k].Release(1);
        }
    }

    public String getCell(int row, int col)
    {
        // return the string at [row,col]
        if (row >= this.nRows || col >= this.nCols || row < 1 || col < 1)
        {
            return null;
        }
        Write.WaitOne();
        Write.ReleaseMutex();
        //return the str from the cell
        return this.Spreadsheet[row, col];
        
    }
    public bool setCell(int row, int col, String str)
    {

        if (row >= this.nRows || col >= this.nCols || row < 1 || col < 1)
        {

            return false;
        }
        //check if available to start
        Write.WaitOne();
        Write.ReleaseMutex();

        //lock row and col 
        bool lock_row = mut_Rows[row].WaitOne();
        bool lock_col = mut_Cols[col].WaitOne();
        //change the cell value
        this.Spreadsheet[row, col] = str;
        //release locks
        if (lock_row != null)
        {
            mut_Rows[row].Release(1);
        }
        if (lock_col != null)
        {
            mut_Cols[col].Release(1);
        }
        return true;
    }
    public bool searchString(String str, ref int row, ref int col)
    {

        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;
        bool sem = false;
        if (IsSemaphoreExist == true)
        {
            SemaphoreCreate.WaitOne();
            SemaphoreCreate.ReleaseMutex();
            semCount++;
            this.semaphore.WaitOne();
            sem = true;       
        }

        //set result
        bool result = false;
        bool lock_row = false;
        bool lock_col = false;
        for (int i = 1; i < this.nRows && result == false; i++)
        {
            for (int j = 1; j < this.nCols && result == false; j++)
            {
                //check if available to search 
                Write.WaitOne();
                Write.ReleaseMutex();
                //lock row and col
                lock_row = mut_Rows[i].WaitOne();
                lock_col = mut_Cols[j].WaitOne();
                //check if contains
                if (this.Spreadsheet[i, j].Contains(str))
                {
                    row = i;
                    col = j;
                    result = true;
                }
                //release row and col
                if (lock_row != null && mut_Rows[i] != null)
                {
                    mut_Rows[i].Release(1);
                }
                if (lock_col != null && mut_Cols[j] != null)
                {
                    mut_Cols[j].Release(1);
                }
            }
        }

        if (IsSemaphoreExist == true && sem == true)
        {
            this.semaphore.Release(1);
            this.semCount--;
        }

        this.searchCount--;
        return result;
    }
    public bool exchangeRows(int row1, int row2)
    {
        // exchange the content of row1 and row2
        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;
        String temp;
        if (row2>=this.nRows || row2<1 || row1 >= this.nRows || row1 < 1 || row1==row2)
        {
            this.searchCount--;
            return false;
        }
        bool row1_lock = false;
        bool row2_lock = false;
        bool col_lock = false;

        for (int i = 1; i<this.nCols; i++)
        {

            Write.WaitOne();
            Write.ReleaseMutex();
            //lock the row and cols
            row1_lock = this.mut_Rows[row1].WaitOne();
            row2_lock = this.mut_Rows[row2].WaitOne();
            col_lock = this.mut_Cols[i].WaitOne();
            //exchange cell
            temp = this.Spreadsheet[row1, i];
            this.Spreadsheet[row1, i] = this.Spreadsheet[row2, i];
            this.Spreadsheet[row2, i] = temp;

            //release the row and cols
            if(row1_lock != null)
            {
                this.mut_Rows[row1].Release(1);
            }
            if (row2_lock != null)
            {
                this.mut_Rows[row2].Release(1);
            }
            if (col_lock != null)
            {
                this.mut_Cols[i].Release(1);
            }
        }
        this.searchCount--;
        return true;
    }
    public bool exchangeCols(int col1, int col2)
    {
        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;
        // exchange the content of col1 and col2
        String temp;
        if (col2 >= this.nCols || col2 < 1 || col1 >= this.nCols || col1 < 1||col1==col2)
        {
            this.searchCount--;
            return false;
        }
        bool col1_lock = false;
        bool col2_lock = false;
        bool row_lock = false;
        for (int i = 1; i < this.nRows; i++)
        {

            //lock the row and cols
            Write.WaitOne();
            Write.ReleaseMutex();
            row_lock = this.mut_Rows[i].WaitOne();
            col1_lock = this.mut_Cols[col1].WaitOne();
            col2_lock = this.mut_Cols[col2].WaitOne();
            //exchange cell
            temp = this.Spreadsheet[i, col1];
            this.Spreadsheet[i, col1] = this.Spreadsheet[i, col2];
            this.Spreadsheet[i, col2] = temp;
            //release the row and cols
            if (row_lock != null)
            {
                this.mut_Rows[i].Release(1);
            }
            if (col1_lock != null)
            {
                this.mut_Cols[col1].Release(1);
            }
            if (col2_lock != null)
            {
                this.mut_Cols[col2].Release(1);
            }

        }
        this.searchCount--;
        return true;
    
    }
    public bool searchInRow(int row, String str, ref int col)
    {
        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;
        bool sem = false;
        if (IsSemaphoreExist == true)
        {
            SemaphoreCreate.WaitOne();
            SemaphoreCreate.ReleaseMutex();
            this.semCount++;
            this.semaphore.WaitOne();
            sem = true;
        }
        // perform search in specific row
        if (row >= this.nRows || row < 1)
        {
            if (IsSemaphoreExist == true && sem == true)
            {
                this.semCount--;
            }
            this.searchCount--;
            return false;
        }

        //set result
        bool result = false;
        for (int j = 1; j < this.nCols && result==false; j++)
        {

            Write.WaitOne();
            Write.ReleaseMutex();
            bool cl = this.mut_Rows[row].WaitOne();
            bool cl2 = this.mut_Cols[j].WaitOne();
   
            if (this.Spreadsheet[row, j].Contains(str))
            {
                col = j;
                result = true;

            }

            if (cl != null)
            {
                this.mut_Rows[row].Release(1);
            }
            if (cl2 != null)
            {
                this.mut_Cols[j].Release(1);
            }

        }
        if (IsSemaphoreExist == true && sem == true)
        {
            this.semaphore.Release(1);
            this.semCount--;
        }
        this.searchCount--;
        return result;
    }
    public bool searchInCol(int col, String str, ref int row)
    {

        bool sem = false;
        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;

        if (IsSemaphoreExist == true)
        {
            SemaphoreCreate.WaitOne();
            SemaphoreCreate.ReleaseMutex();
            semCount++;
            this.semaphore.WaitOne();
            sem = true;
        }
        bool result = false;
        bool row_lock = false;
        bool col_lock = false;
        // perform search in specific col
        if (col >= this.nCols || col < 1)
        {
            if (IsSemaphoreExist == true && sem == true)
            {
                this.semCount--;
            }
            this.searchCount--;
            return false;
        }
        for (int j = 1; j < this.nRows && result==false; j++)
        {
            Write.WaitOne();
            Write.ReleaseMutex();
            row_lock = this.mut_Rows[j].WaitOne();
            col_lock = this.mut_Cols[col].WaitOne();
            if (this.Spreadsheet[j, col].Contains(str))
            {
                row = j;
                result = true;
            }
            if (row_lock != null)
            {
                this.mut_Rows[j].Release(1);
            }
            if (col_lock != null)
            {
                this.mut_Cols[col].Release(1);
            }

        }
        if (IsSemaphoreExist == true && sem == true)
        {
            this.semaphore.Release(1);
            this.semCount--;
        }
        this.searchCount--;
        return result;
    }
    public bool searchInRange(int col1, int col2, int row1, int row2, String str, ref int row, ref int col)
    {
        Write.WaitOne();
        Write.ReleaseMutex();
        this.searchCount++;
        bool sem = false;
        if (IsSemaphoreExist == true)
        {
            SemaphoreCreate.WaitOne();
            SemaphoreCreate.ReleaseMutex();
            semCount++;
            this.semaphore.WaitOne();
            sem = true;
        }

        // perform search within spesific range: [row1:row2,col1:col2] 
        //includes col1,col2,row1,row2
        if (row1 >= this.nRows || col1 >= this.nCols || row1 < 1 || col1 < 1 || row2 >= this.nRows || col2 >= this.nCols || row2 < 1 || col2 < 1)
        {
            if (IsSemaphoreExist == true && sem == true)
            {
                this.semCount--;
            }
            this.searchCount--;
            return false;
        }
        bool result = false;
        bool lock_row = false;
        bool lock_col = false;
        int temp=0;
        if (row1 > row2)
        {
            temp = row1;
            row1 = row2;
            row2 = temp;
        }
        if (col1 > col2)
        {
            temp = col1;
            col1 = col2;
            col2 = temp;
        }

        for (int i = row1; i < row2+1 && result == false; i++)
        {
            for (int j = col1; j < col2+1 && result == false; j++)
            {
                //lock row and col
                Write.WaitOne();
                Write.ReleaseMutex();
                lock_row = mut_Rows[i].WaitOne();
                lock_col = mut_Cols[j].WaitOne();
                //check if contains
                if (this.Spreadsheet[i, j].Contains(str))
                {
                    row = i;
                    col = j;
                    result =  true;
                }
                //release row and col
                if (lock_row != null)
                {
                    mut_Rows[i].Release(1);
                }
                if (lock_col != null)
                {
                    mut_Cols[j].Release(1);
                }
            }
        }

        if (IsSemaphoreExist == true && sem == true)
        {
            this.semaphore.Release(1);
            this.semCount--;
        }
        this.searchCount--;
        return result;
    }
    public bool addRow(int row1)
    {
        //add a row after row1
        if (row1 >= this.nRows || row1 < 1)
        {
            return false;
        }
        //block all functions 
        Write.WaitOne();
        Stopwatch now = Stopwatch.StartNew();
        //checks if available to start
        while (this.searchCount > 0 ) { 
            if (now.ElapsedMilliseconds > 50)
            {
                Write.ReleaseMutex();
                now.Stop();
                return false;
            }
        }
        now.Stop();
        String[,] temp = new string[this.nRows, this.nCols];
        Semaphore[] temp_row = new Semaphore[this.nRows];
        temp_row = this.mut_Rows;
        temp = this.Spreadsheet;
        this.nRows++;
        this.Spreadsheet = new string[this.nRows, this.nCols];
        this.mut_Rows = new Semaphore[this.nRows];
        int rows = 1;
        for (int i = 1; i < this.nRows; i++)
        {
            for (int j = 1; j < this.nCols; j++)
            {
                if (i == row1 + 1)
                {
                    this.Spreadsheet[i, j] = "";
                }
                else
                {
                    this.Spreadsheet[i, j] = temp[rows, j];
                }  
            }
            if (i != row1 + 1)
            {
                this.mut_Rows[i] = temp_row[rows];
                rows++;
            }
            else
            {
                this.mut_Rows[i] = new Semaphore(0,1);
                this.mut_Rows[i].Release(1);
            }
        }
        //release all func 
        Thread.Sleep(20);
        Write.ReleaseMutex();
        return true;
    }
    public bool addCol(int col1)
    {
        //add a column after col1
        if (col1 >= this.nCols || col1 < 1)
        {
            return false;
        }
        //block all functions 
        Write.WaitOne();
        Stopwatch now = Stopwatch.StartNew();
        //checks if available to start
        while (this.searchCount > 0)
        {
            if (now.ElapsedMilliseconds > 50)
            {
                Write.ReleaseMutex();
                now.Stop();
                return false;
            }
        }
        now.Stop();
        String[,] temp = new string[this.nRows, this.nCols];
        Semaphore[] temp_col = new Semaphore[this.nCols];
        temp_col = this.mut_Cols;
        temp = this.Spreadsheet;
        this.nCols++;
        this.Spreadsheet = new string[this.nRows, this.nCols];
        this.mut_Cols = new Semaphore[this.nCols];
        int cols = 1;
        this.mut_Cols[0] = new Semaphore(0,1);
        this.mut_Cols[0].Release(1);
        for (int i = 1; i < this.nCols; i++)
        {
            for (int j = 1; j < this.nRows; j++)
            {
                if (i == col1 + 1)
                {
                    this.Spreadsheet[j, i] = "";
                }
                else
                {
                    this.Spreadsheet[j, i] = temp[j, cols];
                }
            }
            if (i != col1 + 1)
            {
                this.mut_Cols[i] = temp_col[cols];
                cols++;
            }
            else
            {
                this.mut_Cols[i] = new Semaphore(0,1);
                this.mut_Cols[i].Release(1);
            }
        }
        //release all func 
        Thread.Sleep(20);
        Write.ReleaseMutex();
        return true;
    }
    public void getSize(ref int nRows, ref int nCols)
    {
        // return the size of the spreadsheet in nRows, nCols
        Write.WaitOne();
        Write.ReleaseMutex();
        nRows = this.nRows - 1;
        nCols = this.nCols - 1;
    }
    public bool setConcurrentSearchLimit(int nUsers)
    {
        // this function aims to limit the number of users that can perform the search operations concurrently.
        // The default is no limit. When the function is called, the max number of concurrent search operations is set to nUsers. 
        // In this case additional search operations will wait for existing search to finish.
        bool result = false;
        this.SemaphoreCreate.WaitOne();
        if (IsSemaphoreExist == false)
        {
            IsSemaphoreExist = true;
            this.semaphore = new Semaphore(0, nUsers);
            this.semaphore.Release(nUsers);
            this.semMax = nUsers;
            result = true;
        }
        else if ( this.semMax < nUsers)
        {
            Stopwatch now = Stopwatch.StartNew();
            while (this.semCount > 0)
            {
                if (now.ElapsedMilliseconds > 50)
                {
                    this.SemaphoreCreate.ReleaseMutex();
                    now.Stop();
                    return false;
                }
            }
            now.Stop();
            this.semaphore = new Semaphore(0, nUsers);
            this.semaphore.Release(nUsers);
            this.semMax = nUsers; 
            result= true;
        }
        this.SemaphoreCreate.ReleaseMutex();
        return result;
    }

    public bool save(String fileName)
    {
        // save the spreadsheet to a file fileName.
        // you can decide the format you save the data. There are several options.
        Write.WaitOne();
        File.WriteAllLines(@fileName, ToCsv(this.Spreadsheet));
        Write.ReleaseMutex();
        return true;
    }

    private static IEnumerable<String> ToCsv<T>(T[,] data, string separator = ",")
    {
        for (int i = 0; i < data.GetLength(0)-1; ++i)
            yield return string.Join(separator, System.Linq.Enumerable
              .Range(0, data.GetLength(1)-1)
              .Select(j => data[i+1, j+1])); // simplest, we don't expect ',' and '"' in the items
    }

    public bool load(String fileName)
    {
        try
        {
            // load the spreadsheet from fileName
            // replace the data and size of the current spreadsheet with the loaded data
            string filePath = fileName;
            StreamReader sr = new StreamReader(filePath);
            var lines = new List<string[]>();
            int Row = 0;
            int MaxCol = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Line.Length > MaxCol)
                {
                    MaxCol = Line.Length;
                }
                lines.Add(Line);
                Row++;
            }
          
            var data = lines.ToArray();
            this.Spreadsheet = new string[Row + 1, MaxCol + 1];
            this.nRows = Row + 1;
            this.nCols = MaxCol + 1;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    this.Spreadsheet[i + 1, j + 1] = data[i][j];
                }
            }
            this.mut_Rows = new Semaphore[this.nRows];
            this.mut_Cols = new Semaphore[this.nCols];

            for (int j = 0; j < this.nRows; j++)
            {
                this.mut_Rows[j] = new Semaphore(0, 1);
                this.mut_Rows[j].Release(1);
            }
            //mut_Cols
            for (int k = 0; k < this.nCols; k++)
            {
                this.mut_Cols[k] = new Semaphore(0, 1);
                this.mut_Cols[k].Release(1);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}



