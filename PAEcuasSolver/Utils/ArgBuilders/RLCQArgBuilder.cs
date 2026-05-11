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

            double q0 = input.InitialPosition;
            double i0 = input.InitialVelocity;

            string e = input.FunctionExpression.ToString();
            return $"{L},{R},{C},\"{e}\",{q0},{i0}";
        }
    }
}