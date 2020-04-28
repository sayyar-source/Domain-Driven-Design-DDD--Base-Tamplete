using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
    public class BaseEntity
    {
      
        public int ID { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool IsEnable { get; set; }

    }
}
