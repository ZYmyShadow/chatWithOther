using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chatWithOther {
    public partial class LoginForm : Form {
        public LoginForm() => InitializeComponent();

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e) {
            System.Environment.Exit(0);
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            String UserName = UserNameText.Text;
            String PassWord = PassWordText.Text;
            //安全过滤

            //验证账号密码是否正确

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            System.Environment.Exit(0);
        }
    }
}
