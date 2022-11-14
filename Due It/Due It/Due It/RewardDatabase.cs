using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Due_It
{
    public class TimeSlotDatabaseContext
    {

    }

    public class RewardDatabase
    {
            static SQLiteAsyncConnection Database;

            public static readonly AsyncLazy<RewardDatabase> Instance = new AsyncLazy<RewardDatabase>(async () =>
            {
                var instance = new RewardDatabase();
                CreateTableResult result = await Database.CreateTableAsync<Reward>();
                return instance;
            });

            public RewardDatabase()
            {
                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            }

            public Task<List<Reward>> GetItemsAsync()
            {
                return Database.Table<Reward>().ToListAsync();
            }

            public Task<Reward> GetItemAsync(int id)
            {
                return Database.Table<Reward>().Where(i => i.ID == id).FirstOrDefaultAsync();
            }

            public async Task<int> SaveItemAsync(Reward reward)
            {
                await Database.CreateTableAsync<Reward>();
                if (reward.ID == null)
                    return await Database.InsertAsync(reward);
                return await Database.UpdateAsync(reward);
            }

            public Task<int> DeleteItemAsync(Reward reward)
            {
                return Database.DeleteAsync(reward);
            }
        
    }
}
