using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class P_Decision
    {
        public Int32 IdP_Decision;
        public string SCodColpensiones;
        public string SEstadoDecision;
        public string SDecision;
        public string SCodigo;

        public void Get_InfoPDecision(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                string Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "SCodColpensiones":
                        this.SCodColpensiones = tmpXML.InnerText;
                        break;
                    case "SDecision":
                        this.SDecision = tmpXML.InnerText;
                        break;
                    case "SEstadoDecision":
                        this.SEstadoDecision = tmpXML.InnerText;
                        break;
                    case "SCodigo":
                        this.SCodigo = tmpXML.InnerText;
                        break;
                }
            }
        }
    }
}
