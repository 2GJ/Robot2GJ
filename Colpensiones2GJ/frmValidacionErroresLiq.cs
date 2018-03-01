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
    public partial class frmValidacionErroresLiq : Form
    {
        public frmValidacionErroresLiq()
        {
            InitializeComponent();
        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            }
        }

        private void btoLeerArchivo_Click(object sender, EventArgs e)
        {
            //Abrir el archivo de captura.
            if (this.tbExaminar.Text == null)
                MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

            tbTEjecucion.Text = "0";
            tbTPromedio.Text = "0";
            tbTEstFin.Text = "0";
            tbOK.Text = "0";
            tbError.Text = "0";

            string LineaCaptura;
            StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);


            Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
            RegTotal.Text = y.ToString();

            ResumenTiempo objResT = new ResumenTiempo(y);
            objResT.F_StartTimer();

            this.Refresh();

            while ((LineaCaptura = FileCaptura.ReadLine()) != null)
            {
                char tmpChar = '\t';
                char[] Separador = new char[] { tmpChar };
                string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                string strLinea = "";

                for (int i = 0; i < strLineArzay.Length; i++)
                {
                    strLinea += strLineArzay[i] + "\t";
                }
            }
        }

        private void btProcesarArchivo_Click(object sender, EventArgs e)
        {
            //int Contador = 0;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso.
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    objRec.Get_InformacionReconocimiento();
                    objRec.GetActividadEtapaActual();

                    //Validar Decision actual
                    string RespuestaValDecision = "";
                    if ((objRec.IdP_Decision.SCodigo != "1") && (objRec.IdP_Decision.SCodigo != "2") && (objRec.IdP_Decision.SCodigo != "4"))
                    {
                        //Casos no decididos...
                        //Leer Respuesta LOG Liquidador...
                        if ((strLineArzay[8] != null) && (strLineArzay[8] != ""))
                        {
                            string tmp = strLineArzay[8];
                            tmp = tmp.Replace("Intento 1", "");
                            tmp = tmp.Replace(":", "");
                            tmp = tmp.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");


                            //Realizar envio de XML al Liquidador.....
                            CapaSOABizAgi IntentoXMLLiq = new CapaSOABizAgi();
                            string Respuesta = IntentoXMLLiq.ServicioSetEventByXML(strLineArzay[7]);
                            RespuestaValDecision = Respuesta;

                            //CapaSOABizAgi Respuesta = new CapaSOABizAgi();
                            //string Res = Respuesta.CapturaRespuestaBA(tmp);

                            if ((Respuesta.Contains("(id:168)")) && (Respuesta.Contains("no est")) && (Respuesta.Contains("disponible para el proceso")))
                            {
                                int Task;
                                if (objRec.EtapaActividad == "tskLiquidacionAutomatico")
                                {
                                    Task = 4329;
                                    RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, Task);
                                }
                                else if (objRec.EtapaActividad == "CasoAsignadoAlLiquidador")
                                {
                                    Task = 162;
                                    //relizar perfom a firmado.
                                    RespuestaValDecision = objRec.Set_PerformPorFaltaEvento(Task);
                                    //Reliazar Perform de firmado salida.
                                    if (RespuestaValDecision.Contains("EJECUCION CORRECTA..."))
                                    {
                                        RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, 174);
                                    }
                                    else
                                    {
                                        RespuestaValDecision = "No se pudo ejecutar perform para pasar caso a firmado...";
                                    }
                                }
                                else if (objRec.EtapaActividad == "ParaFirma")
                                {
                                    Task = 173;
                                    //Relizar perfom a firmado.
                                    RespuestaValDecision = objRec.Set_PerformPorFaltaEvento(Task);
                                    //Reliazar Perform de firmado salida.
                                    if (RespuestaValDecision.Contains("EJECUCION CORRECTA..."))
                                    {
                                        RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, 174);
                                    }
                                    else
                                    {
                                        RespuestaValDecision = "No se pudo ejecutar perform para pasar caso a firmado...";
                                    }
                                }
                                else if (objRec.EtapaActividad == "EnDecision")
                                {
                                    Task = 171;
                                    //Relizar perfom a firmado.
                                    RespuestaValDecision = objRec.Set_PerformPorFaltaEvento(Task);
                                    //Reliazar Perform de firmado salida.
                                    if (RespuestaValDecision.Contains("EJECUCION CORRECTA..."))
                                    {
                                        RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, 174);
                                    }
                                    else
                                    {
                                        RespuestaValDecision = "No se pudo ejecutar perform para pasar caso a firmado...";
                                    }
                                }
                                else if (objRec.EtapaActividad == "Task11")
                                {
                                    RespuestaValDecision = "Investigacion Administrativa...";
                                }

                                else if (objRec.EtapaActividad == "Firmado")
                                {
                                    Task = 174;
                                    RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, Task);
                                }
                                else if (objRec.EtapaActividad == "Task2")
                                {
                                    Task = 876;
                                    //Relizar perfom a firmado.
                                    RespuestaValDecision = objRec.Set_PerformPorFaltaEvento(Task);
                                    //Reliazar Perform de firmado salida.
                                    if (RespuestaValDecision.Contains("EJECUCION CORRECTA..."))
                                    {
                                        RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, 174);
                                    }
                                    else
                                    {
                                        //1Tarea (id:876) no está disponible para el proceso (id:4426372)
                                        if ((RespuestaValDecision.Contains("(id:876)")) && (RespuestaValDecision.Contains("no est")) && (RespuestaValDecision.Contains("disponible para el proceso")))
                                        {
                                            objRec.GetActividadEtapaActual();
                                            string ResUpdEtapa = objRec.UpdateEtapa("0");

                                            Task = 171;
                                            //Relizar perfom a firmado.
                                            RespuestaValDecision = objRec.Set_PerformPorFaltaEvento(Task);
                                            //Reliazar Perform de firmado salida.
                                            if (RespuestaValDecision.Contains("EJECUCION CORRECTA..."))
                                            {
                                                RespuestaValDecision = IntentoXMLLiq.ConvertirSetEventPerform(strLineArzay[7], objRec.IdCase, 174);
                                            }
                                            else
                                            {
                                                CapaSOABizAgi objGetCase = new CapaSOABizAgi();
                                                string resGetCase = objGetCase.Get_InfoCaseBizAgiByRadBasic(objRec.RadNumber);
                                                if (resGetCase.Contains("1No se encontraron registros"))
                                                    RespuestaValDecision = "Caso cerrado o anulado...";
                                                else
                                                    RespuestaValDecision = "No se pudo ejecutar perform para pasar caso a firmado...";
                                            }

                                        }
                                        else
                                        {
                                            CapaSOABizAgi objGetCase = new CapaSOABizAgi();
                                            string resGetCase = objGetCase.Get_InfoCaseBizAgiByRadBasic(objRec.RadNumber);
                                            if (resGetCase.Contains("EJECUCION CORRECTA..."))
                                                RespuestaValDecision = "EJECUCION CORRECTA...";
                                            else
                                                RespuestaValDecision = "No se pudo ejecutar etapa 80 caso debe estar anulado o cerrado...";
                                        }
                                    }
                                }
                                else
                                {
                                    RespuestaValDecision = "Esta en Otra Actividad (" + objRec.EtapaActividad + "Id:" + "XX" + ")";
                                }
                            }
                        }
                        else
                        {
                            RespuestaValDecision = "NO SE TIENEN XML EN LOGS LIQUIDADOR...";
                        }

                    }
                    else
                    {
                        //Casos decididos...
                        RespuestaValDecision = "CASO YA DECIDIDO...";
                    }

                    rtRespuesta.Text += strLinea + "\t" + RespuestaValDecision + "\n";

                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void btExaminar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbExaminar.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i] + "\t";
                    }

                    //Consultar Estado del Caso.
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    objRec.GetActividadEtapaActual();
                    string ResUpdEtapa = objRec.UpdateEtapa("0");

                    rtRespuesta.Text += strLineArzay[0] + "\t" + strLineArzay[1] + "\t" + objRec.CodError + "\t" + objRec.DesError + "\t" + ResUpdEtapa + "\n";

                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i] + "\t";
                    }

                    //Inicializa Clase Reconocimiento..
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));

                    //Ejecuta Respuesta Etapa 110.
                    string ResUpdEtapa = objRec.Set_Etapa110(strLineArzay[2]);


                    //Valida error:
                    if (ResUpdEtapa.Contains("1Tarea (id:168) no está disponible para el proceso"))
                    {
                        //Actualizar caso con el campo de tipo accion liquidador en actulizar.
                        ResUpdEtapa = objRec.Set_Etapa110PA(strLineArzay[2]);
                    }


                    rtRespuesta.Text += strLineArzay[0] + "\t" + strLineArzay[1] + "\t" + strLineArzay[2] + "\t" + objRec.CodError + "\t" + objRec.DesError + "\t" + ResUpdEtapa + "\n";


                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);


                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void btoConsultarCiudadResidencia_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i] + "\t";

                    }

                    rtRespuesta.Text += strLinea;

                    //Inicializa Clase Reconocimiento..
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));

                    objRec.GetInformacionCiudadano();

                    string sRespuesta = objRec.MunicipioResidencia + "\t" + objRec.DepartamentoResidencia + "\t" + objRec.CodigoDaneResidencia;

                    rtRespuesta.Text += "\t" + sRespuesta + "\n";

                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void btoCapturaLOG_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no es valido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                Int64 y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                int ContCol = 0;
                int ConrLin = 0;
                string sCol = "";

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    ConrLin += 1;

                    for (int z = 0; z < LineaCaptura.Length; z++)
                    {

                        //Cambio Columna//
                        if (LineaCaptura.Substring(z, 1) == "|")
                        {
                            ContCol += 1;
                            rtRespuesta.Text += sCol + "\t";
                            sCol = "";
                        }
                        //Cambio de columna por fin de linea...
                        else if ((ContCol == 18) && (z == LineaCaptura.Length - 1))
                        {
                            if (LineaCaptura.Substring(z, 1) == "\t")
                                sCol += " ";
                            else
                                sCol += LineaCaptura.Substring(z, 1);
                            ContCol = 0;
                            rtRespuesta.Text += sCol + "\n";
                            sCol = "";
                        }
                        else
                        {
                            if (LineaCaptura.Substring(z, 1) == "\t")
                                sCol += " ";
                            else
                                sCol += LineaCaptura.Substring(z, 1);
                        }
                    }

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void btoErrorEnFirma_Click(object sender, EventArgs e)
        {
            int Contador = 0;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRes = "";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso.
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    objRec.Get_InformacionReconocimiento();
                    objRec.GetActividadEtapaActual();


                    //Validar si tiene ya una decision.
                    if ((objRec.IdP_Decision.SCodColpensiones == "1") || (objRec.IdP_Decision.SCodColpensiones == "2") || (objRec.IdP_Decision.SCodColpensiones == "3"))
                    {
                        CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();

                        string sXML = "<BizAgiWSParam><ActivityData><idCase>" + objRec.IdCase + "</idCase><taskId>174</taskId></ActivityData><Entities><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                        sRes = objCapaSOA.ServicioPerformActivity(sXML);
                    }
                    else
                    {
                        sRes = "NO TIENE UN DECISION";
                    }

                    rtRespuesta.Text += strLinea + "\t" + sRes + "\n";

                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void btoResLiqGenXML_Click(object sender, EventArgs e)
        {
            int Contador = 0;

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRes = "";
                    string sValRes = "NoNewVal";

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso.
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    objRec.Get_InformacionReconocimiento();
                    objRec.GetActividadEtapaActual();


                    //Verificacion de Actividad...
                    if ((strLineArzay[16].ToString().Contains("Caso asignado al liquidador")) && (objRec.EtapaActividad != "CasoAsignadoAlLiquidador"))
                    {
                        //sRes = "Error en registro de Actividad1...";
                        objRec.EtapaActividad = "CasoAsignadoAlLiquidador";
                        sValRes = "ERROR SOLACT1";

                        string se1 = "";
                        se1 += "<BizAgiWSParam>";
                        se1 += "<Entities idCase=\"" + objRec.IdCase + "\">";
                        se1 += "<M_cat_Reconocimiento>";
                        se1 += "<IdM_RC01Reconocimiento>";
                        se1 += "<SActividadActual>" + objRec.EtapaActividad + "</SActividadActual>";
                        se1 += "</IdM_RC01Reconocimiento>";
                        se1 += "</M_cat_Reconocimiento>";
                        se1 += "</Entities>";
                        se1 += "</BizAgiWSParam>";

                        CapaSOABizAgi objSOAA = new CapaSOABizAgi();
                        sValRes += objSOAA.ServicioSaveEntity(se1);


                    }
                    else if ((strLineArzay[16].ToString().Contains("Esperando Accion Liquidador")) && (objRec.EtapaActividad != "Task2"))
                    {
                        //sRes = "Error en registro de Actividad2...";
                        objRec.EtapaActividad = "Task2";
                        sValRes = "ERROR SOLACT2";

                        string se1 = "";
                        se1 += "<BizAgiWSParam>";
                        se1 += "<Entities idCase=\"" + objRec.IdCase + "\">";
                        se1 += "<M_cat_Reconocimiento>";
                        se1 += "<IdM_RC01Reconocimiento>";
                        se1 += "<SActividadActual>" + objRec.EtapaActividad + "</SActividadActual>";
                        se1 += "</IdM_RC01Reconocimiento>";
                        se1 += "</M_cat_Reconocimiento>";
                        se1 += "</Entities>";
                        se1 += "</BizAgiWSParam>";

                        CapaSOABizAgi objSOAA = new CapaSOABizAgi();
                        sValRes += objSOAA.ServicioSaveEntity(se1);

                    }
                    //else
                    //{


                    string sCodDANE = "";
                    string sCodDANEDEP = "";
                    string sCodDANEMUN = "";

                    //Departamento 2 posiciones
                    if (strLineArzay[6].Length == 1)
                    {
                        sCodDANEDEP = "0" + strLineArzay[6];
                    }
                    else if (strLineArzay[6].Length == 2)
                    {
                        sCodDANEDEP = strLineArzay[6];
                    }
                    else
                    {
                        sCodDANEDEP = "ERROR EN CODIGO DEPARTAMENTO";
                        sRes += sCodDANEDEP;
                    }

                    //Municipio 3 posiciones
                    if (strLineArzay[7].Length == 1)
                    {
                        sCodDANEMUN = "00" + strLineArzay[7];
                    }
                    else if (strLineArzay[7].Length == 2)
                    {
                        sCodDANEMUN = "0" + strLineArzay[7];
                    }
                    else if (strLineArzay[7].Length == 3)
                    {
                        sCodDANEMUN = strLineArzay[7];
                    }
                    else
                    {
                        sCodDANEMUN = "ERROR EN CODIGO MUNICIPIO";
                        sRes += sCodDANEMUN;
                    }


                    if (sCodDANEMUN.Length == 3 && sCodDANEDEP.Length == 2)
                    {

                        sCodDANE = sCodDANEDEP + sCodDANEMUN;
                        string XML = objRec.GenerarXMLRespuestaNP(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], strLineArzay[3], strLineArzay[4],
                                                        strLineArzay[5], strLineArzay[9], sCodDANE, strLineArzay[15],
                                                        strLineArzay[13], strLineArzay[14], strLineArzay[12], strLineArzay[8],
                                                        strLineArzay[10], strLineArzay[11], strLineArzay[17], strLineArzay[18],
                                                        strLineArzay[19], strLineArzay[20]);

                        /*
                         * -> 1-Int32 In_IdCase         0
                         * XRadNumber                   1  
                         * -> 2-string In_sActoAdm      2
                         * -> 3-string In_sEtapa        3
                         * -> 4-string In_SResolucion   4
                         * -> 5-string In_SCodDecision  5
                         * -> 6-string In_SDireccionPN  9 
                         * -> 7-string In_SCodDANE      6 Departamento  UNION
                         * -> 7-string In_SCodDANE      7 Municipio     UNION
                         * -> 8-string In_sSN           15
                         * -> 9-string In_sPN           13
                         * -> 10-string In_sSA          14
                         * -> 11-string In_sPA          12
                         * -> 12-string In_sTel         8
                         * -> 13-string In_sTipDoc      10
                         * -> 14-string In_SNoIden      11
                         */

                        string bErrorEtapa = "0";

                        bErrorEtapa = "0";

                        if (XML.Contains("ERROR"))
                        {
                            sRes = XML;
                        }
                        else
                        {
                            if (XML.Contains("<IdP_Accion businessKey=\"SEtapa='N/A'\"/>"))
                            {
                                bErrorEtapa = "1";
                                XML = XML.Replace("<IdP_Accion businessKey=\"SEtapa='N/A'\"/>", "<IdP_Accion businessKey=\"SEtapa='80'\"/>");
                            }

                            CapaSOABizAgi objSOA = new CapaSOABizAgi();
                            sRes = objSOA.ServicioSetEventByXML(XML);

                            if (!sRes.Contains("EJECUCION CORRECTA") && (bErrorEtapa == "1"))
                            {
                                XML = XML.Replace("<IdP_Accion businessKey=\"SEtapa='N/A'\"/>", "<IdP_Accion businessKey=\"SEtapa='110'\"/>");
                                sRes = objSOA.ServicioSetEventByXML(XML);
                            }

                            if (sRes.Contains("Tarea (id:168) no está disponible para el proceso"))
                            {
                                int IdTaskBA = 0;

                                if (objRec.EtapaActividad == "Task2")
                                    IdTaskBA = 876;

                                if (objRec.EtapaActividad == "CasoAsignadoAlLiquidador")
                                    IdTaskBA = 162;

                                if (objRec.EtapaActividad == "EnRevision")
                                    IdTaskBA = 172;

                                if (objRec.EtapaActividad == "EnDecision")
                                    IdTaskBA = 171;

                                if (objRec.EtapaActividad == "ParaFirma")
                                    IdTaskBA = 173;

                                if (objRec.EtapaActividad == "Task4")
                                    IdTaskBA = 892;

                                if (objRec.EtapaActividad == "tskLiquidacionAutomatico")
                                    IdTaskBA = 4329;

                                if (objRec.EtapaActividad == "Firmado")
                                    IdTaskBA = 174;


                                CapaSOABizAgi ConvPerfor = new CapaSOABizAgi();
                                string A = ConvPerfor.ConvertirSetEventPerform(XML, objRec.IdCase, IdTaskBA);

                                if (!A.Contains("EJECUCION CORRECTA"))
                                {
                                    if (A.Contains("Tarea (id:168) no está disponible para el proceso"))
                                        sRes = "Caso en otra actividad sin envio al liquidador...";
                                    else
                                        sRes = A;
                                }
                                else
                                {
                                    objRec.GetActividadEtapaActual();


                                    if (objRec.EtapaActividad == "Firmado")
                                    {
                                        IdTaskBA = 174;
                                        A = ConvPerfor.ConvertirSetEventPerform(XML, objRec.IdCase, IdTaskBA);
                                    }

                                    sRes = A;
                                }
                            }


                            //string sXML = "<BizAgiWSParam><ActivityData><idCase>" + objRec.IdCase + "</idCase><taskId>174</taskId></ActivityData><Entities><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                            //string sResTMP = objSOA.ServicioPerformActivity(sXML);
                        }
                    }
                    //}
                    rtRespuesta.Text += strLinea + "\t" + sRes + "\t" + sValRes + "\n";

                    if (objRec.CodError == "0")
                        tbOK.Text = Convert.ToString(Convert.ToInt32(tbOK.Text) + 1);
                    else
                        tbError.Text = Convert.ToString(Convert.ToInt32(tbError.Text) + 1);

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private Boolean validarSiguienteIdCase(String[] arr, int idxActual, int idxSiguiente) {

            char tmpChar = '\t';
            char[] Separador = new char[] { tmpChar };

            String lineaActual = arr[idxActual];
            string[] camposRegistroActual = lineaActual.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
            String idCaseActual = camposRegistroActual[0];

            String idCaseSiguiente;

            if (idxSiguiente < arr.Length)
            {
                String lineaSiguiente = arr[idxSiguiente];
                string[] camposRegistroSiguiente = lineaSiguiente.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                idCaseSiguiente = camposRegistroSiguiente[0];
            }
            else {
                idCaseSiguiente = "";
            }

            if (idCaseActual.Equals(idCaseSiguiente))
            {
                return true;
            }
            else {
                return false;
            }
        
        }
        
        private void btoGenResXML_Click(object sender, EventArgs e)
        {

            rtRespuesta.Text = "";
            rtSQL.Text = "";

            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");


                //2GJ: Se inician campos de tiempos.
                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";


                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();
                
                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();
                
                /*-------------------------------------------------------------------------------*/
                String[] totalLineas = File.ReadAllLines(this.tbExaminar.Text);
                Console.WriteLine("El tamaño del arreglo es: " + totalLineas.Length);
                Console.ReadLine();
                int contador = 0;
                var persNoticiar = new List<PersonasNotificar>();

                while (contador < totalLineas.Length)
                {
                    
                    string sCodigoDANE = "";
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = totalLineas[contador].Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    if (validarSiguienteIdCase(totalLineas,contador, contador + 1))
                    {
                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                        persNoticiar.Add(new PersonasNotificar(strLineArzay[6], strLineArzay[7], sCodigoDANE, strLineArzay[10],
                                                               strLineArzay[11], strLineArzay[13], strLineArzay[15], strLineArzay[12],
                                                               strLineArzay[14], strLineArzay[9], strLineArzay[8], strLineArzay[20]));
                        objResT.F_MarkTimer();
                        
                    }
                    else
                    {

                        string strLinea = "";
                        string sRespuestaCaso = "Res: ";
                        string sDetalleRespuesta = "Detalle: ";
                        string sInformacionTecnica = "Logs: ";
                        string sEtapa = "";
                        string PATask = "NULL";
                        string PAIdTask = "NULL";

                        Boolean bEventoDisponible = false;

                        for (int i = 0; i < strLineArzay.Length; i++)
                        {
                            strLinea += strLineArzay[i].Trim() + "\t";
                        }

                        //Consultar Estado del Caso...
                        Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                        //Informacion de Reconocimiento...
                        objRec.Get_InformacionReconocimiento();
                        //Informacion de Actividad Actual...
                        objRec.GetActividadEtapaActual();
                        //Consulta informacion BizAgi...
                        objRec.Reconocimiento_CargarDatosBizAgi();

                        if ((objRec.DatosBizAgi.IdCase == 0) && (objRec.DatosBizAgi.RadNumber == "0"))
                        {
                            sDetalleRespuesta += "CASO CERRADO O NO EXISTE...";
                            sRespuestaCaso += "CASO CERRADO O NO EXISTE.";
                        }
                        else
                        {

                            sDetalleRespuesta += "CASO ENCONTRADO...";
                            
                            //VERIFICACIONES...

                            //Verificacion de evento de comunicacion con el liquidador...
                            if (objRec.DatosBizAgi.BuscarIdTask(168) == false)
                            {
                                sDetalleRespuesta += "CASO SIN REG ACTIVIDADES DISPONIBLE...";
                                bEventoDisponible = false;
                            }
                            else
                            {
                                sDetalleRespuesta += "CASO CON REG ACTIVIDADES DISPONIBLE...";
                                //sDetalleRespuesta += "CASO SIN REG ACTIVIDADES DISPONIBLE...";
                                bEventoDisponible = true;
                            }

                            //Verificar informacion de actividad actual
                            if (objRec.DatosBizAgi.BuscarNameTask(objRec.EtapaActividad) == true)
                            {
                                sDetalleRespuesta += "CASO CON INFORMACION CORRECTA DE ACTIVIDAD ACTUAL...";
                            }
                            else
                            {
                                sDetalleRespuesta += "CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL...";
                            }

                            //SOLUCION DE ERRORES...
                            
                            //Solucion en informacion de actividad actual.
                            if (sDetalleRespuesta.Contains("CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL..."))
                            {
                                //876	Task2	                    Esperando Accion Liquidador
                                //162	CasoAsignadoAlLiquidador	Caso asignado al liquidador
                                //174	Firmado	                    Firmado
                                //4329	tskLiquidacionAutomatico	Liquidacion Automatico
                                //171	EnDecision	                En decisión 
                                //172	EnRevision	                En revisión
                                //173	ParaFirma	                Para Firma
                                //183	ReportadoANomina	        Reportado a nómina
                                //892	Task4	                    Devolver Para Decision
                                //994	Task9	                    Devolucion por Documentos 
                                //1075	Task11	                    Devuelto Investigacion Adminitrativa
                                //1076	Task12	                    Devuelto Consulta Cuota Parte
                                //4899	VerificacionDecision	    Verificación de Decision
                                //ACTIVIDAD NO IDENTIFICADA...

                                string ResSolAct = objRec.SolucionActividadActualEnData();


                                if (ResSolAct == "ACTIVIDAD NO IDENTIFICADA...")
                                {
                                    if (bEventoDisponible == true)
                                    {
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("RegistroDeActividades");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    else
                                    {
                                        Int64 IdActDecTom = objRec.BuscarIWorkItemXActividad("Task5");

                                        if (IdActDecTom > 0)
                                        {
                                            CapaSOABizAgi objCS = new CapaSOABizAgi();
                                            string sRespBA = objCS.IniciarPerformActivity("domain", "admon", objRec.IdCase, 897);
                                            sRespuestaCaso = "DECISION TOMADA: " + sRespBA;
                                            sDetalleRespuesta += "DECISION TOMADA: " + sRespBA;
                                        }
                                        else
                                        {
                                            sDetalleRespuesta = sDetalleRespuesta.Replace("CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL...", ResSolAct);
                                        }
                                    }
                                }
                                else if ((ResSolAct == "DecisionTomada") || (ResSolAct == "ActualizacionBDMisionales") ||
                                    (ResSolAct == "RCEventHistoriaLaboral") || (ResSolAct == "EnviarInformacionAlLiquida"))
                                {
                                    string NewString = "CASO CON INFORMACION CORRECTA DE ACTIVIDAD ACTUAL...";
                                    sDetalleRespuesta = sDetalleRespuesta.Replace("CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL...", NewString);
                                }
                                else if (ResSolAct == "VerificacionDecision")
                                {
                                    ResSolAct = "PA VerificacionDECISION";
                                    sDetalleRespuesta = sDetalleRespuesta.Replace("CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL...", ResSolAct);
                                }
                                else
                                {
                                    string NewString = "ACTIVIDAD SOL: " + ResSolAct + "...";
                                    sDetalleRespuesta = sDetalleRespuesta.Replace("CASO CON ERROR EN INFORMACION DE ACTIVIDAD ACTUAL...", NewString);
                                }
                            }
                            

                            //Validar actividad para realizar seteo
                            //1-CASO CON INFORMACION CORRECTA DE ACTIVIDAD ACTUAL...
                            if ((sDetalleRespuesta.Contains("CASO CON INFORMACION CORRECTA DE ACTIVIDAD ACTUAL...")) ||
                                (sDetalleRespuesta.Contains("ACTIVIDAD SOL:")))
                            {
                                if (objRec.EtapaActividad == "Task2")
                                {
                                    if (sDetalleRespuesta.Contains("CASO CON REG ACTIVIDADES DISPONIBLE..."))
                                    {
                                        sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR NP...";
                                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                        sEtapa = "80";
                                    }
                                    else
                                    {
                                        sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                        PATask = "Task2";
                                        PAIdTask = "876";
                                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                    }
                                }
                                else if (objRec.EtapaActividad == "CasoAsignadoAlLiquidador")
                                {
                                    if (sDetalleRespuesta.Contains("CASO CON REG ACTIVIDADES DISPONIBLE..."))
                                    {
                                        sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR NP...";
                                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                        sEtapa = "80";
                                    }
                                    else
                                    {

                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("CasoAsignadoAlLiquidador");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                        sDetalleRespuesta = sDetalleRespuesta.Replace("ACTIVIDAD LISTA PARA GENERAR NP...", "REQUIERE APOYO DEL EQUIPO BIZAGI...");

                                        //sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                        //sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                        //PATask = "CasoAsignadoAlLiquidador";
                                        //PAIdTask = "162";
                                    }
                                }
                                else if (objRec.EtapaActividad == "Firmado")
                                {
                                    if (sDetalleRespuesta.Contains("CASO SIN REG ACTIVIDADES DISPONIBLE"))
                                    {
                                        sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                        PATask = "Firmado";
                                        PAIdTask = "174";
                                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                        sEtapa = "80";
                                    }
                                    else
                                    {
                                        sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR NP...";
                                        sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                        sEtapa = "80";
                                    }
                                }
                                else if (objRec.EtapaActividad == "DecisionTomada")
                                {
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    PATask = "DecisionTomada";
                                    PAIdTask = "897";
                                }
                                else if (objRec.EtapaActividad == "RCEventHistoriaLaboral")
                                {
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    PATask = "RCEventHistoriaLaboral";
                                    PAIdTask = "4467";
                                }
                                else if (objRec.EtapaActividad == "EnviarInformacionAlLiquida")
                                {
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    PATask = "EnviarInformacionAlLiquida";
                                    PAIdTask = "141";
                                }
                                else if (objRec.EtapaActividad == "ActualizacionBDMisionales")
                                {
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    PATask = "ActualizacionBDMisionales";
                                    PAIdTask = "3655";
                                }
                                else if (objRec.EtapaActividad == "tskLiquidacionAutomatico")
                                {
                                    //if (sDetalleRespuesta.Contains("CASO SIN REG ACTIVIDADES DISPONIBLE...") == true)
                                    //{
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                    PATask = "tskLiquidacionAutomatico";
                                    PAIdTask = "4329";
                                    //}
                                    //else
                                    //{
                                    //    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR NP...";
                                    //    sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                    //    sEtapa = "110";
                                    //}
                                }
                                else if (objRec.EtapaActividad == "ParaFirma")
                                {
                                    sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                    sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                                    PATask = "ParaFirma";
                                    PAIdTask = "173";
                                }
                                else
                                {
                                    sDetalleRespuesta += "PENDIENTE DEFINIR ACCION PARA ACTIVIDAD...";
                                }
                            }
                            else if (sDetalleRespuesta.Contains("PA VerificacionDECISION"))
                            {
                                sDetalleRespuesta += "ACTIVIDAD LISTA PARA GENERAR PA...";
                                sCodigoDANE = "N/A";
                                PATask = "VerificacionDecision";
                                PAIdTask = "4899";
                            }
                            else
                            {
                                sDetalleRespuesta += "ACTIVIDAD ACTUAL: " + objRec.EtapaActividad + "...";
                            }

                            //Validar Codigo DANE
                            if (sCodigoDANE.Length == 5)
                            {
                                sDetalleRespuesta += "CODIGO DANE VALIDO...";
                            }
                            else
                            {
                                sDetalleRespuesta += "CODIGO DANE INVALIDO...";
                            }

                            //Valida ETAPA
                            if (strLineArzay[3] != "N/A")
                            {
                                sEtapa = strLineArzay[3];
                            }

                            //GENERACION DE NOTIFICACION.
                            //Generacion por escenario normal (Detalle: CASO ENCONTRADO...
                            //                                          CASO CON REG ACTIVIDADES DISPONIBLE...
                            //                                          CASO CON INFORMACION CORRECTA DE ACTIVIDAD ACTUAL...
                            //                                          ACTIVIDAD LISTA PARA GENERAR NP...
                            //                                          CODIGO DANE VALIDO...).

                            if (sDetalleRespuesta.Contains("ACTIVIDAD LISTA PARA GENERAR NP..."))
                            {
                                Boolean bReintento = false;

                                do
                                {
                                    bReintento = false;

                                    //Generar SetEvent:

                                    persNoticiar.Add(new PersonasNotificar(strLineArzay[6], strLineArzay[7], sCodigoDANE, strLineArzay[10],
                                                               strLineArzay[11], strLineArzay[13], strLineArzay[15], strLineArzay[12],
                                                               strLineArzay[14], strLineArzay[9], strLineArzay[8], strLineArzay[20]));

                                    string XML = objRec.GenerarXMLRespuestaNPMultiPerson(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], sEtapa, strLineArzay[4],
                                                                    strLineArzay[5], strLineArzay[17], strLineArzay[18],
                                                                    strLineArzay[19], strLineArzay[20], persNoticiar);
                        

                                    /*string XML = objRec.GenerarXMLRespuestaNP(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], sEtapa, strLineArzay[4],
                                                                    strLineArzay[5], strLineArzay[9], sCodigoDANE, strLineArzay[15],
                                                                    strLineArzay[13], strLineArzay[14], strLineArzay[12], strLineArzay[8],
                                                                    strLineArzay[10], strLineArzay[11], strLineArzay[17], strLineArzay[18],
                                                                    strLineArzay[19], strLineArzay[20]);*/


                                    CapaSOABizAgi objSOA = new CapaSOABizAgi();
                                    var sResNP = objSOA.ServicioSetEventByXML(XML);

                                    if (!sRespuestaCaso.Contains("EJECUCION CORRECTA"))
                                    {
                                        //Solusiones post envio...
                                        if (sResNP.Contains("Val-Etapa no valida para liquidacion automatica."))
                                        {
                                            //Se apaga el indicador de automatico.
                                            sInformacionTecnica += "SaveEntity IndAutomaticoOff: " + objRec.UpdateIndicadorAutomatico(false) + "...";
                                            bReintento = true;
                                        }
                                        else if (sResNP.Contains("Val-Reconocimiento ya tiene decision."))
                                        {
                                            //Borrar personas a notificar...
                                            sRespuestaCaso += "Require revisar la coleccion de personas a notificar...";
                                        }
                                        else
                                        {
                                            sInformacionTecnica += "XML Enviado: " + XML + "...";
                                        }
                                    }
                                    else
                                    {
                                        sDetalleRespuesta += sRespuestaCaso;
                                    }

                                } while (bReintento == true);
                            }
                            else if (sDetalleRespuesta.Contains("ACTIVIDAD LISTA PARA GENERAR PA..."))
                            {
                                if (("RCEventHistoriaLaboral" == PATask) || ("EnviarInformacionAlLiquida" == PATask)
                                        || ("ActualizacionBDMisionales" == PATask))
                                {
                                    //Reliza perform Activity
                                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                                    string sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                    sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ":ResPA:" + sRespBA + ")...";
                                    sRespuestaCaso += "REPETIR EJECUCION DE ROBOT...";

                                    if (sRespBA.Contains("ind_automatico, 1804, Campo ind_automatico esta en N y usuario es AUTOMATICO o revisor es RAUTOMATICO") == true)
                                    {
                                        sInformacionTecnica += objRec.UpdateIndicadorAutomatico(true);
                                        //sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                        //sDetalleRespuesta += "SE EJECUTO PA 2 (" + PAIdTask + ":" + PATask + ":ResPA:" + sRespBA + ")...";
                                        //sRespuestaCaso += "REPETIR EJECUCION DE ROBOTO...";
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    if (sRespBA.Contains("NumeroIdentificacion, 1406, Error Numero de Cedula Ciudadania NO esta en rango para genero Masculino"))
                                    {
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    if (sRespBA.Contains("Instancia no es válido, debe ingresar alguna de las siguientes opciones: [01|02|03|04|05|06|07]"))
                                    {
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    if (sRespBA.Contains("NumeroIdentificacion, 1405, Error Numero de Cedula Ciudadania NO esta en rango para genero Femenino"))
                                    {
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    if (sRespBA.Contains("FechaSolicitud Debe tener una longitud de 8 caracteresFechaSolicitud no es válido, solo permite números, el formato debe ser YYYYMMDD"))
                                    {
                                        Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                        string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                        rtSQL.Text += sqlUpdate + "\n";
                                        sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                    }
                                    if (sRespBA.Contains("Observación no es válido, debe ingresar un valor cuando el tipo de trámite es ACTUALIZAR."))
                                    {
                                        string XMLSE2 = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente><IdP_AccionLiquidador>1</IdP_AccionLiquidador></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                        sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE2);

                                        sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                        sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                        sInformacionTecnica += "ResPA: " + sRespBA;

                                        if (!sRespBA.Contains("EJECUCION CORRECTA..."))
                                        {
                                            Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("EnviarInformacionAlLiquida");
                                            string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                            rtSQL.Text += sqlUpdate + "\n";
                                            sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                        }


                                    }


                                }
                                else if ("tskLiquidacionAutomatico" == PATask)
                                {
                                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                                    string XMLSE = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                    string sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE);

                                    sDetalleRespuesta += "SETEVENT VALIDACION FORMA MANUAL...";
                                    sInformacionTecnica += sRespBA;

                                    sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                    sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                    sInformacionTecnica += "ResPA: " + sRespBA;
                                }
                                else if ("CasoAsignadoAlLiquidador" == PATask)
                                {
                                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                                    string XMLSE = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                    string sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE);

                                    sDetalleRespuesta += "SETEVENT VALIDACION FORMA MANUAL...";
                                    sInformacionTecnica += sRespBA;

                                    sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                    sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                    sInformacionTecnica += "ResPA: " + sRespBA;
                                }
                                else if ("VerificacionDecision" == PATask)
                                {
                                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                                    string XMLSE = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BVerificadoCorrectamente>true</BVerificadoCorrectamente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                    string sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE);

                                    sDetalleRespuesta += "SETEVENT VALIDACION FORMA MANUAL...";
                                    sInformacionTecnica += sRespBA;

                                    sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                    sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                    sInformacionTecnica += "ResPA: " + sRespBA;
                                }

                                else
                                {
                                    //Reliza perform Activity
                                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                                    string sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));

                                    if (sRespBA.Contains("No es posible avanzar la actividad de forma manual, la actividad se avanza de forma automatica dependiendo del cambio de estados enviados por el liquidador!!!"))
                                    {
                                        string XMLSE = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                        sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE);

                                        sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                        sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                        sInformacionTecnica += "ResPA: " + sRespBA;

                                        if (sRespBA.Contains("No es posible avanzar la actividad de forma manual, la actividad se avanza de forma automatica dependiendo del cambio de estados enviados por el liquidador!!!"))
                                        {
                                            string XMLSE2 = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente><IdP_AccionLiquidador>1</IdP_AccionLiquidador></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                                            sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE2);

                                            sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32(PAIdTask));
                                            sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                            sInformacionTecnica += "ResPA: " + sRespBA;
                                        }
                                    }
                                    else
                                    {
                                        sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                                        sInformacionTecnica += "ResPA: " + sRespBA;
                                    }

                                    if (sRespBA.Contains("Tarea (id:897) no está disponible para el proceso") == true)
                                    {
                                        if (sDetalleRespuesta.Contains("CASO CON REG ACTIVIDADES DISPONIBLE"))
                                        {
                                            //UPDATE WORKITEM SET idtasl = 897 WHERE idworkitem = XXX
                                            Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("RegistroDeActividades");
                                            string sqlUpdate = "UPDATE WORKITEM SET idtask = 897 WHERE idworkitem = " + IdWorkItem;
                                            rtSQL.Text += sqlUpdate + "\n";
                                            sRespuestaCaso += "APOYO BIZAGI...";
                                        }
                                        else
                                        {
                                            Int64 IdWorkItem = 0;
                                            if (objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("InvestigacionAdministrativ") > 0)
                                            {
                                                //sDetalleRespuesta += "BUSCAR COMO INSTANCIAR ACTIVIDAD...";
                                                //UPDATE WORKITEM SET idtasl = 897 WHERE idworkitem = XXX
                                                //Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("RegistroDeActividades");
                                                IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("InvestigacionAdministrativ");
                                                string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                                rtSQL.Text += sqlUpdate + "\n";
                                                sRespuestaCaso += "APOYO BIZAGI...";
                                            }
                                            else
                                            {
                                                sRespuestaCaso += "MMMMM...";
                                            }
                                        }

                                    }
                                    else if (sRespBA.Contains("Las notificaciones para el subproceso son diferentes: 0_dif_0") == true)
                                    {
                                        if (sDetalleRespuesta.Contains("CASO CON REG ACTIVIDADES DISPONIBLE") || (1 == 1))
                                        {
                                            //sDetalleRespuesta += "NUEVO IFF...";
                                            //UPDATE WORKITEM SET idtasl = 897 WHERE idworkitem = XXX
                                            Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("DecisionTomada");
                                            string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                            rtSQL.Text += sqlUpdate + "\n";
                                            sRespuestaCaso += "APOYO BIZAGI...";
                                        }
                                    }
                                    else
                                    {
                                        if (objRec.EtapaActividad == "ParaFirma")
                                        {
                                            Int64 IdWorkItem = objRec.DatosBizAgi.BuscarIdWorkItemPorNameTask("ParaFirma");
                                            string sqlUpdate = "UPDATE WORKITEM SET idtask = 4329 WHERE idworkitem = " + IdWorkItem;
                                            rtSQL.Text += sqlUpdate + "\n";
                                            sRespuestaCaso += "REQUIERE APOYO DEL EQUIPO BIZAGI...";
                                        }

                                    }
                                    //if (sRespBA.Contains(" Las notificaciones para el subproceso son diferentes: 0_dif_0") == true)
                                    //{
                                    //    string sXML = objRec.GenerarXMLRespuestaNPSaveEntity(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], sEtapa, strLineArzay[4],
                                    //                                strLineArzay[5], strLineArzay[9], sCodigoDANE, strLineArzay[15],
                                    //                                strLineArzay[13], strLineArzay[14], strLineArzay[12], strLineArzay[8],
                                    //                                strLineArzay[10], strLineArzay[11], strLineArzay[17]);
                                    //
                                    //    string res = objCapaSoa.ServicioSaveEntity(sXML);
                                    //}

                                }
                            }



                            //Verificacion
                            //Consulta informacion BizAgi...
                            Reconocimiento objVerificacion = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                            objVerificacion.Reconocimiento_CargarDatosBizAgi();

                            //VERIFICACIONES...

                            //Verificacion de Existenciua del Caso o Caso Cerrado...
                            if ((objVerificacion.DatosBizAgi.IdCase == 0) && (objVerificacion.DatosBizAgi.RadNumber == "0"))
                            {
                                sRespuestaCaso += "VERIFICADO OK...";
                            }
                            else
                            {
                                sRespuestaCaso += "REQUIERE VERIFICACION...";
                            }
                        }
                       
                        persNoticiar.Clear();

                        rtRespuesta.Text += strLinea + sRespuestaCaso + "\t" + sDetalleRespuesta + "\t" + sInformacionTecnica + "\n";

                        objResT.F_MarkTimer();
                        tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                        tbTPromedio.Text = objResT.Get_TiempoPromedio();
                        tbTEstFin.Text = objResT.Get_TiempoEstimado();
                        RegProcesados.Text = objResT.Ejecutados.ToString();
                        this.Refresh();
                        
                    }
                    
                    contador++;
                }

                /*-----------------------------------------------------------------*/

     
            }catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message);
            }finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


        public string GenerarCodigoDane(string In_Departamento, string In_Municipio)
        {
            string sRespuesta = "";

            string sCodDANEDEP = "";
            string sCodDANEMUN = "";

            //Departamento 2 posiciones
            if (In_Departamento.Length == 1)
            {
                sCodDANEDEP = "0" + In_Departamento;
            }
            else if (In_Departamento.Length == 2)
            {
                sCodDANEDEP = In_Departamento;
            }
            else
            {
                sCodDANEDEP = "ERROR EN CODIGO DEPARTAMENTO";
                sCodDANEDEP += " (" + sCodDANEDEP + ").";
            }

            //Municipio 3 posiciones
            if (In_Municipio.Length == 1)
            {
                sCodDANEMUN = "00" + In_Municipio;
            }
            else if (In_Municipio.Length == 2)
            {
                sCodDANEMUN = "0" + In_Municipio;
            }
            else if (In_Municipio.Length == 3)
            {
                sCodDANEMUN = In_Municipio;
            }
            else
            {
                sCodDANEMUN = "ERROR EN CODIGO MUNICIPIO";
                sCodDANEMUN += " (" + sCodDANEMUN + ").";
            }

            sRespuesta = sCodDANEDEP + sCodDANEMUN;

            return sRespuesta;
        }

        public string GenrarEtapa(string In_Actividad)
        {
            string sRespuesta = "";

            if (In_Actividad == "Task2")
            {
                sRespuesta = "<IdP_Accion businessKey=\"SEtapa='80'\"/>";
            }
            else
            {
                sRespuesta = "NO EXISTE ETAPA VALIDA PARA LA ACTIVIDAD...";
            }

            return sRespuesta;

            //if (XML.Contains("<IdP_Accion businessKey=\"SEtapa='N/A'\"/>"))
            //{
            //    bErrorEtapa = "1";
            //    XML = XML.Replace("<IdP_Accion businessKey=\"SEtapa='N/A'\"/>", "<IdP_Accion businessKey=\"SEtapa='80'\"/>");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int Contador = 0;
            rtRespuesta.Text = "";
            rtSQL.Text = "";


            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRespuestaCaso = "Res: ";
                    string sDetalleRespuesta = "Detalle: ";
                    string sInformacionTecnica = "Logs: ";
                    string sSQL = "SQL: ";

                    //string sCodigoDANE = "";
                    //string sEtapa = "";
                    //string PATask = "NULL";
                    //string PAIdTask = "NULL";

                    //Boolean bEventoDisponible = false;

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso...
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    //Informacion de Reconocimiento...
                    objRec.Get_InformacionReconocimiento();
                    //Informacion de Actividad Actual...
                    objRec.GetActividadEtapaActual();
                    //Consulta informacion BizAgi...
                    objRec.Reconocimiento_CargarDatosBizAgi();


                    //VERIFICACIONES...

                    //Verificacion de Existenciua del Caso o Caso Cerrado...
                    if ((objRec.DatosBizAgi.IdCase == 0) && (objRec.DatosBizAgi.RadNumber == "0"))
                    {
                        sDetalleRespuesta += "CASO CERRADO O NO EXISTE...";
                        sRespuestaCaso += "CASO CERRADO O NO EXISTE.";
                    }
                    else
                    {
                        sDetalleRespuesta += "CASO ENCONTRADO...";

                        //Imprimir LOG de ACTIVIDADES...
                        string LOGAct = objRec.DatosBizAgi.LogIdWorkItem();



                        if (LOGAct.Contains("156-EsperarActualizacionDeInfo"))
                            LOGAct = LOGAct.Replace("156-EsperarActualizacionDeInfo;", "");

                        sDetalleRespuesta += LOGAct;

                        //162	CasoAsignadoAlLiquidador	    Caso asignado al liquidador
                        //890	DecisionTomada	                Decision Tomada Actualizar Información
                        //897	Task5	                        Decision Tomada


                        if (LOGAct == "890-DecisionTomada;897-Task5;162-CasoAsignadoAlLiquidador;")
                        {
                            //Como tiene decision tomada regresarlo a Liquidacion Automatica...
                            sSQL = "UPDATE WORKITEM SET idTask = 4329 where wiClosed = 0 and idtask = 890 and idCase = " + objRec.IdCase.ToString();
                            this.rtSQL.Text += sSQL + "\n";
                        }
                    }


                    rtRespuesta.Text += strLinea + sRespuestaCaso + "\t" + sDetalleRespuesta + "\t" + sInformacionTecnica + "\n";

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void button4_Click(object sender, EventArgs e)
        {
            //int Contador = 0;
            rtRespuesta.Text = "";
            rtSQL.Text = "";


            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRespuestaCaso = "Res: ";
                    string sDetalleRespuesta = "Detalle: ";
                    string sInformacionTecnica = "Logs: ";
                    string sSQL = "SQL: ";

                    //string sCodigoDANE = "";
                    //string sEtapa = "";
                    //string PATask = "NULL";
                    //string PAIdTask = "NULL";

                    //Boolean bEventoDisponible = false;

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso...
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    //Informacion de Reconocimiento...
                    objRec.Get_InformacionReconocimiento();
                    //Informacion de Actividad Actual...
                    objRec.GetActividadEtapaActual();
                    //Consulta informacion BizAgi...
                    objRec.Reconocimiento_CargarDatosBizAgi();


                    //Script para ejecucion directa....
                    //Intanciar firma (80)....Y cerrar los demas....
                    string tmpSQL = objRec.GenerSQLInstanciaNP();
                    sSQL += tmpSQL;

                    rtRespuesta.Text += strLinea + sRespuestaCaso + "\t" + sDetalleRespuesta + "\t" + sInformacionTecnica + "\n";
                    rtSQL.Text += tmpSQL + "\n";

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void button5_Click(object sender, EventArgs e)
        {


            //int Contador = 0;
            rtRespuesta.Text = "";
            rtSQL.Text = "";


            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                tbTEjecucion.Text = "0";
                tbTPromedio.Text = "0";
                tbTEstFin.Text = "0";
                tbOK.Text = "0";
                tbError.Text = "0";

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRespuestaCaso = "Res: ";
                    string sDetalleRespuesta = "Detalle: ";
                    string sInformacionTecnica = "Logs: ";
                    string sSQL = "SQL: ";

                    //string sCodigoDANE = "";
                    //string sEtapa = "";
                    //string PATask = "NULL";
                    //string PAIdTask = "NULL";

                    //Boolean bEventoDisponible = false;

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso...
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    //Informacion de Reconocimiento...
                    objRec.Get_InformacionReconocimiento();
                    //Informacion de Actividad Actual...
                    objRec.GetActividadEtapaActual();
                    //Consulta informacion BizAgi...
                    objRec.Reconocimiento_CargarDatosBizAgi();


                    //Codigo dane
                    string sCodigoDANE = this.GenerarCodigoDane(strLineArzay[6], strLineArzay[7]);
                    string sEtapa = "80";

                    //Generar respuesta
                    string xml = objRec.GenerarXMLRespuestaPA(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], sEtapa, strLineArzay[4],
                                                                strLineArzay[5], strLineArzay[9], sCodigoDANE, strLineArzay[15],
                                                                strLineArzay[13], strLineArzay[14], strLineArzay[12], strLineArzay[8],
                                                                strLineArzay[10], strLineArzay[11]);

                    //Reliza perform Activity
                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                    string sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, 174, xml);


                    rtRespuesta.Text += strLinea + sRespBA + "\n";

                    objResT.F_MarkTimer();
                    tbTEjecucion.Text = objResT.Get_TiempoEjecucion();
                    tbTPromedio.Text = objResT.Get_TiempoPromedio();
                    tbTEstFin.Text = objResT.Get_TiempoEstimado();
                    RegProcesados.Text = objResT.Ejecutados.ToString();

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

        private void GenRESF_Click(object sender, EventArgs e)
        {
            //int Contador = 0;
            rtRespuesta.Text = "";
            rtSQL.Text = "";


            try
            {
                //Abrir el archivo de captura.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                string LineaCaptura;
                StreamReader FileCaptura = new StreamReader(this.tbExaminar.Text);

                int y = File.ReadAllLines(this.tbExaminar.Text).Length;
                RegTotal.Text = y.ToString();

                ResumenTiempo objResT = new ResumenTiempo(y);
                objResT.F_StartTimer();

                this.Refresh();

                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                    string strLinea = "";

                    string sRespuestaCaso = "Res: ";
                    string sDetalleRespuesta = "Detalle: ";
                    string sInformacionTecnica = "Logs: ";

                    string sCodigoDANE = "";
                    string sEtapa = "";
                    string PATask = "NULL";
                    string PAIdTask = "NULL";


                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        strLinea += strLineArzay[i].Trim() + "\t";
                    }

                    //Consultar Estado del Caso...
                    Reconocimiento objRec = new Reconocimiento(strLineArzay[1], Convert.ToInt32(strLineArzay[0]));
                    //Informacion de Reconocimiento...
                    objRec.Get_InformacionReconocimiento();
                    //Informacion de Actividad Actual...
                    //objRec.GetActividadEtapaActual();
                    //Consulta informacion BizAgi...
                    //objRec.Reconocimiento_CargarDatosBizAgi();

                    CapaSOABizAgi objCapaSoa = new CapaSOABizAgi();
                    string XMLSE = "<BizAgiWSParam><Entities idCase=\"" + objRec.IdCase + "\"><M_cat_Reconocimiento><IdM_RC01Reconocimiento><BSiguiente>true</BSiguiente></IdM_RC01Reconocimiento></M_cat_Reconocimiento></Entities></BizAgiWSParam>";
                    string sRespBA = objCapaSoa.ServicioSaveEntity(XMLSE);

                    sDetalleRespuesta += "SETEVENT VALIDACION FORMA MANUAL...";
                    sInformacionTecnica += sRespBA;


                    string XMLSEF = objRec.GenerarXMLRespuestaNPSEF(Convert.ToInt32(strLineArzay[0]), strLineArzay[2], sEtapa, strLineArzay[4],
                                                                strLineArzay[5], strLineArzay[9], sCodigoDANE, strLineArzay[15],
                                                                strLineArzay[13], strLineArzay[14], strLineArzay[12], strLineArzay[8],
                                                                strLineArzay[10], strLineArzay[11], strLineArzay[17]);

                    sRespBA = objCapaSoa.ServicioSaveEntity(XMLSEF);


                    sRespBA = objCapaSoa.IniciarPerformActivity("domain", "admon", objRec.IdCase, Convert.ToInt32("897"));
                    sDetalleRespuesta += "SE EJECUTO PA (" + PAIdTask + ":" + PATask + ")...";
                    sInformacionTecnica += "ResPA: " + sRespBA;
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

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Inicializa los campos de respuesta por pantalla.
                rtRespuesta.Text = "";
                rtSQL.Text = "";

                //Valida que se ingrese una ruta de archivo.
                if (this.tbExaminar.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");


                clsRespuestasLiquidadorReco objResLiqReco = new clsRespuestasLiquidadorReco(this.tbExaminar.Text, '\t');
                this.rtRespuesta.Text = objResLiqReco.EnviarRespuestas();
               
                MessageBox.Show("PROCESO TERMINADO...");
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

        private void rtRespuesta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
