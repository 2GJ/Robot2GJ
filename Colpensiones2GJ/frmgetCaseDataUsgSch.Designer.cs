namespace Colpensiones2GJ
{
    partial class frmgetCaseDataUsgSch
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbIdCase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIdWorkItem = new System.Windows.Forms.TextBox();
            this.tbXSD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Invocar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbIdCase
            // 
            this.tbIdCase.Location = new System.Drawing.Point(16, 36);
            this.tbIdCase.Name = "tbIdCase";
            this.tbIdCase.Size = new System.Drawing.Size(168, 20);
            this.tbIdCase.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "idCase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "idWorkItem";
            // 
            // tbIdWorkItem
            // 
            this.tbIdWorkItem.Location = new System.Drawing.Point(191, 35);
            this.tbIdWorkItem.Name = "tbIdWorkItem";
            this.tbIdWorkItem.Size = new System.Drawing.Size(100, 20);
            this.tbIdWorkItem.TabIndex = 4;
            // 
            // tbXSD
            // 
            this.tbXSD.Location = new System.Drawing.Point(298, 35);
            this.tbXSD.Name = "tbXSD";
            this.tbXSD.Size = new System.Drawing.Size(593, 20);
            this.tbXSD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "XSD";
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(13, 92);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(878, 248);
            this.rtbRespuesta.TabIndex = 7;
            this.rtbRespuesta.Text = "";
            // 
            // frmgetCaseDataUsgSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 352);
            this.Controls.Add(this.rtbRespuesta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbXSD);
            this.Controls.Add(this.tbIdWorkItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIdCase);
            this.Controls.Add(this.button1);
            this.Name = "frmgetCaseDataUsgSch";
            this.Text = "frmgetCaseDataUsgSch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbIdCase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIdWorkItem;
        private System.Windows.Forms.TextBox tbXSD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbRespuesta;
    }
}