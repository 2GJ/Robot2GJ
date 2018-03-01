using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Colpensiones2GJ
{
    public class DataLog
    {
        private String FilePath;
        private String FileName;
        private String FileExtension;
        private String DirectoryName;

        #region Constructores

        public DataLog(String In_FP)
        {
            this.FileName = Path.GetFileNameWithoutExtension(In_FP);
            this.DirectoryName = Path.GetDirectoryName(In_FP);
            this.FileExtension = Path.GetExtension(In_FP);
            this.FilePath = In_FP;
        }

        #endregion

        #region Operaciones

        public void CreateFile()
        {
            FileStream objFS = File.Create(this.FilePath);
            objFS.Close();
        }

        public bool ExisteFile()
        {
            return File.Exists(this.FilePath);
        }

        public void AddLine(String In_Line)
        {
            if (this.ExisteFile() == false)
                this.CreateFile();
    
            In_Line = "2GJLog " + DateTime.Now.ToString() + ":\t" + In_Line;
            StreamWriter WriteFile = File.AppendText(this.FilePath);
            WriteFile.WriteLine(In_Line);
            WriteFile.Close(); 
        }

        public void AddIdName(string In_IdStr)
        {
            this.FileName += In_IdStr;
            this.FilePath = this.DirectoryName + "\\" +this.FileName + this.FileExtension; 
        }

        #endregion
    }

    public class DataLogPantallaMasivo
    {
        private Int64 TotalRegistros;
        private Int64 TotalResgistrosProcesados;
        private Int64 TotalResgistrosProcesadosOk;
        private Int64 TotalResgistrosProcesadosOFF;

        #region Constructores

        public DataLogPantallaMasivo(Int64 In_TotalReg)
        {
            this.TotalRegistros = In_TotalReg;
        }

        #endregion

        #region Get

        public String GetLogPantallaFull()
        {
            return "-> " + this.TotalResgistrosProcesados.ToString() + " Registros ejecutados de " + this.TotalRegistros.ToString() + "." + "\n" + this.TotalResgistrosProcesadosOk.ToString() + " Ejecutados Correctamente y " + this.TotalResgistrosProcesadosOFF.ToString() + " Ejecutados Con Error.";
        }

        #endregion

        #region Operaciones

        public void AdicionarProcesadoOK()
        {
            this.TotalResgistrosProcesados += 1;
            this.TotalResgistrosProcesadosOk += 1;
        }
        public void AdicionarProcesadoOFF()
        {
            this.TotalResgistrosProcesados += 1;
            this.TotalResgistrosProcesadosOFF += 1;
        }

        #endregion
    }
}
