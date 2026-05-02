using System.Text.Json;
using PAEcuasSolver.Models.Results;
using System.Linq;

namespace PAEcuasSolver.Utils.Mappers
{
    public class MASResultMapper : IResultMapper
    {
        public IResultData Map(JsonElement root)
        {
            return new MASResultData
            {
                Omega = root.GetProperty("omega").GetDouble(),
                Amplitude = root.GetProperty("A").GetDouble(),
                Phase = root.GetProperty("phi").GetDouble(),

                Time = root.GetProperty("t")
                    .EnumerateArray()
                    .Select(e => e.GetDouble())
                    .ToList(),

                Values = root.GetProperty("x")
                    .EnumerateArray()
                    .Select(e => e.GetDouble())
                    .ToList()
            };
        }
    }
}