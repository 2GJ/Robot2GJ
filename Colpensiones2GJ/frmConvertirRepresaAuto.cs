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
    public partial class frmConvertirRepresaAuto : Form
    {
        public frmConvertirRepresaAuto()
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

            int y = File.ReadAllLines(this.tbExaminar.Text).Length;

            RegTotal.Text = y.ToString();
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Contador = 0;
            DateTime FechaInicio = DateTime.Now;
            DateTime FechaFin;
            Int32 TProm = 0;
            Int32 TEje = 0;
            Int32 TEst = 0;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                //tbTEjecucion.Text = "0";
                //tbTPromedio.Text = "0";
                //tbTEstFin.Text = "0";
                //tbOK.Text = "0";
                //tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;

                RegTotal.Text = y.ToString();
                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";
                    

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i] + "\t";
                    }

                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    
                    //Validar Actualizacion de Sucursal Bancaria.
                    string sXMLSucBan = objRec.Get_XMLSucursalBancaria(strLineArzay[2]);

                    //Validar Actualizacion de TipoLiquidacion.
                    string sXMLTipLiq = objRec.Get_XMLTipoLiquidacion(strLineArzay[3]);
                    
                    //Validar Actualizacion de Instancia y Recurso.
                    string sXMLInstancia = objRec.Get_XMLTipoInstancia(strLineArzay[4]);
                    string sXMLRecurso   = objRec.Get_XMLTipoRecurso(strLineArzay[4]);

                    string ResConvAuto = objRec.Upd_AutomaticoRepresa(sXMLSucBan, sXMLTipLiq, sXMLInstancia, sXMLRecurso);


                    rtbResutadoFinal.Text += strLinea + "\t" + ResConvAuto + "\n";

                    Contador += 1;
                    label1.Text = Convert.ToString(Contador);

                    FechaFin = DateTime.Now;
                    TimeSpan ts = FechaFin - FechaInicio;
                    FechaInicio = DateTime.Now;
                    Int32 A = ts.Milliseconds;

                    TEje += A;
                    TProm = TEje / Contador;
                    TEst = (Convert.ToInt32(RegTotal.Text) - Contador) * TProm;


                    //tbTEjecucion.Text = Convert.ToString((TEje/1000)/60);
                    //tbTEjecucion.Text = Convert.ToString((TEje / 1000));
                    //tbTPromedio.Text = Convert.ToString(((TEje / Contador)/1000)/60);
                    //tbTPromedio.Text = Convert.ToString(((TEje / Contador) / 1000));
                    //tbTEstFin.Text = Convert.ToString(((Convert.ToInt32(RegTotal.Text) * TProm)/1000)/60);
                    //tbTEstFin.Text = Convert.ToString((((Convert.ToInt32(RegTotal.Text) - Contador) * TProm) / 1000));

                    //RegProcesados.Text = Convert.ToString(Contador);

                    //if (objRec.CodError == 0)
                     //   tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    //else
                      //  tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    this.Refresh();
                }

                //TProm = ((TEje / Contador) / 1000);
                //tbTPromedio.Text = Convert.ToString(TProm);

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

        private void frmConvertirRepresaAuto_Load(object sender, EventArgs e)
        {
            this.rtbDetlleBanco.Text = "0- Se Busca Banco.\n";
            this.rtbDetlleBanco.Text += "N/A- No se realiza ninguna accion sobre el banco. \n";
            this.rtbDetlleBanco.Text += "Diferente a 0 y N/A se actualiza al banco enviado.";

            this.rtbTipoLiquidacion.Text = "Debe ser igual a RECONOCIMIENTO o RELIQUIDACION.";
                        
            this.rtbInstancia.Text = "1 - Recurso de Repocision.\n";
            this.rtbInstancia.Text += "2 - Recurso de Apelacion.\n";
            this.rtbInstancia.Text += "3 - Revocatoria Directa.\n";
            this.rtbInstancia.Text += "4 - Recurso de Queja.\n";
            this.rtbInstancia.Text += "5 - Nuevo Estudio.\n";
            this.rtbInstancia.Text += "6 - Ordinaria.\n";
        }
    }
}
