using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public interface IArgBuilder
    {
        string BuildArgs(ProblemInput input);
    }
}