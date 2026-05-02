using System;
using System.Text;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Utils.Formatters
{
    public class UnifiedResultFormatter : IResultFormatter
    {
        public string Format(IResultData data)
        {
            return data switch
            {
                MASResultData mas => FormatMAS(mas),
                MVAResultData mva => FormatMVA(mva),
                MVFResultData mvf => FormatMVF(mvf),
                RLCQResultData rlc => FormatRLCQ(rlc),
                RLCIResultData rlc => FormatRLCI(rlc),

                _ => "Tipo de resultado no soportado."
            };
        }

        // ================= MAS =================
        private string FormatMAS(MASResultData mas)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Movimiento Armónico Simple (MAS) ===\n");

            sb.AppendLine($"omega = {mas.Omega:F4}");
            sb.AppendLine($"A     = {mas.Amplitude:F4}");
            sb.AppendLine($"phi   = {mas.Phase:F4}\n");

            sb.AppendLine($"x(t) = {BuildMASEquation(mas)}");

            return sb.ToString();
        }

        private string BuildMASEquation(MASResultData mas)
        {
            return $"{mas.Amplitude:F4}*cos({mas.Omega:F4}t - {mas.Phase:F4})";
        }

        // ================= MVA =================
        private string FormatMVA(MVAResultData mva)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Movimiento Vibratorio Amortiguado ===\n");

            sb.AppendLine($"lambda = {mva.Lambda:F4}");
            sb.AppendLine($"omega  = {mva.Omega:F4}");
            sb.AppendLine($"Tipo   = {mva.Tipo}\n");

            sb.AppendLine("Constantes:");
            sb.AppendLine($"C1 = {mva.C1:F4}");
            sb.AppendLine($"C2 = {mva.C2:F4}\n");

            sb.AppendLine($"x(t) = {BuildMVAEquation(mva)}");

            return sb.ToString();
        }

        private string BuildMVAEquation(MVAResultData mva)
        {
            // SUBAMORTIGUADO
            if (mva.Tipo != null && mva.Tipo.Contains("Sub"))
            {
                double wd = Math.Sqrt(mva.Omega * mva.Omega - mva.Lambda * mva.Lambda);

                return $"e^(-{mva.Lambda:F4}t)[{mva.C1:F4}*cos({wd:F4}t) + {mva.C2:F4}*sin({wd:F4}t)]";
            }

            // CRÍTICAMENTE AMORTIGUADO
            if (mva.Tipo != null && mva.Tipo.Contains("Crit"))
            {
                return $"({mva.C1:F4} + {mva.C2:F4}t)e^(-{mva.Lambda:F4}t)";
            }

            // SOBREAMORTIGUADO
            if (mva.R1.HasValue && mva.R2.HasValue)
            {
                return $"{mva.C1:F4}*e^({mva.R1:F4}t) + {mva.C2:F4}*e^({mva.R2:F4}t)";
            }

            return "Ecuación no disponible";
        }

        private string FormatMVF(MVFResultData mvf)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Movimiento Vibratorio Forzado ===\n");

            sb.AppendLine($"lambda = {mvf.Lambda:F4}");
            sb.AppendLine($"omega  = {mvf.Omega:F4}");
            sb.AppendLine($"F0     = {mvf.F0:F4}");
            sb.AppendLine($"wf     = {mvf.OmegaF:F4}\n");

            sb.AppendLine($"A   = {mvf.Amplitude:F4}");
            sb.AppendLine($"phi = {mvf.Phase:F4}\n");

            sb.AppendLine($"{mvf.Equation}");

            return sb.ToString();
        }

        // ================= RLCQ =================
        private string FormatRLCQ(RLCQResultData rlc)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Circuito RLC (Carga q) ===\n");

            sb.AppendLine($"lambda = {rlc.Lambda:F4}");
            sb.AppendLine($"omega  = {rlc.Omega:F4}");
            sb.AppendLine($"E0     = {rlc.E0:F4}");
            sb.AppendLine($"w      = {rlc.W:F4}\n");

            sb.AppendLine($"A   = {rlc.Amplitude:F4}");
            sb.AppendLine($"phi = {rlc.Phase:F4}\n");

            sb.AppendLine($"{rlc.Equation}");

            return sb.ToString();
        }

        // ================= RLCI =================
        private string FormatRLCI(RLCIResultData rlc)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Circuito RLC (Corriente i) ===\n");

            sb.AppendLine($"lambda = {rlc.Lambda:F4}");
            sb.AppendLine($"omega  = {rlc.Omega:F4}");
            sb.AppendLine($"E0     = {rlc.E0:F4}");
            sb.AppendLine($"w      = {rlc.W:F4}\n");

            sb.AppendLine($"A   = {rlc.Amplitude:F4}");
            sb.AppendLine($"phi = {rlc.Phase:F4}\n");

            sb.AppendLine($"{rlc.Equation}");

            return sb.ToString();
        }
    }
}