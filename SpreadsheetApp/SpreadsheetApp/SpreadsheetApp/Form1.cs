using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing;
using System.IO;



namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        ShareableSpreadSheet sp = new ShareableSpreadSheet(10, 10);
        public bool is_loaded = false;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(37,52, 64);
            dataGridView1.BackgroundColor = Color.FromArgb(37, 52, 64);
            Load_button.BackColor = Color.FromArgb(139, 194, 180);
            Load_button.ForeColor = Color.FromArgb(255, 255, 255);
            Load_button.Font = new Font("Goudy Old Style", 14,FontStyle.Bold);
            Search_String.BackColor = Color.FromArgb(139, 194, 180);
            Search_String.ForeColor = Color.FromArgb(255, 255, 255);
            Search_String.Font = new Font("Goudy Old Style", 14, FontStyle.Bold);
            Exchange_Rows.BackColor = Color.FromArgb(139, 194, 180);
            Exchange_Rows.ForeColor = Color.FromArgb(255, 255, 255);
            Exchange_Rows.Font = new Font("Goudy Old Style", 13, FontStyle.Bold);
            Exchange_Cols.BackColor = Color.FromArgb(139, 194, 180);
            Exchange_Cols.ForeColor = Color.FromArgb(255, 255, 255);
            Exchange_Cols.Font = new Font("Goudy Old Style", 13, FontStyle.Bold);
            Get_Size.BackColor = Color.FromArgb(139, 194, 180);
            Get_Size.ForeColor = Color.FromArgb(255, 255, 255);
            Get_Size.Font = new Font("Goudy Old Style", 14, FontStyle.Bold);
            Save.BackColor = Color.FromArgb(139, 194, 180);
            Save.ForeColor = Color.FromArgb(255, 255, 255);
            Save.Font = new Font("Goudy Old Style", 14, FontStyle.Bold);
        }

        private void Display_sp(ShareableSpreadSheet sp)
        {
            int nRows = 0;
            int nCols = 0;
            String colName ="";
            sp.getSize(ref nRows, ref nCols);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = nCols;

            for (int col = 0; col < nCols; col++)
            {
                colName = "col " + (col + 1);
                dataGridView1.Columns[col].Name = colName;
            }

            String[] line = new string[nCols];
            for (int row = 1; row <= nRows; row++)
            {
                for (int col = 1; col <= nCols; col++)
                {
                    line[col - 1] = sp.Spreadsheet[row, col];
                }
                dataGridView1.Rows.Add(line);
            }
            
            int rowIndex = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(rowIndex % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(222,236,233);
                }
                rowIndex++;
                
            }
            
        }
        private void Load_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            
            bool is_Loaded = false;
            if (openFileDialog1.FileName != null || openFileDialog1.FileName != "")
            {
                is_Loaded = sp.load(openFileDialog1.FileName);
                if (is_Loaded == false)
                {
                    MessageBox.Show("Failed to load file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    is_loaded = true;
                    Display_sp(sp);
                }
            }
            else
            {
                MessageBox.Show("Invalid file name","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.dataGridView1, "To Set Cell Value Press On Its Text");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex;
            String str = Interaction.InputBox("Enter new cell value", "Set Cell", "");
            bool set_cell = sp.setCell(row + 1, col + 1, str);
            if (set_cell == true)
            {
                Display_sp(sp);
            }
            else
            {
                MessageBox.Show("Failed to set cell value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Search_String_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;
            
            if(is_loaded == false)
            {
                MessageBox.Show("File was not loaded to spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String str1 = Interaction.InputBox("Enter value to search", "Search String", "");
                bool Search_String = sp.searchString(str1, ref row, ref col);
                if (Search_String == true)
                {
                    MessageBox.Show("The string: " + str1 + " is at row: " + row + " and col: " + col,"Search String");
                }
                else
                {
                    MessageBox.Show("The string: " + str1 + " was not found in the spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


        private void Exchange_Rows_Click(object sender, EventArgs e)
        {
            
            var m = new Form2();
            
            
            if (is_loaded == false)
            {
                MessageBox.Show("File was not loaded to spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                m.ShowDialog();
                System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form2"];
                int nRow1 = Form2.row1;
                int nRow2 = Form2.row2;
                bool exchange_rows = sp.exchangeRows(nRow1, nRow2);
                if (exchange_rows == true)
                {
                    MessageBox.Show("Successfully exchanged rows: " + nRow1 + " and " + nRow2,"Exchange Rows");
                    Display_sp(sp);

                }
                else
                {
                    MessageBox.Show("Failed to exchanged rows: " + nRow1 + " and " + nRow2, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Exchange_Cols_Click(object sender, EventArgs e)
        {
            var n = new Form3();
            
            if (is_loaded == false)
            {
                MessageBox.Show("File was not loaded to spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                n.ShowDialog();
                System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form3"];
                int nCol1 = Form3.col1;
                int nCol2 = Form3.col2;
                bool exchange_cols = sp.exchangeCols(nCol1, nCol2);
                if (exchange_cols == true)
                {
                    MessageBox.Show("Successfully exchanged cols: " + nCol1 + " and " + nCol2, "Exchanged Cols");
                    Display_sp(sp);

                }
                else
                {
                    MessageBox.Show("Failed to exchanged cols: " + nCol1 + " and " + nCol2, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Get_Size_Click(object sender, EventArgs e)
        {
            int nRows = 0;
            int nCols = 0;
            if (is_loaded == false)
            {
                MessageBox.Show("File was not loaded to spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sp.getSize(ref nRows, ref nCols);
                MessageBox.Show("The spreadsheet contains " + nRows + " Rows and " + nCols + " Columns","Get Size");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            if (is_loaded == false)
            {
                MessageBox.Show("File was not loaded to spreadsheet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                bool save = sp.save(saveFileDialog1.FileName + ".csv");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
     
    }
} 
