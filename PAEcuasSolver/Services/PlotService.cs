using ScottPlot;
using ScottPlot.WinForms;
using System.Windows.Forms;

namespace PAEcuasSolver.Services
{
    public class PlotService
    {
        public void PlotAnimated(double[] t, double[] x)
        {
            Form form = new Form
            {
                Width = 800,
                Height = 600,
                Text = "Gráfica MAS"
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

            // 👇 CLAVE: esto mantiene viva la ventana
            System.Windows.Forms.Application.Run(form);
        }
    }
}