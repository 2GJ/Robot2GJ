namespace Colpensiones2GJ
{
    partial class frmAddGridCTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCiudadano = new System.Windows.Forms.TextBox();
            this.txtNoDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNitEmpresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccionEmpresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCiudadEmpresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.dgvDocumentosCTP = new System.Windows.Forms.DataGridView();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtAddDoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosCTP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Ciudadano:";
            // 
            // txtNombreCiudadano
            // 
            this.txtNombreCiudadano.Location = new System.Drawing.Point(141, 26);
            this.txtNombreCiudadano.Name = "txtNombreCiudadano";
            this.txtNombreCiudadano.Size = new System.Drawing.Size(258, 20);
            this.txtNombreCiudadano.TabIndex = 1;
            // 
            // txtNoDocumento
            // 
            this.txtNoDocumento.Location = new System.Drawing.Point(141, 52);
            this.txtNoDocumento.Name = "txtNoDocumento";
            this.txtNoDocumento.Size = new System.Drawing.Size(258, 20);
            this.txtNoDocumento.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Documento:";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(141, 78);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(258, 20);
            this.txtNombreEmpresa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre Empresa:";
            // 
            // txtNitEmpresa
            // 
            this.txtNitEmpresa.Location = new System.Drawing.Point(141, 104);
            this.txtNitEmpresa.Name = "txtNitEmpresa";
            this.txtNitEmpresa.Size = new System.Drawing.Size(258, 20);
            this.txtNitEmpresa.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nit Empresa:";
            // 
            // txtDireccionEmpresa
            // 
            this.txtDireccionEmpresa.Location = new System.Drawing.Point(141, 130);
            this.txtDireccionEmpresa.Name = "txtDireccionEmpresa";
            this.txtDireccionEmpresa.Size = new System.Drawing.Size(258, 20);
            this.txtDireccionEmpresa.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion Empresa:";
            // 
            // txtCiudadEmpresa
            // 
            this.txtCiudadEmpresa.Location = new System.Drawing.Point(141, 156);
            this.txtCiudadEmpresa.Name = "txtCiudadEmpresa";
            this.txtCiudadEmpresa.Size = new System.Drawing.Size(258, 20);
            this.txtCiudadEmpresa.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ciudad Empresa:";
            // 
            // btoCancelar
            // 
            this.btoCancelar.Location = new System.Drawing.Point(395, 397);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(75, 23);
            this.btoCancelar.TabIndex = 12;
            this.btoCancelar.Text = "Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = true;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.Location = new System.Drawing.Point(314, 397);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(75, 23);
            this.btoAceptar.TabIndex = 13;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = true;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // dgvDocumentosCTP
            // 
            this.dgvDocumentosCTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentosCTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Documento,
            this.LinkDocumento,
            this.CodigoDocumento,
            this.Editar});
            this.dgvDocumentosCTP.Location = new System.Drawing.Point(12, 216);
            this.dgvDocumentosCTP.Name = "dgvDocumentosCTP";
            this.dgvDocumentosCTP.Size = new System.Drawing.Size(461, 150);
            this.dgvDocumentosCTP.TabIndex = 14;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // LinkDocumento
            // 
            this.LinkDocumento.HeaderText = "Link Documento";
            this.LinkDocumento.Name = "LinkDocumento";
            this.LinkDocumento.ReadOnly = true;
            // 
            // CodigoDocumento
            // 
            this.CodigoDocumento.HeaderText = "Codigo Documento";
            this.CodigoDocumento.Name = "CodigoDocumento";
            this.CodigoDocumento.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // txtAddDoc
            // 
            this.txtAddDoc.Location = new System.Drawing.Point(174, 187);
            this.txtAddDoc.Name = "txtAddDoc";
            this.txtAddDoc.Size = new System.Drawing.Size(122, 23);
            this.txtAddDoc.TabIndex = 15;
            this.txtAddDoc.Text = "Add Documento";
            this.txtAddDoc.UseVisualStyleBackColor = true;
            this.txtAddDoc.Click += new System.EventHandler(this.txtAddDoc_Click);
            // 
            // frmAddGridCTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 432);
            this.Controls.Add(this.txtAddDoc);
            this.Controls.Add(this.dgvDocumentosCTP);
            this.Controls.Add(this.btoAceptar);
            this.Controls.Add(this.btoCancelar);
            this.Controls.Add(this.txtCiudadEmpresa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDireccionEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNitEmpresa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreCiudadano);
            this.Controls.Add(this.label1);
            this.Name = "frmAddGridCTP";
            this.Text = "Agregar Confirmacion Tiempos Publicos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentosCTP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.Button btoAceptar;
        public System.Windows.Forms.TextBox txtNombreCiudadano;
        public System.Windows.Forms.TextBox txtNoDocumento;
        public System.Windows.Forms.TextBox txtNombreEmpresa;
        public System.Windows.Forms.TextBox txtNitEmpresa;
        public System.Windows.Forms.TextBox txtDireccionEmpresa;
        public System.Windows.Forms.TextBox txtCiudadEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoDocumento;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button txtAddDoc;
        public System.Windows.Forms.DataGridView dgvDocumentosCTP;
    }
}