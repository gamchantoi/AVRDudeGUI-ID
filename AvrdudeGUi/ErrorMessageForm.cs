using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace avrdudeGUI {
    public partial class ErrorMessageForm : Form {
        public ErrorMessageForm() {
            InitializeComponent();
        }

        private void ErrorMessageForm_Load(object sender, EventArgs e) {
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ErrorMessageForm_Activated(object sender, EventArgs e) {
            CloseButton.Focus();
        }
    }
}