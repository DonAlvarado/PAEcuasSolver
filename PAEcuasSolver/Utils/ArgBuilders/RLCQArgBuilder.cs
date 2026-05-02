using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public class RLCQArgBuilder : IArgBuilder
    {
        public string BuildArgs(ProblemInput input)
        {
            double L = input.Parameters["L"];
            double R = input.Parameters["R"];
            double C = input.Parameters["C"];
            double E0 = input.Parameters["E0"];
            double w = input.Parameters["w"];

            double q0 = input.InitialPosition;
            double dq0 = input.InitialVelocity;

            return $"{L},{R},{C},{E0},{w},{q0},{dq0}";
        }
    }
}