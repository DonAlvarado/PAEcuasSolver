using System.Text.Json;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Utils.Mappers
{
    public class MASResultMapper : IResultMapper
    {
        public IResultData Map(JsonElement root)
        {
            return new MASResultData
            {
                Lambda = root.GetProperty("lambda").GetDouble(),
                Omega = root.GetProperty("omega").GetDouble(),
                Tipo = root.GetProperty("tipo").GetString(),

                C1 = root.GetProperty("C1").GetDouble(),
                C2 = root.GetProperty("C2").GetDouble(),

                R1 = root.TryGetProperty("r1", out var r1) ? r1.GetDouble() : null,
                R2 = root.TryGetProperty("r2", out var r2) ? r2.GetDouble() : null,

                Time = root.GetProperty("t").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                Values = root.GetProperty("x").EnumerateArray().Select(e => e.GetDouble()).ToList()
            };
        }
    }
}