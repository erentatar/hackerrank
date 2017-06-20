using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrls
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> internalIPs = new List<string>()
            {
                "10.0.36.132",
                "10.0.36.133",
                "10.0.36.134",
                "10.0.36.135",
                "10.0.36.136",
                "10.0.36.137",
                "10.0.36.138",
                "10.0.36.139",
                "10.0.36.140",
                "10.0.36.141",
                "10.0.36.142",
                "10.0.36.143",
                "10.0.36.144",
                "10.0.36.145",
                "10.0.36.146",
                "10.0.36.147",
                "10.0.36.148",
                "10.0.36.167",
                "10.0.36.168",
                "10.0.36.169"
            };

            foreach (var ip in internalIPs)
            {
                string uri = "http://" + ip + "/Kurs/KrsKurs.aspx";

                System.Diagnostics.Process.Start(uri);
            }
        }
    }
}
