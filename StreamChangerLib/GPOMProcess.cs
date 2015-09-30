using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTreeLib
{
    public class GPOMProcess
    {
        public bool Success { get; set; }

        public string Message { get; set; }


        public virtual void Run()
        {
        }

    }
}
