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
    public partial class frmGetEntitydata : Form
    {
        public frmGetEntitydata()
        {
            InitializeComponent();
        }

        private void btoInvoke_Click(object sender, EventArgs e)
        {
            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            rtbRespuesta.Text = objCapaSOA.ServicioGetEntity(txtInDato.Text);
        }
    }
}
