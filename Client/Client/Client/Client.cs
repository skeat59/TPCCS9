using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    class Client
    {
        public static Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Stream stream = new NetworkStream(s);
        StreamWriter SW = new StreamWriter(new NetworkStream(s));
        StreamReader SR = new StreamReader(new NetworkStream(s));
        public void Connect(string host, int port, string name)
        {
            s.Connect(host, port);
            SW.WriteLine(name);
            if (SR.ReadLine() == "Welcone")
            {
                SW.WriteLine("Confirmation : Welcome");
            }
            else
            {
                Console.WriteLine("You're blacklisted, get lost");
            }
        }
        public bool IsConnected()
        {
            return (s.Connected);
        }
        public void Run()
        {
            Thread t = new Thread(new ThreadStart(MyThread));
            Thread t2 = new Thread(new ThreadStart(ThreadWrite));
        }
        static void MyThread();
        static void ThreadWrite();
        public void Read()
        {
            if (s.Poll(500, SelectMode.SelectRead))
            {
                int lettre = stream.ReadByte();
                string mot = "";

                while (lettre != -1)
                {
                    mot += (char)lettre;
                    lettre = stream.ReadByte();
                }


                Console.WriteLine(mot);
            }
        }
        public void Write()
        {
            string message = Console.ReadLine();
            int i = message.Length;
            while (i >= 0)
            {
                stream.WriteByte((byte)message[i]);   
            }
        }
        public void Close();
    }
}
