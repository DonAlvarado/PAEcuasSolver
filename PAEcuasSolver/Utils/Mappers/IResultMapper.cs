using System.Text.Json;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Utils.Mappers
{
    public interface IResultMapper
    {
        IResultData Map(JsonElement json);
    }
}