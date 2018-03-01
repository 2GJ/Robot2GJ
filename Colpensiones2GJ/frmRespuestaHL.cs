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
    public partial class frmRespuestaHL : Form
    {
        public frmRespuestaHL()
        {
            InitializeComponent();
        }

        private void btInvocar_Click(object sender, EventArgs e)
        {
            CapaSOABAWF.WorkflowEngineSOASoapClient objCapaSOAWF = new CapaSOABAWF.WorkflowEngineSOASoapClient("WorkflowEngineSOASoap");

            string sXML = "<BizAgiWSParam>";
            sXML += "<Events>";
            sXML += "<Event>";
            sXML += "<EventData>";
            sXML += "<radNumber>" + tbRadNumber.Text + "</radNumber>";
            sXML += "<eventName>RCEventHistoriaLaboral</eventName>";
            sXML += "</EventData>";
            sXML += "<Entities>";
            sXML += "<App>";
            sXML += "<M_cat_Reconocimiento>";
            sXML += "<IdM_RC01Reconocimiento>";
            sXML += "<SDetalleErrorHistoriaLab>" + tbDetalleErrorHL.Text + "</SDetalleErrorHistoriaLab>";
            sXML += "<STotalSemanas>" + tbTotalSemanas.Text + "</STotalSemanas>";
            sXML += "<SErrorHistoriaLaboral>" + tbCodErrorHL.Text +"</SErrorHistoriaLaboral>";
            sXML += "<SDesErrorValidacion>" + tbDetalleErrValHL.Text + "</SDesErrorValidacion>";
            sXML += "<SCodErrorValidacion>" + tbCodValHL.Text + "</SCodErrorValidacion>";
            sXML += "</IdM_RC01Reconocimiento>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</App>";
            sXML += "</Entities>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";

            string sRes = objCapaSOAWF.setEventAsString2(sXML);

            rtbRespuesta.Text = sRes;
        }

 
    }
}
