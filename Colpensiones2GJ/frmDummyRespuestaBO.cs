using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.OleDb;


namespace Colpensiones2GJ
{
    public partial class frmDummyRespuestaBO : Form
    {
        public Reconocimiento objReco;
        public Entidad RespBO;
        public List<GrillaConfirmaciones> lstGridConf { set; get; }
        public int ContIdCTP;


        public partial class GrillaConfirmaciones
        {
            public string NombreCiudadano;
            public List<GrillaDocumentos> lstGridDoc { set; get; }

            public GrillaConfirmaciones()
            {
                lstGridDoc = new List<GrillaDocumentos>();
            }
        }

        public partial class GrillaDocumentos
        {
            public string NombreDoc;
        }
        
        
        
        public frmDummyRespuestaBO()
        {
            InitializeComponent();

            Entidad objEntresBO = new Entidad("P_RespuestaValidacion", "SNombre", " ", "IdP_RespuestaNube");
            this.RespBO = objEntresBO;

            lstGridConf = new List<GrillaConfirmaciones>();
        }
              

        private void btoConInfoRecMR_Click(object sender, EventArgs e)
        {
            this.objReco = new Reconocimiento(txtRadumber.Text, 0, Convert.ToInt32(txtIdCaseMR.Text));
            this.objReco.Get_InfoReconocimientoMR();

            

            this.txtIdCaseMRView.Text = this.objReco.IdCaseMR.ToString();
            this.txtRadNumberMRView.Text = this.objReco.RadNumber;
            this.txtTramite.Text = this.objReco.SubTramite;
            this.txtTramite.Text = objReco.MTramite.P_SubTT.SNombre.ToString();
            this.chkPensionFamiliar.Checked = objReco.MTramite.P_SubTT.BFamiliar;
            this.chkTieneTPC1.Checked = objReco.MTramite.VarProTramite.TieneTPC1;
            this.chkTieneTPC2.Checked = objReco.MTramite.VarProTramite.TieneTPC2;
            this.chkCotColpC1.Checked = objReco.MTramite.VarProTramite.CotizColpC1;
            this.chkCotColpC2.Checked = objReco.MTramite.VarProTramite.CotizColpC2;

        }

        private void btoConsultarInfoTR_Click(object sender, EventArgs e)
        {
            //Consultar Informacion Reconocimiento Proceso Tramite Recococimiento.
            this.objReco = new Reconocimiento(txtRadNumberTR.Text, 0, Convert.ToInt32(txtIdCaseMR.Text),Convert.ToInt32(txtIdCaseTR.Text));
                      
            this.objReco.Get_InfoReconocimientoTR();

            this.txtIdCaseMRView.Text = objReco.IdCaseMR.ToString();
            this.txtIdCaseTRView.Text = objReco.TramiteReco.IdCaseTR.ToString();
            this.txtRadNumberMRView.Text = objReco.RadNumber.ToString();
            this.txtRadNumberTRView.Text = objReco.TramiteReco.RadNumberTR.ToString();
            this.txtTramite.Text = objReco.TramiteReco.MTramite.P_SubTT.SNombre.ToString();
            this.chkPensionFamiliar.Checked = objReco.TramiteReco.MTramite.P_SubTT.BFamiliar;
            this.chkTieneTPC1.Checked = objReco.TramiteReco.MTramite.VarProTramite.TieneTPC1;
            this.chkTieneTPC2.Checked = objReco.TramiteReco.MTramite.VarProTramite.TieneTPC2;
            this.chkCotColpC1.Checked = objReco.TramiteReco.MTramite.VarProTramite.CotizColpC1;
            this.chkCotColpC2.Checked = objReco.TramiteReco.MTramite.VarProTramite.CotizColpC2;

        }

        private void frmDummyRespuestaBO_Load(object sender, EventArgs e)
        {
            this.RespBO.GetListEntidad();

            this.cboRespuestaBO.DataSource = this.RespBO.lstDatosEntidad.Select(x => new { x.IdDatoEntidad, x.Descripcion }).ToList();
            this.cboRespuestaBO.DisplayMember = "Descripcion";
            this.cboRespuestaBO.ValueMember = "IdDatoEntidad";
                  

            //foreach (DatosEntidad tmp in this.RespBO.lstDatosEntidad)
            //{
                //this.cboRespuestaBO.Items.Add(tmp.Descripcion);
                //this.cboRespuestaBO.Items.Insert(tmp.IdDatoEntidad, tmp.Descripcion);
            //}

            //this.cboRespuestaBO.DataSource = this.RespBO.lstDatosEntidad;
            //this.cboRespuestaBO.DisplayMember = "Descripcion";
            //this.cboRespuestaBO.ValueMember = "IdDatoEntidad";

            this.ContIdCTP = 0;

            this.txtRadNumberTR.Text = "2013_7141";
            this.txtIdCaseTR.Text = "77747";
            this.txtIdCaseMR.Text = "77747";
        }

        private void btoAdcCTP_Click(object sender, EventArgs e)
        {
            frmAddGridCTP objFrmAdd = new frmAddGridCTP();
            objFrmAdd.ShowDialog();


            if (objFrmAdd.DialogResult == DialogResult.OK)
            {
                this.ContIdCTP += 1;
                DataGridViewRow row = (DataGridViewRow)dgvConfirmaciones.Rows[0].Clone();
                row.Cells[0].Value = this.ContIdCTP.ToString();
                row.Cells[1].Value = objFrmAdd.txtNombreCiudadano.Text;
                row.Cells[2].Value = objFrmAdd.txtNoDocumento.Text;
                row.Cells[3].Value = objFrmAdd.txtNombreEmpresa.Text;
                row.Cells[4].Value = objFrmAdd.txtNitEmpresa.Text;
                row.Cells[5].Value = objFrmAdd.txtDireccionEmpresa.Text;
                row.Cells[6].Value = objFrmAdd.txtCiudadEmpresa.Text;

                this.dgvConfirmaciones.Rows.Add(row);

                foreach (DataGridViewRow Fila in objFrmAdd.dgvDocumentosCTP.Rows)
                {
                    if (Fila.Cells[0].Value != null)
                    {
                        DataGridViewRow rowd = (DataGridViewRow)dgvDocsCTP.Rows[0].Clone();

                        rowd.Cells[0].Value = this.ContIdCTP;
                        rowd.Cells[1].Value = Fila.Cells[0].Value;
                        rowd.Cells[2].Value = Fila.Cells[1].Value;
                        rowd.Cells[3].Value = Fila.Cells[2].Value;

                        this.dgvDocsCTP.Rows.Add(rowd);
                    }
                }                
            }

        }

        private void btoGenerarRespuesta2_Click(object sender, EventArgs e)
        {
            VarTramiteReco objVarTR = new VarTramiteReco();
            objVarTR.Set_InfoRespuestaBOById(Convert.ToInt16(cboRespuestaBO.SelectedValue));

            objReco.TramiteReco.MTramite.VarProTramiteReco = objVarTR;
            
            string sXML = "";

            sXML += "<BizAgiWSParam>";
	        sXML +=     "<domain>domain</domain>";
	        sXML +=     "<userName>admon</userName>";
	        sXML +=     "<Events>";
		    sXML +=         "<Event>";
			sXML +=             "<EventData>";
		    sXML +=                 "<radNumber>" + objReco.RadNumber + "</radNumber>";
		    sXML +=                 "<eventName>TRC_EsperaInfoTiemposPub</eventName>";
			sXML +=             "</EventData>";
			sXML +=             "<Entities>";
		    sXML +=             "<M_cat_Reconocimiento>";
			sXML +=                 "<M_Tramite>";
		    sXML +=                     "<IdM_VariablesTramiteReco>";
			sXML +=				            "<IdP_EstadoRespBOTmpPub businessKey=\"SCodColpensiones='" + objReco.TramiteReco.MTramite.VarProTramiteReco.IdRespBO.CodColpensiones + "'\"/>";
            
            
            //Coleccion de Entidades....
            if (dgvConfirmaciones.Rows.Count > 1)
            {
                sXML += "<M_RC08_ConfirmTiemposPubs>";
                foreach (DataGridViewRow Fila in dgvConfirmaciones.Rows)
                {
                    if (Fila.Cells["Id"].Value != null)
                    {
                        string idTmp = Fila.Cells["Id"].Value.ToString();
                        sXML += "<M_RC08_ConfirmTiemposPub>";
                        sXML += "<IdM_RC01_ComuniSolCtaPar>";
                        sXML += "<SNombresApellidosTrab>" + Fila.Cells["NombreCiudadano"].Value.ToString() + "</SNombresApellidosTrab>";
                        sXML += "<SDireccion>" + Fila.Cells["DireccionEmpresa"].Value.ToString() + "</SDireccion>";
                        if (Fila.Cells["CiudadEmpresa"].Value.ToString() != null && Fila.Cells["CiudadEmpresa"].Value.ToString() != "")
                            sXML += "<IdP_CiudadDestinatario businessKey=\"SCodigo='" + Fila.Cells["CiudadEmpresa"].Value.ToString() + "'\"/>";
                        sXML += "<SNit>" + Fila.Cells["NitEmpresa"].Value.ToString() + "</SNit>";
                        sXML += "<SNombre>" + Fila.Cells["NombreEmpresa"].Value.ToString() + "</SNombre>";
                        sXML += "<SDocumentoID>" + Fila.Cells["NoDocumento"].Value.ToString() + "</SDocumentoID>";

                        //Coleccion de Documentos
                        int tmpMkColl = 0;

                        if (dgvDocsCTP.Rows.Count > 1)
                        {
                            foreach (DataGridViewRow FilaH in dgvDocsCTP.Rows)
                            {
                                if (FilaH.Cells["IdC"].Value != null)
                                {
                                    if (FilaH.Cells["IdC"].Value.ToString() == idTmp)
                                    {
                                        if (tmpMkColl == 0)
                                        {
                                            tmpMkColl = 1;
                                            sXML += "<M_ECE_DocumentoEnviars>";
                                        }

                                        sXML += "<M_ECE_DocumentoEnviar>";
                                        sXML += "<SNombreDocumento>" + FilaH.Cells["NombreDocumento"].Value.ToString() + "</SNombreDocumento>";
                                        sXML += "<SLinkDoc>" + FilaH.Cells["LinkDocumento"].Value.ToString() + "</SLinkDoc>";
                                        sXML += "<SCodigoDocumento>" + FilaH.Cells["CodigoDocumento"].Value.ToString() + "</SCodigoDocumento>";
                                        sXML += "<SNit>" + Fila.Cells["NitEmpresa"].Value.ToString() + "</SNit>";
                                        sXML +=	"</M_ECE_DocumentoEnviar>";
                                    }
                                }
                            }
                        }

                        if (tmpMkColl == 1)
                            sXML += "</M_ECE_DocumentoEnviars>";

                        sXML += "</IdM_RC01_ComuniSolCtaPar>";
                        sXML += "</M_RC08_ConfirmTiemposPub>";
                    }
                }        
                sXML += "</M_RC08_ConfirmTiemposPubs>";
            }

            //Cierre de XML.....
            sXML += "</IdM_VariablesTramiteReco>";
            sXML += "</M_Tramite>";
            sXML += "</M_cat_Reconocimiento>";
            sXML += "</Entities>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";

            this.rtRespuestaXML.Text = sXML;

        }

        private void btoEjecutar_Click(object sender, EventArgs e)
        {
            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();
            this.rtbRespuestaBA.Text = objCapaSOA.ServicioSetEventByXML(rtRespuestaXML.Text);
            //this.rtbRespuestaBAXML.Text = objCapaSOA.OutXML;
        }

        private void btoGenrarRespMR_Click(object sender, EventArgs e)
        {
            VarTramiteReco objVarTR = new VarTramiteReco();
            objVarTR.Set_InfoRespuestaBOById(Convert.ToInt16(cboRespuestaBO.SelectedValue));

            objReco.MTramite.VarProTramiteReco = objVarTR;

            string sXML = "";

            sXML += "<BizAgiWSParam>";
            sXML += "<domain>domain</domain>";
            sXML += "<userName>admon</userName>";
            sXML += "<Events>";
            sXML += "<Event>";
            sXML += "<EventData>";
            sXML += "<radNumber>" + objReco.RadNumber + "</radNumber>";
            sXML += "<eventName>TRC_EsperaInfoTiemposPub</eventName>";
            sXML += "</EventData>";
            sXML += "<Entities>";
            sXML += "<M_cat_ServicioCiudadano>";
            sXML += "<M_Tramite>";
            sXML += "<IdM_VariablesTramiteReco>";
            sXML += "<IdP_EstadoRespBOTmpPub businessKey=\"SCodColpensiones='" + objReco.MTramite.VarProTramiteReco.IdRespBO.CodColpensiones + "'\"/>";

            if (objReco.MTramite.VarProTramiteReco.IdRespBO.Codigo != "1")
            {
                sXML += "<M_DetallevalidacionNube>";
                sXML += "<M_DetalleValidacionNube>";
                sXML += "<IdP_TipoValidacion businessKey=\"SCodigo='1'\"/>";
                sXML += "<SDetalleValidacion>1- detalle del error presentado el la validacion de BO segunda respuesta TP</SDetalleValidacion>";
                sXML += "</M_DetalleValidacionNube>";
                sXML += "</M_DetallevalidacionNube>";
            }
            else
            {
                //Coleccion de Entidades....
                if (dgvConfirmaciones.Rows.Count > 1)
                {
                    sXML += "<M_RC08_ConfirmTiemposPubs>";
                    foreach (DataGridViewRow Fila in dgvConfirmaciones.Rows)
                    {
                        if (Fila.Cells["Id"].Value != null)
                        {
                            string idTmp = Fila.Cells["Id"].Value.ToString();
                            sXML += "<M_RC08_ConfirmTiemposPub>";
                            sXML += "<IdM_RC01_ComuniSolCtaPar>";
                            sXML += "<SNombresApellidosTrab>" + Fila.Cells["NombreCiudadano"].Value.ToString() + "</SNombresApellidosTrab>";
                            sXML += "<SDireccion>" + Fila.Cells["DireccionEmpresa"].Value.ToString() + "</SDireccion>";
                            if (Fila.Cells["CiudadEmpresa"].Value.ToString() != null && Fila.Cells["CiudadEmpresa"].Value.ToString() != "")
                                sXML += "<IdP_CiudadDestinatario businessKey=\"SCodigo='" + Fila.Cells["CiudadEmpresa"].Value.ToString() + "'\"/>";
                            sXML += "<SNit>" + Fila.Cells["NitEmpresa"].Value.ToString() + "</SNit>";
                            sXML += "<SNombre>" + Fila.Cells["NombreEmpresa"].Value.ToString() + "</SNombre>";
                            sXML += "<SDocumentoID>" + Fila.Cells["NoDocumento"].Value.ToString() + "</SDocumentoID>";

                            //Coleccion de Documentos
                            int tmpMkColl = 0;

                            if (dgvDocsCTP.Rows.Count > 1)
                            {
                                foreach (DataGridViewRow FilaH in dgvDocsCTP.Rows)
                                {
                                    if (FilaH.Cells["IdC"].Value != null)
                                    {
                                        if (FilaH.Cells["IdC"].Value.ToString() == idTmp)
                                        {
                                            if (tmpMkColl == 0)
                                            {
                                                tmpMkColl = 1;
                                                sXML += "<M_ECE_DocumentoEnviars>";
                                            }

                                            sXML += "<M_ECE_DocumentoEnviar>";
                                            sXML += "<SNombreDocumento>" + FilaH.Cells["NombreDocumento"].Value.ToString() + "</SNombreDocumento>";
                                            sXML += "<SLinkDoc>" + FilaH.Cells["LinkDocumento"].Value.ToString() + "</SLinkDoc>";
                                            sXML += "<SCodigoDocumento>" + FilaH.Cells["CodigoDocumento"].Value.ToString() + "</SCodigoDocumento>";
                                            sXML += "<SNit>" + Fila.Cells["NitEmpresa"].Value.ToString() + "</SNit>";
                                            sXML += "</M_ECE_DocumentoEnviar>";
                                        }
                                    }
                                }
                            }

                            if (tmpMkColl == 1)
                                sXML += "</M_ECE_DocumentoEnviars>";

                            sXML += "</IdM_RC01_ComuniSolCtaPar>";
                            sXML += "</M_RC08_ConfirmTiemposPub>";
                        }
                    }
                    sXML += "</M_RC08_ConfirmTiemposPubs>";
                }
            }

            //Cierre de XML.....
            sXML += "</IdM_VariablesTramiteReco>";
            sXML += "</M_Tramite>";
            sXML += "</M_cat_ServicioCiudadano>";
            sXML += "</Entities>";
            sXML += "</Event>";
            sXML += "</Events>";
            sXML += "</BizAgiWSParam>";

            this.rtRespuestaXML.Text = sXML;
        }

       
      

      

      
        

                  
    }
}
