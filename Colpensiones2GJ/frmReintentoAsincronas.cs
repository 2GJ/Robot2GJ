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
    public partial class frmReintentoAsincronas : Form
    {
        public frmReintentoAsincronas()
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

        private void tbExaminar_TextChanged(object sender, EventArgs e)
        {
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no es valido...");

            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

            int y = File.ReadAllLines(this.tbExaminar.Text).Length;

            this.tbRegistrosArchivo.Text = y.ToString();
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
    }
}
