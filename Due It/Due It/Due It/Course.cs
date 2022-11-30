using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
    }
}
