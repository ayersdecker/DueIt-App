using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    internal class Assignment
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public CompletionTime CompletionTime { get; set; }
        public TimeSlot SlotStart { get; set; }
        public TimeSlot SlotEnd { get; set; }

    }
}
