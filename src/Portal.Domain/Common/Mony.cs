using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.Common
{
   public class Mony
    {
        private Mony()
        {

        }
    
        public Mony(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
}
