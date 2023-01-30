using SQLite;
using System;
// Class : Assignment
// Description : Used to schedule Assignments into calendar to be completed
//
namespace Due_It
{
    public class Assignment
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public DateTime DueDate { get; set; }
        public TimeSpan DueTime { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int AsnCompletionTime { get; set; }
        
        public CompletionTime TimeRemaining { get; set; }
        public Assignment()
        {
            ID = 0;
            Name = "Not Available";
            Course = "Not Available";
            DueDate = DateTime.Today;
            Description = "Not Available";
            Priority = Priority.none;
            AsnCompletionTime = 0;
            DueTime = TimeSpan.FromHours(0);
            TimeRemaining = CompletionTime.fifteen;

        }
        public Assignment(int? iD, string name, string course, DateTime date, TimeSpan time, string description, Priority priority, int asCompletionTime, TimeSlot slotStart, TimeSlot slotEnd, CompletionTime timeRemaining)
        {
            ID = iD;
            Name = name;
            Course = course;
            DueDate = date;
            DueTime = time;
            Description = description;
            Priority = priority;
            AsnCompletionTime = asCompletionTime;
            TimeRemaining = timeRemaining;
        }

        public CompletionTime ChunkRemaining()
        {
            return TimeRemaining;
        }
    }
}
