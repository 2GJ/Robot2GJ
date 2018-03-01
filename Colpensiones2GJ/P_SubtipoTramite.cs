using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class P_SubtipoTramite
    {
        public Int32 IdP_SubTipoTramite;
        public String SCodigo;
        public String SNombre;
        public Boolean BRequiereEspera;
        public String SCodColpensiones;
        public string SCodColpServices;
        public Boolean BFamiliar;

        public void GetInfoSubtipoTramite(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                string Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "BRequiereEspera":
                        this.BRequiereEspera = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                    case "SCodColpensiones":
                        this.SCodColpensiones = tmpXML.InnerText;
                        break;
                    case "SCodigo":
                        this.SCodigo = tmpXML.InnerText;
                        break;
                    case "SCodColpServices":
                        this.SCodColpServices = tmpXML.InnerText;
                        break;
                    case "SNombre":
                        this.SNombre = tmpXML.InnerText;
                        break;
                    case "BFamiliar":
                        this.BFamiliar = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                } 
            }
        }
    }
}
