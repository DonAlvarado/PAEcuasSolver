using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Models
{
    public class ProblemInput
    {
        public string Type { get; set; }
        public Dictionary<string, double> Parameters { get; set; }
    }
}
