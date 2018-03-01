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
    public partial class frmLiquidadorDummy : Form
    {
        public frmLiquidadorDummy()
        {
            InitializeComponent();
        }

        Reconocimiento objReco;


        private void btoEnvioLiquidador_Click(object sender, EventArgs e)
        {
            //Reliza consulta de la informacion del reconocimiento enviado al liquidador
            objReco = new Reconocimiento (this.txtRadumber.Text, Convert.ToInt32(this.txtIdCase.Text));
            objReco.Get_InfoLiquidador();

            this.txtIdCaseView.Text = objReco.IdCase.ToString();
            this.txtRadNumberView.Text = objReco.RadNumber.ToString();
            this.txtTramite.Text = objReco.SubTramite.ToString();
            if (objReco.EtapaActividad != null)
                this.txtEstado.Text = objReco.EtapaActividad.ToString();
            this.chbReqVerificacion.Checked = objReco.RequiereVerificacion;
        }

        private void btoActivarVerificacion_Click(object sender, EventArgs e)
        {
            objReco.Upd_RequiereVerificacion();
            objReco.Get_InfoLiquidador();

            this.chbReqVerificacion.Checked = objReco.RequiereVerificacion;
        }

        private void btoDesactivarVerificacion_Click(object sender, EventArgs e)
        {
            objReco.Upd_NORequiereVerificacion();
            objReco.Get_InfoLiquidador();

            this.chbReqVerificacion.Checked = objReco.RequiereVerificacion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string NoActo = null;
                string prefijoActo = null;

                if (this.txtNoActoAdm.Text != null)
                {
                    NoActo = this.txtNoActoAdm.Text;                
                }

                if (this.txtPrefijoActAdm != null)
                {
                    prefijoActo = this.txtPrefijoActAdm.Text;
                }


                string Res = objReco.Set_ResliquidadorFullDatosUnNotificado(this.txtId.Text, this.txtEtapa.Text, this.txtFechaReg.Text, this.txtTipoAccion.Text,
                                                                            this.txtDominio.Text, this.txtUser.Text, this.txtObservacion.Text, NoActo,
                                                                            prefijoActo, this.txtFechaReg.Text, "RECONOCIMIENTO", this.txtDecision.Text,
                                                                            this.txtActoAdm.Text, "false", "N/A", this.txtTipoDoc.Text,
                                                                            this.txtNoIdentificacion.Text, this.txtPrimerNombre.Text, this.txtSegundoNombre.Text,
                                                                            this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtDireccion.Text,
                                                                            this.txtTelefono.Text, "false", "N/A", "N/A", txtCiudad.Text, chkBonoPensional.Checked,
                                                                            this.chkReqApelacion.Checked);

            

                this.rtbError.Text = Res;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

                
    }
}
