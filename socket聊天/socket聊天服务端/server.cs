using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace socket聊天服务端
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private void startOrStop_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;


            if (flagOfAccept == false && button.Text == "开始监听")
            {

                button.Text = "点击停止";


                //从线程池获取线程
                ThreadPool.QueueUserWorkItem((xxx) =>
                {
                    try
                    {
                        //创建socket并绑定
                        #region
                        socketTolisen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketTolisen.Bind(new IPEndPoint(IPAddress.Any, 12345));
                        #endregion
                        //  开始监听
                        socketTolisen.Listen();

                        //获得socket，与客户端相连
                        Socket serverSocket = socketTolisen.Accept();
                        chatTextBox.Text = "";
                        flagOfAccept = true;
                        MessageBox.Show("已经与客户端连接！");
                        //创建一个实例，传入Server对象和Socket对象
                        socketsFromAcceptsWithNoHearts = new SocketsFromAccepts(serverSocket, this);

                        //线程池中取线程，传入回调方法和参数
                        ThreadPool.QueueUserWorkItem(Recieve, socketsFromAcceptsWithNoHearts);

                        //1对1通信，不用循环监听进行多线程了
                        //while (true)
                        //{
                        //    //创建socket，与客户端相连
                        //    Socket serverSocket = socketTolisen.Accept();
                        //    //创建一个实例，传入Server对象和Socket对象
                        //    SocketsFromAccepts socketsFromAcceptsWithNoHearts = new SocketsFromAccepts(serverSocket, this);
                        //    //线程池中取线程，传入回调方法和参数
                        //    ThreadPool.QueueUserWorkItem(Recieve, socketsFromAcceptsWithNoHearts);
                        //}

                    }
                    catch (Exception)
                    {


                    }
                    finally
                    {
                        //关闭服务器监听socket
                        socketTolisen.Close();
                    }
                }, this);
                chatTextBox.Text = "正在监听。。";
            }
            else
            {
                if (socketsFromAcceptsWithNoHearts != null)
                    socketsFromAcceptsWithNoHearts.ServerSocket.Close();
                socketTolisen.Close();
                flagOfAccept = false;
                chatTextBox.Text = "";
                button.Text = "开始监听";
            }



        }

        public static void Recieve(Object obj)
        {
            SocketsFromAccepts socketsOfAccepts = obj as SocketsFromAccepts;
            socketsOfAccepts.RecieveAndShow();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (flagOfAccept == false)
            {
                MessageBox.Show("请先启动监听");
            }
            else
                socketsFromAcceptsWithNoHearts.ResponseAndShow();
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (flagOfAccept == false)
            //    {
            //        MessageBox.Show("请先启动监听");
            //    }
            //    else
            //        socketsFromAcceptsWithNoHearts.ResponseAndShow();
            //    sendTextBox.Text = "";

            //}
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (socketsFromAcceptsWithNoHearts != null && socketsFromAcceptsWithNoHearts.ServerSocket != null)
            //{
            //    socketsFromAcceptsWithNoHearts.ServerSocket.Close();
            //}
            //if (socketTolisen != null)
            //{
            //    socketTolisen.Close();
            //}
        }

        private void sendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (flagOfAccept == false)
                {
                    MessageBox.Show("请先启动监听");
                }
                else
                    socketsFromAcceptsWithNoHearts.ResponseAndShow();
                sendTextBox.Text = "";
                e.Handled = true;

            }
        }
    }

}
