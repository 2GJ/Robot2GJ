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
    public partial class frmSaveEntity : Form
    {
        public frmSaveEntity()
        {
            InitializeComponent();
        }

        private void btoInvocar_Click(object sender, EventArgs e)
        {
            //CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient();

            CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");

            string Pru = "<BizAgiWSParam><Entities idCase = \"34300\"><M_cat_ServicioCiudadano><IdM_SC01ServCiudadano><Tramite><IdM_VariablesProcesoTram><IdP_SucursalBancaria>1</IdP_SucursalBancaria></IdM_VariablesProcesoTram></Tramite></IdM_SC01ServCiudadano></M_cat_ServicioCiudadano></Entities></BizAgiWSParam>";

            string sRes = objCapaSOA.saveEntityAsString(Pru);

            rtbRespuesta.Text = sRes;
        }

        private void btoInvocar_Click_2(object sender, EventArgs e)
        {
            int Contador = 0;
            bool Reintentar = false;

            if (rbSaveEntityEntity.Checked == true)
            {

                try
                {
                    Int32 Tiempo = Convert.ToInt32(this.txtTiempo.Text);

                    //Abrir el archivo de captura.
                    if (this.txtRutaArchivo.Text == null)
                        MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                    string LineaCaptura;
                    StreamReader FileCaptura = new StreamReader(this.txtRutaArchivo.Text);

                    Int64 y = File.ReadAllLines(this.txtRutaArchivo.Text).Length;
                    this.txtTotalReg.Text = y.ToString();

                    ResumenTiempo objResT = new ResumenTiempo(y);
                    objResT.F_StartTimer();
                    this.txtFechaInicio.Text = objResT.InicioOperacion.ToString();


                    while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                    {
                        CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                        string ResSaveEntity = objCapaSOABizAgi.ServicioSaveEntity(LineaCaptura);

                        this.rtbRespuesta.Text += ResSaveEntity;
                        this.rtbRespuesta.Text += "\n";

                        Contador += 1;
                        this.txtEjecutados.Text = Convert.ToString(Contador);


                        objResT.F_MarkTimer();
                        this.txtTiempoEjecucion.Text = objResT.Get_TiempoEjecucion();
                        this.txtPromedio.Text = objResT.Get_TiempoPromedio();
                        this.txtEstimadoFin.Text = objResT.Get_TiempoEstimado();

                        this.Refresh();

                        if (this.chkAplicaTiempo.Checked == true)
                            Thread.Sleep(Tiempo);

                    }

                    this.txtFechaFin.Text = objResT.FechaFin.ToString();
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
            else
            {
                try
                {
                    Int32 Tiempo = Convert.ToInt32(this.txtTiempo.Text);

                    //Abrir el archivo de captura.
                    if (this.txtRutaArchivo.Text == null)
                        MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                    string LineaCaptura;
                    StreamReader FileCaptura = new StreamReader(this.txtRutaArchivo.Text);

                    Int64 y = File.ReadAllLines(this.txtRutaArchivo.Text).Length;
                    this.txtTotalReg.Text = y.ToString();

                    ResumenTiempo objResT = new ResumenTiempo(y);
                    objResT.F_StartTimer();
                    this.txtFechaInicio.Text = objResT.InicioOperacion.ToString();


                    while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                    {
                        Reintentar = false;

                        char tmpChar = '\t';
                        char[] Separador = new char[] { tmpChar };
                        string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < strLineArzay.Length; i++)
                        {
                            this.rtbRespuesta.Text += strLineArzay[i] + "\t";
                        }

                        //Columnas Fijas 
                        //0- IdCase
                        //1- RadNumber
                        //2- XML Modelo

                        //Construir XML
                        string strSaveEntity = "";

                        strSaveEntity += "<BizAgiWSParam>";
                        strSaveEntity += "<Entities idCase=\"" + strLineArzay[0] + "\">";
                        strSaveEntity += strLineArzay[2];
                        strSaveEntity += "</Entities>";
                        strSaveEntity += "</BizAgiWSParam>";

                        //Llamado de save entity
                        CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                        string ResSaveEntity = objCapaSOABizAgi.ServicioSaveEntity(strSaveEntity);

                        this.rtbRespuesta.Text += ResSaveEntity;
                        this.rtbRespuesta.Text += "\n";

                        Contador += 1;
                        this.txtEjecutados.Text = Convert.ToString(Contador);


                        objResT.F_MarkTimer();
                        this.txtTiempoEjecucion.Text = objResT.Get_TiempoEjecucion();
                        this.txtPromedio.Text = objResT.Get_TiempoPromedio();
                        this.txtEstimadoFin.Text = objResT.Get_TiempoEstimado();

                        this.Refresh();

                        if (this.chkAplicaTiempo.Checked == true)
                            Thread.Sleep(Tiempo);

                    }

                    this.txtFechaFin.Text = objResT.FechaFin.ToString();
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
        }

        private void btoExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtRutaArchivo.Text = openFileDialog1.FileName;
            } 
        }

        private void chkAplicaTiempo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAplicaTiempo.Checked == true)
            {
                this.txtTiempo.Visible = true;
                this.lblTiempo.Visible = true;
            }
            else
            {
                this.txtTiempo.Visible = false;
                this.lblTiempo.Visible = false;
            }
        }
    }
}
