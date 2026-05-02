using PAEcuasSolver.Models;
using PAEcuasSolver.Models.Results;
using PAEcuasSolver.Utils;
using PAEcuasSolver.Utils.ArgBuilders;
using PAEcuasSolver.Utils.Mappers;
using System.Text.Json;

namespace PAEcuasSolver.Services
{
    public class SolverService
    {
        private readonly MatlabService matlabService = new();
        private readonly MatlabOutputParser parser = new();

        public Result Resolver(ProblemInput input)
        {
            var argBuilder = ArgBuilderFactory.GetBuilder(input.Type);

            string args = argBuilder.BuildArgs(input);

            string script = GetScriptName(input.Type);

            string rawOutput = matlabService.Execute(script, args);

            var (humanText, json) = parser.Parse(rawOutput);


            /** 
             * 
                                            USAR ESTO EN CASO DE BUG DE LO QUE SUELTA MATLAB:
                                            Console.WriteLine("=== RAW OUTPUT ===");
                                            Console.WriteLine(rawOutput);
                                            Console.WriteLine("=== JSON EXTRAIDO ===");
                                            Console.WriteLine(json);
            **/


            IResultData? data = null;

            if (!string.IsNullOrWhiteSpace(json))
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var mapper = ResultMapperFactory.GetMapper(input.Type);

                data = mapper.Map(root);
            }

            return new Result
            {
                Message = humanText,
                Data = data
            };
        }

        private string GetScriptName(string type)
        {
            return type switch
            {
                "MAS" => "mas",
                "MVA" => "mva",
                "MVF" => "mvf",
                "RLC_Q" => "rlc_q",
                "RLC_I" => "rlc_i",

                _ => throw new NotImplementedException($"No hay script para {type}")
            };
        }
    }
}