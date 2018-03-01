using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    public class LogRobotto
    {
        public Int64 IdCase;
        public string RadNumber;
        public string ResumenError;
        public List<LogRobottoDetalle> DetalleLog { set; get; }


        public LogRobotto(Int64 In_IdCase, String In_RadNumber)
        {
            this.IdCase = In_IdCase;
            this.RadNumber = In_RadNumber;
            DetalleLog = new List<LogRobottoDetalle>();
        }


        public void Add_DetalleLog(string In_Accion, string In_Detalle)
        {
            this.Add_DetalleLog(In_Accion, In_Detalle);
        }
    }
}
