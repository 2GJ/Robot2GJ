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
    public partial class frmAddGridCTP : Form
    {
        public frmAddGridCTP()
        {
            InitializeComponent();
        }
        
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btoCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAddDoc_Click(object sender, EventArgs e)
        {
            frmAddDocTP objFrmAddDoc = new frmAddDocTP();
            objFrmAddDoc.ShowDialog();


            if (objFrmAddDoc.DialogResult == DialogResult.OK)
            {
                DataGridViewRow row = (DataGridViewRow)dgvDocumentosCTP.Rows[0].Clone();
                row.Cells[0].Value = objFrmAddDoc.txtNombreDocumento.Text;
                row.Cells[1].Value = objFrmAddDoc.txtCodigoDocumento.Text;
                row.Cells[2].Value = objFrmAddDoc.txtLinkDocumento.Text;

                this.dgvDocumentosCTP.Rows.Add(row);
            }
        }
    }
}
