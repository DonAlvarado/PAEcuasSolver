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
                "3" => new MVFInputHandler(),
                "4" => new RLCQInputHandler(),
                "5" => new RLCIInputHandler(),

                _ => throw new NotImplementedException("Opción no válida")
            };
        }
    }
}