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
    }
}