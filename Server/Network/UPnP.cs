using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.IO;

namespace Server.Network
{

    /* This implementation of NAT traversal comes from
     * www.codeproject.com/Articles/27992/NAT-Traversal-with-UPnP-in-C
     * which is licensed under public domain certification of Creative Commons.
     */ 
    public class NAT
    {
        static TimeSpan _timeout = new TimeSpan(0, 0, 0, 3);
        public static TimeSpan TimeOut
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        static string _descUrl, _serviceUrl, _eventUrl, _servType;
        public static bool Discover()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            string req = "M-SEARCH * HTTP/1.1\r\n" +
            "HOST: 239.255.255.250:1900\r\n" +
            "ST:upnp:rootdevice\r\n" +
            "MAN:\"ssdp:discover\"\r\n" +
            "MX:3\r\n\r\n";
            byte[] data = Encoding.ASCII.GetBytes(req);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Broadcast, 1900);
            byte[] buffer = new byte[0x1000];

            DateTime start = DateTime.Now;

            do
            {
                s.SendTo(data, ipe);
                s.SendTo(data, ipe);
                s.SendTo(data, ipe);

                int length = 0;
                do
                {
                    length = s.Receive(buffer);

                    string resp = Encoding.ASCII.GetString(buffer, 0, length).ToLower();
                    if (resp.Contains("upnp:rootdevice"))
                    {
                        resp = resp.Substring(resp.ToLower().IndexOf("location:") + 9);
                        resp = resp.Substring(0, resp.IndexOf("\r")).Trim();
                        if (!string.IsNullOrEmpty(_serviceUrl = GetServiceUrl(resp)))
                        {
                            _descUrl = resp;
                            return true;
                        }
                    }
                } while (length > 0);
            } while (start.Subtract(DateTime.Now) < _timeout);
            return false;
        }

        private static string GetServiceUrl(string resp)
        {
#if !DEBUG
            try
            {
#endif
                XmlDocument desc = new XmlDocument();
                desc.Load(WebRequest.Create(resp).GetResponse().GetResponseStream());
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(desc.NameTable);
                nsMgr.AddNamespace("tns", "urn:schemas-upnp-org:device-1-0");
                XmlNode typen = desc.SelectSingleNode("//tns:device/tns:deviceType/text()", nsMgr);
                if (!typen.Value.Contains("InternetGatewayDevice"))
                    return null;
                XmlNode serv = desc.SelectSingleNode("//tns:service/tns:serviceType/text()", nsMgr);
                _servType = "urn:schemas-upnp-org:service:WANPPPConnection:1";
                XmlNode node = desc.SelectSingleNode(String.Format("//tns:service[tns:serviceType=\"{0}\"]/tns:controlURL/text()", _servType), nsMgr);
                if (node == null)
                    return null;

                XmlNode eventnode = desc.SelectSingleNode("//tns:service[tns:serviceType=\"" + _servType + "\"]/tns:eventSubURL/text()", nsMgr);
                _eventUrl = CombineUrls(resp, eventnode.Value);
                return CombineUrls(resp, node.Value);
#if !DEBUG
            }
            catch { return null; }
#endif
        }

        private static string CombineUrls(string resp, string p)
        {
            int n = resp.IndexOf("://");
            n = resp.IndexOf('/', n + 3);
            return resp.Substring(0, n) + p;
        }

        public static void ForwardPort(int port, ProtocolType protocol, string description)
        {
            if (string.IsNullOrEmpty(_serviceUrl))
                throw new Exception("No UPnP service available or Discover() has not been called");
            // Note: The ip is hardcoded. Need to fix that.
            XmlDocument xdoc = SOAPRequest(_serviceUrl, 
                String.Format("<u:AddPortMapping xmlns:u=\"{0}\"><NewRemoteHost></NewRemoteHost><NewExternalPort>{1}</NewExternalPort><NewProtocol>{2}</NewProtocol><NewInternalPort>{3}</NewInternalPort>"
                               + "<NewInternalClient>{4}</NewInternalClient><NewEnabled>1</NewEnabled><NewPortMappingDescription>{5}</NewPortMappingDescription><NewLeaseDuration>0</NewLeaseDuration></u:AddPortMapping>", 
                               _servType, port.ToString(), protocol.ToString().ToUpper(), port.ToString(), "192.168.1.2", description), "AddPortMapping");
        }

        public static void DeleteForwardingRule(int port, ProtocolType protocol)
        {
            if (string.IsNullOrEmpty(_serviceUrl))
                throw new Exception("No UPnP service available or Discover() has not been called");
            XmlDocument xdoc = SOAPRequest(_serviceUrl, 
                String.Format("<u:DeletePortMapping xmlns:u=\"{0}\"><NewRemoteHost></NewRemoteHost><NewExternalPort>{1}</NewExternalPort><NewProtocol>{2}</NewProtocol></u:DeletePortMapping>",
                               _servType, port.ToString(), protocol.ToString().ToUpper()), "DeletePortMapping");
        }

        public static IPAddress GetExternalIP()
        {
            if (string.IsNullOrEmpty(_serviceUrl))
                throw new Exception("No UPnP service available or Discover() has not been called");
            XmlDocument xdoc = SOAPRequest(_serviceUrl, "<u:GetExternalIPAddress xmlns:u=\"" + _servType + "\">" +
            "</u:GetExternalIPAddress>", "GetExternalIPAddress");
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xdoc.NameTable);
            nsMgr.AddNamespace("tns", "urn:schemas-upnp-org:device-1-0");
            string IP = xdoc.SelectSingleNode("//NewExternalIPAddress/text()", nsMgr).Value;
            return IPAddress.Parse(IP);
        }

        private static XmlDocument SOAPRequest(string url, string soap, string function)
        {
            string req = "<?xml version=\"1.0\"?>" +
            "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
            "<s:Body>" +
            soap +
            "</s:Body>" +
            "</s:Envelope>";
            WebRequest r = HttpWebRequest.Create(url);
            r.Method = "POST";
            byte[] b = Encoding.UTF8.GetBytes(req);
            r.Headers.Add("SOAPACTION", "\"" + _servType + "#" + function + "\"");
            r.ContentType = "text/xml; charset=\"utf-8\"";
            r.ContentLength = b.Length;
            r.GetRequestStream().Write(b, 0, b.Length);
            XmlDocument resp = new XmlDocument();
            try
            {
                using (WebResponse wres = r.GetResponse())
                {
                    Stream ress = wres.GetResponseStream();
                    resp.Load(ress);
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Response);
            }
            
            return resp;
        }
    }
}
