using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;

namespace chatWithOther {
    public partial class chatRoom : Form {
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
        public chatRoom() => InitializeComponent();

        private void chatRoom_Load(object sender, EventArgs e) {
        }

        private void chatRoom_FormClosed(object sender, FormClosedEventArgs e) {
            System.Environment.Exit(0);
        }

        private void inputText_KeyUp(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter) {
                sendButton_Click(sender, e);
            }
        }

        private void chatRoom_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                System.Environment.Exit(0);
            }
        }

        private void sendButton_Click(object sender, EventArgs e) {
            String text = inputText.Text;
            inputText.Clear();
            String name = getCurrentName();
            String date = DateTime.Now.ToString();
            chatText.AppendText(name + " " + date + "\r\n");
            chatText.AppendText(text + "\r\n");
        }

        private String getCurrentName() {
            String name = Dns.GetHostName();
            return name;
        }

        private List<String> getCurrentPersonNum() {
            return null;
        }

        private void changeTime_Tick(object sender, EventArgs e) {
            currentTime.Text = DateTime.Now.ToString();
        }

        private void chatTextChange_Tick(object sender, EventArgs e) {

        }
    }
}
