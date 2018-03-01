using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class VarTramiteReco
    {
        public Boolean EspInfoTP;
        public P_RespuestaValidacion IdRespBO;

        public void GetInfoVarTramiteReco(XmlNodeList In_XML)
        {
             foreach (XmlNode tmpXML in In_XML)
             {
                 string Atributo = tmpXML.Name;

                 switch (Atributo)
                 {
                    case "BEsperarInfoTiempoPub":
                        this.EspInfoTP = Convert.ToBoolean(Convert.ToInt16(tmpXML.InnerText));
                        break;
                 }
             }   
        }

        public void Set_InfoRespuestaBOById(Int16 In_IdResBO)
        {
            P_RespuestaValidacion objPR = new P_RespuestaValidacion();
            objPR.Get_InfoById(In_IdResBO);
            this.IdRespBO = objPR;
        }
    }
}
