using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static int count = 0;
        static int port = 8005;
        static List<Socket> connectedСlients = new List<Socket>();

        static void WorkWithClient(object listenSocket)
        {
            Console.WriteLine("Поток {0}, время {1}", count, DateTime.Now.ToShortTimeString());
            Socket handler = ((Socket)listenSocket).Accept();
            connectedСlients.Add(handler);
            int indexOfClient = connectedСlients.Count;
            StringBuilder builder = new StringBuilder();
            int bytes;
            byte[] data = new byte[255];
            do
            {
                builder.Clear();

                do
                {
                    try
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    catch
                    {
                        builder.Append("end");
                    }
                }
                while (handler.Available > 0);

                foreach (Socket socket in connectedСlients)
                {
                    StringBuilder answer = new StringBuilder(builder.ToString());
                    answer.Append("\nUser# ");
                    answer.Append(indexOfClient);
                    byte[] aBytes = Encoding.UTF8.GetBytes(answer.ToString());

                    if (builder.ToString() != "end")
                    {
                        socket.Send(aBytes);
                    }
                    else
                    {
                        answer.Append("end");
                        aBytes = Encoding.UTF8.GetBytes(answer.ToString());
                        socket.Send(aBytes);
                    }
                }
            }
            while (builder.ToString() != "end");            

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            count--;
            connectedСlients.Remove(handler);
        }


        static void Main(string[] args)
        {
            String Host = Dns.GetHostName();
            Console.WriteLine("Сomputer_NAME: = " + Host);
            IPAddress[] IPs;
            IPs = Dns.GetHostAddresses(Host);

            foreach (IPAddress ip1 in IPs)
            {
                Console.WriteLine(ip1);
            }

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                while (true)
                {
                    if (count < 10)
                    {
                        Thread thread = new Thread(WorkWithClient);
                        thread.Start(listenSocket);
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
