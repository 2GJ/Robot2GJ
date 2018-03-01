using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    public class clsCasoBA
    {
        #region Atributos

        private Int64 IdCase;
        private String RadNumber;
        private List<clsAsincronaBA> Asincronas { get; set; } 

        #endregion

        #region Constructores

        public clsCasoBA(Int64 In_IdCase)
        {
            this.IdCase = In_IdCase;
            this.Asincronas = new List<clsAsincronaBA>();
        }

        public clsCasoBA(Int64 In_IdCase, String In_Rad,  clsAsincronaBA In_Asincrona)
        {
            this.IdCase = In_IdCase;
            this.RadNumber = In_Rad;
            this.Asincronas = new List<clsAsincronaBA>();
            this.AddAsincrona(In_Asincrona);
        }

        #endregion

        #region Operaciones

        public void ReintentoAsincronas()
        {
            foreach (clsAsincronaBA Asic in this.Asincronas)
            {
                Asic.ReintentarAsincrona(this.IdCase);
            }
        }

        public void ReintentoAsincrona(Int32 In_IdTask)
        {
            foreach (clsAsincronaBA Asic in this.Asincronas)
            {
                if (Asic.GetIdAsincrona() == In_IdTask)
                {
                    Asic.ReintentarAsincrona(this.IdCase);
                }
            }
        }

        public bool GetResultadoReintento(Int32 In_IdTask)
        {
            foreach (clsAsincronaBA Asic in this.Asincronas)
            {
                if (Asic.GetIdAsincrona() == In_IdTask)
                {
                    if (Asic.Reintento.GetRespuesta() == "EJECUCION CORRECTA...")
                        return true;
                }
            }

            return false;
        }

        public String GetResultadoReintentoDescripcion(Int32 In_IdTask)
        {
            foreach (clsAsincronaBA Asic in this.Asincronas)
            {
                if (Asic.GetIdAsincrona() == In_IdTask)
                {
                    return Asic.Reintento.GetRespuesta();
                }
            }

            return "NO SE TIENE INFPORMACION DE ASINCRONA";
        }

        public String GetResultadoReintentoDetails(Int32 In_IdTask)
        {
            foreach (clsAsincronaBA Asic in this.Asincronas)
            {
                if (Asic.GetIdAsincrona() == In_IdTask)
                {
                    return Asic.Reintento.GetRespuestaDetails();
                }
            }

            return "NO SE TIENE INFPORMACION DE ASINCRONA";
        }

        public void AddAsincrona(clsAsincronaBA In_Asincrona)
        {
            this.Asincronas.Add(In_Asincrona);
        }

        #endregion
    }
}
