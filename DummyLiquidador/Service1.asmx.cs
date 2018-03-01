using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DummyLiquidador
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.colpensiones.gov.co/contracts/1.0/prestacioneseconomicas/ContratoSvcBe" +
            "neficios/ActivarLiquidacion", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("EstadoEjecucion", Namespace = "http://www.colpensiones.gov.co/contracts/1.0/prestacioneseconomicas")]
        public tipoEstadoEjecucion ActivarLiquidacion([System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.colpensiones.gov.co/contracts/1.0/prestacioneseconomicas")] tipoInformacionGeneralReconocimiento InformacionGeneralReconocimiento)
        {
            return null;
        }


    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoIdentificacionPersona
    {

        private string tipoIdentificacionField;

        private string numIdentificacionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tipoIdentificacion
        {
            get
            {
                return this.tipoIdentificacionField;
            }
            set
            {
                this.tipoIdentificacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numIdentificacion
        {
            get
            {
                return this.numIdentificacionField;
            }
            set
            {
                this.numIdentificacionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionBeneficiarioReconocimiento
    {

        private tipoIdentificacionPersona identificacionField;

        private tipoBanco bancoPagoField;

        private tipoSucursalBanco sucursalBancoPagoField;

        private tipoCiudad ciudadPagoBeneficiarioField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoIdentificacionPersona identificacion
        {
            get
            {
                return this.identificacionField;
            }
            set
            {
                this.identificacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoBanco bancoPago
        {
            get
            {
                return this.bancoPagoField;
            }
            set
            {
                this.bancoPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoSucursalBanco sucursalBancoPago
        {
            get
            {
                return this.sucursalBancoPagoField;
            }
            set
            {
                this.sucursalBancoPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoCiudad ciudadPagoBeneficiario
        {
            get
            {
                return this.ciudadPagoBeneficiarioField;
            }
            set
            {
                this.ciudadPagoBeneficiarioField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/comun")]
    public partial class tipoBanco
    {

        private string codigoField;

        private string nombreField;

        /// <remarks/>
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/comun")]
    public partial class tipoSucursalBanco
    {

        private string codigoField;

        private string nombreField;

        /// <remarks/>
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoCiudad
    {

        private string codigoField;

        private string nombreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionCausante
    {

        private tipoIdentificacionPersona identificacionField;

        private tipoBanco bancoPagoField;

        private tipoSucursalBanco sucursalBancoPagoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoIdentificacionPersona identificacion
        {
            get
            {
                return this.identificacionField;
            }
            set
            {
                this.identificacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoBanco bancoPago
        {
            get
            {
                return this.bancoPagoField;
            }
            set
            {
                this.bancoPagoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoSucursalBanco sucursalBancoPago
        {
            get
            {
                return this.sucursalBancoPagoField;
            }
            set
            {
                this.sucursalBancoPagoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionBasicaTramiteReconocimiento
    {

        private string identificadorTramiteField;

        private string identificadorCasoField;

        private string fechaSolicitudField;

        private string usuarioSustanciadorField;

        private string usuarioRevisorField;

        private string accionTramiteField;

        private string tipoPrestacionField;

        private string instanciaField;

        private string tipoLiquidacionField;

        private bool tiemposPublicosField;

        private bool tiemposPrivadosField;

        private string observacionField;

        private string prioridadField;

        private string nombreAccionRespuestaField;

        private tipoCiudad ciudadPagoCausanteField;

        private string procesamientoAutomaticoField;

        private string codigoEPSField;

        private string estadoTrasladoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string identificadorTramite
        {
            get
            {
                return this.identificadorTramiteField;
            }
            set
            {
                this.identificadorTramiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string identificadorCaso
        {
            get
            {
                return this.identificadorCasoField;
            }
            set
            {
                this.identificadorCasoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fechaSolicitud
        {
            get
            {
                return this.fechaSolicitudField;
            }
            set
            {
                this.fechaSolicitudField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string usuarioSustanciador
        {
            get
            {
                return this.usuarioSustanciadorField;
            }
            set
            {
                this.usuarioSustanciadorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string usuarioRevisor
        {
            get
            {
                return this.usuarioRevisorField;
            }
            set
            {
                this.usuarioRevisorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string accionTramite
        {
            get
            {
                return this.accionTramiteField;
            }
            set
            {
                this.accionTramiteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tipoPrestacion
        {
            get
            {
                return this.tipoPrestacionField;
            }
            set
            {
                this.tipoPrestacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string instancia
        {
            get
            {
                return this.instanciaField;
            }
            set
            {
                this.instanciaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tipoLiquidacion
        {
            get
            {
                return this.tipoLiquidacionField;
            }
            set
            {
                this.tipoLiquidacionField = value;
            }
        }

        /// <remarks/>
        public bool tiemposPublicos
        {
            get
            {
                return this.tiemposPublicosField;
            }
            set
            {
                this.tiemposPublicosField = value;
            }
        }

        /// <remarks/>
        public bool tiemposPrivados
        {
            get
            {
                return this.tiemposPrivadosField;
            }
            set
            {
                this.tiemposPrivadosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string observacion
        {
            get
            {
                return this.observacionField;
            }
            set
            {
                this.observacionField = value;
            }
        }

        /// <remarks/>
        public string prioridad
        {
            get
            {
                return this.prioridadField;
            }
            set
            {
                this.prioridadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombreAccionRespuesta
        {
            get
            {
                return this.nombreAccionRespuestaField;
            }
            set
            {
                this.nombreAccionRespuestaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoCiudad ciudadPagoCausante
        {
            get
            {
                return this.ciudadPagoCausanteField;
            }
            set
            {
                this.ciudadPagoCausanteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string procesamientoAutomatico
        {
            get
            {
                return this.procesamientoAutomaticoField;
            }
            set
            {
                this.procesamientoAutomaticoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigoEPS
        {
            get
            {
                return this.codigoEPSField;
            }
            set
            {
                this.codigoEPSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string estadoTraslado
        {
            get
            {
                return this.estadoTrasladoField;
            }
            set
            {
                this.estadoTrasladoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionGeneralReconocimiento
    {

        private tipoInformacionBasicaTramiteReconocimiento informacionBasicaTramiteReconocimientoField;

        private tipoInformacionCausante informacionCausanteField;

        private tipoInformacionBeneficiarioReconocimiento[] beneficiariosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionBasicaTramiteReconocimiento informacionBasicaTramiteReconocimiento
        {
            get
            {
                return this.informacionBasicaTramiteReconocimientoField;
            }
            set
            {
                this.informacionBasicaTramiteReconocimientoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionCausante informacionCausante
        {
            get
            {
                return this.informacionCausanteField;
            }
            set
            {
                this.informacionCausanteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("beneficiario")]
        public tipoInformacionBeneficiarioReconocimiento[] beneficiarios
        {
            get
            {
                return this.beneficiariosField;
            }
            set
            {
                this.beneficiariosField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/comun/errores")]
    public partial class tipoEstadoEjecucion
    {

        private string codigoField;

        private string descripcionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionFuncionarioCertificador
    {

        private tipoIdentificacionPersona identificacionField;

        private string nombreCompletoField;

        private string cargoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoIdentificacionPersona identificacion
        {
            get
            {
                return this.identificacionField;
            }
            set
            {
                this.identificacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombreCompleto
        {
            get
            {
                return this.nombreCompletoField;
            }
            set
            {
                this.nombreCompletoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string cargo
        {
            get
            {
                return this.cargoField;
            }
            set
            {
                this.cargoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionFormato
    {

        private string tipoField;

        private string numeroField;

        private string consecutivoFormatoField;

        private string fechaExpedicionCertificadoField;

        private tipoCiudad ciudadExpedicionFormatoField;

        private tipoDepartamento departamentoExpedicionFormatoField;

        private int cantidadHojasField;

        private bool cantidadHojasFieldSpecified;

        private string numeroActoAdministrativoField;

        private tipoInformacionFuncionarioCertificador funcionarioCertificadorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string consecutivoFormato
        {
            get
            {
                return this.consecutivoFormatoField;
            }
            set
            {
                this.consecutivoFormatoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fechaExpedicionCertificado
        {
            get
            {
                return this.fechaExpedicionCertificadoField;
            }
            set
            {
                this.fechaExpedicionCertificadoField = value;
            }
        }

        /// <remarks/>
        public tipoCiudad ciudadExpedicionFormato
        {
            get
            {
                return this.ciudadExpedicionFormatoField;
            }
            set
            {
                this.ciudadExpedicionFormatoField = value;
            }
        }

        /// <remarks/>
        public tipoDepartamento departamentoExpedicionFormato
        {
            get
            {
                return this.departamentoExpedicionFormatoField;
            }
            set
            {
                this.departamentoExpedicionFormatoField = value;
            }
        }

        /// <remarks/>
        public int cantidadHojas
        {
            get
            {
                return this.cantidadHojasField;
            }
            set
            {
                this.cantidadHojasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cantidadHojasSpecified
        {
            get
            {
                return this.cantidadHojasFieldSpecified;
            }
            set
            {
                this.cantidadHojasFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string numeroActoAdministrativo
        {
            get
            {
                return this.numeroActoAdministrativoField;
            }
            set
            {
                this.numeroActoAdministrativoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionFuncionarioCertificador funcionarioCertificador
        {
            get
            {
                return this.funcionarioCertificadorField;
            }
            set
            {
                this.funcionarioCertificadorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoDepartamento
    {

        private string codigoField;

        private string nombreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoFactorCalculoSalario
    {

        private string mesField;

        private tipoValor valorPrimaAntiguedadField;

        private tipoValor valorRemuneracionDominicalFestivoField;

        private tipoValor valorRemuneracionExtrasField;

        private tipoValor valorRemuneracionBonificacionField;

        private tipoValor valorSubtotalMensualField;

        /// <remarks/>
        public string mes
        {
            get
            {
                return this.mesField;
            }
            set
            {
                this.mesField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorPrimaAntiguedad
        {
            get
            {
                return this.valorPrimaAntiguedadField;
            }
            set
            {
                this.valorPrimaAntiguedadField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorRemuneracionDominicalFestivo
        {
            get
            {
                return this.valorRemuneracionDominicalFestivoField;
            }
            set
            {
                this.valorRemuneracionDominicalFestivoField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorRemuneracionExtras
        {
            get
            {
                return this.valorRemuneracionExtrasField;
            }
            set
            {
                this.valorRemuneracionExtrasField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorRemuneracionBonificacion
        {
            get
            {
                return this.valorRemuneracionBonificacionField;
            }
            set
            {
                this.valorRemuneracionBonificacionField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorSubtotalMensual
        {
            get
            {
                return this.valorSubtotalMensualField;
            }
            set
            {
                this.valorSubtotalMensualField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/comun")]
    public partial class tipoValor
    {

        private decimal valorField;

        private bool valorFieldSpecified;

        /// <remarks/>
        public decimal valor
        {
            get
            {
                return this.valorField;
            }
            set
            {
                this.valorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valorSpecified
        {
            get
            {
                return this.valorFieldSpecified;
            }
            set
            {
                this.valorFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionCalculoBase
    {

        private string fechaBaseField;

        private string indicadorAporteField;

        private string indicadorVinculacionAntFechaBaseField;

        private string totalMesesVinculacionField;

        private tipoValor subTotalMensualField;

        private tipoValor promedioSubTotalField;

        private tipoValor asignacionBasicaMensualField;

        private tipoValor valorRepresentacionField;

        private tipoValor valorPrimaTecnicaField;

        private tipoValor valorTotalAdicionalesField;

        private tipoValor valorSalarioBaseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fechaBase
        {
            get
            {
                return this.fechaBaseField;
            }
            set
            {
                this.fechaBaseField = value;
            }
        }

        /// <remarks/>
        public string indicadorAporte
        {
            get
            {
                return this.indicadorAporteField;
            }
            set
            {
                this.indicadorAporteField = value;
            }
        }

        /// <remarks/>
        public string indicadorVinculacionAntFechaBase
        {
            get
            {
                return this.indicadorVinculacionAntFechaBaseField;
            }
            set
            {
                this.indicadorVinculacionAntFechaBaseField = value;
            }
        }

        /// <remarks/>
        public string totalMesesVinculacion
        {
            get
            {
                return this.totalMesesVinculacionField;
            }
            set
            {
                this.totalMesesVinculacionField = value;
            }
        }

        /// <remarks/>
        public tipoValor subTotalMensual
        {
            get
            {
                return this.subTotalMensualField;
            }
            set
            {
                this.subTotalMensualField = value;
            }
        }

        /// <remarks/>
        public tipoValor promedioSubTotal
        {
            get
            {
                return this.promedioSubTotalField;
            }
            set
            {
                this.promedioSubTotalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoValor asignacionBasicaMensual
        {
            get
            {
                return this.asignacionBasicaMensualField;
            }
            set
            {
                this.asignacionBasicaMensualField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorRepresentacion
        {
            get
            {
                return this.valorRepresentacionField;
            }
            set
            {
                this.valorRepresentacionField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorPrimaTecnica
        {
            get
            {
                return this.valorPrimaTecnicaField;
            }
            set
            {
                this.valorPrimaTecnicaField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorTotalAdicionales
        {
            get
            {
                return this.valorTotalAdicionalesField;
            }
            set
            {
                this.valorTotalAdicionalesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoValor valorSalarioBase
        {
            get
            {
                return this.valorSalarioBaseField;
            }
            set
            {
                this.valorSalarioBaseField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionPeriodoAporte
    {

        private tipoRangoFecha rangoFechaAporteField;

        private string indicadorDescuentoSeguridadField;

        private tipoInformacionIdentificacionPersonaJuridica entidadPagoField;

        private tipoInformacionIdentificacionPersonaJuridica entidadResponsableField;

        private tipoInformacionIdentificacionPersonaJuridica informacionCajaFondoField;

        private string indicadorPeriodoACargoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoRangoFecha rangoFechaAporte
        {
            get
            {
                return this.rangoFechaAporteField;
            }
            set
            {
                this.rangoFechaAporteField = value;
            }
        }

        /// <remarks/>
        public string indicadorDescuentoSeguridad
        {
            get
            {
                return this.indicadorDescuentoSeguridadField;
            }
            set
            {
                this.indicadorDescuentoSeguridadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionIdentificacionPersonaJuridica entidadPago
        {
            get
            {
                return this.entidadPagoField;
            }
            set
            {
                this.entidadPagoField = value;
            }
        }

        /// <remarks/>
        public tipoInformacionIdentificacionPersonaJuridica entidadResponsable
        {
            get
            {
                return this.entidadResponsableField;
            }
            set
            {
                this.entidadResponsableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionIdentificacionPersonaJuridica informacionCajaFondo
        {
            get
            {
                return this.informacionCajaFondoField;
            }
            set
            {
                this.informacionCajaFondoField = value;
            }
        }

        /// <remarks/>
        public string indicadorPeriodoACargo
        {
            get
            {
                return this.indicadorPeriodoACargoField;
            }
            set
            {
                this.indicadorPeriodoACargoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/comun")]
    public partial class tipoRangoFecha
    {

        private string fechaDesdeField;

        private string fechaHastaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fechaDesde
        {
            get
            {
                return this.fechaDesdeField;
            }
            set
            {
                this.fechaDesdeField = value;
            }
        }

        /// <remarks/>
        public string fechaHasta
        {
            get
            {
                return this.fechaHastaField;
            }
            set
            {
                this.fechaHastaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionIdentificacionPersonaJuridica
    {

        private tipoNIT nitField;

        private tipoInformacionBasicaPersonaJuridica nombreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoNIT nit
        {
            get
            {
                return this.nitField;
            }
            set
            {
                this.nitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionBasicaPersonaJuridica nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoNIT
    {

        private string numeroField;

        private string digitoVerificacionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string digitoVerificacion
        {
            get
            {
                return this.digitoVerificacionField;
            }
            set
            {
                this.digitoVerificacionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionBasicaPersonaJuridica
    {

        private string razonSocialField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string razonSocial
        {
            get
            {
                return this.razonSocialField;
            }
            set
            {
                this.razonSocialField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionPeriodoVinculacion
    {

        private string tipoNovedadField;

        private tipoRangoFecha rangoFechaVinculacionField;

        private string cantidadDiasLicenciaField;

        private tipoRangoFecha fechaVinculacionField;

        private tipoInformacionBasicaPersonaJuridica nombreEmpleadorField;

        private string cargoTrabajadorField;

        private tipoRangoFecha fechaInterrupcionField;

        private int totalDiasInterrupcionField;

        private bool totalDiasInterrupcionFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tipoNovedad
        {
            get
            {
                return this.tipoNovedadField;
            }
            set
            {
                this.tipoNovedadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoRangoFecha rangoFechaVinculacion
        {
            get
            {
                return this.rangoFechaVinculacionField;
            }
            set
            {
                this.rangoFechaVinculacionField = value;
            }
        }

        /// <remarks/>
        public string cantidadDiasLicencia
        {
            get
            {
                return this.cantidadDiasLicenciaField;
            }
            set
            {
                this.cantidadDiasLicenciaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoRangoFecha fechaVinculacion
        {
            get
            {
                return this.fechaVinculacionField;
            }
            set
            {
                this.fechaVinculacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionBasicaPersonaJuridica nombreEmpleador
        {
            get
            {
                return this.nombreEmpleadorField;
            }
            set
            {
                this.nombreEmpleadorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string cargoTrabajador
        {
            get
            {
                return this.cargoTrabajadorField;
            }
            set
            {
                this.cargoTrabajadorField = value;
            }
        }

        /// <remarks/>
        public tipoRangoFecha fechaInterrupcion
        {
            get
            {
                return this.fechaInterrupcionField;
            }
            set
            {
                this.fechaInterrupcionField = value;
            }
        }

        /// <remarks/>
        public int totalDiasInterrupcion
        {
            get
            {
                return this.totalDiasInterrupcionField;
            }
            set
            {
                this.totalDiasInterrupcionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalDiasInterrupcionSpecified
        {
            get
            {
                return this.totalDiasInterrupcionFieldSpecified;
            }
            set
            {
                this.totalDiasInterrupcionFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoCorreoElectronico
    {

        private string direccionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string direccion
        {
            get
            {
                return this.direccionField;
            }
            set
            {
                this.direccionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gobiernoenlinea.gov.co/GEL-XML/1.0/schemas/Comun/Ubicacion")]
    public partial class tipoTipoTelefono
    {

        private string codTipoTelefonoRegistradoField;

        private enumNomTipoTelefono nomTipoTelefonoRegistradoField;

        private bool nomTipoTelefonoRegistradoFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codTipoTelefonoRegistrado
        {
            get
            {
                return this.codTipoTelefonoRegistradoField;
            }
            set
            {
                this.codTipoTelefonoRegistradoField = value;
            }
        }

        /// <remarks/>
        public enumNomTipoTelefono nomTipoTelefonoRegistrado
        {
            get
            {
                return this.nomTipoTelefonoRegistradoField;
            }
            set
            {
                this.nomTipoTelefonoRegistradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nomTipoTelefonoRegistradoSpecified
        {
            get
            {
                return this.nomTipoTelefonoRegistradoFieldSpecified;
            }
            set
            {
                this.nomTipoTelefonoRegistradoFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gobiernoenlinea.gov.co/GEL-XML/1.0/schemas/Comun/Ubicacion")]
    public enum enumNomTipoTelefono
    {

        /// <remarks/>
        RESIDENCIA,

        /// <remarks/>
        OFICINA,

        /// <remarks/>
        MOVIL,

        /// <remarks/>
        FAX,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gobiernoenlinea.gov.co/GEL-XML/1.0/schemas/Comun/Ubicacion")]
    public partial class tipoDatoTelefono
    {

        private tipoTipoTelefono tipoTelefonoRegistradoField;

        private string numTelefonoContactoField;

        private string indicativoPaisField;

        private string indicativoCiudadField;

        private string extensionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoTipoTelefono tipoTelefonoRegistrado
        {
            get
            {
                return this.tipoTelefonoRegistradoField;
            }
            set
            {
                this.tipoTelefonoRegistradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numTelefonoContacto
        {
            get
            {
                return this.numTelefonoContactoField;
            }
            set
            {
                this.numTelefonoContactoField = value;
            }
        }

        /// <remarks/>
        public string indicativoPais
        {
            get
            {
                return this.indicativoPaisField;
            }
            set
            {
                this.indicativoPaisField = value;
            }
        }

        /// <remarks/>
        public string indicativoCiudad
        {
            get
            {
                return this.indicativoCiudadField;
            }
            set
            {
                this.indicativoCiudadField = value;
            }
        }

        /// <remarks/>
        public string extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoLocalidad
    {

        private int codigoField;

        private bool codigoFieldSpecified;

        private string nombreField;

        /// <remarks/>
        public int codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codigoSpecified
        {
            get
            {
                return this.codigoFieldSpecified;
            }
            set
            {
                this.codigoFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoPais
    {

        private string codigoField;

        private string nombreField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionUbicacionPersona
    {

        private tipoPais paisField;

        private tipoDepartamento departamentoField;

        private tipoCiudad ciudadField;

        private tipoLocalidad localidadField;

        private string direccionField;

        private tipoDatoTelefono[] telefonosField;

        private tipoCorreoElectronico[] correosElectronicosField;

        /// <remarks/>
        public tipoPais pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoDepartamento departamento
        {
            get
            {
                return this.departamentoField;
            }
            set
            {
                this.departamentoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoCiudad ciudad
        {
            get
            {
                return this.ciudadField;
            }
            set
            {
                this.ciudadField = value;
            }
        }

        /// <remarks/>
        public tipoLocalidad localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string direccion
        {
            get
            {
                return this.direccionField;
            }
            set
            {
                this.direccionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("telefono")]
        public tipoDatoTelefono[] telefonos
        {
            get
            {
                return this.telefonosField;
            }
            set
            {
                this.telefonosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("correoElectronico")]
        public tipoCorreoElectronico[] correosElectronicos
        {
            get
            {
                return this.correosElectronicosField;
            }
            set
            {
                this.correosElectronicosField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionGeneralPersonaJuridica
    {

        private tipoInformacionIdentificacionPersonaJuridica informacionBasicaField;

        private tipoInformacionUbicacionPersona ubicacionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionIdentificacionPersonaJuridica informacionBasica
        {
            get
            {
                return this.informacionBasicaField;
            }
            set
            {
                this.informacionBasicaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionUbicacionPersona ubicacion
        {
            get
            {
                return this.ubicacionField;
            }
            set
            {
                this.ubicacionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoTiempoPublico
    {

        private tipoInformacionIdentificacionPersonaJuridica empleadorField;

        private tipoInformacionGeneralPersonaJuridica entidadCertificadoraField;

        private tipoInformacionPeriodoVinculacion[] informacionVinculacionField;

        private tipoInformacionPeriodoAporte[] informacionAportesField;

        private tipoInformacionCalculoBase informacionCalculosBaseField;

        private tipoFactorCalculoSalario[] informacionFactorSalarioField;

        private tipoInformacionFormato[] informacionFormatosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionIdentificacionPersonaJuridica empleador
        {
            get
            {
                return this.empleadorField;
            }
            set
            {
                this.empleadorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionGeneralPersonaJuridica entidadCertificadora
        {
            get
            {
                return this.entidadCertificadoraField;
            }
            set
            {
                this.entidadCertificadoraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("periodoVinculacion")]
        public tipoInformacionPeriodoVinculacion[] informacionVinculacion
        {
            get
            {
                return this.informacionVinculacionField;
            }
            set
            {
                this.informacionVinculacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("periodoAporte")]
        public tipoInformacionPeriodoAporte[] informacionAportes
        {
            get
            {
                return this.informacionAportesField;
            }
            set
            {
                this.informacionAportesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionCalculoBase informacionCalculosBase
        {
            get
            {
                return this.informacionCalculosBaseField;
            }
            set
            {
                this.informacionCalculosBaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("factorSalario")]
        public tipoFactorCalculoSalario[] informacionFactorSalario
        {
            get
            {
                return this.informacionFactorSalarioField;
            }
            set
            {
                this.informacionFactorSalarioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("formato")]
        public tipoInformacionFormato[] informacionFormatos
        {
            get
            {
                return this.informacionFormatosField;
            }
            set
            {
                this.informacionFormatosField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionResolucionPension
    {

        private string numeroField;

        private string fechaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionReconocimiento
    {

        private string fechaRadicacionField;

        private string numeroRadicacionField;

        private string riesgoRedencionAnticipadaField;

        private tipoInformacionResolucionPension resolucionField;

        private string tasaField;

        private tipoValor valorPensionField;

        private string cantidadMesadasField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string fechaRadicacion
        {
            get
            {
                return this.fechaRadicacionField;
            }
            set
            {
                this.fechaRadicacionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string numeroRadicacion
        {
            get
            {
                return this.numeroRadicacionField;
            }
            set
            {
                this.numeroRadicacionField = value;
            }
        }

        /// <remarks/>
        public string riesgoRedencionAnticipada
        {
            get
            {
                return this.riesgoRedencionAnticipadaField;
            }
            set
            {
                this.riesgoRedencionAnticipadaField = value;
            }
        }

        /// <remarks/>
        public tipoInformacionResolucionPension resolucion
        {
            get
            {
                return this.resolucionField;
            }
            set
            {
                this.resolucionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string tasa
        {
            get
            {
                return this.tasaField;
            }
            set
            {
                this.tasaField = value;
            }
        }

        /// <remarks/>
        public tipoValor valorPension
        {
            get
            {
                return this.valorPensionField;
            }
            set
            {
                this.valorPensionField = value;
            }
        }

        /// <remarks/>
        public string cantidadMesadas
        {
            get
            {
                return this.cantidadMesadasField;
            }
            set
            {
                this.cantidadMesadasField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionRegimenTransicion
    {

        private string codigoRegimenField;

        private string descripcionRegimenField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string codigoRegimen
        {
            get
            {
                return this.codigoRegimenField;
            }
            set
            {
                this.codigoRegimenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string descripcionRegimen
        {
            get
            {
                return this.descripcionRegimenField;
            }
            set
            {
                this.descripcionRegimenField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionComplementariaPersonaNatural
    {

        private string fechaNacimientoField;

        private string sexoField;

        /// <remarks/>
        public string fechaNacimiento
        {
            get
            {
                return this.fechaNacimientoField;
            }
            set
            {
                this.fechaNacimientoField = value;
            }
        }

        /// <remarks/>
        public string sexo
        {
            get
            {
                return this.sexoField;
            }
            set
            {
                this.sexoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/personas")]
    public partial class tipoInformacionBasicaPersonaNatural
    {

        private string primerNombreField;

        private string segundoNombreField;

        private string primerApellidoField;

        private string segundoApellidoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string primerNombre
        {
            get
            {
                return this.primerNombreField;
            }
            set
            {
                this.primerNombreField = value;
            }
        }

        /// <remarks/>
        public string segundoNombre
        {
            get
            {
                return this.segundoNombreField;
            }
            set
            {
                this.segundoNombreField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string primerApellido
        {
            get
            {
                return this.primerApellidoField;
            }
            set
            {
                this.primerApellidoField = value;
            }
        }

        /// <remarks/>
        public string segundoApellido
        {
            get
            {
                return this.segundoApellidoField;
            }
            set
            {
                this.segundoApellidoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionCausanteReconocimiento
    {

        private tipoInformacionBasicaPersonaNatural informacionBasicaField;

        private tipoInformacionComplementariaPersonaNatural informacionComplementariaField;

        private string fechaMuerteInvalidezField;

        private string indicadorTransicionField;

        private tipoInformacionRegimenTransicion regimenTransicionField;

        /// <remarks/>
        public tipoInformacionBasicaPersonaNatural informacionBasica
        {
            get
            {
                return this.informacionBasicaField;
            }
            set
            {
                this.informacionBasicaField = value;
            }
        }

        /// <remarks/>
        public tipoInformacionComplementariaPersonaNatural informacionComplementaria
        {
            get
            {
                return this.informacionComplementariaField;
            }
            set
            {
                this.informacionComplementariaField = value;
            }
        }

        /// <remarks/>
        public string fechaMuerteInvalidez
        {
            get
            {
                return this.fechaMuerteInvalidezField;
            }
            set
            {
                this.fechaMuerteInvalidezField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string indicadorTransicion
        {
            get
            {
                return this.indicadorTransicionField;
            }
            set
            {
                this.indicadorTransicionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionRegimenTransicion regimenTransicion
        {
            get
            {
                return this.regimenTransicionField;
            }
            set
            {
                this.regimenTransicionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionConsultaGeneralReconocimiento
    {

        private tipoInformacionCausanteReconocimiento informacionCausanteField;

        private tipoInformacionReconocimiento informacionReconocimientoField;

        private tipoTiempoPublico[] informacionTiemposPublicosField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionCausanteReconocimiento informacionCausante
        {
            get
            {
                return this.informacionCausanteField;
            }
            set
            {
                this.informacionCausanteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoInformacionReconocimiento informacionReconocimiento
        {
            get
            {
                return this.informacionReconocimientoField;
            }
            set
            {
                this.informacionReconocimientoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("informacionTiempoPublico")]
        public tipoTiempoPublico[] informacionTiemposPublicos
        {
            get
            {
                return this.informacionTiemposPublicosField;
            }
            set
            {
                this.informacionTiemposPublicosField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("WSDLToWebService", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.colpensiones.gov.co/schemas/1.0/prestacioneseconomicas")]
    public partial class tipoInformacionConsultaGeneralReconocimientoDTO
    {

        private tipoInformacionConsultaGeneralReconocimiento[] detalleField;

        private tipoEstadoEjecucion estadoEjecucionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("reconocimientos")]
        public tipoInformacionConsultaGeneralReconocimiento[] Detalle
        {
            get
            {
                return this.detalleField;
            }
            set
            {
                this.detalleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public tipoEstadoEjecucion EstadoEjecucion
        {
            get
            {
                return this.estadoEjecucionField;
            }
            set
            {
                this.estadoEjecucionField = value;
            }
        }
    }
}