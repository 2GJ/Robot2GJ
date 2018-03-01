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
//using ColpensionesBC;

namespace Colpensiones2GJ
{
    public partial class frmSetEvent : Form
    {
        public frmSetEvent()
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
                    //2- Nombre Evento
                    //3- XML Modelo

                    //Construir XML
                    string strSetEvent = "";


                    strSetEvent +=      "<BizAgiWSParam>";
	                strSetEvent +=          "<Events>";
		            strSetEvent +=              "<Event>";
			        strSetEvent +=                  "<EventData>";
				    strSetEvent +=                      "<idCase>" + strLineArzay[0] + "</idCase>";
				    strSetEvent +=                      "<eventName>" + strLineArzay[2] + "</eventName>";
                    strSetEvent +=                  "</EventData>";
			        strSetEvent +=                  "<Entities>";
				    strSetEvent +=                      "<App>";
                    strSetEvent +=                          strLineArzay[3];
                    strSetEvent +=                      "</App>";
			        strSetEvent +=                  "</Entities>";
		            strSetEvent +=              "</Event>";
	                strSetEvent +=          "</Events>";
                    strSetEvent +=      "</BizAgiWSParam>";
                                    

                    //Llamado de set Event
                    CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                    string ResSetEvent = objCapaSOABizAgi.ServicioSetEventByXML(strSetEvent);

                    this.rtbRespuesta.Text += ResSetEvent;
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
