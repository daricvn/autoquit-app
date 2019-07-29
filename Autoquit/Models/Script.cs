using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquit.Models
{
    public class Script
    {
        public string Name { get; set; } = "";
        public string Password { get; set; }
        public int LoopType { get; set; }
        public int? LoopCount { get; set; }
        public int? LoopTimeType { get; set; }
        public double BoundX { get; set; }
        public double BoundY { get; set; }
        public string ResolutionApp { get; set; }
        public System.ComponentModel.BindingList<ScriptItem> Scripts { get; set; } = new BindingList<ScriptItem>();
    }
}
