using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;

namespace Server.Misc
{
    public class PhpBB
    {
        private CookieContainer cookieJar;
        private string username;
        private string password;
        private readonly string loginUrl = "http://uotemrael.com/forum/ucp.php?mode=login";
        private readonly string postingUrl = "http://uotemrael.com/forum/posting.php?mode=post&f=";

        public void Login()
        {
            if (loginUrl.Length == 0 || username.Length == 0 || password.Length == 0)
            {
                Console.WriteLine("Information missing");
                return;
            }

            CookieContainer myContainer = new CookieContainer();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.CookieContainer = new CookieContainer();

            // Set type to POST
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            request.ContentType = "application/x-www-form-urlencoded";

            // Build the new header, this isn't a multipart/form, so it's very simple
            StringBuilder data = new StringBuilder();
            data.Append("username=" + Uri.EscapeDataString(username));
            data.Append("&password=" + Uri.EscapeDataString(password));
            data.Append("&login=Login&autologin=1");

            // Create a byte array of the data we want to send
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());

            // Set the content length in the request headers
            request.ContentLength = byteData.Length;

            Stream postStream;
            try
            {
                postStream = request.GetRequestStream();
            }
            catch (Exception e)
            {
                Console.WriteLine("Login - " + e.Message.ToString() + " (GRS)");
                return;
            }

            // Write data
            postStream.Write(byteData, 0, byteData.Length);

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine("Login - " + e.Message.ToString() + " (GR)");
                return;
            }

            bool isLoggedIn = false;

            // Store the cookies
            foreach (Cookie c in response.Cookies)
            {
                Console.WriteLine("name: {0}, value: {1}", c.Name, c.Value);
                if (c.Name.Contains("_u"))
                {
                    if (Convert.ToInt32(c.Value) > 1)
                    {
                        isLoggedIn = true;
                    }
                }
                myContainer.Add(c);
            }

            if (isLoggedIn)
            {
                cookieJar = myContainer;
            }
        }

        public void Post(string forumId, string subject, string message)
        {
            HttpWebResponse response = null;
            string source = string.Empty;
            string lastClick = string.Empty;
            string creationTime = string.Empty;
            string formToken = string.Empty;
            HttpWebRequest webRequest = null;
            if(cookieJar == null)
            {
                ExceptionLogging.WriteLine(new NullReferenceException(), "Non connecté au forum pour l'utilisateur {0}.", username);
                return;
            }

            // GET
            while (true)
            {
                webRequest =
                    (HttpWebRequest)HttpWebRequest.Create(postingUrl + forumId);
                webRequest.KeepAlive = true;
                webRequest.Method = "GET";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.CookieContainer = cookieJar;

                ServicePointManager.Expect100Continue = false;

                try
                {
                    response = (HttpWebResponse)webRequest.GetResponse();
                }
                catch (Exception ex)
                {
                    continue;
                }
                break;
            }

            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            source = streamReader.ReadToEnd();
            streamReader.Close();

            response.Close();

            // Get stuff
            // last click
            Match lastClickMatch = Regex.Match(source, "name=\"lastclick\" value=\"([0-9]{10})\" />");
            if (lastClickMatch.Success)
                lastClick = lastClickMatch.Groups[1].Value;

            // creation time
            Match creationTimeMatch = Regex.Match(source, "name=\"creation_time\" value=\"([0-9]{10})\" />");
            if (creationTimeMatch.Success)
                creationTime = creationTimeMatch.Groups[1].Value;

            // form token
            Match formTokenMatch = Regex.Match(source, "name=\"form_token\" value=\"(.{40})\" />");
            if (formTokenMatch.Success)
                formToken = formTokenMatch.Groups[1].Value;

            Thread.Sleep(8100);

            // POST
            webRequest = (HttpWebRequest)WebRequest.Create(postingUrl + forumId);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookieJar;
            string data = "icon=&subject=" + Uri.EscapeDataString(subject) + "&addbbcode20=100&message=" + Uri.EscapeDataString(message) 
                + "&attach_sig=on&post=Submit&lastclick=" + lastClick + "&creation_time=" + creationTime + "&form_token=" + formToken;

            byte[] byte1 = Encoding.UTF8.GetBytes(data);
            webRequest.ContentLength = byte1.Length;

            ServicePointManager.Expect100Continue = false;

            Stream stream = webRequest.GetRequestStream();
            stream.Write(byte1, 0, byte1.Length);
            stream.Close();

            response = (HttpWebResponse)webRequest.GetResponse();

            response.Close();
        }

        public PhpBB(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}

