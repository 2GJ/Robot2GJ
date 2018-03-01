using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Colpensiones2GJ
{
    public class clsRespuestasLiquidadorReco
    {
        #region Atributos

        private String[] ArrStrLineas;
        private Int32 ILineaActual;
        private char Sep;
        public String RutaDeArchivo;
        public clsRespuestaReconocimiento ResReco;        
        public DataLog LogOk;
        public DataLog LogOFF;
        public DataLog LogDetail;
        public DataLogPantallaMasivo Log;

        #endregion

        #region Constructores

        public clsRespuestasLiquidadorReco(String In_RtaArchivo, char In_Separador)
        {
            this.RutaDeArchivo = In_RtaArchivo;
            this.LogOk = new DataLog(In_RtaArchivo);
            this.LogOk.AddIdName("LogOK");
            this.LogOFF = new DataLog(In_RtaArchivo);
            this.LogOFF.AddIdName("LogOFF");
            this.LogDetail = new DataLog(In_RtaArchivo);
            this.LogDetail.AddIdName("Details");
            this.ArrStrLineas = File.ReadAllLines(this.RutaDeArchivo);
            this.ILineaActual = 0;
            this.Sep = In_Separador;
            //this.Log = null;
        }

        #endregion

        #region Operaciones

        public String EnviarRespuestas()
        {
            this.Log = new DataLogPantallaMasivo(this.ArrStrLineas.Length);

            while (this.ILineaActual < this.ArrStrLineas.Length)
            {
                String[] ArrStrCol = this.CargarLineaArchivo(this.ILineaActual);
                this.GenerarRespuesta(ArrStrCol);
                this.ILineaActual++;
            }

            return this.Log.GetLogPantallaFull();
        }
        public void GenerarRespuesta(String[] InArr)
        {
            try
            {
                this.ResReco = new clsRespuestaReconocimiento(InArr);

                String ResGen = "";
               
                #region VALIDACIONES PREVIAS.

                //1-Validacion si el caso no existe.
                if (this.ResReco.objRec.WFC.idCase == 0)
                {
                    ResGen += " Codigo: NEX Descripcion: 2GJ CASO DE RECONOCIMIENTO NO EXISTE. ";  
                }
                //1.1-Validacion si existe incopnsistencia entre radicado y idcase.
                if (this.ResReco.objRec.WFC.idCase == -1)
                {
                    ResGen += " Codigo: DIF Descripcion: 2GJ RADICADO NO CONCUERDA CON IDCASE. ";
                }
                //2-Validacion si el caso se encuntra cerrado.
                if (Convert.ToBoolean(this.ResReco.objRec.WFC.caseclosed) == true)
                {
                    ResGen += " Codigo: CLS Descripcion: 2GJ CASO CERRADO. ";
                }
                //3-Validacion evento de respuesta liquidador no disponible.
                if (this.ResReco.objRec.DatosBizAgi.BuscarIdTask(168) != true && this.ResReco.objRec.WFC.idCase != 0 && Convert.ToBoolean(this.ResReco.objRec.WFC.caseclosed) != true)
                {
                    ResGen += " Codigo: 168 Descripcion: 2GJ EVENTO DE RESPUESTA LIQUIDADOR NO DISPONIBLE. ";
                }
                //4-Validacion actividad de respuesta liquidador no disponible.
                if ((this.ResReco.objRec.DatosBizAgi.BuscarNameTask("CasoAsignadoAlLiquidador") == false && this.ResReco.objRec.DatosBizAgi.BuscarNameTask("Firmado") == false && this.ResReco.objRec.DatosBizAgi.BuscarNameTask("Task2") == false) && (this.ResReco.objRec.WFC.idCase != 0) && (Convert.ToBoolean(this.ResReco.objRec.WFC.caseclosed) != true))
                {
                    ResGen += " Codigo: TSK Descripcion: 2GJ ACTIVIDAD DE RESPUESTA LIQUIDADOR NO DISPONIBLES. ";
                }
                //5-Validacion de errores generales en consultas de informacion del objeto de reconocimiento.
                if (this.ResReco.objRec.CodError != "OK" && this.ResReco.objRec.WFC.idCase != 0 && Convert.ToBoolean(this.ResReco.objRec.WFC.caseclosed) != true)
                {
                    ResGen += " Codigo: " + this.ResReco.objRec.CodError + " Descripcion: " + this.ResReco.objRec.DesError;
                }

                #endregion

                #region GENERACION RESPUESTA.

                if (ResGen == "")
                {
                    this.ResReco.MapeoDatosGenerales(InArr);

                    String[] ArrNext = null;

                    do
                    {
                        ArrNext = this.TieneNotificantesAdicionales(InArr);
                        if (ArrNext != null)
                            this.ResReco.MapeoDatosNotificantes(ArrNext);
                    } while (ArrNext != null);

                    this.ResReco.GenResXMLRespuesta();
                    this.ResReco.EnviarRespuestaLiquidador();

                    //Realizar Reintento....
                    if (this.ResReco.RunOK == false)
                    {
                        if (this.ResReco.ValidarSiExisteSolucion())
                        {
                            this.ResReco.GenResXMLRespuesta();
                            this.ResReco.EnviarRespuestaLiquidador();
                        }
                    }

                    if (this.ResReco.RunOK == true)
                    {
                        this.LogOk.AddLine(this.ArrStrLineas[this.ILineaActual].ToString() + "\t" + this.ResReco.GetStringCapaSOARespuesta() + "\t" + this.ResReco.objRec.DatosBizAgi.LogIdWorkItem());
                        this.Log.AdicionarProcesadoOK();
                    }
                    else
                    {
                        this.LogOFF.AddLine(this.ArrStrLineas[this.ILineaActual].ToString() + "\t" + this.ResReco.GetStringCapaSOARespuesta() + "\t" + this.ResReco.objRec.DatosBizAgi.LogIdWorkItem());
                        this.LogDetail.AddLine(this.ResReco.GetStringCapaSOARespuestaDetails());
                        this.Log.AdicionarProcesadoOFF();
                    }
                }
                else
                {
                    this.LogOFF.AddLine(this.ArrStrLineas[this.ILineaActual].ToString() + "\t" + ResGen + "\t" + this.ResReco.objRec.DatosBizAgi.LogIdWorkItem());
                    this.LogDetail.AddLine("IDCASE: " + this.ResReco.objRec.IdCase.ToString() + "\t RADNUMBER: " + this.ResReco.objRec.RadNumber + "\n" + this.ResReco.objRec.GetREspuestaFull() + "\n");
                    this.Log.AdicionarProcesadoOFF();
                }

                #endregion
            }
            catch (Exception e)
            {
                var A = e.Message;
                this.LogOFF.AddLine(this.ArrStrLineas[this.ILineaActual].ToString() + "\t" + "Codigo: .NET Descripcion: " + e.Message.ToString());
            }
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
        }
        public String[] TieneNotificantesAdicionales(String[] InArr)
        {
            String[] arrNext = this.ProximoArrayArchivo(InArr);

            if (arrNext != null)
            {
                if (arrNext[0] == InArr[0])
                {
                    this.ILineaActual += 1;
                    return arrNext;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public String[] ProximoArrayArchivo (String[] InArr)
        {
            String[] ArrStrColNext = null;
            //this.ILineaNotificantes = this.ILineaActual;
            if ((this.ILineaActual + 1) < this.ArrStrLineas.Length)
            {
                ArrStrColNext = this.CargarLineaArchivo(this.ILineaActual + 1);
            }
            else
            {
                ArrStrColNext = null;
            }
            return ArrStrColNext;
        }
        private String[] CargarLineaArchivo(Int32 In_Linea)
        {
            char[] Separador = new char[] { this.Sep };
            //String[] ArrStrCol = this.ArrStrLineas[In_Linea].Split(Separador, StringSplitOptions.RemoveEmptyEntries);
            String[] ArrStrCol = this.ArrStrLineas[In_Linea].Split(Separador);
            return ArrStrCol;
        }

        #endregion
    }

    public class clsRespuestaReconocimiento
    {
        #region Atributos

        private Int32 IdCase;
        private String SRadNumber;
        private clsPersonaNotificar Causante;
        private List<clsPersonaNotificar> Notificantes { get; set; } 
        public String sDescripcionRespuesta;
        public String sDetalleRespuesta;
        public Reconocimiento objRec;
        public String XMLResLiq;
        public bool RunOK;
        private CapaSOABizAgi ObjCSOA;

        private bool cmpBSiguiente;
        private string cmpIdP_TipoAccion;
        private bool cmpBBonoPensional;
        private Int32 cmpIid;
        private DateTime cmpFechaString;
        private string cmpIdP_Accion;
        private string cmpDominioUsuAct;
        private string cmpUsuarioAct;
        private String cmpObservaciones;
        private string cmpUsuAnalista;
        private string cmpDomAnalista;
        private string cmpUsuRevisor;
        private string cmpDomRevisor;
        private string cmpUsuLider;
        private string cmpDomLider;
        private string cmpUsuCoor;
        private string cmpDomCoor;
        private string cmpUsuSuscriptor;
        private string cmpDomSuscriptor;
        private Int32 cmpNumeroActoAdm;
        private DateTime cmpFechaActoAdm;
        private string cmpTipoLiquidacion;
        private string cmpDecision;
        private string cmpPrefijo;
        private String cmpActoAdministrativo;
        private String cmpParteResolutiva;
        private bool cmpIndicadorApelacion;
        private bool cmpIndicadorRetiro;

        #endregion

        #region Constructores

        public clsRespuestaReconocimiento(String[] In_Arr)
        {
            this.IdCase = Convert.ToInt32(In_Arr[0]);
            this.SRadNumber = In_Arr[1];

            //Consultar Estado del Caso...
            this.objRec = new Reconocimiento(this.SRadNumber, this.IdCase);
            this.objRec.Get_InfoRecByQueryForm();
            if (this.objRec.WFC.idCase == 0)
            {
                this.RunOK = false;
                this.objRec.CodError = "-1";
                this.objRec.DesError = "CASO RECONOCIMIENTO NO EXISTE.";
                objRec.GetActividadEtapaActual();
                objRec.Reconocimiento_CargarDatosBizAgi();
                if ((this.objRec.CodError == "-1") && (this.objRec.DatosBizAgi.CaseClosed == false))
                {
                    this.RunOK = true;
                    this.objRec.CodError = "OK";
                    this.objRec.DesError = null;
                    this.objRec.WFC.idCase = Convert.ToInt32(this.objRec.DatosBizAgi.IdCase);
                }
            }
            else
            {
                //Informacion de Reconocimiento...
                objRec.Get_InformacionReconocimiento();
                //Informacion de Actividad Actual...
                objRec.GetActividadEtapaActual();
                //Consulta informacion BizAgi...
                objRec.Reconocimiento_CargarDatosBizAgi();
                //this.Causante = new clsPersonasNotificar();
                this.RunOK = false;
                
            }
            this.Notificantes = new List<clsPersonaNotificar>();
            this.ObjCSOA = new CapaSOABizAgi();
        }

        #endregion

        #region Operaciones

        public void MapeoDatosGenerales(String[] In_Arr)
        {
            try
            {
                //CAMPOS FIJOS O POR DEFECTO......
                this.cmpBSiguiente = true;
                this.cmpIdP_TipoAccion = "FIN";
                this.SetDefaultcmpIid();
                this.SetDefaultcmpFechaString();
                this.SetDefaultcmpObservaciones();
                this.SetDefaultcmpTipoLiquidacion();
                this.SetDefaultcmpParteResolutiva();

                this.cmpDominioUsuAct = null;
                this.cmpDomAnalista = null;
                this.cmpDomRevisor = null;
                this.cmpDomLider = null;
                this.cmpDomCoor = null;
                this.cmpDomSuscriptor = null;

                this.cmpFechaActoAdm = DateTime.Now;

                //MAPEO DE CAMPOS DESDE ARCHIVO PLANO.....
                this.cmpIdP_Accion = In_Arr[2]; //ETAPA.  
                this.cmpUsuAnalista = In_Arr[3]; //USUARIO INSERCION EN EL LIQUIDADOR.
                this.cmpUsuarioAct = In_Arr[3]; //USUARIO INSERCION EN EL LIQUIDADOR.
                this.cmpUsuRevisor = In_Arr[4]; //USUARIO REVISOR USERNAME.
                this.cmpUsuLider = In_Arr[5]; //USUARIO LIDER USERNAME.
                this.cmpUsuCoor = In_Arr[6]; //USUARIO COORDINADOR.
                this.cmpUsuSuscriptor = In_Arr[7]; //USUARIO SUSCRIPTOR EN EL LIQUIDADOR.
                         
                this.cmpActoAdministrativo = In_Arr[8]; //GUID ACTO ADMINISTRATIVO.
                this.cmpPrefijo = In_Arr[9]; //PREFIJO DEL ACTO ADMINISTRATIVO.
                this.cmpNumeroActoAdm = Convert.ToInt32(In_Arr[10]); //NUMERO ACTO ADMINISTRATIVO.
                this.cmpDecision = In_Arr[11]; //DECISION.
                
               
                //DEPARTAMENTO.[12]          -> Parametro 1 Persona Notificar.
                //MUNICIPIO.[13]             -> Parametro 2 Persona Notificar.
                //DIRECCION.[14]             -> Parametro 9 Persona Notificar.
                //TIPO DOCUMENTO.[15]        -> Parametro 3 Persona Notificar.
                //NUMERO DOCUMENTO.[16]      -> Parametro 4 Persona Notificar.
                //PRIMER APELLIDO.[17]      -> Parametro 7 Persona Notificar.
                //PRIMER NOMBRE.[18]        -> Parametro 5 Persona Notificar.
                //SEGUNDO APELLIDO.[19]     -> Parametro 8 Persona Notificar.
                //SEGUNDO NOMBRE.[20]       -> Parametro 6 Persona Notificar.
                

                var Tel = In_Arr[21] + " " + In_Arr[22];  //TELEFONO (TELEFONO FIJO Y CELULAR) -> Parametro 10 Persona Notificar.
                Tel.Trim();

                this.SetValuecmpBonoPensionalFromString(In_Arr[23]); //INDICADOR DE BONO PENSIONAL.
                this.SetValuecmpIndicadorApelacionFromString(In_Arr[24]); //INDICADOR DE APELACION.
                this.SetValuecmpIndicadorRetiroFromString(In_Arr[25]); //INDICADOR RETIRO DEFINITIVO.

                //TIPO PERSONA.[26]       -> Parametro 11 Persona Notificar.
                          
                this.Causante = new clsPersonaNotificar(In_Arr[12], In_Arr[13], In_Arr[15], In_Arr[16], In_Arr[18], In_Arr[20]
                                                            , In_Arr[17], In_Arr[19], In_Arr[14], Tel, In_Arr[26]);
            }
            catch (Exception e1)
            {
                
            }

        }
        public void MapeoDatosNotificantes(String[] In_ArrNot)
        {
            if (this.ExisteNotificante(In_ArrNot[15], In_ArrNot[16]) == false)
            {
                var Tel = In_ArrNot[21] + " " + In_ArrNot[22];  //TELEFONO (TELEFONO FIJO Y CELULAR) -> Parametro 10 Persona Notificar.
                Tel.Trim();

                clsPersonaNotificar objNot = new clsPersonaNotificar(In_ArrNot[12], In_ArrNot[13], In_ArrNot[15], In_ArrNot[16], In_ArrNot[18], In_ArrNot[20]
                                                                , In_ArrNot[17], In_ArrNot[19], In_ArrNot[14], Tel, In_ArrNot[26]);

                this.Notificantes.Add(objNot);
            }
        }
        public bool ExisteNotificante(String In_TipoId, String In_Snumero)
        { 
            bool Respuesta = false;

            if (this.Causante.tipoIdent == In_TipoId && this.Causante.numIdent == In_Snumero)
            {
                Respuesta = true;
            }
            else
            {
                foreach (var Not in this.Notificantes)
                {
                    if (Not.tipoIdent == In_TipoId && Not.numIdent == In_Snumero)
                    {
                        Respuesta = true;
                    }
                }
            }

            return Respuesta;
        }
        public void EnviarRespuestaLiquidador()
        {
            this.ObjCSOA.Servicio_SetEvent_ByIdCaseEventNameXML(this.IdCase, "RegistroDeActividades", this.XMLResLiq);
            //this.ObjCSOA.Servicio_SetEvent_ByIdCaseEventNameXML(this.IdCase, 168, this.XMLResLiq);

            if (this.ObjCSOA.GetRespuesta().Contains("EJECUCION CORRECTA..."))
            {
                this.RunOK = true;
            }
            else
            {
                this.RunOK = false;
            }
        }
        public void GenResXMLRespuesta()
        {
            Boolean bRes = true;
            string sXML = "";

            sXML += "<M_cat_Reconocimiento>";
            sXML +=     "<IdM_RC01Reconocimiento>";
            //sXML +=         "<BSiguiente>" + this.GetStringcmpBSiguiente() + "</BSiguiente>";
            sXML +=         "<IdM_DatosActividad>";
            sXML +=         "<Iid>" + this.GetStringcmpIid() + "</Iid>";
            sXML +=         "<IdP_Accion businessKey=\"SEtapa='" + this.GetStringcmpIdP_Accion() + "'\"/>";
            sXML +=             "<IdP_TipoAccion businessKey=\"SCodColpensiones='" + this.GetStringcmpIdP_TipoAccion()  + "'\"/>";
            sXML +=             "<SFechaString>" + this.GetStringcmpFechaString() + "</SFechaString>";
            sXML +=             "<SDominio>" + this.GetStringcmpDominioUsuAct() + "</SDominio>";
            sXML +=             "<SResponsable>" + this.GetStringcmpUsuarioAct() + "</SResponsable>";
            sXML +=             "<SObservaciones>" + this.GetStringcmpObservaciones() + "</SObservaciones>";
            sXML +=             "<IdM_UsuariosLiquidador>";
            sXML +=                 "<SUsuAnalista>" + this.GetStringcmpUsuAnalista() + "</SUsuAnalista>";
            sXML +=                 "<SDomUsuAnalista>" + this.GetStringcmpDomAnalista() + "</SDomUsuAnalista>";
            sXML +=                 "<SUsuRevisor>" + this.GetStringcmpUsuRevisor() + "</SUsuRevisor>";
            sXML +=                 "<SDomUsuRevisor>" + this.GetStringcmpDomRevisor() + "</SDomUsuRevisor>";
            sXML +=                 "<SUsuLider>" + this.GetStringcmpUsuLider() + "</SUsuLider>";
            sXML +=                 "<SDomUsuLider>" + this.GetStringcmpDomLider() + "</SDomUsuLider>";
            sXML +=                 "<SUsuCoordinador>" + this.GetStringcmpUsuCoor() + "</SUsuCoordinador>";
            sXML +=                 "<SDomUsuCoordinador>" + this.GetStringcmpDomCoor() + "</SDomUsuCoordinador>";
            sXML +=                 "<SUsuSuscriptor>" + this.GetStringcmpUsuSuscriptor() + "</SUsuSuscriptor>";
            sXML +=                 "<SDomUsuSuscriptor>" + this.GetStringcmpDomSuscriptor() + "</SDomUsuSuscriptor>";
            sXML +=             "</IdM_UsuariosLiquidador>";

            if (this.cmpIdP_Accion == "70" || this.cmpIdP_Accion == "80" || this.cmpIdP_Accion == "84" || this.cmpIdP_Accion == "85" || this.cmpIdP_Accion == "110")
            {
                sXML += "<INumeroActoAdministrativ>" + this.GetStringcmpNumeroActoAdm() + "</INumeroActoAdministrativ>";
                sXML += "<SFechaActoAdminitrativo>" + this.GetStringcmpFechaActAdm() + "</SFechaActoAdminitrativo>";
                sXML += "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='" + this.GetStringcmpTipoLiquidacion() + "'\"/>";
                sXML += "<IdP_Decision businessKey=\"SCodColpensiones='" + this.GetStringcmpDecision() + "'\"/>";
                sXML += "<SPrefijoNoActoAdm>" + this.GetStringcmpPrefijo() + "</SPrefijoNoActoAdm>";
                sXML += "<SActoAdministrativo>" + this.GetStringcmpActoAdministrativo() + "</SActoAdministrativo>";
                sXML += "<SParteResolutiva>" + this.GetStringcmpParteResolutiva() + "</SParteResolutiva>";
                sXML += "<BBonoPensional>" + this.GetStringcmpBBonoPensional() + "</BBonoPensional>";
                sXML += "<BIndicadorApelacion>" + this.GetStringcmpIndicadorApelacion() + "</BIndicadorApelacion>";
                

                //PERSONAS A NOTIFICAR....
                sXML += "<RC01_DtosAct_Notificar>";

                //Causante....
                sXML += "<M_RC01_PersonasNotificar>";

                    sXML += "<IdP_TipoNotificante businessKey=\"SCodigo='" + this.Causante.tipoPersona.ToString() + "'\"/>";
                    sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + this.Causante.tipoIdent.ToString() + "'\"/>";
                    sXML += "<SNumeroDocumento>" + this.Causante.numIdent + "</SNumeroDocumento>";
                    sXML += "<SPrimerNombre>" + this.Causante.GetXMLPrimerNombre() + "</SPrimerNombre>";
                    sXML += "<SSegundoNombre>" + this.Causante.GetXMLSegundoNombre() + "</SSegundoNombre>";
                    sXML += "<SPrimerApellido>" + this.Causante.GetXMLPrimerApellido() + "</SPrimerApellido>";
                    sXML += "<SSegundoApellido>" + this.Causante.GetXMLSegundoApellido() + "</SSegundoApellido>";
                    sXML += "<SDireccion>" + this.Causante.direccion + "</SDireccion>";
                    sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + this.Causante.GetXMLCodigoDane() + "'\"/>";
                    sXML += "<STelefono>" + this.Causante.telefono + "</STelefono>";
                        this.Causante.SetDefaultXMLAutorizadoNotificar();
                    sXML += "<BAutorizaNotificacionCor>" + this.Causante.GetXMLAutorizoNotidicarStr() + "</BAutorizaNotificacionCor>";
                        this.Causante.SetDefaultXMLCorreoElectronico();
                    sXML += "<SCorreo>" + this.Causante.GetXMLCorreoElectronico() + "</SCorreo>";
                        this.Causante.SetDefaultXMLFax();
                    sXML += "<SFax>" + this.Causante.GetXMLFax() + "</SFax>";
                        this.Causante.SetDefaultXMLCarta();
                    sXML += "<SCarta>" + this.Causante.GetXMLCarta() + "</SCarta>";

                sXML += "</M_RC01_PersonasNotificar>";
                //...Causante.

                //Empleadores y Otros....
                if (this.Notificantes != null)
                {
                    foreach (var tmp in this.Notificantes)
                    {
                        sXML += "<M_RC01_PersonasNotificar>";
                            sXML += "<IdP_TipoNotificante businessKey=\"SCodigo='" + tmp.tipoPersona.ToString() + "'\"/>";
                            sXML += "<IdP_TipoDocumento businessKey=\"SCodigo='" + tmp.tipoIdent.ToString() + "'\"/>";
                            sXML += "<SNumeroDocumento>" + tmp.numIdent + "</SNumeroDocumento>";
                            sXML += "<SPrimerNombre>" + tmp.GetXMLPrimerNombre() + "</SPrimerNombre>";
                            sXML += "<SSegundoNombre>" + tmp.GetXMLSegundoNombre() + "</SSegundoNombre>";
                            sXML += "<SPrimerApellido>" + tmp.GetXMLPrimerApellido() + "</SPrimerApellido>";
                            sXML += "<SSegundoApellido>" + tmp.GetXMLSegundoApellido() + "</SSegundoApellido>";
                            sXML += "<SDireccion>" + tmp.direccion + "</SDireccion>";
                            sXML += "<IdP_Ciudad businessKey=\"SCodigo='" + tmp.GetXMLCodigoDane() + "'\"/>";
                            sXML += "<STelefono>" + tmp.telefono + "</STelefono>";
                            tmp.SetDefaultXMLAutorizadoNotificar();
                            sXML += "<BAutorizaNotificacionCor>" + tmp.GetXMLAutorizoNotidicarStr() + "</BAutorizaNotificacionCor>";
                            tmp.SetDefaultXMLCorreoElectronico();
                            sXML += "<SCorreo>" + tmp.GetXMLCorreoElectronico() + "</SCorreo>";
                            tmp.SetDefaultXMLFax();
                            sXML += "<SFax>" + tmp.GetXMLFax() + "</SFax>";
                            tmp.SetDefaultXMLCarta();
                            sXML += "<SCarta>" + tmp.GetXMLCarta() + "</SCarta>";
                            sXML += "</M_RC01_PersonasNotificar>";
                    }
                }
                //...Empleadores y Otros.

                //...PERSONAS A NOTIFICAR.
                sXML += "</RC01_DtosAct_Notificar>";
                sXML += "</IdM_DatosActividad>";
                sXML += "</IdM_RC01Reconocimiento>";
                sXML += "</M_cat_Reconocimiento>";
                
            }

            this.XMLResLiq = sXML;
        }
        public Boolean ValidarSiExisteSolucion()
        {
            String strtmp = this.GetStringCapaSOARespuesta();
            if (strtmp.Contains("Etapa no valida para liquidación automática, la etapa enviada debe ser 110."))
            {
                //Se envia respuesta por la etapa 110.
                this.cmpIdP_Accion = "110";
            }

            return true;
        }

        #endregion

        #region SetersDefault

        private void SetDefaultcmpParteResolutiva()
        {
            this.cmpParteResolutiva = "1";
        }
        private void SetDefaultcmpFechaString()
        {
            this.cmpFechaString = DateTime.Now;
        }
        private void SetDefaultcmpIid()
        {
            this.cmpIid = Convert.ToInt32(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
        }
        private void SetDefaultcmpObservaciones()
        {
            this.cmpObservaciones = "Respuesta liquidador por medio de Robot.";
        }
        private void SetDefaultcmpTipoLiquidacion()
        {
            this.cmpTipoLiquidacion = "RECONOCIMIENTO";
        }

        #endregion

        #region SetersValue

        private void SetValuecmpBonoPensionalFromString(string In_str)
        {
            if (In_str == "0")
                this.cmpBBonoPensional = false;
            else if (In_str == "1")
                this.cmpBBonoPensional = true;
            else
                this.cmpBBonoPensional = false;
        }
        private void SetValuecmpIndicadorRetiroFromString(string In_str)
        {
            if (In_str == "0")
                this.cmpIndicadorRetiro = false;
            else if (In_str == "1")
                this.cmpIndicadorRetiro = true;
            else
                this.cmpIndicadorRetiro = false;

        }
        private void SetValuecmpIndicadorApelacionFromString(string In_str)
        {
            if (In_str == "0")
                this.cmpIndicadorApelacion = false;
            else if (In_str == "1")
                this.cmpIndicadorApelacion = true;
            else
                this.cmpIndicadorApelacion = false;
        }

        #endregion

        #region Geters

        public String GetStringCapaSOARespuestaDetails()
        {
            return "IDCASE: " + this.IdCase.ToString() + "\t RADNUMBER: " + this.SRadNumber + "\n" + this.ObjCSOA.GetLogFull();
        }
        public String GetStringCapaSOARespuesta()
        {
            return this.ObjCSOA.GetRespuesta();
        }
        private string GetStringcmpPrefijo()
        {
            return this.cmpPrefijo;
        }
        private String GetStringcmpIndicadorRetiro()
        {
            if (this.cmpIndicadorApelacion == true)
                return "true";
            else
                return "false";
        }
        private String GetStringcmpIndicadorApelacion()
        {
            if (this.cmpIndicadorApelacion == true)
                return "true";
            else
                return "false";
        }
        private String GetStringcmpParteResolutiva()
        {
            return this.cmpParteResolutiva;
        }
        private String GetStringcmpActoAdministrativo()
        {
            return this.cmpActoAdministrativo;
        }
        private string GetStringcmpDecision()
        {
            return this.cmpDecision;
        }
        private string GetStringcmpTipoLiquidacion()
        {
            return this.cmpTipoLiquidacion;
        }
        private string GetStringcmpFechaActAdm()
        {
            string mont = "01";
            if (this.cmpFechaActoAdm.Month.ToString().Length < 2)
            {
                mont = "0" + this.cmpFechaActoAdm.Month.ToString();
            }
            else
            {
                mont = this.cmpFechaActoAdm.Month.ToString();
            }

            string day = "01";
            if (this.cmpFechaActoAdm.Day.ToString().Length < 2)
            {
                day = "0" + this.cmpFechaActoAdm.Day.ToString();
            }
            else
            {
                day = this.cmpFechaActoAdm.Day.ToString();
            }
            return this.cmpFechaActoAdm.Year.ToString() + mont + day;
        }
        private string GetStringcmpNumeroActoAdm()
        {
            if (this.cmpNumeroActoAdm != null)
                return Convert.ToString(this.cmpNumeroActoAdm);
            else
                return "0";
        }
        private string GetStringcmpDomSuscriptor()
        {
            if (this.cmpUsuSuscriptor != null && this.cmpUsuSuscriptor != "")
            {
                return this.cmpDomSuscriptor = "domain";
            }
            else
            {
                return this.cmpDomSuscriptor;
            }
        }
        private string GetStringcmpUsuSuscriptor()
        {
            return this.cmpUsuSuscriptor;
        }
        private string GetStringcmpDomCoor()
        {
            if (this.cmpUsuCoor != null && this.cmpUsuCoor != "")
            {
                return this.cmpDomCoor = "domain";
            }
            else
            {
                return this.cmpDomCoor;
            }
        }
        private string GetStringcmpUsuCoor()
        {
            return this.cmpUsuCoor;
        }
        private string GetStringcmpDomLider()
        {
            if (this.cmpUsuLider != null && this.cmpUsuLider != "")
            {
                return this.cmpDomLider = "domain";
            }
            else
            {
                return this.cmpDomLider;
            }
        }
        private string GetStringcmpUsuLider()
        {
            return this.cmpUsuLider;
        }
        private string GetStringcmpDomRevisor()
        {
            if (this.cmpUsuRevisor != null && this.cmpUsuRevisor != "")
            {
                return this.cmpDomRevisor = "domain";
            }
            else
            {
                return this.cmpDomRevisor;
            }
        }
        private string GetStringcmpUsuRevisor()
        {
            return this.cmpUsuRevisor;
        }
        private string GetStringcmpDomAnalista()
        {
            if (this.cmpUsuAnalista != null && this.cmpUsuAnalista != "")
            {
                return this.cmpDomAnalista = "domain";
            }
            else
            {
                return this.cmpDomAnalista;
            }
        }
        private string GetStringcmpUsuAnalista()
        {
            return this.cmpUsuAnalista;
        }
        private String GetStringcmpObservaciones()
        {
            return this.cmpObservaciones;
        }
        private string GetStringcmpUsuarioAct()
        {
            return this.cmpUsuarioAct;
        }
        private string GetStringcmpDominioUsuAct()
        {
            return this.cmpDominioUsuAct;
        }
        private string GetStringcmpIdP_Accion()
        {
            return this.cmpIdP_Accion;
        }
        private string GetStringcmpFechaString()
        {
            string mont = "01";
            if (this.cmpFechaString.Month.ToString().Length < 2)
            {
                mont = "0" + this.cmpFechaString.Month.ToString();
            }
            else
            {
                mont = this.cmpFechaString.Month.ToString();
            }

            string day = "01";
            if (this.cmpFechaString.Day.ToString().Length < 2)
            {
                day = "0" + this.cmpFechaString.Day.ToString();
            }
            else
            {
                day = this.cmpFechaString.Day.ToString();
            }
            return this.cmpFechaString.Year.ToString() + mont + day;
        }
        private string GetStringcmpIid()
        {
            if (this.cmpIid != null)
                return Convert.ToString(this.cmpIid);
            else
                return "0";
        }
        private string GetStringcmpBBonoPensional()
        {
            if (this.cmpBBonoPensional == true)
                return "true";
            else
                return "false";
        }       
        private string GetStringcmpIdP_TipoAccion()
        {
            return this.cmpIdP_TipoAccion.ToString();
        }       
        private string GetStringcmpBSiguiente()
        {
            if (this.cmpBSiguiente == true)
                return "true";
            else
                return "false";
        }

        #endregion
    }

    public class clsPersonaNotificar
    {

        #region Atributos

        private String primerNombre;
        private String segundoNombre;
        private String primerApellido;
        private String segundoApellido;
        private String codDepartamento;
        private String codMunicipio;
        private bool AutorizaNotificar;
        private String CorreoElectronico;
        private string Fax;
        private String Carta;
        public String codigoDANE;
        public String tipoIdent;
        public String numIdent;
        public String direccion;
        public String telefono;
        public String tipoPersona;
        public Int64 IdTipoNotificante;
        public Int64 Id;

        #endregion

        #region Constructores

        public clsPersonaNotificar(String codDepartamento, String codMunicipio, String tipoIdent,
            String numIdent, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido,
            String direccion, String telefono, String tipoPersona)
        {
            this.codDepartamento = codDepartamento;
            this.codMunicipio = codMunicipio;
            this.tipoIdent = tipoIdent;
            this.numIdent = numIdent;
            this.primerNombre = primerNombre;
            this.segundoNombre = segundoNombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.tipoPersona = tipoPersona;
        }

        public clsPersonaNotificar()
        {
        }

        #endregion

        #region Seters
        
        public void SetDefaultXMLFax()
        {
            this.Fax = null;
        }
        public void SetDefaultXMLCarta()
        {
            this.Carta = null;
        }
        public void SetDefaultXMLAutorizadoNotificar()
        {
            this.AutorizaNotificar = false;
        }
        public void SetDefaultXMLCorreoElectronico()
        {
            this.CorreoElectronico = null;
        }
        public string GetXMLCarta()
        {
            return this.Carta;
        }
        public string GetXMLFax()
        {
            return this.Fax;
        }

        #endregion

        #region Geters

        public string GetXMLAutorizoNotidicarStr()
        {
            return this.AutorizaNotificar.ToString();
        }
        public String GetXMLCorreoElectronico()
        {
            return this.CorreoElectronico;
        }
        public String GetXMLPrimerNombre()
        {
            if ((this.primerNombre == null) || (this.primerNombre == "NULL"))
            {
                return "2GJDNVALXML";
            }
            else
            {
                return this.primerNombre;
            }
        }
        public String GetXMLPrimerApellido()
        {
            if (((this.primerApellido == null) || (this.primerApellido == "NULL")) && (this.tipoPersona != "02"))
            {
                return "2GJDNVALXML";
            }
            else
            {
                if (this.tipoPersona != "02")
                    return this.primerApellido;
                else
                    return null;
            }
        }
        public String GetXMLSegundoNombre()
        {
            if ((this.segundoNombre == null) || (this.segundoNombre == "NULL"))
            {
                return null;
            }
            else
            {
                return this.segundoNombre;
            }
        }
        public String GetXMLSegundoApellido()
        {
            if ((this.segundoApellido == null) || (this.segundoApellido == "NULL"))
            {
                return null;
            }
            else
            {
                return this.segundoApellido;
            }
        }
        public String GetXMLCodigoDane()
        {
            String sCodDepartamento;
            
            if (this.codDepartamento.Length == 1)
            {
                sCodDepartamento = "0" + this.codDepartamento;
            }
            else if (this.codDepartamento.Length == 2)
            {
                sCodDepartamento = this.codDepartamento;
            }
            else
            {
                sCodDepartamento = "2GJDNVALXML";
            }

            String sCodMunicipio;
           
            if (this.codMunicipio.Length == 1)
            {
                sCodMunicipio = "00" + this.codMunicipio;
            }
            else if (this.codMunicipio.Length == 2)
            {
                sCodMunicipio = "0" + this.codMunicipio;
            }
            else if (this.codMunicipio.Length == 3)
            {
                sCodMunicipio = this.codMunicipio;
            }
            else
            {
                sCodMunicipio = "2GJDNVALXML";
            }

            return sCodDepartamento + sCodMunicipio;
        }

        #endregion

    }
}
