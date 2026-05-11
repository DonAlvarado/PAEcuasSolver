using PAEcuasSolver.Models;
using PAEcuasSolver.Utils.ArgBuilders;

public class MVFArgBuilder : IArgBuilder
{
    public string BuildArgs(ProblemInput input)
    {
        return string.Join(",",
            input.Parameters["m"],
            input.Parameters["k"],
            input.Parameters["b"],
            input.Parameters["F0"],
            input.Parameters["wf"],
            input.InitialPosition,
            input.InitialVelocity
        );
    }
}