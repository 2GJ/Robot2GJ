namespace Colpensiones2GJ
{
    partial class frmPruebaCargaArchivoTXT
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
            this.btoExaminar = new System.Windows.Forms.Button();
            this.tbRutaArchivo = new System.Windows.Forms.TextBox();
            this.rtbLecturaArchivo = new System.Windows.Forms.RichTextBox();
            this.btLeerArchivo = new System.Windows.Forms.Button();
            this.rtbResInforec = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(13, 13);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(75, 23);
            this.btoExaminar.TabIndex = 0;
            this.btoExaminar.Text = "Examinar";
            this.btoExaminar.UseVisualStyleBackColor = true;
            this.btoExaminar.Click += new System.EventHandler(this.btoExaminar_Click);
            // 
            // tbRutaArchivo
            // 
            this.tbRutaArchivo.Location = new System.Drawing.Point(95, 15);
            this.tbRutaArchivo.Name = "tbRutaArchivo";
            this.tbRutaArchivo.Size = new System.Drawing.Size(451, 20);
            this.tbRutaArchivo.TabIndex = 1;
            // 
            // rtbLecturaArchivo
            // 
            this.rtbLecturaArchivo.Location = new System.Drawing.Point(13, 73);
            this.rtbLecturaArchivo.Name = "rtbLecturaArchivo";
            this.rtbLecturaArchivo.Size = new System.Drawing.Size(533, 419);
            this.rtbLecturaArchivo.TabIndex = 2;
            this.rtbLecturaArchivo.Text = "";
            // 
            // btLeerArchivo
            // 
            this.btLeerArchivo.Location = new System.Drawing.Point(13, 43);
            this.btLeerArchivo.Name = "btLeerArchivo";
            this.btLeerArchivo.Size = new System.Drawing.Size(75, 23);
            this.btLeerArchivo.TabIndex = 3;
            this.btLeerArchivo.Text = "Leer Archivo";
            this.btLeerArchivo.UseVisualStyleBackColor = true;
            this.btLeerArchivo.Click += new System.EventHandler(this.btLeerArchivo_Click);
            // 
            // rtbResInforec
            // 
            this.rtbResInforec.Location = new System.Drawing.Point(552, 12);
            this.rtbResInforec.Name = "rtbResInforec";
            this.rtbResInforec.Size = new System.Drawing.Size(401, 480);
            this.rtbResInforec.TabIndex = 4;
            this.rtbResInforec.Text = "";
            // 
            // frmPruebaCargaArchivoTXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 504);
            this.Controls.Add(this.rtbResInforec);
            this.Controls.Add(this.btLeerArchivo);
            this.Controls.Add(this.rtbLecturaArchivo);
            this.Controls.Add(this.tbRutaArchivo);
            this.Controls.Add(this.btoExaminar);
            this.Name = "frmPruebaCargaArchivoTXT";
            this.Text = "frmPruebaCargaArchivoTXT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox tbRutaArchivo;
        private System.Windows.Forms.RichTextBox rtbLecturaArchivo;
        private System.Windows.Forms.Button btLeerArchivo;
        private System.Windows.Forms.RichTextBox rtbResInforec;
    }
}