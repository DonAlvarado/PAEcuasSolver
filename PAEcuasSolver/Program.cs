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

// VALIDACIÓN GENERAL
if (result.Data == null)
{
    Console.WriteLine("No hay datos para graficar.");
    return;
}

// VALIDAR LISTAS GENÉRICAMENTE (NO MVA ONLY)
if (result.Data is IResultData dataWithPlot)
{
    var plotService = new PlotService();

    // MAS o MVA ya deben tener Time/Values
    var t = dataWithPlot.Time;
    var x = dataWithPlot.Values;

    if (t == null || x == null)
    {
        Console.WriteLine("No hay datos para graficar.");
        return;
    }

    if (t.Count != x.Count)
    {
        Console.WriteLine("Datos inconsistentes para graficar.");
        return;
    }

    Console.WriteLine($"Datos t: {t.Count}");
    Console.WriteLine($"Datos x: {x.Count}");

    plotService.PlotAnimated(dataWithPlot);
}
else
{
    Console.WriteLine("Tipo de resultado no soportado para gráfica aún.");
}