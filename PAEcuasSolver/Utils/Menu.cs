using PAEcuasSolver.Models;
using PAEcuasSolver.Utils.InputHandler;

namespace PAEcuasSolver.Utils
{
    public class Menu
    {
        public ProblemInput Show()
        {
            Console.WriteLine("Seleccione tipo de problema:");
            Console.WriteLine("1. MAS");
            Console.WriteLine("2. MVA");
            Console.WriteLine("3. MVF");
            Console.WriteLine("4. Circuito (q)");
            Console.WriteLine("5. Circuito (i)");

            string opcion = Console.ReadLine();

            var handler = InputHandlerFactory.GetHandler(opcion);

            return handler.ReadInput();
        }
    }
}