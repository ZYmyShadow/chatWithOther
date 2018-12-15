using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace chatWithOther {
    public partial class chatRoom : Form {

        public chatRoom() => InitializeComponent();

        private void chatRoom_Load(object sender, EventArgs e) {
        }

        private void chatRoom_FormClosed(object sender, FormClosedEventArgs e) {
            System.Environment.Exit(0);
        }

        private void sendButton_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                sendButton_Click(sender, e);
            } else if (e.KeyCode == Keys.Escape) {
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
            return null;
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
