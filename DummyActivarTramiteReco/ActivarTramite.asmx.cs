using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DummyActivarTramiteReco
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://localhost/WebServicesDummyActLiquidador", Name = "WebServicesDummyActLiquidador", Description = "Servicio Dummy Activar Liquidador...")]
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

        [WebMethod]
        public RespuestaServicio ServicioActivarTramite (Int64 In_idCase, string In_RadNumber)
        {
            RespuestaServicio objResServicio = new RespuestaServicio();

            return objResServicio;
        }

        public class RespuestaServicio
        {

        }
    }
}