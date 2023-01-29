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
        public int CourseID { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DueTime { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public CompletionTime CompletionTime { get; set; }
        
        public CompletionTime TimeRemaining { get; set; }
        public Assignment()
        {
            ID = 0;
            Name = "Not Available";
            CourseID = 0;
            DueDate = DateTime.Today;
            Description = "Not Available";
            Priority = Priority.none;
            CompletionTime = CompletionTime.fifteen;
            DueTime = DateTime.Today;
            TimeRemaining = CompletionTime.fifteen;

        }
        public Assignment(int? iD, string name, int course, DateTime date, DateTime time, string description, Priority priority, CompletionTime completionTime, TimeSlot slotStart, TimeSlot slotEnd, CompletionTime timeRemaining)
        {
            ID = iD;
            Name = name;
            CourseID = course;
            DueDate = date;
            DueTime = time;
            Description = description;
            Priority = priority;
            CompletionTime = completionTime;
            TimeRemaining = timeRemaining;
        }

        public CompletionTime ChunkRemaining()
        {
            return TimeRemaining;
        }
    }
}
