using PAEcuasSolver.Models.Results;

public class MVFResultData : IResultData
{
    public double Lambda { get; set; }
    public double Omega0 { get; set; }
    public double OmegaF { get; set; }

    public double F0 { get; set; }

    public double A { get; set; }
    public double B { get; set; }

    public double C1 { get; set; }
    public double C2 { get; set; }

    public string Equation { get; set; }

    public List<double> Time { get; set; }
    public List<double> Values { get; set; }
}