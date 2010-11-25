using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Random.org
{
    internal class WebInterface
    {
        public static string GetWebPage(string URL)
        {
            try
            {
                WebRequest request = WebRequest.Create(URL);
                request.Proxy = null;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Console.WriteLine (response.StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return (responseFromServer);
            }
            catch { throw new Exception("Unable to connect to Random.org."); }
        }
    }
}