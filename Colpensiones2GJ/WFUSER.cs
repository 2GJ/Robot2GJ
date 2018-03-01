using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class WFUSER
    {
        public Int32 IdUser;
        public string UsernName;
        public string FullName;

        //Constructor 
        public WFUSER()
        {
            IdUser = 0;
            UsernName = null;
            FullName = null;
        }

        //Validar existencia de usuario.
        public Boolean ValidarUsuario(string In_UsrName)
        {

            Int32 IdUser = 0;

            string ResP = this.GetEntityWFUSERbyUserName(In_UsrName);

            XmlDocument xDocUser = new XmlDocument();
            xDocUser.LoadXml(ResP);

            XmlNodeList NodoUser = xDocUser.SelectNodes("/BizAgiWSResponse/Entities");
            
            if (NodoUser.Count > 0)
            {
                foreach (XmlNode XN in NodoUser)
                {
                    if (XN["WFUSER"] != null)
                    {
                        string sIdUser = XN["WFUSER"].Attributes.GetNamedItem("key").InnerText;
                        this.IdUser = Convert.ToInt32(sIdUser);
                        IdUser = this.IdUser;

                        XmlNodeList NodosHijos = XN["WFUSER"].ChildNodes;
                        
                        foreach (XmlNode XNN in NodosHijos)
                        {
                            if (XNN.Name == "userName")
                            {
                                this.UsernName = XNN.InnerText;
                            }

                            if (XNN.Name == "fullName")
                            {
                                this.FullName = XNN.InnerText;
                            }
                        }
                    }
                }
            }
            if (this.IdUser > 0)
                return true;
            else
                return false;
        }

        //Consultar Entidad WFUSER por UserName
        public string GetEntityWFUSERbyUserName(string In_SUsernName)
        {
            string tmpEntities = "<BizAgiWSParam><EntityData><EntityName>WFUSER</EntityName><Filters><![CDATA[username = '" + In_SUsernName + "']]></Filters></EntityData></BizAgiWSParam>";
            CapaSOABizAgi objEntCapaSOA = new CapaSOABizAgi();
            return objEntCapaSOA.ServicioGetEntity(tmpEntities);
        }


    }
}
