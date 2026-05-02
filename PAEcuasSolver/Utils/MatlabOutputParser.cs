using System.Text;

namespace PAEcuasSolver.Utils
{
    public class MatlabOutputParser
    {
        public (string humanText, string json) Parse(string output)
        {
            var lines = output.Split('\n');

            bool insideJson = false;
            var jsonBuilder = new StringBuilder();
            var humanBuilder = new StringBuilder();

            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim(); // 🔥 CLAVE

                if (line == "JSON_START")
                {
                    insideJson = true;
                    continue;
                }

                if (line == "JSON_END")
                {
                    insideJson = false;
                    continue;
                }

                if (insideJson)
                {
                    jsonBuilder.AppendLine(line);
                }
                else
                {
                    humanBuilder.AppendLine(rawLine); // conserva formato original
                }
            }

            return (humanBuilder.ToString(), jsonBuilder.ToString().Trim());
        }
    }
}