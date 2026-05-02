using System.Linq;
using System.Text.Json;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Utils.Mappers
{
    public class MVFResultMapper : IResultMapper
    {
        public IResultData Map(JsonElement root)
        {
            return new MVFResultData
            {
                Lambda = root.GetProperty("lambda").GetDouble(),
                Omega = root.GetProperty("omega").GetDouble(),

                F0 = root.GetProperty("F0").GetDouble(),
                OmegaF = root.GetProperty("omega_f").GetDouble(),

                Amplitude = root.GetProperty("A").GetDouble(),
                Phase = root.GetProperty("phi").GetDouble(),

                Equation = root.GetProperty("equation").GetString(),

                Time = root.GetProperty("t").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                Values = root.GetProperty("x").EnumerateArray().Select(e => e.GetDouble()).ToList()
            };
        }
    }
}