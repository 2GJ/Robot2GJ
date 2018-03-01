namespace Colpensiones2GJ
{
    partial class frmRobottoCierreNP
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaDatosEntrada = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btoCargarDatos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRutaDatosEntrada);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btoExaminar
            // 
            this.btoExaminar.Location = new System.Drawing.Point(436, 61);
            this.btoExaminar.Name = "btoExaminar";
            this.btoExaminar.Size = new System.Drawing.Size(87, 23);
            this.btoExaminar.TabIndex = 5;
            this.btoExaminar.Text = "Examinar";
            this.btoExaminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Archivo de Entrada";
            // 
            // txtRutaDatosEntrada
            // 
            this.txtRutaDatosEntrada.Location = new System.Drawing.Point(6, 35);
            this.txtRutaDatosEntrada.Name = "txtRutaDatosEntrada";
            this.txtRutaDatosEntrada.Size = new System.Drawing.Size(517, 20);
            this.txtRutaDatosEntrada.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btoCargarDatos);
            this.groupBox2.Location = new System.Drawing.Point(13, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 172);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btoCargarDatos
            // 
            this.btoCargarDatos.Location = new System.Drawing.Point(8, 20);
            this.btoCargarDatos.Name = "btoCargarDatos";
            this.btoCargarDatos.Size = new System.Drawing.Size(75, 23);
            this.btoCargarDatos.TabIndex = 0;
            this.btoCargarDatos.Text = "button1";
            this.btoCargarDatos.UseVisualStyleBackColor = true;
            // 
            // frmRobottoCierreNP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRobottoCierreNP";
            this.Text = "frmRobottoCierreNP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRutaDatosEntrada;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btoCargarDatos;
    }
}