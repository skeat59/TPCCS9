using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace MyBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            Send(args[0]);

            Console.Read();
        }
        public static void Send(string adress)
        {
            String message = "GET / HTTP/1.1\nHost :" + adress.Replace("www.", " ") + "\nConnection : close\n\n";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(adress, 80);

            Stream stream = new NetworkStream(s);
            StreamWriter Sw = new StreamWriter(new NetworkStream(s));

            for (int i = 0; i < message.Length; i++)
                stream.WriteByte((byte)message[i]);


            int lettre = stream.ReadByte();
            string mot = "";

            while (lettre != -1)
            {
                mot += (char)lettre;
                lettre = stream.ReadByte();
            }


            Console.WriteLine(mot);

            stream.Flush();
            s.Close();
        }
    }
}
