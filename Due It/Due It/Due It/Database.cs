using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Due_It
{
    public class Database
    {
        /// <summary>
        /// This is the SQLite connect that can be called upon dynamically
        /// </summary>
        static SQLiteAsyncConnection connection;

        /// <summary>
        /// New database created using this readonly Instance
        /// </summary>
        public static readonly AsyncLazy<Database> Instance = new AsyncLazy<Database>(async () =>
        {
            // New Construction of Database
            var instance = new Database();
            // Flag that houses whether Reward table is created or migrated (UNUSED AT THIS TIME)
            CreateTableResult result = await connection.CreateTableAsync<Reward>();
            // Returns constructed Database that is generated ASYNC and can run against flags
            return instance;
        });

        /// <summary>
        /// Default Constructor for the SQLite Database that assigns the connection to a new ASYNC connection
        /// </summary>
        public Database()
        {
            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }


        // This collection of methods called Get____ItemsAsync() are used to ->

        /// <summary>
        /// ASYNC Method to return all items stored within the Rewards Table as a Task List
        /// </summary>
        /// <returns>Task<list<Reward>></returns>
        public Task<List<Reward>> GetRewardItemsAsync()
        {
            return connection.Table<Reward>().ToListAsync();
        }
        /// <summary>
        /// ASYNC Method to return all items stored within the Assignment Table as a Task List
        /// </summary>
        /// <returns>Task<list<Assignments>></returns>
        public Task<List<Assignment>> GetAssignmentItemsAsync()
        {
            return connection.Table<Assignment>().ToListAsync();
        }
        /// <summary>
        /// ASYNC Method to return all items stored within the Courses Table as a Task List
        /// </summary>
        /// <returns>Task<list<Course>></returns>
        public Task<List<Course>> GetCourseItemsAsync()
        {
            return connection.Table<Course>().ToListAsync();
        }
        /// <summary>
        /// ASYNC Method to return all items stored within the Blocks Table as a Task List
        /// </summary>
        /// <returns>Task<list<Block>></returns>
        public Task<List<Block>> GetBlockItemsAsync()
        {
            return connection.Table<Block>().ToListAsync();
        }
        /// <summary>
        /// ASYNC Method to return all items stored within the SystemPreferences Table as a Task List
        /// </summary>
        /// <returns>Task<list<SystemProperties>></returns>
        public Task<List<SystemProperties>> GetSystemPropertiesItemsAsync()
        {
            return connection.Table<SystemProperties>().ToListAsync();
        }


        // This collection of methods called Get____ItemsAsync(int id) are used to ->

        /// <summary>
        /// ASYNC Method to return selected item stored within Rewards Table as a Task
        /// </summary>
        /// <returns>Task<Reward></returns>
        public Task<Reward> GetRewardItemAsync(int id)
        {
            return connection.Table<Reward>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// ASYNC Method to return selected item stored within Assignments Table as a Task
        /// </summary>
        /// <returns>Task<Assignment></returns>
        public Task<Assignment> GetAssignmentItemAsync(int id)
        {
            return connection.Table<Assignment>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// ASYNC Method to return selected item stored within Courses Table as a Task
        /// </summary>
        /// <returns>Task<Course></returns>
        public Task<Course> GetCourseItemAsync(int id)
        {
            return connection.Table<Course>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// ASYNC Method to return selected item stored within Blocks Table as a Task
        /// </summary>
        /// <returns>Task<Block></returns>
        public Task<Block> GetBlockItemAsync(int id)
        {
            return connection.Table<Block>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// ASYNC Method to return selected item stored within SystemProperties Table as a Task
        /// </summary>
        /// <returns>Task<SystemProperties></returns>
        public Task<SystemProperties> GetSystemPropertiesItemAsync(int id)
        {
            return connection.Table<SystemProperties>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }


        // This collection of methods called Save____ItemsAsync(Item item) are used to ->

        /// <summary>
        /// Saves Reward Item ASYNC to the Rewards table if exists or not
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> SaveRewardItemAsync(Reward reward)
        {
            await connection.CreateTableAsync<Reward>();
            if (reward.ID == null)
                return await connection.InsertAsync(reward);
            return await connection.UpdateAsync(reward);
        }
        /// <summary>
        /// Saves Assignment Item ASYNC to the Assignment table if exists or not
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> SaveAssignmentItemAsync(Assignment assignment)
        {
            await connection.CreateTableAsync<Assignment>();
            if (assignment.ID == null)
                return await connection.InsertAsync(assignment);
            return await connection.UpdateAsync(assignment);
        }
        /// <summary>
        /// Saves Course Item ASYNC to the Course table if exists or not
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> SaveCourseItemAsync(Course course)
        {
            await connection.CreateTableAsync<Course>();
            if (course.ID == null)
                return await connection.InsertAsync(course);
            return await connection.UpdateAsync(course);
        }
        /// <summary>
        /// Saves Block Item ASYNC to the Block table if exists or not
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> SaveBlockItemAsync(Block block)
        {
            await connection.CreateTableAsync<Block>();
            if (block.ID == null)
                return await connection.InsertAsync(block);
            return await connection.UpdateAsync(block);
        }
        /// <summary>
        /// Saves SystemProperties Item ASYNC to the SystemProperties table if exists or not
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> SaveSystemPropertiesItemAsync(SystemProperties systemProperties)
        {
            await connection.CreateTableAsync<Reward>();
            if (systemProperties.ID == null)
                return await connection.InsertAsync(systemProperties);
            return await connection.UpdateAsync(systemProperties);
        }


        // This collection of methods called Delete____ItemAsync(Item item) are used to ->

        /// <summary>
        /// Deletes Reward Item ASYNC from the Reward table
        /// </summary>
        /// <returns>Task<int></returns>
        public Task<int> DeleteRewardItemAsync(Reward reward)
        {
            return connection.DeleteAsync(reward);
        }
        /// <summary>
        /// Deletes Assignment Item ASYNC from the Assignment table
        /// </summary>
        /// <returns>Task<int></returns>
        public Task<int> DeleteAssignmentItemAsync(Assignment assignment)
        {
            return connection.DeleteAsync(assignment);
        }
        /// <summary>
        /// Deletes Course Item ASYNC from the Course table
        /// </summary>
        /// <returns>Task<int></returns>
        public Task<int> DeleteCourseItemAsync(Course course)
        {
            return connection.DeleteAsync(course);
        }
        /// <summary>
        /// Deletes Block Item ASYNC from the Block table
        /// </summary>
        /// <returns>Task<int></returns>
        public Task<int> DeleteBlockItemAsync(Block block)
        {
            return connection.DeleteAsync(block);
        }
        /// <summary>
        /// Deletes SystemProperties Item ASYNC from the SystemProperties table
        /// </summary>
        /// <returns>Task<int></returns>
        public Task<int> DeleteSystemPropertiesItemAsync(SystemProperties systemProperties)
        {
            return connection.DeleteAsync(systemProperties);
        }


    }
}
