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
            InitializeComponent();
            LoadUp();
            CalendarLoad();
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

            //var rewardItem = new Reward
            //{
            //    ID = null,
            //    Name = "Test",
            //    Description = "Reward Db Test"
            //};
            //reward = new RewardDatabase();
            //await reward.SaveItemAsync(rewardItem);
            //GetRewards();
            //AssignIt();
        }
        //async void AssignIt()
        //{
          //  rewardsList = await reward.GetItemsAsync();
        //}
    }
}