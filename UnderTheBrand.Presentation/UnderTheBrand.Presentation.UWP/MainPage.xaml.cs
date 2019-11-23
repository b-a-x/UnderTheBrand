namespace UnderTheBrand.Presentation.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new UnderTheBrand.Infrastructure.Mobile.App());
        }
    }
}
