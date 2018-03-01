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
    public partial class frmAddRolesSkills : Form
    {
        public frmAddRolesSkills()
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

                    String sXML = "";

                    if (rbAddRoles.Checked == true)
                    {
                          sXML += "<BizAgiWSParam>";
                          sXML += "   <Entities>";
                          sXML += "      <WFUSER key=\"" + strLineArzay[0] +"\">";
                          sXML += "        <Roles>";
                          sXML += "            <idRole>" + strLineArzay[2] + "</idRole>";
                          sXML += "        </Roles>";
                          sXML += "      </WFUSER>";
                          sXML += "    </Entities>";
                          sXML += "</BizAgiWSParam>";
                    }
                    else
                    {

                    }
                    
                    CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                    string ResSaveEntity = objCapaSOABizAgi.ServicioSaveEntity(sXML);

                    this.rtbRespuesta.Text += ResSaveEntity;
                    this.rtbRespuesta.Text += "\n";

                    Contador += 1;
                    this.txtEjecutados.Text = Convert.ToString(Contador);
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
    }
}
