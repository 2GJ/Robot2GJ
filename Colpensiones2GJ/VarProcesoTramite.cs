using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class VarProcesoTramite
    {
        public Int32 IdM_VarProcesoTramite;
        public Boolean CotizColpC1;
        public Boolean CotizColpC2;
        public Boolean TieneTPC1;
        public Boolean TieneTPC2;
        
        public void GetInfoVarProcesoTramite(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                string Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "BCotizColpC1":
                        this.CotizColpC1 = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                    case "BCotizColpC2":
                        this.CotizColpC2 = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                    case "BTieneTiemposPublicos":
                        this.TieneTPC1 = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                    case "BTieneTiemposPublicosC2":
                        this.TieneTPC2 = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                }
            }
        }
    }
}
