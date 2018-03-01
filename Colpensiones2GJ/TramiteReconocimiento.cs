using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class TramiteReconocimiento
    {
        public Int32 IdCaseTR;
        public string RadNumberTR;
        public Tramite MTramite;
               
        public TramiteReconocimiento(string In_RadNumber, Int32 In_IdCaseTR)
        {
            this.RadNumberTR = In_RadNumber;
            this.IdCaseTR = In_IdCaseTR;
            Tramite ObjTramite = new Tramite();
            this.MTramite = ObjTramite;
        }


        //Get Informacion General Tramite Reconocimiento
        public void Get_InfoGeneralTR()
        {
            string XSD = this.Get_XSD_InfoGeneralTR();

            CapaSOABizAgi ObjCapaSOABA = new CapaSOABizAgi();
            string ResCapaSOA = ObjCapaSOABA.ServicioGetCaseDataSchema(this.IdCaseTR, XSD);

            //Consulta Informacion del Tramite.
            XmlDocument XDocTramite = new XmlDocument();
            XDocTramite.LoadXml(ResCapaSOA);

            XmlNodeList NodoCatReconocimiento = XDocTramite.SelectNodes("/BizAgiWSResponse/App/M_cat_Reconocimiento");
            
            if (NodoCatReconocimiento.Count > 0)
            {
                foreach (XmlNode tmpXML in NodoCatReconocimiento)
                {
                    XmlNodeList ChildsCatReco = tmpXML.ChildNodes;
                                                            
                    foreach (XmlNode tmpChieldCatReco in ChildsCatReco)
                    {   
                        string Atributo = tmpChieldCatReco.Name;

                        switch (Atributo)
                        {
                            case "M_Tramite":
                                this.MTramite.IdM_Tramite = Convert.ToInt32(tmpChieldCatReco.Attributes.GetNamedItem("key").InnerText);
                                this.MTramite.GetInfoTramite(tmpChieldCatReco.ChildNodes);
                                break;
                        }
                    }                    
                }
            }
        }


        //XSD Informacion General Tramite Reconocimiento
        private string Get_XSD_InfoGeneralTR()
        {
            string XSDInfoGeneralTR = "";
            
            XSDInfoGeneralTR += "<xs:schema attributeFormDefault=\"qualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">";
            XSDInfoGeneralTR +=     "<xs:element name=\"App\">";
            XSDInfoGeneralTR +=         "<xs:complexType>";
            XSDInfoGeneralTR +=             "<xs:sequence>";
            XSDInfoGeneralTR +=                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_cat_Reconocimiento\">";
            XSDInfoGeneralTR +=                     "<xs:complexType>";
            XSDInfoGeneralTR +=                         "<xs:sequence>";
            XSDInfoGeneralTR +=                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"M_Tramite\">";
            XSDInfoGeneralTR +=                                 "<xs:complexType>";
            XSDInfoGeneralTR +=                                     "<xs:sequence>";
            XSDInfoGeneralTR +=                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramitePQRS\">";
            XSDInfoGeneralTR +=                                             "<xs:complexType>";
            XSDInfoGeneralTR +=                                                 "<xs:sequence>";
            XSDInfoGeneralTR +=                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_Estado\">";
            XSDInfoGeneralTR +=                                                         "<xs:complexType>";
            XSDInfoGeneralTR +=                                                             "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                             "</xs:sequence>";
            XSDInfoGeneralTR +=                                                             "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                         "</xs:complexType>";
            XSDInfoGeneralTR +=                                                        "</xs:element>";
            XSDInfoGeneralTR +=                                                     "</xs:sequence>";
            XSDInfoGeneralTR +=                                                     "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                 "</xs:complexType>";
            XSDInfoGeneralTR +=                                                 "</xs:element>";
            XSDInfoGeneralTR +=                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_SubtipoTramite\">";
            XSDInfoGeneralTR +=                                                     "<xs:complexType>";
            XSDInfoGeneralTR +=                                                         "<xs:sequence>";
            XSDInfoGeneralTR +=                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BRequiereEspera\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpServices\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BFamiliar\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                             "</xs:sequence>";
            XSDInfoGeneralTR +=                                                             "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                         "</xs:complexType>";
            XSDInfoGeneralTR +=                                                     "</xs:element>";
            XSDInfoGeneralTR +=                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesProcesoTram\">";
            XSDInfoGeneralTR +=                                                         "<xs:complexType>";
            XSDInfoGeneralTR +=                                                             "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BCotizColpC1\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTieneTiemposPublicosC2\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BCotizColpC2\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTieneTiemposPublicos\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                             "</xs:sequence>";
            XSDInfoGeneralTR +=                                                             "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                         "</xs:complexType>";
            XSDInfoGeneralTR +=                                                     "</xs:element>";
            XSDInfoGeneralTR +=                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdM_VariablesTramiteReco\">";
            XSDInfoGeneralTR +=                                                         "<xs:complexType>";
            XSDInfoGeneralTR +=                                                             "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                 "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_EstadoRespBOTmpPub\">";
            XSDInfoGeneralTR +=                                                                     "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                         "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodColpensiones\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                     "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                     "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                 "</xs:complexType>";
            XSDInfoGeneralTR +=                                                             "</xs:element>";
            XSDInfoGeneralTR +=                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEsperarInfoTiempoPub\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_DetallevalidacionNube\">";
            XSDInfoGeneralTR +=                                                                 "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                     "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_DetalleValidacionNube\">";
            XSDInfoGeneralTR +=                                                                         "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                             "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"IdP_TipoValidacion\">";
            XSDInfoGeneralTR +=                                                                                 "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                                     "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SNombre\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SCodigo\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                                     "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                                     "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                                 "</xs:complexType>";
            XSDInfoGeneralTR +=                                                                             "</xs:element>";
            XSDInfoGeneralTR +=                                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"SDetalleValidacion\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEsPrevalidacion\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                             "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                         "</xs:complexType>";
            XSDInfoGeneralTR +=                                                                     "</xs:element>";
            XSDInfoGeneralTR +=                                                                     "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                 "</xs:complexType>";
            XSDInfoGeneralTR +=                                                             "</xs:element>";
            XSDInfoGeneralTR +=                                                             "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_RC08_ConfirmTiemposPubs\">";
            XSDInfoGeneralTR +=                                                                 "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                     "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                         "<xs:element minOccurs=\"0\" maxOccurs=\"unbounded\" name=\"M_RC08_ConfirmTiemposPub\">";
            XSDInfoGeneralTR +=                                                                             "<xs:complexType>";
            XSDInfoGeneralTR +=                                                                                 "<xs:sequence>";
            XSDInfoGeneralTR +=                                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiempoVencRecibirCertif\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BTiempoVencRecibirAcuse\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BRecibidaCertificacionEx\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BSilencioAdministrativo\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                                     "<xs:element minOccurs=\"0\" maxOccurs=\"1\" name=\"BEnviadaSolCorresExt\" type=\"xs:boolean\" />";
            XSDInfoGeneralTR +=                                                                                 "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                             "</xs:complexType>";
            XSDInfoGeneralTR +=                                                                         "</xs:element>";
            XSDInfoGeneralTR +=                                                                     "</xs:sequence>";
            XSDInfoGeneralTR +=                                                                 "</xs:complexType>";
            XSDInfoGeneralTR +=                                                             "</xs:element>";
            XSDInfoGeneralTR +=                                                         "</xs:sequence>";
            XSDInfoGeneralTR +=                                                         "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                                     "</xs:complexType>";
            XSDInfoGeneralTR +=                                                 "</xs:element>";
            XSDInfoGeneralTR +=                                             "</xs:sequence>";
            XSDInfoGeneralTR +=                                             "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                                         "</xs:complexType>";
            XSDInfoGeneralTR +=                                     "</xs:element>";
            XSDInfoGeneralTR +=                                 "</xs:sequence>";
            XSDInfoGeneralTR +=                                 "<xs:attribute form=\"unqualified\" name=\"entityName\" type=\"xs:string\" />";
            XSDInfoGeneralTR +=                             "</xs:complexType>";
            XSDInfoGeneralTR +=                         "</xs:element>";
            XSDInfoGeneralTR +=                     "</xs:sequence>";
            XSDInfoGeneralTR +=                 "</xs:complexType>";
            XSDInfoGeneralTR +=             "</xs:element>";
            XSDInfoGeneralTR +=         "</xs:schema>";

            return XSDInfoGeneralTR;
        }
    }
}
