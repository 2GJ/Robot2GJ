using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    public class ResumenTiempo
    {
        //Variables Resumen
        public Int64 Ejecutados;
        public Int64 TiempoEjecucion;
        public Int64 TiempoEstimado;
        public Int64 Total;
        public DateTime InicioOperacion;
        public DateTime FinOperacion;
        
        //Variables Ultima Ejecucion
        public DateTime FechaIni;
        public DateTime FechaFin;
        public Int64 UltimaMarca;
        public TimeSpan TS;
        public Int64 Tiempo;
        public Int64 TiempoPromedio;

        //Constructor
        public ResumenTiempo(Int64 In_total)
        {
            this.TiempoEjecucion = 0;
            this.TiempoEstimado = 0;
            this.Total = In_total;
            this.InicioOperacion = DateTime.Now;
        }

        //Adiciona uno al contador de ejecutados...
        public void Set_AddOne()
        {
            this.Ejecutados += 1; 
        }

        //Inicia Cronometro.
        public void F_StartTimer()
        {
            this.FechaIni = DateTime.Now;
        }

        //Marca Tiempo Cronometro.
        public void F_MarkTimer()
        {
            this.FechaFin = DateTime.Now;
            this.TS = this.FechaFin - this.FechaIni;
            this.FechaIni = this.FechaFin;
            this.Tiempo = this.TS.Milliseconds;
            this.Ejecutados += 1;
            this.TiempoEjecucion += this.Tiempo;
            this.TiempoPromedio = this.TiempoEjecucion / this.Ejecutados;
            this.TiempoEstimado = ((this.Total - this.Ejecutados) * this.TiempoPromedio);
        }

        //Get Tiempo Ejecucion String
        public string Get_TiempoEjecucion()
        {
            return this.F_DeterminaTiempoString(this.TiempoEjecucion);
        }

        //Get Tiempo Promedio String
        public string Get_TiempoPromedio()
        {
            return this.F_DeterminaTiempoString(this.TiempoPromedio);
        }

        //Get Tiempo Estimado String
        public string Get_TiempoEstimado()
        {
            return this.F_DeterminaTiempoString(this.TiempoEstimado);
        }

        //Determina unidad de tiempo.
        private string F_DeterminaTiempoString(Int64 In_Tiempo)
        {
            string resTiempo;

            //Un segundo equivale a 1.000 milisegundos
            //Un minuto equivale a 60.000 milisegundos

            if (In_Tiempo < 1000)
                resTiempo = In_Tiempo.ToString() + " ms";
            else
                if (In_Tiempo < 60000)
                    resTiempo = (In_Tiempo / 1000).ToString() + " seg";
                else
                    resTiempo = (In_Tiempo / 60000).ToString() + " min";

            return resTiempo;
        }
    }
}
