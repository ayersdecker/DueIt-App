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

        public List<Assignment> assignmentsToday = new List<Assignment>();
        public ObservableCollection<Assignment> todayRoster = new ObservableCollection<Assignment>();
        public List<Course> coursesToday;
        public List<Block> blocksToday;
        public List<SystemProperties> systemPropertiesToday;

        public TodayPage()
        {
            todayRoster.Clear();
            _ = AssignRoster();
            NavigationPage.SetHasNavigationBar(this, false);
            
            InitializeComponent();
            LoadUp();
            CalendarLoad();
            Time.Text = DateTime.Now.ToString("h:mm tt");
            ObservableCollection<Assignment> Boobl = todayRoster;
            BindingContext = this;
            ScheduleView.ItemsSource = Boobl;
        }
        async void CalendarLoad()
        {
            var database = new Database();
            assignmentsToday = await database.GetAssignmentItemsAsync();
            coursesToday = await database.GetCourseItemsAsync();
            blocksToday = await database.GetBlockItemsAsync();
            systemPropertiesToday = await database.GetSystemPropertiesItemsAsync();
            ToggleToday.Text = DateTime.Now.ToString("M");
        }
        async void LoadUp()
        {
            var database = new Database();
            await database.SaveAssignmentItemAsync(new Assignment());
            await database.SaveCourseItemAsync(new Course());
            await database.SaveBlockItemAsync(new Block());
            await database.SaveSystemPropertiesItemAsync(new SystemProperties());
            

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
        public void AssignmentAdd(Assignment assignment)
        {
            todayRoster.Add(assignment);
        }
        public async Task AssignRoster()
        {
            var database = new Database();
            List<Assignment> assignmentsToday = await database.GetAssignmentItemsAsync();
            foreach (Assignment assignment in assignmentsToday)
            {
                todayRoster.Add(assignment);
            }
        }
        public async Task SaveThisAssignmentAsync(Assignment assignment)
        {
            var database = new Database();
            await database.SaveAssignmentItemAsync(assignment);
            await AssignRoster();
        }
    }
}