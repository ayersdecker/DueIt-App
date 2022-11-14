using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Due_It
{
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

            public Task<int> SaveItemAsync(Reward reward)
            {
                if (reward.ID != 0)
                {
                    return Database.UpdateAsync(reward);
                }
                else
                {
                    return Database.InsertAsync(reward);
                }
            }

            public Task<int> DeleteItemAsync(Reward reward)
            {
                return Database.DeleteAsync(reward);
            }
        
    }
}
