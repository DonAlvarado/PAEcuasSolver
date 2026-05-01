using PAEcuasSolver.Models;
using PAEcuasSolver.Services;
using PAEcuasSolver.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Services
{
    public class SolverService
    {
        private MatlabService matlabService = new MatlabService();

        public Result Resolver(ProblemInput Input)
        {
            switch (Input.Type)
            {
                case "MAS":
                    return matlabService.Ejecutar("mas.m", Input.Parameters);

                case "MVA":
                    return matlabService.Ejecutar("mva.m", Input.Parameters);

                case "MVF":
                    return matlabService.Ejecutar("mvf.m", Input.Parameters);

                case "RLC_Q":
                    return matlabService.Ejecutar("circuito_q.m", Input.Parameters);

                case "RLC_I":
                    return matlabService.Ejecutar("circuito_i.m", Input.Parameters);

                default:
                    return new Result { Mensaje = "Tipo no soportado" };
            }
        }

        internal object Result(ProblemInput input)
        {
            throw new NotImplementedException();
        }
    }
}
