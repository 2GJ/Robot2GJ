using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Colpensiones2GJ
{
    public partial class frmCasoReconocimiento : Form
    {
        public clsCasoBizAgi objCasoBizAgi = null;

        public frmCasoReconocimiento()
        {
            InitializeComponent();

           
        }

        private void btoSearch_Click(object sender, EventArgs e)
        {
            try
            {
                objCasoBizAgi = new clsCasoBizAgi(Convert.ToInt32(this.txtIdCaseRecSearch.Text), this.txtRadSearch.Text);
                objCasoBizAgi.GetDatosGenerales();
                
                this.txtIdCaseRec.Text = objCasoBizAgi.IdCase.ToString();
                this.txtRadRec.Text = objCasoBizAgi.RadNumber;
                this.txtFechaCreacion.Text = objCasoBizAgi.FechaCreacion;
                this.txtFechaSolucion.Text = objCasoBizAgi.FechaSolucion;

                objCasoBizAgi.GetDatosProcesoReconocimientoGenerales();

                this.txtPrioridad.Text = objCasoBizAgi.CasoNegocio.Priorodad;
                this.txtIdEntityMCatRec.Text = objCasoBizAgi.CasoNegocio.Reconocimiento.CatReconocimiento.IdEntity.ToString();
                this.txtIdEntityMTramite.Text = objCasoBizAgi.CasoNegocio.Reconocimiento.CatReconocimiento.MTramite.IdEntity.ToString();
            }
            catch (Exception ex)
            {
                this.rtEstatus.Text = ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
