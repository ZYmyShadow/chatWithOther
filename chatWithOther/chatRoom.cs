using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;

namespace chatWithOther {
    public partial class ChatRoom : Form {
        /**
         * 
         * 当前电脑名：static System.Environment.MachineName
         * 当前电脑所属网域：static System.Environment.UserDomainName
         * 当前电脑用户：static System.Environment.UserName
         * 获取当前电脑名：static System.Net.Dns.GetHostName()
         * 根据电脑名取出全部IP地址：static System.Net.Dns.Resolve(电脑名).AddressList
         * 也可根据IP地址取出电脑名：static System.Net.Dns.Resolve(IP地址).HostName
         * 获取客户端电脑IP：Page.Request.UserHostAddress
         * 获取客户端电脑名：Page.Request.UserHostName
         * 获取用户信息：Page.User
         * 获取服务器电脑名：Page.Server.ManchineName 
         * 
         */
        private string UserName = "";

        public ChatRoom(string UserName) {
            InitializeComponent();
            if (!UserName.Equals("")) {
                this.UserName = UserName;
            }
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e) {
            System.Environment.Exit(0);
        }

        private void inputText_KeyUp(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter) {
                SendButton_Click(sender, e);
            }
        }

        private void ChatRoom_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Escape) {
                System.Environment.Exit(0);
            }
        }

        private void SendButton_Click(object sender, EventArgs e) {
            string text = inputText.Text;
            inputText.Clear();
            string name = getCurrentName();
            string date = DateTime.Now.ToString();
            chatText.AppendText(name + " " + date + "\r\n");
            chatText.AppendText(text + "\r\n");
        }

        private string getCurrentName() {
            if (UserName.Equals("")) {
                UserName = Dns.GetHostName();
            }
            return UserName;
        }

        private List<string> getCurrentPersonNum() {
            return null;
        }

        private void changeTime_Tick(object sender, EventArgs e) {
            currentTime.Text = DateTime.Now.ToString();
        }

        private void chatTextChange_Tick(object sender, EventArgs e) {
        }
    }
}
