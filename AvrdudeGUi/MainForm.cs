using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace avrdudeGUI {
    
    public partial class MainForm : Form {
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        /// <summary>
        /// avrdude.exe ファイル選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int bytes;
        Boolean x;
        byte[] buffer;
        /// <summary>
        /// チップ消去ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChipEraseButton_Click(object sender, EventArgs e) {

            if (MessageBox.Show("All the settings and data in the device are deleted. Is it good ?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes) {
                ExecCommand("-e", 50, false);
            }
        }

        /// <summary>
        /// ターミナルモードボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminalButton_Click(object sender, EventArgs e) {

            if (AvrdudeTextBox.Text.Length == 0) {
                MessageBox.Show("Select avrdude.exe File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AvrdudeButton.Focus();
                return;
            }
            if (ProgrammerComboBox.SelectedIndex < 0) {
                MessageBox.Show("Select Programmer", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProgrammerComboBox.Focus();
                return;
            }
            if (DeviceComboBox.SelectedIndex < 0) {
                MessageBox.Show("Select Device", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DeviceComboBox.Focus();
                return;
            }

            System.Diagnostics.Process prc = null;
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = System.Environment.GetEnvironmentVariable("comspec");
            psi.Arguments = " /K \"" + AvrdudeTextBox.Text + "\" "; // 終了しても Windows Closeしない
            psi.Arguments += GetArg();
            psi.Arguments += " -t";
            prc = System.Diagnostics.Process.Start(psi);
            prc.WaitForExit();
        }


        /// <summary>
        /// ヒューズ読み込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadFuseButton_Click(object sender, EventArgs e) {
            string hfuse;
            string lfuse;
            string efuse;
            StreamReader sr;
            string data;
            string temp;

            HFuseTextBox.Text = "";
            LFuseTextBox.Text = "";
            EFuseTextBox.Text = "";

            hfuse = "_hfuse_.txt";
            lfuse = "_lfuse_.txt";
            efuse = "_efuse_.txt";
            temp = Environment.GetEnvironmentVariable("temp") + "\\";

            File.Delete(temp + hfuse);
            File.Delete(temp + lfuse);
            File.Delete(temp + efuse);

            // hfuse と lfuse 読み込み
            if (ExecCommand("-U hfuse:r:" + hfuse + ":h -U lfuse:r:" + lfuse + ":h",
                150, false) == 0) {

                if (File.Exists(temp + hfuse)) {
                    sr = new StreamReader(temp + hfuse);
                    data = sr.ReadLine();
                    if (data.Length == 3){
                        HFuseTextBox.Text = "0" + data.Substring(2, 1).ToUpper();
                    } else if (data.Length == 4){
                        HFuseTextBox.Text = data.Substring(2, 2).ToUpper();
                    }
                    sr.Close();
                }
                if (File.Exists(temp + lfuse)) {
                    sr = new StreamReader(temp + lfuse);
                    data = sr.ReadLine();
                    if (data.Length == 3){
                        LFuseTextBox.Text = "0" + data.Substring(2, 1).ToUpper();
                    } else if (data.Length == 4){
                        LFuseTextBox.Text = data.Substring(2, 2).ToUpper();
                    }
                    sr.Close();
                }

                // AVRISPmkIIの場合は時間待ちが必要???
                System.Windows.Forms.Cursor cur = System.Windows.Forms.Cursor.Current;
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;   // 砂時計カーソル
                System.Threading.Thread.Sleep(500);
                System.Windows.Forms.Cursor.Current = cur;  // カーソルを戻す

                // efuse の無いデバイスもあるのでエラーは無視する
                if (ExecCommand("-U efuse:r:" + efuse + ":h", 50, true) == 0)
                {
                        if (File.Exists(temp + efuse))
                        {
                            sr = new StreamReader(temp + efuse);
                            data = sr.ReadLine();
                            if (data.Length == 3)
                            {
                                EFuseTextBox.Text = "0" + data.Substring(2, 1).ToUpper();
                            }
                            else if (data.Length == 4)
                            {
                                EFuseTextBox.Text = data.Substring(2, 2).ToUpper();
                            }
                            sr.Close();
                        }
                }
            }
            File.Delete(temp + hfuse);
            File.Delete(temp + lfuse);
            File.Delete(temp + efuse);
        }

        /// <summary>
        /// ヒューズ書き込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteFuseButton_Click(object sender, EventArgs e) {

            Regex reg = new Regex("^[0-9A-Fa-f]{2}$");

            if ((HFuseTextBox.Text.Length > 0) && (reg.Match(HFuseTextBox.Text).Success == false)) {
                MessageBox.Show("Please Set hfuse by the hexadecimal number of 2 charactors. ",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HFuseTextBox.Focus();
                return;
            }
            if ((LFuseTextBox.Text.Length > 0) && (reg.Match(LFuseTextBox.Text).Success == false)) {
                MessageBox.Show("Please Set lfuse by the hexadecimal number of 2 charactors. ",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LFuseTextBox.Focus();
                return;
            }
            if ((EFuseTextBox.Text.Length > 0) && (reg.Match(EFuseTextBox.Text).Success == false)) {
                MessageBox.Show("Please Set efuse by the hexadecimal number of 2 charactors. ",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EFuseTextBox.Focus();
                return;
            }
            if ((HFuseTextBox.Text.Length == 0) && (LFuseTextBox.Text.Length == 0) && (EFuseTextBox.Text.Length == 0)) {
                MessageBox.Show("Please Set hfuse, lfuse or efuse.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Fuses is ReWritten. Is it good ?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                != DialogResult.Yes) return;

            int max = 50;
            string arg = "";
            if (HFuseTextBox.Text.Length > 0) {
                arg += "-U hfuse:w:0x" + HFuseTextBox.Text + ":m";
                max += 50;
            }
            if (LFuseTextBox.Text.Length > 0) {
                arg += " -U lfuse:w:0x" + LFuseTextBox.Text + ":m";
                max += 50;
            }
            if (EFuseTextBox.Text.Length > 0) {
                arg += " -U efuse:w:0x" + EFuseTextBox.Text + ":m";
                max += 50;
            }
            ExecCommand(arg, max, false);
        }

        /// <summary>
        /// ロックビット読み込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadLockBitButton_Click(object sender, EventArgs e) {
            string fname;
            StreamReader sr;
            string data;
            string temp;

            LockBitTextBox.Text = "";

            temp = Environment.GetEnvironmentVariable("temp") + "\\";

            fname = "_lockbit_.txt";
            File.Delete(temp + fname);

            ExecCommand("-U lock:r:" + fname + ":h", 100, false);

            if (File.Exists(temp + fname)) {
                sr = new StreamReader(temp + fname);
                data = sr.ReadLine();
                if (data.Length == 3)
                {
                    LockBitTextBox.Text = "0"+ data.Substring(2, 1).ToUpper();
                }
                else if (data.Length == 4)
                {
                    LockBitTextBox.Text = data.Substring(2, 2).ToUpper();
                }
                sr.Close();
                File.Delete(temp + fname);
            }
        }

        /// <summary>
        /// ロックビット書き込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteLockBitButton_Click(object sender, EventArgs e) {

            Regex reg = new Regex("^[0-9A-Fa-f]{2}$");

            if (LockBitTextBox.Text.Length == 0) {
                MessageBox.Show("Please Set Lock bit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (reg.Match(LockBitTextBox.Text).Success == false) {
                MessageBox.Show("Please Set Lock bit by the hexadecimal number of 2 charactors. ",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LockBitTextBox.Focus();
                return;
            }

            if (MessageBox.Show("Lock bit is ReWritten. Is it good ?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                != DialogResult.Yes) return;

            ExecCommand("-U lock:w:0x" + LockBitTextBox.Text + ":m", 150, false);
        }

        /// <summary>
        /// Flash ファイル選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlashFileButton_Click(object sender, EventArgs e) {

            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.AddExtension = true;
            OpenFileDialog.DefaultExt = "hex";
            OpenFileDialog.Filter = "Intel Hex File(*.hex)|*.hex|All File(*.*)|*.*";
            OpenFileDialog.FileName = "";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName.Length > 0) {
                FlashFileTextBox.Text = OpenFileDialog.FileName;
            }
        }

        /// <summary>
        /// Flash 読み込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadFlashButton_Click(object sender, EventArgs e) {

            SaveFileDialog.AddExtension = true;
            SaveFileDialog.DefaultExt = "hex";
            SaveFileDialog.FileName = "";
            SaveFileDialog.Filter = "Hex File (*.hex)|*.hex|All File (*.*)|*.*";
            SaveFileDialog.OverwritePrompt = true;
            SaveFileDialog.Title = "Save Flash data";
            SaveFileDialog.ValidateNames = true;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
                this.Refresh();
                ExecCommand("-U flash:r:\"" + SaveFileDialog.FileName + "\":i", 100, false);
            }
        }

        /// <summary>
        /// Flash 書き込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteFlashButton_Click(object sender, EventArgs e) {

            if (FlashFileTextBox.Text.Length == 0) {
                MessageBox.Show("Select Flash file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }
            if (!File.Exists(FlashFileTextBox.Text)) {
                MessageBox.Show("File not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }

            ExecCommand("-D -U flash:w:\"" + FlashFileTextBox.Text + "\":a", 150, false);
        }

        /// <summary>
        /// Flash Verifyボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifyFlashButton_Click(object sender, EventArgs e) {

            if (FlashFileTextBox.Text.Length == 0) {
                MessageBox.Show("Select Flash file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }
            if (!File.Exists(FlashFileTextBox.Text)) {
                MessageBox.Show("File not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }

            ExecCommand("-U flash:v:\"" + FlashFileTextBox.Text + "\":a", 100, false);
        }

        /// <summary>
        /// Flash Erase - Write - Verify ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramFlashButton_Click(object sender, EventArgs e) {

            if (FlashFileTextBox.Text.Length == 0) {
                MessageBox.Show("Select Flash file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }
            if (!File.Exists(FlashFileTextBox.Text)) {
                MessageBox.Show("File not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FlashFileButton.Focus();
                return;
            }

            ExecCommand("-e -U flash:w:\"" + FlashFileTextBox.Text + "\":a", 150, false);
        }

        /// <summary>
        /// EEPROM ファイル選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EEPROMFileButton_Click(object sender, EventArgs e) {

            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.AddExtension = true;
            OpenFileDialog.DefaultExt = "eep";
            OpenFileDialog.Filter = "EEPROM File(*.eep)|*.eep|All File(*.*)|*.*";
            OpenFileDialog.FileName = "";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName.Length > 0) {
                EEPROMFileTextBox.Text = OpenFileDialog.FileName;
            }
        }

        /// <summary>
        /// EEPROM 読み込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadEEPROMButton_Click(object sender, EventArgs e) {

            SaveFileDialog.AddExtension = true;
            SaveFileDialog.DefaultExt = "eep";
            SaveFileDialog.FileName = "";
            SaveFileDialog.Filter = "EEPROM File (*.eep)|*.eep|All File (*.*)|*.*";
            SaveFileDialog.OverwritePrompt = true;
            SaveFileDialog.Title = "Save EEPROM data";
            SaveFileDialog.ValidateNames = true;
            if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
                this.Refresh();
                ExecCommand("-U eeprom:r:\"" + SaveFileDialog.FileName + "\":i", 100, false);
            }
        }

        /// <summary>
        /// EEPROM 書き込みボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteEEPROMButton_Click(object sender, EventArgs e) {

            if (EEPROMFileTextBox.Text.Length == 0) {
                MessageBox.Show("Select EEPROM file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EEPROMFileButton.Focus();
                return;
            }
            if (!File.Exists(EEPROMFileTextBox.Text)) {
                MessageBox.Show("File not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EEPROMFileButton.Focus();
                return;
            }

            ExecCommand("-U eeprom:w:\"" + EEPROMFileTextBox.Text + "\":a", 150, false);
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// メインフォームコンストラクタ
        /// </summary>
        public MainForm() {
            InitializeComponent();

            string[] ports;
            ports = SerialPort.GetPortNames();  // 有効なシリアルポートを全て取得

            // ポート一覧してコンボボックスにセット
            PortComboBox.Items.Add("");     // 未選択
            PortComboBox.Items.Add("avrdoper"); // AVR-Doper
            foreach (string p in ports) {
                if (p.Length > 0) {
                    PortComboBox.Items.Add(p);
                }
            }
            PortComboBox.Items.Add("LPT1");
            PortComboBox.Items.Add("LPT2");
            PortComboBox.Items.Add("USB");
            PortComboBox.Items.Add("usb");      // 2009.1.4 追加
            // 他に特殊なポート指定が必要なプログラマがある場合は追加すること
            PortComboBox.Sorted = true;     //ソートする

            // ユーザ設定復元
            AvrdudeTextBox.Text = avrdudeGUI.Default.Avrdude;
            if (AvrdudeTextBox.Text.Length == 0) {
                if (File.Exists("avrdude.exe")) {
                    AvrdudeTextBox.Text = "avrdude.exe";
                }
            }
            if (AvrdudeTextBox.Text.Length > 0) {
                AvrdudeInfo();
            }
            WindowCheckBox.Checked = avrdudeGUI.Default.DisplayWindow;
            CommandLineOptionTextBox.Text = avrdudeGUI.Default.CommandLineOption;

            // タイトルバー文字列
            this.Text += Application.ProductVersion;
            this.Text = this.Text.Substring(0, this.Text.LastIndexOf('.')); // バージョン番号末尾削除
            this.Text += "]";
        }

        /// <summary>
        /// Form Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {

            // ユーザ設定保存
            avrdudeGUI.Default.Avrdude = AvrdudeTextBox.Text;
            if (ProgrammerComboBox.SelectedIndex >= 0) {
                avrdudeGUI.Default.Programmer = ProgrammerComboBox.SelectedItem.ToString();
            }
            if (PortComboBox.SelectedIndex >= 0) {
                avrdudeGUI.Default.Port = PortComboBox.SelectedItem.ToString();
            }
            if (DeviceComboBox.SelectedIndex >= 0) {
                avrdudeGUI.Default.Device = DeviceComboBox.SelectedItem.ToString();
            }
            avrdudeGUI.Default.DisplayWindow = WindowCheckBox.Checked;
            avrdudeGUI.Default.CommandLineOption = CommandLineOptionTextBox.Text;
            avrdudeGUI.Default.Save();
        }

        /// <summary>
        /// avrdude.exeのヘルプ出力からプログラマ・デバイス名取得
        /// 各コンボボックスの選択
        /// </summary>
        /// <returns></returns>
        private void AvrdudeInfo() {
            int i;
            string line;

            System.Diagnostics.Process prc = avrdude("-c ?");  // 引数 プログラマ一覧
            if (prc == null) return;

            ProgrammerComboBox.Items.Clear();
            while (!prc.StandardError.EndOfStream) {
                Regex reg;
                Match m;

                line = prc.StandardError.ReadLine();
                line = line.Replace('(', '<');          // () を <> に置換
                line = line.Replace(')', '>');
                reg = new Regex("(\\w+) += ([^\\[]+)");
                m = reg.Match(line);
                if (m.Success) {
                    ProgrammerComboBox.Items.Add(m.Groups[2].Value.Trim() + " (" + m.Groups[1] + ")");
                }
            }
            prc.WaitForExit();
            if (ProgrammerComboBox.Items.Count > 0) {
                ProgrammerComboBox.Items.Add("AVR-Doper (stk500v2)");   // AVR-Doperを追加
                ProgrammerComboBox.Sorted = true;   // ソートする
            }
            for (i = 0; i < ProgrammerComboBox.Items.Count; i++) {
                // 以前の設定と一致するものがあれば選択状態にする
                if (ProgrammerComboBox.Items[i].ToString().Equals(avrdudeGUI.Default.Programmer)) {
                    ProgrammerComboBox.SelectedIndex = i;
                    break;
                }
            }

            prc = avrdude("-p ?");  // 引数 デバイス一覧
            if (prc == null) return;

            DeviceComboBox.Items.Clear();
            while (!prc.StandardError.EndOfStream) {
                Regex reg;
                Match m;

                line = prc.StandardError.ReadLine();
                line = line.Replace("TINY", "tiny");    // どういうわけか TINYと tinyが混在しているので
                line = line.Replace("MEGA", "mega");    // 見やすいように
                reg = new Regex("(\\w+) += (\\w+)");
                m = reg.Match(line);
                if (m.Success) {
                    DeviceComboBox.Items.Add(m.Groups[2].Value + " (" + m.Groups[1].Value + ")");
                }
            }
            prc.WaitForExit();
            if (DeviceComboBox.Items.Count > 0) {
                DeviceComboBox.Sorted = true;   // ソートする
            }
            for (i = 0; i < DeviceComboBox.Items.Count; i++) {
                if (DeviceComboBox.Items[i].ToString().Equals(avrdudeGUI.Default.Device)) {
                    DeviceComboBox.SelectedIndex = i;
                    break;
                }
            }

            for (i = 0; i < PortComboBox.Items.Count; i++) {
                if (PortComboBox.Items[i].ToString().Equals(avrdudeGUI.Default.Port)) {
                    PortComboBox.SelectedIndex = i;
                    break;
                }
            }
        }


////////////////////////        /// <summary>/////////////////////////////////
        /// avrdude プログラマ・ポート・デバイス指定文字列取得
        /// </summary>
        /// <returns></returns>
        private string GetArg(){
            string prog = "";

            Regex reg = new Regex("\\((\\w+)\\)");  // () の中の文字列
            Match m = reg.Match(ProgrammerComboBox.SelectedItem.ToString());
            if (m.Success) {
                prog = m.Groups[1].Value;
            }

            string port = "";
            if (PortComboBox.SelectedIndex >= 0) {
                port = PortComboBox.SelectedItem.ToString();
            }

            string device = "";
            m = reg.Match(DeviceComboBox.SelectedItem.ToString());
            if (m.Success) {
                device = m.Groups[1].Value;
            }

            string arg = " -c " + prog;
            if (port.Length > 0) {
                arg += " -P " + port;
            }
            arg += " -p " + device;

            // ボーレート指定等、コマンドラインの追加パラメータ 
            if (CommandLineOptionTextBox.Text.Length > 0) {
                arg += " " + CommandLineOptionTextBox.Text + " ";
            }

            return arg;
        }

        /// <summary>
        /// avrdude.exe 実行開始
        /// </summary>
        /// <param name="arg">実行時の引数</param>
        /// <returns>Processオブジェクト</returns>
        private System.Diagnostics.Process avrdude(string arg) {

            if (AvrdudeTextBox.Text.Length == 0) return null;

            System.Diagnostics.Process prc;
            try {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.FileName = AvrdudeTextBox.Text;
                psi.RedirectStandardError = true;   // 標準エラー出力を取り込む
                psi.CreateNoWindow = true;          // ウインドウ表示しない
                psi.UseShellExecute = false;        // 必須
                psi.Arguments = arg;                // 引数
                prc = System.Diagnostics.Process.Start(psi);
            } catch {
                prc = null;
            }
            return prc;
        }

        /// <summary>
        /// avrdude コマンド実行
        /// </summary>
        /// <param name="arg">avrdudeの引数</param>
        /// <param name="maxProgress">avrdudeの出力文字列中の # の数(=プログレスバーの最大値)</param>
        /// <param name="ignoreError">== true : エラーが発生してもエラーダイアログを表示しない</param>
        /// <returns>avrdudeの戻り値</returns>
        private int ExecCommand(string arg, int maxProgress, bool ignoreError) {

            if (AvrdudeTextBox.Text.Length == 0) {
                MessageBox.Show("Select avrdude.exe File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AvrdudeButton.Focus();
                return 0;
            }
            if (ProgrammerComboBox.SelectedIndex < 0) {
                MessageBox.Show("Select Programmer", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProgrammerComboBox.Focus();
                return 0;
            }
            if (DeviceComboBox.SelectedIndex < 0) {
                MessageBox.Show("Select Device", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DeviceComboBox.Focus();
                return 0;
            }

            System.Windows.Forms.Cursor cur = System.Windows.Forms.Cursor.Current;

            try {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;   // 砂時計カーソル

                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.Arguments = "";
                if (WindowCheckBox.Checked == true)
                {
                    // cmd.exe窓動作モード。エラー発生時に困るので自動終了しない
                    psi.FileName = System.Environment.GetEnvironmentVariable("comspec");
                    psi.Arguments = " /K \"" + AvrdudeTextBox.Text + "\" ";
                } else {
                    // 通常モード
                    psi.FileName = AvrdudeTextBox.Text;
                }
                if (WindowCheckBox.Checked == false) {
                    // Window表示なし
                    psi.Arguments += GetArg() + " -u " + arg;   // 終了時のヒューズ設定確認を省略
                    psi.CreateNoWindow = true;          // Window表示しない
                    psi.RedirectStandardError = true;   // 標準エラー出力を取り込む
                    psi.UseShellExecute = false;        // 必須
                } else {
                    // Windows表示(DOS窓実行)あり
                    psi.Arguments += GetArg() + " " + arg;      // 終了時のヒューズ設定確認はあり
                }
                psi.WorkingDirectory = Environment.GetEnvironmentVariable("temp");  // テンポラリ
                
                // avrdude起動
                System.Diagnostics.Process prc = System.Diagnostics.Process.Start(psi);

                StringBuilder sb = new StringBuilder();
                if (WindowCheckBox.Checked == false) {
                    ProgressBar.Maximum = maxProgress;
                    ProgressBar.Value = 0;
                    while (!prc.StandardError.EndOfStream) {
                        int c;
                        c = prc.StandardError.Read();
                        // # が出力されたらプログレスバーを進める
                        if ((c == (int)'#') && (ProgressBar.Value < ProgressBar.Maximum)) {
                            ProgressBar.Value += 1;
                        }
                        sb.Append((char)c); // 出力メッセージをとっておく
                    }
                }
                prc.WaitForExit();  // 終了待ち

                System.Windows.Forms.Cursor.Current = cur;  // カーソルを戻す

                if ((WindowCheckBox.Checked == false) && (prc.ExitCode != 0) && (ignoreError == false)) {
                    // エラーが発生したので出力メッセージを表示する
                    System.Media.SystemSounds.Asterisk.Play();  // チャイム音？
                    Form md = new ErrorMessageForm();
                    md.Text = this.Text + " Error";
                    md.Controls["MessageTextBox"].Text = sb.ToString();
                    md.ShowDialog();
                    ProgressBar.Value = 0;
                    return 1;
                } else {
                    // 正常終了
                    /*
                    MessageBox.Show("avrdude.exe done. Thank you.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     */
                    ProgressBar.Value = 0;
                    return 0;
                }

            } catch {
                System.Windows.Forms.Cursor.Current = cur;  // カーソルを戻す
                ProgressBar.Value = 0;
                return 1;
            }
        }

        private void AvrdudeButton_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog.CheckFileExists = true;
            OpenFileDialog.Filter = "avrdude.exe|avrdude.exe";
            OpenFileDialog.FileName = "";
            OpenFileDialog.Title = "Select avrdude.exe File";
            OpenFileDialog.ShowDialog();
            if (OpenFileDialog.FileName.Length > 0)
            {
                AvrdudeTextBox.Text = OpenFileDialog.FileName;
                AvrdudeInfo();  // コンボボックス設定
            }
        }

        private byte[] HexStringToByteArray(string s)
        {
            int leng = s.Trim().Length;
            int leng2 = s.Trim().Length;
               s = s.Replace(" ", "");
               byte[] comBuffer = new byte[s.Length / 2];
               leng = leng % 2;
               leng2 = leng2 % 5;
              
               if (leng == 0)
               {
                   for (int i = 0; i < s.Length; i += 2)
                       comBuffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
               }
               else if (leng2 == 0)
               {
                   for (int i = 0; i < s.Length; i += 2)
                       comBuffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
               }
               else 
               {

                   MessageBox.Show("masukkan 2 baris bilangan contoh:ff");
               }

              return comBuffer;
            
            
            }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Disconnect");
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text =="")
            {
                serialPort1.Close();
                MessageBox.Show("COMPORT NGGAK ONO");
            }
            
            else
            {
                serialPort1.Close();
                serialPort1.PortName = comboBox1.Text;
                if (comboBox2.Text == "")
                {
                    serialPort1.Close();
                    MessageBox.Show("Baud rung di pilih");
                }
                else
                {
                    serialPort1.BaudRate = int.Parse(comboBox2.Text);
                    serialPort1.DataBits = 8;
                    serialPort1.Open();

                    button1.Text = ("connected");
                    button1.BackColor = System.Drawing.Color.LawnGreen;
                   // label1.ForeColor = System.Drawing.Color.LawnGreen;
                   // label1.Text = ("COMPORT CONNECT");
                    button2.BackColor = System.Drawing.Color.Empty;
                }


            }
            if (!serialPort1.IsOpen)
            {
                //label1.ForeColor = System.Drawing.Color.Red;
                //button1.BackColor = System.Drawing.Color.Red;
               // label1.Text = ("Comport belum di pilih");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button2.Text = ("Diskonected");
            button1.Text = ("CONNECT");
            //label1.ForeColor = System.Drawing.Color.Red;
            button1.BackColor = System.Drawing.Color.Empty;
            button2.BackColor = System.Drawing.Color.Red;
            //label1.Text = ("COMPORT DISKONECT");
        }

        private void comboBox1_DropDown_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Disconnect");
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("9600");
            comboBox2.Items.Add("19200");
            comboBox2.Items.Add("38400");
            comboBox2.Items.Add("57600");
            comboBox2.Items.Add("115200");
            comboBox2.Items.Add("128000");
            comboBox2.Items.Add("1000000");
        }

        private void Log(LogMsgType msgtype, string msg) // menampilkan tulisan di jendela terminal
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                richTextBox1.SelectedText = string.Empty;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
                //richTextBox1.SelectionColor = LogMsgTypeColor[(int)msgtype];
                richTextBox1.AppendText(msg);
                richTextBox1.ScrollToCaret();
            }));
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] gambar = new byte[71477];
            if (x == true)
            {
                string data = serialPort1.ReadExisting();

                // Display the text to the user in the terminal
                Log(LogMsgType.Incoming, data);
            }
            else
            {

                bytes = serialPort1.BytesToRead;
                buffer = new byte[bytes];
                // Read the data from the port and store it in our buffer
                serialPort1.Read(buffer, 0, bytes);

                Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));
                //label1.Text = bytes.ToString();
                //DisplayPicture(gambar);

                // Show the user the incoming data in hex format


            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            x = false;
           
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            x = true;
         
        }

        private void SendData()//  fungsi mengirim data dalam bentuk tulisan form kirim data 
        {
            if (x == true)
            {
                // Send the user's text straight out the port
                serialPort1.Write(textBox1.Text);
                // Show in the terminal window the user's text
                Log(LogMsgType.Outgoing, textBox1.Text);
                textBox1.SelectAll();
            }
            else
            {
                
                bytes = serialPort1.BytesToWrite;
                byte[] ngehe = HexStringToByteArray(textBox1.Text);
                
                 // Read the data from the port and store it in our buffer
                serialPort1.Write(ngehe, 0,ngehe.Length);
                Log(LogMsgType.Incoming, ByteArrayToHexString(ngehe));
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("COMPORT RUNG KONECT");
            }
            else if (serialPort1.IsOpen)
            {
                SendData();
            }
        }
         byte[] header = new byte[] { 0x42, 0x4D, 0x76, 0xA0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x04, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0xC8, 0x00, 0x00, 0x00, 0xC8, 0x00, 0x00, 0x00, 0x01, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x01, 0x00, 0x02, 0x02, 0x02, 0x00, 0x03, 0x03, 0x03, 0x00, 0x04, 0x04, 0x04, 0x00, 0x05, 0x05, 0x05, 0x00, 0x06, 0x06, 0x06, 0x00, 0x07, 0x07, 0x07, 0x00, 0x08, 0x08, 0x08, 0x00, 0x09, 0x09, 0x09, 0x00, 0x0A, 0x0A, 0x0A, 0x00, 0x0B, 0x0B, 0x0B, 0x00, 0x0C, 0x0C, 0x0C, 0x00, 0x0D, 0x0D, 0x0D, 0x00, 0x0E, 0x0E, 0x0E, 0x00, 0x0F, 0x0F, 0x0F, 0x00, 0x10, 0x10, 0x10, 0x00, 0x11, 0x11, 0x11, 0x00, 0x12, 0x12, 0x12, 0x00, 0x13, 0x13, 0x13, 0x00, 0x14, 0x14, 0x14, 0x00, 0x15, 0x15, 0x15, 0x00, 0x16, 0x16, 0x16, 0x00, 0x17, 0x17, 0x17, 0x00, 0x18, 0x18, 0x18, 0x00, 0x19, 0x19, 0x19, 0x00, 0x1A, 0x1A, 0x1A, 0x00, 0x1B, 0x1B, 0x1B, 0x00, 0x1C, 0x1C, 0x1C, 0x00, 0x1D, 0x1D, 0x1D, 0x00, 0x1E, 0x1E, 0x1E, 0x00, 0x1F, 0x1F, 0x1F, 0x00, 0x20, 0x20, 0x20, 0x00, 0x21, 0x21, 0x21, 0x00, 0x22, 0x22, 0x22, 0x00, 0x23, 0x23, 0x23, 0x00, 0x24, 0x24, 0x24, 0x00, 0x25, 0x25, 0x25, 0x00, 0x26, 0x26, 0x26, 0x00, 0x27, 0x27, 0x27, 0x00, 0x28, 0x28, 0x28, 0x00, 0x29, 0x29, 0x29, 0x00, 0x2A, 0x2A, 0x2A, 0x00, 0x2B, 0x2B, 0x2B, 0x00, 0x2C, 0x2C, 0x2C, 0x00, 0x2D, 0x2D, 0x2D, 0x00, 0x2E, 0x2E, 0x2E, 0x00, 0x2F, 0x2F, 0x2F, 0x00, 0x30, 0x30, 0x30, 0x00, 0x31, 0x31, 0x31, 0x00, 0x32, 0x32, 0x32, 0x00, 0x33, 0x33, 0x33, 0x00, 0x34, 0x34, 0x34, 0x00, 0x35, 0x35, 0x35, 0x00, 0x36, 0x36, 0x36, 0x00, 0x37, 0x37, 0x37, 0x00, 0x38, 0x38, 0x38, 0x00, 0x39, 0x39, 0x39, 0x00, 0x3A, 0x3A, 0x3A, 0x00, 0x3B, 0x3B, 0x3B, 0x00, 0x3C, 0x3C, 0x3C, 0x00, 0x3D, 0x3D, 0x3D, 0x00, 0x3E, 0x3E, 0x3E, 0x00, 0x3F, 0x3F, 0x3F, 0x00, 0x40, 0x40, 0x40, 0x00, 0x41, 0x41, 0x41, 0x00, 0x42, 0x42, 0x42, 0x00, 0x43, 0x43, 0x43, 0x00, 0x44, 0x44, 0x44, 0x00, 0x45, 0x45, 0x45, 0x00, 0x46, 0x46, 0x46, 0x00, 0x47, 0x47, 0x47, 0x00, 0x48, 0x48, 0x48, 0x00, 0x49, 0x49, 0x49, 0x00, 0x4A, 0x4A, 0x4A, 0x00, 0x4B, 0x4B, 0x4B, 0x00, 0x4C, 0x4C, 0x4C, 0x00, 0x4D, 0x4D, 0x4D, 0x00, 0x4E, 0x4E, 0x4E, 0x00, 0x4F, 0x4F, 0x4F, 0x00, 0x50, 0x50, 0x50, 0x00, 0x51, 0x51, 0x51, 0x00, 0x52, 0x52, 0x52, 0x00, 0x53, 0x53, 0x53, 0x00, 0x54, 0x54, 0x54, 0x00, 0x55, 0x55, 0x55, 0x00, 0x56, 0x56, 0x56, 0x00, 0x57, 0x57, 0x57, 0x00, 0x58, 0x58, 0x58, 0x00, 0x59, 0x59, 0x59, 0x00, 0x5A, 0x5A, 0x5A, 0x00, 0x5B, 0x5B, 0x5B, 0x00, 0x5C, 0x5C, 0x5C, 0x00, 0x5D, 0x5D, 0x5D, 0x00, 0x5E, 0x5E, 0x5E, 0x00, 0x5F, 0x5F, 0x5F, 0x00, 0x60, 0x60, 0x60, 0x00, 0x61, 0x61, 0x61, 0x00, 0x62, 0x62, 0x62, 0x00, 0x63, 0x63, 0x63, 0x00, 0x64, 0x64, 0x64, 0x00, 0x65, 0x65, 0x65, 0x00, 0x66, 0x66, 0x66, 0x00, 0x67, 0x67, 0x67, 0x00, 0x68, 0x68, 0x68, 0x00, 0x69, 0x69, 0x69, 0x00, 0x6A, 0x6A, 0x6A, 0x00, 0x6B, 0x6B, 0x6B, 0x00, 0x6C, 0x6C, 0x6C, 0x00, 0x6D, 0x6D, 0x6D, 0x00, 0x6E, 0x6E, 0x6E, 0x00, 0x6F, 0x6F, 0x6F, 0x00, 0x70, 0x70, 0x70, 0x00, 0x71, 0x71, 0x71, 0x00, 0x72, 0x72, 0x72, 0x00, 0x73, 0x73, 0x73, 0x00, 0x74, 0x74, 0x74, 0x00, 0x75, 0x75, 0x75, 0x00, 0x76, 0x76, 0x76, 0x00, 0x77, 0x77, 0x77, 0x00, 0x78, 0x78, 0x78, 0x00, 0x79, 0x79, 0x79, 0x00, 0x7A, 0x7A, 0x7A, 0x00, 0x7B, 0x7B, 0x7B, 0x00, 0x7C, 0x7C, 0x7C, 0x00, 0x7D, 0x7D, 0x7D, 0x00, 0x7E, 0x7E, 0x7E, 0x00, 0x7F, 0x7F, 0x7F, 0x00, 0x80, 0x80, 0x80, 0x00, 0x81, 0x81, 0x81, 0x00, 0x82, 0x82, 0x82, 0x00, 0x83, 0x83, 0x83, 0x00, 0x84, 0x84, 0x84, 0x00, 0x85, 0x85, 0x85, 0x00, 0x86, 0x86, 0x86, 0x00, 0x87, 0x87, 0x87, 0x00, 0x88, 0x88, 0x88, 0x00, 0x89, 0x89, 0x89, 0x00, 0x8A, 0x8A, 0x8A, 0x00, 0x8B, 0x8B, 0x8B, 0x00, 0x8C, 0x8C, 0x8C, 0x00, 0x8D, 0x8D, 0x8D, 0x00, 0x8E, 0x8E, 0x8E, 0x00, 0x8F, 0x8F, 0x8F, 0x00, 0x90, 0x90, 0x90, 0x00, 0x91, 0x91, 0x91, 0x00, 0x92, 0x92, 0x92, 0x00, 0x93, 0x93, 0x93, 0x00, 0x94, 0x94, 0x94, 0x00, 0x95, 0x95, 0x95, 0x00, 0x96, 0x96, 0x96, 0x00, 0x97, 0x97, 0x97, 0x00, 0x98, 0x98, 0x98, 0x00, 0x99, 0x99, 0x99, 0x00, 0x9A, 0x9A, 0x9A, 0x00, 0x9B, 0x9B, 0x9B, 0x00, 0x9C, 0x9C, 0x9C, 0x00, 0x9D, 0x9D, 0x9D, 0x00, 0x9E, 0x9E, 0x9E, 0x00, 0x9F, 0x9F, 0x9F, 0x00, 0xA0, 0xA0, 0xA0, 0x00, 0xA1, 0xA1, 0xA1, 0x00, 0xA2, 0xA2, 0xA2, 0x00, 0xA3, 0xA3, 0xA3, 0x00, 0xA4, 0xA4, 0xA4, 0x00, 0xA5, 0xA5, 0xA5, 0x00, 0xA6, 0xA6, 0xA6, 0x00, 0xA7, 0xA7, 0xA7, 0x00, 0xA8, 0xA8, 0xA8, 0x00, 0xA9, 0xA9, 0xA9, 0x00, 0xAA, 0xAA, 0xAA, 0x00, 0xAB, 0xAB, 0xAB, 0x00, 0xAC, 0xAC, 0xAC, 0x00, 0xAD, 0xAD, 0xAD, 0x00, 0xAE, 0xAE, 0xAE, 0x00, 0xAF, 0xAF, 0xAF, 0x00, 0xB0, 0xB0, 0xB0, 0x00, 0xB1, 0xB1, 0xB1, 0x00, 0xB2, 0xB2, 0xB2, 0x00, 0xB3, 0xB3, 0xB3, 0x00, 0xB4, 0xB4, 0xB4, 0x00, 0xB5, 0xB5, 0xB5, 0x00, 0xB6, 0xB6, 0xB6, 0x00, 0xB7, 0xB7, 0xB7, 0x00, 0xB8, 0xB8, 0xB8, 0x00, 0xB9, 0xB9, 0xB9, 0x00, 0xBA, 0xBA, 0xBA, 0x00, 0xBB, 0xBB, 0xBB, 0x00, 0xBC, 0xBC, 0xBC, 0x00, 0xBD, 0xBD, 0xBD, 0x00, 0xBE, 0xBE, 0xBE, 0x00, 0xBF, 0xBF, 0xBF, 0x00, 0xC0, 0xC0, 0xC0, 0x00, 0xC1, 0xC1, 0xC1, 0x00, 0xC2, 0xC2, 0xC2, 0x00, 0xC3, 0xC3, 0xC3, 0x00, 0xC4, 0xC4, 0xC4, 0x00, 0xC5, 0xC5, 0xC5, 0x00, 0xC6, 0xC6, 0xC6, 0x00, 0xC7, 0xC7, 0xC7, 0x00, 0xC8, 0xC8, 0xC8, 0x00, 0xC9, 0xC9, 0xC9, 0x00, 0xCA, 0xCA, 0xCA, 0x00, 0xCB, 0xCB, 0xCB, 0x00, 0xCC, 0xCC, 0xCC, 0x00, 0xCD, 0xCD, 0xCD, 0x00, 0xCE, 0xCE, 0xCE, 0x00, 0xCF, 0xCF, 0xCF, 0x00, 0xD0, 0xD0, 0xD0, 0x00, 0xD1, 0xD1, 0xD1, 0x00, 0xD2, 0xD2, 0xD2, 0x00, 0xD3, 0xD3, 0xD3, 0x00, 0xD4, 0xD4, 0xD4, 0x00, 0xD5, 0xD5, 0xD5, 0x00, 0xD6, 0xD6, 0xD6, 0x00, 0xD7, 0xD7, 0xD7, 0x00, 0xD8, 0xD8, 0xD8, 0x00, 0xD9, 0xD9, 0xD9, 0x00, 0xDA, 0xDA, 0xDA, 0x00, 0xDB, 0xDB, 0xDB, 0x00, 0xDC, 0xDC, 0xDC, 0x00, 0xDD, 0xDD, 0xDD, 0x00, 0xDE, 0xDE, 0xDE, 0x00, 0xDF, 0xDF, 0xDF, 0x00, 0xE0, 0xE0, 0xE0, 0x00, 0xE1, 0xE1, 0xE1, 0x00, 0xE2, 0xE2, 0xE2, 0x00, 0xE3, 0xE3, 0xE3, 0x00, 0xE4, 0xE4, 0xE4, 0x00, 0xE5, 0xE5, 0xE5, 0x00, 0xE6, 0xE6, 0xE6, 0x00, 0xE7, 0xE7, 0xE7, 0x00, 0xE8, 0xE8, 0xE8, 0x00, 0xE9, 0xE9, 0xE9, 0x00, 0xEA, 0xEA, 0xEA, 0x00, 0xEB, 0xEB, 0xEB, 0x00, 0xEC, 0xEC, 0xEC, 0x00, 0xED, 0xED, 0xED, 0x00, 0xEE, 0xEE, 0xEE, 0x00, 0xEF, 0xEF, 0xEF, 0x00, 0xF0, 0xF0, 0xF0, 0x00, 0xF1, 0xF1, 0xF1, 0x00, 0xF2, 0xF2, 0xF2, 0x00, 0xF3, 0xF3, 0xF3, 0x00, 0xF4, 0xF4, 0xF4, 0x00, 0xF5, 0xF5, 0xF5, 0x00, 0xF6, 0xF6, 0xF6, 0x00, 0xF7, 0xF7, 0xF7, 0x00, 0xF8, 0xF8, 0xF8, 0x00, 0xF9, 0xF9, 0xF9, 0x00, 0xFA, 0xFA, 0xFA, 0x00, 0xFB, 0xFB, 0xFB, 0x00, 0xFC, 0xFC, 0xFC, 0x00, 0xFD, 0xFD, 0xFD, 0x00, 0xFE, 0xFE, 0xFE, 0x00, 0xFF, 0xFF, 0xFF, 0x00, };
      int a;
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
           richTextBox2.Text = ByteArrayToHexString(header);
           
            richTextBox1.Clear();
            if (serialPort1.IsOpen)
            {
                timer1.Start();
                serialPort1.WriteLine("c"); // kirim coomand Test BMP dengan carier and return
            }
            else
            {
                MessageBox.Show("COMPORT RUNG KONECT");
            }
            label13.Text = "0";


        }
         private void DisplayPicture(byte[] PictureData) // fungsi menampilkan gambar di picture box
        {

            MemoryStream memstr = new MemoryStream(PictureData);
            memstr.Seek(0, SeekOrigin.Begin);
            
            pictureBox1.Image = new Bitmap(memstr);
           



        }
         
        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;
            int bytes = serialPort1.BytesToRead;
            byte[] buffer = new byte[bytes];
            serialPort1.Read(buffer, 0, bytes);
            Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));
            int lengOftheString = richTextBox1.Text.Trim().Length;
            label10.Text = "TUNGGU SEBENTAR DATA SEDANG DI TERIMA";
            label12.Text = "LOADING TIME=  " + lengOftheString.ToString();
           
            if (lengOftheString >= 119999)
            {
               
                label10.Text = "DATA SELESAI";
                timer1.Stop();
                lengOftheString = 0;
                byte[] gambar = new byte[71477];
                gambar = HexStringToByteArray(richTextBox2.Text + richTextBox1.Text);
                DisplayPicture(gambar);
                label13.Text ="1" ;
            }
            }
        int d;
        private void button5_Click(object sender, EventArgs e)
        {
             d++;
            string filename = "C:\\Datagambar" + "\\GambarCapture" + d + ".bmp";// simpan gambar generated +1
            if (label13.Text=="1")
            {
                pictureBox1.Image.Save(filename);
            }
            else
            {
                MessageBox.Show("Ora Ono Gambar kog meh di save");
            }
   
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            x = true;
            label13.Text = "0";
        }

      
      
        

       

       
    }
}