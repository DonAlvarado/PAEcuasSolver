namespace PAEcuasSolver.Models.Results
{
    public class MASResultData : IResultData
    {
        public double Lambda { get; set; }
        public double Omega { get; set; }
        public string Tipo { get; set; }

        public double C1 { get; set; }
        public double C2 { get; set; }

        public double? R1 { get; set; }
        public double? R2 { get; set; }

        public List<double> Time { get; set; }
        public List<double> Values { get; set; }
    }
}