namespace Colpensiones2GJ
{
    partial class frmGetEntitydata
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
            this.btoInvoke = new System.Windows.Forms.Button();
            this.txtInDato = new System.Windows.Forms.TextBox();
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btoInvoke
            // 
            this.btoInvoke.Location = new System.Drawing.Point(12, 38);
            this.btoInvoke.Name = "btoInvoke";
            this.btoInvoke.Size = new System.Drawing.Size(541, 23);
            this.btoInvoke.TabIndex = 0;
            this.btoInvoke.Text = "Invoke";
            this.btoInvoke.UseVisualStyleBackColor = true;
            this.btoInvoke.Click += new System.EventHandler(this.btoInvoke_Click);
            // 
            // txtInDato
            // 
            this.txtInDato.Location = new System.Drawing.Point(12, 12);
            this.txtInDato.Name = "txtInDato";
            this.txtInDato.Size = new System.Drawing.Size(541, 20);
            this.txtInDato.TabIndex = 1;
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(12, 67);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(541, 429);
            this.rtbRespuesta.TabIndex = 2;
            this.rtbRespuesta.Text = "";
            // 
            // frmGetEntitydata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 508);
            this.Controls.Add(this.rtbRespuesta);
            this.Controls.Add(this.txtInDato);
            this.Controls.Add(this.btoInvoke);
            this.Name = "frmGetEntitydata";
            this.Text = "frmGetEntitydata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btoInvoke;
        private System.Windows.Forms.TextBox txtInDato;
        private System.Windows.Forms.RichTextBox rtbRespuesta;
    }
}