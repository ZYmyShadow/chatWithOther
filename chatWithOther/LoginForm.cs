using System;
using System.Windows.Forms;

namespace chatWithOther {
    public partial class LoginForm : Form {
        public LoginForm() => InitializeComponent();

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e) {
            System.Environment.Exit(0);
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            string UserName = UserNameText.Text;
            string PassWord = PassWordText.Text;
            //安全过滤
            if(UserName.Contains("\"") || UserName.Contains("1=1")) {
                MessageBox.Show("用户名中包含不合法词或字符串");
                return;
            }
            //验证账号密码是否正确

            //新建窗体，登陆成功
            if(UserName == PassWord) {
                Form ChatRoomForm = new ChatRoom(UserName);
                ChatRoomForm.Show();
                this.Hide();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            System.Environment.Exit(0);
        }
    }
}
