using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colpensiones2GJ
{
    class CasosBAValC
    {
        private LiquidadorEntities dbEntity;

        public CasosBAValC()
        {
            dbEntity = new LiquidadorEntities();
        }

        public void AddCasoBAVal(Int32 In_IdCase, string In_RadNum, Int32 In_IdCaseState, byte In_CaseClose, 
                                Int32 In_IdWorkFlow, Int32 In_IdParentCase)
        {
            //CasosBAVal objNuevoCaso = new CasosBAVal
            //{
             //   IdCase = In_IdCase,
              //  RadNumber = In_RadNum,
               // IdCaseState = In_IdCaseState,
                //CaseClose = In_CaseClose,
                //IdWorkFlow = In_IdWorkFlow,
                //IdParentCase = In_IdParentCase
            //};

            //dbEntity.AddToCasosBAVal(objNuevoCaso);
        }
    }
}
