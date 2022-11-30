using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
// Class : Assignment
// Description : Used to schedule Assignments into calendar to be completed
//
namespace Due_It
{
    public class Assignment : ITimeChunk
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public CompletionTime CompletionTime { get; set; }
        public TimeSlot SlotStart { get; set; }
        public TimeSlot SlotEnd { get; set; }
        public CompletionTime TimeRemaining { get; set; }
        public string Notes { get; set; } 
        public Assignment()
        {
            ID = 0;
            Name = "Not Available";
            CourseID = 0;
            Date = DateTime.Today;
            Description = "Not Available";
            Priority = Priority.none;
            CompletionTime = CompletionTime.fifteen;
            SlotStart = TimeSlot.ZeroFift;
            SlotEnd = TimeSlot.ZeroThir;
            TimeRemaining = CompletionTime.fifteen;
            Notes = "N/A";

        }
        public Assignment(int? iD, string name, int course, DateTime date, string description, Priority priority, CompletionTime completionTime, TimeSlot slotStart, TimeSlot slotEnd, CompletionTime timeRemaining, string notes)
        {
            ID = iD;
            Name = name;
            CourseID = course;
            Date = date;
            Description = description;
            Priority = priority;
            CompletionTime = completionTime;
            SlotStart = slotStart;
            SlotEnd = slotEnd;
            TimeRemaining = timeRemaining;
            Notes = notes;
        }

        public TimeSlot ChunkStart()
        {
            return SlotStart;
        }
        public TimeSlot ChunkEnd()
        {
            return SlotEnd;
        }
        public int ChunkCount()
        {
            return SlotEnd - SlotStart;
        }
        public CompletionTime ChunkRemaining()
        {
            return TimeRemaining;
        }
        public string NoteIntake()
        {
            return Notes;
        }
    }
}
