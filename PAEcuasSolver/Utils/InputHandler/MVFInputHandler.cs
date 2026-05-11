using PAEcuasSolver.Models;
using System.Collections.Generic;

namespace PAEcuasSolver.Utils.InputHandler
{
    public class MVFInputHandler : IInputHandler
    {
        public ProblemInput ReadInput()
        {
            var input = new ProblemInput
            {
                Type = "MVF",
                Parameters = new Dictionary<string, double>()
            };

            Console.WriteLine("=== Movimiento Vibratorio Forzado ===");

            input.Parameters["m"] = InputHelper.LeerDouble("Masa (m): ");
            input.Parameters["k"] = InputHelper.LeerDouble("Constante del resorte (k): ");
            input.Parameters["b"] = InputHelper.LeerDouble("Amortiguamiento (b): ");

            input.Parameters["F0"] = InputHelper.LeerDouble("Fuerza externa (F0): ");
            input.Parameters["wf"] = InputHelper.LeerDouble("Frecuencia forzada (wf): ");

            input.InitialPosition = InputHelper.LeerDouble("x(0): ");
            input.InitialVelocity = InputHelper.LeerDouble("x'(0): ");

            return input;
        }
    }
}