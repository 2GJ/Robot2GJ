using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Colpensiones2GJ
{
    public partial class frmCreateScriptSQL : Form
    {
        public frmCreateScriptSQL()
        {
            InitializeComponent();
        }

        private void frmCreateScriptSQL_Load(object sender, EventArgs e)
        {

        }

        private void btoInvocar_Click(object sender, EventArgs e)
        {
            int Contador = 0;
            bool Reintentar = false;

            try
            {
                //Abrir el archivo de captura.
                if (this.txtRutaArchivo.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.txtRutaArchivo.Text);

                Int64 y = File.ReadAllLines(this.txtRutaArchivo.Text).Length;
                this.txtTotalReg.Text = y.ToString();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    Reintentar = false;

                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    //for (int i = 0; i < strLineArzay.Length; i++)
                    //{
                    //    this.rtbRespuesta.Text += strLineArzay[i] + "\t";
                    //}


                    string ResReplace = this.ReplaceArchivoSQL(strLineArzay);
                    
                    //string strSaveEntity = "";

                    //strSaveEntity += "<BizAgiWSParam>";
                    //strSaveEntity += "<Entities idCase=\"" + strLineArzay[0] + "\">";
                    //strSaveEntity += strLineArzay[2];
                    //strSaveEntity += "</Entities>";
                    //strSaveEntity += "</BizAgiWSParam>";

                    //Llamado de save entity
                    //CapaSOABizAgi objCapaSOABizAgi = new CapaSOABizAgi();
                    //string ResSaveEntity = objCapaSOABizAgi.ServicioSaveEntity(strSaveEntity);

                    this.rtbRespuesta.Text += ResReplace;
                    this.rtbRespuesta.Text += "\n";

                    Contador += 1;
                    this.txtEjecutados.Text = Convert.ToString(Contador);

                    this.Refresh();
                }

                
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public string ReplaceArchivoSQL(string[] In_Datos)
        {
            string ResSQL = this.TextTemporal();

            //ResSQL = ResSQL.Replace("VAR2GJ[UserName]", "'" + In_Datos[0] + "'");
            ResSQL = ResSQL.Replace("@UserName", "'" + In_Datos[0] + "'");
            ResSQL = ResSQL.Replace("@fullName", "'" + In_Datos[1] + "'");
            ResSQL = ResSQL.Replace("@domain", "'" + In_Datos[2] + "'");
            ResSQL = ResSQL.Replace("@idOficina", In_Datos[3]);
            ResSQL = ResSQL.Replace("@idP_GerenciasColpensiones", In_Datos[4]);
            ResSQL = ResSQL.Replace("@idTipoDocumento", In_Datos[5]);
            ResSQL = ResSQL.Replace("@sNumeroDocumento", "'" + In_Datos[6] + "'");
            ResSQL = ResSQL.Replace("@idVicepresidencia", In_Datos[7]);
            ResSQL = ResSQL.Replace("@BActivarAsignacionTurnos", In_Datos[8]);
            ResSQL = ResSQL.Replace("@idCoordinacionesColpension", In_Datos[9]);
            ResSQL = ResSQL.Replace("@IdRole", In_Datos[10]);
           
            return ResSQL; 

        }

        public string TextTemporal()
        {
            string R = "";

            R += "PRINT '1-INICIO'; \n";
            R += "IF NOT EXISTS (SELECT * FROM WFUSER WHERE username = @UserName) \n";
            R += "BEGIN \n";
            R += "PRINT 'NO EXISTE'; \n";
            R += "INSERT INTO WFUSER([fullName],[userName],[domain],[notifByEmail],[DelegateEnabled],[idOficina],[idP_GerenciasColpensiones],[idTipoDocumento],[sNumeroDocumento],[HabilitadoRecibirCorresp],[idVicepresidencia],[BActivarAsignacionTurnos],[idCoordinacionesColpension],[enabled]) \n";
            R += "VALUES(@fullName,@UserName,@domain,0,0,@idOficina,@idP_GerenciasColpensiones,@idTipoDocumento,@sNumeroDocumento,0,@idVicepresidencia,0,@idCoordinacionesColpension,1) \n";
            R += "PRINT 'CREADO EN WFUSER'; \n";
            R += "INSERT INTO USERAUTH \n";
            R += "SELECT  WFU.iduser, \n";
            R += "WFU.sNumeroDocumento as password, \n";
            R += "WFU.sNumeroDocumento as secretQuestion, \n";
            R += "WFU.sNumeroDocumento as secretAnswer, \n";
            R += "0 as locked, \n";
            R += "0 as expired, \n";
            R += "getdate() as lastLogonDate, \n";
            R += "getdate() as lastChangePasswordDate, \n";
            R += "0 as failedLoginAttempts \n";
            R += "FROM  WFUSER WFU \n";
            R += "WHERE  WFU.username = @UserName \n";
            R += "PRINT 'CREADO EN USERAUTH'; \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'EXISTE'; \n";
            R += "UPDATE USERAUTH \n";
            R += "SET	password = WFU.sNumeroDocumento, \n";
            R += "secretQuestion = WFU.sNumeroDocumento, \n";
            R += "secretAnswer = WFU.sNumeroDocumento, \n";
            R += "locked = 0, \n";
            R += "expired = 0, \n";
            R += "lastLogonDate = getdate(), \n";
            R += "lastChangePasswordDate = getdate(), \n";
            R += "failedLoginAttempts = 0 \n";
            R += "FROM  WFUSER WFU \n";
            R += "INNER JOIN USERAUTH UA ON WFU.iduser = UA.iduser AND  WFU.username = @UserName \n";
            R += "WHERE UA.IDUSER = WFU.iduser \n";
            R += "PRINT 'ACTUALIZADO USERAUTH' \n";
            R += "END \n";
            R += "IF NOT EXISTS (SELECT * FROM USERORG ORG \n";
            R += "INNER JOIN WFUSER WFU ON ORG.IDUSER = WFU.IDUSER \n";
            R += "WHERE WFU.username = @UserName AND ORG.IDORG = 1) \n";
            R += "BEGIN \n";
            R += "PRINT 'SIN ORGANIZACION' \n";
            R += "INSERT INTO USERORG \n";
            R += "SELECT 1 AS IdOrg, WFU.iduser \n";
            R += "FROM WFUSER WFU \n";
            R += "WHERE WFU.username = @UserName \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'YA EXISTE ORGANIZACION' \n";
            R += "END \n";
            R += "IF NOT EXISTS (SELECT * FROM USERROLE UR \n";
            R += "INNER JOIN WFUSER WFU ON UR.IDUSER = WFU.IDUSER \n";
            R += "WHERE WFU.username = @UserName AND UR.IDROLE = @IdRole) \n";
            R += "BEGIN \n";
            R += "PRINT 'SIN ROLE' \n";
            R += "INSERT INTO USERROLE (idrole,iduser) \n";
            R += "SELECT @IdRole AS idRole, WFU.iduser AS iduser \n";
            R += "FROM WFUSER WFU \n";
            R += "WHERE WFU.username = @UserName \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'YA EXISTE ROLE' \n";
            R += "END \n";
            R += "GO \n";

            /*
            R += "PRINT '1-INICIO'; \n";
            R += "IF NOT EXISTS (SELECT * FROM WFUSER WHERE username = VAR2GJ[UserName] ) \n";
            R += "BEGIN \n";
            R += "PRINT 'NO EXISTE'; \n";
            R += "INSERT INTO WFUSER([fullName],[userName],[domain],[notifByEmail],[DelegateEnabled],[idOficina],[idP_GerenciasColpensiones],[idTipoDocumento],[sNumeroDocumento],[HabilitadoRecibirCorresp],[idVicepresidencia],[BActivarAsignacionTurnos],[idCoordinacionesColpension],[enabled]) \n";
            R += "VALUES(@fullName,VAR2GJ[UserName],@domain,0,0,@idOficina,@idP_GerenciasColpensiones,@idTipoDocumento,@sNumeroDocumento,0,@idVicepresidencia,0,@idCoordinacionesColpension,1) \n";
            R += "PRINT 'CREADO EN WFUSER'; \n";
            R += "INSERT INTO USERAUTH \n";
            R += "SELECT  WFU.iduser, \n";
            R += "WFU.sNumeroDocumento as password, \n";
            R += "WFU.sNumeroDocumento as secretQuestion, \n";
            R += "WFU.sNumeroDocumento as secretAnswer, \n";
            R += "0 as locked, \n";
            R += "0 as expired, \n";
            R += "getdate() as lastLogonDate, \n";
            R += "getdate() as lastChangePasswordDate, \n";
            R += "0 as failedLoginAttempts \n";
            R += "FROM  WFUSER WFU \n";
            R += "WHERE  WFU.username = VAR2GJ[UserName] \n";
            R += "PRINT 'CREADO EN USERAUTH'; \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'EXISTE'; \n";
            R += "UPDATE USERAUTH \n";
            R += "SET	password = WFU.sNumeroDocumento, \n";
            R += "secretQuestion = WFU.sNumeroDocumento, \n";
            R += "secretAnswer = WFU.sNumeroDocumento, \n";
            R += "locked = 0, \n";
            R += "expired = 0, \n";
            R += "lastLogonDate = getdate(), \n";
            R += "lastChangePasswordDate = getdate(), \n";
            R += "failedLoginAttempts = 0 \n";
            R += "FROM  WFUSER WFU \n";
            R += "INNER JOIN USERAUTH UA ON WFU.iduser = UA.iduser AND  WFU.username = VAR2GJ[UserName] \n";
            R += "WHERE UA.IDUSER = WFU.iduser \n";
            R += "PRINT 'ACTUALIZADO USERAUTH' \n";
            R += "END \n";
            R += "IF NOT EXISTS (SELECT * FROM USERORG ORG \n";
            R += "INNER JOIN WFUSER WFU ON ORG.IDUSER = WFU.IDUSER \n";
            R += "WHERE WFU.username = VAR2GJ[UserName] AND ORG.IDORG = 1) \n";
            R += "BEGIN \n";
            R += "PRINT 'SIN ORGANIZACION' \n";
            R += "INSERT INTO USERORG \n";
            R += "SELECT 1 AS IdOrg, WFU.iduser \n";
            R += "FROM WFUSER WFU \n";
            R += "WHERE WFU.username = VAR2GJ[UserName] \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'YA EXISTE ORGANIZACION' \n";
            R += "END \n";
            R += "IF NOT EXISTS (SELECT * FROM USERROLE UR \n";
            R += "INNER JOIN WFUSER WFU ON UR.IDUSER = WFU.IDUSER \n";
            R += "WHERE WFU.username = VAR2GJ[UserName] AND UR.IDROLE = @IdRole) \n";
            R += "BEGIN \n";
            R += "PRINT 'SIN ROLE' \n";
            R += "INSERT INTO USERROLE (idrole,iduser) \n";
            R += "SELECT @IdRole AS idRole, WFU.iduser AS iduser \n";
            R += "FROM WFUSER WFU \n";
            R += "WHERE WFU.username = VAR2GJ[UserName] \n";
            R += "END \n";
            R += "ELSE \n";
            R += "BEGIN \n";
            R += "PRINT 'YA EXISTE ROLE' \n";
            R += "END \n";
            R += "GO \n";
            */
            return R;
        }

        private void btoExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtRutaArchivo.Text = openFileDialog1.FileName;
            } 
        }

    }
}
