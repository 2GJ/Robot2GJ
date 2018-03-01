using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Colpensiones2GJ
{
    public class clsAsincronaBA
    {
        #region Atributos

        private Int32 IdAsincrona;
        private String NombreAsincrona;
        private String MostrarNombreAsincrona;
        public CapaSOABizAgi Reintento;

        #endregion

        #region Get

        public Int32 GetIdAsincrona()
        {
            return this.IdAsincrona;
        }

        public String GetRespuestaSOA()
        {
            return this.Reintento.GetRespuesta();
        }

        #endregion

        #region Constructores

        public clsAsincronaBA(Int32 In_IdTask)
        {
            this.IdAsincrona = In_IdTask;
            this.Reintento = new CapaSOABizAgi();
        }

        #endregion

        #region Operaciones

        public void ReintentarAsincrona(Int64 Id_Case)
        {
            this.Reintento.Servicio_ReintentoAsincrona(Convert.ToInt32(Id_Case), Convert.ToInt32(this.IdAsincrona));

            if ((this.Reintento.GetRespuesta() == "891ValidationException: Las notificaciones para el subproceso son diferentes: 0_dif_0")
                && (this.IdAsincrona == 897))
            {
                

            }
        }

        #endregion
    }

    public class clsMasivoAsincronasBA
    {
        #region Atributos
        
        private String RutaDeArchivo;
        private Int32 ILineaActual;
        private String[] ArrStrLineas;
        private char Sep;
        public clsCasoBA Caso;
        public DataLog LogOk;
        public DataLog LogOFF;
        public DataLog LogDetail;
        public DataLogPantallaMasivo LogPantalla;

        #endregion

        #region Constructores

        public clsMasivoAsincronasBA(String In_RtaArchivo, char In_Separador)
        {
            this.RutaDeArchivo = In_RtaArchivo;
            this.LogOk = new DataLog(In_RtaArchivo);
            this.LogOk.AddIdName("LogOK");
            this.LogOFF = new DataLog(In_RtaArchivo);
            this.LogOFF.AddIdName("LogOFF");
            this.LogDetail = new DataLog(In_RtaArchivo);
            this.LogDetail.AddIdName("Details");
            this.ArrStrLineas = File.ReadAllLines(this.RutaDeArchivo);
            this.ILineaActual = 0;
            this.Sep = In_Separador;
            this.LogPantalla = new DataLogPantallaMasivo(this.ArrStrLineas.Length);
        }

        #endregion

        #region Get

        public String GetLineaString()
        {
            string result = string.Join(this.Sep.ToString(), this.ArrStrLineas[this.ILineaActual]);
            return result;
        }

        public String GetLogPantallaFull()
        {
            return this.LogPantalla.GetLogPantallaFull();
        }

        #endregion

        #region Operaciones

        public void EjecutarLineaAsincronaBA()
        {
            String[] arrStrArch = this.CargarLineaArchivo();
            this.Caso = new clsCasoBA(Convert.ToInt64(arrStrArch[0]), arrStrArch[1], new clsAsincronaBA(Convert.ToInt32(arrStrArch[2])));
            this.Caso.ReintentoAsincrona(Convert.ToInt32(arrStrArch[2]));

            if (this.Caso.GetResultadoReintento(Convert.ToInt32(arrStrArch[2])) == true)
            {
                this.LogPantalla.AdicionarProcesadoOK();
                this.LogOk.AddLine(this.GetLineaString() + "\t" + this.Caso.GetResultadoReintentoDescripcion(Convert.ToInt32(arrStrArch[2])));
            }
            else
            {
                this.LogPantalla.AdicionarProcesadoOFF();
                this.LogOFF.AddLine(this.GetLineaString() + "\t" + this.Caso.GetResultadoReintentoDescripcion(Convert.ToInt32(arrStrArch[2])));
                this.LogDetail.AddLine(this.Caso.GetResultadoReintentoDetails(Convert.ToInt32(arrStrArch[2])));
            }
            this.ILineaActual += 1;
        }

        private String[] CargarLineaArchivo()
        {
            return this.ArrStrLineas[this.ILineaActual].Split(new char[] { this.Sep });
        }

        public bool EjecucionCompleta()
        {
            if (this.ILineaActual == this.ArrStrLineas.Length)
                return true;
            else
                return false;
        }

        

        #endregion
    }
    
    
}
