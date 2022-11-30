using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    public class SystemProperties
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public Preference Preference { get; set; }

        public SystemProperties()
        {
            ID = 0;
            Preference = new Preference();
        }
    }
}
