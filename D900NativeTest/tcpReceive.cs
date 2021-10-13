using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace D900NativeTest
{
    class tcpReceive: TcpListener
    {
        public tcpReceive(System.Net.IPAddress local, Int32 port): base(local, port)
        {
            this.Start();
        }
    }
}
