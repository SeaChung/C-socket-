namespace socket聊天
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatTextBox = new TextBox();
            sendTextBox = new TextBox();
            sendButton = new Button();
            serverIPTextBox = new TextBox();
            label1 = new Label();
            serverPortTextBox = new TextBox();
            label2 = new Label();
            startConnectBtn = new Button();
            SuspendLayout();
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(12, 12);
            chatTextBox.Multiline = true;
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = ScrollBars.Both;
            chatTextBox.Size = new Size(533, 261);
            chatTextBox.TabIndex = 0;
            chatTextBox.TabStop = false;
            // 
            // sendTextBox
            // 
            sendTextBox.Location = new Point(12, 312);
            sendTextBox.Multiline = true;
            sendTextBox.Name = "sendTextBox";
            sendTextBox.ScrollBars = ScrollBars.Both;
            sendTextBox.Size = new Size(533, 90);
            sendTextBox.TabIndex = 1;
            sendTextBox.KeyDown += sendTextBox_KeyDown;
            sendTextBox.KeyPress += sendTextBox_KeyPress;
            sendTextBox.KeyUp += sendTextBox_KeyUp;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(601, 312);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(143, 90);
            sendButton.TabIndex = 2;
            sendButton.Text = "发送";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // serverIPTextBox
            // 
            serverIPTextBox.Location = new Point(601, 48);
            serverIPTextBox.Name = "serverIPTextBox";
            serverIPTextBox.Size = new Size(124, 27);
            serverIPTextBox.TabIndex = 3;
            serverIPTextBox.Text = "localhost";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(601, 25);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "服务器IP";
            // 
            // serverPortTextBox
            // 
            serverPortTextBox.Location = new Point(601, 109);
            serverPortTextBox.Name = "serverPortTextBox";
            serverPortTextBox.Size = new Size(124, 27);
            serverPortTextBox.TabIndex = 5;
            serverPortTextBox.Text = "12345";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(607, 81);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 6;
            label2.Text = "服务器端口";
            // 
            // startConnectBtn
            // 
            startConnectBtn.Location = new Point(602, 170);
            startConnectBtn.Name = "startConnectBtn";
            startConnectBtn.Size = new Size(123, 29);
            startConnectBtn.TabIndex = 7;
            startConnectBtn.Text = "点击连接";
            startConnectBtn.UseVisualStyleBackColor = true;
            startConnectBtn.Click += StartConnect;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startConnectBtn);
            Controls.Add(label2);
            Controls.Add(serverPortTextBox);
            Controls.Add(label1);
            Controls.Add(serverIPTextBox);
            Controls.Add(sendButton);
            Controls.Add(sendTextBox);
            Controls.Add(chatTextBox);
            Name = "Client";
            Text = "客户端";
            FormClosing += Client_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox chatTextBox;
        private TextBox sendTextBox;
        private Button sendButton;
        private TextBox serverIPTextBox;
        private Label label1;
        private TextBox serverPortTextBox;
        private Label label2;
        private Button startConnectBtn;
        public bool flagOfConnection=false;
    }
}
