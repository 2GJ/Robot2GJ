using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class P_RespuestaValidacion
    {
        public Int32 IdP_RespuestaValidacion;
        public string Codigo;
        public string Nombre;
        public string CodColpensiones;

        public CapaSOABizAgi objCSOA = new CapaSOABizAgi();

        public void Get_InfoById(Int16 In_Id)
        {
            string filtro = "<![CDATA[IdP_RespuestaNube = " + In_Id + "]]>";
            String XML = "";
            XML += "<BizAgiWSParam><EntityData><EntityName>";
            XML += "P_RespuestaValidacion";
            XML += "</EntityName><Filters>";
            XML += filtro;
            XML += "</Filters></EntityData></BizAgiWSParam>";

            this.Get_InfoXML(objCSOA.ServicioGetEntity(XML));
        }

        private void Get_InfoXML(string In_XML)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(In_XML);

            XmlNodeList Entities = xdoc.SelectNodes("/BizAgiWSResponse/Entities/P_RespuestaValidacion");

            foreach (XmlNode tmp in Entities)
            {
                this.IdP_RespuestaValidacion = Convert.ToInt32(tmp.Attributes.GetNamedItem("key").InnerText);

                //XmlNodeList NodH = tmp["P_RespuestaValidacion"].ChildNodes;
                XmlNodeList NodH = tmp.ChildNodes;
                
                foreach (XmlNode tmpH in NodH)
                {
                    switch (tmpH.Name.ToString())
                    {
                        case "SCodColpensiones":
                            this.CodColpensiones = tmpH.InnerText;
                            break;
                        case "SNombre":
                            this.Nombre = tmpH.InnerText;
                            break;
                        case "SCodigo":
                            this.Codigo = tmpH.InnerText;
                            break;
                    }
                }
            }
        }
    }
}
