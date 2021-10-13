using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace D900NativeTest
{
    class socketMessage: Socket
    {
        public socketMessage(System.Net.IPAddress host, Int32 port, SocketType socketType, ProtocolType protocolType): base(socketType, protocolType)
        {
            this.Connect(host, port);
        }

        public void login(string user, string pass)
        {
            Byte[] userData = System.Text.Encoding.ASCII.GetBytes(user+"\r\n");
            Byte[] passData = System.Text.Encoding.ASCII.GetBytes(pass+"\r\n");
            byte[] data = new byte[256];
            string readString = string.Empty;

            Int32 inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);

            inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);

            this.Send(userData, 0, userData.Length, SocketFlags.None);
            this.Send(passData, 0, passData.Length, SocketFlags.None);

            inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);

            inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);
        }

        public string sendNative(string message)
        {
            byte[] msgData = System.Text.Encoding.ASCII.GetBytes(message + "\r\n");
            byte[] data = new byte[256];
            string readString = string.Empty;

            this.Send(msgData, 0, msgData.Length, SocketFlags.None);
            
            Int32 inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);

            inData = this.Receive(data);
            readString = System.Text.Encoding.ASCII.GetString(data, 0, inData);
            Console.WriteLine(readString);

            return readString;
        }
    }
}
