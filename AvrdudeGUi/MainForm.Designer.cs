namespace avrdudeGUI
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadFuseButton = new System.Windows.Forms.Button();
            this.WriteFuseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EFuseTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LFuseTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HFuseTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ChipEraseButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeviceComboBox = new System.Windows.Forms.ComboBox();
            this.ProgramFlashButton = new System.Windows.Forms.Button();
            this.VerifyFlashButton = new System.Windows.Forms.Button();
            this.WriteFlashButton = new System.Windows.Forms.Button();
            this.ReadFlashButton = new System.Windows.Forms.Button();
            this.FlashFileButton = new System.Windows.Forms.Button();
            this.FlashFileTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.WriteEEPROMButton = new System.Windows.Forms.Button();
            this.ReadEEPROMButton = new System.Windows.Forms.Button();
            this.EEPROMFileButton = new System.Windows.Forms.Button();
            this.EEPROMFileTextBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ReadLockBitButton = new System.Windows.Forms.Button();
            this.WriteLockBitButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.LockBitTextBox = new System.Windows.Forms.TextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TerminalButton = new System.Windows.Forms.Button();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AvrdudeButton = new System.Windows.Forms.Button();
            this.AvrdudeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.CommandLineOptionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProgrammerComboBox = new System.Windows.Forms.ComboBox();
            this.WindowCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadFuseButton);
            this.groupBox2.Controls.Add(this.WriteFuseButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EFuseTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LFuseTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.HFuseTextBox);
            this.groupBox2.Location = new System.Drawing.Point(141, 96);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(172, 112);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fuse";
            // 
            // ReadFuseButton
            // 
            this.ReadFuseButton.Location = new System.Drawing.Point(106, 15);
            this.ReadFuseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReadFuseButton.Name = "ReadFuseButton";
            this.ReadFuseButton.Size = new System.Drawing.Size(62, 28);
            this.ReadFuseButton.TabIndex = 3;
            this.ReadFuseButton.Text = "Read";
            this.ReadFuseButton.UseVisualStyleBackColor = true;
            this.ReadFuseButton.Click += new System.EventHandler(this.ReadFuseButton_Click);
            // 
            // WriteFuseButton
            // 
            this.WriteFuseButton.Location = new System.Drawing.Point(107, 44);
            this.WriteFuseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WriteFuseButton.Name = "WriteFuseButton";
            this.WriteFuseButton.Size = new System.Drawing.Size(62, 28);
            this.WriteFuseButton.TabIndex = 4;
            this.WriteFuseButton.Text = "Write";
            this.WriteFuseButton.UseVisualStyleBackColor = true;
            this.WriteFuseButton.Click += new System.EventHandler(this.WriteFuseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "h";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "eFuse";
            // 
            // EFuseTextBox
            // 
            this.EFuseTextBox.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EFuseTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.EFuseTextBox.Location = new System.Drawing.Point(58, 78);
            this.EFuseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EFuseTextBox.MaxLength = 2;
            this.EFuseTextBox.Name = "EFuseTextBox";
            this.EFuseTextBox.Size = new System.Drawing.Size(30, 20);
            this.EFuseTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "lFuse";
            // 
            // LFuseTextBox
            // 
            this.LFuseTextBox.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LFuseTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LFuseTextBox.Location = new System.Drawing.Point(58, 50);
            this.LFuseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LFuseTextBox.MaxLength = 2;
            this.LFuseTextBox.Name = "LFuseTextBox";
            this.LFuseTextBox.Size = new System.Drawing.Size(30, 20);
            this.LFuseTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "h";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "hFuse";
            // 
            // HFuseTextBox
            // 
            this.HFuseTextBox.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HFuseTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.HFuseTextBox.Location = new System.Drawing.Point(58, 23);
            this.HFuseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HFuseTextBox.MaxLength = 2;
            this.HFuseTextBox.Name = "HFuseTextBox";
            this.HFuseTextBox.Size = new System.Drawing.Size(30, 20);
            this.HFuseTextBox.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(141, 210);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(162, 28);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ChipEraseButton);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.ProgramFlashButton);
            this.groupBox5.Controls.Add(this.VerifyFlashButton);
            this.groupBox5.Controls.Add(this.WriteFlashButton);
            this.groupBox5.Controls.Add(this.ReadFlashButton);
            this.groupBox5.Controls.Add(this.FlashFileButton);
            this.groupBox5.Controls.Add(this.FlashFileTextBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(313, 212);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flash";
            // 
            // ChipEraseButton
            // 
            this.ChipEraseButton.Location = new System.Drawing.Point(221, 143);
            this.ChipEraseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChipEraseButton.Name = "ChipEraseButton";
            this.ChipEraseButton.Size = new System.Drawing.Size(86, 68);
            this.ChipEraseButton.TabIndex = 10;
            this.ChipEraseButton.Text = "Chip Erase";
            this.ChipEraseButton.UseVisualStyleBackColor = true;
            this.ChipEraseButton.Click += new System.EventHandler(this.ChipEraseButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeviceComboBox);
            this.groupBox3.Location = new System.Drawing.Point(0, 20);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(271, 50);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device";
            // 
            // DeviceComboBox
            // 
            this.DeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceComboBox.FormattingEnabled = true;
            this.DeviceComboBox.Location = new System.Drawing.Point(6, 19);
            this.DeviceComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeviceComboBox.Name = "DeviceComboBox";
            this.DeviceComboBox.Size = new System.Drawing.Size(259, 24);
            this.DeviceComboBox.TabIndex = 0;
            // 
            // ProgramFlashButton
            // 
            this.ProgramFlashButton.Location = new System.Drawing.Point(6, 174);
            this.ProgramFlashButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProgramFlashButton.Name = "ProgramFlashButton";
            this.ProgramFlashButton.Size = new System.Drawing.Size(209, 29);
            this.ProgramFlashButton.TabIndex = 5;
            this.ProgramFlashButton.Text = "Erase - Program- Verify";
            this.ProgramFlashButton.UseVisualStyleBackColor = true;
            this.ProgramFlashButton.Click += new System.EventHandler(this.ProgramFlashButton_Click);
            // 
            // VerifyFlashButton
            // 
            this.VerifyFlashButton.Location = new System.Drawing.Point(131, 143);
            this.VerifyFlashButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VerifyFlashButton.Name = "VerifyFlashButton";
            this.VerifyFlashButton.Size = new System.Drawing.Size(84, 28);
            this.VerifyFlashButton.TabIndex = 4;
            this.VerifyFlashButton.Text = "Verify";
            this.VerifyFlashButton.UseVisualStyleBackColor = true;
            this.VerifyFlashButton.Click += new System.EventHandler(this.VerifyFlashButton_Click);
            // 
            // WriteFlashButton
            // 
            this.WriteFlashButton.Location = new System.Drawing.Point(3, 99);
            this.WriteFlashButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WriteFlashButton.Name = "WriteFlashButton";
            this.WriteFlashButton.Size = new System.Drawing.Size(304, 42);
            this.WriteFlashButton.TabIndex = 3;
            this.WriteFlashButton.Text = "Program";
            this.WriteFlashButton.UseVisualStyleBackColor = true;
            this.WriteFlashButton.Click += new System.EventHandler(this.WriteFlashButton_Click);
            // 
            // ReadFlashButton
            // 
            this.ReadFlashButton.Location = new System.Drawing.Point(6, 143);
            this.ReadFlashButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReadFlashButton.Name = "ReadFlashButton";
            this.ReadFlashButton.Size = new System.Drawing.Size(124, 28);
            this.ReadFlashButton.TabIndex = 2;
            this.ReadFlashButton.Text = "Read";
            this.ReadFlashButton.UseVisualStyleBackColor = true;
            this.ReadFlashButton.Click += new System.EventHandler(this.ReadFlashButton_Click);
            // 
            // FlashFileButton
            // 
            this.FlashFileButton.Location = new System.Drawing.Point(271, 28);
            this.FlashFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlashFileButton.Name = "FlashFileButton";
            this.FlashFileButton.Size = new System.Drawing.Size(36, 69);
            this.FlashFileButton.TabIndex = 1;
            this.FlashFileButton.Text = "...";
            this.FlashFileButton.UseVisualStyleBackColor = true;
            this.FlashFileButton.Click += new System.EventHandler(this.FlashFileButton_Click);
            // 
            // FlashFileTextBox
            // 
            this.FlashFileTextBox.Location = new System.Drawing.Point(7, 72);
            this.FlashFileTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlashFileTextBox.Name = "FlashFileTextBox";
            this.FlashFileTextBox.Size = new System.Drawing.Size(264, 22);
            this.FlashFileTextBox.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.WriteEEPROMButton);
            this.groupBox6.Controls.Add(this.ReadEEPROMButton);
            this.groupBox6.Controls.Add(this.EEPROMFileButton);
            this.groupBox6.Controls.Add(this.EEPROMFileTextBox);
            this.groupBox6.Location = new System.Drawing.Point(6, 7);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Size = new System.Drawing.Size(297, 81);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "EEPROM";
            // 
            // WriteEEPROMButton
            // 
            this.WriteEEPROMButton.Location = new System.Drawing.Point(128, 45);
            this.WriteEEPROMButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WriteEEPROMButton.Name = "WriteEEPROMButton";
            this.WriteEEPROMButton.Size = new System.Drawing.Size(111, 28);
            this.WriteEEPROMButton.TabIndex = 3;
            this.WriteEEPROMButton.Text = "Write";
            this.WriteEEPROMButton.UseVisualStyleBackColor = true;
            this.WriteEEPROMButton.Click += new System.EventHandler(this.WriteEEPROMButton_Click);
            // 
            // ReadEEPROMButton
            // 
            this.ReadEEPROMButton.Location = new System.Drawing.Point(6, 46);
            this.ReadEEPROMButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReadEEPROMButton.Name = "ReadEEPROMButton";
            this.ReadEEPROMButton.Size = new System.Drawing.Size(116, 28);
            this.ReadEEPROMButton.TabIndex = 2;
            this.ReadEEPROMButton.Text = "Read";
            this.ReadEEPROMButton.UseVisualStyleBackColor = true;
            this.ReadEEPROMButton.Click += new System.EventHandler(this.ReadEEPROMButton_Click);
            // 
            // EEPROMFileButton
            // 
            this.EEPROMFileButton.Location = new System.Drawing.Point(245, 16);
            this.EEPROMFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EEPROMFileButton.Name = "EEPROMFileButton";
            this.EEPROMFileButton.Size = new System.Drawing.Size(26, 22);
            this.EEPROMFileButton.TabIndex = 1;
            this.EEPROMFileButton.Text = "...";
            this.EEPROMFileButton.UseVisualStyleBackColor = true;
            this.EEPROMFileButton.Click += new System.EventHandler(this.EEPROMFileButton_Click);
            // 
            // EEPROMFileTextBox
            // 
            this.EEPROMFileTextBox.Location = new System.Drawing.Point(4, 16);
            this.EEPROMFileTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EEPROMFileTextBox.Name = "EEPROMFileTextBox";
            this.EEPROMFileTextBox.Size = new System.Drawing.Size(235, 22);
            this.EEPROMFileTextBox.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ReadLockBitButton);
            this.groupBox7.Controls.Add(this.WriteLockBitButton);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.LockBitTextBox);
            this.groupBox7.Location = new System.Drawing.Point(6, 96);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(129, 112);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Lock Bit";
            // 
            // ReadLockBitButton
            // 
            this.ReadLockBitButton.Location = new System.Drawing.Point(63, 10);
            this.ReadLockBitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReadLockBitButton.Name = "ReadLockBitButton";
            this.ReadLockBitButton.Size = new System.Drawing.Size(62, 28);
            this.ReadLockBitButton.TabIndex = 1;
            this.ReadLockBitButton.Text = "Read";
            this.ReadLockBitButton.UseVisualStyleBackColor = true;
            this.ReadLockBitButton.Click += new System.EventHandler(this.ReadLockBitButton_Click);
            // 
            // WriteLockBitButton
            // 
            this.WriteLockBitButton.Location = new System.Drawing.Point(63, 45);
            this.WriteLockBitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WriteLockBitButton.Name = "WriteLockBitButton";
            this.WriteLockBitButton.Size = new System.Drawing.Size(62, 28);
            this.WriteLockBitButton.TabIndex = 2;
            this.WriteLockBitButton.Text = "Write";
            this.WriteLockBitButton.UseVisualStyleBackColor = true;
            this.WriteLockBitButton.Click += new System.EventHandler(this.WriteLockBitButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "h";
            // 
            // LockBitTextBox
            // 
            this.LockBitTextBox.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LockBitTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.LockBitTextBox.Location = new System.Drawing.Point(6, 37);
            this.LockBitTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LockBitTextBox.MaxLength = 2;
            this.LockBitTextBox.Name = "LockBitTextBox";
            this.LockBitTextBox.Size = new System.Drawing.Size(30, 20);
            this.LockBitTextBox.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(3, 222);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(313, 19);
            this.ProgressBar.TabIndex = 9;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // TerminalButton
            // 
            this.TerminalButton.Location = new System.Drawing.Point(7, 210);
            this.TerminalButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TerminalButton.Name = "TerminalButton";
            this.TerminalButton.Size = new System.Drawing.Size(128, 28);
            this.TerminalButton.TabIndex = 11;
            this.TerminalButton.Text = "Terminal";
            this.TerminalButton.UseVisualStyleBackColor = true;
            this.TerminalButton.Click += new System.EventHandler(this.TerminalButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(1, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(327, 274);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.ProgressBar);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(319, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flash";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.ExitButton);
            this.tabPage3.Controls.Add(this.TerminalButton);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(319, 245);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fuse";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(319, 245);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Configure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "gamchanMaxRobo @avrdude project";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AvrdudeButton);
            this.groupBox4.Controls.Add(this.AvrdudeTextBox);
            this.groupBox4.Location = new System.Drawing.Point(10, 4);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(296, 57);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "avrdude.exe File";
            // 
            // AvrdudeButton
            // 
            this.AvrdudeButton.Location = new System.Drawing.Point(260, 19);
            this.AvrdudeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AvrdudeButton.Name = "AvrdudeButton";
            this.AvrdudeButton.Size = new System.Drawing.Size(30, 25);
            this.AvrdudeButton.TabIndex = 1;
            this.AvrdudeButton.Text = "...";
            this.AvrdudeButton.UseVisualStyleBackColor = true;
            this.AvrdudeButton.Click += new System.EventHandler(this.AvrdudeButton_Click_1);
            // 
            // AvrdudeTextBox
            // 
            this.AvrdudeTextBox.Location = new System.Drawing.Point(6, 22);
            this.AvrdudeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AvrdudeTextBox.MaxLength = 32;
            this.AvrdudeTextBox.Name = "AvrdudeTextBox";
            this.AvrdudeTextBox.Size = new System.Drawing.Size(248, 22);
            this.AvrdudeTextBox.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.CommandLineOptionTextBox);
            this.groupBox9.Location = new System.Drawing.Point(194, 140);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(112, 71);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Command line Option";
            // 
            // CommandLineOptionTextBox
            // 
            this.CommandLineOptionTextBox.Location = new System.Drawing.Point(6, 35);
            this.CommandLineOptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CommandLineOptionTextBox.Name = "CommandLineOptionTextBox";
            this.CommandLineOptionTextBox.Size = new System.Drawing.Size(80, 22);
            this.CommandLineOptionTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProgrammerComboBox);
            this.groupBox1.Controls.Add(this.WindowCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(310, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Programmer";
            // 
            // ProgrammerComboBox
            // 
            this.ProgrammerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProgrammerComboBox.FormattingEnabled = true;
            this.ProgrammerComboBox.Location = new System.Drawing.Point(4, 37);
            this.ProgrammerComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProgrammerComboBox.Name = "ProgrammerComboBox";
            this.ProgrammerComboBox.Size = new System.Drawing.Size(300, 24);
            this.ProgrammerComboBox.TabIndex = 0;
            // 
            // WindowCheckBox
            // 
            this.WindowCheckBox.AutoSize = true;
            this.WindowCheckBox.Location = new System.Drawing.Point(170, 10);
            this.WindowCheckBox.Name = "WindowCheckBox";
            this.WindowCheckBox.Size = new System.Drawing.Size(120, 20);
            this.WindowCheckBox.TabIndex = 2;
            this.WindowCheckBox.Text = "Display Window";
            this.WindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.PortComboBox);
            this.groupBox8.Location = new System.Drawing.Point(10, 140);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(178, 71);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Port";
            // 
            // PortComboBox
            // 
            this.PortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(6, 22);
            this.PortComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(151, 24);
            this.PortComboBox.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.comboBox2);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.radioButton2);
            this.tabPage4.Controls.Add(this.radioButton1);
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(319, 245);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Terminal";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Baud ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Comport";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(80, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(228, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 37);
            this.button3.TabIndex = 7;
            this.button3.Text = "SEND";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 204);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 22);
            this.textBox1.TabIndex = 6;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(100, 224);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 20);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "text Mode";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 224);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 20);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Hex mode";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(306, 135);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.richTextBox2);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Controls.Add(this.pictureBox1);
            this.tabPage5.Controls.Add(this.button4);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(319, 245);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "CameraTes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(303, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(10, 10);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            this.richTextBox2.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "----";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "---";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(226, 65);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 50);
            this.button5.TabIndex = 2;
            this.button5.Text = "Save image";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(11, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 204);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(226, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 45);
            this.button4.TabIndex = 0;
            this.button4.Text = "Capture";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(330, 284);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Roboholicrazy ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EFuseTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LFuseTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HFuseTextBox;
        private System.Windows.Forms.Button WriteFuseButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ReadFuseButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button WriteFlashButton;
        private System.Windows.Forms.Button ReadFlashButton;
        private System.Windows.Forms.Button FlashFileButton;
        private System.Windows.Forms.TextBox FlashFileTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button WriteEEPROMButton;
        private System.Windows.Forms.Button ReadEEPROMButton;
        private System.Windows.Forms.Button EEPROMFileButton;
        private System.Windows.Forms.TextBox EEPROMFileTextBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button ReadLockBitButton;
        private System.Windows.Forms.Button WriteLockBitButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LockBitTextBox;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button ProgramFlashButton;
        private System.Windows.Forms.Button VerifyFlashButton;
        private System.Windows.Forms.Button ChipEraseButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button TerminalButton;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button AvrdudeButton;
        private System.Windows.Forms.TextBox AvrdudeTextBox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox CommandLineOptionTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ProgrammerComboBox;
        private System.Windows.Forms.CheckBox WindowCheckBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox DeviceComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label13;
    }
}

