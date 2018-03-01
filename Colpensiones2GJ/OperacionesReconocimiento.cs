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
    public partial class OperacionesReconocimiento : Form
    {
        public OperacionesReconocimiento()
        {
            InitializeComponent();
        }

        private void rbOpcionCaptura1_CheckedChanged(object sender, EventArgs e)
        {
            //rbOpcionCaptura1 Captura por Archivo Plano...
            if (this.rbOpcionCaptura1.Checked == true)
            {
                this.rtbDatosIngreso.Enabled = false;
                this.btoExaminar.Enabled = true;
                this.txtExaminar.Enabled = true;
            }
            //rbOpcionCaptura2 Captura por texto...
            if (this.rbOpcionCaptura2.Checked == true)
            {
                this.rtbDatosIngreso.Enabled = true;
                this.btoExaminar.Enabled = false;
                this.txtExaminar.Enabled = false;
            }

        }

        private void btoExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtExaminar.Text = openFileDialog1.FileName;
            } 
        }

        private void btoActUsuLiqSup_Click(object sender, EventArgs e)
        {
            //string LineaCaptura;
            Int64 linecount = 0;
            
            //Validar que se tenga informacion...
            //Para Archivo
            if (this.rbOpcionCaptura1.Checked == true)
            {
                if (this.txtExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido.");

                //Cargar Archivo...
                StreamReader FileCaptura = new StreamReader(this.txtExaminar.Text);

                //Contar numero de lineas.
                linecount = File.ReadAllLines(this.txtExaminar.Text).Length;


                ResumenTiempo objResT = new ResumenTiempo(linecount);
                objResT.F_StartTimer();

                this.RegTotal.Text = linecount.ToString();
                this.txtIniOpe.Text = objResT.InicioOperacion.ToString();

                this.Refresh();

                string LineaCaptura = "";
                
                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    string LineaCaptura2 = "";

                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        LineaCaptura2  += strLineArzay[i] + "\t";
                    }

                    //Campura de columnas.....
                    Int32 IdCase =  Convert.ToInt32(strLineArzay[0]);
                    string RadNumber = strLineArzay[1];
                    string UserLiq = strLineArzay[2];
                    string UserSup = strLineArzay[3];
                    

                    //Inicia Objeto reconocimiento
                    Reconocimiento objReconcimiento = new Reconocimiento(RadNumber, IdCase);
                    objReconcimiento.Get_InformacionReconocimiento();
                    objReconcimiento.GetActividadEtapaActual();
                    
                    //Actualiza usuario liquidador y revisor..
                    LineaCaptura += "\t" + objReconcimiento.UpdateUsuarios(UserLiq, UserSup);

                    this.rtxtResultado.Text += LineaCaptura + "\n";

                    this.RegProcesados.Text = Convert.ToString(Convert.ToInt32(this.RegProcesados.Text) + 1);

                    this.Refresh();
                }

                this.txtFinOpe.Text = Convert.ToString(DateTime.Now);

            }
        }

        private void Operaciones(int In_Oper, string In_StrLinea)
        {
            char tmpChar = '\t';
            char[] Separador = new char[] { tmpChar };
            string[] strLineArzay = In_StrLinea.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
            string strLinea = "";

            for (int i = 0; i < strLineArzay.Length; i++)
            {
                strLinea += strLineArzay[i].Trim() + "\t";
            }

            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
                        
            if (In_Oper == 1)
            {
                //Operacion 1 Actualizacion de usuario liquidador y supervisor...                
            }
        }
    }
}
