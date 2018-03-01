using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Colpensiones2GJ.Model_New;


namespace Colpensiones2GJ
{
    public class Reconocimiento
    {

        #region Atributos

        //Datos BizAgi...
        public string RadNumber;
        public Int32 IdCase;
        public Int32 IdCaseMR;
        public string EtapaActividad;

        public csWFCASE WFC;

        public Boolean RequiereVerificacion;

        //Informacion de Sutramite
        public string SubTramite;
        public string CodSubTramite;
        public Int16 IdMunicipio;
        public String SucursalBancaria;
        public String CodSucursalBancaria;
        public Int16 IdSucBancaria;
        public string MunicipioResidencia;
        public string DepartamentoResidencia;
        public string CodigoDaneResidencia;
        public string BTiemposPublicos;
        public string BTiemposPrivados;
        public string BRegimenEspecial;
        
        //Data Tecnica
        public string XMLEnvio;
        public string XMLResBA;
        public string CodError;
        public string DesError;

        //Informacion de RC01_Reconocimiento
        public Int32 IdRC01Reco;

        //Informacion de IdM_DatosReconocimientoA
        public Int32 IdMDtsRecA;
        public P_Decision IdP_Decision;

  
        //Otras Clases
        public TramiteReconocimiento TramiteReco;
        public Tramite MTramite;
        public CasoBizAgi DatosBizAgi;
        public List<PersonasNotificar> lstPN { set; get; }
        public List<PersonasNotificar> lstPNBA { set; get; }

        #endregion

        #region Constructores
        //Constructor....
        public Reconocimiento(string In_rad, Int32 In_idcase)
        {
            this.IdCase = In_idcase;
            this.RadNumber = In_rad;

            Tramite ObjTramite = new Tramite();
            this.MTramite = ObjTramite;
            P_Decision ObjDecision = new P_Decision();
            this.IdP_Decision = ObjDecision;
            CasoBizAgi ObjCasoBizAgi = new CasoBizAgi();
            this.DatosBizAgi = ObjCasoBizAgi;
            this.lstPN = new List<PersonasNotificar>();
            this.lstPNBA = new List<PersonasNotificar>();
            this.WFC = new csWFCASE();
        }

        //Constructor....
        public Reconocimiento(string In_rad, Int32 In_idcase, Int32 In_idCaseMR)
        {
            this.IdCase = In_idcase;
            this.RadNumber = In_rad;
            this.IdCaseMR = In_idCaseMR;

            Tramite ObjTramite = new Tramite();
            this.MTramite = ObjTramite;
            P_Decision ObjDecision = new P_Decision();
            this.IdP_Decision = ObjDecision;
        }

        //Constructor....
        public Reconocimiento(string In_rad, Int32 In_idcase, Int32 In_idCaseMR, Int32 In_IdCaseTR)
        {
            this.RadNumber = In_rad;
            this.IdCase = In_idcase;
            this.IdCaseMR = In_idCaseMR;

            TramiteReconocimiento ObjTR = new TramiteReconocimiento(this.RadNumber, In_IdCaseTR);
            this.TramiteReco = ObjTR;
            P_Decision ObjDecision = new P_Decision();
            this.IdP_Decision = ObjDecision;
            
        }

        #endregion

        #region Get

        public String GetREspuestaFull()
        {
            return "Respuesta: " + this.DesError.ToString() + "\n" + "XML_IN: " + this.XMLEnvio + "\n" + "XML_OUT: " + this.XMLResBA;
        }

        #endregion

        #region NewOperaciones

        public void Get_InfoRecByQueryForm()
        {
            csQuerySOA QF = new csQuerySOA("admon", "domain");
            QF.AddInternal("RADNUMBER", this.RadNumber);
            QF.AddInternal("IDWFCLASS", "7");
            QF.RunQuery();

            this.CodError = QF.Get_ErrorCode();
            this.DesError = QF.Get_AnswerANDErrorMesaje();
            this.XMLResBA = QF.Get_OutXML();

            if (this.CodError != "OK")
            {
                this.WFC.idCase = 0;
                this.WFC.radNumber = "NE";
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(this.XMLResBA);
                XmlNode child = doc.SelectSingleNode("/BizAgiWSResponse/Results/Tables");
                if (child != null)
                {
                    foreach (XmlNode n in child.ChildNodes)
                    {
                        if (n.Name == "TaskTable" && n.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode n1 in n.ChildNodes)
                            {
                                if (n1.Name == "Rows" && n1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode n2 in n1.ChildNodes)
                                    {
                                        if (n2.Name == "Row" && n2.ChildNodes.Count > 0)
                                        {
                                            foreach (XmlNode n3 in n2.ChildNodes)
                                            {
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "RADNUMBER")
                                                    this.WFC.radNumber = n3.InnerText.ToString();
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "IDCASE")
                                                {
                                                    if (this.IdCase != Convert.ToInt32(n3.InnerText.ToString()))
                                                        this.WFC.idCase = -1;
                                                    else
                                                        this.WFC.idCase = Convert.ToInt32(n3.InnerText.ToString());
                                                }
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "WFCLSDISPLAYNAME")
                                                    this.WFC.wfclsdisplayname = n3.InnerText.ToString();
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "IDWFCLASS")
                                                    this.WFC.idwfclass = Convert.ToInt16(n3.InnerText.ToString());
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "IDCASESTATE")
                                                    this.WFC.idcasestate = Convert.ToInt16(n3.InnerText.ToString());
                                                if (n3.Attributes.GetNamedItem("Name").InnerText.ToString() == "CASECLOSED")
                                                {
                                                    if (n3.InnerText.ToString() == "1")
                                                        this.WFC.caseclosed = true;
                                                    else
                                                        this.WFC.caseclosed = false;
                                                }
                                            }
                                        }
                                    } 
                                }
                            }
                        }
                    }
                }
            }

        }

              
        #endregion

        #region Operaciones


        public void Get_InformacionReconocimiento()
        {
            string XSD = this.Get_XSD_InformacionGeneralReconocimiento();

            CapaSOABizAgi ObjCapaSOABA = new CapaSOABizAgi();
            string ResCapaSOA = ObjCapaSOABA.ServicioGetCaseDataSchema(this.IdCase, XSD);

            //Consulta Informacion del Tramite.
            XmlDocument XDocReconocimiento = new XmlDocument();
            XDocReconocimiento.LoadXml(ResCapaSOA);

            XmlNodeList NodoReconocimiento = XDocReconocimiento.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento");

            if (NodoReconocimiento.Count > 0)
            {
                foreach (XmlNode tmpXML in NodoReconocimiento)
                {
                    XmlNodeList ChildsCatReco = tmpXML.ChildNodes;

                    foreach (XmlNode tmpChieldCatReco in ChildsCatReco)
                    {
                        string Atributo = tmpChieldCatReco.Name;

                        switch (Atributo)
                        {
                            case "M_Tramite":
                                this.MTramite.IdM_Tramite = Convert.ToInt32(tmpChieldCatReco.Attributes.GetNamedItem("key").InnerText);
                                this.MTramite.GetInfoTramite(tmpChieldCatReco.ChildNodes);
                                break;

                            case "IdM_RC01Reconocimiento":
                                this.IdRC01Reco = Convert.ToInt32(tmpChieldCatReco.Attributes.GetNamedItem("key").InnerText);
                                this.Get_RC01Reconocimiento(tmpChieldCatReco.ChildNodes);
                                break;
                        }
                    }
                }
            }
        }

        //Buscar idworkitem por ombre de actividad
        public Int64 BuscarIWorkItemXActividad(string In_Actividad)
        {
            return this.DatosBizAgi.BuscarIdWorkItemPorNameTask(In_Actividad);
        }

        //Buscar Actividad de Reconocimiento Activa
        public string SolucionActividadActualEnData()
        {

            //162	CasoAsignadoAlLiquidador	Caso asignado al liquidador
            //876	Task2	                    Esperando Accion Liquidador
            //174	Firmado	                    Firmado
            //4329	tskLiquidacionAutomatico	Liquidacion Automatico
            //171	EnDecision	                En decisión 
            //172	EnRevision	                En revisión
            //173	ParaFirma	                Para Firma
            //183	ReportadoANomina	        Reportado a nómina
            //892	Task4	                    Devolver Para Decision
            //994	Task9	                    Devolucion por Documentos 
            //1075	Task11	                    Devuelto Investigacion Adminitrativa
            //1076	Task12	                    Devuelto Consulta Cuota Parte
            //4899	VerificacionDecision	    Verificación de Decision

            //897	Task5	                    Decision Tomada
            //4467  RCEventHistoriaLaboral


            //ACTIVIDAD NO IDENTIFICADA...

            string Respuesta = "";

            
            if (this.DatosBizAgi.BuscarNameTask("EnviarInformacionAlLiquida") == true)
            {
                this.EtapaActividad = "EnviarInformacionAlLiquida";
                Respuesta += "EnviarInformacionAlLiquida";
            }
            else if (this.DatosBizAgi.BuscarNameTask("ActualizacionBDMisionales") == true)
            {
                this.EtapaActividad = "ActualizacionBDMisionales";
                Respuesta += "ActualizacionBDMisionales";
            }
            else if (this.DatosBizAgi.BuscarNameTask("RCEventHistoriaLaboral") == true)
            {
                this.EtapaActividad = "RCEventHistoriaLaboral";
                Respuesta += "RCEventHistoriaLaboral";
            }
            else if (this.DatosBizAgi.BuscarNameTask("tskLiquidacionAutomatico") == true)
            {
                this.EtapaActividad = "tskLiquidacionAutomatico";
                Respuesta += "tskLiquidacionAutomatico";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task5") == true)
            {
                this.EtapaActividad = "DecisionTomada";
                Respuesta += "DecisionTomada";
            }
            else if (this.DatosBizAgi.BuscarNameTask("CasoAsignadoAlLiquidador") == true)
            {
                this.EtapaActividad = "CasoAsignadoAlLiquidador";
                Respuesta += "CasoAsignadoAlLiquidador";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task2") == true)
            {
                this.EtapaActividad = "Task2";
                Respuesta += "Task2";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Firmado") == true)
            {
                this.EtapaActividad = "Firmado";
                Respuesta += "Firmado";
            }
            else if (this.DatosBizAgi.BuscarNameTask("EnDecision") == true)
            {
                this.EtapaActividad = "EnDecision";
                Respuesta += "EnDecision";
            }
            else if (this.DatosBizAgi.BuscarNameTask("EnRevision") == true)
            {
                this.EtapaActividad = "EnRevision";
                Respuesta += "EnRevision";
            }
            else if (this.DatosBizAgi.BuscarNameTask("ParaFirma") == true)
            {
                this.EtapaActividad = "ParaFirma";
                Respuesta += "ParaFirma";
            }
            else if (this.DatosBizAgi.BuscarNameTask("ReportadoANomina") == true)
            {
                this.EtapaActividad = "ReportadoANomina";
                Respuesta += "ReportadoANomina";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task4") == true)
            {
                this.EtapaActividad = "Task4";
                Respuesta += "Task4";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task9") == true)
            {
                this.EtapaActividad = "Task9";
                Respuesta += "Task9";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task11") == true)
            {
                this.EtapaActividad = "Task11";
                Respuesta += "Task11";
            }
            else if (this.DatosBizAgi.BuscarNameTask("Task12") == true)
            {
                this.EtapaActividad = "Task12";
                Respuesta += "Task12";
            }
            else if (this.DatosBizAgi.BuscarNameTask("VerificacionDecision") == true)
            {
                this.EtapaActividad = "VerificacionDecision";
                Respuesta += "VerificacionDecision";
            }
            else
            {
                Respuesta += "ACTIVIDAD NO IDENTIFICADA...";
            }

            return Respuesta;
        }
        
        //Carga Informacion de BizAgi.
        public void Reconocimiento_CargarDatosBizAgi()
        {
            string XML = "";
            XML += "<BizAgiWSParam>";
            XML += "<applicationName>App</applicationName>";
            XML += "<processName>RC01_Reconocimiento</processName>";
            //XML += "<idCase>" + this.IdCase + "</idCase>";
            XML += "<radNumber>" + this.RadNumber + "</radNumber>";
            XML += "</BizAgiWSParam>";

            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string ResXML = objCapaSOA.ServicioGetCaseAsString(XML); 

            //XmlDocument xdoc = new XmlDocument();
            //xdoc.LoadXml(ResXML);

            //XmlNodeList NodoProcess = xdoc.SelectNodes("/process");

            this.DatosBizAgi.CargaXMLGetCaseAsString(ResXML);
 

        }

        //Validacion de Diferencias BizAgi vs Liquidador.....
        public string ValDifBizAgiLiq(string In_SEtapa)
        {

            //Respuestas:
            //0- No se encontro diferencia o validacion.
            //50.40 - Liquidador envia etapa 50 BizAgi esta en 40. (Se reporta a encargado colpensiones).

            //60.0  - Liquidador envia etapa 60 BizAgi esta en 0. (Validar error y revisar detalle de caso).
            string sRespuesta = "0";

            //Validar etapa enviada por liquidador contra actividad bizagi.
            //Etapa 50 -> En Revision
            if (In_SEtapa == "50")
            {
                //Actividad BizAgi Investigacion Administrativa -> Etapa 40.
                if (this.EtapaActividad == "Task11")
                {
                    //Reportar a encargado de colpensiones para que tomen decision.
                    sRespuesta = "50.40 - Liquidador intenta enviar etapa 50 BizAgi esta en 40. Caso de Investigacion Administrativa Pendiente..";
                }
                //Actividad BizAgi Firmado -> Etapa 80.
                if (this.EtapaActividad == "Firmado")
                {
                    //La instruccion enviada por el liquidador es en Revision y.
                    sRespuesta = "50.40 - Liquidador intenta enviar etapa 50 BizAgi esta en 40. Caso de Investigacion Administrativa Pendiente..";
                }
            }
            //Etapa 60 -> Para Firma
            if (In_SEtapa == "60")
            {
                //Actividad BizAgi Esperando Accion Liquidador -> Etapa 0.
                if (this.EtapaActividad == "Task2")
                {
                    //La instruccion enviada por el liquidador debe funcionar, se debe revisar el tema.
                    sRespuesta = "60.0 - Liquidador intenta enviar etapa 60 BizAgi esta en 0. Revisar Detalle de Caso.";
                }
                //Actividad BizAgi Firmado -> Etapa 80.
                if (this.EtapaActividad == "Firmado")
                {

                }
            }

            return sRespuesta;
        }

        //Actualiza el caso para que requiere de verificacion....
        public string UpdateSolicitarVerificacion()
        {
            //XML de SaveEntity con los datos de Verificacion...
            string XMLse = "<BizAgiWSParam><Entities idCase=\"" + this.IdCase.ToString() + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BRequiereVerificacion>1</BRequiereVerificacion></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";

            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string Res = objCapaSOA.ServicioSaveEntity(XMLse);

            return Res;
        }

        //Consulta la actividad actual en bizagi....
        public void GetActividadEtapaActual()
        {
            //XSD de consulta etapa actual.
            string sXSD = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"App\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SIndicadorAuto\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SActividadActual\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SActividadActual\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioRevisor\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioSustanciador\" type=\"xs:string\" /></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence></xs:complexType></xs:element></xs:schema>";

            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string Res = objCapaSOA.ServicioGetCaseDataSchema(this.IdCase, sXSD);

            XML objXML = new XML();
            string ResNodo = objXML.GetNodoXML("/BizAgiWSResponse/App/M_cat_Reconocimiento/IdM_RC01Reconocimiento",
                                "SActividadActual",
                                Res);

            this.EtapaActividad = ResNodo;
        }

        //Instancia la Actividad de Esperar Accion Liquidador...
        public string UpdateEtapa(string In_Etapa)
        {
            string sRes = "";
            string sXML = "";
            int idTask = 0;

            //Valida si es posible mover el caso a la actividad indicada.
            //ACTIVIDADES BIZAGI
            //Etapa 0   - Task2 - Esperando Accion Liquidador.
            //Etapa 10  - CasoAsignadoAlLiquidador - Caso Asignado Liquidador.
            //Etapa 20  - EnDecision - En Decision.
            //Etapa 30  - Task9 - Devolucion Por Documentos.
            //Etapa 40  - Task11 - Devolucion para Investigacion Administrativa.
            //Etapa 50  - EnRevision - En Revision.
            //Etapa 60  - ParaFirma - Para Firma.
            //Etapa 70  - Task12 - Devuelto para Cuota a Parte.
            //Etapa 80  - Firmado - Firmado.
            //Etapa 90  - ReportadoANomina - Reportado a Nomina.
            //Etapa 100 - Task4 - Devolver para Decision.
            //Etapa 110 - tskLiquidacionAutomatico - Liquidacion Automatica.

            //Etapa 0   - Task2 - Esperando Accion Liquidador.
            if (this.EtapaActividad == "Task2")
            {
                idTask = 876;
                if (In_Etapa == "0")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 0...";
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
            }
            //Etapa 10  - CasoAsignadoAlLiquidador - Caso Asignado Liquidador.
            else if (this.EtapaActividad == "CasoAsignadoAlLiquidador")
            {
                idTask = 162;
                if (In_Etapa == "10")
                {
                    sRes = "Caso YA esta en Etapa" + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 10..";
                    sXML = "<BizAgiWSParam><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>1</Iid><IdP_TipoPrestaciones businessKey=\"SCodificado='00'\"/><IdP_Accion businessKey=\"SEtapa='10'\"/><SFechaString>20120712</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 10 Avanzado Automaticamente.</SObservaciones><SError>0</SError></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 20..
            else if (this.EtapaActividad == "EnDecision")
            {
                idTask = 171;
                if (In_Etapa == "20")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 20..";
                    sXML = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>1</Iid><IdP_Accion businessKey=\"SEtapa='20'\"/><SFechaString>20120708</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 20 Avanzado Automaticamente.</SObservaciones></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 30  - Task9 - Devolucion Por Documentos. NO PROBADA
            else if (this.EtapaActividad == "Task9")
            {
                idTask = 994;
                if (In_Etapa == "30")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 30... Sacar de Devolucion por Documentos.";
                    sXML = "";
                    this.CodError = "1";
                    this.DesError = "REV";
                }
            }
            //Etapa 40  - Task11 - Devolucion para Investigacion Administrativa. NO PROBADA
            else if (this.EtapaActividad == "Task11")
            {
                idTask = 994;
                if (In_Etapa == "40")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                }
                else
                {
                    sRes = "Caso esta en Etapa 40.. Informar para gestionar la Inv. Adminitrativa.";
                    sXML = "";
                    this.CodError = "1";
                    this.DesError = "REV";
                }
            }
            //Etapa 50..
            else if (this.EtapaActividad == "EnRevision")
            {
                idTask = 172;
                if (In_Etapa == "50")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 50..";
                    sXML = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>1</Iid><IdP_Accion businessKey=\"SEtapa='50'\"/><SFechaString>20120713</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 50 Avanzado Automaticamente.</SObservaciones></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 60..
            else if (this.EtapaActividad == "ParaFirma")
            {
                idTask = 173;
                if (In_Etapa == "60")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 60..";
                    sXML = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>123</Iid><IdP_Accion businessKey=\"SEtapa='60'\"/><SFechaString>20120808</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 60 Avanzado Automaticamente.</SObservaciones></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 70  - Task12 - Devuelto para Cuota a Parte. NO PROBADO
            else if (this.EtapaActividad == "Task12")
            {
                idTask = 172;
                if (In_Etapa == "70")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 70..";
                    sXML = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>123</Iid><IdP_Accion businessKey=\"SEtapa='60'\"/><SFechaString>20120808</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 60 Avanzado Automaticamente.</SObservaciones></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 80  - Firmado - Firmado. NO PROBADO
            else if (this.EtapaActividad == "Firmado")
            {
                idTask = 174;
                if (In_Etapa == "80")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 80.. Ya firmado No debereia tener problema..";
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
            }
            //Etapa 90  - ReportadoANomina - Reportado a Nomina. NO PROBADO
            else if (this.EtapaActividad == "ReportadoANomina")
            {
                idTask = 172;
                if (In_Etapa == "90")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 90.. Etapa no tenida en cuenta.";
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
            }
            //Etapa 100 - Task4 - Devolver para Decision. NO PROBADO
            else if (this.EtapaActividad == "Task4")
            {
                idTask = 892;
                if (In_Etapa == "100")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 100..";
                    sXML = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Events><Event><EventData><idCase>" + this.IdCase + "</idCase><eventName>RegistroDeActividades</eventName></EventData><Entities><App><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosActividad><Iid>12</Iid><IdP_Accion businessKey=\"SEtapa='Etapa 100'\"/><SFechaString>20120706</SFechaString><IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/><SDominio>domain</SDominio><SResponsable>admon</SResponsable><SObservaciones>Observaciones Etapa 60 Avanzado Automaticamente.</SObservaciones></IdM_DatosActividad></IdM_RC01Reconocimiento></M_cat_Reconocimiento></App></Entities></Event></Events></BizAgiWSParam>";
                }
            }
            //Etapa 110 - tskLiquidacionAutomatico - Liquidacion Automatica.
            else if (this.EtapaActividad == "tskLiquidacionAutomatico")
            {
                idTask = 4329;
                if (In_Etapa == "110")
                {
                    sRes = "Caso YA esta en Etapa " + In_Etapa;
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    sRes = "Caso esta en Etapa 110.. Perfecto Listo para Procesar..";
                    sXML = "";
                    this.CodError = "0";
                    this.DesError = "OK";
                }
            }
            else
            {
                sRes = "CASO EN ACTIVIDAD NO VALIDA...";
                sXML = "";
                this.CodError = "1";
                this.DesError = "N/A";
            }

            if (sXML != "")
            {
                CapaSOABizAgi objMoverCaso = new CapaSOABizAgi();
                string sResSetEvent = objMoverCaso.ServicioSetEventByXML(sXML);

                if (sResSetEvent == "EJECUCION CORRECTA...")
                {
                    this.CodError = "0";
                    this.DesError = "OK";
                }
                else
                {
                    if (sResSetEvent.Contains("(id:168)") && sResSetEvent.Contains("no está disponible para el proceso"))
                    {
                        objMoverCaso.ConvertirSetEventPerform(sXML, this.IdCase, idTask);
                    }
                    else
                    {
                        this.CodError = "1";
                        this.DesError = "Error en ejecucion de SetEvent";
                    }
                }
                sRes += sResSetEvent;
            }

            return sRes;
        }

        //Consultar Banco para el Caso.....
        public void UpdateSucursalBancaria()
        {
            this.GetInformacionCiudadano();
            this.Get_IdSucursalBancaria();

            if (this.IdSucBancaria != 0)
            {
                string sSE = "<BizAgiWSParam><Entities idCase=\"" + this.IdCase + "\"><M_cat_Reconocimiento><M_Tramite><IdM_VariablesProcesoTram><IdP_SucursalBancaria>" + this.IdSucBancaria + "</IdP_SucursalBancaria></IdM_VariablesProcesoTram></M_Tramite></M_cat_Reconocimiento></Entities></BizAgiWSParam>";

                CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
                string sRes = objSaveEntity.ServicioSaveEntity(sSE);
            }
        }

        //Consultar Banco para el Caso.....
        public void UpdateSucursalBancariaCompleja(Int16 In_IdMunicipio)
        {
            //Guarda IdSucursalBancaria Temporalmente
            Int16 IdMunicipioTemporal = this.IdMunicipio;
            this.IdMunicipio = In_IdMunicipio;
            
            
            this.Get_IdSucursalBancaria();

            if (this.IdSucBancaria != 0)
            {
                string sSE = "<BizAgiWSParam><Entities idCase=\"" + this.IdCase + "\"><M_cat_Reconocimiento><M_Tramite><IdM_VariablesProcesoTram><IdP_SucursalBancaria>" + this.IdSucBancaria + "</IdP_SucursalBancaria></IdM_VariablesProcesoTram></M_Tramite></M_cat_Reconocimiento></Entities></BizAgiWSParam>";

                CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
                string sRes = objSaveEntity.ServicioSaveEntity(sSE);
            }

            this.IdMunicipio = IdMunicipioTemporal;
        }

        //Buscar Banco de Residencia....
        public void GetInformacionCiudadano()
        {
            string sXSD = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> <xs:element name=\"App\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_Ciudadano\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_MunicipioResidencia\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SMunicipio\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigoActualDANE\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"Deparatamento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:schema>";

            CapaSOABizAgi objGetEntity = new CapaSOABizAgi();
            string Res = objGetEntity.ServicioGetCaseDataSchema(this.IdCase, sXSD);

            XmlDocument xdocMun = new XmlDocument();
            xdocMun.LoadXml(Res);

            XmlNodeList NodoMun = xdocMun.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento/M_Tramite/IdM_Ciudadano");

            if (NodoMun.Count > 0)
            {
                foreach (XmlNode XN in NodoMun)
                {
                    if (XN["IdP_MunicipioResidencia"] != null)
                    {
                        this.IdMunicipio = Convert.ToInt16(XN["IdP_MunicipioResidencia"].Attributes.GetNamedItem("key").InnerText);

                        XmlNodeList NHN1 = XN.ChildNodes;

                        foreach (XmlNode XNN1 in NHN1)
                        {
                            XmlNodeList NHN2 = XNN1.ChildNodes;

                            foreach (XmlNode XNN2 in NHN2)
                            {
                                if (XNN2.Name == "SMunicipio")
                                    //if (XNN2["SMunicipio"] != null)
                                    this.MunicipioResidencia = XNN2.InnerText;

                                if (XNN2.Name == "SCodigoActualDANE")
                                    //if (XNN2["SCodigoActualDANE"] != null)
                                    this.CodigoDaneResidencia = XNN2.InnerText;

                                if (XNN2.Name == "Deparatamento")
                                {

                                    XmlNodeList NHN3 = XNN2.ChildNodes;

                                    foreach (XmlNode XNN3 in NHN3)
                                    {
                                        if (XNN3.Name == "SNombre")
                                            //if (XNN3["SNombre"] != null)
                                            this.DepartamentoResidencia = XNN3.InnerText;
                                    }

                                }
                            }
                            //}
                        }
                    }
                }
            }

        }

        //Sucursal Bancaria....
        public void Get_IdSucursalBancaria()
        {

            Int16 IdSuc = 0;
            int iPrio = 0;

            //CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");

            string tmpEntities = "<BizAgiWSParam><EntityData><EntityName>P_SucursalBancaria</EntityName><Filters><![CDATA[IdP_Ciudad = " + this.IdMunicipio + " AND BAplicaPagRecAuto = 1]]></Filters></EntityData></BizAgiWSParam>";

            CapaSOABizAgi objEntCapaSOA = new CapaSOABizAgi();

            string ResP = objEntCapaSOA.ServicioGetEntity(tmpEntities);

            //string ResP = objCapaSOA.getEntitiesAsString(tmpEntities);

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
                        IdSuc = 0;
                    }
                }
            }
            this.IdSucBancaria = IdSuc;
        }

        //Consulta Informacion de Envio al Liquidador....
        public void Get_InfoLiquidador()
        {
            string sXSDEnviLiq = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> <xs:element name=\"App\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesProcesoTram\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SucursalBancaria\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Ciudad\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SMunicipio\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"Deparatamento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Banco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_Ciudadano\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNumeroDocumento\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoDocumento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposRegimenEspecial\" type=\"xs:boolean\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPrivados\" type=\"xs:boolean\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Recurso\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPublicos\" type=\"xs:boolean\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SIndicadorAuto\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SFechaSolicitud\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioRevisor\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SActividadActual\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdTask\" type=\"xs:integer\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BRequiereVerificacion\" type=\"xs:boolean\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_EPS\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNit\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SEps\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_AccionLiquidador\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SDescripcion\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosReconocimientoA\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoLiquidacion\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SDescripcion\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioSustanciador\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SObservaciones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"RC01Reconocimiento_Benef\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_RC01_BenefReconocimie\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoDocumento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SucursalBanco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Ciudad\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SMunicipio\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"Deparatamento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Banco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNumeroDocumento\" type=\"xs:string\"/> </xs:sequence> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosGenerales\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SRadNumber\" type=\"xs:string\"/> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdCase\" type=\"xs:integer\"/> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\"/> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:schema>";

            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string sRes = objCapaSOA.ServicioGetCaseDataSchema(Convert.ToInt32(this.IdCase), sXSDEnviLiq);

            XmlDocument xdocMun = new XmlDocument();

            xdocMun.LoadXml(sRes);

            XmlNodeList NodoCatRec = xdocMun.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento");

            if (NodoCatRec.Count > 0)
            {
                foreach (XmlNode XN0 in NodoCatRec)
                {
                    XmlNodeList ChildCatRec = XN0.ChildNodes;
                    foreach (XmlNode XN1 in ChildCatRec)
                    {
                        if (XN1.Name == "M_Tramite")
                        {
                            XmlNodeList ChildTram = XN1.ChildNodes;
                            foreach (XmlNode XN10 in ChildTram)
                            {
                                if (XN10.Name == "IdP_SubtipoTramite")
                                {
                                    XmlNodeList ChildSubTra = XN10.ChildNodes;
                                    foreach (XmlNode XN101 in ChildSubTra)
                                    {
                                        if (XN101.Name == "SNombre")
                                            this.SubTramite = XN101.InnerText;
                                        if (XN101.Name == "SCodColpServices")
                                            this.CodSubTramite = XN101.InnerText;
                                    }
                                }
                                if (XN10.Name == "IdM_VariablesProcesoTram")
                                {
                                    XmlNodeList ChildVarRec = XN10.ChildNodes;
                                    foreach (XmlNode XN102 in ChildVarRec)
                                    {
                                        if (XN102.Name == "SNombre")
                                            this.SucursalBancaria = XN102.InnerText;
                                        if (XN102.Name == "SCodColpensiones")
                                            this.CodSucursalBancaria = XN102.InnerText;
                                    }
                                }
                                if (XN10.Name == "IdM_Ciudadano")
                                {
                                    XmlNodeList ChildCiu = XN10.ChildNodes;
                                    foreach (XmlNode XN103 in ChildCiu)
                                    {
                                        //if (XN103.Name == "SNombre")
                                        //    this.SucursalBancaria = XN102.InnerText;
                                        //if (XN103.Name == "SCodColpensiones")
                                        //     this.CodSucursalBancaria = XN102.InnerText;
                                    }
                                }
                                if (XN10.Name == "IdM_VariablesTramiteReco")
                                {
                                    XmlNodeList ChildVarTraRec = XN10.ChildNodes;
                                    foreach (XmlNode XN104 in ChildVarTraRec)
                                    {
                                        if (XN104.Name == "BTiemposRegimenEspecial")
                                            this.BRegimenEspecial = XN104.InnerText;
                                        if (XN104.Name == "BTiemposPrivados")
                                            this.BTiemposPrivados = XN104.InnerText;
                                        if (XN104.Name == "BTiemposPublicos")
                                            this.BTiemposPublicos = XN104.InnerText;
                                    }
                                }
                            }
                        }
                        if (XN1.Name == "IdM_RC01Reconocimiento")
                        {
                            XmlNodeList ChildRC01Reco = XN1.ChildNodes;
                            foreach (XmlNode XN11 in ChildRC01Reco)
                            {
                                if (XN11.Name == "SActividadActual")
                                    this.EtapaActividad = XN11.InnerText;
                                if (XN11.Name == "BRequiereVerificacion")
                                    this.RequiereVerificacion = Convert.ToBoolean(Convert.ToByte(XN11.InnerText));
                            }
                        }
                    }
                }


            }
        }

        //Consulta informacion del Tramite Reconocimiento en MR.
        public void Get_InfoReconocimientoMR()
        {
            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string sRes = objCapaSOA.ServicioGetCaseDataSchema(Convert.ToInt32(this.IdCaseMR), this.Get_XSD_InfoGeneralMR());
                      

            XmlDocument XDocTramiteMR = new XmlDocument();
            XDocTramiteMR.LoadXml(sRes);

            XmlNodeList NodoTramiteMR = XDocTramiteMR.SelectNodes("/BizAgiWSResponse/App/M_cat_ServicioCiudadano");

            if (NodoTramiteMR.Count > 0)
            {
                foreach (XmlNode tmpXML in NodoTramiteMR)
                {
                    XmlNodeList ChildsCatReco = tmpXML.ChildNodes;

                    foreach (XmlNode tmpChieldCatReco in ChildsCatReco)
                    {
                        string Atributo = tmpChieldCatReco.Name;

                        switch (Atributo)
                        {
                            case "M_Tramite":
                                this.MTramite.IdM_Tramite = Convert.ToInt32(tmpChieldCatReco.Attributes.GetNamedItem("key").InnerText);
                                this.MTramite.GetInfoTramite(tmpChieldCatReco.ChildNodes);
                                break;
                        }
                    }
                }
            }
        }

        //Consulta Informacion de Tramite Reconocimiento.
        public void Get_InfoReconocimientoTR()
        {
            //Consulta Informacion...
            this.TramiteReco.Get_InfoGeneralTR();
        }

        //Actualiza caso para que se realize verificacion...
        public void Upd_RequiereVerificacion()
        {
            string sSE = "<BizAgiWSParam><Entities idCase=\"" + this.IdCase + "\"><M_cat_Reconocimiento> <IdM_RC01Reconocimiento> <BRequiereVerificacion>1</BRequiereVerificacion> </IdM_RC01Reconocimiento> </M_cat_Reconocimiento></Entities></BizAgiWSParam>";

            CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
            string sRes = objSaveEntity.ServicioSaveEntity(sSE);
        }

        //Actualiza caso para que NO realize verificacion...
        public void Upd_NORequiereVerificacion()
        {
            string sSE = "<BizAgiWSParam><Entities idCase=\"" + this.IdCase + "\"><M_cat_Reconocimiento> <IdM_RC01Reconocimiento> <BRequiereVerificacion>0</BRequiereVerificacion> </IdM_RC01Reconocimiento> </M_cat_Reconocimiento></Entities></BizAgiWSParam>";

            CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
            string sRes = objSaveEntity.ServicioSaveEntity(sSE);
        }

        //SetEtapa80 Liquidador (Liquidacion Manual)
        public string Set_Etapa80()
        {
            string sSetEvent80 = "<BizAgiWSParam>";
            sSetEvent80 += "<domain>domain</domain>";
            sSetEvent80 += "<userName>admon</userName>";
            sSetEvent80 += "<Events>";
            sSetEvent80 += "<Event>";
            sSetEvent80 += "<EventData>";
            sSetEvent80 += "<idCase>" + this.IdCase + "</idCase>";
            sSetEvent80 += "<eventName>RegistroDeActividades</eventName>";
            sSetEvent80 += "</EventData>";
            sSetEvent80 += "<Entities>";
            sSetEvent80 += "<App>";
            sSetEvent80 += "<M_cat_Reconocimiento>";
            sSetEvent80 += "<IdM_RC01Reconocimiento>";
            sSetEvent80 += "<IdM_DatosActividad>";
            sSetEvent80 += "<Iid>21</Iid>";
            sSetEvent80 += "<IdP_Accion businessKey=\"SEtapa='80'\"/>";
            sSetEvent80 += "<SFechaString>20121212</SFechaString>";
            sSetEvent80 += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sSetEvent80 += "<SDominio>domain</SDominio>";
            sSetEvent80 += "<SResponsable>admon</SResponsable>";
            sSetEvent80 += "<SObservaciones>Pruebas XML Firmado</SObservaciones>";
            sSetEvent80 += "<INumeroActoAdministrativ>6543</INumeroActoAdministrativ>";
            sSetEvent80 += "<SFechaActoAdminitrativo>20121212</SFechaActoAdminitrativo>";
            sSetEvent80 += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sSetEvent80 += "<IdP_Decision businessKey=\"SCodColpensiones='1'\"/>";
            sSetEvent80 += "<SActoAdministrativo>123454321</SActoAdministrativo>";
            sSetEvent80 += "<BBonoPensional>TRUE</BBonoPensional>";
            sSetEvent80 += "<SParteResolutiva>3543</SParteResolutiva>";
            sSetEvent80 += "<RC01_DtosAct_Notificar>";
            sSetEvent80 += "<M_RC01_PersonasNotificar>";
            sSetEvent80 += "<IdP_TipoDocumento businessKey=\"SCodigo='CC'\"/>";
            sSetEvent80 += "<SNumeroDocumento>80087026</SNumeroDocumento>";
            sSetEvent80 += "<SPrimerNombre>German</SPrimerNombre>";
            sSetEvent80 += "<SSegundoNombre>Joaquin</SSegundoNombre>";
            sSetEvent80 += "<SPrimerApellido>Gomez</SPrimerApellido>";
            sSetEvent80 += "<SSegundoApellido>Jimenez</SSegundoApellido>";
            sSetEvent80 += "<SDireccion>Calle 56</SDireccion>";
            sSetEvent80 += "<STelefono>3333333</STelefono>";
            sSetEvent80 += "<BAutorizaNotificacionCor>FALSE</BAutorizaNotificacionCor>";
            sSetEvent80 += "<SCorreo/>";
            sSetEvent80 += "<SFax/>";
            sSetEvent80 += "</M_RC01_PersonasNotificar>";
            sSetEvent80 += "</RC01_DtosAct_Notificar>";
            sSetEvent80 += "</IdM_DatosActividad>";
            sSetEvent80 += "</IdM_RC01Reconocimiento>";
            sSetEvent80 += "</M_cat_Reconocimiento>";
            sSetEvent80 += "</App>";
            sSetEvent80 += "</Entities>";
            sSetEvent80 += "</Event>";
            sSetEvent80 += "</Events>";
            sSetEvent80 += "</BizAgiWSParam>";
            
            CapaSOABizAgi objMoverCaso = new CapaSOABizAgi();
            string sResSetEvent = objMoverCaso.ServicioSetEventByXML(sSetEvent80);

            if (sResSetEvent == "EJECUCION CORRECTA...")
            {
                this.CodError = "0";
                this.DesError = "OK";
            }
            else
            {
                this.CodError = "1";
                this.DesError = "Error en ejecucion de SetEvent";
            }
            return sResSetEvent;
        }

        //SetEtapa110 Liquidador (Liquidacion Automatica)
        public string Set_Etapa110(String In_Decision)
        {
            string  sSetEvent110     =       "<BizAgiWSParam>";
                    sSetEvent110    +=          "<domain>domain</domain>";
                    sSetEvent110    +=          "<userName>admon</userName>";
                    sSetEvent110    +=          "<Events>";
                    sSetEvent110    +=              "<Event>";
                    sSetEvent110    +=                  "<EventData>";
                    sSetEvent110    +=                      "<idCase>" + this.IdCase + "</idCase>";
                    sSetEvent110    +=                      "<eventName>RegistroDeActividades</eventName>";
                    sSetEvent110    +=                  "</EventData>";
                    sSetEvent110    +=                  "<Entities>";
                    sSetEvent110    +=                      "<App>";
                    sSetEvent110    +=                          "<M_cat_Reconocimiento>";
                    sSetEvent110    +=                              "<IdM_RC01Reconocimiento>";
                    sSetEvent110    +=                                  "<IdM_DatosActividad>";
                    sSetEvent110    +=                                      "<Iid>21</Iid>";
                    sSetEvent110    +=                                      "<IdP_Accion businessKey=\"SEtapa='110'\"/>";
                    sSetEvent110    +=                                      "<SFechaString>20130626</SFechaString>";
                    sSetEvent110    +=                                      "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
                    sSetEvent110    +=                                      "<SDominio>domain</SDominio>";
                    sSetEvent110    +=                                      "<SResponsable>admon</SResponsable>";
                    sSetEvent110    +=                                      "<SObservaciones>Etapa avanzada por AUTOMATICO</SObservaciones>";
                    sSetEvent110    +=                                      "<IdP_Decision businessKey=\"SCodColpensiones='" + In_Decision + "'\"/>";
                    sSetEvent110    +=                                  "</IdM_DatosActividad>";
                    sSetEvent110    +=                              "</IdM_RC01Reconocimiento>";
                    sSetEvent110    +=                          "</M_cat_Reconocimiento>";
                    sSetEvent110    +=                      "</App>";
                    sSetEvent110    +=                  "</Entities>";
                    sSetEvent110    +=              "</Event>";
                    sSetEvent110    +=          "</Events>";
                    sSetEvent110    +=         "</BizAgiWSParam>";


                    //sSetEvent110 += "<INumeroActoAdministrativ>6543</INumeroActoAdministrativ>";
                    //sSetEvent110 += "<SFechaActoAdminitrativo>20121212</SFechaActoAdminitrativo>";
                    //sSetEvent110 += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
                    //sSetEvent110 += "<SActoAdministrativo>123454321</SActoAdministrativo>";
                    //sSetEvent110 += "<BBonoPensional>TRUE</BBonoPensional>";
                    //sSetEvent110 += "<SParteResolutiva>3543</SParteResolutiva>";
                    //sSetEvent110 += "<RC01_DtosAct_Notificar>";
                    //sSetEvent110 += "<M_RC01_PersonasNotificar>";
                    //sSetEvent110 += "<IdP_TipoDocumento businessKey=\"SCodigo='CC'\"/>";
                    //sSetEvent110 += "<SNumeroDocumento>80087026</SNumeroDocumento>";
                    //sSetEvent110 += "<SPrimerNombre>German</SPrimerNombre>";
                    //sSetEvent110 += "<SSegundoNombre>Joaquin</SSegundoNombre>";
                    //sSetEvent110 += "<SPrimerApellido>Gomez</SPrimerApellido>";
                    //sSetEvent110 += "<SSegundoApellido>Jimenez</SSegundoApellido>";
                    //sSetEvent110 += "<SDireccion>Calle 56</SDireccion>";
                    //sSetEvent110 += "<STelefono>3333333</STelefono>";
                    //sSetEvent110 += "<BAutorizaNotificacionCor>FALSE</BAutorizaNotificacionCor>";
                    //sSetEvent110 += "<SCorreo/>";
                    //sSetEvent110 += "<SFax/>";
                    //sSetEvent110 += "</M_RC01_PersonasNotificar>";
                    //sSetEvent110 += "</RC01_DtosAct_Notificar>";
            
            CapaSOABizAgi objMoverCaso = new CapaSOABizAgi();
            string sResSetEvent = objMoverCaso.ServicioSetEventByXML(sSetEvent110);

            if ((sResSetEvent == "EJECUCION CORRECTA...") || (sResSetEvent == "OK") )
            {
                this.CodError = "0";
                this.DesError = "OK";
            }
            else
            {
                this.CodError = "1";
                this.DesError = sResSetEvent;
            }

            return sResSetEvent;
        }

        //Actualiza Caso Represa a Automatico
        public string Upd_AutomaticoRepresa(string In_Sucbancaria, string In_TipoLiq, string In_Instancia, string In_Recurso)
        {

            string XMLSaveEnt = "<BizAgiWSParam>";
            XMLSaveEnt += "<Entities idCase=\"" + this.IdCase + "\">";
            XMLSaveEnt += "<M_cat_Reconocimiento>";
            XMLSaveEnt += "<IdM_RC01Reconocimiento>";
            XMLSaveEnt += "<SCodErrorValidacion>N</SCodErrorValidacion>";
            XMLSaveEnt += "<IdS_UserLiquidador>146</IdS_UserLiquidador>";
            XMLSaveEnt += "<IdS_UserSupervisor>147</IdS_UserSupervisor>";
            XMLSaveEnt += "<SUsuarioRevisor>RAUTOMATICO</SUsuarioRevisor>";
            XMLSaveEnt += "<SUsuarioSustanciador>AUTOMATICO</SUsuarioSustanciador>";
            XMLSaveEnt += "<SIndicadorAuto>1</SIndicadorAuto>";
            XMLSaveEnt += "<IdP_EPS>41</IdP_EPS>";
            XMLSaveEnt += "<SErrorHistoriaLaboral>0</SErrorHistoriaLaboral>";
            XMLSaveEnt += "<IdM_DatosActividad>";
            XMLSaveEnt += "<IdP_EstadoReconocimiento>64</IdP_EstadoReconocimiento>";
            XMLSaveEnt += "<IdP_Accion>64</IdP_Accion>";
            XMLSaveEnt += "</IdM_DatosActividad>";
            XMLSaveEnt += "</IdM_RC01Reconocimiento>";
            XMLSaveEnt += "<M_Tramite>";
            XMLSaveEnt += In_Instancia;
            XMLSaveEnt += "<IdM_VariablesTramiteReco>";
            XMLSaveEnt += "<IdP_EPS>41</IdP_EPS>";
            XMLSaveEnt += In_TipoLiq;
            XMLSaveEnt += In_Recurso;
            XMLSaveEnt += "</IdM_VariablesTramiteReco>";
            XMLSaveEnt += "<IdM_VariablesProcesoTram>";
            XMLSaveEnt += In_Sucbancaria;
            XMLSaveEnt += "</IdM_VariablesProcesoTram>";
            XMLSaveEnt += "</M_Tramite>";
            XMLSaveEnt += "</M_cat_Reconocimiento>";
            XMLSaveEnt += "</Entities>";
            XMLSaveEnt += "</BizAgiWSParam>";

            CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
            string sRes = objSaveEntity.ServicioSaveEntity(XMLSaveEnt);

            return sRes;
        }


        //Valida Columna Banco para Actualizacion
        public string Get_XMLSucursalBancaria(string In_VrCol)
        {
            string Res = "";
            //Igual a cero se debe buscar una sucursal bancaria para la ciudad de residencia del caso.
            if (In_VrCol == "0")
            {
                this.UpdateSucursalBancaria();
                if (this.IdSucBancaria != null)
                    Res = "<IdP_SucursalBancaria>" + this.IdSucBancaria + "</IdP_SucursalBancaria>";
                else
                    Res = "";
            }
            else if (In_VrCol == "N/A")
            {
                Res = "";
            }
            else
            {
                if (In_VrCol != null)
                    Res = "<IdP_SucursalBancaria>" + In_VrCol + "</IdP_SucursalBancaria>";
                else
                    Res = "";
            }

            return Res;
        }


        //Valida Columna de Tipo Liquidacion
        public string Get_XMLTipoLiquidacion(string In_VrCol)
        {
            string Res = "";
            if (In_VrCol == "N/A")
            {
                Res = "";
            }
            else
            {
                Res = "<TipoLiquidacion businessKey=\"SCodColpensiones='" + In_VrCol + "'\"/>";
            }
            return Res;
        }

        //Valida Columna de Recurso
        public string Get_XMLTipoRecurso(string In_VrCol)
        {
            string Res = "";
            if (In_VrCol == "N/A")
            {
                Res = "";
            }
            else
            {
                Res = "<IdP_Recurso businessKey=\"SCodigo='" + In_VrCol + "'\"/>";
            }
            return Res;
        }

        //Valida Columna de Intancia
        public string Get_XMLTipoInstancia(string In_VrCol)
        {
            string Res = "";
            if (In_VrCol == "N/A")
            {
                Res = "";
            }
            else
            {
                Res = "<IdP_TipoInstancia businessKey=\"SCodigo='" + In_VrCol + "'\"/>";
            }
            return Res;
        }

        //Captura Informacion de Tramite (Reconocimiento)
        private void Get_InfoEntTramiteRec(XmlNode In_NodoTramite)
        {
            foreach (XmlNode TmpNode in In_NodoTramite)
            {
                if (TmpNode.Name == "IdP_SubtipoTramite")
                    this.Get_InfEntSubTramite(TmpNode);                 
            }
        }

        //Captura Informacion de SubTramite (Entidad Parametrica)
        private void Get_InfEntSubTramite(XmlNode In_NodoSubTramite)
        {
            foreach (XmlNode TmpNode in In_NodoSubTramite)
            {
                if (TmpNode.Name == "SNombre")
                    this.SubTramite = TmpNode.InnerText;
                if (TmpNode.Name == "SCodigo")
                    this.CodSubTramite = TmpNode.InnerText;
            }
        }

        //Captura Informacion de VariablesProcesoTramite
        private void Get_InfEntVarProcesoTrmite(XmlNode In_NodoVarProTra)
        {
            foreach (XmlNode TmpNode in In_NodoVarProTra)
            {
                //if (TmpNode.Name == "BCotizColpC1")
                    //this.SubTramite = TmpNode.InnerText;
                //if (TmpNode.Name == "BTieneTiemposPublicos")
                    //this.CodSubTramite = TmpNode.InnerText;
                //if (TmpNode.Name == "BCotizColpC2")
                    //this.CodSubTramite = TmpNode.InnerText;
                //if (TmpNode.Name == "BTieneTiemposPublicosC2")
                    //this.CodSubTramite = TmpNode.InnerText;
            }
        }

        //SetEtapa110 Liquidador (Liquidacion Automatica)
        public string Set_Etapa110PA(String In_Decision)
        {


            string sSE = "<BizAgiWSParam>";
            sSE += "<Entities idCase=\"" + this.IdCase + "\">";
            sSE += "<M_cat_Reconocimiento>";
            sSE += "<IdM_RC01Reconocimiento>";
            sSE += "<BSiguiente>1</BSiguiente>";
            sSE += "</IdM_RC01Reconocimiento>";
            sSE += "</M_cat_Reconocimiento>";
            sSE += "</Entities>";
            sSE += "</BizAgiWSParam>";

            CapaSOABizAgi objActualiza = new CapaSOABizAgi();
            string sResSEnt = objActualiza.ServicioSaveEntity(sSE);
            
            
            string sPerActivity110 = "<BizAgiWSParam>";
            sPerActivity110 += "<domain>domain</domain>";
            sPerActivity110 += "<userName>admon</userName>";
            sPerActivity110 += "<ActivityData>";
            sPerActivity110 += "<idCase>" + this.IdCase + "</idCase>";
            sPerActivity110 += "<taskId>4329</taskId>";
            sPerActivity110 += "</ActivityData>";
            sPerActivity110 += "<Entities>";
            sPerActivity110 += "<App>";
            sPerActivity110 += "<M_cat_Reconocimiento>";
            sPerActivity110 += "<IdM_RC01Reconocimiento>";
            sPerActivity110 += "<BSiguiente>1</BSiguiente>";
            sPerActivity110 += "<IdM_DatosActividad>";
            sPerActivity110 += "<Iid>21</Iid>";
            sPerActivity110 += "<IdP_Accion businessKey=\"SEtapa='110'\"/>";
            sPerActivity110 += "<SFechaString>20130626</SFechaString>";
            sPerActivity110 += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sPerActivity110 += "<SDominio>domain</SDominio>";
            sPerActivity110 += "<SResponsable>admon</SResponsable>";
            sPerActivity110 += "<SObservaciones>Etapa avanzada por AUTOMATICO</SObservaciones>";
            sPerActivity110 += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_Decision + "'\"/>";
            sPerActivity110 += "</IdM_DatosActividad>";
            sPerActivity110 += "</IdM_RC01Reconocimiento>";
            sPerActivity110 += "</M_cat_Reconocimiento>";
            sPerActivity110 += "</App>";
            sPerActivity110 += "</Entities>";
            sPerActivity110 += "</BizAgiWSParam>";
                        

            CapaSOABizAgi objMoverCaso = new CapaSOABizAgi();
            string sResSetEvent = objMoverCaso.ServicioPerformActivity(sPerActivity110);

            if ((sResSetEvent == "EJECUCION CORRECTA...") || (sResSetEvent == "OK"))
            {
                this.CodError = "0";
                this.DesError = "OK";
            }
            else
            {
                this.CodError = "1";
                this.DesError = sResSetEvent;
            }

            return sResSetEvent;
        }

        //Validar tipo de Liquidacion
        public string Get_TipoLiquidacion()
        {

            string XSDInfo = "";

               XSDInfo += "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
               XSDInfo += "<xs:element name=\"App\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"TipoLiquidacion\" type=\"xs:integer\" />";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosReconocimientoA\">";
               XSDInfo += "<xs:complexType>";
               XSDInfo += "<xs:sequence>";
               XSDInfo += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoLiquidacion\" type=\"xs:integer\" />";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "</xs:sequence>";
               XSDInfo += "</xs:complexType>";
               XSDInfo += "</xs:element>";
               XSDInfo += "</xs:schema>";


            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            string sRes = objCapaSOA.ServicioGetCaseDataSchema(Convert.ToInt32(this.IdCase), XSDInfo);

            string TL1 = "";
            string TL2 = "";


            XmlDocument XDocTipLiq = new XmlDocument();

            XDocTipLiq.LoadXml(sRes);

            XmlNode NodoTL1 = XDocTipLiq.SelectSingleNode("/BizAgiWSResponse/App/M_cat_Reconocimiento/M_Tramite/IdM_VariablesTramiteReco");

            foreach (XmlNode TmpNode in NodoTL1)
            {
                if (TmpNode.InnerText != null)
                    TL1 = TmpNode.InnerText;
            }
                        
            XmlNode NodoTL2 = XDocTipLiq.SelectSingleNode("/BizAgiWSResponse/App/M_cat_Reconocimiento/IdM_RC01Reconocimiento/IdM_DatosReconocimientoA");

            foreach (XmlNode TmpNode in NodoTL2)
            {
                if (TmpNode.InnerText != null)
                    TL2 = TmpNode.InnerText;
            }

            if (TL1 != TL2)
            {
                return TL1;
            }
            else
            {
                return "OK";
            }
        }

        public String SaveEntityForIncRazonSocial()
        {
            String Res = "";

            foreach (PersonasNotificar tmpPN in this.lstPN)
            {
                if ((tmpPN.IdTipoNotificante == 2) && (tmpPN.primerNombre.Length <= 4) && (tmpPN.primerApellido.Length > 4))
                {
                    string XML = "";

                    XML += "<BizAgiWSParam>";
                    XML += "<Entities>";
                    XML += "<M_RC01_PersonasNotificar key=\"" +tmpPN.Id.ToString() + "\">";
                    XML += "<SPrimerNombre>" +tmpPN.primerApellido + "</SPrimerNombre>";
                    XML += "<SPrimerApellido>" +tmpPN.primerNombre + "</SPrimerApellido>";
                    XML += "</M_RC01_PersonasNotificar>";
                    XML += "</Entities>";
                    XML += "</BizAgiWSParam>";

                    CapaSOABizAgi objCapaSOABA = new CapaSOABizAgi();
                    Res += objCapaSOABA.ServicioSaveEntity(XML);
                }
            }

            return Res;
        }

        //XSD Informacion General Tramite Reconocimiento
        private string Get_XSD_InfoGeneralMR()
        {
            string XSDInfoGeneralMR = "";

            XSDInfoGeneralMR += "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
            XSDInfoGeneralMR += "<xs:element name=\"App\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_ServicioCiudadano\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramitePQRS\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Estado\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BRequiereEspera\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BFamiliar\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesProcesoTram\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BCotizColpC1\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTieneTiemposPublicosC2\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BCotizColpC2\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTieneTiemposPublicos\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_EstadoRespBOTmpPub\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEsperarInfoTiempoPub\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_DetallevalidacionNube\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_DetalleValidacionNube\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoValidacion\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SDetalleValidacion\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEsPrevalidacion\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_RC08_ConfirmTiemposPubs\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_RC08_ConfirmTiemposPub\">";
            XSDInfoGeneralMR += "<xs:complexType>";
            XSDInfoGeneralMR += "<xs:sequence>";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiempoVencRecibirCertif\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiempoVencRecibirAcuse\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BRecibidaCertificacionEx\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BSilencioAdministrativo\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEnviadaSolCorresExt\" type=\"xs:boolean\" />";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:sequence>";
            XSDInfoGeneralMR += "</xs:complexType>";
            XSDInfoGeneralMR += "</xs:element>";
            XSDInfoGeneralMR += "</xs:schema>";

            return XSDInfoGeneralMR;
        }

        private string Get_XML_InfoGetNotificantesReconocimiento()
        {
            var sXML = "";
            
            sXML += "<BizAgiWSParam>";
            sXML += "<CaseInfo>";
            sXML += "<IdCase>" + this.IdCase.ToString() + "</IdCase>";
            sXML += "</CaseInfo>";
            sXML += "<XPaths>";
            sXML += "<XPath XPath=\"M_cat_Reconocimiento.IdM_RC01Reconocimiento.IdM_DatosActividad.RC01_DtosAct_Notificar\"/>";
            sXML += "<XPath XPath=\"M_cat_Reconocimiento.IdM_RC01Reconocimiento.RC01_Rec_PersonasNotific\"/>";
            sXML += "</XPaths>";
            sXML += "</BizAgiWSParam>";

            return sXML;
        }

        private string Get_XML_InfoEntityNotificantesReconocimiento(Int64 In_IdEnt)
        {
            var sXML = "";

            sXML += "<BizAgiWSParam>";
            sXML +=     "<EntityData>";
            sXML +=         "<EntityID>10266</EntityID>";
            sXML +=         "<Filters>";
            sXML += "<![CDATA[IdM_RC01_PersonasNotificar = " + In_IdEnt.ToString() + "]]>";
            sXML +=         "</Filters>";
            sXML +=     "</EntityData>";
            sXML += "</BizAgiWSParam>";

            return sXML;
        }

        public void Get_InfoNotificantesReconocimiento()
        {
            string XML = this.Get_XML_InfoGetNotificantesReconocimiento();

            CapaSOABizAgi objCapaSOABA = new CapaSOABizAgi();
            string ResCapaSOA = objCapaSOABA.ServicioGetCasesUsingXPaths(XML);

            //Consulta Informacion del Tramite.
            XmlDocument XDocReconocimiento = new XmlDocument();
            XDocReconocimiento.LoadXml(ResCapaSOA);

            XmlNodeList NodRecNotificantes = XDocReconocimiento.SelectNodes("/BizAgiWSResponse/XPath");
            if (NodRecNotificantes.Count > 0)
            {
                foreach (XmlNode tmpXML in NodRecNotificantes)
                {
                    if (tmpXML.Attributes.GetNamedItem("XPath").InnerText == "M_cat_Reconocimiento.IdM_RC01Reconocimiento.IdM_DatosActividad.RC01_DtosAct_Notificar")
                    {
                        XmlNodeList ChildsXPaths = tmpXML.ChildNodes;

                        foreach (XmlNode tmlXMLP in ChildsXPaths)
                        {
                            if (tmlXMLP.Name == "Items")
                            {
                                XmlNodeList ChildsItems = tmlXMLP.ChildNodes;

                                foreach (XmlNode tmpXMLI in ChildsItems)
                                {
                                    Int64 Id = Convert.ToInt64(tmpXMLI.Attributes.GetNamedItem("Id").InnerText);
                                    String XMLNot = objCapaSOABA.ServicioGetEntityByString(this.Get_XML_InfoEntityNotificantesReconocimiento(Id));

                                    XmlDocument XDocENP = new XmlDocument();
                                    XDocENP.LoadXml(XMLNot);

                                    XmlNodeList NodPN = XDocENP.SelectNodes("/BizAgiWSResponse/Entities/M_RC01_PersonasNotificar");
                                    if (NodPN.Count > 0)
                                    {
                                        PersonasNotificar objPN = new PersonasNotificar();
                                        objPN.Id = Id;

                                        foreach (XmlNode tmp1 in NodPN)
                                        {
                                            XmlNodeList NodeListEntNotP = tmp1.ChildNodes;

                                            if (NodeListEntNotP.Count > 0)
                                            {
                                                foreach (XmlNode tmp2 in NodeListEntNotP)
                                                {
                                                    string Atrib = tmp2.Name;

                                                    switch (Atrib)
                                                    {
                                                        case "SPrimerNombre":
                                                            objPN.primerNombre = tmp2.InnerText;
                                                            break;

                                                        case "SPrimerApellido":
                                                            objPN.primerApellido = tmp2.InnerText;
                                                            break;

                                                        case "IdP_TipoNotificante":
                                                            objPN.IdTipoNotificante = Convert.ToInt64(tmp2.Attributes.GetNamedItem("key").InnerText);
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                        this.lstPN.Add(objPN);
                                    }
                                }
                            }
                        }
                    }
                    if (tmpXML.Attributes.GetNamedItem("XPath").InnerText == "M_cat_Reconocimiento.IdM_RC01Reconocimiento.RC01_Rec_PersonasNotific")
                    {
                        XmlNodeList ChildsXPaths = tmpXML.ChildNodes;

                        foreach (XmlNode tmlXMLP in ChildsXPaths)
                        {
                            if (tmlXMLP.Name == "Items")
                            {
                                XmlNodeList ChildsItems = tmlXMLP.ChildNodes;

                                foreach (XmlNode tmpXMLI in ChildsItems)
                                {
                                    Int64 Id = Convert.ToInt64(tmpXMLI.Attributes.GetNamedItem("Id").InnerText);
                                    String XMLNot = objCapaSOABA.ServicioGetEntityByString(this.Get_XML_InfoEntityNotificantesReconocimiento(Id));

                                    XmlDocument XDocENP = new XmlDocument();
                                    XDocENP.LoadXml(XMLNot);

                                    XmlNodeList NodPN = XDocENP.SelectNodes("/BizAgiWSResponse/Entities/M_RC01_PersonasNotificar");
                                    if (NodPN.Count > 0)
                                    {
                                        PersonasNotificar objPNBA = new PersonasNotificar();

                                        foreach (XmlNode tmp1 in NodPN)
                                        {
                                            XmlNodeList NodeListEntNotP = tmp1.ChildNodes;

                                            if (NodeListEntNotP.Count > 0)
                                            {
                                                foreach (XmlNode tmp2 in NodeListEntNotP)
                                                {
                                                    string Atrib = tmp2.Name;

                                                    switch (Atrib)
                                                    {
                                                        case "SPrimerNombre":
                                                            objPNBA.primerNombre = tmp2.InnerText;
                                                            break;

                                                        case "SPrimerApellido":
                                                            objPNBA.primerApellido = tmp2.InnerText;
                                                            break;

                                                        case "IdP_TipoNotificante":
                                                            objPNBA.IdTipoNotificante = Convert.ToInt64(tmp2.Attributes.GetNamedItem("key").InnerText);
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                        this.lstPNBA.Add(objPNBA);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void Get_RC01Reconocimiento(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                String Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "IdM_DatosReconocimientoA":
                        this.IdMDtsRecA = Convert.ToInt32(tmpXML.Attributes.GetNamedItem("key").InnerText);
                        this.Get_MDtsReconocimientoA(tmpXML.ChildNodes); 
                        break;
                }
            }
        }

        private void Get_MDtsReconocimientoA(XmlNodeList In_XML)
        {
            foreach (XmlNode tmpXML in In_XML)
            {
                String Atributo = tmpXML.Name;

                switch (Atributo)
                {
                    case "IdP_Decision":
                        this.IdP_Decision.IdP_Decision = Convert.ToInt32(tmpXML.Attributes.GetNamedItem("key").InnerText);
                        this.IdP_Decision.Get_InfoPDecision(tmpXML.ChildNodes);
                        break;
                }
            }
        }

        private String Get_XSD_InformacionGeneralReconocimiento()
        {

            string XSDInfoGenReco = "";

            XSDInfoGenReco +=	"<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
            XSDInfoGenReco +=	    "<xs:element name=\"App\">";
            XSDInfoGenReco +=	        "<xs:complexType>";
            XSDInfoGenReco +=	            "<xs:sequence>";
            XSDInfoGenReco +=	                "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\">";
            XSDInfoGenReco +=	                    "<xs:complexType>";
            XSDInfoGenReco +=	                        "<xs:sequence>";
            XSDInfoGenReco +=	                            "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\">";
            XSDInfoGenReco +=	                                "<xs:complexType>";
            XSDInfoGenReco +=	                                    "<xs:sequence>";
            XSDInfoGenReco +=	                                        "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosReconocimientoA\">";
            XSDInfoGenReco +=	                                            "<xs:complexType>";
            XSDInfoGenReco +=	                                                "<xs:sequence>";
            XSDInfoGenReco +=	                                                    "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Decision\">";
            XSDInfoGenReco +=	                                                        "<xs:complexType>";
            XSDInfoGenReco +=	                                                            "<xs:sequence>";
            XSDInfoGenReco +=	                                                                "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                                                "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SDecision\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                                                "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SEstadoDecision\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                                                "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                                            "</xs:sequence>";
            XSDInfoGenReco +=	                                                            "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                                        "</xs:complexType>";
            XSDInfoGenReco +=	                                                    "</xs:element>";
            XSDInfoGenReco +=	                                                "</xs:sequence>";
            XSDInfoGenReco +=	                                                "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                            "</xs:complexType>";
            XSDInfoGenReco +=	                                        "</xs:element>";
            XSDInfoGenReco +=	                                    "</xs:sequence>";
            XSDInfoGenReco +=	                                    "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                                "</xs:complexType>";
            XSDInfoGenReco +=	                            "</xs:element>";
            XSDInfoGenReco +=	                        "</xs:sequence>";
            XSDInfoGenReco +=	                    "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGenReco +=	                "</xs:complexType>";
            XSDInfoGenReco +=               "</xs:element>";
            XSDInfoGenReco +=           "</xs:sequence>";
            XSDInfoGenReco +=       "</xs:complexType>";
            XSDInfoGenReco +=   "</xs:element>";
            XSDInfoGenReco += "</xs:schema>";
            
            return XSDInfoGenReco;
        }

        public string Upd_UserLiquidadorSupervisor(string In_UserLiq, string In_UserSup)
        {


            return "OK";
        }

        public string UPD_ErrorActividadSinEvento()
        {
            string sSaveEntity = "";
            string sPerfomActivity = "";
            string sRespuesta = "";

            if (this.EtapaActividad == "EnDecision")
            {
                sSaveEntity +=  "<BizAgiWSParam>";
	            sSaveEntity +=      "<Entities idCase=\"" + this.IdCase + "\">";
		        sSaveEntity +=          "<M_cat_Reconocimiento>";
			    sSaveEntity +=              "<IdM_RC01Reconocimiento>";
				sSaveEntity +=                  "<BSiguiente>1</BSiguiente>";
				sSaveEntity +=                  "<IdM_DatosActividad>";
				sSaveEntity +=                  "<IdP_Accion businessKey=\"SEtapa='10'\"/>";
				sSaveEntity +=                  "<IdP_EstadoReconocimiento businessKey=\"SEtapa='10'\"/>";
				sSaveEntity +=                  "<SFechaString>20120713</SFechaString>";
				sSaveEntity +=                  "<Id_Responsable>1</Id_Responsable>";
				sSaveEntity +=                  "<IdS_UsuarioEjecutor>1</IdS_UsuarioEjecutor>";
				sSaveEntity +=                  "<IdP_TipoAccion businessKey=\"SCodColpensiones='ARRANQUE'\"/>";
				sSaveEntity +=                  "<SDominio>domain</SDominio>";
				sSaveEntity +=                  "<SResponsable>admon</SResponsable>";
				sSaveEntity +=                  "<SObservaciones>Automaticamente BA.</SObservaciones>";
				sSaveEntity +=                  "</IdM_DatosActividad>";
			    sSaveEntity +=              "</IdM_RC01Reconocimiento>";
		        sSaveEntity +=          "</M_cat_Reconocimiento>";
	            sSaveEntity +=      "</Entities>";
                sSaveEntity += "</BizAgiWSParam>";

                CapaSOABizAgi objCS = new CapaSOABizAgi();
                sRespuesta = objCS.ServicioSaveEntity(sSaveEntity);

                if (sRespuesta.Contains("EJECUCION CORRECTA..."))
                {
                    sPerfomActivity +=  "<BizAgiWSParam>";
                    sPerfomActivity +=      "<domain>Domain</domain>";
	                sPerfomActivity +=      "<userName>admon</userName>";
	                sPerfomActivity +=      "<ActivityData>";
		            sPerfomActivity +=          "<idCase>" + this.IdCase.ToString() + "</idCase>";
		            sPerfomActivity +=          "<taskId>" + 171 + "</taskId>";
	                sPerfomActivity +=      "</ActivityData>";
                    sPerfomActivity += "</BizAgiWSParam>";

                    sRespuesta = objCS.ServicioPerformActivity(sPerfomActivity);
                }
            }

            if (this.EtapaActividad == "Task2")
            {
                sSaveEntity += "<BizAgiWSParam>";
                sSaveEntity += "<Entities idCase=\"" + this.IdCase + "\">";
                sSaveEntity += "<M_cat_Reconocimiento>";
                sSaveEntity += "<IdM_RC01Reconocimiento>";
                sSaveEntity += "<BSiguiente>1</BSiguiente>";
                sSaveEntity += "<IdM_DatosActividad>";
                sSaveEntity += "<IdP_Accion businessKey=\"SEtapa='10'\"/>";
                sSaveEntity += "<IdP_EstadoReconocimiento businessKey=\"SEtapa='10'\"/>";
                sSaveEntity += "<SFechaString>20120713</SFechaString>";
                sSaveEntity += "<Id_Responsable>1</Id_Responsable>";
                sSaveEntity += "<IdS_UsuarioEjecutor>1</IdS_UsuarioEjecutor>";
                sSaveEntity += "<IdP_TipoAccion businessKey=\"SCodColpensiones='ARRANQUE'\"/>";
                sSaveEntity += "<SDominio>domain</SDominio>";
                sSaveEntity += "<SResponsable>admon</SResponsable>";
                sSaveEntity += "<SObservaciones>Automaticamente BA.</SObservaciones>";
                sSaveEntity += "</IdM_DatosActividad>";
                sSaveEntity += "</IdM_RC01Reconocimiento>";
                sSaveEntity += "</M_cat_Reconocimiento>";
                sSaveEntity += "</Entities>";
                sSaveEntity += "</BizAgiWSParam>";

                CapaSOABizAgi objCS = new CapaSOABizAgi();
                sRespuesta = objCS.ServicioSaveEntity(sSaveEntity);

                if (sRespuesta.Contains("EJECUCION CORRECTA..."))
                {
                    sPerfomActivity += "<BizAgiWSParam>";
                    sPerfomActivity += "<domain>Domain</domain>";
                    sPerfomActivity += "<userName>admon</userName>";
                    sPerfomActivity += "<ActivityData>";
                    sPerfomActivity += "<idCase>" + this.IdCase.ToString() + "</idCase>";
                    sPerfomActivity += "<taskId>" + 171 + "</taskId>";
                    sPerfomActivity += "</ActivityData>";

                    sPerfomActivity += "<Entities>";
                    sPerfomActivity +=  "<App>";
                    sPerfomActivity +=      "<M_cat_Reconocimiento>";
                    sPerfomActivity +=          "<IdM_RC01Reconocimiento>";
                    sPerfomActivity +=              "<BSiguiente>1</BSiguiente>";
                    sPerfomActivity +=          "</IdM_RC01Reconocimiento>";
                    sPerfomActivity +=      "</M_cat_Reconocimiento>";
                    sPerfomActivity +=  "</App>";
                    sPerfomActivity += "</Entities>";
                    

                    sPerfomActivity += "</BizAgiWSParam>";

                    sRespuesta = objCS.ServicioPerformActivity(sPerfomActivity);
                }
            }

            return sRespuesta;
        }

        public string Set_PerformPorFaltaEvento(int In_idTask)
        {
            string sSaveEntity = "";
            string sRespuesta = "";
            string sPerfomActivity = "";

            sSaveEntity += "<BizAgiWSParam>";
            sSaveEntity += "<Entities idCase=\"" + this.IdCase + "\">";
            sSaveEntity += "<M_cat_Reconocimiento>";
            sSaveEntity += "<IdM_RC01Reconocimiento>";
            sSaveEntity += "<BSiguiente>1</BSiguiente>";
            sSaveEntity += "<IdM_DatosActividad>";
            sSaveEntity += "<IdP_Accion businessKey=\"SEtapa='80'\"/>";
            sSaveEntity += "<IdP_EstadoReconocimiento businessKey=\"SEtapa='80'\"/>";
            sSaveEntity += "<SFechaString>20120713</SFechaString>";
            sSaveEntity += "<Id_Responsable>1</Id_Responsable>";
            sSaveEntity += "<IdS_UsuarioEjecutor>1</IdS_UsuarioEjecutor>";
            sSaveEntity += "<IdP_TipoAccion businessKey=\"SCodColpensiones='ARRANQUE'\"/>";
            sSaveEntity += "<SDominio>domain</SDominio>";
            sSaveEntity += "<SResponsable>admon</SResponsable>";
            sSaveEntity += "<SObservaciones>Automaticamente BA.</SObservaciones>";
            sSaveEntity += "</IdM_DatosActividad>";
            sSaveEntity += "</IdM_RC01Reconocimiento>";
            sSaveEntity += "</M_cat_Reconocimiento>";
            sSaveEntity += "</Entities>";
            sSaveEntity += "</BizAgiWSParam>";
            
            CapaSOABizAgi objCS = new CapaSOABizAgi();
            sRespuesta = objCS.ServicioSaveEntity(sSaveEntity);

            if (sRespuesta.Contains("EJECUCION CORRECTA..."))
            {

                sPerfomActivity += "<BizAgiWSParam>";
                sPerfomActivity += "<domain>Domain</domain>";
                sPerfomActivity += "<userName>admon</userName>";
                sPerfomActivity += "<ActivityData>";
                sPerfomActivity += "<idCase>" + this.IdCase.ToString() + "</idCase>";
                sPerfomActivity += "<taskId>" + In_idTask.ToString() + "</taskId>";
                sPerfomActivity += "</ActivityData>";
                
                sPerfomActivity += "<Entities>";
                sPerfomActivity +=  "<M_cat_Reconocimiento>";
                sPerfomActivity +=      "<IdM_RC01Reconocimiento>";
                sPerfomActivity += "<BSiguiente>1</BSiguiente>";
                sPerfomActivity +=      "</IdM_RC01Reconocimiento>";
                sPerfomActivity +=  "</M_cat_Reconocimiento>";
                sPerfomActivity += "</Entities>";

                sPerfomActivity += "</BizAgiWSParam>";

                sRespuesta = objCS.ServicioPerformActivity(sPerfomActivity);
            }

            return sRespuesta;
        }

        public string Set_ResliquidadorFullDatosUnNotificado(string In_Id, string In_Etapa, string In_Fecha, string In_TipoAccion, 
                                                            string In_SDominoRes, string In_SResponsable, string In_SObservacion,
                                                            string In_NoActo, string In_PrefijoActo, string In_sFechaActo, string In_TipoLiq, string In_Decision,
                                                            string In_ActoAdm, string In_BonoPen, string In_ParteRes, string In_TipoDoc,
                                                            string In_NoDoc, string In_PN, string In_SN, string In_PA, string In_SA,
                                                            string In_Direccion, string In_Telefono, string In_EnvioMail, string In_Correo,
                                                            string In_Fax, string In_Ciudad, Boolean In_IndBnoPensional, Boolean In_IndReqApelcion)
        {

            

            string sSetEvent = "<BizAgiWSParam>";
            sSetEvent += "<domain>domain</domain>";
            sSetEvent += "<userName>admon</userName>";
            sSetEvent += "<Events>";
            sSetEvent += "<Event>";
            sSetEvent += "<EventData>";
            sSetEvent += "<idCase>" + this.IdCase + "</idCase>";
            sSetEvent += "<eventName>RegistroDeActividades</eventName>";
            sSetEvent += "</EventData>";
            sSetEvent += "<Entities>";
            sSetEvent += "<App>";
            sSetEvent += "<M_cat_Reconocimiento>";
            sSetEvent += "<IdM_RC01Reconocimiento>";
            sSetEvent += "<IdM_DatosActividad>";
            sSetEvent += "<Iid>" + In_Id + "</Iid>";
            sSetEvent += "<IdP_Accion businessKey=\"SEtapa='" + In_Etapa + "'\"/>";
            sSetEvent += "<SFechaString>" + In_Fecha + "</SFechaString>";
            sSetEvent += "<IdP_TipoAccion businessKey=\"SCodColpensiones='" + In_TipoAccion + "'\"/>";
            sSetEvent += "<SDominio>" + In_SDominoRes + "</SDominio>";
            sSetEvent += "<SResponsable>" + In_SResponsable + "</SResponsable>";
            sSetEvent += "<SObservaciones>" + In_SObservacion + "</SObservaciones>";
            if (In_NoActo != null)
                sSetEvent += "<INumeroActoAdministrativ>" + In_NoActo + "</INumeroActoAdministrativ>";
            if (In_PrefijoActo != null)
                sSetEvent += "<SPrefijoNoActoAdm>" + In_PrefijoActo + "</SPrefijoNoActoAdm>";
            sSetEvent += "<SFechaActoAdminitrativo>" + In_sFechaActo + "</SFechaActoAdminitrativo>";
            sSetEvent += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='" + In_TipoLiq + "'\"/>";
            sSetEvent += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_Decision + "'\"/>";
            sSetEvent += "<SActoAdministrativo>" + In_ActoAdm + "</SActoAdministrativo>";
            sSetEvent += "<BBonoPensional>" + In_BonoPen + "</BBonoPensional>";
            sSetEvent += "<SParteResolutiva>" + In_ParteRes  + "</SParteResolutiva>";
            sSetEvent += "<BBonoPensional>" + In_IndBnoPensional.ToString()  + "</BBonoPensional>";
            sSetEvent += "<BIndicadorApelacion>" + In_IndReqApelcion.ToString() + "</BIndicadorApelacion>";
            sSetEvent += "<RC01_DtosAct_Notificar>";
            sSetEvent += "<M_RC01_PersonasNotificar>";
            sSetEvent += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_TipoDoc + "'\"/>";
            sSetEvent += "<SNumeroDocumento>" + In_NoDoc + "</SNumeroDocumento>";
            sSetEvent += "<SPrimerNombre>" + In_PN + "</SPrimerNombre>";
            sSetEvent += "<SSegundoNombre>" + In_SN + "</SSegundoNombre>";
            sSetEvent += "<SPrimerApellido>" + In_PA + "</SPrimerApellido>";
            sSetEvent += "<SSegundoApellido>" + In_SA + "</SSegundoApellido>";
            sSetEvent += "<SDireccion>" + In_Direccion + "</SDireccion>";
            sSetEvent += "<STelefono>" + In_Telefono + "</STelefono>";
            sSetEvent += "<IdP_Ciudad businessKey=\"SCodigo='" + In_Ciudad +"'\"/>";
            sSetEvent += "<BAutorizaNotificacionCor>" + In_EnvioMail + "</BAutorizaNotificacionCor>";
            sSetEvent += "<SCorreo>" + In_Correo + "</SCorreo>";
            sSetEvent += "<SFax>" + In_Fax + "</SFax>";
            sSetEvent += "</M_RC01_PersonasNotificar>";
            sSetEvent += "</RC01_DtosAct_Notificar>";
            sSetEvent += "</IdM_DatosActividad>";
            sSetEvent += "</IdM_RC01Reconocimiento>";
            sSetEvent += "</M_cat_Reconocimiento>";
            sSetEvent += "</App>";
            sSetEvent += "</Entities>";
            sSetEvent += "</Event>";
            sSetEvent += "</Events>";
            sSetEvent += "</BizAgiWSParam>";

            CapaSOABizAgi objMoverCaso = new CapaSOABizAgi();
            string sResSetEvent = objMoverCaso.ServicioSetEventByXML(sSetEvent);

            if (sResSetEvent == "EJECUCION CORRECTA...")
            {
                this.CodError = "0";
                this.DesError = "OK";
            }
            else
            {
                this.CodError = "1";
                this.DesError = "Error en ejecucion de SetEvent";
            }
            return sResSetEvent;
        }

        //Genrar XML Respuesta Liquidador Firmado.
        public string GenerarXMLRespuestaNP(Int32 In_IdCase, string In_sActoAdm, string In_sEtapa, string In_SResolucion, 
                                            string In_SCodDecision, string In_SDireccionPN, string In_SCodDANE,
                                            string In_sSN, string In_sPN, string In_sSA, string In_sPA, string In_sTel,
                                            string In_sTipDoc, string In_SNoIden, string In_BonoPensional, string In_IndApe, 
                                            string In_IndRetiro, string In_TipoPersona)
        {
            Boolean bRes = true;
            string sXML = "";

            sXML += "<BizAgiWSParam>";
            sXML += "<Events>";
            sXML += "<Event>";
            sXML += "<EventData>";
            sXML += "<idCase>" + In_IdCase + "</idCase>";
            sXML += "<eventName>RegistroDeActividades</eventName>";
            sXML += "</EventData>";
            sXML += "<Entities>";
            sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<IdM_DatosActividad>";
            sXML += "<BIndicadorApelacion>false</BIndicadorApelacion>";
            
            //BONOS PENSIONALES
            if (In_BonoPensional == "1")
                sXML += "<BBonoPensional>true</BBonoPensional>";
            else
                sXML += "<BBonoPensional>false</BBonoPensional>";


            //INDICADOR DE APELACIONES
             if (In_IndApe == "1")
                    sXML += "<BIndicadorApelacion>true</BIndicadorApelacion>";
                else
                    sXML += "<BIndicadorApelacion>false</BIndicadorApelacion>";

            //INDICADOR DE RETIRO DEFINITIVO DEL SERVICIO (APLICA O NO APLICA)
            if (In_IndRetiro == "1")
                    sXML += "<BConRetiroDef>true</BConRetiroDef>";
                else
                    sXML += "<BConRetiroDef>false</BConRetiroDef>";
            
            DateTime GenId = DateTime.Now;
            sXML += "<Iid>" + GenId.Year.ToString() + GenId.Month.ToString() + GenId.Day.ToString() + "</Iid>";
            string day = "";
            string mont = "";
            if (GenId.Month.ToString().Length < 2)
            {
                mont = "0" + GenId.Month.ToString().Length;
            }
            else
            {
                mont = GenId.Month.ToString();
            }
            if (GenId.Day.ToString().Length < 2)
            {
                day = "0" + GenId.Day.ToString().Length;
            }
            else
            {
                day = GenId.Day.ToString();
            }
            sXML += "<SFechaString>" + GenId.Year.ToString() + mont + day + "</SFechaString>";
            sXML += "<SParteResolutiva>N/A</SParteResolutiva>";
            sXML += "<SActoAdministrativo>" + In_sActoAdm + "</SActoAdministrativo>";
            sXML += "<IdP_Accion businessKey=\"SEtapa='" + In_sEtapa + "'\"/>";
            sXML += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sXML += "<SFechaActoAdminitrativo>N/A</SFechaActoAdminitrativo>";
            sXML += "<SDominio>domain</SDominio>";
            sXML += "<SResponsable>admon</SResponsable>";
            sXML += "<INumeroActoAdministrativ>" + In_SResolucion + "</INumeroActoAdministrativ>";
            sXML += "<SPrefijoNoActoAdm>GNR</SPrefijoNoActoAdm>";
            sXML += "<SObservaciones>Caso ejecutado por Robot..</SObservaciones>";
            sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_SCodDecision + "'\"/>";
            sXML += "<RC01_DtosAct_Notificar>";
            sXML += "<M_RC01_PersonasNotificar>";
            sXML += "<SDireccion>" + In_SDireccionPN + "</SDireccion>";
            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + In_SCodDANE + "'\"/>";
            sXML += "<SCarta>TEMPORAL</SCarta>";
            
            if (In_sSN != "NULL")
            {
                sXML += "<SSegundoNombre>" + In_sSN + "</SSegundoNombre>";
            }
            if (In_sPN != "NULL")
            {
                sXML += "<SPrimerNombre>" + In_sPN + "</SPrimerNombre>";
            }
            else
            {
                bRes = false;
            }
            if (In_sSA != "NULL")
            {
                sXML += "<SSegundoApellido>" + In_sSA + "</SSegundoApellido>";
            }
            if (In_sPA != "NULL")
            {
                sXML += "<SPrimerApellido>" + In_sPA + "</SPrimerApellido>";
            }
            else
            {
                bRes = false;
            }
            sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
            sXML += "<STelefono>" + In_sTel + "</STelefono>";
            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_sTipDoc + "'\"/>";
            sXML += "<SNumeroDocumento>" + In_SNoIden + "</SNumeroDocumento>";
            
            //TIPO DE NOTIFICANTE QUE SE REQUIERE (Valores 01,02)
            sXML += "<IdP_TipoNotificante businessKey=\"SCodigo='" + In_TipoPersona + "'\"/>";
            
            
            sXML += "</M_RC01_PersonasNotificar>";
            sXML += "</RC01_DtosAct_Notificar>";
            sXML += "</IdM_DatosActividad>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</App>";
            sXML += "</Entities>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";
            if (bRes == false)
                sXML = "ERROR - " + sXML;

            return sXML;
        }

        public string GenerarXMLRespuestaNPMultiPerson(Int32 In_IdCase, string In_sActoAdm, string In_sEtapa, string In_SResolucion,
                                            string In_SCodDecision, string In_BonoPensional, string In_IndApe,
                                            string In_IndRetiro, string In_TipoPersona, List<PersonasNotificar> personasNotificar)
        {
            Boolean bRes = true;
            string sXML = "";

            sXML += "<BizAgiWSParam>";
            sXML += "<Events>";
            sXML += "<Event>";
            sXML += "<EventData>";
            sXML += "<idCase>" + In_IdCase + "</idCase>";
            sXML += "<eventName>RegistroDeActividades</eventName>";
            sXML += "</EventData>";
            sXML += "<Entities>";
            sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<IdM_DatosActividad>";
            //INDICADOR DE APELACIONES
            if (In_IndApe == "1")
                sXML += "<BIndicadorApelacion>true</BIndicadorApelacion>";
            else
                sXML += "<BIndicadorApelacion>false</BIndicadorApelacion>";
            //BONOS PENSIONALES
            if (In_BonoPensional == "1")
                sXML += "<BBonoPensional>true</BBonoPensional>";
            else
                sXML += "<BBonoPensional>false</BBonoPensional>";


            //INDICADOR DE APELACIONES
            if (In_IndApe == "1")
                sXML += "<BIndicadorApelacion>true</BIndicadorApelacion>";
            else
                sXML += "<BIndicadorApelacion>false</BIndicadorApelacion>";

            //INDICADOR DE RETIRO DEFINITIVO DEL SERVICIO (APLICA O NO APLICA)
            if (In_IndRetiro == "1")
                sXML += "<BConRetiroDef>true</BConRetiroDef>";
            else
                sXML += "<BConRetiroDef>false</BConRetiroDef>";

            DateTime GenId = DateTime.Now;
            sXML += "<Iid>" + GenId.Year.ToString() + GenId.Month.ToString() + GenId.Day.ToString() + "</Iid>";
            string day = "";
            string mont = "";
            if (GenId.Month.ToString().Length < 2)
            {
                mont = "0" + GenId.Month.ToString().Length;
            }
            else
            {
                mont = GenId.Month.ToString();
            }
            if (GenId.Day.ToString().Length < 2)
            {
                day = "0" + GenId.Day.ToString().Length;
            }
            else
            {
                day = GenId.Day.ToString();
            }
            sXML += "<SFechaString>" + GenId.Year.ToString() + mont + day + "</SFechaString>";
            sXML += "<SParteResolutiva>N/A</SParteResolutiva>";
            sXML += "<SActoAdministrativo>" + In_sActoAdm + "</SActoAdministrativo>";
            sXML += "<IdP_Accion businessKey=\"SEtapa='" + In_sEtapa + "'\"/>";
            sXML += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sXML += "<SFechaActoAdminitrativo>N/A</SFechaActoAdminitrativo>";
            sXML += "<SDominio>domain</SDominio>";
            sXML += "<SResponsable>admon</SResponsable>";
            sXML += "<INumeroActoAdministrativ>" + In_SResolucion + "</INumeroActoAdministrativ>";
            sXML += "<SPrefijoNoActoAdm>GNR</SPrefijoNoActoAdm>";
            sXML += "<SObservaciones>Caso ejecutado por Robot..</SObservaciones>";
            sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_SCodDecision + "'\"/>";
            sXML += "<RC01_DtosAct_Notificar>";

            foreach (PersonasNotificar persNotif in personasNotificar)
            {

                sXML += "<M_RC01_PersonasNotificar>";
                sXML += "<SDireccion>" + persNotif.direccion + "</SDireccion>";
                sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + persNotif.codigoDANE + "'\"/>";
                sXML += "<SCarta>TEMPORAL</SCarta>";

                if (persNotif.segundoNombre != "NULL")
                {
                    sXML += "<SSegundoNombre>" + persNotif.segundoNombre + "</SSegundoNombre>";
                }
                if (persNotif.primerNombre != "NULL")
                {
                    sXML += "<SPrimerNombre>" + persNotif.primerNombre + "</SPrimerNombre>";
                }
                else
                {
                    bRes = false;
                }
                if (persNotif.segundoApellido != "NULL")
                {
                    sXML += "<SSegundoApellido>" + persNotif.segundoApellido + "</SSegundoApellido>";
                }
                if (persNotif.primerApellido != "NULL")
                {
                    sXML += "<SPrimerApellido>" + persNotif.primerApellido + "</SPrimerApellido>";
                }
                else
                {
                    bRes = false;
                }
                sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
                sXML += "<STelefono>" + persNotif.telefono + "</STelefono>";
                sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + persNotif.tipoIdent + "'\"/>";
                sXML += "<SNumeroDocumento>" + persNotif.numIdent + "</SNumeroDocumento>";

                //TIPO DE NOTIFICANTE QUE SE REQUIERE (Valores 01,02)
                sXML += "<IdP_TipoNotificante businessKey=\"SCodigo='" + persNotif.tipoPersona + "'\"/>";
                sXML += "</M_RC01_PersonasNotificar>";

            }


            sXML += "</RC01_DtosAct_Notificar>";
            sXML += "</IdM_DatosActividad>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</App>";
            sXML += "</Entities>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";
            if (bRes == false)
                sXML = "ERROR - " + sXML;

            return sXML;
        }

        //Actualizar Usuario Liquidador y Supervisor del requenocimiento.
        public string UpdateUsuarios(string In_UsrLiq, string In_UsrSup)
        {
            Boolean bVal;
            WFUSER objUserLiq = new WFUSER();
            WFUSER objUserSup = new WFUSER();
          
            //Validar usuario Liquidador
            if (In_UsrLiq != "N/A")
            {
                bVal = objUserLiq.ValidarUsuario(In_UsrLiq);
                if (bVal == false)
                    return "Usuario liquidador (" + In_UsrLiq + "), No existe, por favor consulte a su administrador.";
            }

            //Validar usuario Supervisor
            if (In_UsrSup != "N/A")
            {   
                bVal = objUserSup.ValidarUsuario(In_UsrSup);
                if (bVal == false)
                    return "Usuario supervisor (" + In_UsrSup + "), No existe, por favor consulte a su administrador.";
            }

            //Actualizar los usuarios
            string XML = "";

            XML += "<BizAgiWSParam>";
            XML += "<Entities idCase=\"" + this.IdCase + "\">";
            XML += "<M_cat_Reconocimiento>";
            XML += "<IdM_RC01Reconocimiento>";
            if (In_UsrLiq != "N/A")
                XML += "<IdS_UserLiquidador>" + objUserLiq.IdUser + "</IdS_UserLiquidador>";
            if (In_UsrSup != "N/A")
                XML += "<IdS_UserSupervisor>" + objUserSup.IdUser + "</IdS_UserSupervisor>";
            if (In_UsrLiq != "N/A")
                XML += "<SUsuarioSustanciador>" + objUserLiq.UsernName + "</SUsuarioSustanciador>";
            if (In_UsrSup != "N/A")
                XML += "<SUsuarioRevisor>" + objUserSup.UsernName + "</SUsuarioRevisor>";
            XML += "</IdM_RC01Reconocimiento>";
            XML += "</M_cat_Reconocimiento>";
            XML += "</Entities>";
            XML += "</BizAgiWSParam>";

            CapaSOABizAgi objUpdUsuarios = new CapaSOABizAgi();
            return objUpdUsuarios.ServicioSaveEntity(XML);

        }

        //Apagar o prender indicador de automatico.
        public string UpdateIndicadorAutomatico(Boolean In_Indicador)
        {
            string XML = "";

            XML += "<BizAgiWSParam>";
            XML += "<Entities idCase=\"" + this.IdCase + "\">";
            XML += "<M_cat_Reconocimiento>";
            XML += "<IdM_RC01Reconocimiento>";
           
            if (In_Indicador == true)
            {
                XML += "<SIndicadorAuto>1</SIndicadorAuto>";
            }
            else
            {
                XML += "<SIndicadorAuto>0</SIndicadorAuto>";
            }

            XML += "</IdM_RC01Reconocimiento>";
            XML += "</M_cat_Reconocimiento>";
            XML += "</Entities>";
            XML += "</BizAgiWSParam>";

            CapaSOABizAgi objUpdUsuarios = new CapaSOABizAgi();
            return objUpdUsuarios.ServicioSaveEntity(XML);

        }

        //Genrar XML Respuesta Liquidador Firmado (SaveEnity).
        public string GenerarXMLRespuestaNPSaveEntity(Int32 In_IdCase, string In_sActoAdm, string In_sEtapa, string In_SResolucion,
                                            string In_SCodDecision, string In_SDireccionPN, string In_SCodDANE,
                                            string In_sSN, string In_sPN, string In_sSA, string In_sPA, string In_sTel,
                                            string In_sTipDoc, string In_SNoIden, string In_BonoPensional)
        {
            Boolean bRes = true;
            string sXML = "";

            sXML += "<BizAgiWSParam>";
            sXML += "<Entities>";
            sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<IdM_DatosActividad>";
            //Tipo de Liquidacion (No es requerido)...
            //sXML += "<IdP_TipoAccion businessKey="SCodColpensiones='FIN'"/>";
            sXML += "<BBonoPensional>false</BBonoPensional>";
            //IdValor no requrido...
            DateTime GenId = DateTime.Now;
            sXML += "<Iid>" + GenId.Year.ToString() + GenId.Month.ToString() + GenId.Day.ToString() + "</Iid>";
            string day = "";
            string mont = "";
            if (GenId.Month.ToString().Length < 2)
            {
                mont = "0" + GenId.Month.ToString().Length;
            }
            else
            {
                mont = GenId.Month.ToString();
            }
            if (GenId.Day.ToString().Length < 2)
            {
                day = "0" + GenId.Day.ToString().Length;
            }
            else
            {
                day = GenId.Day.ToString();
            }
            sXML += "<SFechaString>" + GenId.Year.ToString() + mont + day + "</SFechaString>";
            sXML += "<SParteResolutiva>N/A</SParteResolutiva>";
            sXML += "<SActoAdministrativo>" + In_sActoAdm + "</SActoAdministrativo>";
            sXML += "<IdP_Accion businessKey=\"SEtapa='" + In_sEtapa + "'\"/>";
            sXML += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sXML += "<SFechaActoAdminitrativo>N/A</SFechaActoAdminitrativo>";
            sXML += "<SDominio>domain</SDominio>";
            sXML += "<SResponsable>admon</SResponsable>";
            sXML += "<INumeroActoAdministrativ>" + In_SResolucion + "</INumeroActoAdministrativ>";
            sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_SCodDecision + "'\"/>";

            //BONOS PENSIONALES
            if (In_BonoPensional == "1")
                sXML += "<BBonoPensional>true</BBonoPensional>";
            else
                sXML += "<BBonoPensional>false</BBonoPensional>";

            sXML += "<RC01_DtosAct_Notificar>";
            sXML += "<M_RC01_PersonasNotificar>";
            sXML += "<SDireccion>" + In_SDireccionPN + "</SDireccion>";
            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + In_SCodDANE + "'\"/>";
            sXML += "<SCarta>TEMPORAL</SCarta>";
            if (In_sSN != "NULL")
            {
                sXML += "<SSegundoNombre>" + In_sSN + "</SSegundoNombre>";
            }
            if (In_sPN != "NULL")
            {
                sXML += "<SPrimerNombre>" + In_sPN + "</SPrimerNombre>";
                
            }
            else
            {
                bRes = false;
            }
            //Segundo Apellido
            if (In_sSA != "NULL")
            {
                sXML += "<SSegundoApellido>" + In_sSA + "</SSegundoApellido>";
                //bRes = false;
            }
            else
            {
                //bRes = false;
            }
            //Segundo Apellido
            if (In_sPA != "NULL")
            {
                sXML += "<SPrimerApellido>" + In_sPA + "</SPrimerApellido>";
                //bRes = false;
            }
            else
            {
                bRes = false;
            }
            sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
            //Telefono
            sXML += "<STelefono>" + In_sTel + "</STelefono>";
            //Tipo Identificacion
            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_sTipDoc + "'\"/>";
            //Numero de Idneitificacion
            sXML += "<SNumeroDocumento>" + In_SNoIden + "</SNumeroDocumento>";
            sXML += "</M_RC01_PersonasNotificar>";
            sXML += "</RC01_DtosAct_Notificar>";
            sXML += "</IdM_DatosActividad>";
            sXML += "<M_RC01_PersonasNotificar>";
            //Direccion de la persona a notificar.
            sXML += "<SDireccion>" + In_SDireccionPN + "</SDireccion>";
            //Codigo DANE
            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + In_SCodDANE + "'\"/>";
            sXML += "<SCarta>TEMPORAL</SCarta>";
            //Segundo Nombre
            if (In_sSN != "NULL")
            {
                sXML += "<SSegundoNombre>" + In_sSN + "</SSegundoNombre>";
                //bRes = false;
            }
            else
            {
                //bRes = false;
            }
            //Primer Nombre
            if (In_sPN != "NULL")
            {
                sXML += "<SPrimerNombre>" + In_sPN + "</SPrimerNombre>";
                //bRes = false;
            }
            else
            {
                bRes = false;
            }
            //Segundo Apellido
            if (In_sSA != "NULL")
            {
                sXML += "<SSegundoApellido>" + In_sSA + "</SSegundoApellido>";
                //bRes = false;
            }
            else
            {
                //bRes = false;
            }
            //Segundo Apellido
            if (In_sPA != "NULL")
            {
                sXML += "<SPrimerApellido>" + In_sPA + "</SPrimerApellido>";
                //bRes = false;
            }
            else
            {
                bRes = false;
            }
            sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
            //Telefono
            sXML += "<STelefono>" + In_sTel + "</STelefono>";
            //Tipo Identificacion
            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_sTipDoc + "'\"/>";
            //Numero de Idneitificacion
            sXML += "<SNumeroDocumento>" + In_SNoIden + "</SNumeroDocumento>";
            sXML += "</M_RC01_PersonasNotificar>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</App>";
            sXML += "</Entities>";
            //sXML += "</Event>";
            //sXML += "</Events>";
            sXML += "</BizAgiWSParam>";
            if (bRes == false)
                sXML = "ERROR - " + sXML;

            return sXML;
        }

        //Generar scripts de notificacion directa...
        public string GenerSQLInstanciaNP()
        {
            string sSQL = "";
            Boolean bActivo = false;

            foreach (WorkItem tmpWI in this.DatosBizAgi.CurrentWorkItems)
            {
                var strTmp2324 = tmpWI.Task.TaskName;
                if ((strTmp2324 == "RegistroDeActividades") || (strTmp2324 == "EnDecision") || (strTmp2324 == "EnRevision") || (strTmp2324 == "ParaFirma")
                    || (strTmp2324 == "Firmado") || (strTmp2324 == "Task5") || (strTmp2324 == "tskLiquidacionAutomatico"))
                {
                    if (bActivo == false)
                    {
                        sSQL += "UPDATE WORKITEM SET idTask = 174 WHERE idWorkItem = " + tmpWI.IdWorkItem + " AND idCase = " + this.IdCase + "\n";
                        bActivo = true;
                    }
                    else
                    {
                        sSQL += "UPDATE WORKITEM SET wiClosed = 1 WHERE idWorkItem = " + tmpWI.IdWorkItem + " AND idCase = " + this.IdCase + "\n";
                    }
                }     
            }

            return sSQL;
        }

        //Genrar XML Respuesta Liquidador Firmado.
        public string GenerarXMLRespuestaPA(Int32 In_IdCase, string In_sActoAdm, string In_sEtapa, string In_SResolucion,
                                            string In_SCodDecision, string In_SDireccionPN, string In_SCodDANE,
                                            string In_sSN, string In_sPN, string In_sSA, string In_sPA, string In_sTel,
                                            string In_sTipDoc, string In_SNoIden)
        {
            Boolean bRes = true;
            string sXML = "";

            //sXML += "<Entities>";
            sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<BSiguiente>true</BSiguiente>";
            sXML += "<IdM_DatosActividad>";
            //Tipo de Liquidacion (No es requerido)...
            //sXML += "<IdP_TipoAccion businessKey="SCodColpensiones='FIN'"/>";
            sXML += "<BBonoPensional>false</BBonoPensional>";
            //IdValor no requrido...
            DateTime GenId = DateTime.Now;
            sXML += "<Iid>" + GenId.Year.ToString() + GenId.Month.ToString() + GenId.Day.ToString() + "</Iid>";
            string day = "";
            string mont = "";
            if (GenId.Month.ToString().Length < 2)
            {
                mont = "0" + GenId.Month.ToString().Length;
            }
            else
            {
                mont = GenId.Month.ToString();
            }
            if (GenId.Day.ToString().Length < 2)
            {
                day = "0" + GenId.Day.ToString().Length;
            }
            else
            {
                day = GenId.Day.ToString();
            }
            sXML += "<SFechaString>" + GenId.Year.ToString() + mont + day + "</SFechaString>";
            sXML += "<SParteResolutiva>N/A</SParteResolutiva>";
            //Acto adminitrativo debe ser requerido.
            sXML += "<SActoAdministrativo>" + In_sActoAdm + "</SActoAdministrativo>";
            //La etapa que se quiere avanzar
            sXML += "<IdP_Accion businessKey=\"SEtapa='" + In_sEtapa + "'\"/>";
            sXML += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sXML += "<SFechaActoAdminitrativo>N/A</SFechaActoAdminitrativo>";
            sXML += "<SDominio>domain</SDominio>";
            sXML += "<SResponsable>admon</SResponsable>";
            //Numero Acto Adminitrativo
            sXML += "<INumeroActoAdministrativ>" + In_SResolucion + "</INumeroActoAdministrativ>";
            //sXML += "<SObservaciones>TUA CREADA POR CASO FIRMADO SIN SOP</SObservaciones>";
            //sXML += "<IdP_TipoLiquidacion businessKey="SCodColpensiones='RECONOCIMIENTO'"/>";
            //Codigo colpensiones de la decison.
            sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_SCodDecision + "'\"/>";


            //Persona a notificar solo se puede una....
            sXML += "<RC01_DtosAct_Notificar>";
            sXML += "<M_RC01_PersonasNotificar>";
            //Direccion de la persona a notificar.
            sXML += "<SDireccion>" + In_SDireccionPN + "</SDireccion>";
            //Codigo DANE
            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + In_SCodDANE + "'\"/>";
            sXML += "<SCarta>TEMPORAL</SCarta>";
            //Segundo Nombre
            if (In_sSN != "NULL")
            {
                sXML += "<SSegundoNombre>" + In_sSN + "</SSegundoNombre>";
                //bRes = false;
            }
            else
            {
                //bRes = false;
            }
            //Primer Nombre
            if (In_sPN != "NULL")
            {
                sXML += "<SPrimerNombre>" + In_sPN + "</SPrimerNombre>";
                //bRes = false;
            }
            else
            {
                bRes = false;
            }
            //Segundo Apellido
            if (In_sSA != "NULL")
            {
                sXML += "<SSegundoApellido>" + In_sSA + "</SSegundoApellido>";
                //bRes = false;
            }
            else
            {
                //bRes = false;
            }
            //Segundo Apellido
            if (In_sPA != "NULL")
            {
                sXML += "<SPrimerApellido>" + In_sPA + "</SPrimerApellido>";
                //bRes = false;
            }
            else
            {
                bRes = false;
            }
            sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
            //Telefono
            sXML += "<STelefono>" + In_sTel + "</STelefono>";
            //Tipo Identificacion
            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_sTipDoc + "'\"/>";
            //Numero de Idneitificacion
            sXML += "<SNumeroDocumento>" + In_SNoIden + "</SNumeroDocumento>";
            sXML += "</M_RC01_PersonasNotificar>";


            sXML += "</RC01_DtosAct_Notificar>";
            sXML += "</IdM_DatosActividad>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</App>";
            //sXML += "</Entities>";
    

            if (bRes == false)
                sXML = "ERROR - " + sXML;

            return sXML;
        }

        //Genrar XML Respuesta Liquidador Firmado.
        public string GenerarXMLRespuestaNPSEF(Int32 In_IdCase, string In_sActoAdm, string In_sEtapa, string In_SResolucion,
                                            string In_SCodDecision, string In_SDireccionPN, string In_SCodDANE,
                                            string In_sSN, string In_sPN, string In_sSA, string In_sPA, string In_sTel,
                                            string In_sTipDoc, string In_SNoIden, string In_BonoPensional)
        {
            Boolean bRes = true;
            string sXML = "";

            //sXML += "<BizAgiWSParam>";
            //sXML += "<Events>";
            //sXML += "<Event>";
            //sXML += "<EventData>";
            //sXML += "<idCase>" + In_IdCase + "</idCase>";
            //sXML += "<eventName>RegistroDeActividades</eventName>";
            //sXML += "</EventData>";
            //sXML += "<Entities>";
            //sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<IdM_DatosActividad>";
            sXML += "<BIndicadorApelacion>false</BIndicadorApelacion>";

            //BONOS PENSIONALES
            if (In_BonoPensional == "1")
                sXML += "<BBonoPensional>true</BBonoPensional>";
            else
                sXML += "<BBonoPensional>false</BBonoPensional>";

            DateTime GenId = DateTime.Now;
            sXML += "<Iid>" + GenId.Year.ToString() + GenId.Month.ToString() + GenId.Day.ToString() + "</Iid>";
            string day = "";
            string mont = "";
            if (GenId.Month.ToString().Length < 2)
            {
                mont = "0" + GenId.Month.ToString().Length;
            }
            else
            {
                mont = GenId.Month.ToString();
            }
            if (GenId.Day.ToString().Length < 2)
            {
                day = "0" + GenId.Day.ToString().Length;
            }
            else
            {
                day = GenId.Day.ToString();
            }
            sXML += "<SFechaString>" + GenId.Year.ToString() + mont + day + "</SFechaString>";
            sXML += "<SParteResolutiva>N/A</SParteResolutiva>";
            sXML += "<SActoAdministrativo>" + In_sActoAdm + "</SActoAdministrativo>";
            sXML += "<IdP_Accion businessKey=\"SEtapa='" + In_sEtapa + "'\"/>";
            sXML += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
            sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='RECONOCIMIENTO'\"/>";
            sXML += "<SFechaActoAdminitrativo>N/A</SFechaActoAdminitrativo>";
            sXML += "<SDominio>domain</SDominio>";
            sXML += "<SResponsable>admon</SResponsable>";
            sXML += "<INumeroActoAdministrativ>" + In_SResolucion + "</INumeroActoAdministrativ>";
            sXML += "<SPrefijoNoActoAdm>GNR</SPrefijoNoActoAdm>";
            sXML += "<SObservaciones>Caso ejecutado por Robot..</SObservaciones>";
            sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + In_SCodDecision + "'\"/>";
            sXML += "<RC01_DtosAct_Notificar>";
            sXML += "<M_RC01_PersonasNotificar>";
            sXML += "<SDireccion>" + In_SDireccionPN + "</SDireccion>";
            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + In_SCodDANE + "'\"/>";
            sXML += "<SCarta>TEMPORAL</SCarta>";

            if (In_sSN != "NULL")
            {
                sXML += "<SSegundoNombre>" + In_sSN + "</SSegundoNombre>";
            }
            if (In_sPN != "NULL")
            {
                sXML += "<SPrimerNombre>" + In_sPN + "</SPrimerNombre>";
            }
            else
            {
                bRes = false;
            }
            if (In_sSA != "NULL")
            {
                sXML += "<SSegundoApellido>" + In_sSA + "</SSegundoApellido>";
            }
            if (In_sPA != "NULL")
            {
                sXML += "<SPrimerApellido>" + In_sPA + "</SPrimerApellido>";
            }
            else
            {
                bRes = false;
            }
            sXML += "<BAutorizaNotificacionCor>false</BAutorizaNotificacionCor>";
            sXML += "<STelefono>" + In_sTel + "</STelefono>";
            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + In_sTipDoc + "'\"/>";
            sXML += "<SNumeroDocumento>" + In_SNoIden + "</SNumeroDocumento>";
            //sXML += "<IdP_TipoNotificante businessKey=\"SCodigo='01'\"/>";
            sXML += "</M_RC01_PersonasNotificar>";
            sXML += "</RC01_DtosAct_Notificar>";
            sXML += "</IdM_DatosActividad>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            //sXML += "</App>";
            //sXML += "</Entities>";
            //sXML += "</Event>";
            //sXML += "</Events>";
            //sXML += "</BizAgiWSParam>";
            if (bRes == false)
                sXML = "ERROR - " + sXML;

            return sXML;
        }


        #endregion


    }
}
