using PAEcuasSolver.Services;
using PAEcuasSolver.Utils;
using PAEcuasSolver.Utils.Formatters;
using PAEcuasSolver.Models.Results;

// Inicialización de componentes principales
var solver = new SolverService();
var menu = new PAEcuasSolver.Utils.Menu();
var formatter = new UnifiedResultFormatter();
var plotService = new PlotService();

// ================= INPUT =================
var input = menu.Show();

// ================= SOLVER =================
var result = solver.Resolver(input);

// ================= OUTPUT =================
Console.WriteLine("Resultado:\n");

// Si no hay datos → error controlado
if (result.Data == null)
{
    Console.WriteLine("No se pudo obtener resultado del sistema.");
    return;
}

// Mostrar resultado formateado (MAS, MVA, MVF, etc.)
Console.WriteLine(formatter.Format(result.Data));

// ================= PLOT =================

// Validación de datos para graficar
if (result.Data.Time == null || result.Data.Values == null)
{
    Console.WriteLine("\nNo hay datos para graficar.");
    return;
}

if (result.Data.Time.Count != result.Data.Values.Count)
{
    Console.WriteLine("\nDatos inconsistentes para graficar.");
    return;
}

Console.WriteLine($"\nDatos t: {result.Data.Time.Count}");
Console.WriteLine($"Datos x: {result.Data.Values.Count}");

// Graficar (unificado)
plotService.PlotAnimated(result.Data);