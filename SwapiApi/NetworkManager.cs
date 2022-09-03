using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SwapiApi
{
    public class NetworkManager
    {
        private WebClient client = new WebClient();
        public string GetJson(string url)
        {
            return client.DownloadString(url);
        }
    }
}
