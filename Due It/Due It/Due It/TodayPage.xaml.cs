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
            RunIt();
        }
        async void RunIt()
        {
            var rewardItem = new Reward
            {
                ID = null,
                Name = "Test",
                Description = "Reward Db Test"
            };
            reward = new RewardDatabase(); 
            await reward.SaveItemAsync(rewardItem);
            //GetRewards();
            AssignIt();
        }
        async void AssignIt()
        {
            rewardsList = await reward.GetItemsAsync();
        }
    }
}