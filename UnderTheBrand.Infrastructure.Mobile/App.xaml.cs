using UnderTheBrand.Infrastructure.Mobile.Services;
using UnderTheBrand.Infrastructure.Mobile.Views;
using Xamarin.Forms;

namespace UnderTheBrand.Infrastructure.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
