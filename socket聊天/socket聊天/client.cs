using System.Net.Sockets;
using System.Text;

namespace socket聊天
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private Socket socketClient;

        private void StartConnect(object sender, EventArgs e)
        {
            string ip = serverIPTextBox.Text;
            int port = Convert.ToInt32(serverPortTextBox.Text);
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketClient.Connect(ip, port);
                MessageBox.Show("连接成功");
                flagOfConnection = true;
                ThreadPool.QueueUserWorkItem((_) => { RecieveAndShow(); }, this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败\r\n" + ex.Message);
            }


        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (flagOfConnection)
            {
                SendAndShow();
            }
            else
                MessageBox.Show("请先连接");
            sendTextBox.Text = "";
        }
        private void SendAndShow()
        {

            //转化为字节数组
            byte[] bytesFromText = Encoding.UTF8.GetBytes(sendTextBox.Text);
            //留一个空用来存 空字符
            byte[] bytesToSend = new byte[bytesFromText.Length + 1];
            //
            for (int i = 0; i < bytesFromText.Length; i++)
            {
                bytesToSend[i] = bytesFromText[i];
            }
            bytesToSend[bytesFromText.Length] = 0;


            socketClient.Send(bytesToSend);

            chatTextBox
                      .AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                      "\r\n" +
                      "I say:" +
                      sendTextBox.Text.ToString() +
                      "\r\n");
        }

       
        public void RecieveAndShow()
        {
            string text = null;
            List<byte> list = new List<byte>();
            while (true)
            {

                byte[] buffer = new byte[1024];
                int bytesRead = socketClient.Receive(buffer);

                //把读到的所有字节添加到list中
                for (int i = 0; i < bytesRead; i++)
                {
                    list.Add(buffer[i]);
                }

                //收到0字节说明读到尾部
                if (buffer[bytesRead - 1] == 0x0)
                {
                    byte[] bytes = new byte[list.Count - 1];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = list[i];
                    }

                    list.Clear();
                    text = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    chatTextBox
                        .AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "\r\n" +
                        "He say:" +
                        text.ToString() +
                        "\r\n");
                }
            }
        }



        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socketClient != null)
                socketClient.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sendTextBox.Text.Length.ToString());

        }
        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!flagOfConnection)
            //    {
            //        MessageBox.Show("请先连接");

            //    }
            //    else
            //        SendAndShow();
            //    sendTextBox.Text = "";
            //    e.Handled = true;

            //}

        }
        private void sendTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (!flagOfConnection)
            //    {
            //        MessageBox.Show("请先连接");

            //    }
            //    else
            //        SendAndShow();
            //    sendTextBox.Text = "";
            //    e.Handled = true;
            //}
        }
        private void sendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!flagOfConnection)
                {
                    MessageBox.Show("请先连接");

                }
                else
                    SendAndShow();
                sendTextBox.Text = "";
                e.Handled = true;

            }
        }
    }
}
