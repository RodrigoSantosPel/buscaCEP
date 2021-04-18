using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace buscaCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new buscaCEP.MainPage();
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
