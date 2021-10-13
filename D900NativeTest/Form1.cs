using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace D900NativeTest
{
    public partial class Form1 : Form
    {
        socketMessage insight;
        //tcpReceive insightReceive;

        public Form1()
        {
            InitializeComponent();
            //IPAddress local = IPAddress.Parse(GetLocalIPAddress());
            //insightReceive = new tcpReceive(local, 3000);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //set IP address and password
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(this.txtIP.Text);
            Int32 port = Int32.Parse(this.txtPort.Text);

            //open connection and login
            socketMessage D900 = new socketMessage(ip, port, SocketType.Stream, ProtocolType.Tcp);
            insight = D900;
            insight.login(this.txtUser.Text, this.txtPass.Text);

            //enable webhmi in program
            UriBuilder builder = new UriBuilder(this.txtIP.Text);
            this.webInsight.Url = builder.Uri;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //Get results of nativemode command
            this.lblResults.Text = insight.sendNative(this.txtMsg.Text);
        }

        //Get's local IP address to set TCP Listening IP and port
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
