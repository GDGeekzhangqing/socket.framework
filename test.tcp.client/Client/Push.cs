﻿
using socket.framework.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test.tcp.client.Client
{
    public class Push
    {
        private TcpPushClient client;
        Random random = new Random();
        public Push(int receiveBufferSize, string ip, int port)
        {
            client = new TcpPushClient(receiveBufferSize);
            client.OnConnect += Client_OnConnect;
            client.OnReceive += Client_OnReceive;
            client.OnSend += Client_OnSend;
            client.OnClose += Client_OnClose;
            client.OnDisconnect += Client_OnDisconnect;
            client.Connect(ip, port);
        }

        private void Client_OnClose()
        {
            Console.WriteLine($"Push断开");
        }
        private void Client_OnDisconnect()
        {
            Console.WriteLine($"Push中断");
        }

        private void Client_OnReceive(byte[] obj)
        {
            Console.WriteLine($"Push接收长度[{obj.Length}]     {random.Next(1, 9999)}");
        }

        private void Client_OnConnect(bool obj)
        {
            Console.WriteLine($"Push连接{obj}");
        }

        private void Client_OnSend(int obj)
        {
            Console.WriteLine($"Push已发送长度{obj}    {random.Next(1, 9999)}");
        }

        public void Send(byte[] data, int offset, int length)
        {
            client.Send(data, offset, length);
        }

        public void Close()
        {
            client.Close();
        }

    }
}
