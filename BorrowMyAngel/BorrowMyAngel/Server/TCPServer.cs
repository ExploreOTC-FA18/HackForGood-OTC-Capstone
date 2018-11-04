using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BorrowMyAngel.Server
{
    public static class TCPServer
    {
        private static TcpListener _listener;
        private static Thread _serverThread;
        private static TcpClient _client;
        private static bool _doOnce;

        public static Action<string> ClientReceived;
        public static Action<string> MessageReceived;

        static public void Start()
        {
            IPAddress localAdd = IPAddress.Parse("10.12.69.183");
            _listener = new TcpListener(IPAddress.Any, 9999);
            _listener.Start();

            _serverThread = new Thread(RunThread);
            _serverThread.Start();
        }

        static public void Stop()
        {
            if (_serverThread != null && _serverThread.IsAlive)
            {
                _serverThread.Abort();
                _listener.Stop();
            }
        }

        static public void SendMessage(string message)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(message);
            _client.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
        }

        static private void RunThread()
        {
            while (true)   //we wait for a connection
            {
                _client = _listener.AcceptTcpClient();  //if a connection exists, the server will accept it

                while (_client.Connected && _serverThread.IsAlive)  //while the client is connected, we look for incoming messages
                {
                    if (!_doOnce)
                    {
                        ClientReceived("");
                        _doOnce = false;
                    }

                    byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
                    int bytesRead = _client.GetStream().Read(bytesToRead, 0, _client.ReceiveBufferSize);
                    string messageReceived = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    MessageReceived(messageReceived);
                }

                _client.Close();
            }
        }
    }
}
