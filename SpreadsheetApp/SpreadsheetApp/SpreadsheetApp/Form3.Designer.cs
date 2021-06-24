
namespace SpreadsheetApp
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Col2 = new System.Windows.Forms.TextBox();
            this.Col1 = new System.Windows.Forms.TextBox();
            this.EXC_COL = new System.Windows.Forms.Button();
            this.Exc_Col_label = new System.Windows.Forms.Label();
            this.col1_label = new System.Windows.Forms.Label();
            this.Col2_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Col2
            // 
            this.Col2.Location = new System.Drawing.Point(402, 98);
            this.Col2.Name = "Col2";
            this.Col2.Size = new System.Drawing.Size(88, 31);
            this.Col2.TabIndex = 5;
            this.Col2.TextChanged += new System.EventHandler(this.Col2_TextChanged);
            // 
            // Col1
            // 
            this.Col1.Location = new System.Drawing.Point(168, 98);
            this.Col1.Name = "Col1";
            this.Col1.Size = new System.Drawing.Size(88, 31);
            this.Col1.TabIndex = 4;
            this.Col1.TextChanged += new System.EventHandler(this.Col1_TextChanged);
            // 
            // EXC_COL
            // 
            this.EXC_COL.Location = new System.Drawing.Point(318, 148);
            this.EXC_COL.Name = "EXC_COL";
            this.EXC_COL.Size = new System.Drawing.Size(237, 47);
            this.EXC_COL.TabIndex = 3;
            this.EXC_COL.Text = "Exchange Columns";
            this.EXC_COL.UseVisualStyleBackColor = true;
            this.EXC_COL.Click += new System.EventHandler(this.EXC_COL_Click);
            // 
            // Exc_Col_label
            // 
            this.Exc_Col_label.AutoSize = true;
            this.Exc_Col_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exc_Col_label.Location = new System.Drawing.Point(28, 26);
            this.Exc_Col_label.Name = "Exc_Col_label";
            this.Exc_Col_label.Size = new System.Drawing.Size(396, 32);
            this.Exc_Col_label.TabIndex = 6;
            this.Exc_Col_label.Text = "Please Enter Columns To Exchange :";
            // 
            // col1_label
            // 
            this.col1_label.AutoSize = true;
            this.col1_label.Location = new System.Drawing.Point(28, 101);
            this.col1_label.Name = "col1_label";
            this.col1_label.Size = new System.Drawing.Size(134, 25);
            this.col1_label.TabIndex = 8;
            this.col1_label.Text = "Column num 1:";
            // 
            // Col2_label
            // 
            this.Col2_label.AutoSize = true;
            this.Col2_label.Location = new System.Drawing.Point(262, 101);
            this.Col2_label.Name = "Col2_label";
            this.Col2_label.Size = new System.Drawing.Size(134, 25);
            this.Col2_label.TabIndex = 7;
            this.Col2_label.Text = "Column num 2:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 218);
            this.Controls.Add(this.col1_label);
            this.Controls.Add(this.Col2_label);
            this.Controls.Add(this.Exc_Col_label);
            this.Controls.Add(this.Col2);
            this.Controls.Add(this.Col1);
            this.Controls.Add(this.EXC_COL);
            this.Name = "Form3";
            this.Text = "Exchange Columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Col2;
        private System.Windows.Forms.TextBox Col1;
        private System.Windows.Forms.Button EXC_COL;
        private System.Windows.Forms.Label Exc_Col_label;
        private System.Windows.Forms.Label col1_label;
        private System.Windows.Forms.Label Col2_label;
    }
}