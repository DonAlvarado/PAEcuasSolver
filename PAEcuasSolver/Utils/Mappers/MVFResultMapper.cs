using PAEcuasSolver.Models.Results;
using PAEcuasSolver.Utils.Mappers;
using System.Text.Json;

public class MVFResultMapper : IResultMapper
{
    public IResultData Map(JsonElement root)
    {
        if (!root.TryGetProperty("t", out var t) ||
            !root.TryGetProperty("x", out var x))
        {
            throw new Exception("MVF JSON inválido: faltan 't' o 'x'");
        }

        return new MVFResultData
        {
            Lambda = root.GetProperty("lambda").GetDouble(),
            Omega0 = root.GetProperty("omega0").GetDouble(),
            OmegaF = root.GetProperty("omega_f").GetDouble(),

            F0 = root.GetProperty("F0").GetDouble(),

            A = root.GetProperty("A").GetDouble(),
            B = root.GetProperty("B").GetDouble(),

            C1 = root.GetProperty("C1").GetDouble(),
            C2 = root.GetProperty("C2").GetDouble(),

            Equation = root.GetProperty("equation").GetString(),

            Time = t.EnumerateArray().Select(e => e.GetDouble()).ToList(),
            Values = x.EnumerateArray().Select(e => e.GetDouble()).ToList()
        };
    }
}