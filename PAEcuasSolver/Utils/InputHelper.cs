using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Utils
{
    public static class InputHelper
    {
        public static double LeerDouble(string msg)
        {
            Console.Write(msg);
            return double.Parse(Console.ReadLine());
        }
    }
}
