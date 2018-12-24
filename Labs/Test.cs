using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Test
    {
        public string Name
        {
            get;
            set;
        }

        public bool IsPassed
        {
            get;
            set;
        }

      
        public Test(string name, bool isPassed)
        {
            Name = name;
            IsPassed = isPassed;
        }

        public Test()
        {
            Name = "Default";
        }
      
        
        public override string ToString()
        {
            return $"Test: {Name}, passed {IsPassed}.";
        }
    }
}
