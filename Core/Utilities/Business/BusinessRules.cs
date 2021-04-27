using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
namespace Core.Utilities.Business
{
  public  class BusinessRules
    {
      
        public static IResult Run(params IResult[] logics)
        {
            // istendiği kadar parametre geçilebilir params ile 
            foreach (var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
