using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public class RLCIArgBuilder : IArgBuilder
    {
        public string BuildArgs(ProblemInput input)
        {
            double L = input.Parameters["L"];
            double R = input.Parameters["R"];
            double C = input.Parameters["C"];
            double E0 = input.Parameters["E0"];
            double w = input.Parameters["w"];

            double i0 = input.InitialPosition;
            double di0 = input.InitialVelocity;

            return $"{L},{R},{C},{E0},{w},{i0},{di0}";
        }
    }
}