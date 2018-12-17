using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace chatRoomService {
    public partial class ChatRoomService : Form {
        public int listenport = 51028; //服务器端监听端口   
        private TcpListener listener;    //服务器监听器  
        private ArrayList clients;     // 已连接客户端数组  
        private Thread processor;    //主线程  
        private Socket clientsocket;   //客户端套接字  
        private Thread clientservice;     //客户端线程  

        public ChatRoomService() {
            InitializeComponent();
            PortNum.Text = "51028";
        }

        private void StartListening() {

            listener = new TcpListener(listenport);
            listener.Start();
            while (true) {
                try {
                    Socket s = listener.AcceptSocket();
                    clientsocket = s;
                    clientservice = new Thread(new ThreadStart(ServiceClient));
                    clientservice.Start();  //开始监听  
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
            //listener.Stop();  
        }


        private void ServiceClient() {
            Socket client = clientsocket;
            bool alive = true;

            while (alive) {
                Byte[] buffer = new Byte[2048000];
                client.Receive(buffer);
                //     string time = System.DateTime.Now.ToString();  
                string clientcommand = System.Text.Encoding.Default.GetString(buffer);

                string[] tokens = clientcommand.Split(new Char[] { '|' });

                if (tokens[0] == "CONNECT") {

                    for (int n = 0; n < clients.Count; n++) {

                        Client cl = (Client)clients[n];
                        SendToClient(cl, "JOIN|" + tokens[1]);
                    }
                    EndPoint ep = client.RemoteEndPoint;
                    Client c = new Client(tokens[1], ep, clientservice, client);
                    clients.Add(c);
                    string message = "LISTEN|" + GetChatterList() + "\r\n";
                    SendToClient(c, message);
                    ClientList.Items.Add(c);

                }
                if (tokens[0] == "CHAT") {
                    for (int n = 0; n < clients.Count; n++) {
                        Client cl = (Client)clients[n];
                        SendToClient(cl, clientcommand);
                    }
                }
                if (tokens[0] == "PRIV") {
                    string destclient = tokens[3];
                    for (int n = 0; n < clients.Count; n++) {
                        Client cl = (Client)clients[n];
                        if (cl.Name.CompareTo(tokens[3]) == 0)
                            SendToClient(cl, clientcommand);
                        if (cl.Name.CompareTo(tokens[1]) == 0)
                            SendToClient(cl, clientcommand);
                    }
                }
                if (tokens[0] == "LEAVE") {
                    int remove = 0;
                    bool found = false;
                    int c = clients.Count;
                    for (int n = 0; n < c; n++) {
                        Client cl = (Client)clients[n];
                        SendToClient(cl, clientcommand);
                        if (cl.Name.CompareTo(tokens[1]) == 0) {
                            remove = n;
                            found = true;
                            ClientList.Items.Remove(cl);
                        }
                    }
                    if (found)
                        clients.RemoveAt(remove);
                    client.Close();
                    alive = false;
                }
            }
        }
        private void SendToClient(Client cl, string message) {
            try {
                byte[] buffer = System.Text.Encoding.Default.GetBytes(message.ToCharArray());
                cl.Sock.Send(buffer, buffer.Length, 0);
            } catch (Exception) {
                cl.Sock.Close();
                cl.CLThread.Abort();
                clients.Remove(cl);
                ClientList.Items.Remove(cl.Name + " : " + cl.Host.ToString());
            }
        }
        private string GetChatterList() {
            string chatters = "";
            for (int n = 0; n < clients.Count; n++) {
                Client cl = (Client)clients[n];
                chatters += cl.Name;
                chatters += "|";
            }
            chatters.Trim(new char[] { '|' });
            return chatters;
        }

        private void ServiceOK_Click(object sender, EventArgs e) {
            if (PortNum.Text != "51028")
                listenport = Convert.ToInt32(PortNum.Text);

            Control.CheckForIllegalCrossThreadCalls = false;
            clients = new ArrayList(); //开始一个监听线程  
            processor = new Thread(new ThreadStart(StartListening));
            processor.Start();
            MessageBox.Show("开始监听！");
        }

        private void ChatRoomService_FormClosing(object sender, FormClosingEventArgs e) {
            System.Environment.Exit(0);
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            clientservice.Abort();
            processor.Abort();
            System.Environment.Exit(0);
        }
    }

    public class Client {
        public Client(string Name, EndPoint Host, Thread CLThread, Socket Sock) {
            this.Name = Name;
            this.Host = Host;
            this.CLThread = CLThread;
            this.Sock = Sock;
        }

        public string Name { get; set; }
        public EndPoint Host { get; set; }
        public Thread CLThread { get; set; }
        public Socket Sock { get; set; }
    }
}
