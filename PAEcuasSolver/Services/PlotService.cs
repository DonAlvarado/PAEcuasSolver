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

            double[] t = null;
            double[] x = null;

            // ================= MAS =================
            if (result is MASResultData mas)
            {
                t = mas.Time.ToArray();
                x = mas.Values.ToArray();
            }
            // ================= MVA =================
            else if (result is MVAResultData mva)
            {
                t = mva.Time.ToArray();
                x = mva.Values.ToArray();
            }
            else
            {
                MessageBox.Show("Tipo de resultado no soportado para gráfica");
                return;
            }

            // Línea base
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