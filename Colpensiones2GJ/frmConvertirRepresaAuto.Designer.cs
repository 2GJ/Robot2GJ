namespace Colpensiones2GJ
{
    partial class frmConvertirRepresaAuto
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
            this.tbExaminar = new System.Windows.Forms.TextBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btDetener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RegTotal = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbDetlleBanco = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbTipoLiquidacion = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbInstancia = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtbResutadoFinal = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbExaminar);
            this.groupBox1.Controls.Add(this.btExaminar);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 48);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // tbExaminar
            // 
            this.tbExaminar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbExaminar.Location = new System.Drawing.Point(137, 20);
            this.tbExaminar.Name = "tbExaminar";
            this.tbExaminar.Size = new System.Drawing.Size(576, 20);
            this.tbExaminar.TabIndex = 4;
            // 
            // btExaminar
            // 
            this.btExaminar.Location = new System.Drawing.Point(19, 17);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(112, 23);
            this.btExaminar.TabIndex = 3;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btDetener);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.RegTotal);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 89);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // btDetener
            // 
            this.btDetener.Location = new System.Drawing.Point(267, 19);
            this.btDetener.Name = "btDetener";
            this.btDetener.Size = new System.Drawing.Size(119, 54);
            this.btDetener.TabIndex = 36;
            this.btDetener.Text = "Detener";
            this.btDetener.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Procesar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegTotal
            // 
            this.RegTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.RegTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTotal.Location = new System.Drawing.Point(6, 47);
            this.RegTotal.Name = "RegTotal";
            this.RegTotal.Size = new System.Drawing.Size(125, 25);
            this.RegTotal.TabIndex = 33;
            this.RegTotal.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Leer Archivo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.rtbInstancia);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.rtbTipoLiquidacion);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rtbDetlleBanco);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(416, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 394);
            this.panel2.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "1 - RadNumber";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "0 - IdCase";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Columnas";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 164);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Location = new System.Drawing.Point(12, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(728, 61);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(694, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2 - Banco";
            // 
            // rtbDetlleBanco
            // 
            this.rtbDetlleBanco.BackColor = System.Drawing.Color.Gray;
            this.rtbDetlleBanco.Location = new System.Drawing.Point(47, 78);
            this.rtbDetlleBanco.Name = "rtbDetlleBanco";
            this.rtbDetlleBanco.Size = new System.Drawing.Size(262, 61);
            this.rtbDetlleBanco.TabIndex = 4;
            this.rtbDetlleBanco.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "3 - Tipo Liquidacion";
            // 
            // rtbTipoLiquidacion
            // 
            this.rtbTipoLiquidacion.BackColor = System.Drawing.Color.Gray;
            this.rtbTipoLiquidacion.Location = new System.Drawing.Point(47, 158);
            this.rtbTipoLiquidacion.Name = "rtbTipoLiquidacion";
            this.rtbTipoLiquidacion.Size = new System.Drawing.Size(262, 50);
            this.rtbTipoLiquidacion.TabIndex = 6;
            this.rtbTipoLiquidacion.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "4 - Instancia";
            // 
            // rtbInstancia
            // 
            this.rtbInstancia.BackColor = System.Drawing.Color.Gray;
            this.rtbInstancia.Location = new System.Drawing.Point(47, 231);
            this.rtbInstancia.Name = "rtbInstancia";
            this.rtbInstancia.Size = new System.Drawing.Size(262, 109);
            this.rtbInstancia.TabIndex = 8;
            this.rtbInstancia.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtbResutadoFinal);
            this.groupBox5.Location = new System.Drawing.Point(12, 215);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(398, 133);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            // 
            // rtbResutadoFinal
            // 
            this.rtbResutadoFinal.Location = new System.Drawing.Point(6, 17);
            this.rtbResutadoFinal.Name = "rtbResutadoFinal";
            this.rtbResutadoFinal.Size = new System.Drawing.Size(386, 110);
            this.rtbResutadoFinal.TabIndex = 0;
            this.rtbResutadoFinal.Text = "";
            // 
            // frmConvertirRepresaAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 527);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConvertirRepresaAuto";
            this.Load += new System.EventHandler(this.frmConvertirRepresaAuto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbExaminar;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label RegTotal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btDetener;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox rtbDetlleBanco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbTipoLiquidacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbInstancia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtbResutadoFinal;
    }
}