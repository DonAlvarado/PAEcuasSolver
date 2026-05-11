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

            double i0 = input.InitialPosition;
            double di0 = input.InitialVelocity;

            string e = input.FunctionExpression.ToString();
            return $"{L},{R},{C},\"{e}\",{i0},{di0}";
        }
    }
}