using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class Entidad
    {
        public string NombreEntidad;
        public string ColName;
        public string Filtro;
        public string IdCol;
        public List<DatosEntidad> lstDatosEntidad { get; set; }

        public Entidad(string In_NomEntidad, string In_ColName ,string In_Filtro, string In_ColId)
        {
            this.NombreEntidad = In_NomEntidad;
            this.ColName = In_ColName;
            this.Filtro = In_Filtro;
            this.IdCol = In_ColId;
            lstDatosEntidad = new List<DatosEntidad>();
        }

        public void GetListEntidad()
        {
            CapaSOABizAgi objCapaSOA = new CapaSOABizAgi();

            string XML = "";

            //<![CDATA[IdP_Ciudad = " + this.IdMunicipio + " AND BAplicaPagRecAuto = 1]]>
            XML += "<BizAgiWSParam><EntityData><EntityName>";
            XML += this.NombreEntidad;
            XML += "</EntityName><Filters>";
            XML += this.Filtro;
            XML += "</Filters></EntityData></BizAgiWSParam>";

            string Res = objCapaSOA.ServicioGetEntity(XML);

            XmlDocument xmlEntidad = new XmlDocument();
            xmlEntidad.LoadXml(Res);

            XmlNodeList NodoItems = xmlEntidad.SelectNodes("/BizAgiWSResponse/Entities/" + this.NombreEntidad);

            if (NodoItems.Count > 0)
            {
                foreach (XmlNode tmpNodoItem in NodoItems)
                {
                    DatosEntidad objItemEnt = new DatosEntidad();
                    objItemEnt.IdDatoEntidad = Convert.ToInt32(tmpNodoItem.Attributes.GetNamedItem("key").InnerText);
                    XmlNodeList NodoColsItem = tmpNodoItem.ChildNodes;

                    foreach (XmlNode tmpColItem in NodoColsItem)
                    {
                        if (this.ColName == tmpColItem.Name)
                        {
                            objItemEnt.Descripcion = tmpColItem.InnerText;
                        }
                        //else if (this.IdCol == tmpColItem.Name)
                        //{
                         //   objItemEnt.IdDatoEntidad = Convert.ToInt32(tmpColItem.InnerText);
                        //}
                    }

                    this.lstDatosEntidad.Add(objItemEnt);
                }
            }
        }



    }
}
