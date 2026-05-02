using System;
using System.Globalization;

namespace PAEcuasSolver.Utils
{
    public static class InputHelper
    {
        public static double LeerDouble(string msg)
        {
            double valor;

            while (true)
            {
                Console.Write(msg);
                var input = Console.ReadLine();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out valor))
                    return valor;

                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}