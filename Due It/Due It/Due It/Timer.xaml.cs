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
        Stopwatch stopwatch = new Stopwatch();
        

        public Timer()
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
        private void HourUpButton_Clicked(object sender, EventArgs e)
        {

        }
        private void HourDownButton_Clicked(object sender, EventArgs e)
        {

        }
        private void HourUpButton_Clicked_1(object sender, EventArgs e)
        {

        }
        private void MinUpButton_Clicked(object sender, EventArgs e)
        {

        }
        private void MinDownButton_Clicked(object sender, EventArgs e)
        {

        }
        private void StartPauseButton_Clicked(object sender, EventArgs e)
        {
            StartPauseButton.Text = StartPauseButton.Text == "Start" ? "Pause" : "Start";
            StartPauseButton.BackgroundColor = StartPauseButton.BackgroundColor == Color.Lime ? Color.LightYellow : Color.Lime;
            if (StartPauseButton.Text != "Pause")
                TimeSetVisibility(true); 
            else
                TimeSetVisibility(false);
            
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
                SecondTime.IsVisible        = false;
                StartPauseButton.Opacity    = 1;
                BackgroundImg.IsVisible = false;
                Home.IsVisible = true;
                TimerBtn.IsVisible = true;
                Settings.IsVisible = true;
                stopwatch.Stop();
            }
            else
            {
                HourUpButton.IsVisible = false;
                HourDownButton.IsVisible = false;
                MinUpButton.IsVisible = false;
                MinDownButton.IsVisible = false;
                ClearButton.IsVisible = false;
                SecondTime.IsVisible        = true;
                StartPauseButton.Opacity    = .25;
                BackgroundImg.IsVisible = true;
                Home.IsVisible = false;
                TimerBtn.IsVisible = false;
                Settings.IsVisible = false;
                stopwatch.Start();
            }
        }
        private void ClearButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}