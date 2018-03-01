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
    public partial class frmRespuestaBDM : Form
    {
        public frmRespuestaBDM()
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
            sXML += "<eventName>ActualizacionBDMisionales</eventName>";
            sXML += "</EventData>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";

            string sRes = objCapaSOAWF.setEventAsString2(sXML);

            rtbRespuesta.Text = sRes;
        }
    }
}
