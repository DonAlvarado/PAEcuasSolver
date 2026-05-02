using PAEcuasSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Utils.InputHandler
{
    public class MVAInputHandler : IInputHandler
    {
        public ProblemInput ReadInput()
        {
            var input = new ProblemInput
            {
                Type = "MVA",
                Parameters = new Dictionary<string, double>()
            };

            Console.WriteLine("=== Movimiento Vibratorio Amortiguado ===");

            input.Parameters["m"] = InputHelper.LeerDouble("Masa (m): ");
            input.Parameters["k"] = InputHelper.LeerDouble("Constante (k): ");
            input.Parameters["b"] = InputHelper.LeerDouble("Coeficiente de amortiguamiento (b): ");

            input.InitialPosition = InputHelper.LeerDouble("x(0): ");
            input.InitialVelocity = InputHelper.LeerDouble("x'(0): ");

            return input;
        }
    }
}
