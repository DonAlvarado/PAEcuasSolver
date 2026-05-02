using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.ArgBuilders
{
    public static class ArgBuilderFactory
    {
        public static IArgBuilder GetBuilder(string type)
        {
            return type switch
            {
                "MVA" => new MVAArgBuilder(),
                "MAS" => new MASArgBuilder(),
                // "RLC_Q" => new RLCQArgBuilder(),

                _ => throw new NotImplementedException($"No hay ArgBuilder para {type}")
            };
        }
    }
}