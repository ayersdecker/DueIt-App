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
        public ObservableCollection<Assignment> toBeLoaded = new ObservableCollection<Assignment>();
        public List<Course> coursesToday;
        public List<Block> blocksToday;
        public List<SystemProperties> systemPropertiesToday;

        public TodayPage()
        {
            
            _ = AssignRoster();
            NavigationPage.SetHasNavigationBar(this, false);
            TodayAssignmentQuery(todayRoster);
            InitializeComponent();
            //LoadUp();
            //CalendarLoad();
            Time.Text = DateTime.Now.ToString("h:mm tt");
            todayRoster = AssignmentSampleList();
            toBeLoaded = TodayAssignmentQuery(todayRoster);
            ObservableCollection<Assignment> Boobl = toBeLoaded;
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
        public ObservableCollection<Assignment> TodayAssignmentQuery(ObservableCollection<Assignment> assignmentItems)
        {
            ObservableCollection<Assignment> result = new ObservableCollection<Assignment>();
            foreach (var assignmentItem in assignmentItems)
            {
                if (assignmentItem.ScheduledTime.Date == DateTime.Today.Date) { result.Add(assignmentItem);  }
            }
            
            return result;
        }
        private ObservableCollection<Assignment> WeekAssignmentQuery(ObservableCollection<Assignment> assignmentItems)
        {
            ObservableCollection<Assignment> result = new ObservableCollection<Assignment>();
            foreach (var assignmentItem in assignmentItems)
            {
                if (assignmentItem.ScheduledTime.Date >= DateTime.Today.Date && assignmentItem.ScheduledTime.Date <= DateTime.Today.AddDays(7)) { result.Add(assignmentItem); }
            }

            return result;
        }
        private ObservableCollection<Assignment> AssignmentSampleList()
        {
            ObservableCollection<Assignment> assignment = new ObservableCollection<Assignment>();
            assignment.Add(new Assignment() { Name = "Homework 1", Course = "Science", Priority = Priority.low, DueDate = DateTime.Today.AddDays(4), ScheduledTime = DateTime.Today });
            assignment.Add(new Assignment() { Name = "Homework 2", Course = "Science", Priority = Priority.low, DueDate = DateTime.Today.AddDays(1), ScheduledTime = DateTime.Today });
            assignment.Add(new Assignment() { Name = "Project 1", Course = "History", Priority = Priority.medium, DueDate = DateTime.Today.AddDays(3), ScheduledTime = DateTime.Today});
            assignment.Add(new Assignment() { Name = "ICE 04", Course = "PF 1", Priority = Priority.low, DueDate = DateTime.Today.AddDays(1), ScheduledTime = DateTime.Today.AddDays(1)});
            return assignment;
        }
        private void ToggleToday_Clicked(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime oneWeekNow  = currentDate.AddDays(6);
            if (ToggleToday.Text == DateTime.Now.ToString("M"))
            {
                ToggleToday.Text = currentDate.ToString("MMM") + " " + currentDate.ToString("dd") + " - " + oneWeekNow.ToString("MMM") + " " + oneWeekNow.ToString("dd");
                toBeLoaded.Clear();
                toBeLoaded = WeekAssignmentQuery(todayRoster);
            }
            else
            {
                ToggleToday.Text = currentDate.ToString("M");
                toBeLoaded.Clear();
                toBeLoaded = TodayAssignmentQuery(todayRoster);
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

        private void ScheduleView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] options = new string[] { "Start Timer", "Incomplete", "Completed" };
            var result = DisplayActionSheet(ScheduleView.SelectedItem.ToString(), "Cancel", "", options);
            if(result.ToString() == options[2]) { toBeLoaded.Remove((Assignment)ScheduleView.SelectedItem); ScheduleView.ItemsSource = toBeLoaded; }
        }

    }
}