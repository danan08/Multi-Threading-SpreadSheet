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
    
    public partial class Form3 : Form
    {
        public static int col1 = 0;
        public static int col2 = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void EXC_COL_Click(object sender, EventArgs e)
        {
            col1 = int.Parse(Col1.Text);
            col2 = int.Parse(Col2.Text);
            this.Close();
        }

        private void Col2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Col1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
