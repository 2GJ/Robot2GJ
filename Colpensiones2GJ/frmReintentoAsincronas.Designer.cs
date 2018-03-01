namespace Colpensiones2GJ
{
    partial class frmReintentoAsincronas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReintentoAsincronas));
            this.grBoxArchivo = new System.Windows.Forms.GroupBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btoReintentarAsincronas = new System.Windows.Forms.Button();
            this.tbRegistrosArchivo = new System.Windows.Forms.TextBox();
            this.lblRegArchivo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRegistrosEjecutados = new System.Windows.Forms.Label();
            this.rtbResultado = new System.Windows.Forms.RichTextBox();
            this.chkActSol = new System.Windows.Forms.CheckBox();
            this.grBoxArchivo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoxArchivo
            // 
            this.grBoxArchivo.BackColor = System.Drawing.Color.Transparent;
            this.grBoxArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grBoxArchivo.Controls.Add(this.btExaminar);
            this.grBoxArchivo.Controls.Add(this.tbExaminar);
            this.grBoxArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grBoxArchivo.Location = new System.Drawing.Point(12, 12);
            this.grBoxArchivo.Name = "grBoxArchivo";
            this.grBoxArchivo.Size = new System.Drawing.Size(894, 50);
            this.grBoxArchivo.TabIndex = 35;
            this.grBoxArchivo.TabStop = false;
            // 
            // btExaminar
            // 
            this.btExaminar.Location = new System.Drawing.Point(8, 14);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(117, 23);
            this.btExaminar.TabIndex = 11;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // tbExaminar
            // 
            this.tbExaminar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbExaminar.Location = new System.Drawing.Point(132, 16);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(756, 21);
            this.tbExaminar.TabIndex = 10;
            this.tbExaminar.TextChanged += new System.EventHandler(this.tbExaminar_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btoReintentarAsincronas);
            this.groupBox1.Controls.Add(this.chkActSol);
            this.groupBox1.Controls.Add(this.tbRegistrosArchivo);
            this.groupBox1.Controls.Add(this.lblRegArchivo);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 365);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Para Ejecución";
            // 
            // btoReintentarAsincronas
            // 
            this.btoReintentarAsincronas.BackColor = System.Drawing.Color.ForestGreen;
            this.btoReintentarAsincronas.Location = new System.Drawing.Point(122, 323);
            this.btoReintentarAsincronas.Name = "btoReintentarAsincronas";
            this.btoReintentarAsincronas.Size = new System.Drawing.Size(206, 23);
            this.btoReintentarAsincronas.TabIndex = 40;
            this.btoReintentarAsincronas.Text = "Reintentar Asincronas";
            this.btoReintentarAsincronas.UseVisualStyleBackColor = false;
            this.btoReintentarAsincronas.Click += new System.EventHandler(this.btoReintentarAsincronas_Click);
            // 
            // tbRegistrosArchivo
            // 
            this.tbRegistrosArchivo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbRegistrosArchivo.Font = new System.Drawing.Font("NeoSansStdBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegistrosArchivo.ForeColor = System.Drawing.Color.Red;
            this.tbRegistrosArchivo.Location = new System.Drawing.Point(131, 28);
            this.tbRegistrosArchivo.Name = "tbRegistrosArchivo";
            this.tbRegistrosArchivo.Size = new System.Drawing.Size(86, 26);
            this.tbRegistrosArchivo.TabIndex = 1;
            // 
            // lblRegArchivo
            // 
            this.lblRegArchivo.AutoSize = true;
            this.lblRegArchivo.Location = new System.Drawing.Point(24, 35);
            this.lblRegArchivo.Name = "lblRegArchivo";
            this.lblRegArchivo.Size = new System.Drawing.Size(101, 13);
            this.lblRegArchivo.TabIndex = 0;
            this.lblRegArchivo.Text = "Registros Archivo:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblRegistrosEjecutados);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(462, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 365);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado Ejecución";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Font = new System.Drawing.Font("NeoSansStdBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(131, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 26);
            this.textBox1.TabIndex = 1;
            // 
            // lblRegistrosEjecutados
            // 
            this.lblRegistrosEjecutados.AutoSize = true;
            this.lblRegistrosEjecutados.Location = new System.Drawing.Point(24, 35);
            this.lblRegistrosEjecutados.Name = "lblRegistrosEjecutados";
            this.lblRegistrosEjecutados.Size = new System.Drawing.Size(101, 13);
            this.lblRegistrosEjecutados.TabIndex = 0;
            this.lblRegistrosEjecutados.Text = "Registros Archivo:";
            // 
            // rtbResultado
            // 
            this.rtbResultado.Location = new System.Drawing.Point(12, 439);
            this.rtbResultado.Name = "rtbResultado";
            this.rtbResultado.Size = new System.Drawing.Size(894, 171);
            this.rtbResultado.TabIndex = 38;
            this.rtbResultado.Text = "";
            // 
            // chkActSol
            // 
            this.chkActSol.AutoSize = true;
            this.chkActSol.BackColor = System.Drawing.Color.Transparent;
            this.chkActSol.Location = new System.Drawing.Point(27, 275);
            this.chkActSol.Margin = new System.Windows.Forms.Padding(2);
            this.chkActSol.Name = "chkActSol";
            this.chkActSol.Size = new System.Drawing.Size(171, 17);
            this.chkActSol.TabIndex = 39;
            this.chkActSol.Text = "Aplicar o Generar Soluciones";
            this.chkActSol.UseVisualStyleBackColor = false;
            // 
            // frmReintentoAsincronas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 622);
            this.Controls.Add(this.rtbResultado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBoxArchivo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("NeoSansStdBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReintentoAsincronas";
            this.Text = "Reintento Asincronas";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.grBoxArchivo.ResumeLayout(false);
            this.grBoxArchivo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxArchivo;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRegistrosArchivo;
        private System.Windows.Forms.Label lblRegArchivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRegistrosEjecutados;
        private System.Windows.Forms.RichTextBox rtbResultado;
        private System.Windows.Forms.Button btoReintentarAsincronas;
        private System.Windows.Forms.CheckBox chkActSol;
    }
}