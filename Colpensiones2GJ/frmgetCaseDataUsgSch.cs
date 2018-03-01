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
    public partial class frmgetCaseDataUsgSch : Form
    {
        public frmgetCaseDataUsgSch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");

            string sRes = objCapaSOA.getCaseDataUsingSchemaAsString(Convert.ToInt32(tbIdCase.Text), tbXSD.Text);

            rtbRespuesta.Text = sRes;
        }

       
    }
}
