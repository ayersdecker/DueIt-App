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
        public DateTime ScheduledTime { get; set; }
        public string DueDateString { get { return DueDate.ToShortDateString(); } }
        
        public CompletionTime TimeRemaining { get; set; }
        public Assignment()
        {
            ID = 0;
            Name = "[Name/Title Box]";
            Course = "[Course Box]";
            DueDate = DateTime.Today.Date;
            Description = "[Description Box]";
            Priority = Priority.none;
            AsnCompletionTime = 0;
            DueTime = TimeSpan.FromHours(0);
            ScheduledTime = DateTime.Today;
            TimeRemaining = CompletionTime.fifteen;

        }
        public Assignment(int? iD, string name, string course, DateTime date, TimeSpan time, string description, Priority priority, DateTime scheduled, int asCompletionTime, CompletionTime timeRemaining)
        {
            ID = iD;
            Name = name;
            Course = course;
            DueDate = date;
            DueTime = time;
            Description = description;
            Priority = priority;
            ScheduledTime = scheduled;
            AsnCompletionTime = asCompletionTime;
            TimeRemaining = timeRemaining;
        }

        public override string ToString()
        {
            return Name;
        }
        public CompletionTime ChunkRemaining()
        {
            return TimeRemaining;
        }
    }
}
