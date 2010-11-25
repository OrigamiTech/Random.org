using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Random.org
{
    public static class QuotaChecker
    {
        private const string unexpected = "Error: unexpected data.";
        public static int Check()
        {
            int i;
            if (int.TryParse(WebInterface.GetWebPage("http://www.random.org/quota/?format=plain"), out i))
                return i;
            throw new Exception(unexpected);
        }
        public static int Check(IPAddress ip)
        {
            int i;
            if (int.TryParse(WebInterface.GetWebPage("http://www.random.org/quota/?ip=" + ip.ToString() + "&format=plain"), out i))
                return i;
            throw new Exception(unexpected);
        }
    }
}