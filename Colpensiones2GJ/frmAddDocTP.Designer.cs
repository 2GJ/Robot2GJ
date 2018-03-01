namespace Colpensiones2GJ
{
    partial class frmAddDocTP
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
            this.txtCodigoDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLinkDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodigoDocumento
            // 
            this.txtCodigoDocumento.Location = new System.Drawing.Point(134, 55);
            this.txtCodigoDocumento.Name = "txtCodigoDocumento";
            this.txtCodigoDocumento.Size = new System.Drawing.Size(258, 20);
            this.txtCodigoDocumento.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo Documento:";
            // 
            // txtLinkDocumento
            // 
            this.txtLinkDocumento.Location = new System.Drawing.Point(134, 81);
            this.txtLinkDocumento.Name = "txtLinkDocumento";
            this.txtLinkDocumento.Size = new System.Drawing.Size(258, 20);
            this.txtLinkDocumento.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Link Documento:";
            // 
            // txtNombreDocumento
            // 
            this.txtNombreDocumento.Location = new System.Drawing.Point(134, 29);
            this.txtNombreDocumento.Name = "txtNombreDocumento";
            this.txtNombreDocumento.Size = new System.Drawing.Size(258, 20);
            this.txtNombreDocumento.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre Documento:";
            // 
            // btoAceptar
            // 
            this.btoAceptar.Location = new System.Drawing.Point(236, 120);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(75, 23);
            this.btoAceptar.TabIndex = 8;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = true;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // btoCancelar
            // 
            this.btoCancelar.Location = new System.Drawing.Point(317, 120);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(75, 23);
            this.btoCancelar.TabIndex = 9;
            this.btoCancelar.Text = "Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = true;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // frmAddDocTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 155);
            this.Controls.Add(this.btoCancelar);
            this.Controls.Add(this.btoAceptar);
            this.Controls.Add(this.txtNombreDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLinkDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoDocumento);
            this.Controls.Add(this.label1);
            this.Name = "frmAddDocTP";
            this.Text = "frmAddDocTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCodigoDocumento;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtLinkDocumento;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombreDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Button btoCancelar;
    }
}