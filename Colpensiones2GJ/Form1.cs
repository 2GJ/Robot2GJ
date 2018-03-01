using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Colpensiones2GJ
{
    public partial class btoPruebaCargaArchivo : Form
    {
        public btoPruebaCargaArchivo()
        {
            InitializeComponent();
        }

        private void btoPruebaServicio_Click(object sender, EventArgs e)
        {
            Form objFrmSaveEntity = new frmSaveEntity();
            objFrmSaveEntity.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form objFrmCaseDataUsgSch = new frmgetCaseDataUsgSch();
            objFrmCaseDataUsgSch.Show();
        }

        private void btResHL_Click(object sender, EventArgs e)
        {
            Form objFrmDumRespHL = new frmRespuestaHL();
            objFrmDumRespHL.Show();
        }

        private void btRespuestaBDM_Click(object sender, EventArgs e)
        {
            Form objFrmDumResBDM = new frmRespuestaBDM();
            objFrmDumResBDM.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form objFrmLiqDummy = new frmLiquidadorDummy();
            objFrmLiqDummy.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form objPruebaCargaArchivo = new frmPruebaCargaArchivoTXT();
            objPruebaCargaArchivo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form objValAsinReco = new frmValidacionAsincReco();
            objValAsinReco.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmConvertirManualesAuto objConvManAuto = new frmConvertirManualesAuto();
            objConvManAuto.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPerformActivity objFormPA = new frmPerformActivity();
            objFormPA.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmValidacionErroresLiq objFormValLiq = new frmValidacionErroresLiq();
            objFormValLiq.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmConvertirRepresaAuto objFormAutoRep = new frmConvertirRepresaAuto();
            objFormAutoRep.Show();
        }

        private void btoDummyBO_Click(object sender, EventArgs e)
        {
            frmDummyRespuestaBO objFormBO = new frmDummyRespuestaBO();
            objFormBO.Show();
        }

        private void btoDummyLiquidador_Click(object sender, EventArgs e)
        {
            frmLiquidadorDummy objFormDLiq = new frmLiquidadorDummy();
            objFormDLiq.Show();
        }

        private void btoGetEntityData_Click(object sender, EventArgs e)
        {
            frmGetEntitydata objFrm = new frmGetEntitydata();
            objFrm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OperacionesReconocimiento frmOpeRec = new OperacionesReconocimiento();
            frmOpeRec.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmDummyNotificacionPersonal frmNotPersonal = new frmDummyNotificacionPersonal();
            frmNotPersonal.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           frmSaveEntity frmSaveEntity = new frmSaveEntity();
            frmSaveEntity.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmSetEvent frmSet = new frmSetEvent();
            frmSet.Show();
        }

        private void btoNotificacionPersonal_Click(object sender, EventArgs e)
        {

        }

        private void btoGetCaseRec_Click(object sender, EventArgs e)
        {
            frmCasoReconocimiento frmCasoRec = new frmCasoReconocimiento();
            frmCasoRec.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmCreateScriptSQL frmCreatorSQL = new frmCreateScriptSQL();
            frmCreatorSQL.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmRadicarML frmRadicarML = new frmRadicarML();
            frmRadicarML.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmAddRolesSkills frmAddRolSkill = new frmAddRolesSkills();
            frmAddRolSkill.Show();
        }

        private void Asincronas_Click(object sender, EventArgs e)
        {
            frmReintentoAsincronas frmAsyn = new frmReintentoAsincronas();
            frmAsyn.Show();
        }

       
    }
}
