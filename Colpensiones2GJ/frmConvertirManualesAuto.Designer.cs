namespace Colpensiones2GJ
{
    partial class frmConvertirManualesAuto
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
            this.rtbResCaso = new System.Windows.Forms.RichTextBox();
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.btLeerArchivo = new System.Windows.Forms.Button();
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.Conteo = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.btoCargarArchivo = new System.Windows.Forms.Button();
            this.chkVerificacion = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbOK = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbTEstFin = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbTPromedio = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbTEjecucion = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbResCaso
            // 
            this.rtbResCaso.Location = new System.Drawing.Point(238, 95);
            this.rtbResCaso.Name = "rtbResCaso";
            this.rtbResCaso.Size = new System.Drawing.Size(195, 287);
            this.rtbResCaso.TabIndex = 9;
            this.rtbResCaso.Text = "";
            // 
            // rtbResultado
            // 
            this.rtbResultado.Location = new System.Drawing.Point(12, 73);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.Size = new System.Drawing.Size(647, 489);
            this.rtbResultado.TabIndex = 8;
            this.rtbResultado.Text = "";
            // 
            // btLeerArchivo
            // 
            this.btLeerArchivo.Location = new System.Drawing.Point(237, 44);
            this.btLeerArchivo.Name = "btLeerArchivo";
            this.btLeerArchivo.Size = new System.Drawing.Size(112, 23);
            this.btLeerArchivo.TabIndex = 7;
            this.btLeerArchivo.Text = "Leer Archivo";
            this.btLeerArchivo.UseVisualStyleBackColor = true;
            this.btLeerArchivo.Click += new System.EventHandler(this.btLeerArchivo_Click);
            // 
            // tbExaminar
            // 
            this.tbExaminar.Location = new System.Drawing.Point(94, 12);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(565, 20);
            this.tbExaminar.TabIndex = 6;
            // 
            // btExaminar
            // 
            this.btExaminar.Location = new System.Drawing.Point(12, 12);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(75, 23);
            this.btExaminar.TabIndex = 5;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // Conteo
            // 
            this.Conteo.BackColor = System.Drawing.Color.Red;
            this.Conteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conteo.Location = new System.Drawing.Point(355, 40);
            this.Conteo.Name = "Conteo";
            this.Conteo.Size = new System.Drawing.Size(101, 25);
            this.Conteo.TabIndex = 14;
            this.Conteo.Text = "0";
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.Color.RoyalBlue;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(130, 43);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(101, 25);
            this.Total.TabIndex = 15;
            this.Total.Text = "0";
            // 
            // btoCargarArchivo
            // 
            this.btoCargarArchivo.Location = new System.Drawing.Point(12, 44);
            this.btoCargarArchivo.Name = "btoCargarArchivo";
            this.btoCargarArchivo.Size = new System.Drawing.Size(112, 23);
            this.btoCargarArchivo.TabIndex = 17;
            this.btoCargarArchivo.Text = "Cargar Archivo";
            this.btoCargarArchivo.UseVisualStyleBackColor = true;
            this.btoCargarArchivo.Click += new System.EventHandler(this.btoCargarArchivo_Click);
            // 
            // chkVerificacion
            // 
            this.chkVerificacion.AutoSize = true;
            this.chkVerificacion.Location = new System.Drawing.Point(456, 123);
            this.chkVerificacion.Name = "chkVerificacion";
            this.chkVerificacion.Size = new System.Drawing.Size(163, 17);
            this.chkVerificacion.TabIndex = 18;
            this.chkVerificacion.Text = "Solicitar Verificacion del Acto";
            this.chkVerificacion.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBox1.Location = new System.Drawing.Point(665, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(468, 561);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Location = new System.Drawing.Point(683, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Col0 - IdCase";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.Location = new System.Drawing.Point(683, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Col5 - Recurso o Instancia";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Location = new System.Drawing.Point(683, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Col4 - ActualizarTramite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Location = new System.Drawing.Point(683, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Col3 - SucursalBanco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Location = new System.Drawing.Point(683, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Col2 - TipoLiquidacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Location = new System.Drawing.Point(683, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Col1 - RadNumber";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Location = new System.Drawing.Point(719, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "RECONOCIMIENTO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label8.Location = new System.Drawing.Point(719, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "RELIQUIDACION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label9.Location = new System.Drawing.Point(719, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "N/A -> No se realiza actualizacion de banco.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label10.Location = new System.Drawing.Point(719, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(253, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "0 -> Se Busca un Banco en la ciudad de residencia.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label11.Location = new System.Drawing.Point(719, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(223, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Id Entero -> Se actualiza a ese id de sucursal.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label12.Location = new System.Drawing.Point(719, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(392, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Si es Recurso Pension de Vejez se Actualiza a Reconocimiento Pension de Vejez";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label13.Location = new System.Drawing.Point(719, 267);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "1 -> Recurso de Reposicion";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label14.Location = new System.Drawing.Point(719, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "2 -> Recurso de Apelacion";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label15.Location = new System.Drawing.Point(719, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "3 -> Revocaria Directa";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label16.Location = new System.Drawing.Point(719, 313);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "4 -> Recurso de Queja";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label17.Location = new System.Drawing.Point(719, 329);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "5 -> Nuevo Estudio";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label18.Location = new System.Drawing.Point(719, 345);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "6 -> Fallo";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label19.Location = new System.Drawing.Point(719, 362);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "7 -> Sentencia";
            // 
            // tbError
            // 
            this.tbError.BackColor = System.Drawing.SystemColors.Window;
            this.tbError.Enabled = false;
            this.tbError.Location = new System.Drawing.Point(945, 536);
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(100, 20);
            this.tbError.TabIndex = 49;
            // 
            // tbOK
            // 
            this.tbOK.BackColor = System.Drawing.SystemColors.Window;
            this.tbOK.Enabled = false;
            this.tbOK.Location = new System.Drawing.Point(945, 509);
            this.tbOK.Name = "tbOK";
            this.tbOK.Size = new System.Drawing.Size(100, 20);
            this.tbOK.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label20.Location = new System.Drawing.Point(745, 539);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(146, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "EJECUTADOS CON ERROR";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label21.Location = new System.Drawing.Point(745, 512);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(178, 13);
            this.label21.TabIndex = 46;
            this.label21.Text = "EJECUTADOS CORRECTAMENTE";
            // 
            // tbTEstFin
            // 
            this.tbTEstFin.BackColor = System.Drawing.SystemColors.Window;
            this.tbTEstFin.Enabled = false;
            this.tbTEstFin.Location = new System.Drawing.Point(922, 468);
            this.tbTEstFin.Name = "tbTEstFin";
            this.tbTEstFin.Size = new System.Drawing.Size(100, 20);
            this.tbTEstFin.TabIndex = 45;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label22.Location = new System.Drawing.Point(742, 471);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "Tiempo Estimado Finalizacion:";
            // 
            // tbTPromedio
            // 
            this.tbTPromedio.BackColor = System.Drawing.SystemColors.Window;
            this.tbTPromedio.Enabled = false;
            this.tbTPromedio.Location = new System.Drawing.Point(922, 442);
            this.tbTPromedio.Name = "tbTPromedio";
            this.tbTPromedio.Size = new System.Drawing.Size(100, 20);
            this.tbTPromedio.TabIndex = 43;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label23.Location = new System.Drawing.Point(742, 445);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 13);
            this.label23.TabIndex = 42;
            this.label23.Text = "Tiempo Promedio:";
            // 
            // tbTEjecucion
            // 
            this.tbTEjecucion.BackColor = System.Drawing.SystemColors.Window;
            this.tbTEjecucion.Enabled = false;
            this.tbTEjecucion.Location = new System.Drawing.Point(922, 416);
            this.tbTEjecucion.Name = "tbTEjecucion";
            this.tbTEjecucion.Size = new System.Drawing.Size(100, 20);
            this.tbTEjecucion.TabIndex = 41;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label24.Location = new System.Drawing.Point(742, 419);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 13);
            this.label24.TabIndex = 40;
            this.label24.Text = "Tiempo De Ejecucion:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label25.Location = new System.Drawing.Point(683, 389);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(209, 13);
            this.label25.TabIndex = 50;
            this.label25.Text = "Col6 - Fecha Solicitud (string AAAAMMDD)";
            // 
            // frmConvertirManualesAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 582);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.tbOK);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tbTEstFin);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbTPromedio);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tbTEjecucion);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rtbResultado);
            this.Controls.Add(this.btoCargarArchivo);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.Conteo);
            this.Controls.Add(this.rtbResCaso);
            this.Controls.Add(this.btLeerArchivo);
            this.Controls.Add(this.tbExaminar);
            this.Controls.Add(this.btExaminar);
            this.Controls.Add(this.chkVerificacion);
            this.Name = "frmConvertirManualesAuto";
            this.Text = "Convertir caso Manual en Automatico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbResCaso;
        private System.Windows.Forms.RichTextBox rtbResultado;
        private System.Windows.Forms.Button btLeerArchivo;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.Label Conteo;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Button btoCargarArchivo;
        private System.Windows.Forms.CheckBox chkVerificacion;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.TextBox tbOK;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbTEstFin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbTPromedio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbTEjecucion;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
    }
}