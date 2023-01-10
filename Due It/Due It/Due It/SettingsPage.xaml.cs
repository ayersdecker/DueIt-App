using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TodayPage());
        }

        private void TimerBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Timer());
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void AddEvent_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdjustEvents());
        }

        private void AddCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdjustCourses());
        }

        private void Preferences_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreferencesPage());
        }

        private void Completed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompletedPage());
        }

        private void AboutPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private void AddAssignment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssignment());
        }
    }
}