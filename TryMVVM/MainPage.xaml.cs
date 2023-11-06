using TryMVVM.src;

namespace TryMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new PersonViewModel();
        }
    }
}