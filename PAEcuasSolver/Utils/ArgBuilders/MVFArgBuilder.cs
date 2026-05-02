using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public class MVFArgBuilder : IArgBuilder
    {
        public string BuildArgs(ProblemInput input)
        {
            double m = input.Parameters["m"];
            double k = input.Parameters["k"];
            double b = input.Parameters["b"];
            double F0 = input.Parameters["F0"];
            double wf = input.Parameters["wf"];

            double x0 = input.InitialPosition;
            double v0 = input.InitialVelocity;

            return $"{m},{k},{b},{F0},{wf},{x0},{v0}";
        }
    }
}