namespace Colpensiones2GJ
{
    partial class frmCreateScriptSQL
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btoExaminar = new System.Windows.Forms.Button();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.txtEjecutados = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalReg = new System.Windows.Forms.TextBox();
            this.btoInvocar = new System.Windows.Forms.Button();
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Controls.Add(this.txtRutaArchivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(684, 45);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(93, 23);
            this.btoExaminar.TabIndex = 4;
            this.btoExaminar.Text = "Examinar";
            this.btoExaminar.UseVisualStyleBackColor = true;
            this.btoExaminar.Click += new System.EventHandler(this.btoExaminar_Click);
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(9, 19);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(768, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // txtEjecutados
            // 
            this.txtEjecutados.BackColor = System.Drawing.Color.Red;
            this.txtEjecutados.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjecutados.Location = new System.Drawing.Point(140, 63);
            this.txtEjecutados.Name = "txtEjecutados";
            this.txtEjecutados.Size = new System.Drawing.Size(131, 38);
            this.txtEjecutados.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtEjecutados);
            this.groupBox3.Controls.Add(this.txtTotalReg);
            this.groupBox3.Controls.Add(this.btoInvocar);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 114);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // txtTotalReg
            // 
            this.txtTotalReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReg.Location = new System.Drawing.Point(6, 63);
            this.txtTotalReg.Name = "txtTotalReg";
            this.txtTotalReg.Size = new System.Drawing.Size(131, 38);
            this.txtTotalReg.TabIndex = 7;
            // 
            // btoInvocar
            // 
            this.btoInvocar.Location = new System.Drawing.Point(6, 19);
            this.btoInvocar.Name = "btoInvocar";
            this.btoInvocar.Size = new System.Drawing.Size(265, 38);
            this.btoInvocar.TabIndex = 6;
            this.btoInvocar.Text = "Invocar";
            this.btoInvocar.UseVisualStyleBackColor = true;
            this.btoInvocar.Click += new System.EventHandler(this.btoInvocar_Click);
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(12, 216);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(783, 229);
            this.rtbRespuesta.TabIndex = 7;
            this.rtbRespuesta.Text = "";
            // 
            // frmCreateScriptSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 457);
            this.Controls.Add(this.rtbRespuesta);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCreateScriptSQL";
            this.Text = "frmCreateScriptSQL";
            this.Load += new System.EventHandler(this.frmCreateScriptSQL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.TextBox txtEjecutados;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTotalReg;
        private System.Windows.Forms.Button btoInvocar;
        private System.Windows.Forms.RichTextBox rtbRespuesta;
    }
}