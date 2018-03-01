namespace Colpensiones2GJ
{
    partial class frmDummyNotificacionPersonal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btoCargaDtosCallCenter = new System.Windows.Forms.Button();
            this.dgCallCenter = new System.Windows.Forms.DataGridView();
            this.lblIdCase = new System.Windows.Forms.Label();
            this.txtIdCase = new System.Windows.Forms.TextBox();
            this.txtNoRad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoRadTramite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoIdentificacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrimerNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btoGenerarResp = new System.Windows.Forms.Button();
            this.rtXMLRespuestaBA = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.CS1 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtConC1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObsC1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtConC2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtObsC2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtConC3 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtObsC3 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.rtXMLGenerado = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNomEvento = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.CN1 = new System.Windows.Forms.RadioButton();
            this.CN2 = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.CS2 = new System.Windows.Forms.RadioButton();
            this.CN3 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.CS3 = new System.Windows.Forms.RadioButton();
            this.IdCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRadicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoRadicadoTramite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCallCenter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btoCargaDtosCallCenter
            // 
            this.btoCargaDtosCallCenter.Location = new System.Drawing.Point(12, 12);
            this.btoCargaDtosCallCenter.Name = "btoCargaDtosCallCenter";
            this.btoCargaDtosCallCenter.Size = new System.Drawing.Size(154, 23);
            this.btoCargaDtosCallCenter.TabIndex = 0;
            this.btoCargaDtosCallCenter.Text = "Carga Datos Call Center";
            this.btoCargaDtosCallCenter.UseVisualStyleBackColor = true;
            this.btoCargaDtosCallCenter.Click += new System.EventHandler(this.btoCargaDtosCallCenter_Click);
            // 
            // dgCallCenter
            // 
            this.dgCallCenter.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCallCenter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgCallCenter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCallCenter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCase,
            this.NoRadicado,
            this.NoRadicadoTramite,
            this.NumIdentificacion,
            this.TipoIdentificacion,
            this.PrimerNombre,
            this.PrimerApellido,
            this.Ciudad,
            this.Telefono,
            this.Celular,
            this.Estado,
            this.Evento});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCallCenter.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgCallCenter.Location = new System.Drawing.Point(12, 41);
            this.dgCallCenter.Name = "dgCallCenter";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCallCenter.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgCallCenter.Size = new System.Drawing.Size(1295, 221);
            this.dgCallCenter.TabIndex = 5;
            this.dgCallCenter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCallCenter_CellContentClick);
            this.dgCallCenter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCallCenter_CellContentClick);
            // 
            // lblIdCase
            // 
            this.lblIdCase.AutoSize = true;
            this.lblIdCase.Location = new System.Drawing.Point(90, 326);
            this.lblIdCase.Name = "lblIdCase";
            this.lblIdCase.Size = new System.Drawing.Size(40, 13);
            this.lblIdCase.TabIndex = 6;
            this.lblIdCase.Text = "IdCase";
            // 
            // txtIdCase
            // 
            this.txtIdCase.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtIdCase.Enabled = false;
            this.txtIdCase.Location = new System.Drawing.Point(136, 326);
            this.txtIdCase.Name = "txtIdCase";
            this.txtIdCase.Size = new System.Drawing.Size(100, 20);
            this.txtIdCase.TabIndex = 7;
            // 
            // txtNoRad
            // 
            this.txtNoRad.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNoRad.Enabled = false;
            this.txtNoRad.Location = new System.Drawing.Point(136, 349);
            this.txtNoRad.Name = "txtNoRad";
            this.txtNoRad.Size = new System.Drawing.Size(100, 20);
            this.txtNoRad.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "NoRadicacion";
            // 
            // txtNoRadTramite
            // 
            this.txtNoRadTramite.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNoRadTramite.Enabled = false;
            this.txtNoRadTramite.Location = new System.Drawing.Point(136, 375);
            this.txtNoRadTramite.Name = "txtNoRadTramite";
            this.txtNoRadTramite.Size = new System.Drawing.Size(100, 20);
            this.txtNoRadTramite.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "NoRadicacionTramite";
            // 
            // txtNoIdentificacion
            // 
            this.txtNoIdentificacion.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNoIdentificacion.Enabled = false;
            this.txtNoIdentificacion.Location = new System.Drawing.Point(136, 401);
            this.txtNoIdentificacion.Name = "txtNoIdentificacion";
            this.txtNoIdentificacion.Size = new System.Drawing.Size(100, 20);
            this.txtNoIdentificacion.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "No Identificacion";
            // 
            // txtTipoIdentificacion
            // 
            this.txtTipoIdentificacion.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtTipoIdentificacion.Enabled = false;
            this.txtTipoIdentificacion.Location = new System.Drawing.Point(136, 427);
            this.txtTipoIdentificacion.Name = "txtTipoIdentificacion";
            this.txtTipoIdentificacion.Size = new System.Drawing.Size(100, 20);
            this.txtTipoIdentificacion.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo Identificacion";
            // 
            // txtPrimerNombre
            // 
            this.txtPrimerNombre.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtPrimerNombre.Enabled = false;
            this.txtPrimerNombre.Location = new System.Drawing.Point(136, 453);
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Size = new System.Drawing.Size(186, 20);
            this.txtPrimerNombre.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Primer Nombre";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtPrimerApellido.Enabled = false;
            this.txtPrimerApellido.Location = new System.Drawing.Point(136, 479);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(186, 20);
            this.txtPrimerApellido.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 482);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Primer Apellido";
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCiudad.Enabled = false;
            this.txtCiudad.Location = new System.Drawing.Point(136, 505);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ciudad";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(136, 531);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 534);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Telefono";
            // 
            // txtCelular
            // 
            this.txtCelular.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCelular.Enabled = false;
            this.txtCelular.Location = new System.Drawing.Point(136, 557);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(100, 20);
            this.txtCelular.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 560);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Celular";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(136, 583);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(90, 586);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Estado";
            // 
            // btoGenerarResp
            // 
            this.btoGenerarResp.Location = new System.Drawing.Point(667, 268);
            this.btoGenerarResp.Name = "btoGenerarResp";
            this.btoGenerarResp.Size = new System.Drawing.Size(640, 23);
            this.btoGenerarResp.TabIndex = 30;
            this.btoGenerarResp.Text = "Generar Respuesta";
            this.btoGenerarResp.UseVisualStyleBackColor = true;
            this.btoGenerarResp.Click += new System.EventHandler(this.btoGenerarResp_Click);
            // 
            // rtXMLRespuestaBA
            // 
            this.rtXMLRespuestaBA.Location = new System.Drawing.Point(667, 472);
            this.rtXMLRespuestaBA.Name = "rtXMLRespuestaBA";
            this.rtXMLRespuestaBA.Size = new System.Drawing.Size(640, 139);
            this.rtXMLRespuestaBA.TabIndex = 31;
            this.rtXMLRespuestaBA.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CN1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.CS1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtConC1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtObsC1);
            this.groupBox1.Location = new System.Drawing.Point(345, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 103);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contacto Uno";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 13);
            this.label22.TabIndex = 46;
            this.label22.Text = "Contactado C1";
            // 
            // CS1
            // 
            this.CS1.AutoSize = true;
            this.CS1.Location = new System.Drawing.Point(119, 19);
            this.CS1.Name = "CS1";
            this.CS1.Size = new System.Drawing.Size(34, 17);
            this.CS1.TabIndex = 45;
            this.CS1.TabStop = true;
            this.CS1.Text = "Si";
            this.CS1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Nombre Contacto 1";
            // 
            // txtConC1
            // 
            this.txtConC1.Location = new System.Drawing.Point(119, 73);
            this.txtConC1.Name = "txtConC1";
            this.txtConC1.Size = new System.Drawing.Size(191, 20);
            this.txtConC1.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Observaciones C1";
            // 
            // txtObsC1
            // 
            this.txtObsC1.Location = new System.Drawing.Point(119, 47);
            this.txtObsC1.Name = "txtObsC1";
            this.txtObsC1.Size = new System.Drawing.Size(191, 20);
            this.txtObsC1.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CN2);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.CS2);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtConC2);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtObsC2);
            this.groupBox2.Location = new System.Drawing.Point(345, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 106);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contacto Dos";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Nombre Contacto 2";
            // 
            // txtConC2
            // 
            this.txtConC2.Location = new System.Drawing.Point(119, 73);
            this.txtConC2.Name = "txtConC2";
            this.txtConC2.Size = new System.Drawing.Size(191, 20);
            this.txtConC2.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Observaciones C2";
            // 
            // txtObsC2
            // 
            this.txtObsC2.Location = new System.Drawing.Point(119, 47);
            this.txtObsC2.Name = "txtObsC2";
            this.txtObsC2.Size = new System.Drawing.Size(191, 20);
            this.txtObsC2.TabIndex = 39;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CN3);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.CS3);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtConC3);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtObsC3);
            this.groupBox3.Location = new System.Drawing.Point(345, 489);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 109);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contacto Tres";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Nombre Contacto 3";
            // 
            // txtConC3
            // 
            this.txtConC3.Location = new System.Drawing.Point(119, 73);
            this.txtConC3.Name = "txtConC3";
            this.txtConC3.Size = new System.Drawing.Size(191, 20);
            this.txtConC3.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Observaciones C1";
            // 
            // txtObsC3
            // 
            this.txtObsC3.Location = new System.Drawing.Point(119, 47);
            this.txtObsC3.Name = "txtObsC3";
            this.txtObsC3.Size = new System.Drawing.Size(191, 20);
            this.txtObsC3.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 268);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(308, 29);
            this.label20.TabIndex = 47;
            this.label20.Text = "INFORMACION DEL CASO";
            // 
            // rtXMLGenerado
            // 
            this.rtXMLGenerado.Location = new System.Drawing.Point(667, 294);
            this.rtXMLGenerado.Name = "rtXMLGenerado";
            this.rtXMLGenerado.Size = new System.Drawing.Size(640, 146);
            this.rtXMLGenerado.TabIndex = 49;
            this.rtXMLGenerado.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(667, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(640, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Enviar Respuesta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNomEvento
            // 
            this.txtNomEvento.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNomEvento.Enabled = false;
            this.txtNomEvento.Location = new System.Drawing.Point(136, 300);
            this.txtNomEvento.Name = "txtNomEvento";
            this.txtNomEvento.Size = new System.Drawing.Size(100, 20);
            this.txtNomEvento.TabIndex = 51;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(49, 303);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(81, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Nombre Evento";
            // 
            // CN1
            // 
            this.CN1.AutoSize = true;
            this.CN1.Location = new System.Drawing.Point(159, 19);
            this.CN1.Name = "CN1";
            this.CN1.Size = new System.Drawing.Size(39, 17);
            this.CN1.TabIndex = 47;
            this.CN1.TabStop = true;
            this.CN1.Text = "No";
            this.CN1.UseVisualStyleBackColor = true;
            // 
            // CN2
            // 
            this.CN2.AutoSize = true;
            this.CN2.Location = new System.Drawing.Point(159, 21);
            this.CN2.Name = "CN2";
            this.CN2.Size = new System.Drawing.Size(39, 17);
            this.CN2.TabIndex = 50;
            this.CN2.TabStop = true;
            this.CN2.Text = "No";
            this.CN2.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 49;
            this.label23.Text = "Contactado C2";
            // 
            // CS2
            // 
            this.CS2.AutoSize = true;
            this.CS2.Location = new System.Drawing.Point(119, 21);
            this.CS2.Name = "CS2";
            this.CS2.Size = new System.Drawing.Size(34, 17);
            this.CS2.TabIndex = 48;
            this.CS2.TabStop = true;
            this.CS2.Text = "Si";
            this.CS2.UseVisualStyleBackColor = true;
            // 
            // CN3
            // 
            this.CN3.AutoSize = true;
            this.CN3.Location = new System.Drawing.Point(159, 15);
            this.CN3.Name = "CN3";
            this.CN3.Size = new System.Drawing.Size(39, 17);
            this.CN3.TabIndex = 53;
            this.CN3.TabStop = true;
            this.CN3.Text = "No";
            this.CN3.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 13);
            this.label24.TabIndex = 52;
            this.label24.Text = "Contactado C3";
            // 
            // CS3
            // 
            this.CS3.AutoSize = true;
            this.CS3.Location = new System.Drawing.Point(119, 15);
            this.CS3.Name = "CS3";
            this.CS3.Size = new System.Drawing.Size(34, 17);
            this.CS3.TabIndex = 51;
            this.CS3.TabStop = true;
            this.CS3.Text = "Si";
            this.CS3.UseVisualStyleBackColor = true;
            // 
            // IdCase
            // 
            this.IdCase.HeaderText = "IdCase";
            this.IdCase.Name = "IdCase";
            this.IdCase.ReadOnly = true;
            // 
            // NoRadicado
            // 
            this.NoRadicado.HeaderText = "NoRadicado";
            this.NoRadicado.Name = "NoRadicado";
            this.NoRadicado.ReadOnly = true;
            // 
            // NoRadicadoTramite
            // 
            this.NoRadicadoTramite.HeaderText = "NoRadicadoTramite";
            this.NoRadicadoTramite.Name = "NoRadicadoTramite";
            this.NoRadicadoTramite.ReadOnly = true;
            // 
            // NumIdentificacion
            // 
            this.NumIdentificacion.HeaderText = "NumIdentificacion";
            this.NumIdentificacion.Name = "NumIdentificacion";
            this.NumIdentificacion.ReadOnly = true;
            // 
            // TipoIdentificacion
            // 
            this.TipoIdentificacion.HeaderText = "TipoIdentificacion";
            this.TipoIdentificacion.Name = "TipoIdentificacion";
            this.TipoIdentificacion.ReadOnly = true;
            // 
            // PrimerNombre
            // 
            this.PrimerNombre.HeaderText = "PrimerNombre";
            this.PrimerNombre.Name = "PrimerNombre";
            this.PrimerNombre.ReadOnly = true;
            // 
            // PrimerApellido
            // 
            this.PrimerApellido.HeaderText = "PrimerApellido";
            this.PrimerApellido.Name = "PrimerApellido";
            this.PrimerApellido.ReadOnly = true;
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // Celular
            // 
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Evento
            // 
            this.Evento.HeaderText = "Evento";
            this.Evento.Name = "Evento";
            this.Evento.ReadOnly = true;
            // 
            // frmDummyNotificacionPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 619);
            this.Controls.Add(this.txtNomEvento);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.rtXMLGenerado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtXMLRespuestaBA);
            this.Controls.Add(this.btoGenerarResp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrimerNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTipoIdentificacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNoIdentificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoRadTramite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoRad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdCase);
            this.Controls.Add(this.lblIdCase);
            this.Controls.Add(this.dgCallCenter);
            this.Controls.Add(this.btoCargaDtosCallCenter);
            this.Name = "frmDummyNotificacionPersonal";
            this.Text = "Notificacion Personal";
            ((System.ComponentModel.ISupportInitialize)(this.dgCallCenter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btoCargaDtosCallCenter;
        private System.Windows.Forms.DataGridView dgCallCenter;
        private System.Windows.Forms.Label lblIdCase;
        private System.Windows.Forms.TextBox txtIdCase;
        private System.Windows.Forms.TextBox txtNoRad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoRadTramite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoIdentificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrimerNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btoGenerarResp;
        private System.Windows.Forms.RichTextBox rtXMLRespuestaBA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtConC1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObsC1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtConC2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtObsC2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtConC3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtObsC3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RichTextBox rtXMLGenerado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNomEvento;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton CS1;
        private System.Windows.Forms.RadioButton CN1;
        private System.Windows.Forms.RadioButton CN2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton CS2;
        private System.Windows.Forms.RadioButton CN3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton CS3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRadicado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoRadicadoTramite;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;

    }
}