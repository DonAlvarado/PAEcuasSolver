using System.Diagnostics;

namespace PAEcuasSolver.Services
{
    public class MatlabService
    {
        public string Execute(string script, string args)
        {
            string projectRoot = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..")
            );

            string matlabPath = Path.Combine(projectRoot, "ScriptsMatlab");

            var psi = new ProcessStartInfo
            {
                FileName = "matlab",
                Arguments = $"-batch \"cd('{matlabPath}'); {script}({args})\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine("=== MATLAB ERROR ===");
                Console.WriteLine(error);
            }

            return output + error;
        }
    }
}