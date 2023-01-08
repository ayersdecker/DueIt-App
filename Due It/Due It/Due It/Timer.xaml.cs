using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer : ContentPage
    {
        public int hourCount = 0;
        public int minuteCount = 0;

        public Timer()
        {
            
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            CurrentTime.IsVisible= false;
            
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
        private void HourUpButton_Clicked(object sender, EventArgs e)
        {
            hourCount++;
        }
        private void HourDownButton_Clicked(object sender, EventArgs e)
        {
            hourCount--;
        }
        private void MinUpButton_Clicked(object sender, EventArgs e)
        {
            minuteCount++;
        }
        private void MinDownButton_Clicked(object sender, EventArgs e)
        {
            minuteCount--;
            
        }
        
        private void TimeSetVisibility(bool toggle)
        {
            if (toggle)
            {
                HourUpButton.IsVisible = true;
                HourDownButton.IsVisible = true;
                MinUpButton.IsVisible = true;
                MinDownButton.IsVisible = true;
                ClearButton.IsVisible = true;
                StartButton.IsVisible = true;
                PauseButton.IsVisible = false;
                BackgroundImg.IsVisible = false;
                Home.IsVisible = true;
                TimerBtn.IsVisible = true;
                Settings.IsVisible = true;
                PageTitle.IsVisible = true;
                CurrentTime.IsVisible = false       ;
            }
            else
            {
                PageTitle.IsVisible = false;
                HourUpButton.IsVisible = false;
                HourDownButton.IsVisible = false;
                MinUpButton.IsVisible = false;
                MinDownButton.IsVisible = false;
                ClearButton.IsVisible = false;
                StartButton.IsVisible    = false;
                PauseButton.IsVisible= true;
                BackgroundImg.IsVisible = true;
                Home.IsVisible = false;
                TimerBtn.IsVisible = false;
                Settings.IsVisible = false;
                CurrentTime.IsVisible= true;
            }
        }
        private void ClearButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PauseButton_Clicked(object sender, EventArgs e)
        {
            TimeSetVisibility(true);
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            TimeSetVisibility(false);
        }
    }
}