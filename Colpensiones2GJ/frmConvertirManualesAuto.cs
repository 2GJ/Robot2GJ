using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace Colpensiones2GJ
{
    public partial class frmConvertirManualesAuto : Form
    {
        public frmConvertirManualesAuto()
        {
            InitializeComponent();
        }

        private void btLeerArchivo_Click(object sender, EventArgs e)
        {   
            //int Contador = 0;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                Total.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();
                           

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    bool Reintentar = false;
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        rtbResultado.Text += strLineArzay[i] + "\t";
                    }

                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));


                    //Se habilita la verificacion de la decision.
                    if (this.chkVerificacion.Checked == true)
                    {
                        //objRec.Reconocimiento(strLineArzay[1], Convert.ToInt16(strLineArzay[0]));
                        string ResRec = objRec.UpdateSolicitarVerificacion();
                    }


                    //Consulta Informacion del Banco.
                    string sBanco = "N/A";
                    if ((strLineArzay[3] != "N/A") && (strLineArzay[3] != "0"))
                    {
                        sBanco = strLineArzay[3];
                    }
                    else if (strLineArzay[3] == "0")
                    {
                        //Buscar Banco en el Municipio.
                        string sXSD2 = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> <xs:element name=\"App\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_Ciudadano\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_MunicipioResidencia\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SMunicipio\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigoActualDANE\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"Deparatamento\"> <xs:complexType> <xs:sequence> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" /> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" /> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" /> </xs:complexType> </xs:element> </xs:sequence> </xs:complexType> </xs:element> </xs:schema>";
                        CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                        string sRes = objCapaSOA.getCaseDataUsingSchemaAsString(Convert.ToInt32(strLineArzay[0]), sXSD2);
                        XmlDocument xdocMun = new XmlDocument();
                        xdocMun.LoadXml(sRes);
                        XmlNodeList NodoMun = xdocMun.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento/M_Tramite/IdM_Ciudadano");

                        if (NodoMun.Count > 0)
                        {
                            foreach (XmlNode XN in NodoMun)
                            {
                                if (XN["IdP_MunicipioResidencia"] != null)
                                {
                                    string tmp = XN["IdP_MunicipioResidencia"].Attributes.GetNamedItem("key").InnerText;
                                    ColpensionesReconocimiento objBA = new ColpensionesReconocimiento();
                                    int idSucBan = objBA.Get_IdSucursalBancaria(Convert.ToInt16(tmp));
                                    if (idSucBan != 0)
                                    {
                                        sBanco = idSucBan.ToString();
                                    }
                                    else
                                    {
                                        sBanco = "NO SE PUDO ACTUALIZAR BANCO AUTOMATICAMENTE...";
                                    }
                                }
                                else
                                {
                                    sBanco = "NO SE PUDO ACTUALIZAR BANCO AUTOMATICAMENTE...";
                                }
                            }
                        }
                        else
                        {
                            sBanco = "NO SE PUDO ACTUALIZAR BANCO AUTOMATICAMENTE...";
                        }
                    }
                    else
                    {
                        sBanco = "N/A";
                    }

                    string sRespBA = "";
                    string sXMLSeteven = "";
                    string sSaveEntity = "";
                    string sXMLEPS = "";
                    string sXMLTramite = "";
                    string sXMLBanco = "";
                    string sXMLInstancia = "";
                    string sXMLTipoLiquidacion = "";
                    string sXMLTipoLiquidacion2 = "";
                    string sXMLFechaSolicitud = "";
                    
                    
                    //Si es RECONOCIMIETO envio EPS.
                    //Si no Borro EPS.
                    if (strLineArzay[2] == "RECONOCIMIENTO")
                    {
                        sXMLEPS = "<IdP_EPS businessKey=\"SNit='888888888'\"/>";
                    }
                    else
                    {
                        //sXMLEPS = "<IdP_EPS>25</IdP_EPS>";
                        sXMLEPS = "<IdP_EPS businessKey=\"SNit='888888888'\"/>";
                    }

                    //Actualiza Banco
                    if ((sBanco != "N/A") && (sBanco != "0") && (sBanco != "NO SE PUDO ACTUALIZAR BANCO AUTOMATICAMENTE..."))
                    {
                        sXMLBanco = "<IdP_SucursalBancaria>" + sBanco + "</IdP_SucursalBancaria>";
                    }
                    else if (sBanco != "0")
                    {

                    }
                    else
                    {
                        sXMLBanco = "";
                    }

                    //Actualiza tipo de tramite
                    //if ((strLineArzay[4].Contains("Recurso Pensi")) && (strLineArzay[4].Contains("n de Vejez")))
                    //{
                    //sXMLTramite = "<IdP_SubtipoTramite businessKey=\"SCodigo='8'\"/>";
                    //}
                    //else if ((strLineArzay[4].Contains("Recurso Indemnizaci")) && (strLineArzay[4].Contains("n de vejez")))
                    //{
                    //sXMLTramite = "<IdP_SubtipoTramite businessKey=\"SCodigo='331'\"/>";
                    //}

                    //Actualizar Instancia.....
                    if (strLineArzay[5] == "N/A")
                    {
                        //sXMLInstancia = "<IdP_Recurso></IdP_Recurso>";
                        sXMLInstancia = "";
                    }
                    else
                    {
                        sXMLInstancia = "<IdP_Recurso businessKey=\"SCodigo='" + strLineArzay[5] + "'\"/>";
                    }

                    //Actualiza tipo Liquidacion..
                    if (strLineArzay[2] == "N/A")
                    {
                        sXMLTipoLiquidacion = "";
                        sXMLTipoLiquidacion2 = "";
                    }
                    else
                    {
                        sXMLTipoLiquidacion = "<TipoLiquidacion businessKey=\"SCodColpensiones='" + strLineArzay[2] + "'\"/>";
                        sXMLTipoLiquidacion2 = "<IdP_TipoLiquidacion businessKey=\"SCodColpensiones='" + strLineArzay[2] + "'\"/>";
                    }

                    //Actualizacion de fecha...
                    if (strLineArzay[6] != "N/A")
                    {
                        sXMLFechaSolicitud = "<SFechaSolicitud>" + strLineArzay[6] + "</SFechaSolicitud>";
                    }
                    else
                    {
                        sXMLFechaSolicitud = "";
                    }

                    //Relizar SetEven de la Etapa 200.
                    //Actualizacion de banco.....
                    //SI banco tiene idsucursal
                    sSaveEntity =       "<BizAgiWSParam>";
                    sSaveEntity +=          "<Entities idCase=\"" + strLineArzay[0] + "\">";
                    sSaveEntity +=              "<M_cat_Reconocimiento>";
                    sSaveEntity +=                  "<M_Tramite>";

                    if (sXMLTramite != "")
                    {
                        sSaveEntity +=                  sXMLTramite;
                    }
                    if (sXMLBanco != "")
                    {
                        sSaveEntity +=                  "<IdM_VariablesProcesoTram>";
                        sSaveEntity +=                      sXMLBanco;
                        sSaveEntity +=                  "</IdM_VariablesProcesoTram>";
                    }
                    if (sXMLEPS != "" || sXMLInstancia != "" || sXMLTipoLiquidacion != "")
                    {
                        sSaveEntity += "<IdM_VariablesTramiteReco>";
                        if (sXMLEPS != "")
                        {
                            sSaveEntity += sXMLEPS;
                        }
                        if (sXMLInstancia != "")
                        {
                            sSaveEntity += sXMLInstancia;
                        }
                        if (sXMLTipoLiquidacion != "")
                        {
                            sSaveEntity += sXMLTipoLiquidacion;
                        }
                        sSaveEntity += "</IdM_VariablesTramiteReco>";
                    }

                    sSaveEntity += "</M_Tramite>";

                    if ((sXMLEPS != "") || (sXMLFechaSolicitud != "") || (sXMLTipoLiquidacion2 != ""))
                    {
                        sSaveEntity +=      "<IdM_RC01Reconocimiento>";
                        sSaveEntity +=          sXMLEPS;
                        sSaveEntity +=          sXMLFechaSolicitud;
                        if (sXMLTipoLiquidacion2 != "")
                        {
                            sSaveEntity += "<IdM_DatosReconocimientoA>";
                            sSaveEntity += sXMLTipoLiquidacion2;
                            sSaveEntity += "</IdM_DatosReconocimientoA>";
                        }
                        sSaveEntity += "</IdM_RC01Reconocimiento>";
                    }
                    sSaveEntity += "</M_cat_Reconocimiento>";
                    sSaveEntity += "</Entities>";
                    sSaveEntity += "</BizAgiWSParam>";
                    


                    sXMLSeteven = "<BizAgiWSParam>";
                    sXMLSeteven += "<Events>";
                    sXMLSeteven += "<Event>";
                    sXMLSeteven += "<EventData>";
                    sXMLSeteven += "<idCase>" + strLineArzay[0] + "</idCase>";
                    sXMLSeteven += "<eventName>RegistroDeActividades</eventName>";
                    sXMLSeteven += "</EventData>";
                    sXMLSeteven += "<Entities>";
                    sXMLSeteven += "<App>";
                    sXMLSeteven += "<M_cat_Reconocimiento>";
                    sXMLSeteven += "<M_Tramite>";
                    
                    if (sXMLTramite != "")
                    {
                        sXMLSeteven += sXMLTramite;
                    }
                    if (sXMLBanco != "")
                    {
                        sXMLSeteven += "<IdM_VariablesProcesoTram>";
                        sXMLSeteven += sXMLBanco;
                        sXMLSeteven += "</IdM_VariablesProcesoTram>";
                    }

                    if (sXMLTipoLiquidacion != "")
                    {
                        sXMLSeteven += "<IdM_VariablesTramiteReco>";
                        sXMLSeteven += sXMLTipoLiquidacion;
                        sXMLSeteven += "</IdM_VariablesTramiteReco>";
                    }

                        sXMLSeteven += "</M_Tramite>";
                        sXMLSeteven += "<IdM_RC01Reconocimiento>";
                        sXMLSeteven += "<IdM_DatosActividad>";
                        sXMLSeteven += "<IdP_Accion businessKey=\"SEtapa='200'\"/>";
                        sXMLSeteven += "<IdP_TipoAccion businessKey=\"SCodColpensiones='FIN'\"/>";
                        sXMLSeteven += "<Iid>5857</Iid>";
                        sXMLSeteven += "<SFechaString>20130530</SFechaString>";
                        sXMLSeteven += "<SResponsable>admon</SResponsable>";
                        sXMLSeteven += "<SDominio>domain</SDominio>";
                    
                   
                    sXMLSeteven += "</IdM_DatosActividad>";

                    if (sXMLFechaSolicitud != "")
                    {
                        sXMLSeteven += sXMLFechaSolicitud;
                    }

                    if (sXMLTipoLiquidacion2 != "")
                    {
                        sXMLSeteven += "<IdM_DatosReconocimientoA>";
                        sXMLSeteven += sXMLTipoLiquidacion2;
                        sXMLSeteven += "</IdM_DatosReconocimientoA>";
                    }
                    sXMLSeteven += "</IdM_RC01Reconocimiento>";
                    sXMLSeteven += "</M_cat_Reconocimiento>";
                    sXMLSeteven += "</App>";
                    sXMLSeteven += "</Entities>";
                    sXMLSeteven += "</Event>";
                    sXMLSeteven += "</Events>";
                    sXMLSeteven += "</BizAgiWSParam>";



                    CapaSOABA.EntityManagerSOASoapClient objSEError891 = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");
                    string sResSE = objSEError891.saveEntityAsString(sSaveEntity);
                    
                    CapaSOABAWF.WorkflowEngineSOASoapClient objCapaSOAWF = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");
                    string ResSE = objCapaSOAWF.setEventAsString(sXMLSeteven);
                    
                    this.rtbResCaso.Text += ResSE;
                    ColpensionesBC.RespuestasBizAgi objResBA = new ColpensionesBC.RespuestasBizAgi();
                    sRespBA = objResBA.CapturaRespuestaBA(ResSE);


                    if (sRespBA == "")
                          sRespBA = "Ejecutado Correctamente..." + "\t" + ResSE;
                    
                    rtbResultado.Text += sRespBA + "\n";
                                       
                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    this.Conteo.Text = objResT.Ejecutados.ToString();

                    this.Refresh();
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

        private void btExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            }
            this.Refresh();
        }

        private void btoCargarArchivo_Click(object sender, EventArgs e)
        {
            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

            int y = File.ReadAllLines(this.tbExaminar.Text).Length;

            Total.Text = y.ToString();
            this.Refresh();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }       
    }
}
