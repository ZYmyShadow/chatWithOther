namespace chatRoomService {
    partial class ChatRoomService {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.ClientList = new System.Windows.Forms.ListBox();
            this.ServiceOK = new System.Windows.Forms.Button();
            this.PortNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientList
            // 
            this.ClientList.BackColor = System.Drawing.SystemColors.Control;
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 12;
            this.ClientList.Location = new System.Drawing.Point(12, 12);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(225, 88);
            this.ClientList.TabIndex = 0;
            // 
            // ServiceOK
            // 
            this.ServiceOK.Location = new System.Drawing.Point(243, 12);
            this.ServiceOK.Name = "ServiceOK";
            this.ServiceOK.Size = new System.Drawing.Size(75, 23);
            this.ServiceOK.TabIndex = 1;
            this.ServiceOK.Text = "OK";
            this.ServiceOK.UseVisualStyleBackColor = true;
            this.ServiceOK.Click += new System.EventHandler(this.ServiceOK_Click);
            // 
            // PortNum
            // 
            this.PortNum.BackColor = System.Drawing.SystemColors.Control;
            this.PortNum.Location = new System.Drawing.Point(98, 106);
            this.PortNum.Name = "PortNum";
            this.PortNum.Size = new System.Drawing.Size(100, 21);
            this.PortNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "PortNum：";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(243, 42);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "CLOSE";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ChatRoomService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 136);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortNum);
            this.Controls.Add(this.ServiceOK);
            this.Controls.Add(this.ClientList);
            this.Name = "ChatRoomService";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoomService_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.Button ServiceOK;
        private System.Windows.Forms.TextBox PortNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseButton;
    }
}

