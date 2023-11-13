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
            System.Windows.Forms.Button startJournal;
            System.Windows.Forms.Button folderInfo;
            System.Windows.Forms.Button folderInfoGit;
            this.del_btn = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.TEST_TEXT2 = new System.Windows.Forms.TextBox();
            this.TEST_TEXT = new System.Windows.Forms.TextBox();
            this.TEST_TEXT3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.folderPathGit = new System.Windows.Forms.TextBox();
            startJournal = new System.Windows.Forms.Button();
            folderInfo = new System.Windows.Forms.Button();
            folderInfoGit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startJournal
            // 
            startJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            startJournal.Location = new System.Drawing.Point(213, 89);
            startJournal.Name = "startJournal";
            startJournal.Size = new System.Drawing.Size(91, 60);
            startJournal.TabIndex = 8;
            startJournal.Text = "Начать вести журнал";
            startJournal.UseVisualStyleBackColor = true;
            startJournal.Click += new System.EventHandler(this.startJournal_Click);
            // 
            // folderInfo
            // 
            folderInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            folderInfo.Location = new System.Drawing.Point(218, 175);
            folderInfo.Name = "folderInfo";
            folderInfo.Size = new System.Drawing.Size(91, 41);
            folderInfo.TabIndex = 11;
            folderInfo.Text = "Начать вести отчет";
            folderInfo.UseVisualStyleBackColor = true;
            folderInfo.Click += new System.EventHandler(this.folderInfo_Click);
            // 
            // folderInfoGit
            // 
            folderInfoGit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            folderInfoGit.Location = new System.Drawing.Point(218, 229);
            folderInfoGit.Name = "folderInfoGit";
            folderInfoGit.Size = new System.Drawing.Size(91, 41);
            folderInfoGit.TabIndex = 14;
            folderInfoGit.Text = "Начать вести отчет";
            folderInfoGit.UseVisualStyleBackColor = true;
            folderInfoGit.Click += new System.EventHandler(this.folderInfoGit_Click_1);
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
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(10, 188);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(203, 20);
            this.FolderPath.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Введите путь для задания 3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Введите путь для задания 4:";
            // 
            // folderPathGit
            // 
            this.folderPathGit.Location = new System.Drawing.Point(10, 242);
            this.folderPathGit.Name = "folderPathGit";
            this.folderPathGit.Size = new System.Drawing.Size(203, 20);
            this.folderPathGit.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(316, 282);
            this.Controls.Add(folderInfoGit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.folderPathGit);
            this.Controls.Add(folderInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(startJournal);
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
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox folderPathGit;
    }
}

