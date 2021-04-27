using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BASE
{
   public class AutoDateTime : IEntities
    {
        public AutoDateTime()
        {
            InsertDate = DateTime.Now.Date;
            InsertTime = DateTime.Now.TimeOfDay;
        }
        public DateTime InsertDate { get; set; }
        public TimeSpan InsertTime { get; set; }
    }
}
