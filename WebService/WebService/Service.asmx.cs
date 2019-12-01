using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebService
{
    /// <summary>
    /// Description résumée de Service
    /// </summary>
    [WebService()]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    //[System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Fibonacci(int n)
        {
            if (n >= 1 && n <= 100)
            {
                int a = 0; // F0
                int b = 1; // F1

                for (int i = 0; i < n; i++)
                {
                    int tmp = a;
                    a = b;
                    b = tmp + b;
                }

                return a;
            }
            else
            {
                return -1;
            }

        }

        [WebMethod]
        public string XmlToJson(string xml)
        {
            string json = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                json= JsonConvert.SerializeXmlNode(doc);
            }
            catch(Exception e)
            {
                json = "Bad Xml format";
            }
            return json;
        }
    }
}
