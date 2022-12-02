using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Due_It
{
    public class AsyncLazy<T>
    {
        /// <summary>
        /// Creates Task Instance that can be used to return such items
        /// </summary>
        readonly Lazy<Task<T>> instance;

        /// <summary>
        /// Constructor that is built off of a single Function for AsyncLazy
        /// </summary>
        /// <param name="factory"></param>
        public AsyncLazy(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        /// <summary>
        /// Constructor that is built off of a single Func<Task<T>> for AsyncLazy
        /// </summary>
        /// <param name="factory"></param>
        public AsyncLazy(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        /// <summary>
        /// Function that awaits the function and returns the value type from parameter
        /// </summary>
        /// <returns>T</returns>
        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }

        /// <summary>
        /// USED ONLY FOR TESTING PURPOSES
        /// </summary>
        public void Start()
        {
            var unused = instance.Value;
        }
    }
}
