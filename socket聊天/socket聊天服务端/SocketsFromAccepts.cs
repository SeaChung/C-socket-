using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socket聊天服务端
{/// <summary>
///  This class is used to recieve and response normal data,not heart data.
/// </summary>
    public class SocketsFromAccepts
    {
        private Socket serverSocket;
        private Server server;
        public Socket ServerSocket { get { return serverSocket; }
            }
        public SocketsFromAccepts(Socket socket, Server server)
        {
            this.serverSocket = socket;
            this.server = server;
        }
        public void RecieveAndShow()
        {
            string text = null;
            List<byte> list = new List<byte>();
            while (true)
            {

                byte[] buffer = new byte[1024];
                int bytesRead = serverSocket.Receive(buffer);

                //把读到的所有字节添加到list中
                for (int i = 0; i < bytesRead; i++)
                {
                    list.Add(buffer[i]);
                }

                //收到0字节说明读到尾部
                if (buffer[bytesRead - 1] == 0x0)
                {
                    byte[] bytes = new byte[list.Count-1];
                    for (int i = 0;i < bytes.Length; i++)
                    {
                        bytes[i] = list[i];
                    }
                    //if(list.Count)
                    list.Clear();
                    text = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    server.chatTextBox
                        .AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "\r\n" +
                        "He say:" +
                        text.ToString() +
                        "\r\n");
                }
            }
        }
        public void ResponseAndShow()
        {
            
            //转化为字节数组
            byte[] bytesFromText = Encoding.UTF8.GetBytes(server.sendTextBox.Text);
            //留一个空用来存 空字符
            byte[] bytesToResponse = new byte[bytesFromText.Length + 1];
            for (int i = 0; i < bytesFromText.Length; i++)
            {
                bytesToResponse[i] = bytesFromText[i];
            }
            bytesToResponse[bytesFromText.Length] = 0;

            serverSocket.Send(bytesToResponse);

            server.chatTextBox
                       .AppendText( DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                       "\r\n" +
                       "I say:" +
                       server.sendTextBox.Text.ToString() +
                       "\r\n");
            server.sendTextBox.Text = "";
        }
    }
}
