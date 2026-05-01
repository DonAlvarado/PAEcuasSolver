using PAEcuasSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PAEcuasSolver.Services
{
    public class MatlabService
    {
        public Result Ejecutar(string script, Dictionary<string, double> parametros)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "matlab",
                Arguments = $"-batch \"run('{script}')\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return new Result
            {
                Mensaje = output
            };
        }
    }
}
