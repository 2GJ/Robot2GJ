using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ColpensionesBC
{
    public class RespuestasBizAgi
    {
        private XmlDocument xdoc = new XmlDocument(); 

        public string CapturaRespuestaBA(string In_ResXML)
        {
            string sRespuesta = "";
            
            xdoc.LoadXml(In_ResXML);

            XmlNodeList NodoRC01 = xdoc.SelectNodes("process/processError");

            if (NodoRC01.Count > 0)
            {
                foreach (XmlNode XN in NodoRC01)
                {
                    if (XN["errorCode"] != null)
                    {
                        sRespuesta += XN["errorCode"].InnerText;
                    }
                    else
                    {
                        sRespuesta += "OK";
                    }
                    if (XN["errorMessage"] != null)
                    {
                        sRespuesta += XN["errorMessage"].InnerText;
                    }
                    else
                    {
                        sRespuesta += "EJECUCION CORRECTA...";
                    }
                }
            }
            else
            {

                XmlNodeList NodoRC01t = xdoc.SelectNodes("processes/process/processError");

                if (NodoRC01t.Count > 0)
                {
                    foreach (XmlNode XN in NodoRC01t)
                    {
                        if (XN["errorCode"] != null)
                        {
                            sRespuesta += XN["errorCode"].InnerText;
                        }
                        else
                        {
                            sRespuesta += "OK";
                        }
                        if (XN["errorMessage"] != null)
                        {
                            sRespuesta += XN["errorMessage"].InnerText;
                        }
                        else
                        {
                            sRespuesta += "EJECUCION CORRECTA...";
                        }
                    }
                }
            }
            
            return sRespuesta;
        }
    }
}
