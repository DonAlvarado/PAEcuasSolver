using PAEcuasSolver.Models.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAEcuasSolver.Utils.Formatters
{
    public interface IResultFormatter
    {
        string Format(IResultData data);
    }
}
