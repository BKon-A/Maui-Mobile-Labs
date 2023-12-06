using Microsoft.Maui.Storage;

namespace MobileDev_Lab_4_Chart
{
    public partial class MainPage : ContentPage
    {
        public Function function;

        public string FileName { get; set; } = FileSystem.AppDataDirectory + "/result.txt";

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnClickCalculate(object sender, EventArgs e)
        {
            double functionResult = 0;

            function = new Function(double.Parse(xRatio.Text), double.Parse(startInterval.Text), double.Parse(endInterval.Text), double.Parse(stepInterval.Text));

            Reciever.staticFunction = function;

            functionResult = function.FunctionCalculate();

            result.Text = $"Result: {functionResult}";
        }

        private void OnClickClearFile(object sender, EventArgs e)
        {
            // Clear the content of the file
            File.WriteAllText(FileName, string.Empty);
        }

        private void OnClickSerialize(object sender, EventArgs e)
        {
            // Serialize the function object to a string using its overridden ToString method
            var serializedData = function.ToString();

            // Append new serialized information
            File.AppendAllText(FileName, serializedData + Environment.NewLine);
        }

        private async void OnClickDeserialize(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    var data = File.ReadLines(FileName).Reverse().Take(5).ToList();

                    if (data.Count == 5)
                    {
                        // Зчитати числові значення з останніх 4 рядків (в зворотньому порядку)
                        xRatio.Text = GetNumericValue(data[4]);
                        startInterval.Text = GetNumericValue(data[3]);
                        endInterval.Text = GetNumericValue(data[2]);
                        stepInterval.Text = GetNumericValue(data[1]);
                    }
                    else
                    {
                        await DisplayAlert("File Error", "Not enough lines in the file", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("File Not Found", "File does not exist", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private string GetNumericValue(string input)
        {
            // Вибрати числові значення за допомогою роздільника ": "
            var parts = input.Split(": ");
            if (parts.Length > 1)
            {
                return parts[1].Trim(); // Повертаємо значення після ": " та видаляємо зайві пробіли
            }
            return string.Empty;
        }




        private async void OnClickReadWithFile(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    var data = File.ReadAllText(FileName);

                    editor.Text = data;
                }
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("NullReferenceException", "File is empty", "OK");
            }
        }
    }
}
