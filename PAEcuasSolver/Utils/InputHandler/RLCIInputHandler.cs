using PAEcuasSolver.Models;
using System;
using System.Collections.Generic;

namespace PAEcuasSolver.Utils.InputHandler
{
    public class RLCIInputHandler : IInputHandler
    {
        public ProblemInput ReadInput()
        {
            var input = new ProblemInput
            {
                Type = "RLC_I",
                Parameters = new Dictionary<string, double>()
            };

            Console.WriteLine("=== Circuito RLC (Corriente i) ===");

            input.Parameters["L"] = InputHelper.LeerDouble("Inductancia (L): ");
            input.Parameters["R"] = InputHelper.LeerDouble("Resistencia (R): ");
            input.Parameters["C"] = InputHelper.LeerDouble("Capacitancia (C): ");

            input.Parameters["E0"] = InputHelper.LeerDouble("Voltaje (E0): ");
            input.Parameters["w"] = InputHelper.LeerDouble("Frecuencia (w): ");

            input.InitialPosition = InputHelper.LeerDouble("i(0): ");
            input.InitialVelocity = InputHelper.LeerDouble("i'(0): ");

            return input;
        }
    }
}