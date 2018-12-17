using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

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
        private string IPText = "127.0.0.1";
        private int serverport = 51028;
        private TcpClient clientsocket;
        private NetworkStream ns;
        private StreamReader sr;
        private Thread recThread = null;
        private bool connected = false;

        public ChatRoom(string UserName) {
            InitializeComponent();
            if (!UserName.Equals("")) {
                this.UserName = UserName;
            }

            CreateConnection();
            if (connected) {
                StoreforServer();
                recThread = new Thread(new ThreadStart(ReceiveChat));
                recThread.Start();
                chatText.Text = "";
            }
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e) {
            QuitChat();
            System.Environment.Exit(0);
        }

        private void inputText_KeyUp(object sender, KeyEventArgs e) {
            if (/*e.Modifiers == Keys.Control && */e.KeyCode == Keys.Enter) {
                SendButton_Click(sender, e);
            }
        }

        private void ChatRoom_KeyUp(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Escape) {
                QuitChat();
                System.Environment.Exit(0);
            }
        }

        private void SendButton_Click(object sender, EventArgs e) {
            /*string text = inputText.Text;
            inputText.Clear();
            string name = getCurrentName();
            string date = DateTime.Now.ToString();
            chatText.AppendText(name + " " + date + "\r\n");
            chatText.AppendText(text + "\r\n");*/
            try {
                string pubcommand = "CHAT|" + getCurrentName() + "| " + inputText.Text + "\r\n";
                Byte[] outbytes = System.Text.Encoding.Default.GetBytes(pubcommand);
                ns.Write(outbytes, 0, outbytes.Length);
                inputText.Text = "";
            } catch (Exception) {
                MessageBox.Show("Lost Connect", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ns.Close();
                clientsocket.Close();
                if (recThread != null && recThread.IsAlive)
                    recThread.Abort();
                connected = false;
            }
        }

        private string getCurrentName() {
            if (UserName.Equals("")) {
                UserName = Dns.GetHostName();
            }
            return UserName;
        }

        private void changeTime_Tick(object sender, EventArgs e) {
            currentTime.Text = DateTime.Now.ToString();
        }

        private void CreateConnection() {
            try {
                clientsocket = new TcpClient(IPText, serverport);
                ns = clientsocket.GetStream();
                sr = new StreamReader(ns);
                connected = true;
            } catch (Exception) {
                MessageBox.Show("Can't connect the service", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void StoreforServer() {
            try {
                string command = "CONNECT|" + getCurrentName();
                Byte[] outbytes = System.Text.Encoding.Default.GetBytes(command);
                ns.Write(outbytes, 0, outbytes.Length);
                string serverresponse = sr.ReadLine();
                serverresponse.Trim();
                string[] tokens = serverresponse.Split(new Char[] { '|' });
                for (int n = 1; n < tokens.Length - 1; n++)
                    currentPersonList.Items.Add(tokens[n].Trim(new char[] { '\r', '\n' }));
            } catch (Exception) {
                MessageBox.Show("Can't Connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ReceiveChat() {
            bool alive = true;
            while (alive) {
                try {
                    Byte[] buffer = new Byte[2048000];
                    ns.Read(buffer, 0, buffer.Length);
                    string time = System.DateTime.Now.ToLongTimeString();
                    string chatter = System.Text.Encoding.Default.GetString(buffer);

                    string[] tokens = chatter.Split(new Char[] { '|' });

                    if (tokens[0] == "CHAT") {
                        chatText.AppendText(tokens[1].Trim());
                        chatText.AppendText("  " + time + " \r\n");
                        chatText.AppendText(tokens[2].Trim());
                    }
                    if (tokens[0] == "JOIN") {
                        chatText.AppendText(time + "  ");
                        chatText.AppendText(tokens[1].Trim());
                        chatText.AppendText("加入聊天室" + "\r\n");
                        string newcomer = tokens[1].Trim(new char[] { '\r', '\n' });
                        currentPersonList.Items.Add(newcomer);
                    }
                    if (tokens[0] == "LEAVE") {
                        chatText.AppendText(time + "  ");
                        chatText.AppendText(tokens[1].Trim());
                        chatText.AppendText("退出了聊天室" + "\r\n");
                        string leaver = tokens[1].Trim(new char[] { '\r', '\n' });
                        for (int n = 0; n < currentPersonList.Items.Count; n++) {
                            if (currentPersonList.Items[n].ToString().CompareTo(leaver) == 0) {
                                currentPersonList.Items.RemoveAt(n);
                            }
                        }
                    }
                    if (tokens[0] == "QUIT") {
                        ns.Close();
                        clientsocket.Close();
                        alive = false;
                        connected = false;
                        MessageBox.Show("服务器断开!");
                    }
                } catch (Exception) { }
            }
        }

        private void QuitChat() {
            if (connected) {
                try {
                    string command = "LEAVE|" + getCurrentName();
                    Byte[] outbytes = System.Text.Encoding.Default.GetBytes(command);
                    ns.Write(outbytes, 0, outbytes.Length);
                    clientsocket.Close();
                } catch (Exception) {
                }
            }

            if (recThread != null && recThread.IsAlive)
                recThread.Abort();
        }
    }
}
