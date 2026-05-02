using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Models
{
    public class Result
    {
        public string Message { get; set; }
        public IResultData Data { get; set; }
    }
}