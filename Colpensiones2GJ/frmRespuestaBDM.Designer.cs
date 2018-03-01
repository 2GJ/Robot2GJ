namespace Colpensiones2GJ
{
    partial class frmRespuestaBDM
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
            this.btInvocar = new System.Windows.Forms.Button();
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.tbRadNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btInvocar
            // 
            this.btInvocar.Location = new System.Drawing.Point(26, 264);
            this.btInvocar.Name = "btInvocar";
            this.btInvocar.Size = new System.Drawing.Size(75, 23);
            this.btInvocar.TabIndex = 0;
            this.btInvocar.Text = "Invocar";
            this.btInvocar.UseVisualStyleBackColor = true;
            this.btInvocar.Click += new System.EventHandler(this.btInvocar_Click);
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(208, 12);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(517, 291);
            this.rtbRespuesta.TabIndex = 1;
            this.rtbRespuesta.Text = "";
            // 
            // tbRadNumber
            // 
            this.tbRadNumber.Location = new System.Drawing.Point(15, 25);
            this.tbRadNumber.Name = "tbRadNumber";
            this.tbRadNumber.Size = new System.Drawing.Size(100, 20);
            this.tbRadNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ran Number";
            // 
            // frmRespuestaBDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 315);
            this.Controls.Add(this.tbRadNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbRespuesta);
            this.Controls.Add(this.btInvocar);
            this.Name = "frmRespuestaBDM";
            this.Text = "Respuesta BDM (Dummy)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInvocar;
        private System.Windows.Forms.RichTextBox rtbRespuesta;
        private System.Windows.Forms.TextBox tbRadNumber;
        private System.Windows.Forms.Label label1;
    }
}