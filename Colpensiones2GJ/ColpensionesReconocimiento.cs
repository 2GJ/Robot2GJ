using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class ColpensionesReconocimiento
    {
        public int Get_IdSucursalBancaria(int In_IdMunicio)
        {

            int IdSuc = 0;
            int iPrio = 0;

            CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");

            string tmp1242 = "<BizAgiWSParam><EntityData><EntityName>P_SucursalBancaria</EntityName><Filters><![CDATA[IdP_Ciudad = " + In_IdMunicio + " AND BAplicaPagRecAuto = 1]]></Filters></EntityData></BizAgiWSParam>";

            string ResP = objCapaSOA.getEntitiesAsString(tmp1242);

            XmlDocument xdocMun = new XmlDocument();

            xdocMun.LoadXml(ResP);

            XmlNodeList NodoMun = xdocMun.SelectNodes("/BizAgiWSResponse/Entities");

            if (NodoMun.Count > 0)
            {
                foreach (XmlNode XN in NodoMun)
                {
                    if (XN["P_SucursalBancaria"] != null)
                    {
                        string tmp = XN["P_SucursalBancaria"].Attributes.GetNamedItem("key").InnerText;
                        XmlNodeList NodosHijos = XN.ChildNodes;

                        foreach (XmlNode XNN in NodosHijos)
                        {
                            XmlNodeList NodosNietos = XNN["IdP_Banco"].ChildNodes;
                            
                            foreach (XmlNode XNNN in NodosNietos)
                            {
                                if (XNNN.Name == "IPrioridad")
                                {
                                    if ((Convert.ToInt16(XNNN.InnerText) < iPrio) || (iPrio == 0) || (IdSuc == 0))
                                    {
                                        iPrio = Convert.ToInt16(XNNN.InnerText);
                                        IdSuc = Convert.ToInt16(tmp);
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        //sRespBA += "NO SE PUEDO ACTUALIZAR SUCURSAL BANCARIA..";
                        IdSuc = 0;
                    }
                }
            }
            return IdSuc;
        }
    }
}
