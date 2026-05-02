using System;
using System.Collections.Generic;
using System.Text;

using PAEcuasSolver.Models;

namespace PAEcuasSolver.Utils.InputHandler
{
    public interface IInputHandler
    {
        ProblemInput ReadInput();
    }
}