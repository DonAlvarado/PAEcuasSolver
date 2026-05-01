using PAEcuasSolver.Models;
using PAEcuasSolver.Services;
using PAEcuasSolver.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Controllers
{
    public class SolverController
    {
        private SolverService solverService = new SolverService();

        public void Ejecutar(ProblemInput input)
        {
            var result = solverService.Resolver(input);

            Console.WriteLine("Resultado:");
            Console.WriteLine(result.Mensaje);
        }
    }
}
