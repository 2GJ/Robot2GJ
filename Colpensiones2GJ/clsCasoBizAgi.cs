using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class clsCasoBizAgi
    {
        public Int32 IdCase;
        public String RadNumber;
        public string FechaCreacion;
        public string FechaSolucion;
       
        public clsCasoNegocio CasoNegocio;

        # region Constructores...
            public clsCasoBizAgi(Int32 In_IdCase, String In_RadNamber)
            {
                this.IdCase = In_IdCase;
                this.RadNumber = In_RadNamber;
                this.CasoNegocio = null;
            }
        # endregion

        # region Metodos de Consulta Informacion...
            public void GetDatosGenerales()
            {
                try
                {
                    CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
                    String Respuesta = objCapaSOA.ServicioGetCaseAsString(this.BuildXMLGetCase());
                    this.GetXMLGetCaseAsString(Respuesta);
                }
                catch (Exception ex)
                {
                     //ex.Message.ToString();
                }
         
            }
            public void GetDatosProcesoReconocimientoGenerales()
            {
                try
                {
                    clsCasoNegocio objCasoNegocio = new clsCasoNegocio();
                    this.CasoNegocio = objCasoNegocio;

                    this.CasoNegocio.GetDatosGeneralesNegocio(this.IdCase, "Reconocimiento");
                }
                catch (Exception ex)
                {
                    //ex.Message.ToString();
                }
            }
        # endregion

        # region Operaciones de lectura de XML
            private void GetXMLGetCaseAsString(String In_XML)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(In_XML);

                //Nodo Process...
                XmlNodeList NodoProcesses = xmlDoc.SelectNodes("/processes");

                //solo camptura un caso....
                if (NodoProcesses.Count > 0)
                {
                    foreach (XmlNode tmpNodeHijProcesses in NodoProcesses)
                    {
                        string Atrib = tmpNodeHijProcesses.Name;

                        switch (Atrib)
                        {
                            case "processes":
                                this.CargaXMLNodoPorcesses(tmpNodeHijProcesses);
                                break;
                        }
                    }
                }
            }
            private void CargaXMLNodoPorcesses(XmlNode In_NodoProcesses)
            {
                XmlNodeList lstNodoProcesses = In_NodoProcesses.ChildNodes;

                if (lstNodoProcesses.Count > 0)
                {
                    foreach (XmlNode tmpNodoProcesses in lstNodoProcesses)
                    {
                        string Atrib = tmpNodoProcesses.Name;

                        switch (Atrib)
                        {
                            case "process":
                                this.CargaXMLNodoProcess(tmpNodoProcesses);
                                break;
                        }
                    }
                }
            }
            private void CargaXMLNodoProcess(XmlNode In_NodoProcess)
            {
                //Carga el processId para verificar si es el mismo IdCase...
                XmlNode NodeProcess = In_NodoProcess.SelectSingleNode("processId");
                if (NodeProcess.InnerText != null)
                {
                    if (NodeProcess.InnerText == this.IdCase.ToString())
                    {
                        XmlNodeList lstNodoProcess = In_NodoProcess.ChildNodes;

                        if (lstNodoProcess.Count > 0)
                        {
                            foreach (XmlNode tmpNodeHijProcess in lstNodoProcess)
                            {
                                string Atrib = tmpNodeHijProcess.Name;

                                switch (Atrib)
                                {
                                    case "processRadNumber":
                                        this.RadNumber = tmpNodeHijProcess.InnerText;
                                        break;

                                    case "processCreationDate":
                                        this.FechaCreacion = tmpNodeHijProcess.InnerText;
                                        break;

                                    case "processSolutionDate":
                                        this.FechaSolucion = tmpNodeHijProcess.InnerText;
                                        break;

                                    //case "CurrentWorkItems":
                                    //    if (CargaA == true)
                                    //        this.CargaXMLNodoCurrentWorkItems(tmpNodeHijProcess);
                                    //    break;
                                }
                            }
                        }
                    }
                }
   
            }
        # endregion

        # region Operaciones Internas de la Clase
            private String BuildXMLGetCase()
            {

                String sXML = null;

                //sXML += "<BizAgiWSParam>";
                //sXML += "<idCase>" + this.IdCase.ToString() + "</idCase>";
                //sXML += "</BizAgiWSParam>";
                                
                sXML += "<BizAgiWSParam>";
                //sXML += "<applicationName>App</applicationName>";
                //sXML += "<processName>RC01_Reconocimiento</processName>";
                sXML += "<idCase>" + this.IdCase + "</idCase>";
                sXML += "<radNumber>" + this.RadNumber + "</radNumber>";
                sXML += "</BizAgiWSParam>";

                return sXML;
            }
            private String BuildXSDGetCaseAplicacion()
            {

                String sXSD = "<?xml version=\"1.0\" encoding=\"utf-8\"?><xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"App\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNumeroRadicacion\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BContingencia\" type=\"xs:boolean\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BCasoRepresa\" type=\"xs:boolean\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SPrioridad\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\" type=\"xs:integer\" /></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence></xs:complexType></xs:element></xs:schema>";
                return sXSD;
            }
        # endregion
    }

}
