using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class Tramite
    {
        public Int32 IdM_Tramite;
        public P_SubtipoTramite P_SubTT;
        public VarProcesoTramite VarProTramite;
        public VarTramiteReco VarProTramiteReco;

        public Tramite()
        {
            P_SubtipoTramite objPST = new P_SubtipoTramite();
            this.P_SubTT = objPST;
            VarProcesoTramite objVarProT = new VarProcesoTramite();
            this.VarProTramite = objVarProT;
        }

        public void GetInfoTramite(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                String Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "IdP_SubtipoTramite":
                        this.P_SubTT.IdP_SubTipoTramite = Convert.ToInt32(tmpXML.Attributes.GetNamedItem("key").InnerText);
                        this.P_SubTT.GetInfoSubtipoTramite(tmpXML.ChildNodes);
                        break;
                    case "IdM_VariablesProcesoTram":
                        this.VarProTramite.IdM_VarProcesoTramite = Convert.ToInt32(tmpXML.Attributes.GetNamedItem("key").InnerText);
                        this.VarProTramite.GetInfoVarProcesoTramite(tmpXML.ChildNodes);
                        break;
                }
            }
        }
    }
}
