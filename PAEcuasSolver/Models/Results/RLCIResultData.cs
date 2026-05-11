using System.Collections.Generic;

namespace PAEcuasSolver.Models.Results
{
    public class RLCIResultData : IResultData
    {
        public double Lambda { get; set; }
        public double Omega { get; set; }

        public string VoltageExpression { get; set; }

        public double C1 { get; set; }
        public double C2 { get; set; }

        public string Equation { get; set; }

        public List<double> Time { get; set; }
        public List<double> Values { get; set; }
    }
}