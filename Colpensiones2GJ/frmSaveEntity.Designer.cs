namespace Colpensiones2GJ
{
    partial class frmSaveEntity
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
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btoExaminar = new System.Windows.Forms.Button();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.chkAplicaTiempo = new System.Windows.Forms.CheckBox();
            this.txtEjecutados = new System.Windows.Forms.TextBox();
            this.txtTotalReg = new System.Windows.Forms.TextBox();
            this.btoInvocar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEstimadoFin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTiempoEjecucion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbSaveEntityCase = new System.Windows.Forms.RadioButton();
            this.rbSaveEntityEntity = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(9, 19);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(562, 205);
            this.rtbRespuesta.TabIndex = 2;
            this.rtbRespuesta.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Controls.Add(this.txtRutaArchivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 78);
            this.groupBox1.TabIndex = 3;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.rtbRespuesta);
            this.groupBox2.Location = new System.Drawing.Point(12, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 235);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(577, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 205);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Col 2 -> XML Modelo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Col 1 -> RadNumber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Col 0 -> IdCase";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbSaveEntityEntity);
            this.groupBox3.Controls.Add(this.rbSaveEntityCase);
            this.groupBox3.Controls.Add(this.lblTiempo);
            this.groupBox3.Controls.Add(this.txtTiempo);
            this.groupBox3.Controls.Add(this.chkAplicaTiempo);
            this.groupBox3.Controls.Add(this.txtEjecutados);
            this.groupBox3.Controls.Add(this.txtTotalReg);
            this.groupBox3.Controls.Add(this.btoInvocar);
            this.groupBox3.Location = new System.Drawing.Point(12, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 180);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(123, 68);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(67, 13);
            this.lblTiempo.TabIndex = 11;
            this.lblTiempo.Text = "Tiempo (ms):";
            this.lblTiempo.Visible = false;
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(194, 66);
            this.txtTiempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(68, 20);
            this.txtTiempo.TabIndex = 10;
            this.txtTiempo.Visible = false;
            // 
            // chkAplicaTiempo
            // 
            this.chkAplicaTiempo.AutoSize = true;
            this.chkAplicaTiempo.Location = new System.Drawing.Point(9, 45);
            this.chkAplicaTiempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkAplicaTiempo.Name = "chkAplicaTiempo";
            this.chkAplicaTiempo.Size = new System.Drawing.Size(185, 17);
            this.chkAplicaTiempo.TabIndex = 9;
            this.chkAplicaTiempo.Text = "Aplicar Tiempo Entre Ejecuciones";
            this.chkAplicaTiempo.UseVisualStyleBackColor = true;
            this.chkAplicaTiempo.CheckedChanged += new System.EventHandler(this.chkAplicaTiempo_CheckedChanged);
            // 
            // txtEjecutados
            // 
            this.txtEjecutados.BackColor = System.Drawing.Color.Red;
            this.txtEjecutados.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjecutados.Location = new System.Drawing.Point(134, 135);
            this.txtEjecutados.Name = "txtEjecutados";
            this.txtEjecutados.Size = new System.Drawing.Size(131, 38);
            this.txtEjecutados.TabIndex = 8;
            // 
            // txtTotalReg
            // 
            this.txtTotalReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReg.Location = new System.Drawing.Point(4, 135);
            this.txtTotalReg.Name = "txtTotalReg";
            this.txtTotalReg.Size = new System.Drawing.Size(131, 38);
            this.txtTotalReg.TabIndex = 7;
            // 
            // btoInvocar
            // 
            this.btoInvocar.Location = new System.Drawing.Point(6, 91);
            this.btoInvocar.Name = "btoInvocar";
            this.btoInvocar.Size = new System.Drawing.Size(256, 38);
            this.btoInvocar.TabIndex = 6;
            this.btoInvocar.Text = "Invocar";
            this.btoInvocar.UseVisualStyleBackColor = true;
            this.btoInvocar.Click += new System.EventHandler(this.btoInvocar_Click_2);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Location = new System.Drawing.Point(289, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(506, 180);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.txtEstimadoFin);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtPromedio);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtTiempoEjecucion);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtFechaFin);
            this.panel2.Controls.Add(this.txtFechaInicio);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 155);
            this.panel2.TabIndex = 0;
            // 
            // txtEstimadoFin
            // 
            this.txtEstimadoFin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtEstimadoFin.Enabled = false;
            this.txtEstimadoFin.Location = new System.Drawing.Point(133, 83);
            this.txtEstimadoFin.Name = "txtEstimadoFin";
            this.txtEstimadoFin.Size = new System.Drawing.Size(112, 20);
            this.txtEstimadoFin.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Tiempo Estimado Fin:";
            // 
            // txtPromedio
            // 
            this.txtPromedio.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPromedio.Enabled = false;
            this.txtPromedio.Location = new System.Drawing.Point(133, 58);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(112, 20);
            this.txtPromedio.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Promedio Por Registro:";
            // 
            // txtTiempoEjecucion
            // 
            this.txtTiempoEjecucion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTiempoEjecucion.Enabled = false;
            this.txtTiempoEjecucion.Location = new System.Drawing.Point(110, 32);
            this.txtTiempoEjecucion.Name = "txtTiempoEjecucion";
            this.txtTiempoEjecucion.Size = new System.Drawing.Size(135, 20);
            this.txtTiempoEjecucion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tiempo Ejecucion:";
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtFechaFin.Enabled = false;
            this.txtFechaFin.Location = new System.Drawing.Point(338, 6);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(135, 20);
            this.txtFechaFin.TabIndex = 3;
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtFechaInicio.Enabled = false;
            this.txtFechaInicio.Location = new System.Drawing.Point(110, 6);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(135, 20);
            this.txtFechaInicio.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fin de Proceso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Inicio de Proceso:";
            // 
            // rbSaveEntityCase
            // 
            this.rbSaveEntityCase.AutoSize = true;
            this.rbSaveEntityCase.Location = new System.Drawing.Point(9, 18);
            this.rbSaveEntityCase.Name = "rbSaveEntityCase";
            this.rbSaveEntityCase.Size = new System.Drawing.Size(113, 17);
            this.rbSaveEntityCase.TabIndex = 12;
            this.rbSaveEntityCase.TabStop = true;
            this.rbSaveEntityCase.Text = "SaveEntity X Case";
            this.rbSaveEntityCase.UseVisualStyleBackColor = true;
            // 
            // rbSaveEntityEntity
            // 
            this.rbSaveEntityEntity.AutoSize = true;
            this.rbSaveEntityEntity.Location = new System.Drawing.Point(134, 18);
            this.rbSaveEntityEntity.Name = "rbSaveEntityEntity";
            this.rbSaveEntityEntity.Size = new System.Drawing.Size(115, 17);
            this.rbSaveEntityEntity.TabIndex = 13;
            this.rbSaveEntityEntity.TabStop = true;
            this.rbSaveEntityEntity.Text = "SaveEntity X Entity";
            this.rbSaveEntityEntity.UseVisualStyleBackColor = true;
            // 
            // frmSaveEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 525);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSaveEntity";
            this.Text = "frmSaveEntity";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbRespuesta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEjecutados;
        private System.Windows.Forms.TextBox txtTotalReg;
        private System.Windows.Forms.Button btoInvocar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTiempoEjecucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEstimadoFin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.CheckBox chkAplicaTiempo;
        private System.Windows.Forms.RadioButton rbSaveEntityEntity;
        private System.Windows.Forms.RadioButton rbSaveEntityCase;
    }
}