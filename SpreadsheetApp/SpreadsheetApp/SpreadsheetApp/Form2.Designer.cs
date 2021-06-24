
namespace SpreadsheetApp
{
    partial class Form2
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
            this.EXC_ROW = new System.Windows.Forms.Button();
            this.Row1 = new System.Windows.Forms.TextBox();
            this.Row2 = new System.Windows.Forms.TextBox();
            this.Exc_Row_label = new System.Windows.Forms.Label();
            this.Row2_label = new System.Windows.Forms.Label();
            this.row1_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EXC_ROW
            // 
            this.EXC_ROW.Location = new System.Drawing.Point(312, 149);
            this.EXC_ROW.Name = "EXC_ROW";
            this.EXC_ROW.Size = new System.Drawing.Size(255, 48);
            this.EXC_ROW.TabIndex = 0;
            this.EXC_ROW.Text = "Exchange Rows";
            this.EXC_ROW.UseVisualStyleBackColor = true;
            this.EXC_ROW.Click += new System.EventHandler(this.EXC_ROW_Click);
            // 
            // Row1
            // 
            this.Row1.Location = new System.Drawing.Point(373, 85);
            this.Row1.Name = "Row1";
            this.Row1.Size = new System.Drawing.Size(96, 31);
            this.Row1.TabIndex = 1;
            this.Row1.TextChanged += new System.EventHandler(this.Row1_TextChanged);
            // 
            // Row2
            // 
            this.Row2.Location = new System.Drawing.Point(147, 87);
            this.Row2.Name = "Row2";
            this.Row2.Size = new System.Drawing.Size(96, 31);
            this.Row2.TabIndex = 2;
            this.Row2.TextChanged += new System.EventHandler(this.Row2_TextChanged);
            // 
            // Exc_Row_label
            // 
            this.Exc_Row_label.AutoSize = true;
            this.Exc_Row_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exc_Row_label.Location = new System.Drawing.Point(82, 26);
            this.Exc_Row_label.Name = "Exc_Row_label";
            this.Exc_Row_label.Size = new System.Drawing.Size(356, 32);
            this.Exc_Row_label.TabIndex = 3;
            this.Exc_Row_label.Text = "Please Enter Rows To Exchange :";
            // 
            // Row2_label
            // 
            this.Row2_label.AutoSize = true;
            this.Row2_label.Location = new System.Drawing.Point(261, 90);
            this.Row2_label.Name = "Row2_label";
            this.Row2_label.Size = new System.Drawing.Size(106, 25);
            this.Row2_label.TabIndex = 4;
            this.Row2_label.Text = "Row num 2:";
            // 
            // row1_label
            // 
            this.row1_label.AutoSize = true;
            this.row1_label.Location = new System.Drawing.Point(35, 90);
            this.row1_label.Name = "row1_label";
            this.row1_label.Size = new System.Drawing.Size(106, 25);
            this.row1_label.TabIndex = 5;
            this.row1_label.Text = "Row num 1:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 222);
            this.Controls.Add(this.row1_label);
            this.Controls.Add(this.Row2_label);
            this.Controls.Add(this.Exc_Row_label);
            this.Controls.Add(this.Row2);
            this.Controls.Add(this.Row1);
            this.Controls.Add(this.EXC_ROW);
            this.Name = "Form2";
            this.Text = "Exchange Rows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EXC_ROW;
        private System.Windows.Forms.TextBox Row1;
        private System.Windows.Forms.TextBox Row2;
        private System.Windows.Forms.Label Exc_Row_label;
        private System.Windows.Forms.Label Row2_label;
        private System.Windows.Forms.Label row1_label;
    }
}