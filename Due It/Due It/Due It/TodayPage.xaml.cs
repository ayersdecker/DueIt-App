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
        public Task<List<Reward>> rewards;
        public List<Reward> rewardsList;
        RewardDatabase reward;
        public TodayPage()
        {
            InitializeComponent();
            Hold();
            Hold2();
        }
        void Hold()
        {
            RunIt();
        }
        void Hold2()
        {
            GetRewards();
            AssignIt();
        }
        async void RunIt()
        {
            var rewardItem = new Reward
            {
                ID = 1,
                Name = "Test",
                Description = "Reward Db Test"
            };
            reward = new RewardDatabase(); 
            await reward.SaveItemAsync(rewardItem);
            GetRewards();
            AssignIt();
        }

        private async void GetRewards()
        {
            rewards = await reward.GetItemsAsync();;
        }

        async void AssignIt()
        {
            rewardsList = await new List<Reward>(rewards);
        }
    }
}