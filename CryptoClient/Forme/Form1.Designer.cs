namespace CryptoClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.fswOnBtn = new System.Windows.Forms.RadioButton();
            this.fswOffBtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.srcBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dstBtn = new System.Windows.Forms.Button();
            this.cloudBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.f22TxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.A52CtrModeCbox = new System.Windows.Forms.CheckBox();
            this.A52FileDecryptBtn = new System.Windows.Forms.Button();
            this.A52FileCryptBtn = new System.Windows.Forms.Button();
            this.A52decryptBtn = new System.Windows.Forms.Button();
            this.A52cryptBtn = new System.Windows.Forms.Button();
            this.A52decryptedTxt = new System.Windows.Forms.TextBox();
            this.A52cryptedTxt = new System.Windows.Forms.TextBox();
            this.A52inputTxt = new System.Windows.Forms.TextBox();
            this.A52IVtxtBox = new System.Windows.Forms.TextBox();
            this.A52KeyTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.A52IVLbl = new System.Windows.Forms.Label();
            this.A52KeyLbl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rc4CtrCbx = new System.Windows.Forms.CheckBox();
            this.rc4DecryptFileBtn = new System.Windows.Forms.Button();
            this.rc4CryptFileBtn = new System.Windows.Forms.Button();
            this.rc4CryptTxtBtn = new System.Windows.Forms.Button();
            this.rc4DecryptTxtBtn = new System.Windows.Forms.Button();
            this.rc4DecrytedTxtBox = new System.Windows.Forms.TextBox();
            this.rc4CryptedTxtBox = new System.Windows.Forms.TextBox();
            this.rc4InputTxtBox = new System.Windows.Forms.TextBox();
            this.rc4IVTxtBox = new System.Windows.Forms.TextBox();
            this.rc4KeyTxtBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ETxtBox = new System.Windows.Forms.TextBox();
            this.rsaDecryptTxtBtn = new System.Windows.Forms.Button();
            this.rsaCryptTxtBtn = new System.Windows.Forms.Button();
            this.rsaDecryptedTxtBox = new System.Windows.Forms.TextBox();
            this.rsaCryptedTxtBox = new System.Windows.Forms.TextBox();
            this.rsaInputTxtBox = new System.Windows.Forms.TextBox();
            this.QTxtBox = new System.Windows.Forms.TextBox();
            this.PTxtBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.computeHashBtn = new System.Windows.Forms.Button();
            this.hashValueTxtBox = new System.Windows.Forms.TextBox();
            this.tigerInputTxtBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FocusLbl = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "File System Watcher:";
            // 
            // fswOnBtn
            // 
            this.fswOnBtn.AutoSize = true;
            this.fswOnBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fswOnBtn.Location = new System.Drawing.Point(7, 25);
            this.fswOnBtn.Name = "fswOnBtn";
            this.fswOnBtn.Size = new System.Drawing.Size(46, 23);
            this.fswOnBtn.TabIndex = 1;
            this.fswOnBtn.TabStop = true;
            this.fswOnBtn.Text = "On";
            this.fswOnBtn.UseVisualStyleBackColor = true;
            this.fswOnBtn.Click += new System.EventHandler(this.fswOnBtn_Click);
            // 
            // fswOffBtn
            // 
            this.fswOffBtn.AutoSize = true;
            this.fswOffBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fswOffBtn.Location = new System.Drawing.Point(52, 25);
            this.fswOffBtn.Name = "fswOffBtn";
            this.fswOffBtn.Size = new System.Drawing.Size(48, 23);
            this.fswOffBtn.TabIndex = 2;
            this.fswOffBtn.TabStop = true;
            this.fswOffBtn.Text = "Off";
            this.fswOffBtn.UseVisualStyleBackColor = true;
            this.fswOffBtn.Click += new System.EventHandler(this.fswOffBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(402, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select source folder:";
            // 
            // srcBtn
            // 
            this.srcBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcBtn.Location = new System.Drawing.Point(405, 53);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Size = new System.Drawing.Size(156, 41);
            this.srcBtn.TabIndex = 4;
            this.srcBtn.TabStop = false;
            this.srcBtn.Text = "Source folder";
            this.srcBtn.UseVisualStyleBackColor = true;
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(576, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select destination folder:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(789, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Browse files on cloud:";
            // 
            // dstBtn
            // 
            this.dstBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dstBtn.Location = new System.Drawing.Point(579, 53);
            this.dstBtn.Name = "dstBtn";
            this.dstBtn.Size = new System.Drawing.Size(156, 41);
            this.dstBtn.TabIndex = 7;
            this.dstBtn.TabStop = false;
            this.dstBtn.Text = "Destination folder";
            this.dstBtn.UseVisualStyleBackColor = true;
            this.dstBtn.Click += new System.EventHandler(this.dstBtn_Click);
            // 
            // cloudBtn
            // 
            this.cloudBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cloudBtn.Location = new System.Drawing.Point(792, 53);
            this.cloudBtn.Name = "cloudBtn";
            this.cloudBtn.Size = new System.Drawing.Size(156, 41);
            this.cloudBtn.TabIndex = 8;
            this.cloudBtn.TabStop = false;
            this.cloudBtn.Text = "Mini Cloud";
            this.cloudBtn.UseVisualStyleBackColor = true;
            this.cloudBtn.Click += new System.EventHandler(this.cloudBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 124);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1177, 562);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.Controls.Add(this.f22TxtBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.A52CtrModeCbox);
            this.tabPage1.Controls.Add(this.A52FileDecryptBtn);
            this.tabPage1.Controls.Add(this.A52FileCryptBtn);
            this.tabPage1.Controls.Add(this.A52decryptBtn);
            this.tabPage1.Controls.Add(this.A52cryptBtn);
            this.tabPage1.Controls.Add(this.A52decryptedTxt);
            this.tabPage1.Controls.Add(this.A52cryptedTxt);
            this.tabPage1.Controls.Add(this.A52inputTxt);
            this.tabPage1.Controls.Add(this.A52IVtxtBox);
            this.tabPage1.Controls.Add(this.A52KeyTxtBox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.A52IVLbl);
            this.tabPage1.Controls.Add(this.A52KeyLbl);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1169, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "A52";
            // 
            // f22TxtBox
            // 
            this.f22TxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f22TxtBox.Location = new System.Drawing.Point(320, 41);
            this.f22TxtBox.MaxLength = 22;
            this.f22TxtBox.Name = "f22TxtBox";
            this.f22TxtBox.Size = new System.Drawing.Size(213, 23);
            this.f22TxtBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "f(22bits):";
            // 
            // A52CtrModeCbox
            // 
            this.A52CtrModeCbox.AutoSize = true;
            this.A52CtrModeCbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.A52CtrModeCbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52CtrModeCbox.Location = new System.Drawing.Point(563, 67);
            this.A52CtrModeCbox.Name = "A52CtrModeCbox";
            this.A52CtrModeCbox.Size = new System.Drawing.Size(101, 23);
            this.A52CtrModeCbox.TabIndex = 16;
            this.A52CtrModeCbox.Text = "CTR Mode:";
            this.A52CtrModeCbox.UseVisualStyleBackColor = true;
            // 
            // A52FileDecryptBtn
            // 
            this.A52FileDecryptBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52FileDecryptBtn.Location = new System.Drawing.Point(1029, 41);
            this.A52FileDecryptBtn.Name = "A52FileDecryptBtn";
            this.A52FileDecryptBtn.Size = new System.Drawing.Size(109, 36);
            this.A52FileDecryptBtn.TabIndex = 15;
            this.A52FileDecryptBtn.TabStop = false;
            this.A52FileDecryptBtn.Text = "Decrypt file";
            this.A52FileDecryptBtn.UseVisualStyleBackColor = true;
            this.A52FileDecryptBtn.Click += new System.EventHandler(this.A52FileDecryptBtn_Click);
            // 
            // A52FileCryptBtn
            // 
            this.A52FileCryptBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52FileCryptBtn.Location = new System.Drawing.Point(914, 41);
            this.A52FileCryptBtn.Name = "A52FileCryptBtn";
            this.A52FileCryptBtn.Size = new System.Drawing.Size(109, 36);
            this.A52FileCryptBtn.TabIndex = 14;
            this.A52FileCryptBtn.TabStop = false;
            this.A52FileCryptBtn.Text = "Crypt file";
            this.A52FileCryptBtn.UseVisualStyleBackColor = true;
            this.A52FileCryptBtn.Click += new System.EventHandler(this.A52FileCryptBtn_Click);
            // 
            // A52decryptBtn
            // 
            this.A52decryptBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52decryptBtn.Location = new System.Drawing.Point(1016, 286);
            this.A52decryptBtn.Name = "A52decryptBtn";
            this.A52decryptBtn.Size = new System.Drawing.Size(122, 49);
            this.A52decryptBtn.TabIndex = 13;
            this.A52decryptBtn.TabStop = false;
            this.A52decryptBtn.Text = "Decrypt text";
            this.A52decryptBtn.UseVisualStyleBackColor = true;
            this.A52decryptBtn.Click += new System.EventHandler(this.A52decryptBtn_Click);
            // 
            // A52cryptBtn
            // 
            this.A52cryptBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52cryptBtn.Location = new System.Drawing.Point(1016, 155);
            this.A52cryptBtn.Name = "A52cryptBtn";
            this.A52cryptBtn.Size = new System.Drawing.Size(123, 49);
            this.A52cryptBtn.TabIndex = 12;
            this.A52cryptBtn.TabStop = false;
            this.A52cryptBtn.Text = "Crypt text";
            this.A52cryptBtn.UseVisualStyleBackColor = true;
            this.A52cryptBtn.Click += new System.EventHandler(this.A52cryptBtn_Click);
            // 
            // A52decryptedTxt
            // 
            this.A52decryptedTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52decryptedTxt.Location = new System.Drawing.Point(26, 404);
            this.A52decryptedTxt.Multiline = true;
            this.A52decryptedTxt.Name = "A52decryptedTxt";
            this.A52decryptedTxt.ReadOnly = true;
            this.A52decryptedTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.A52decryptedTxt.Size = new System.Drawing.Size(952, 100);
            this.A52decryptedTxt.TabIndex = 11;
            // 
            // A52cryptedTxt
            // 
            this.A52cryptedTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52cryptedTxt.Location = new System.Drawing.Point(26, 269);
            this.A52cryptedTxt.Multiline = true;
            this.A52cryptedTxt.Name = "A52cryptedTxt";
            this.A52cryptedTxt.ReadOnly = true;
            this.A52cryptedTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.A52cryptedTxt.Size = new System.Drawing.Size(952, 100);
            this.A52cryptedTxt.TabIndex = 10;
            // 
            // A52inputTxt
            // 
            this.A52inputTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52inputTxt.Location = new System.Drawing.Point(26, 131);
            this.A52inputTxt.Multiline = true;
            this.A52inputTxt.Name = "A52inputTxt";
            this.A52inputTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.A52inputTxt.Size = new System.Drawing.Size(952, 100);
            this.A52inputTxt.TabIndex = 9;
            // 
            // A52IVtxtBox
            // 
            this.A52IVtxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52IVtxtBox.Location = new System.Drawing.Point(592, 41);
            this.A52IVtxtBox.MaxLength = 8;
            this.A52IVtxtBox.Name = "A52IVtxtBox";
            this.A52IVtxtBox.Size = new System.Drawing.Size(180, 23);
            this.A52IVtxtBox.TabIndex = 8;
            // 
            // A52KeyTxtBox
            // 
            this.A52KeyTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52KeyTxtBox.Location = new System.Drawing.Point(70, 41);
            this.A52KeyTxtBox.MaxLength = 8;
            this.A52KeyTxtBox.Name = "A52KeyTxtBox";
            this.A52KeyTxtBox.Size = new System.Drawing.Size(154, 23);
            this.A52KeyTxtBox.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(911, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 5;
            this.label10.Text = "Select file:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Decrypted text:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Crypted text:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Insert text to crypt:";
            // 
            // A52IVLbl
            // 
            this.A52IVLbl.AutoSize = true;
            this.A52IVLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52IVLbl.Location = new System.Drawing.Point(561, 41);
            this.A52IVLbl.Name = "A52IVLbl";
            this.A52IVLbl.Size = new System.Drawing.Size(26, 19);
            this.A52IVLbl.TabIndex = 1;
            this.A52IVLbl.Text = "IV:";
            // 
            // A52KeyLbl
            // 
            this.A52KeyLbl.AutoSize = true;
            this.A52KeyLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A52KeyLbl.Location = new System.Drawing.Point(30, 41);
            this.A52KeyLbl.Name = "A52KeyLbl";
            this.A52KeyLbl.Size = new System.Drawing.Size(38, 19);
            this.A52KeyLbl.TabIndex = 0;
            this.A52KeyLbl.Text = "Key:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Lavender;
            this.tabPage2.Controls.Add(this.rc4CtrCbx);
            this.tabPage2.Controls.Add(this.rc4DecryptFileBtn);
            this.tabPage2.Controls.Add(this.rc4CryptFileBtn);
            this.tabPage2.Controls.Add(this.rc4CryptTxtBtn);
            this.tabPage2.Controls.Add(this.rc4DecryptTxtBtn);
            this.tabPage2.Controls.Add(this.rc4DecrytedTxtBox);
            this.tabPage2.Controls.Add(this.rc4CryptedTxtBox);
            this.tabPage2.Controls.Add(this.rc4InputTxtBox);
            this.tabPage2.Controls.Add(this.rc4IVTxtBox);
            this.tabPage2.Controls.Add(this.rc4KeyTxtBox);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1169, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RC4";
            // 
            // rc4CtrCbx
            // 
            this.rc4CtrCbx.AutoSize = true;
            this.rc4CtrCbx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rc4CtrCbx.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4CtrCbx.Location = new System.Drawing.Point(260, 39);
            this.rc4CtrCbx.Name = "rc4CtrCbx";
            this.rc4CtrCbx.Size = new System.Drawing.Size(101, 23);
            this.rc4CtrCbx.TabIndex = 33;
            this.rc4CtrCbx.Text = "CTR Mode:";
            this.rc4CtrCbx.UseVisualStyleBackColor = true;
            // 
            // rc4DecryptFileBtn
            // 
            this.rc4DecryptFileBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4DecryptFileBtn.Location = new System.Drawing.Point(1029, 41);
            this.rc4DecryptFileBtn.Name = "rc4DecryptFileBtn";
            this.rc4DecryptFileBtn.Size = new System.Drawing.Size(109, 36);
            this.rc4DecryptFileBtn.TabIndex = 32;
            this.rc4DecryptFileBtn.TabStop = false;
            this.rc4DecryptFileBtn.Text = "Decrypt file";
            this.rc4DecryptFileBtn.UseVisualStyleBackColor = true;
            this.rc4DecryptFileBtn.Click += new System.EventHandler(this.rc4DecryptFileBtn_Click);
            // 
            // rc4CryptFileBtn
            // 
            this.rc4CryptFileBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4CryptFileBtn.Location = new System.Drawing.Point(914, 41);
            this.rc4CryptFileBtn.Name = "rc4CryptFileBtn";
            this.rc4CryptFileBtn.Size = new System.Drawing.Size(109, 36);
            this.rc4CryptFileBtn.TabIndex = 31;
            this.rc4CryptFileBtn.TabStop = false;
            this.rc4CryptFileBtn.Text = "Crypt file";
            this.rc4CryptFileBtn.UseVisualStyleBackColor = true;
            this.rc4CryptFileBtn.Click += new System.EventHandler(this.rc4CryptFileBtn_Click);
            // 
            // rc4CryptTxtBtn
            // 
            this.rc4CryptTxtBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4CryptTxtBtn.Location = new System.Drawing.Point(1016, 155);
            this.rc4CryptTxtBtn.Name = "rc4CryptTxtBtn";
            this.rc4CryptTxtBtn.Size = new System.Drawing.Size(123, 49);
            this.rc4CryptTxtBtn.TabIndex = 30;
            this.rc4CryptTxtBtn.TabStop = false;
            this.rc4CryptTxtBtn.Text = "Crypt text";
            this.rc4CryptTxtBtn.UseVisualStyleBackColor = true;
            this.rc4CryptTxtBtn.Click += new System.EventHandler(this.rc4CryptTxtBtn_Click);
            // 
            // rc4DecryptTxtBtn
            // 
            this.rc4DecryptTxtBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4DecryptTxtBtn.Location = new System.Drawing.Point(1016, 286);
            this.rc4DecryptTxtBtn.Name = "rc4DecryptTxtBtn";
            this.rc4DecryptTxtBtn.Size = new System.Drawing.Size(123, 49);
            this.rc4DecryptTxtBtn.TabIndex = 29;
            this.rc4DecryptTxtBtn.TabStop = false;
            this.rc4DecryptTxtBtn.Text = "Decrypt text";
            this.rc4DecryptTxtBtn.UseVisualStyleBackColor = true;
            this.rc4DecryptTxtBtn.Click += new System.EventHandler(this.rc4DecryptTxtBtn_Click);
            // 
            // rc4DecrytedTxtBox
            // 
            this.rc4DecrytedTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4DecrytedTxtBox.Location = new System.Drawing.Point(26, 404);
            this.rc4DecrytedTxtBox.Multiline = true;
            this.rc4DecrytedTxtBox.Name = "rc4DecrytedTxtBox";
            this.rc4DecrytedTxtBox.ReadOnly = true;
            this.rc4DecrytedTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rc4DecrytedTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rc4DecrytedTxtBox.TabIndex = 28;
            // 
            // rc4CryptedTxtBox
            // 
            this.rc4CryptedTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4CryptedTxtBox.Location = new System.Drawing.Point(26, 269);
            this.rc4CryptedTxtBox.Multiline = true;
            this.rc4CryptedTxtBox.Name = "rc4CryptedTxtBox";
            this.rc4CryptedTxtBox.ReadOnly = true;
            this.rc4CryptedTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rc4CryptedTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rc4CryptedTxtBox.TabIndex = 27;
            // 
            // rc4InputTxtBox
            // 
            this.rc4InputTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4InputTxtBox.Location = new System.Drawing.Point(26, 131);
            this.rc4InputTxtBox.Multiline = true;
            this.rc4InputTxtBox.Name = "rc4InputTxtBox";
            this.rc4InputTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rc4InputTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rc4InputTxtBox.TabIndex = 26;
            // 
            // rc4IVTxtBox
            // 
            this.rc4IVTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4IVTxtBox.Location = new System.Drawing.Point(442, 42);
            this.rc4IVTxtBox.Name = "rc4IVTxtBox";
            this.rc4IVTxtBox.Size = new System.Drawing.Size(154, 23);
            this.rc4IVTxtBox.TabIndex = 25;
            // 
            // rc4KeyTxtBox
            // 
            this.rc4KeyTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rc4KeyTxtBox.Location = new System.Drawing.Point(70, 41);
            this.rc4KeyTxtBox.Name = "rc4KeyTxtBox";
            this.rc4KeyTxtBox.Size = new System.Drawing.Size(154, 23);
            this.rc4KeyTxtBox.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(911, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 19);
            this.label13.TabIndex = 22;
            this.label13.Text = "Select file:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 384);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 19);
            this.label14.TabIndex = 21;
            this.label14.Text = "Decrypted text:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(23, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 19);
            this.label15.TabIndex = 20;
            this.label15.Text = "Crypted text:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 111);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(138, 19);
            this.label16.TabIndex = 19;
            this.label16.Text = "Insert text to crypt:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(410, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 19);
            this.label17.TabIndex = 18;
            this.label17.Text = "IV:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(30, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 19);
            this.label18.TabIndex = 17;
            this.label18.Text = "Key:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Lavender;
            this.tabPage3.Controls.Add(this.ETxtBox);
            this.tabPage3.Controls.Add(this.rsaDecryptTxtBtn);
            this.tabPage3.Controls.Add(this.rsaCryptTxtBtn);
            this.tabPage3.Controls.Add(this.rsaDecryptedTxtBox);
            this.tabPage3.Controls.Add(this.rsaCryptedTxtBox);
            this.tabPage3.Controls.Add(this.rsaInputTxtBox);
            this.tabPage3.Controls.Add(this.QTxtBox);
            this.tabPage3.Controls.Add(this.PTxtBox);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1169, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RSA";
            // 
            // ETxtBox
            // 
            this.ETxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ETxtBox.Location = new System.Drawing.Point(674, 46);
            this.ETxtBox.Name = "ETxtBox";
            this.ETxtBox.Size = new System.Drawing.Size(237, 23);
            this.ETxtBox.TabIndex = 44;
            this.ETxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ETxtBox_KeyPress);
            // 
            // rsaDecryptTxtBtn
            // 
            this.rsaDecryptTxtBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsaDecryptTxtBtn.Location = new System.Drawing.Point(1016, 286);
            this.rsaDecryptTxtBtn.Name = "rsaDecryptTxtBtn";
            this.rsaDecryptTxtBtn.Size = new System.Drawing.Size(123, 49);
            this.rsaDecryptTxtBtn.TabIndex = 43;
            this.rsaDecryptTxtBtn.TabStop = false;
            this.rsaDecryptTxtBtn.Text = "Decrypt text";
            this.rsaDecryptTxtBtn.UseVisualStyleBackColor = true;
            this.rsaDecryptTxtBtn.Click += new System.EventHandler(this.rsaDecryptTxtBtn_Click);
            // 
            // rsaCryptTxtBtn
            // 
            this.rsaCryptTxtBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsaCryptTxtBtn.Location = new System.Drawing.Point(1016, 155);
            this.rsaCryptTxtBtn.Name = "rsaCryptTxtBtn";
            this.rsaCryptTxtBtn.Size = new System.Drawing.Size(123, 49);
            this.rsaCryptTxtBtn.TabIndex = 42;
            this.rsaCryptTxtBtn.TabStop = false;
            this.rsaCryptTxtBtn.Text = "Crypt text";
            this.rsaCryptTxtBtn.UseVisualStyleBackColor = true;
            this.rsaCryptTxtBtn.Click += new System.EventHandler(this.rsaCryptTxtBtn_Click);
            // 
            // rsaDecryptedTxtBox
            // 
            this.rsaDecryptedTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsaDecryptedTxtBox.Location = new System.Drawing.Point(26, 404);
            this.rsaDecryptedTxtBox.Multiline = true;
            this.rsaDecryptedTxtBox.Name = "rsaDecryptedTxtBox";
            this.rsaDecryptedTxtBox.ReadOnly = true;
            this.rsaDecryptedTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rsaDecryptedTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rsaDecryptedTxtBox.TabIndex = 41;
            // 
            // rsaCryptedTxtBox
            // 
            this.rsaCryptedTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsaCryptedTxtBox.Location = new System.Drawing.Point(26, 269);
            this.rsaCryptedTxtBox.Multiline = true;
            this.rsaCryptedTxtBox.Name = "rsaCryptedTxtBox";
            this.rsaCryptedTxtBox.ReadOnly = true;
            this.rsaCryptedTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rsaCryptedTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rsaCryptedTxtBox.TabIndex = 40;
            // 
            // rsaInputTxtBox
            // 
            this.rsaInputTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsaInputTxtBox.Location = new System.Drawing.Point(26, 131);
            this.rsaInputTxtBox.Multiline = true;
            this.rsaInputTxtBox.Name = "rsaInputTxtBox";
            this.rsaInputTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rsaInputTxtBox.Size = new System.Drawing.Size(952, 100);
            this.rsaInputTxtBox.TabIndex = 39;
            this.rsaInputTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rsaInputTxtBox_KeyPress);
            // 
            // QTxtBox
            // 
            this.QTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QTxtBox.Location = new System.Drawing.Point(368, 46);
            this.QTxtBox.Name = "QTxtBox";
            this.QTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.QTxtBox.Size = new System.Drawing.Size(237, 23);
            this.QTxtBox.TabIndex = 38;
            this.QTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QTxtBox_KeyPress);
            // 
            // PTxtBox
            // 
            this.PTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTxtBox.Location = new System.Drawing.Point(61, 46);
            this.PTxtBox.Name = "PTxtBox";
            this.PTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PTxtBox.Size = new System.Drawing.Size(237, 23);
            this.PTxtBox.TabIndex = 37;
            this.PTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PTxtBox_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(639, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 19);
            this.label21.TabIndex = 36;
            this.label21.Text = "E:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 384);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 19);
            this.label22.TabIndex = 35;
            this.label22.Text = "Decrypted text:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(23, 249);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 19);
            this.label23.TabIndex = 34;
            this.label23.Text = "Crypted text:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(23, 111);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(138, 19);
            this.label24.TabIndex = 33;
            this.label24.Text = "Insert text to crypt:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(328, 46);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 19);
            this.label25.TabIndex = 32;
            this.label25.Text = "Q:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(23, 46);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(22, 19);
            this.label26.TabIndex = 31;
            this.label26.Text = "P:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Lavender;
            this.tabPage4.Controls.Add(this.computeHashBtn);
            this.tabPage4.Controls.Add(this.hashValueTxtBox);
            this.tabPage4.Controls.Add(this.tigerInputTxtBox);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1169, 533);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "TigerHash";
            // 
            // computeHashBtn
            // 
            this.computeHashBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.computeHashBtn.Location = new System.Drawing.Point(434, 271);
            this.computeHashBtn.Name = "computeHashBtn";
            this.computeHashBtn.Size = new System.Drawing.Size(143, 53);
            this.computeHashBtn.TabIndex = 34;
            this.computeHashBtn.TabStop = false;
            this.computeHashBtn.Text = "Compute hash";
            this.computeHashBtn.UseVisualStyleBackColor = true;
            this.computeHashBtn.Click += new System.EventHandler(this.computeHashBtn_Click);
            // 
            // hashValueTxtBox
            // 
            this.hashValueTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashValueTxtBox.Location = new System.Drawing.Point(328, 356);
            this.hashValueTxtBox.Name = "hashValueTxtBox";
            this.hashValueTxtBox.ReadOnly = true;
            this.hashValueTxtBox.Size = new System.Drawing.Size(467, 23);
            this.hashValueTxtBox.TabIndex = 33;
            // 
            // tigerInputTxtBox
            // 
            this.tigerInputTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tigerInputTxtBox.Location = new System.Drawing.Point(70, 114);
            this.tigerInputTxtBox.Multiline = true;
            this.tigerInputTxtBox.Name = "tigerInputTxtBox";
            this.tigerInputTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tigerInputTxtBox.Size = new System.Drawing.Size(952, 138);
            this.tigerInputTxtBox.TabIndex = 32;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(236, 356);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 19);
            this.label19.TabIndex = 31;
            this.label19.Text = "Hash value:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(66, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 19);
            this.label20.TabIndex = 30;
            this.label20.Text = "Insert text:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fswOffBtn);
            this.groupBox1.Controls.Add(this.fswOnBtn);
            this.groupBox1.Location = new System.Drawing.Point(173, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 67);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // FocusLbl
            // 
            this.FocusLbl.AutoSize = true;
            this.FocusLbl.Location = new System.Drawing.Point(1056, 53);
            this.FocusLbl.Name = "FocusLbl";
            this.FocusLbl.Size = new System.Drawing.Size(0, 13);
            this.FocusLbl.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1201, 703);
            this.Controls.Add(this.FocusLbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cloudBtn);
            this.Controls.Add(this.dstBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.srcBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Crypto Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton fswOnBtn;
        private System.Windows.Forms.RadioButton fswOffBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button srcBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dstBtn;
        private System.Windows.Forms.Button cloudBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox A52CtrModeCbox;
        private System.Windows.Forms.Button A52FileDecryptBtn;
        private System.Windows.Forms.Button A52FileCryptBtn;
        private System.Windows.Forms.Button A52decryptBtn;
        private System.Windows.Forms.Button A52cryptBtn;
        private System.Windows.Forms.TextBox A52decryptedTxt;
        private System.Windows.Forms.TextBox A52cryptedTxt;
        private System.Windows.Forms.TextBox A52inputTxt;
        private System.Windows.Forms.TextBox A52IVtxtBox;
        private System.Windows.Forms.TextBox A52KeyTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label A52IVLbl;
        private System.Windows.Forms.Label A52KeyLbl;
        private System.Windows.Forms.Label FocusLbl;
        private System.Windows.Forms.CheckBox rc4CtrCbx;
        private System.Windows.Forms.Button rc4DecryptFileBtn;
        private System.Windows.Forms.Button rc4CryptFileBtn;
        private System.Windows.Forms.Button rc4CryptTxtBtn;
        private System.Windows.Forms.Button rc4DecryptTxtBtn;
        private System.Windows.Forms.TextBox rc4DecrytedTxtBox;
        private System.Windows.Forms.TextBox rc4CryptedTxtBox;
        private System.Windows.Forms.TextBox rc4InputTxtBox;
        private System.Windows.Forms.TextBox rc4IVTxtBox;
        private System.Windows.Forms.TextBox rc4KeyTxtBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox ETxtBox;
        private System.Windows.Forms.Button rsaDecryptTxtBtn;
        private System.Windows.Forms.Button rsaCryptTxtBtn;
        private System.Windows.Forms.TextBox rsaDecryptedTxtBox;
        private System.Windows.Forms.TextBox rsaCryptedTxtBox;
        private System.Windows.Forms.TextBox rsaInputTxtBox;
        private System.Windows.Forms.TextBox QTxtBox;
        private System.Windows.Forms.TextBox PTxtBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button computeHashBtn;
        private System.Windows.Forms.TextBox hashValueTxtBox;
        private System.Windows.Forms.TextBox tigerInputTxtBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox f22TxtBox;
        private System.Windows.Forms.Label label5;
    }
}

