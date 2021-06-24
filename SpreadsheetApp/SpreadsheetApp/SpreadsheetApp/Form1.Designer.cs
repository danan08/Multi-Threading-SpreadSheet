
using System;

namespace SpreadsheetApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Load_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Search_String = new System.Windows.Forms.Button();
            this.Exchange_Rows = new System.Windows.Forms.Button();
            this.Exchange_Cols = new System.Windows.Forms.Button();
            this.Get_Size = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Load_button
            // 
            this.Load_button.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Load_button.Font = new System.Drawing.Font("Goudy Old Style", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Load_button.Location = new System.Drawing.Point(1114, 140);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(186, 56);
            this.Load_button.TabIndex = 0;
            this.Load_button.Text = "Load";
            this.Load_button.UseVisualStyleBackColor = false;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 594);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Search_String
            // 
            this.Search_String.AutoSize = true;
            this.Search_String.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Search_String.Location = new System.Drawing.Point(1114, 220);
            this.Search_String.Name = "Search_String";
            this.Search_String.Padding = new System.Windows.Forms.Padding(6);
            this.Search_String.Size = new System.Drawing.Size(186, 56);
            this.Search_String.TabIndex = 3;
            this.Search_String.Text = "Search";
            this.Search_String.UseVisualStyleBackColor = false;
            this.Search_String.Click += new System.EventHandler(this.Search_String_Click);
            // 
            // Exchange_Rows
            // 
            this.Exchange_Rows.Location = new System.Drawing.Point(1112, 388);
            this.Exchange_Rows.Name = "Exchange_Rows";
            this.Exchange_Rows.Size = new System.Drawing.Size(187, 73);
            this.Exchange_Rows.TabIndex = 5;
            this.Exchange_Rows.Text = "Exchange Rows";
            this.Exchange_Rows.UseVisualStyleBackColor = true;
            this.Exchange_Rows.Click += new System.EventHandler(this.Exchange_Rows_Click);
            // 
            // Exchange_Cols
            // 
            this.Exchange_Cols.Location = new System.Drawing.Point(1112, 295);
            this.Exchange_Cols.Name = "Exchange_Cols";
            this.Exchange_Cols.Size = new System.Drawing.Size(186, 73);
            this.Exchange_Cols.TabIndex = 8;
            this.Exchange_Cols.Text = "Exchange Cols";
            this.Exchange_Cols.UseVisualStyleBackColor = true;
            this.Exchange_Cols.Click += new System.EventHandler(this.Exchange_Cols_Click);
            // 
            // Get_Size
            // 
            this.Get_Size.Location = new System.Drawing.Point(1112, 487);
            this.Get_Size.Name = "Get_Size";
            this.Get_Size.Size = new System.Drawing.Size(187, 56);
            this.Get_Size.TabIndex = 11;
            this.Get_Size.Text = "Get Size";
            this.Get_Size.UseVisualStyleBackColor = true;
            this.Get_Size.Click += new System.EventHandler(this.Get_Size_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(1112, 568);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(187, 56);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 65);
            this.label1.TabIndex = 13;
            this.label1.Text = "Spread Sheet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1347, 689);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Get_Size);
            this.Controls.Add(this.Exchange_Cols);
            this.Controls.Add(this.Exchange_Rows);
            this.Controls.Add(this.Search_String);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Load_button);
            this.Name = "Form1";
            this.Text = "Spread Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Search_String;
        private System.Windows.Forms.Button Exchange_Rows;
        private System.Windows.Forms.Button Exchange_Cols;
        private System.Windows.Forms.Button Get_Size;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
    }
}

