using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TodayPage();
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
