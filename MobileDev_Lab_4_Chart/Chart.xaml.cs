using Microcharts;
using SkiaSharp;
using System.ComponentModel;

namespace MobileDev_Lab_4_Chart
{
    public partial class Chart : ContentPage
    {
        Function function = Reciever.staticFunction;

        public Chart()
        {
            InitializeComponent();
        }

        private void OnClickDraw(object sender, EventArgs e)
        {
            // Обчислити результат перед циклом

            List<ChartEntry> entries = new List<ChartEntry>();

            for (double x = function.StartInterval; x <= function.EndInterval; x += function.Step)
            {
                // Використовувати раніше обчислений результат
                double y = function.Result;
                y += x;

                entries.Add(new ChartEntry((float)y)
                {
                    Label = x.ToString("F2"),
                    ValueLabel = y.ToString("F2"),
                    Color = SKColor.Parse("#2c3e50")
                });
            }

            //resultEntry.Text = $"Result: {function.Result}";

            var chart = new LineChart() { Entries = entries };

            chartView.Chart = chart;
        }

    }
}
