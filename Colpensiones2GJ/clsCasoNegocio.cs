using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class clsCasoNegocio
    {
        public string Priorodad;

        public clsReconocimiento Reconocimiento;
        public clsTramiteReconocimiento TramiteReconocimiento;


        public clsCasoNegocio()
        {
            this.Reconocimiento = null;
        }

        # region Operaciones de Consulta Informacion
            public void GetDatosGeneralesNegocio(Int32 In_IdCase, String In_Proceso)
            {
                if (In_Proceso == "Reconocimiento")
                    this.GetDatosGeneralesReconocimiento(In_IdCase);
            }
            public void GetDatosGeneralesReconocimiento(Int32 In_IdCase)
            {
                try
                {
                    clsReconocimiento objReconocimiento = new clsReconocimiento();
                    this.Reconocimiento = objReconocimiento;
                    this.GetXMLGetCaseDataSchemaAppReconocimiento(this.Reconocimiento.GetInfoDataGeneralReconocimiento(In_IdCase));
                }
                catch (Exception ex)
                {

                }
            }
        # endregion

        # region Operaciones de lectura de XML
            private void GetXMLGetCaseDataSchemaAppReconocimiento(String In_XML)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(In_XML);
                XmlNodeList NodoApp = xmlDoc.SelectNodes("/BizAgiWSResponse/App");

                if (NodoApp.Count > 0)
                {
                    foreach (XmlNode tmpNodo in NodoApp)
                    {
                        if (tmpNodo.Name == "App")
                        {
                            XmlNodeList lstNodoApp = tmpNodo.ChildNodes;

                            if (lstNodoApp.Count > 0)
                            {
                                foreach (XmlNode tmpNodeHijo in lstNodoApp)
                                {

                                    string Atrib = tmpNodeHijo.Name;

                                    switch (Atrib)
                                    {
                                        case "SPrioridad":
                                            this.Priorodad = tmpNodeHijo.InnerText;
                                            break;

                                        case "M_cat_Reconocimiento":
                                            this.Reconocimiento.CargaXML_NodoM_Cat_Reconocimiento(tmpNodo.SelectSingleNode("M_cat_Reconocimiento"));
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        # endregion
    }
}
