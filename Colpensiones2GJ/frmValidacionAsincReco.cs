using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
//using ColpensionesBC;

namespace Colpensiones2GJ
{
    public partial class frmValidacionAsincReco : Form
    {
        public frmValidacionAsincReco()
        {
            InitializeComponent();
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            } 
        }

        private void btLeerArchivo_Click(object sender, EventArgs e)
        {

            int Contador = 0;
            bool Reintentar = false;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");
                                       
                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();
                               
                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();
                
                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    Reintentar = false;

                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        rtbResultado.Text += strLineArzay[i] + "\t";
                    }


                    string ResLog = "";
                    string ResSol = "";

                    //Inicia Objeto reconocimiento
                    Reconocimiento objReconcimiento = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));

                                 
                    //Reliza perform Activity
                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                    
                    string sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objReconcimiento.IdCase, Convert.ToInt32(strLineArzay[2]));
                                       

                    //Identificacion de incidentes o errores por actividad:
                    if (this.chkActSol.Checked == true)
                    {
                        if (Convert.ToInt32(strLineArzay[2]) == 141)
                        {
                            //Incidente en definicion de usuario sustanciador y revisor....
                            if (sRespBA.Contains("UsuarioSustanciador Debe tener una longitud de 5 a 20 caracteresUsuarioSustanciador no es válido")
                                || sRespBA.Contains("UsuarioRevisor Debe tener una longitud de 5 a 20 caracteresUsuarioRevisor no es válido"))
                            {
                                objReconcimiento.Reconocimiento_CargarDatosBizAgi();

                                foreach (WorkItem tmpWI in objReconcimiento.DatosBizAgi.CurrentWorkItems)
                                {
                                    if (tmpWI.Task.IdTask == 141)
                                    {
                                        ResSol = "UPDATE WORKITEM SET idTask = 4677 WHERE idworkitem = " + tmpWI.IdWorkItem;
                                    }
                                }
                            }
                        }
                        if (Convert.ToInt32(strLineArzay[2]) == 59330)
                        {
                            objReconcimiento.Get_InformacionReconocimiento();
                            objReconcimiento.Get_InfoNotificantesReconocimiento();
                            objReconcimiento.SaveEntityForIncRazonSocial();

                            Reintentar = true;

                            ////Consultar Estado del Caso...
                            //Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                            ////Informacion de Reconocimiento...
                            //objRec.Get_InformacionReconocimiento();
                            ////Informacion de Actividad Actual...
                            //objRec.GetActividadEtapaActual();
                            ////Consulta informacion BizAgi...
                            //objRec.Reconocimiento_CargarDatosBizAgi();
                        }
                    }


                    //Acciones por tipos de error.....
                    if (sRespBA.Contains("ind_automatico, 1802, Campo ind_automatico esta en S y no cumple las condiciones"))
                    {
                        //Validar si tiene error en el tipo de liquidacion. 
                        string A = objReconcimiento.Get_TipoLiquidacion(); 
                        //Actualizar tipo liquidacion por id

                        if (A != "OK")
                        {
                            string sSaveEntity = "";
                            sSaveEntity += "<BizAgiWSParam>";
                            sSaveEntity += "<Entities idCase=\"" + strLineArzay[0] + "\">";
                            sSaveEntity += "<M_cat_Reconocimiento>";
                            sSaveEntity += "<IdM_RC01Reconocimiento>";
                            sSaveEntity += "<IdM_DatosReconocimientoA>";
                            sSaveEntity += "<IdP_TipoLiquidacion>" + A + "</IdP_TipoLiquidacion>";
                            sSaveEntity += "</IdM_DatosReconocimientoA>";
                            sSaveEntity += "</IdM_RC01Reconocimiento>";
                            sSaveEntity += "</M_cat_Reconocimiento>";
                            sSaveEntity += "</Entities>";
                            sSaveEntity += "</BizAgiWSParam>";

                            CapaSOABizAgi objCapaSoaTL = new CapaSOABizAgi();
                            string s = objCapaSoaTL.ServicioSaveEntity(sSaveEntity);

                            Reintentar = true;
                        }
                        else
                        {
                            Reintentar = false;
                        }

                    }
                    else if (sRespBA.Contains("Observación no es válido, debe ingresar un valor cuando el tipo de trámite es ACTUALIZAR"))
                    {
                        //Actualizar caso con el campo de tipo accion liquidador en actulizar.
                        CapaSOABA.EntityManagerSOASoapClient objSEError891 = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                        string sTmp123 = "<BizAgiWSParam><Entities idCase=\"" + strLineArzay[0] + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><SObservaciones>Actualizacion Automatica del Caso</SObservaciones></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                        string sResSE = objSEError891.saveEntityAsString(sTmp123);
                    }
                    else if (sRespBA.Contains("TipoLiquidacion Debe tener una longitud de 13 a 14 caracteres TipoLiquidacion no es válido, solo se permiten letras en mayúscula y sin tildes, debe ingresar alguna de las siguientes opciones: [RELIQUIDACION|RECONOCIMIENTO]") ||
                             sRespBA.Contains("TipoLiquidacion Debe tener una longitud de 13 a 14 caracteresTipoLiquidacion no es válido, solo se permiten letras en mayúscula y sin tildes, debe ingresar alguna de las siguientes opciones: [RELIQUIDACION|RECONOCIMIENTO]"))
                    {
                        //Validar si es un AUXILIO FUNERARIO O RECURSO FUNERARIO.
                        string sXSD2 = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"App\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"TipoTramite\"><xs:complexType><xs:sequence><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /><xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\" /></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence><xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /></xs:complexType></xs:element></xs:sequence></xs:complexType></xs:element></xs:schema>";
                        CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                        string sRes = objCapaSOA.getCaseDataUsingSchemaAsString(Convert.ToInt32(strLineArzay[0]), sXSD2);
                        XmlDocument xdocMun = new XmlDocument();
                        xdocMun.LoadXml(sRes);
                        XmlNodeList NodoMun = xdocMun.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento/M_Tramite/IdP_SubtipoTramite");
                        if (NodoMun.Count > 0)
                        {
                            foreach (XmlNode XN in NodoMun)
                            {
                                if (XN["SCodigo"] != null)
                                {
                                    if ((XN["SCodigo"].InnerText == "18") || (XN["SCodigo"].InnerText == "317") || (XN["SCodigo"].InnerText == "8") || (XN["SCodigo"].InnerText == "318"))
                                    {
                                        //Actualizar caso con el campo de tipo liquidacion por reconocimiento si es AUXILIO, VEJEZ.
                                        CapaSOABA.EntityManagerSOASoapClient objSEError891 = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                                        string sTmp123 = "<BizAgiWSParam><Entities idCase=\"" + strLineArzay[0] + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><IdM_DatosReconocimientoA><IdP_TipoLiquidacion>1</IdP_TipoLiquidacion></IdM_DatosReconocimientoA></IdM_RC01Reconocimiento><M_Tramite><IdM_VariablesTramiteReco><TipoLiquidacion>1</TipoLiquidacion></IdM_VariablesTramiteReco></M_Tramite></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                        string sResSE = objSEError891.saveEntityAsString(sTmp123);
                                    }
                                }
                             }
                        }
                    }
                    else if ((sRespBA.Contains("Campo CodBanco y CodSucursal deben estar activos en la base de datos de N")) || 
                        (sRespBA.Contains("No se selecciono una sucursal bancaria para este reconocimiento")) ||
                       (sRespBA.Contains("CodSucursal, 1601, Campo CodSucursal debe ser mayor a cero")) ||
                        (sRespBA.Contains("Codigo Ciudad Pago Causante  no permite nulos")) ||
                        (sRespBA.Contains("CodBanco, 1803, Campo CodBanco debe debe estar en la base de datos de Nomina cuando el ind_automatico es S")))
                    {
                       Boolean SetBancoDir = false;
                    
                        //Se busca un cambio de banco.
                        if (strLineArzay.Length == 4)
                            if ((strLineArzay[3] != "N/A") && (strLineArzay[3] != "0"))
                                SetBancoDir = true;

                        if (SetBancoDir == true)
                        {
                            string sSE = "<BizAgiWSParam><Entities idCase=\"" + objReconcimiento.IdCase + "\"><M_cat_Reconocimiento><M_Tramite><IdM_VariablesProcesoTram><IdP_SucursalBancaria>" + strLineArzay[3] + "</IdP_SucursalBancaria></IdM_VariablesProcesoTram></M_Tramite></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                    
                            CapaSOABizAgi objSaveEntity = new CapaSOABizAgi();
                            string sRes = objSaveEntity.ServicioSaveEntity(sSE);
                    
                            Reintentar = true;
                        }
                        else
                        {
                           objReconcimiento.UpdateSucursalBancaria();
                            if (objReconcimiento.IdSucBancaria != 0)
                            {
                                Reintentar = true;
                           }
                            else
                            {
                                if ((objReconcimiento.MunicipioResidencia == "EXTRANJERO") && (objReconcimiento.DepartamentoResidencia == "EXTRANJERO"))
                                {
                                    objReconcimiento.UpdateSucursalBancariaCompleja(111);
                                    if (objReconcimiento.IdSucBancaria != 0)
                                        Reintentar = true;
                                    else
                                        sRespBA = "Se requiere definir una sucursal bancaria para la Ciudad de Residencia: " + objReconcimiento.MunicipioResidencia + "\t" + objReconcimiento.DepartamentoResidencia + "\t" + objReconcimiento.CodigoDaneResidencia;
                                }
                                else
                                {
                                    //PARA LOS CASOS DE EXTRANJERIA SE REQUIERE ENVIAR COMO CIUDAD DE RESIDENCIA BOGOTA
                                    sRespBA = "Se requiere definir una sucursal bancaria para la Ciudad de Residencia: " + objReconcimiento.MunicipioResidencia + "\t" + objReconcimiento.DepartamentoResidencia + "\t" + objReconcimiento.CodigoDaneResidencia;
                                }
                           }
                        }
                    }
                        
                        
                    //REINTENTO
                    if (Reintentar == true)
                    {
                        string psEnviLiqRei = "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><ActivityData><idCase>" + objReconcimiento.IdCase + "</idCase><taskId>" + strLineArzay[2] + "</taskId></ActivityData></BizAgiWSParam>";
                        CapaSOABizAgi objCapaSoaRe = new CapaSOABizAgi();
                        sRespBA = objCapaSoaRe.ServicioPerformActivity(psEnviLiqRei);
                    }
                    if ((this.chkLog.Checked == true) && (Convert.ToInt32(strLineArzay[2]) == 141) && (this.chkActSol.Checked != true))
                    {
                        string XSDVerf = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> <xs:element name=\"App\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesProcesoTram\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SucursalBancaria\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Banco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_CiudadPago\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_Ciudadano\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNumeroDocumento\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoDocumento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPrivados\" type=\"xs:boolean\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Recurso\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPublicos\" type=\"xs:boolean\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SIndicadorAuto\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SFechaSolicitud\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioRevisor\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_EPS\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNit\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_AccionLiquidador\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosReconocimientoA\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoLiquidacion\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioSustanciador\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SObservaciones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosGenerales\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SRadNumber\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:schema>";

                        CapaSOABizAgi objCapaSoaRe = new CapaSOABizAgi();
                        ResLog = objCapaSoaRe.ServicioGetCaseDataSchema(Convert.ToInt32(strLineArzay[0]), XSDVerf);

                        rtbResultado.Text += sRespBA + "\t" + ResLog;
                        rtbResultado.Text += "\n";
                    }
                    if ((this.chkLog.Checked == true) && (Convert.ToInt32(strLineArzay[2]) == 141) && (this.chkActSol.Checked == true))
                    {
                        string XSDVerf = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> <xs:element name=\"App\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesProcesoTram\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SucursalBancaria\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Banco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_CiudadPago\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_Ciudadano\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNumeroDocumento\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoDocumento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPrivados\" type=\"xs:boolean\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Recurso\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiemposPublicos\" type=\"xs:boolean\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SIndicadorAuto\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SFechaSolicitud\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioRevisor\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_EPS\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNit\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_AccionLiquidador\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosReconocimientoA\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoLiquidacion\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SUsuarioSustanciador\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SObservaciones\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosGenerales\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SRadNumber\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:schema>";

                        CapaSOABizAgi objCapaSoaRe = new CapaSOABizAgi();
                        ResLog = objCapaSoaRe.ServicioGetCaseDataSchema(Convert.ToInt32(strLineArzay[0]), XSDVerf);

                        rtbResultado.Text += sRespBA + "\t" + ResLog + "\t" + ResSol;
                        rtbResultado.Text += "\n";
                    }
                    else if (this.chkActSol.Checked == true)
                    {
                        rtbResultado.Text += sRespBA + "\t" + ResSol;
                        rtbResultado.Text += "\n";
                    }
                    else
                    {
                        rtbResultado.Text += sRespBA;
                        rtbResultado.Text += "\n";
                    }

                    

                    Contador += 1;
                    this.Conteo.Text = Convert.ToString(Contador);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    //RegProcesados.Text = objResT.Ejecutados.ToString();


                    this.Refresh();

                    //Thread.Sleep(50000);
                            
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

            int y = File.ReadAllLines(this.tbExaminar.Text).Length;

            RegTotal.Text = y.ToString();
            this.Refresh();
        }

        private void btExaminar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            } 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no es valido...");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

            int y = File.ReadAllLines(this.tbExaminar.Text).Length;

            RegTotal.Text = y.ToString();
            this.Refresh();
        }

        private void btoReintentarAsincronas_Click(object sender, EventArgs e)
        {
            #region NewReintentarAsincronas
            //Nuevo reintentos de asincornas.

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");


                clsMasivoAsincronasBA objReintentosAsincrona = new clsMasivoAsincronasBA(this.tbExaminar.Text, '\t');

                do
                {
                    objReintentosAsincrona.EjecutarLineaAsincronaBA();
                    rtbResultado.Text = objReintentosAsincrona.LogPantalla.GetLogPantallaFull();
                    this.Refresh();
                }
                while (objReintentosAsincrona.EjecucionCompleta() == false);
               
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception(2GJ): " + e1.Message);
            }
            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbExaminar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
