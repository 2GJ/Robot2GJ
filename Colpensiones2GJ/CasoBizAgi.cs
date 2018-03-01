using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Colpensiones2GJ
{
    public class CasoBizAgi
    {
        public Int64 IdCase;
        public string RadNumber;
        public DateTime CreationDate;
        public DateTime SolutionDate;
        public Int32 IdCaseState;
        public Boolean CaseClosed;

        
        //Candidatos una nuva clase WFCLASS
        private string ProcesDisplayName;
        private Int16 IdWFClass; 

        
        public List<WorkItem> CurrentWorkItems { set; get; }

        //Costructor...
        public CasoBizAgi()
        {
            //this.TaskON = new List<ActividadesBizAgi>();
            this.CurrentWorkItems = new List<WorkItem>();
        }

        //Buscar la Instancia de una actividad por id (True/False)
        public Boolean BuscarIdTask(Int64 In_IdTask)
        {
            Boolean bRespuesta = false;

            foreach (WorkItem tmpWI in this.CurrentWorkItems)
            {
                if (tmpWI.Task.IdTask == In_IdTask)
                    bRespuesta = true;
            }

            return bRespuesta;
        }

        //Buscar la Instancia de una actividad por name (true/false)
        public Boolean BuscarNameTask(String In_NameTask)
        {
            Boolean bRespuesta = false;

            foreach (WorkItem tmpWI in this.CurrentWorkItems)
            {
                if (tmpWI.Task.TaskName == In_NameTask)
                    bRespuesta = true;
            }

            return bRespuesta;
        }

        //Buscar el IdWorkItem por nombre de actividad..
        public Int64 BuscarIdWorkItemPorNameTask(String In_NameTask)
        {
            Int64 Respuesta = 0;

            foreach (WorkItem tmpWI in this.CurrentWorkItems)
            {
                if (tmpWI.Task.TaskName == In_NameTask)
                    Respuesta = tmpWI.IdWorkItem;
            }

            return Respuesta;
        }

        public String LogIdWorkItem()
        {
            String Respuesta = "";

            foreach (WorkItem tmpWI in this.CurrentWorkItems)
            {
                Respuesta += tmpWI.Task.IdTask.ToString() + "-" + tmpWI.Task.TaskName.ToString() + ";";
            }

            return Respuesta;
        }

        //Carga XML Respuesta GetCaseAsString a Objeto CasoBizAgi de un solo UN caso...
        public void CargaXMLGetCaseAsString(string In_XML)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(In_XML);

            //Nodo Process...
            XmlNodeList NodoProcesses = xmlDoc.SelectNodes("/processes");


            //solo camptura un caso....
            if (NodoProcesses.Count > 0)
            {
                foreach (XmlNode tmpNodeHijProcesses in NodoProcesses)
                {
                    string Atrib = tmpNodeHijProcesses.Name;

                    switch (Atrib)
                    {
                        case "processes":
                            this.CargaXMLNodoPorcesses(tmpNodeHijProcesses);
                            break;
                    }
                }
            }
        }

        //Carga XML de NodoProcesses...
        public void CargaXMLNodoPorcesses(XmlNode In_NodoProcesses)
        {
            XmlNodeList lstNodoProcesses = In_NodoProcesses.ChildNodes;

            if (lstNodoProcesses.Count > 0)
            {
                foreach (XmlNode tmpNodoProcesses in lstNodoProcesses)
                {
                    string Atrib = tmpNodoProcesses.Name;

                    switch (Atrib)
                    {
                        case "process":
                            this.CargaXMLNodoProcess(tmpNodoProcesses);
                            break;
                    }
                }
            }
        }

        //Carga XML de NodoProcess...
        public void CargaXMLNodoProcess(XmlNode In_NodoProcess)
        {
            XmlNodeList lstNodoProcess = In_NodoProcess.ChildNodes;

            if (lstNodoProcess.Count > 0)
            {
                foreach (XmlNode tmpNodeHijProcess in lstNodoProcess)
                {
                    string Atrib = tmpNodeHijProcess.Name;

                    switch (Atrib)
                    {
                        case "processId":
                            this.IdCase = Convert.ToInt64(tmpNodeHijProcess.InnerText);
                            break;

                        case "processRadNumber":
                            this.RadNumber = tmpNodeHijProcess.InnerText;
                            break;

                        case "CurrentWorkItems":
                            this.CargaXMLNodoCurrentWorkItems(tmpNodeHijProcess);
                            break;
                    }
                }
            }
        }

        //Carga XML de CurrentWorkItems...
        public void CargaXMLNodoCurrentWorkItems(XmlNode In_CurrentWorkItmes)
        {
            XmlNodeList lstCurrentWorkItems = In_CurrentWorkItmes.ChildNodes;

            if (lstCurrentWorkItems.Count > 0)
            {
                foreach (XmlNode tmpCurrentWorkItem in lstCurrentWorkItems)
                {
                    string Atrib = tmpCurrentWorkItem.Name;

                    switch (Atrib)
                    {
                        case "workItem":
                            WorkItem objWorkItem = new WorkItem();
                            objWorkItem.CargaXMLNodoWorkItem(tmpCurrentWorkItem);
                            this.CurrentWorkItems.Add(objWorkItem);
                            break;
                    }
                }
            }
        }
    }

    public class WorkItem
    {
        public Int64 IdWorkItem;
        public Task Task;


        //Constructor
        public WorkItem()
        {
            Task ObjTask = new Task();
            this.Task = ObjTask;
        }

        //Carga XML de WorkItem...
        public void CargaXMLNodoWorkItem(XmlNode In_WorkItem)
        {
            XmlNodeList lstWorkItem = In_WorkItem.ChildNodes;

            if (lstWorkItem.Count > 0)
            {
                foreach (XmlNode tmpWorkItem in lstWorkItem)
                {


                    string Atrib = tmpWorkItem.Name;

                    switch (Atrib)
                    {
                        case "workItemId":
                            this.IdWorkItem = Convert.ToInt64(tmpWorkItem.InnerText);
                            break;

                        case "task":
                            this.Task.CargaXMLNodoTask(tmpWorkItem);
                            break;
                    }
                }
            }
        }

    }

    public class Task
    {
        public Int64 IdTask;
        public string TaskName;

         //Carga XML de TASK...
        public void CargaXMLNodoTask(XmlNode In_Task)
        {
            XmlNodeList lstTask = In_Task.ChildNodes;

            if (lstTask.Count > 0)
            {
                foreach (XmlNode tmpTask in lstTask)
                {
                    string Atrib = tmpTask.Name;

                    switch (Atrib)
                    {
                        case "taskId":
                            this.IdTask = Convert.ToInt64(tmpTask.InnerText);
                            break;

                        case "taskName":
                            this.TaskName = tmpTask.InnerText;
                            break;
                    }
                }
            }
        }
    }
}
