using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Incognito
{
    class PublicIP
    {
        public string GetPublicIPAddress()
        {
            string Publicip = new WebClient().DownloadString("http://icanhazip.com");
            return Publicip;
        }
    }
}
