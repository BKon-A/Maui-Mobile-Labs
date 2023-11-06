namespace MobileDev_Lab_4_Graph;

public partial class WelcomePage : ContentPage
{
    private const uint AnimationDuration = 1000u;
	public WelcomePage()
	{
		InitializeComponent();
	}
    //private async void MenuTap(object sender, TappedEventArgs e)
    //{
    //    await CloseMenu();
    //}
    //private async Task CloseMenu()
    //{
    //    _ = WelcomeGrid.FadeTo(1, AnimationDuration);
    //    _ = MenuGrid.ScaleTo(1, AnimationDuration);
    //    await WelcomeGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
    //}

    //private async void WelcomeGridTap(object sender, EventArgs e)
    //{
    //    _ = WelcomeGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
    //    await WelcomeGrid.ScaleTo(0.8, AnimationDuration);
    //    _ = WelcomeGrid.FadeTo(0.8, AnimationDuration);
    //}
}