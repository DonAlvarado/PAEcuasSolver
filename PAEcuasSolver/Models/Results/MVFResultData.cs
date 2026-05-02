using System.Collections.Generic;

namespace PAEcuasSolver.Models.Results
{
    public class MVFResultData : IResultData
    {
        public double Lambda { get; set; }
        public double Omega { get; set; }

        public double F0 { get; set; }
        public double OmegaF { get; set; }

        public double Amplitude { get; set; }
        public double Phase { get; set; }

        public string Equation { get; set; }

        public List<double> Time { get; set; }
        public List<double> Values { get; set; }
    }
}