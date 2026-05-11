using PAEcuasSolver.Models;
using System;
using System.Collections.Generic;

namespace PAEcuasSolver.Utils.InputHandler
{
    public class RLCQInputHandler : IInputHandler
    {
        public ProblemInput ReadInput()
        {
            var input = new ProblemInput
            {
                Type = "RLC_Q",
                Parameters = new Dictionary<string, double>()
            };

            Console.WriteLine("=== Circuito RLC (Carga q) ===");

            input.Parameters["L"] = InputHelper.LeerDouble("Inductancia (L): ");
            input.Parameters["R"] = InputHelper.LeerDouble("Resistencia (R): ");
            input.Parameters["C"] = InputHelper.LeerDouble("Capacitancia (C): ");

            Console.Write("Voltaje E(t): ");
            input.FunctionExpression = Console.ReadLine();

            input.InitialPosition = InputHelper.LeerDouble("q(0): ");
            input.InitialVelocity = InputHelper.LeerDouble("i(0): ");

            return input;
        }
    }
}