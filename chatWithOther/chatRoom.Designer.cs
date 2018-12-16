namespace chatWithOther
{
    partial class ChatRoom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chatText = new System.Windows.Forms.TextBox();
            this.currentTime = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.currentPerson = new System.Windows.Forms.ListView();
            this.changeTime = new System.Windows.Forms.Timer(this.components);
            this.chatTextChange = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // chatText
            // 
            this.chatText.BackColor = System.Drawing.SystemColors.Control;
            this.chatText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chatText.Font = new System.Drawing.Font("宋体", 12F);
            this.chatText.Location = new System.Drawing.Point(12, 9);
            this.chatText.Multiline = true;
            this.chatText.Name = "chatText";
            this.chatText.ReadOnly = true;
            this.chatText.Size = new System.Drawing.Size(650, 410);
            this.chatText.TabIndex = 1;
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("宋体", 9F);
            this.currentTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.currentTime.Location = new System.Drawing.Point(665, 9);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(119, 12);
            this.currentTime.TabIndex = 2;
            this.currentTime.Text = "2018/12/12 11:11:11";
            this.currentTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inputText
            // 
            this.inputText.Font = new System.Drawing.Font("宋体", 12F);
            this.inputText.Location = new System.Drawing.Point(12, 426);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(650, 123);
            this.inputText.TabIndex = 3;
            this.inputText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyUp);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("宋体", 13F);
            this.sendButton.Location = new System.Drawing.Point(668, 526);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(118, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // currentPerson
            // 
            this.currentPerson.BackColor = System.Drawing.SystemColors.Control;
            this.currentPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPerson.Font = new System.Drawing.Font("宋体", 12F);
            this.currentPerson.Location = new System.Drawing.Point(668, 30);
            this.currentPerson.Name = "currentPerson";
            this.currentPerson.Size = new System.Drawing.Size(118, 490);
            this.currentPerson.TabIndex = 5;
            this.currentPerson.UseCompatibleStateImageBehavior = false;
            this.currentPerson.View = System.Windows.Forms.View.List;
            // 
            // changeTime
            // 
            this.changeTime.Enabled = true;
            this.changeTime.Interval = 1000;
            this.changeTime.Tick += new System.EventHandler(this.changeTime_Tick);
            // 
            // chatTextChange
            // 
            this.chatTextChange.Enabled = true;
            this.chatTextChange.Tick += new System.EventHandler(this.chatTextChange_Tick);
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 561);
            this.Controls.Add(this.currentPerson);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.chatText);
            this.MaximizeBox = false;
            this.Name = "ChatRoom";
            this.Text = "CHAT ROOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoom_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatRoom_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox chatText;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ListView currentPerson;
        private System.Windows.Forms.Timer changeTime;
        private System.Windows.Forms.Timer chatTextChange;
    }
}

