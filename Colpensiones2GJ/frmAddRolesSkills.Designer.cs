namespace Colpensiones2GJ
{
    partial class frmAddRolesSkills
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
            this.rbAddSkills = new System.Windows.Forms.RadioButton();
            this.rtbRespuesta = new System.Windows.Forms.RichTextBox();
            this.rbAddRoles = new System.Windows.Forms.RadioButton();
            this.btoExaminar = new System.Windows.Forms.Button();
            this.txtTotalReg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEjecutados = new System.Windows.Forms.TextBox();
            this.btoInvocar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbAddSkills
            // 
            this.rbAddSkills.AutoSize = true;
            this.rbAddSkills.Location = new System.Drawing.Point(134, 18);
            this.rbAddSkills.Name = "rbAddSkills";
            this.rbAddSkills.Size = new System.Drawing.Size(71, 17);
            this.rbAddSkills.TabIndex = 13;
            this.rbAddSkills.TabStop = true;
            this.rbAddSkills.Text = "Add Skills";
            this.rbAddSkills.UseVisualStyleBackColor = true;
            // 
            // rtbRespuesta
            // 
            this.rtbRespuesta.Location = new System.Drawing.Point(9, 19);
            this.rtbRespuesta.Name = "rtbRespuesta";
            this.rtbRespuesta.Size = new System.Drawing.Size(562, 234);
            this.rtbRespuesta.TabIndex = 2;
            this.rtbRespuesta.Text = "";
            // 
            // rbAddRoles
            // 
            this.rbAddRoles.AutoSize = true;
            this.rbAddRoles.Location = new System.Drawing.Point(9, 18);
            this.rbAddRoles.Name = "rbAddRoles";
            this.rbAddRoles.Size = new System.Drawing.Size(74, 17);
            this.rbAddRoles.TabIndex = 12;
            this.rbAddRoles.TabStop = true;
            this.rbAddRoles.Text = "Add Roles";
            this.rbAddRoles.UseVisualStyleBackColor = true;
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
            // txtTotalReg
            // 
            this.txtTotalReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReg.Location = new System.Drawing.Point(6, 91);
            this.txtTotalReg.Name = "txtTotalReg";
            this.txtTotalReg.Size = new System.Drawing.Size(131, 38);
            this.txtTotalReg.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.rtbRespuesta);
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 269);
            this.groupBox2.TabIndex = 8;
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
            this.panel1.Size = new System.Drawing.Size(200, 234);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Col 2 -> IdRole o IdSkill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Col 1 -> UserName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Col 0 -> IdUser";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(9, 19);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(768, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btoExaminar);
            this.groupBox1.Controls.Add(this.txtRutaArchivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAddSkills);
            this.groupBox3.Controls.Add(this.rbAddRoles);
            this.groupBox3.Controls.Add(this.txtEjecutados);
            this.groupBox3.Controls.Add(this.txtTotalReg);
            this.groupBox3.Controls.Add(this.btoInvocar);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 140);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // txtEjecutados
            // 
            this.txtEjecutados.BackColor = System.Drawing.Color.Red;
            this.txtEjecutados.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjecutados.Location = new System.Drawing.Point(134, 91);
            this.txtEjecutados.Name = "txtEjecutados";
            this.txtEjecutados.Size = new System.Drawing.Size(131, 38);
            this.txtEjecutados.TabIndex = 8;
            // 
            // btoInvocar
            // 
            this.btoInvocar.Location = new System.Drawing.Point(6, 41);
            this.btoInvocar.Name = "btoInvocar";
            this.btoInvocar.Size = new System.Drawing.Size(256, 38);
            this.btoInvocar.TabIndex = 6;
            this.btoInvocar.Text = "Invocar";
            this.btoInvocar.UseVisualStyleBackColor = true;
            this.btoInvocar.Click += new System.EventHandler(this.btoInvocar_Click);
            // 
            // frmAddRolesSkills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmAddRolesSkills";
            this.Text = "Agregar Roles o Skills a Usuarios";
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAddSkills;
        private System.Windows.Forms.RichTextBox rtbRespuesta;
        private System.Windows.Forms.RadioButton rbAddRoles;
        private System.Windows.Forms.Button btoExaminar;
        private System.Windows.Forms.TextBox txtTotalReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtEjecutados;
        private System.Windows.Forms.Button btoInvocar;
    }
}