using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public class MASArgBuilder : IArgBuilder
    {
        public string BuildArgs(ProblemInput input)
        {
            double m = input.Parameters["m"];
            double k = input.Parameters["k"];
            double b = input.Parameters["b"];
            double x0 = input.InitialPosition;
            double v0 = input.InitialVelocity;

            return $"{m},{k},{b},{x0},{v0}";
        }
    }
}