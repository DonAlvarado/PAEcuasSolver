using PAEcuasSolver.Models.Results;

public class MASResultData : IResultData
{
    public double Omega { get; set; }
    public double Amplitude { get; set; }
    public double Phase { get; set; }

    public List<double> Time { get; set; }
    public List<double> Values { get; set; }
}