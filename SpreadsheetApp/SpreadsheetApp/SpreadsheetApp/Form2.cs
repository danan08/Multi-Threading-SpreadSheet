using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form2 : Form
    {
        public static int row1 = 0;
        public static int row2 = 0;
        public Form2()
        {
            InitializeComponent();
            
        }

        public void EXC_ROW_Click(object sender, EventArgs e)
        {
            row1 = int.Parse(Row1.Text);
            row2 = int.Parse(Row2.Text);
            this.Close();

    }

        public void Row1_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void Row2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
