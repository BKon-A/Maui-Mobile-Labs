namespace MobileDev_Lab_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private double FunctionCalculate(double x)
        {
            double G, y = 0, z = 0, c = 0;
            G = (Math.Tan(Math.Pow(x, 4) - 6) - Math.Pow(Math.Cos(z + x * y), 3)) 
                / (Math.Pow(Math.Cos(Math.Pow(c, 2) * Math.Pow(x, 3)), 4));

            return G;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (double.TryParse(inputEntry.Text, out double value) )
            {
                double result = FunctionCalculate(value);
                resultLabel.Text = $"Result: {result}";
            }
        }

        private async void OnClickAbout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}