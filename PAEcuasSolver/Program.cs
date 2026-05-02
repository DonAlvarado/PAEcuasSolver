using PAEcuasSolver.Services;
using PAEcuasSolver.Utils;
using PAEcuasSolver.Models.Results;

// Inicialización
var solver = new SolverService();
var menu = new PAEcuasSolver.Utils.Menu();

// Obtener input del usuario
var input = menu.Show();

// Resolver problema
var result = solver.Resolver(input);

// Mostrar resultado textual
Console.WriteLine("Resultado:");
Console.WriteLine(result.Message);

// 🔥 VALIDAR SI HAY DATA
if (result.Data == null)
{
    Console.WriteLine("No hay datos para graficar.");
    return;
}

// 🔥 INTENTAR CAST A MAS (por ahora solo tienes ese caso)
if (result.Data is MASResultData masData)
{
    if (masData.Time == null || masData.Values == null)
    {
        Console.WriteLine("No hay datos para graficar.");
        return;
    }

    Console.WriteLine($"Datos t: {masData.Time.Count}");
    Console.WriteLine($"Datos x: {masData.Values.Count}");

    // 🔥 GRAFICAR
    var plotService = new PlotService();

    plotService.PlotAnimated(
        masData.Time.ToArray(),
        masData.Values.ToArray()
    );
}
else
{
    Console.WriteLine("Tipo de resultado no soportado para gráfica aún.");
}