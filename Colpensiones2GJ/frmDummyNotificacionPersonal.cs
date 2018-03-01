using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.EntityModel;

namespace Colpensiones2GJ
{
    public partial class frmDummyNotificacionPersonal : Form
    {
        public frmDummyNotificacionPersonal()
        {
            InitializeComponent();
        }    

        private void btoCargaDtosCallCenter_Click(object sender, EventArgs e)
        {
            EntitiesNewCallCenter objEntNewCallCenter = new EntitiesNewCallCenter();

            IEnumerable<CallCenter> query = from u in objEntNewCallCenter.CallCenter
                                            select u;


            this.dgCallCenter.Rows.Clear();

            foreach (CallCenter item in query)
            {
                DataGridViewRow row = (DataGridViewRow)dgCallCenter.Rows[0].Clone();
                row.Cells[0].Value = item.IdCase.ToString();
                row.Cells[1].Value = item.NumRadicado.ToString();
                row.Cells[2].Value = item.NumeroRadicadoTramite.ToString();
                row.Cells[3].Value = item.NumIdentificacion.ToString();
                row.Cells[4].Value = item.TipoIdentificacion.ToString();
                row.Cells[5].Value = item.PrimerNombre.ToString();
                row.Cells[6].Value = item.PrimerApellido.ToString();
                row.Cells[7].Value = item.Ciudad.ToString();
                row.Cells[8].Value = item.TelefonoFijo.ToString();
                row.Cells[9].Value = item.TelefonoMovil.ToString();
                if (item.Estado != null)
                    row.Cells[10].Value = item.Estado.ToString();
                row.Cells[11].Value = item.NombreEvento.ToString();

                this.dgCallCenter.Rows.Add(row);
            }
        }

        private void dgCallCenter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgCallCenter.Rows[e.RowIndex].Clone();

            if (dgCallCenter.CurrentRow.Cells[11].Value != null)
                this.txtNomEvento.Text = dgCallCenter.CurrentRow.Cells[11].Value.ToString().Trim();
            else
                this.txtNomEvento.Text = null;


            if (dgCallCenter.CurrentRow.Cells[0].Value != null)
                this.txtIdCase.Text = dgCallCenter.CurrentRow.Cells[0].Value.ToString();
            else
                this.txtIdCase.Text = null;
            if (dgCallCenter.CurrentRow.Cells[1].Value != null)
                this.txtNoRad.Text = dgCallCenter.CurrentRow.Cells[1].Value.ToString();
            else
                this.txtNoRad.Text = null;
            if (dgCallCenter.CurrentRow.Cells[2].Value != null)
                this.txtNoRadTramite.Text = dgCallCenter.CurrentRow.Cells[2].Value.ToString();
            else
                this.txtNoRadTramite.Text = null;
            if (dgCallCenter.CurrentRow.Cells[3].Value != null)
                this.txtNoIdentificacion.Text = dgCallCenter.CurrentRow.Cells[3].Value.ToString();
            else
                this.txtNoIdentificacion.Text = null;
            if (dgCallCenter.CurrentRow.Cells[4].Value != null)
                this.txtTipoIdentificacion.Text = dgCallCenter.CurrentRow.Cells[4].Value.ToString();
            else
                this.txtTipoIdentificacion.Text = null;
            if (dgCallCenter.CurrentRow.Cells[5].Value != null)
                this.txtPrimerNombre.Text = dgCallCenter.CurrentRow.Cells[5].Value.ToString();
            else
                this.txtPrimerNombre.Text = null;
            if (dgCallCenter.CurrentRow.Cells[6].Value != null)
                this.txtPrimerApellido.Text = dgCallCenter.CurrentRow.Cells[6].Value.ToString();
            else
                this.txtPrimerApellido.Text = null;
            if (dgCallCenter.CurrentRow.Cells[7].Value != null)
                this.txtCiudad.Text = dgCallCenter.CurrentRow.Cells[7].Value.ToString();
            else
                this.txtCiudad.Text = null;
            if (dgCallCenter.CurrentRow.Cells[8].Value != null)
                this.txtTelefono.Text = dgCallCenter.CurrentRow.Cells[8].Value.ToString();
            else
                this.txtTelefono.Text = null;
            if (dgCallCenter.CurrentRow.Cells[9].Value != null)
                this.txtCelular.Text = dgCallCenter.CurrentRow.Cells[9].Value.ToString();
            else
                this.txtCelular.Text = null;
            if (dgCallCenter.CurrentRow.Cells[10].Value != null)
                this.txtEstado.Text = dgCallCenter.CurrentRow.Cells[10].Value.ToString();
            else
                this.txtEstado.Text = null;
        }


        private String BuildXMLNP()
        {
            string res = "";

            DateTime FechaHoy = DateTime.Now;

            res +=  "<BizAgiWSParam>";
	        res +=      "<Events>";
		    res +=          "<Event>";
			res +=              "<EventData>";
			res +=                  "<idCase>" + this.txtIdCase.Text + "</idCase>";
		    res +=                  "<eventName>" + this.txtNomEvento.Text + "</eventName>";
			res +=              "</EventData>";
			res +=              "<Entities>";
			res +=                  "<App>";
			res +=                      "<M_cat_ProcesosDeApoyo>";
			res +=                          "<IdM_PA01_NotificPersonal>";
			res +=                              "<PA01_NotifPnal_Contactos>";

            if ((this.CS1.Checked == true) || (this.CN1.Checked == true))
            {
			    res +=  "<M_PA01_Contactos>";
			    res +=      "<SObservaciones>" + this.txtObsC1.Text + "</SObservaciones>";
			    res +=      "<SNombreContacto>" + this.txtConC1.Text + "</SNombreContacto>";
                if (this.CS1.Checked == true)
			        res += "<BContacto>true</BContacto>";
                else
                    res += "<BContacto>false</BContacto>";
                res += "<DFechaContacto>" + FechaHoy.ToString("o") + "</DFechaContacto>";
			    res +=  "</M_PA01_Contactos>";
            }
            if ((this.CS2.Checked == true) || (this.CN2.Checked == true))
            {
                res += "<M_PA01_Contactos>";
                res += "<SObservaciones>" + this.txtObsC2.Text + "</SObservaciones>";
                res += "<SNombreContacto>" + this.txtConC2.Text + "</SNombreContacto>";
                if (this.CS2.Checked == true)
                    res += "<BContacto>true</BContacto>";
                else
                    res += "<BContacto>false</BContacto>";
                res += "<DFechaContacto>" + FechaHoy.ToString("o") + "</DFechaContacto>";
                res += "</M_PA01_Contactos>";
            }
            if ((this.CS3.Checked == true) || (this.CN3.Checked == true))
            {
                res += "<M_PA01_Contactos>";
                res += "<SObservaciones>" + this.txtObsC3.Text + "</SObservaciones>";
                res += "<SNombreContacto>" + this.txtConC3.Text + "</SNombreContacto>";
                if (this.CS3.Checked == true)
                    res += "<BContacto>true</BContacto>";
                else
                    res += "<BContacto>false</BContacto>";
                res += "<DFechaContacto>" + FechaHoy.ToString("o") + "</DFechaContacto>";
                res += "</M_PA01_Contactos>";
            }

			res +=      "</PA01_NotifPnal_Contactos>";
			res +=      "</IdM_PA01_NotificPersonal>";
			res +=      "</M_cat_ProcesosDeApoyo>";
			res +=      "</App>";
			res +=      "</Entities>";
		    res +=      "</Event>";
	        res +=      "</Events>";
            res +=      "</BizAgiWSParam>";

            return res;
        }

        private void btoGenerarResp_Click(object sender, EventArgs e)
        {
            this.rtXMLGenerado.Text = this.BuildXMLNP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();

            this.rtXMLRespuestaBA.Text = objCapaSOA.ServicioSetEventByXML(this.rtXMLGenerado.Text);
        }

        
        
    }
}
