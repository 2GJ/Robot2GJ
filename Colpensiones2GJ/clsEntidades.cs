using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class clsEntidades
    {
    }

    public class M_Cat_Reconocimiento
    {
        public Int32 IdEntity;

        public M_Tramite MTramite;

        # region Constructores...
        public M_Cat_Reconocimiento(Int32 In_IdEntity)
        {
            this.IdEntity = In_IdEntity;
        }
        # endregion

        # region Captura de Informacion
        public void CargaGeneralXMLNodeM_Cat_Reconocimiento(XmlNode In_NodeMCatRec)
        {
            XmlNode NodeM_Tramite = In_NodeMCatRec.SelectSingleNode("M_Tramite");
            if (NodeM_Tramite.InnerText != null)
            {
                //if (NodeM_Tramite.InnerText == "M_Tramite")
                //{
                M_Tramite objM_Tramite = new M_Tramite(Convert.ToInt32(NodeM_Tramite.Attributes["key"].InnerText));
                this.MTramite = objM_Tramite;
                //}
            }
        }
        # endregion
    }

    public class M_Tramite
    {
        public Int32 IdEntity;

        # region Constructores...
        public M_Tramite(Int32 In_IdEntity)
        {
            this.IdEntity = In_IdEntity;
        }
        # endregion

        # region Captura de Informacion
        private void CargaGeneralXMLNodeM_Tramite(XmlNode In_NodeMCatRec)
        {
            //XmlNode NodeM_Tramite = In_NodeMCatRec.SelectSingleNode("M_Tramite");
            //if (NodeM_Tramite.InnerText != null)
            //{
            //    if (NodeM_Tramite.InnerText == "M_Tramite")
            //    {
            //        M_Cat_Reconocimiento objM_Cat_Rec = new M_Cat_Reconocimiento(Convert.ToInt32(NodeCatRec.Attributes["key"].InnerText));
            //    }
            //}
        }
        # endregion
    }
}
