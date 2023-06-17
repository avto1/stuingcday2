using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pinger
{
    internal class PingService
    {
        public string Data { get; set;}
        public byte[] Buffer { get; set;}

        public int Timeout { get; set; }

        public string Adderss { get; set; }

        public Ping pingSender { get; set; }

        public PingOptions pingOptions { get; set; }

        public PingService()
        {
            Timeout = 120;
            Adderss = "4.2.2.2";
            Buffer = Encoding.ASCII.GetBytes("Learn to code");
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
        }

        public bool SendPing()
        {
            PingReply reply = pingSender.Send(Adderss, Timeout, Buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
