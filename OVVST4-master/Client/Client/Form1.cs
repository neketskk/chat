using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        static readonly int port = 8005;
        static readonly string address = "127.0.0.1";
        static Socket socket;
        delegate void print(string text);
        private bool isActive = true;

        public Form1()
        {
            InitializeComponent();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            Thread thread = new Thread(ListenSocket);
            thread.Start(socket);
        }

        private void ListenSocket(object listeningSocket)
        {
            StringBuilder builder = new StringBuilder();
            Socket listenSocket = listeningSocket as Socket;
            byte[] data = new byte[256];
            int bytes = 0;

            try
            {
                while (true)
                {
                    builder.Clear();

                    do
                    {
                        bytes = listenSocket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (listenSocket.Available > 0);

                    var str = builder.ToString();

                    if (builder.ToString() != "")
                    {
                        OutInfo.Invoke(new print((s) => OutInfo.AppendText(s)),
                            "\n" + DateTime.Now.ToShortTimeString() + "\n" + "Сообщение: " + builder.ToString() + "\n");
                    }
                    else
                    {
                        OutInfo.Invoke(new print((s) => OutInfo.AppendText(s)),
                            "\n" + DateTime.Now.ToShortTimeString() + "\n" + "Сообщение: подключение отключено по кодовому слову");
                        throw new Exception();
                    }
                }
            }
            catch(Exception)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                isActive = false;
                OutInfo.Invoke(new print((s) => OutInfo.AppendText(s)),
                        "\n" + DateTime.Now.ToShortTimeString() + "\n" + "Сообщение: подключение с сервером разорвано\n");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                string message = InputInfo.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);
                socket.Send(data);
                InputInfo.Text = "";
            }
            else
            {
                OutInfo.Invoke(new print((s) => OutInfo.AppendText(s)),
                        "\n" + DateTime.Now.ToShortTimeString() + "\n" + "Сообщение: вы были отключены от сервера\n");
            }
        }
    }
}