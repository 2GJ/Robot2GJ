using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace Colpensiones2GJ
{
    public class XML
    {
        public XmlDocument xdoc;

        public XML()
        {
            xdoc = new XmlDocument();
        }

        public string GetNodoXML(string In_StrRuta, string In_StrNodo, string In_StrXML)
        {
            string sRes = ""; 

            xdoc.LoadXml(In_StrXML);
            XmlNodeList NodoList = xdoc.SelectNodes(In_StrRuta);

            if (NodoList.Count > 0)
            {
                foreach (XmlNode XN in NodoList)
                {
                    if (XN[In_StrNodo] != null)
                    {
                        sRes = XN[In_StrNodo].InnerText;
                    }
                }
            }

            return sRes;
        }
    }
}
