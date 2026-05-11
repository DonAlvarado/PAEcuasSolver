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
            try
            {
                var argBuilder = ArgBuilderFactory.GetBuilder(input.Type);
                string args = argBuilder.BuildArgs(input);

                string script = GetScriptName(input.Type);

                Console.WriteLine("=== SOLVER DEBUG ===");
                Console.WriteLine($"Script: {script}");
                Console.WriteLine($"Args: {args}");

                string rawOutput = matlabService.Execute(script, args);

                Console.WriteLine("=== RAW OUTPUT ===");
                Console.WriteLine(rawOutput);

                var (humanText, json) = parser.Parse(rawOutput);

                Console.WriteLine("=== HUMAN TEXT ===");
                Console.WriteLine(humanText);

                Console.WriteLine("=== JSON ===");
                Console.WriteLine(json);

                if (string.IsNullOrWhiteSpace(json))
                {
                    throw new Exception("MATLAB no devolvió JSON válido.");
                }

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var mapper = ResultMapperFactory.GetMapper(input.Type);
                var data = mapper.Map(root);

                return new Result
                {
                    Message = humanText,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("🔥 ERROR EN SOLVER SERVICE:");
                Console.WriteLine(ex.ToString());

                return new Result
                {
                    Message = "Error interno al resolver el sistema. Revisa logs.",
                    Data = null
                };
            }
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