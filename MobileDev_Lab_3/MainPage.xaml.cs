using System.Text.Json;
using System;
using System.Text;

namespace MobileDev_Lab_3
{
    public partial class MainPage : ContentPage
    {
        public string FileName { get; set; } = FileSystem.AppDataDirectory + "/result.json";

        Function function;
        public MainPage()
        {
            InitializeComponent();
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
            if(File.Exists(FileName))
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


        private async void OnClickAbout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

    }
}