using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net.NetworkInformation;

namespace Incognito
{
    class Hwid
    {
        public string getHWID()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string HWID = string.Empty;
            foreach (ManagementObject mo in mbsList)
            {
                HWID = mo["ProcessorId"].ToString();
                break;
            }
            return HWID;
        }
    }
}
