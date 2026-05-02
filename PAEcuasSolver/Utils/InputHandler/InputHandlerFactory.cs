using PAEcuasSolver.Utils.InputHandler;

namespace PAEcuasSolver.Utils.InputHandler
{
    public static class InputHandlerFactory
    {
        public static IInputHandler GetHandler(string option)
        {
            return option switch
            {
                "1" => new MASInputHandler(),
                "2" => new MVAInputHandler(),

                // futuros:
                // "2" => new MVAInputHandler(),
                // "4" => new RLCQInputHandler(),

                _ => throw new NotImplementedException("Opción no válida")
            };
        }
    }
}