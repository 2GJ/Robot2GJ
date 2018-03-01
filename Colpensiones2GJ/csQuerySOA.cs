using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    public class csQuerySOA
    {

        #region Atributos

        String UserName;
        String Domain;
        csQueryParam QueryParam;
        private List<csParameter> Parameters { get; set; }
        private String InXML;
        private String OutXML;
        private string ErrorCode;
        private String ErrorMesaje;
        private String Answer;
        
        #endregion

        #region Constructores

        public csQuerySOA(String In_Un, String In_Dom)
        {
            this.UserName = In_Un;
            this.Domain = In_Dom;
            this.Parameters = new List<csParameter>();
            this.QueryParam = new csQueryParam();
        }

        #endregion

        #region Gets

        public string Get_ErrorCode()
        {
            return this.ErrorCode;
        }

        public String Get_OutXML()
        {
            return this.OutXML;
        }

        public String Get_AnswerANDErrorMesaje()
        {
            return "Error: " + this.Answer + " - Description: " + this.ErrorMesaje;
        }

        #endregion

        #region Operaciones

        public void RunQuery()
        {
            this.GenerateXML();
            CapaSOABizAgi CapaSOA = new CapaSOABizAgi();
            CapaSOA.Servicio_QuerySOA_QueryCasesAsString(this.InXML);
            this.ErrorCode = CapaSOA.GetCodeError();

            if (this.ErrorCode != "OK")
            {
                this.Answer = CapaSOA.GetRespuesta();
                this.ErrorMesaje = CapaSOA.GetErrorMessage();
                this.OutXML = CapaSOA.GetOutXML();
            }
            else
            {
                this.Answer = CapaSOA.GetRespuesta();
                this.OutXML = CapaSOA.GetOutXML();
            }
        }

        public void GenerateXML()
        {
            this.InXML = "<BizAgiWSParam>";
            this.InXML +=   "<userName>" + this.UserName.ToString() + "</userName>";
            this.InXML +=   "<domain>" + this.Domain.ToString() + "</domain>";

            this.InXML +=   this.QueryParam.GenerateQueryParamsXML();

            this.InXML += "<Parameters>";
            foreach (var p in this.Parameters)
            {
                 p.GenerateParameterXML();
            }
            this.InXML += "</Parameters>";

            this.InXML += "</BizAgiWSParam>";
        }

        public void AddInternal(String In_Name, String In_Vl)
        {
            this.QueryParam.AddInternal(In_Name, In_Vl);
        }

        public void AddXPath(String In_Pt, Boolean In_Inc)
        {
            this.QueryParam.AddXPath(In_Pt, In_Inc);
        }

        public void AddParameter(String In_Nm, String In_Vl)
        {
            this.Parameters.Add(new csParameter(In_Nm, In_Vl));
        }
        
        #endregion

    }

    public class csQueryParam
    {
        #region Atributos

        private List<csInternal> Internals { get; set; }
        private List<csXPath> XPaths { get; set; }

        #endregion

        #region Constructores

        public csQueryParam()
        {
            this.Internals = new List<csInternal>();
            this.XPaths = new List<csXPath>();
        }

        #endregion

        #region Operaciones

        public String GenerateQueryParamsXML()
        {
            String XML;
            XML =   "<QueryParams>";
            XML +=  "<Internals>";

            foreach (var p in this.Internals)
            {
                XML += p.GenerateInternalXML();
            }

            XML += "</Internals>";
            XML += "<XPaths>";

            foreach (var z in this.XPaths)
            {
                XML += z.GenerateCPathXML();
            }

            XML += "</XPaths>";
            XML +=  "</QueryParams>";

            return XML;
        }

        public void AddInternal(String In_Name, String In_Vl)
        {
            this.Internals.Add(new csInternal(In_Name, In_Vl));
        }

        public void AddXPath(String In_Pt, Boolean In_Inc)
        {
            this.XPaths.Add(new csXPath(In_Pt, In_Inc));
        }

        #endregion
    }

    public class csInternal
    {
        #region Atributos

        String Name;
        String Value;

        #endregion

        #region Constructores

        public csInternal(String In_Name, String In_Vl)
        {
            this.Name = In_Name;
            this.Value = In_Vl;
        }

        #endregion

        #region Operaciones

        public String GenerateInternalXML()
        {
            return "<Internal Name=\"" + this.Name.ToString() + "\">" + this.Value.ToString() + "</Internal>";
        }

        #endregion
    }

    public class csXPath
    {
        #region Atributos

        String Path;
        Boolean Include;

        #endregion

        #region Constructores

        public csXPath(String In_Pt, Boolean In_Inc)
        {
            this.Path = In_Pt;
            this.Include = In_Inc;
        }

        #endregion

        #region Geters

        public string GetIncludeByString()
        {
            if (this.Include == true)
                return "true";
            else
                return "false";
        }

        #endregion

        #region Operaciones

        public String GenerateCPathXML()
        {
            return "<XPath Path=\"" + this.Path.ToString() + " Include=\"" + this.GetIncludeByString() + "\"></XPath>";
        }

        #endregion
    }

    public class csParameter
    {
        #region Atributos

        private String Name;
        private String Value;

        #endregion

        #region Constructores

        public csParameter(String In_Nm, String In_Vl)
        {
            this.Name = In_Nm;
            this.Value = In_Vl;
        }

        #endregion

        #region Operaciones

        public String GenerateParameterXML()
        {
            return "<Parameter Name=\"" + this.Name.ToString() + "\">" + this.Value.ToString() + "</Parameter>";
        }

        #endregion
    }
}


//Ejemplo de Estructura Final.
//<BizAgiWSParam>
//    <userName>admon</userName>
//    <domain>domain</domain>
//    <QueryParams>
//        <Internals>
//            <Internal Name="RADNUMBER" >2015_101</Internal>
//            <Internal Name="IDWFCLASS" >17</Internal> <!--Envío comunicación externa-->
//        </Internals>
//        <XPaths>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.IdEstadoEnvio.SCodigoCurrier" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.IdEstadoEnvio.SEstado" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.IdEstadoEnvio.SEstadoRecepcion" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.IdEstadoEnvio.BSalida" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.IdEstadoEnvio.SCodigo" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.SNumeroGuia" Include="true"></XPath>
//            <XPath Path="M_Cat_Correspondencia.IdM_ECE_EnvioCorresponde.SGuiaLink" Include="true"></XPath>
//        </XPaths>
//    </QueryParams>
//    <Parameters>
//        <Parameter Name="idQueryForm">91</Parameter>
//        <Parameter Name="pag">1</Parameter>
//        <Parameter Name="PageSize">10</Parameter>
//        <Parameter Name="Culture">es-ES</Parameter>
//    </Parameters>
//</BizAgiWSParam>
