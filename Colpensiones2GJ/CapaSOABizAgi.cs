using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class CapaSOABizAgi
    {
        #region Atributos

        private String InXML;
        private String OutXML;
        private String Respuesta;
        private string CodeError;
        private String ErrorMessage;
        private XmlDocument xdoc = new XmlDocument();

        #endregion

        #region NUEVOS METODOS

        #region Geters

        public String GetLogFull()
        {
            return "Respuesta: " + this.Respuesta.ToString() + "\n" + "XML_IN: " + this.InXML + "\n" + "XML_OUT: " + this.OutXML;
        }

        public String GetRespuesta()
        {
            return this.Respuesta;
        }

        public String GetRespuestaDetails()
        {
            return "Respuesta: " + "\t" + this.Respuesta + "\n" + "In_XML:" + "\t" + this.InXML + "\n" + "Out_XML:" + "\t" + this.OutXML;
        }

        public String GetOutXML()
        {
            return this.OutXML;
        }
                
        public string GetCodeError()
        {
            return this.CodeError;
        }

        public String GetErrorMessage()
        {
            return this.ErrorMessage;
        }

        #endregion

        #region Servicios

        public void Servicio_QuerySOA_QueryCasesAsString(String In_XML)
        {
            try
            {
                this.InXML = In_XML;
                CapaSOAQueryForm.QueryFormSOASoapClient objQueryForm = new CapaSOAQueryForm.QueryFormSOASoapClient("QueryFormSOASoap");
                this.OutXML = objQueryForm.QueryCasesAsString(this.InXML);
                this.ProcesarRespuestaCapaSOA();
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        public void Servicio_SetEvent_ByIdCaseEventNameXML(Int32 In_IdCase, string In_EventName, string In_XML)
        {
            try
            {
                this.InXML = "<BizAgiWSParam><Events><Event><EventData><idCase>" + Convert.ToString(In_IdCase) + "</idCase>";
                this.InXML += "<eventName>" + In_EventName + "</eventName></EventData>";
                this.InXML += "<Entities><App>" + In_XML + "</App></Entities></Event></Events></BizAgiWSParam>";
                this.Servicio_SetEvent();
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        public void Servicio_SetEvent_ByIdCaseEventNameXML(Int32 In_IdCase, Int16 In_IdTask, string In_XML)
        {
            try
            {
                this.InXML += "<BizAgiWSParam><Events><Event><EventData><idCase>" + Convert.ToString(In_IdCase) + "</idCase>";
                this.InXML += "<idTask>" + In_IdTask + "</idTask></EventData>";
                this.InXML += "<Entities><App>" + In_XML + "</App></Entities></Event></Events></BizAgiWSParam>";
                this.Servicio_SetEvent();
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        public void Servicio_PerformActivity_ByIdCaseIdTask(Int32 In_IdCase, Int32 In_IdTask)
        {
            try
            {
                      
                this.InXML  = "<BizAgiWSParam>";
                this.InXML +=   "<ActivityData>";
                this.InXML +=       "<idCase>" + In_IdCase + "</idCase>";
                this.InXML +=       "<taskId>" + In_IdTask + "</taskId>";
                this.InXML +=   "</ActivityData>";
                this.InXML += "</BizAgiWSParam>";

                this.Servicio_PerformActivity();
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        public void Servicio_ReintentoAsincrona(Int32 In_IdCase, Int32 In_IdTask)
        {
            this.Servicio_PerformActivity_ByIdCaseIdTask(In_IdCase, In_IdTask);
            if (this.Respuesta == "891ValidationException: Las notificaciones para el subproceso son diferentes: 0_dif_0")
            {
                
            }
        }
           
        private void Servicio_SetEvent()
        {
            try
            {
                this.Respuesta = null;
                CapaSOABAWF.WorkflowEngineSOASoapClient objSaveEntity = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                this.OutXML = objSaveEntity.setEventAsString(this.InXML);
                this.NuevaCapturaRespuestaBA(this.OutXML);
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        private void Servicio_PerformActivity()
        {
            try
            {
                CapaSOABAWF.WorkflowEngineSOASoapClient objPerformAct = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                this.OutXML = objPerformAct.performActivityAsString(this.InXML);
                this.NuevaCapturaRespuestaBA(this.OutXML);
            }
            catch (Exception e1)
            {
                this.Respuesta = "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        #endregion

        #region RespuestasSOA

        private void ProcesarRespuestaCapaSOA()
        {
            this.xdoc.LoadXml(this.OutXML);
            XmlNode root = this.xdoc.FirstChild;

            if (root.Name == "BizAgiWSError")
            {
                this.Respuesta = "Error en el llamado al servicio.";
                if (root.ChildNodes.Count > 0)
                {
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {
                        if (root.ChildNodes[i].LocalName == "ErrorCode")
                            this.CodeError = root.ChildNodes[i].InnerText.ToString();
                        if (root.ChildNodes[i].LocalName == "ErrorMessage")
                            this.ErrorMessage = root.ChildNodes[i].InnerText.ToString();
                    }
                }
            }
            else if (root.Name == "BizAgiWSResponse")
            {
                this.Respuesta = "Respuesta Correcta de Servicio.";
                this.CodeError = "OK";
                if (root.ChildNodes.Count > 0)
                {
                    for (int i = 0; i < root.ChildNodes.Count; i++)
                    {
                        if (root.ChildNodes[i].Name == "Results")
                        {
                            for (int j = 0; j < root.ChildNodes[i].ChildNodes.Count; j++)
                            {
                                if (root.ChildNodes[i].ChildNodes[j].LocalName == "RowsCount")
                                {
                                    if (root.ChildNodes[i].ChildNodes[j].LocalName == "PageCount")
                                        this.Respuesta += " Page: " + root.ChildNodes[i].ChildNodes[j].InnerText.ToString();

                                    if (root.ChildNodes[i].ChildNodes[j].InnerText.ToString() != null)
                                    {
                                        if (Convert.ToInt64(root.ChildNodes[i].ChildNodes[j].InnerText.ToString()) > 0)
                                        {
                                            this.Respuesta += " Rows: " + root.ChildNodes[i].ChildNodes[j].InnerText.ToString();
                                        }
                                        else
                                        {
                                            this.Respuesta += " Rows: 0";
                                            //this.Respuesta = "Caso no existe en Reconocimientos.";
                                            //this.CodeError = "NOEXISTE";
                                            //j = root.ChildNodes[i].ChildNodes.Count;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

            private void NuevaCapturaRespuestaBA(string In_ResXML)
            {
                xdoc.LoadXml(In_ResXML);
                XmlNodeList NodoRC01 = xdoc.SelectNodes("/process/processError");

                if (NodoRC01.Count > 0)
                {
                    foreach (XmlNode XN in NodoRC01)
                    {
                        if (XN["errorCode"] != null)
                        {
                            this.Respuesta += XN["errorCode"].InnerText;
                        }
                        else
                        {
                            this.Respuesta += "OK";
                        }
                        if (XN["errorMessage"] != null)
                        {
                            this.Respuesta += XN["errorMessage"].InnerText;
                        }
                        else
                        {
                            this.Respuesta += "EJECUCION CORRECTA...";
                        }
                    }
                }
                else
                {
                    XmlNodeList NodoRC02 = xdoc.SelectNodes("/processes/process/processError");

                    if (NodoRC02.Count > 0)
                    {
                        foreach (XmlNode XN in NodoRC02)
                        {
                            if (XN["errorCode"] != null)
                            {
                                this.Respuesta += XN["errorCode"].InnerText;
                            }
                            else
                            {
                                this.Respuesta += "OK";
                            }
                            if (XN["errorMessage"] != null)
                            {
                                this.Respuesta += XN["errorMessage"].InnerText;
                            }
                            else
                            {
                                this.Respuesta += "EJECUCION CORRECTA...";
                            }
                        }
                    }
                    else
                    {
                        XmlNodeList NodoRC03 = xdoc.SelectNodes("/Entities/Error/ErrorMessage");

                        if (NodoRC03.Count > 0)
                        {
                            foreach (XmlNode XN in NodoRC03)
                            {
                                this.Respuesta += XN.InnerText;
                            }
                        }
                        else
                        {
                            XmlNodeList NodoRC04 = xdoc.SelectNodes("/BizAgiWSError/");
                            if (NodoRC04.Count > 0)
                            {
                                foreach (XmlNode XN in NodoRC03)
                                {
                                    this.Respuesta += XN.InnerText;
                                }
                            }
                            else
                            {
                                this.Respuesta += "EJECUCION CORRECTA...";
                            }
                        }
                    }
                }

                this.Respuesta = this.Respuesta.Replace("\n", "");
                if (this.Respuesta == "")
                    this.Respuesta = "EJECUCION CORRECTA...";
            }

        #endregion

        #endregion

        #region VIEJOS METODOS

        //Servicios del WorkflowEngineSOA
        //Servicio GETCASE 
        public string ServicioGetCaseAsString(string In_XML)
        {
            try
            {
                CapaSOABAWF.WorkflowEngineSOASoapClient objServicioBA = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                
                
                string sResPerAct = objServicioBA.getCasesAsString(In_XML);

                
                return sResPerAct;
            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message;
            }
        }
        
        //Servico SAVEENTITY
        public string ServicioSaveEntity(string In_XML)
        {

            try
            {

                string sRespuesta = In_XML;

                //realiza Save Entity...
                CapaSOABA.EntityManagerSOASoapClient ObjSaveEntity = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                string sResSE = ObjSaveEntity.saveEntityAsString(In_XML);

                sRespuesta += "\t" + sResSE;

                sRespuesta = this.CapturaRespuestaBA(sResSE) + "\t" + sRespuesta;

                return sRespuesta;

            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        //Servicio GETCASEDATASCHEMA
        public string ServicioGetCaseDataSchema(Int32 In_IdCase ,string In_XSD)
        {
            string sRespuesta = "";

            //realiza Save getData...
            CapaSOABA.EntityManagerSOASoapClient ObjSaveEntity = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
            string sResSE = ObjSaveEntity.getCaseDataUsingSchemaAsString(In_IdCase, In_XSD);

            sRespuesta += sResSE;
            
            return sRespuesta;
        }
       

        //Servicio SETEVENTBYXML
        public string ServicioSetEventByXML(string In_XML)
        {
            try
            {
                this.InXML = In_XML;
                CapaSOABAWF.WorkflowEngineSOASoapClient objSaveEntity = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                this.OutXML = objSaveEntity.setEventAsString(In_XML);
                return this.CapturaRespuestaBA(this.OutXML);
            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        //Servicio PERFORMACTIVITY
        public string ServicioPerformActivity(string In_XML)
        {
            try
            {
                this.InXML = In_XML;
                CapaSOABAWF.WorkflowEngineSOASoapClient objPerformAct = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                this.OutXML = objPerformAct.performActivityAsString(In_XML);
                return this.CapturaRespuestaBA(this.OutXML);
            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        //Servicio getCasesDataUsingXPaths
        public string ServicioGetCasesUsingXPaths(String In_XML)
        {
            string sRespuesta = "";

            CapaSOABA.EntityManagerSOASoapClient ObjSaveEntity = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
            string sResSE = ObjSaveEntity.getCaseDataUsingXPathsAsString(In_XML);

            sRespuesta += sResSE;

            return sRespuesta;
        }

        //Servicio GetEntity ByString
        public string ServicioGetEntityByString(String In_XML)
        {
            string sRespuesta = "";

            CapaSOABA.EntityManagerSOASoapClient ObjSaveEntity = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
            string sResSE = ObjSaveEntity.getEntitiesAsString(In_XML);

            sRespuesta += sResSE;

            return sRespuesta;
        }

        //PERFORM ACTIVITY CON CONSTRUCCION DE XML...
        public string IniciarPerformActivity(string In_Domain, string In_UserName, Int32 In_IdCase, Int32 In_IdTask)
        {
            string XML = "";
            XML += "<BizAgiWSParam>";
            XML += "<domain>" + In_Domain + "</domain>";
            XML += "<userName>" + In_UserName + "</userName>";
            XML += "<ActivityData>";
            XML += "<idCase>" + In_IdCase + "</idCase>";
            XML += "<taskId>" + In_IdTask + "</taskId>";
            XML += "</ActivityData>";
            XML += "</BizAgiWSParam>";

            return this.ServicioPerformActivity(XML);
        }

        public string IniciarPerformActivity(string In_Domain, string In_UserName, Int32 In_IdCase, Int32 In_IdTask, string In_XMLDATA)
        {
            string XML = "";
            XML += "<BizAgiWSParam>";
            XML += "<domain>" + In_Domain + "</domain>";
            XML += "<userName>" + In_UserName + "</userName>";
            XML += "<ActivityData>";
            XML += "<idCase>" + In_IdCase + "</idCase>";
            XML += "<taskId>" + In_IdTask + "</taskId>";
            XML += "</ActivityData>";
            XML += "<Entities>";
            XML += In_XMLDATA;
            XML += "</Entities>";
            XML += "</BizAgiWSParam>";

            return this.ServicioPerformActivity(XML);
        }

        //GETENTITIES
        public string ServicioGetEntity(string In_XML)
        {
            try
            {
                CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                                
                return objCapaSOA.getEntitiesAsString(In_XML);

                //return this.CapturaRespuestaBA(respuesta);
            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message; 
            }
        }
        public string ServicioGetEntitybySCH(string In_XML, string In_SCH)
        {
            try
            {
                CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                return objCapaSOA.getEntitiesUsingSchemaAsString(In_XML, In_SCH);
            }
            catch (Exception e1)
            {
                return "Error CapaSOABizAgi: " + e1.Message;
            }
        }

        //Servicio Respuesta BA
        public string CapturaRespuestaBA(string In_ResXML)
        {
            string sRespuesta = "";

            xdoc.LoadXml(In_ResXML);

            XmlNodeList NodoRC01 = xdoc.SelectNodes("/process/processError");

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
                XmlNodeList NodoRC02 = xdoc.SelectNodes("/processes/process/processError");

                if (NodoRC02.Count > 0)
                {
                    foreach (XmlNode XN in NodoRC02)
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
                    XmlNodeList NodoRC03 = xdoc.SelectNodes("/Entities/Error/ErrorMessage");

                    if (NodoRC03.Count > 0)
                    {
                        foreach (XmlNode XN in NodoRC03)
                        {
                            sRespuesta += XN.InnerText;
                        }
                    }
                    else
                    {
                        sRespuesta += "EJECUCION CORRECTA...";
                    }
                }
            }

            sRespuesta = sRespuesta.Replace("\n", "");
            if (sRespuesta == "")
                sRespuesta = "EJECUCION CORRECTA...";

            return sRespuesta;
        }

        //Convertir SetEvent en PerformActivity
        public string ConvertirSetEventPerform(string In_XMLSet, int In_IdCase, int In_IdTask)
        {
            XmlDocument XDoc = new XmlDocument();
            XDoc.LoadXml(In_XMLSet);

            XmlNode Nodo = XDoc.SelectSingleNode("/BizAgiWSParam/Events/Event/Entities");

            string A = Nodo.InnerXml.ToString();

            A = A.Replace("<IdM_RC01Reconocimiento>", "<IdM_RC01Reconocimiento><BSiguiente>1</BSiguiente>");
            
            return this.IniciarPerformActivity("Domain", "admon", In_IdCase, In_IdTask,A);
        }
        
        //Consultar Informacion de Usuario con el USERNAME..
        private void Get_UserIdUsername(string In_UserName)
        {
            string sXML;
            string sSHC;

            sXML = "<BizAgiWSParam><EntityData><EntityName>WFUSER</EntityName><Filters><![CDATA[userName = " + In_UserName + "]]></Filters></EntityData></BizAgiWSParam>";
            sSHC = "";


            this.ServicioGetEntitybySCH(sXML,sSHC);
        }

        //Consulta Info caso general del caso
        public string Get_InfoCaseBizAgiByRadBasic(string In_Rad)
        {

            string sRes = "";
            string sXML = "<BizAgiWSParam><radNumber>" + In_Rad + "</radNumber></BizAgiWSParam>";
            
            sRes = this.ServicioGetCaseAsString(sXML);

            return this.CapturaRespuestaBA(sRes);

        }

        //Servicio GETCASEDATASCHEMA
        public string CreateCase (string In_XML)
        {
            string sRespuesta = "";
            string sRespuestaValores = "";

            CapaSOABAWF.WorkflowEngineSOASoapClient objPerformAct = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
            sRespuesta = objPerformAct.createCasesAsString(In_XML);
            sRespuestaValores = sRespuesta;
            if (this.CapturaRespuestaBA(sRespuesta) == "EJECUCION CORRECTA...")
            {
                xdoc.LoadXml(sRespuesta);

                XmlNodeList NodoRC01 = xdoc.SelectNodes("/processes/process");
                sRespuestaValores = "";
                if (NodoRC01.Count > 0)
                {
                    foreach (XmlNode XN in NodoRC01)
                    {
                        if (XN["processId"] != null)
                        {
                            sRespuestaValores += "CaseId: " + XN["processId"].InnerText;
                        }
                        if (XN["processRadNumber"] != null)
                        {
                            sRespuestaValores += " | RadNumber: " + XN["processRadNumber"].InnerText;
                        }

                    }
                }
            }


            return sRespuestaValores;
        }
       #endregion

    }
}
