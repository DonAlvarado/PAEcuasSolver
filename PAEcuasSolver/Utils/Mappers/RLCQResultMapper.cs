using System.Linq;
using System.Text.Json;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Utils.Mappers
{
    public class RLCQResultMapper : IResultMapper
    {
        public IResultData Map(JsonElement root)
        {
            return new RLCQResultData
            {
                Lambda = root.GetProperty("lambda").GetDouble(),
                Omega = root.GetProperty("omega").GetDouble(),

                E0 = root.GetProperty("E0").GetDouble(),
                W = root.GetProperty("w").GetDouble(),

                Amplitude = root.GetProperty("A").GetDouble(),
                Phase = root.GetProperty("phi").GetDouble(),

                Equation = root.GetProperty("equation").GetString(),

                Time = root.GetProperty("t").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                Values = root.GetProperty("x").EnumerateArray().Select(e => e.GetDouble()).ToList()
            };
        }
    }
}