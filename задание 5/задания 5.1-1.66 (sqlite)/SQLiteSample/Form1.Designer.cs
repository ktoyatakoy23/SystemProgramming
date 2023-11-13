namespace SQLiteSample
{
    partial class Form1
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
            this.del_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.TEST_TEXT2 = new System.Windows.Forms.TextBox();
            this.TEST_TEXT = new System.Windows.Forms.TextBox();
            this.TEST_TEXT3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // del_btn
            // 
            this.del_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.del_btn.Location = new System.Drawing.Point(11, 89);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(126, 60);
            this.del_btn.TabIndex = 0;
            this.del_btn.Text = "Удалить последнее";
            this.del_btn.UseVisualStyleBackColor = true;
            // 
            // create_btn
            // 
            this.create_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_btn.Location = new System.Drawing.Point(147, 89);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(60, 60);
            this.create_btn.TabIndex = 1;
            this.create_btn.Text = "Создать";
            this.create_btn.UseVisualStyleBackColor = true;
            // 
            // TEST_TEXT2
            // 
            this.TEST_TEXT2.Location = new System.Drawing.Point(11, 37);
            this.TEST_TEXT2.Name = "TEST_TEXT2";
            this.TEST_TEXT2.Size = new System.Drawing.Size(126, 20);
            this.TEST_TEXT2.TabIndex = 2;
            // 
            // TEST_TEXT
            // 
            this.TEST_TEXT.Location = new System.Drawing.Point(11, 11);
            this.TEST_TEXT.Name = "TEST_TEXT";
            this.TEST_TEXT.Size = new System.Drawing.Size(126, 20);
            this.TEST_TEXT.TabIndex = 3;
            // 
            // TEST_TEXT3
            // 
            this.TEST_TEXT3.Location = new System.Drawing.Point(11, 63);
            this.TEST_TEXT3.Name = "TEST_TEXT3";
            this.TEST_TEXT3.Size = new System.Drawing.Size(126, 20);
            this.TEST_TEXT3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TEST_TEXT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "TEST_TEXT3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TEST_TEXT2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(231, 160);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TEST_TEXT3);
            this.Controls.Add(this.TEST_TEXT);
            this.Controls.Add(this.TEST_TEXT2);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.del_btn);
            this.Name = "Form1";
            this.Text = "SQLite Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.TextBox TEST_TEXT2;
        private System.Windows.Forms.TextBox TEST_TEXT;
        private System.Windows.Forms.TextBox TEST_TEXT3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

