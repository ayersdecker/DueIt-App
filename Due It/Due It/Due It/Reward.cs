using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    public class Reward
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
