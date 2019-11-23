using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UnderTheBrand.Presentation.Services;
using UnderTheBrand.Presentation.Views;

namespace UnderTheBrand.Presentation
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
