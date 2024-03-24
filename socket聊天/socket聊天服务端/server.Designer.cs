using System.Net.Sockets;

namespace socket聊天服务端
{
    partial class Server
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
            startOrStop = new Button();
            SuspendLayout();
            // 
            // chatTextBox
            // 
            chatTextBox.CausesValidation = false;
            chatTextBox.Location = new Point(25, 12);
            chatTextBox.Multiline = true;
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = ScrollBars.Both;
            chatTextBox.Size = new Size(483, 281);
            chatTextBox.TabIndex = 0;
            chatTextBox.TabStop = false;
            // 
            // sendTextBox
            // 
            sendTextBox.Location = new Point(25, 342);
            sendTextBox.Multiline = true;
            sendTextBox.Name = "sendTextBox";
            sendTextBox.ScrollBars = ScrollBars.Both;
            sendTextBox.Size = new Size(483, 79);
            sendTextBox.TabIndex = 1;
            sendTextBox.KeyDown += sendTextBox_KeyDown;
            sendTextBox.KeyPress += sendTextBox_KeyPress;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(570, 342);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(160, 79);
            sendButton.TabIndex = 2;
            sendButton.Text = "发送";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // startOrStop
            // 
            startOrStop.Location = new Point(562, 64);
            startOrStop.Name = "startOrStop";
            startOrStop.Size = new Size(168, 167);
            startOrStop.TabIndex = 3;
            startOrStop.Text = "开始监听";
            startOrStop.UseVisualStyleBackColor = true;
            startOrStop.Click += startOrStop_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startOrStop);
            Controls.Add(sendButton);
            Controls.Add(sendTextBox);
            Controls.Add(chatTextBox);
            Name = "Server";
            Text = "服务端";
            FormClosing += Server_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button sendButton;
        private Button startOrStop;
        private Socket socketTolisen;
        public TextBox chatTextBox;
        private bool flagOfAccept=false;
        public TextBox sendTextBox;
        public SocketsFromAccepts socketsFromAcceptsWithNoHearts;
    }
}
