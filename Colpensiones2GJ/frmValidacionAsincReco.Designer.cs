namespace Colpensiones2GJ
{
    partial class frmValidacionAsincReco
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
            this.btLeerArchivo = new System.Windows.Forms.Button();
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.Conteo = new System.Windows.Forms.Label();
            this.RegTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbOK = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTEstFin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTPromedio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTEjecucion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkActSol = new System.Windows.Forms.CheckBox();
            this.btoReintentarAsincronas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLeerArchivo
            // 
            this.btLeerArchivo.Location = new System.Drawing.Point(16, 124);
            this.btLeerArchivo.Name = "btLeerArchivo";
            this.btLeerArchivo.Size = new System.Drawing.Size(206, 23);
            this.btLeerArchivo.TabIndex = 2;
            this.btLeerArchivo.Text = "Reintentar Asincronas";
            this.btLeerArchivo.UseVisualStyleBackColor = true;
            this.btLeerArchivo.Click += new System.EventHandler(this.btLeerArchivo_Click);
            // 
            // rtbResultado
            // 
            this.rtbResultado.Location = new System.Drawing.Point(16, 250);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.Size = new System.Drawing.Size(849, 300);
            this.rtbResultado.TabIndex = 3;
            this.rtbResultado.Text = "";
            // 
            // Conteo
            // 
            this.Conteo.BackColor = System.Drawing.Color.Red;
            this.Conteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conteo.Location = new System.Drawing.Point(16, 150);
            this.Conteo.Name = "Conteo";
            this.Conteo.Size = new System.Drawing.Size(206, 25);
            this.Conteo.TabIndex = 5;
            this.Conteo.Text = "0";
            // 
            // RegTotal
            // 
            this.RegTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTotal.Location = new System.Drawing.Point(16, 94);
            this.RegTotal.Name = "RegTotal";
            this.RegTotal.Size = new System.Drawing.Size(100, 25);
            this.RegTotal.TabIndex = 33;
            this.RegTotal.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btExaminar);
            this.groupBox1.Controls.Add(this.tbExaminar);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 50);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btExaminar
            // 
            this.btExaminar.Location = new System.Drawing.Point(7, 14);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(100, 23);
            this.btExaminar.TabIndex = 11;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click_1);
            // 
            // tbExaminar
            // 
            this.tbExaminar.Location = new System.Drawing.Point(113, 16);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(730, 20);
            this.tbExaminar.TabIndex = 10;
            this.tbExaminar.TextChanged += new System.EventHandler(this.tbExaminar_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Cargar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.tbError);
            this.panel1.Controls.Add(this.tbOK);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbTEstFin);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbTPromedio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbTEjecucion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Location = new System.Drawing.Point(228, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 176);
            this.panel1.TabIndex = 36;
            // 
            // tbError
            // 
            this.tbError.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbError.Enabled = false;
            this.tbError.Location = new System.Drawing.Point(196, 101);
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(100, 20);
            this.tbError.TabIndex = 19;
            // 
            // tbOK
            // 
            this.tbOK.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbOK.Enabled = false;
            this.tbOK.Location = new System.Drawing.Point(196, 75);
            this.tbOK.Name = "tbOK";
            this.tbOK.Size = new System.Drawing.Size(100, 20);
            this.tbOK.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "EJECUTADOS CON ERROR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "EJECUTADOS CORRECTAMENTE";
            // 
            // tbTEstFin
            // 
            this.tbTEstFin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbTEstFin.Enabled = false;
            this.tbTEstFin.Location = new System.Drawing.Point(163, 50);
            this.tbTEstFin.Name = "tbTEstFin";
            this.tbTEstFin.Size = new System.Drawing.Size(100, 20);
            this.tbTEstFin.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tiempo Estimado Finalizacion:";
            // 
            // tbTPromedio
            // 
            this.tbTPromedio.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbTPromedio.Enabled = false;
            this.tbTPromedio.Location = new System.Drawing.Point(163, 29);
            this.tbTPromedio.Name = "tbTPromedio";
            this.tbTPromedio.Size = new System.Drawing.Size(100, 20);
            this.tbTPromedio.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tiempo Promedio:";
            // 
            // tbTEjecucion
            // 
            this.tbTEjecucion.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbTEjecucion.Enabled = false;
            this.tbTEjecucion.Location = new System.Drawing.Point(163, 8);
            this.tbTEjecucion.Name = "tbTEjecucion";
            this.tbTEjecucion.Size = new System.Drawing.Size(100, 20);
            this.tbTEjecucion.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tiempo De Ejecucion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "2 - IdTask";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "1 - No. Radicacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "0 - IdCase";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columnas Reintento Asincronas:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(635, 176);
            this.shapeContainer1.TabIndex = 20;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 310;
            this.lineShape1.X2 = 310;
            this.lineShape1.Y1 = 17;
            this.lineShape1.Y2 = 111;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(16, 178);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(127, 17);
            this.chkLog.TabIndex = 37;
            this.chkLog.Text = "Imprimir Log de Envio";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // chkActSol
            // 
            this.chkActSol.AutoSize = true;
            this.chkActSol.Location = new System.Drawing.Point(16, 199);
            this.chkActSol.Margin = new System.Windows.Forms.Padding(2);
            this.chkActSol.Name = "chkActSol";
            this.chkActSol.Size = new System.Drawing.Size(163, 17);
            this.chkActSol.TabIndex = 38;
            this.chkActSol.Text = "Aplicar o Generar Soluciones";
            this.chkActSol.UseVisualStyleBackColor = true;
            // 
            // btoReintentarAsincronas
            // 
            this.btoReintentarAsincronas.Location = new System.Drawing.Point(16, 221);
            this.btoReintentarAsincronas.Name = "btoReintentarAsincronas";
            this.btoReintentarAsincronas.Size = new System.Drawing.Size(206, 23);
            this.btoReintentarAsincronas.TabIndex = 39;
            this.btoReintentarAsincronas.Text = "New Reintentar Asincronas";
            this.btoReintentarAsincronas.UseVisualStyleBackColor = true;
            this.btoReintentarAsincronas.Click += new System.EventHandler(this.btoReintentarAsincronas_Click);
            // 
            // frmValidacionAsincReco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 562);
            this.Controls.Add(this.btoReintentarAsincronas);
            this.Controls.Add(this.chkActSol);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RegTotal);
            this.Controls.Add(this.Conteo);
            this.Controls.Add(this.rtbResultado);
            this.Controls.Add(this.btLeerArchivo);
            this.Name = "frmValidacionAsincReco";
            this.Text = "Administracion Asincronas Reconocimiento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLeerArchivo;
        private System.Windows.Forms.RichTextBox rtbResultado;
        private System.Windows.Forms.Label Conteo;
        private System.Windows.Forms.Label RegTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.TextBox tbOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTEstFin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTPromedio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTEjecucion;
        private System.Windows.Forms.Label label5;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.CheckBox chkActSol;
        private System.Windows.Forms.Button btoReintentarAsincronas;
    }
}