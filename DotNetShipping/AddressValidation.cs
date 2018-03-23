using DotNetShipping.ShippingProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DotNetShipping
{
   public class AddressValidation
    {
        // You will need a userId to use the USPS provider. Your account will also need access to the production servers.
        public static string uspsUserId = "234PERSO2626";

        public static string Main(string add1, string add2, string city, string state, string zip)
        {
            string reply = BuildRatesRequestMessage(add1, add2, city, state, zip);
            return SendRequest(reply);

            //if (business.Equals("Y"))
            //{
            //    return 'N';
            //}
            //else if (business.Equals("N"))
            //{
            //    return 'Y';
            //}
            //else
            //{
            //    return 'B';
            //}
        }

        private static string BuildRatesRequestMessage(string add1, string add2, string city, string state, string zip5)
        {
            var sb = new StringBuilder();

            var settings = new XmlWriterSettings();

            settings.Indent = false;
            settings.OmitXmlDeclaration = true;
            settings.NewLineHandling = NewLineHandling.None;

            using (var writer = XmlWriter.Create(sb, settings))
            {
                writer.WriteStartElement("AddressValidateRequest");
                writer.WriteAttributeString("USERID", uspsUserId);
                writer.WriteElementString("Revision", "1");
                writer.WriteStartElement("Address");
                writer.WriteAttributeString("ID", "0");
                writer.WriteElementString("Address1", add1);
                writer.WriteElementString("Address2", add2);
                writer.WriteElementString("City", city);
                writer.WriteElementString("State", state);
                writer.WriteElementString("Zip5", zip5);
                writer.WriteElementString("Zip4", "");
                writer.WriteEndElement();
               writer.WriteEndElement();


            }
            

            return sb.ToString();

        }

        private static string SendRequest(string input)
        {
            var reply = "";
            var response = "";
            string bus = "";

            try
            {
                var url = string.Concat("http://production.shippingapis.com/ShippingAPI.dll", "?API=Verify&XML=", input.ToString());
                var webClient = new WebClient();
                response = webClient.DownloadString(url);

                var document = XElement.Parse(response, LoadOptions.None);

               
                //ParseResult(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            XmlReader xReader = XmlReader.Create(new StringReader(response));
            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xReader.Name.Equals("Business"))
                        {
                            xReader.Read();
                            bus = xReader.Value;
                        }
                        reply += ("<" + xReader.Name + ">");
                        break;
                }
            }
            return bus;
        }
    }
}
