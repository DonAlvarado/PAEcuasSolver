using PAEcuasSolver.Controllers;
using PAEcuasSolver.Models;
using PAEcuasSolver.Utils;

var controller = new SolverController();

Console.WriteLine("Seleccione tipo de problema:");
Console.WriteLine("1. MAS");
Console.WriteLine("2. MVA");
Console.WriteLine("3. MVF");
Console.WriteLine("4. Circuito (q)");
Console.WriteLine("5. Circuito (i)");

string opcion = Console.ReadLine();

var Input = new ProblemInput
{
    Parameters = new Dictionary<string, double>()
};

switch (opcion)
{
    case "1":
        Input.Type = "MAS";
        Input.Parameters["m"] = InputHelper.LeerDouble("Masa: ");
        Input.Parameters["k"] = InputHelper.LeerDouble("Constante k: ");
        break;

    case "2":
        Input.Type = "MVA";
        break;

    case "3":
        Input.Type = "MVF";
        break;

    case "4":
        Input.Type = "RLC_Q";
        break;

    case "5":
        Input.Type = "RLC_I";
        break;
}

controller.Ejecutar(Input);