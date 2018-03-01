using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Colpensiones2GJ
{
    public partial class frmRadicarML : Form
    {
        public frmRadicarML()
        {
            InitializeComponent();
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

        private void btoInvocar_Click(object sender, EventArgs e)
        {
            int Contador = 0;
            bool Reintentar = false;



            try
            {

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
                    string strCreateCase = "";
                    string Proceso = "";
                    string CodColpensiones = "";
                    if (rbCreateCase180.Checked == true)
                    {
                        Proceso = "RC03_Incapacidades";
                        CodColpensiones = "MDLSIT";
                    }
                    else if (rbCreateCasePCL.Checked == true)
                    {
                        Proceso = "RC04_CalificacionPCL";
                        CodColpensiones = "MDLPCL";
                    }
                    else
                    {
                        if (rbCreateCaseREI.Checked == true)
                        {
                            Proceso = "RC06_RevisionDelEstadoDeIn";
                            CodColpensiones = "MDLREI";
                        }
                    }

                    strCreateCase += "<BizAgiWSParam><domain>domain</domain><userName>admon</userName><Cases><Case><Process>" + Proceso + "</Process><Entities><App><M_cat_Reconocimiento><M_Tramite><IdP_SubtipoTramite businessKey=\"SCodColpensiones='" + CodColpensiones + "'\"/><IdM_Ciudadano>";
                    strCreateCase += "<SNumeroDocumento>" + strLineArzay[0] + "</SNumeroDocumento>";
                    strCreateCase += "<IdP_TipoDocumento businessKey=\"SCodigo='" + strLineArzay[1] + "'\"/>";
                    strCreateCase += "<SPrimerNombre>" + strLineArzay[2] + "</SPrimerNombre>";
                    strCreateCase += "<SSegundoNombre>" + strLineArzay[3] + "</SSegundoNombre>";
                    strCreateCase += "<SPrimerApellido>" + strLineArzay[4] + "</SPrimerApellido>";
                    strCreateCase += "<SSegundoApellido>" + strLineArzay[5] + "</SSegundoApellido>";
                    strCreateCase += "</IdM_Ciudadano></M_Tramite></M_cat_Reconocimiento></App></Entities></Case></Cases></BizAgiWSParam>";
                    //Llamado de save entity
                    CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                    string ResSaveEntity = objCapaSOABizAgi.CreateCase(strCreateCase);

                    this.rtbRespuesta.Text += ResSaveEntity;
                    this.rtbRespuesta.Text += "\n";

                    Contador += 1;
                    this.txtEjecutados.Text = Convert.ToString(Contador);


                    objResT.F_MarkTimer();
                    this.txtTiempoEjecucion.Text = objResT.Get_TiempoEjecucion();
                    this.txtPromedio.Text = objResT.Get_TiempoPromedio();
                    this.txtEstimadoFin.Text = objResT.Get_TiempoEstimado();

                    this.Refresh();

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
}
