using ScottPlot;
using ScottPlot.WinForms;
using System.Windows.Forms;
using PAEcuasSolver.Models.Results;

namespace PAEcuasSolver.Services
{
    public class PlotService
    {
        public void PlotAnimated(IResultData result)
        {
            // Validación básica
            if (result.Time == null || result.Values == null)
            {
                MessageBox.Show("No hay datos para graficar");
                return;
            }

            double[] t = result.Time.ToArray();
            double[] x = result.Values.ToArray();

            Form form = new Form
            {
                Width = 800,
                Height = 600,
                Text = "Gráfica del Sistema"
            };

            FormsPlot formsPlot = new FormsPlot
            {
                Dock = DockStyle.Fill
            };

            form.Controls.Add(formsPlot);

            var plt = formsPlot.Plot;

            plt.Add.Scatter(t, x);
            var marker = plt.Add.Marker(t[0], x[0]);

            int i = 0;

            var timer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };

            timer.Tick += (s, e) =>
            {
                if (i >= t.Length)
                {
                    timer.Stop();
                    return;
                }

                marker.X = t[i];
                marker.Y = x[i];

                formsPlot.Refresh();
                i++;
            };

            form.Shown += (s, e) => timer.Start();

            Application.Run(form);
        }
    }
}