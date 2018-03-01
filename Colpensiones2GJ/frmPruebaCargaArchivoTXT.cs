using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Colpensiones2GJ
{
    public partial class frmPruebaCargaArchivoTXT : Form
    {
        private XmlDocument xdoc = new XmlDocument(); 

        public frmPruebaCargaArchivoTXT()
        {
            InitializeComponent();
        }

        private void btoExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.txt";
            openFileDialog1.Title = "Select a Cursor File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbRutaArchivo.Text = openFileDialog1.FileName;
            } 
        }

        private void btLeerArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir el archivo de captura.
                if (this.tbRutaArchivo.Text == null)
                    MessageBox.Show("Validacion: La ruta del archivo de carga no esvalido");

                //Boolean SepardorManualListo = false;
                string LineaCaptura;
                string sXSD = "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">   <xs:element name=\"App\">     <xs:complexType>       <xs:sequence>         <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\">           <xs:complexType>             <xs:sequence>               <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_RC01Reconocimiento\">                 <xs:complexType>                   <xs:sequence>                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SIndicadorAuto\" type=\"xs:string\" />                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SActividadActual\" type=\"xs:string\" />                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdTask\" type=\"xs:integer\" />                   </xs:sequence>                   <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />                 </xs:complexType>               </xs:element>               <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_DatosGenerales\">                 <xs:complexType>                   <xs:sequence>                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SRadNumber\" type=\"xs:string\" />                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"Oficina\">                       <xs:complexType>                         <xs:sequence>                           <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />                         </xs:sequence>                         <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />                       </xs:complexType>                     </xs:element>                     <xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdCase\" type=\"xs:integer\" />                   </xs:sequence>                   <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />                 </xs:complexType>               </xs:element>             </xs:sequence>             <xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />           </xs:complexType>         </xs:element>       </xs:sequence>     </xs:complexType>   </xs:element> </xs:schema>";
                             
                StreamWriter sw1 = new StreamWriter("E:\\LogPerformActivity.txt", false, Encoding.ASCII);
                StreamReader FileCaptura = new StreamReader(this.tbRutaArchivo.Text);
                
                while ((LineaCaptura = FileCaptura.ReadLine()) != null)
                {
                    char tmpChar = '\t';
                    char[] Separador = new char[] { tmpChar };
                    string[] strLineArzay = LineaCaptura.Split(Separador, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < strLineArzay.Length; i++)
                    {
                        rtbLecturaArchivo.Text += strLineArzay[i] + "\t";
                    }

                    CapaSOABA.EntityManagerSOASoapClient objCapaSOA = new CapaSOABA.EntityManagerSOASoapClient("EntityManagerSOASoap");

                    string sRes = objCapaSOA.getCaseDataUsingSchemaAsString(Convert.ToInt32(strLineArzay[0]), sXSD);

                    this.rtbResInforec.Text = sRes;
                           

                    xdoc.LoadXml(rtbResInforec.Text);

                    XmlNodeList NodoRC01 = xdoc.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento/IdM_RC01Reconocimiento");

                    if (NodoRC01.Count > 0)
                    {
                        foreach (XmlNode XN in NodoRC01)
                        {
                            //rtbLecturaArchivo.Text += XN["IdTask"].InnerText + "\t" + XN["SActividadActual"].InnerText;
                            rtbLecturaArchivo.Text += XN["IdTask"].InnerText;
                            //Liquidacion Automatica.
                            if (XN["IdTask"].InnerText == "4329")
                            {
                                
                                if (XN["SIndicadorAuto"] != null)
                                    if (XN["SIndicadorAuto"].InnerText == "1")
                                        rtbLecturaArchivo.Text += "\t" + "OK [Liquidacion Automatica] Todo Correcto";
                                    else
                                        rtbLecturaArchivo.Text += "\t" + "ERROR [Liquidacion Automatica] Indicador Auto en Cero";
                                else
                                    rtbLecturaArchivo.Text += "\t" + "ERROR [Liquidacion Automatica] Indicador Auto en nulo";
                            }
                            //Investigacion Automatica.
                            else if (XN["IdTask"].InnerText == "1075")
                            {
                                if (XN["SIndicadorAuto"] != null)
                                    if (XN["SIndicadorAuto"].InnerText == "1")
                                        rtbLecturaArchivo.Text += "\t" + "ERROR [Investigacion Administrativa] Indicador Auto en Uno";
                                    else
                                        rtbLecturaArchivo.Text += "\t" + "OK [Investigacion Administrativa] Todo Correcto";
                                else
                                    rtbLecturaArchivo.Text += "\t" + "ERROR [Investigacion Administrativa] Indicador Auto en nulo";
                            }
                            //Esperando Accion Liquidador
                            else if (XN["IdTask"].InnerText == "876")
                            {
                                if (XN["SIndicadorAuto"] != null)
                                    if (XN["SIndicadorAuto"].InnerText == "1")
                                        rtbLecturaArchivo.Text += "\t" + "ERROR [Esperando Accion Liq] Indicador Auto en Uno";
                                    else
                                        rtbLecturaArchivo.Text += "\t" + "OK [Esperando Accion Liq] Todo Correcto";
                                else
                                    rtbLecturaArchivo.Text += "\t" + "ERROR [Esperando Accion Liq] Indicador Auto en nulo";
                            }
                            //EN DECISION
                            else if (XN["IdTask"].InnerText == "171")
                            {
                                if (XN["SIndicadorAuto"] != null)
                                    if (XN["SIndicadorAuto"].InnerText == "1")
                                        rtbLecturaArchivo.Text += "\t" + "ERROR [En Decision] Indicador Auto en Uno";
                                    else
                                        rtbLecturaArchivo.Text += "\t" + "OK [En Decision] Todo Correcto";
                                else
                                    rtbLecturaArchivo.Text += "\t" + "ERROR [En Decision] Indicador Auto en nulo";
                            }
                            //SIN INFO
                            else
                            {
                                rtbLecturaArchivo.Text += "\t" + "SIN INFO [SIN INFO.......] ";
                            }
                        }
                    }
                    else
                    {
                        rtbLecturaArchivo.Text += "NA" + "\t" + "NA";
                    }
                    
                    
                    rtbLecturaArchivo.Text += "\n";
                    
                }
                sw1.Close();
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
    }
}
