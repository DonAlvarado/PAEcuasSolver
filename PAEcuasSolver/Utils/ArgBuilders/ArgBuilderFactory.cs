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
                "MVF" => new MVFArgBuilder(),
                "RLC_Q" => new RLCQArgBuilder(),
                "RLC_I" => new RLCIArgBuilder(),

                _ => throw new NotImplementedException($"No hay ArgBuilder para {type}")
            };
        }
    }
}