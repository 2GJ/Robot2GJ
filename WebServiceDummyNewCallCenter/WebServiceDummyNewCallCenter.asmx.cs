using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.EntityModel;

namespace WebServiceDummyNewCallCenter
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/WebServicesDummy", Name = "WebServicesDummy", Description = "Servicio Dummy")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDummyNewCallCenter : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Respuesta DummyNewCallCenter(string In_NomEvento, Int32 In_IdCase, string In_Radicado, string In_NumRadTramite,
                                            string In_NumDoc, string In_TipoDoc, string In_PN, string In_SN, string In_PA, string In_SA,
                                            string In_TelMovil, string In_Email, string In_Ciudad, string In_TelFijo, string In_Tramite,
                                            string In_SubTramite)
        {

            try
            {

                EntitiesCallCenter objEntCall = new EntitiesCallCenter();

                CallCenter objCallCenter = new CallCenter();
                objCallCenter.NombreEvento = In_NomEvento;
                objCallCenter.IdCase = Convert.ToInt16(In_IdCase);
                objCallCenter.NumRadicado = In_Radicado;
                objCallCenter.NumeroRadicadoTramite = In_NumRadTramite;
                objCallCenter.NumIdentificacion = In_NumDoc;
                objCallCenter.TipoIdentificacion = In_TipoDoc;
                objCallCenter.PrimerNombre = In_PN;
                objCallCenter.SegundoNombre = In_SN;
                objCallCenter.PrimerApellido = In_PA;
                objCallCenter.SegundoApellido = In_SA;
                objCallCenter.TelefonoFijo = In_TelFijo;
                objCallCenter.TelefonoMovil = In_TelMovil;
                objCallCenter.Email = In_Email;
                objCallCenter.Ciudad = In_Ciudad;
                objCallCenter.Tramite = In_Tramite;
                objCallCenter.SubTramite = In_SubTramite;
                objCallCenter.Estado = "01";

                objEntCall.AddToCallCenter(objCallCenter);
                objEntCall.SaveChanges();
                                               
                Respuesta objRes = new Respuesta();
                objRes.Codigo = "0";
                objRes.Descripcion = "EJECUCION CORRECTA";


                return objRes;
            }
            catch (Exception e)
            {
                Respuesta objRes = new Respuesta();
                objRes.Codigo = In_IdCase.ToString();

                objRes.Codigo = "1";
                objRes.Descripcion = e.Message;

                return objRes;
            }

        }
    }

    public class Respuesta
    {
        public string Codigo;
        public string Descripcion;
    }
}