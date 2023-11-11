using Microcharts;
using SkiaSharp;
using System.Text.Json;

namespace MobileDev_Lab_4_Chart
{
    public partial class WelcomePage : ContentPage
    {
        public string FileName { get; set; } = FileSystem.AppDataDirectory + "/result.json";

        Function function;
        private const uint AnimationDuration = 1000u;

        //ChartEntry[] chartEntry;
        public WelcomePage()
        {
            InitializeComponent();
            //chartView.Chart = new LineChart() { Entries = chartEntry };
        }

        private void OnClickCalculate(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            double functionResult = 0;
            function = new Function(double.Parse(startInterval.Text), double.Parse(endInterval.Text), double.Parse(stepInterval.Text));
            functionResult = function.FunctionCalculate();

            result.Text = $"Result: {functionResult}";
        }

        private void OnClickSerialize(object sender, EventArgs e)
        {
            SerializeToJson(function);
            File.WriteAllText(FileName, SerializeToJson(function));
        }

        private void OnClickDeserialize(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                var data = File.ReadAllText(FileName);

                function = DeserializeFromJson<Function>(data);

                startInterval.Text = function.StartInterval.ToString();
                endInterval.Text = function.EndInterval.ToString();
                stepInterval.Text = function.Step.ToString();
            }
        }
        public string SerializeToJson(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                // Обробка помилок серіалізації
                Console.WriteLine($"Serialization error: {ex.Message}");
                return null;
            }
        }

        public T DeserializeFromJson<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                // Обробка помилок десеріалізації
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return default(T);
            }
        }

        //private void OnClickDraw(object sender, EventArgs e)
        //{
        //    var entries = new[]
        //    {
        //        new ChartEntry(212)
        //        {
        //            Label = "UWP",
        //            ValueLabel = "212",
        //            Color = SKColor.Parse("#2c3e50")
        //        },
        //        new ChartEntry(248)
        //        {
        //            Label = "Android",
        //            ValueLabel = "248",
        //            Color = SKColor.Parse("#77d065")
        //        },
        //        new ChartEntry(128)
        //        {
        //            Label = "iOS",
        //            ValueLabel = "128",
        //            Color = SKColor.Parse("#b455b6")
        //        },
        //        new ChartEntry(514)
        //        {
        //            Label = "Shared",
        //            ValueLabel = "514",
        //            Color = SKColor.Parse("#3498db")
        //        }
        //    };

        //    var chart = new BarChart() { Entries = entries };

        //    chartView.Chart = chart;
        //}

        private async void OnClickAbout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void MenuTap(object sender, TappedEventArgs e)
        {
            await CloseMenu();
        }
        private async Task CloseMenu()
        {
            _ = WelcomeGrid.FadeTo(1, AnimationDuration);
            _ = WelcomeGrid.ScaleTo(1, AnimationDuration);
            await WelcomeGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
        }

        private async void WelcomeGridTap(object sender, EventArgs e)
        {
            _ = WelcomeGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
            await WelcomeGrid.ScaleTo(0.8, AnimationDuration);
            _ = WelcomeGrid.FadeTo(0.8, AnimationDuration);
        }
    }
}
   