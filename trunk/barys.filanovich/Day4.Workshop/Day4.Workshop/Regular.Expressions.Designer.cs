namespace Day4.Workshop
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
            this.inputStringTBox = new System.Windows.Forms.RichTextBox();
            this.patternTBox = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.countLbl = new System.Windows.Forms.Label();
            this.infoTBox = new System.Windows.Forms.TextBox();
            this.GetInfoBtn = new System.Windows.Forms.Button();
            this.RemoveTagBtn = new System.Windows.Forms.Button();
            this.dateReplaceBtn = new System.Windows.Forms.Button();
            this.replaceURLBtn = new System.Windows.Forms.Button();
            this.replaceMailBtn = new System.Windows.Forms.Button();
            this.replaceBucksBtn = new System.Windows.Forms.Button();
            this.replaceCodeBtn = new System.Windows.Forms.Button();
            this.replaceNumberBtn = new System.Windows.Forms.Button();
            this.removeSpaceBtn = new System.Windows.Forms.Button();
            this.replaceQuotesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputStringTBox
            // 
            this.inputStringTBox.Location = new System.Drawing.Point(12, 12);
            this.inputStringTBox.Name = "inputStringTBox";
            this.inputStringTBox.Size = new System.Drawing.Size(782, 183);
            this.inputStringTBox.TabIndex = 0;
            this.inputStringTBox.Text = "";
            // 
            // patternTBox
            // 
            this.patternTBox.Location = new System.Drawing.Point(12, 221);
            this.patternTBox.Name = "patternTBox";
            this.patternTBox.Size = new System.Drawing.Size(543, 20);
            this.patternTBox.TabIndex = 1;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(711, 221);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(83, 20);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // countLbl
            // 
            this.countLbl.AutoSize = true;
            this.countLbl.Location = new System.Drawing.Point(561, 228);
            this.countLbl.Name = "countLbl";
            this.countLbl.Size = new System.Drawing.Size(13, 13);
            this.countLbl.TabIndex = 4;
            this.countLbl.Text = "0";
            // 
            // infoTBox
            // 
            this.infoTBox.Location = new System.Drawing.Point(12, 276);
            this.infoTBox.Multiline = true;
            this.infoTBox.Name = "infoTBox";
            this.infoTBox.Size = new System.Drawing.Size(322, 74);
            this.infoTBox.TabIndex = 5;
            // 
            // GetInfoBtn
            // 
            this.GetInfoBtn.Location = new System.Drawing.Point(12, 247);
            this.GetInfoBtn.Name = "GetInfoBtn";
            this.GetInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.GetInfoBtn.TabIndex = 6;
            this.GetInfoBtn.Text = "Get info";
            this.GetInfoBtn.UseVisualStyleBackColor = true;
            this.GetInfoBtn.Click += new System.EventHandler(this.GetInfoBtn_Click);
            // 
            // RemoveTagBtn
            // 
            this.RemoveTagBtn.Location = new System.Drawing.Point(370, 276);
            this.RemoveTagBtn.Name = "RemoveTagBtn";
            this.RemoveTagBtn.Size = new System.Drawing.Size(105, 23);
            this.RemoveTagBtn.TabIndex = 7;
            this.RemoveTagBtn.Text = "Remove html-tags";
            this.RemoveTagBtn.UseVisualStyleBackColor = true;
            this.RemoveTagBtn.Click += new System.EventHandler(this.RemoveTagBtn_Click);
            // 
            // dateReplaceBtn
            // 
            this.dateReplaceBtn.Location = new System.Drawing.Point(370, 305);
            this.dateReplaceBtn.Name = "dateReplaceBtn";
            this.dateReplaceBtn.Size = new System.Drawing.Size(105, 23);
            this.dateReplaceBtn.TabIndex = 8;
            this.dateReplaceBtn.Text = "Replace date";
            this.dateReplaceBtn.UseVisualStyleBackColor = true;
            this.dateReplaceBtn.Click += new System.EventHandler(this.dateReplaceBtn_Click);
            // 
            // replaceURLBtn
            // 
            this.replaceURLBtn.Location = new System.Drawing.Point(370, 334);
            this.replaceURLBtn.Name = "replaceURLBtn";
            this.replaceURLBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceURLBtn.TabIndex = 9;
            this.replaceURLBtn.Text = "http to ftp";
            this.replaceURLBtn.UseVisualStyleBackColor = true;
            this.replaceURLBtn.Click += new System.EventHandler(this.replaceURLBtn_Click);
            // 
            // replaceMailBtn
            // 
            this.replaceMailBtn.Location = new System.Drawing.Point(370, 363);
            this.replaceMailBtn.Name = "replaceMailBtn";
            this.replaceMailBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceMailBtn.TabIndex = 10;
            this.replaceMailBtn.Text = "@gmail.com";
            this.replaceMailBtn.UseVisualStyleBackColor = true;
            this.replaceMailBtn.Click += new System.EventHandler(this.replaceMailBtn_Click);
            // 
            // replaceBucksBtn
            // 
            this.replaceBucksBtn.Location = new System.Drawing.Point(370, 392);
            this.replaceBucksBtn.Name = "replaceBucksBtn";
            this.replaceBucksBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceBucksBtn.TabIndex = 11;
            this.replaceBucksBtn.Text = "XXX $ to XXX р.";
            this.replaceBucksBtn.UseVisualStyleBackColor = true;
            this.replaceBucksBtn.Click += new System.EventHandler(this.replaceBucksBtn_Click);
            // 
            // replaceCodeBtn
            // 
            this.replaceCodeBtn.Location = new System.Drawing.Point(517, 276);
            this.replaceCodeBtn.Name = "replaceCodeBtn";
            this.replaceCodeBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceCodeBtn.TabIndex = 12;
            this.replaceCodeBtn.Text = "(0152) to (0162)";
            this.replaceCodeBtn.UseVisualStyleBackColor = true;
            this.replaceCodeBtn.Click += new System.EventHandler(this.replaceCodeBtn_Click);
            // 
            // replaceNumberBtn
            // 
            this.replaceNumberBtn.Location = new System.Drawing.Point(517, 334);
            this.replaceNumberBtn.Name = "replaceNumberBtn";
            this.replaceNumberBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceNumberBtn.TabIndex = 13;
            this.replaceNumberBtn.Text = "Replace number";
            this.replaceNumberBtn.UseVisualStyleBackColor = true;
            this.replaceNumberBtn.Click += new System.EventHandler(this.replaceNumberBtn_Click);
            // 
            // removeSpaceBtn
            // 
            this.removeSpaceBtn.Location = new System.Drawing.Point(517, 305);
            this.removeSpaceBtn.Name = "removeSpaceBtn";
            this.removeSpaceBtn.Size = new System.Drawing.Size(105, 23);
            this.removeSpaceBtn.TabIndex = 14;
            this.removeSpaceBtn.Text = "Remove spaces";
            this.removeSpaceBtn.UseVisualStyleBackColor = true;
            this.removeSpaceBtn.Click += new System.EventHandler(this.removeSpaceBtn_Click);
            // 
            // replaceQuotesBtn
            // 
            this.replaceQuotesBtn.Location = new System.Drawing.Point(517, 363);
            this.replaceQuotesBtn.Name = "replaceQuotesBtn";
            this.replaceQuotesBtn.Size = new System.Drawing.Size(105, 23);
            this.replaceQuotesBtn.TabIndex = 15;
            this.replaceQuotesBtn.Text = "„ “ to « »";
            this.replaceQuotesBtn.UseVisualStyleBackColor = true;
            this.replaceQuotesBtn.Click += new System.EventHandler(this.replaceQuotesBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 431);
            this.Controls.Add(this.replaceQuotesBtn);
            this.Controls.Add(this.removeSpaceBtn);
            this.Controls.Add(this.replaceNumberBtn);
            this.Controls.Add(this.replaceCodeBtn);
            this.Controls.Add(this.replaceBucksBtn);
            this.Controls.Add(this.replaceMailBtn);
            this.Controls.Add(this.replaceURLBtn);
            this.Controls.Add(this.dateReplaceBtn);
            this.Controls.Add(this.RemoveTagBtn);
            this.Controls.Add(this.GetInfoBtn);
            this.Controls.Add(this.infoTBox);
            this.Controls.Add(this.countLbl);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.patternTBox);
            this.Controls.Add(this.inputStringTBox);
            this.Name = "Form1";
            this.Text = "Regular expressions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputStringTBox;
        private System.Windows.Forms.TextBox patternTBox;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Label countLbl;
        private System.Windows.Forms.TextBox infoTBox;
        private System.Windows.Forms.Button GetInfoBtn;
        private System.Windows.Forms.Button RemoveTagBtn;
        private System.Windows.Forms.Button dateReplaceBtn;
        private System.Windows.Forms.Button replaceURLBtn;
        private System.Windows.Forms.Button replaceMailBtn;
        private System.Windows.Forms.Button replaceBucksBtn;
        private System.Windows.Forms.Button replaceCodeBtn;
        private System.Windows.Forms.Button replaceNumberBtn;
        private System.Windows.Forms.Button removeSpaceBtn;
        private System.Windows.Forms.Button replaceQuotesBtn;
    }
}

