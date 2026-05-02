using System.Collections.Generic;

namespace PAEcuasSolver.Models.Results
{
    public class RLCIResultData : IResultData
    {
        public double Lambda { get; set; }
        public double Omega { get; set; }

        public double E0 { get; set; }
        public double W { get; set; }

        public double Amplitude { get; set; }
        public double Phase { get; set; }

        public string Equation { get; set; }

        public List<double> Time { get; set; }
        public List<double> Values { get; set; }
    }
}