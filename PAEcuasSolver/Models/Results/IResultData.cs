namespace PAEcuasSolver.Models.Results
{
    public interface IResultData
    {
        List<double> Time { get; set; }
        List<double> Values { get; set; }
    }
}