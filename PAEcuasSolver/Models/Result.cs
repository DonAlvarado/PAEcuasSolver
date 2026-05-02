using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Models
{
    public class Result
    {
        public string Message { get; set; }

        // 👇 aquí vive el resultado específico
        public IResultData Data { get; set; }
    }
}