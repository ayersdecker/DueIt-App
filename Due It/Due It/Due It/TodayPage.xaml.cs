using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage : ContentPage
    {
        public List<Assignment> assignmentsToday;
        public List<Course> coursesToday;
        public List<Block> blocksToday;
        public List<SystemProperties> systemPropertiesToday;

        public TodayPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            LoadUp();
            //CalendarLoad();
        }
        async void CalendarLoad()
        {
            var database = new Database();
            assignmentsToday = await database.GetAssignmentItemsAsync();
            coursesToday = await database.GetCourseItemsAsync();
            blocksToday = await database.GetBlockItemsAsync();
            systemPropertiesToday = await database.GetSystemPropertiesItemsAsync();
            
        }
        async void LoadUp()
        {
            var database = new Database();
            await database.SaveAssignmentItemAsync(new Assignment());
            await database.SaveCourseItemAsync(new Course());
            await database.SaveBlockItemAsync(new Block());
            await database.SaveSystemPropertiesItemAsync(new SystemProperties());
            ToggleToday.Text = DateTime.Now.ToString("M");
        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TodayPage());
        }

        private void Timer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Timer());
        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAssignment());
        }

        private void ToggleToday_Clicked(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime oneWeekNow  = currentDate.AddDays(6);
            if (ToggleToday.Text == DateTime.Now.ToString("M"))
            {
                ToggleToday.Text = currentDate.ToString("MMM") + " " + currentDate.ToString("dd") + " - " + oneWeekNow.ToString("MMM") + " " + oneWeekNow.ToString("dd");
            }
            else
            {
                ToggleToday.Text = currentDate.ToString("M");
            }
        }
    }
}