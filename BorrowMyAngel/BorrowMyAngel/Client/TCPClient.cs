using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BorrowMyAngel.Client
{
    public static class TCPClient
    {
        private static Thread _clientThread;
        private static TcpClient _client;

        public static Action<string> ReceivedMessage;

        public static void Start()
        {
            _client = new TcpClient("10.12.69.183", 9999);

            _clientThread = new Thread(RunThread);
            _clientThread.Start();
        }

        static public void Stop()
        {
            if (_clientThread != null && _clientThread.IsAlive)
                _clientThread.Abort();
        }

        public static void SendMessage(string message)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(message);
            _client.GetStream().Write(bytesToSend, 0, bytesToSend.Length);
        }

        private static void RunThread()
        {
            while (_client.Connected && _clientThread.IsAlive)
            {
                byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
                int bytesRead = _client.GetStream().Read(bytesToRead, 0, _client.ReceiveBufferSize);
                string messageReceived = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                ReceivedMessage(messageReceived);
            }
            _client.Close();
        }
    }
}
