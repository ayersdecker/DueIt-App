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
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseCode { get; set; }
        public int section { get; set; }
        public string Instructor { get; set; }
        //public List<Monad> Schedule { get; set; }

        public Course()
        {
            ID = 0;
            Name = "Not Available";
            Description = "Not Available";
            CourseCode = "Not Available";
            section = 0;
            Instructor = "Not Available";
            //Schedule = new List<Monad>();
        }
        public Course(int? iD, string name, string description, string courseCode, int section, string instructor /*List<Monad> schedule*/)
        {
            ID = iD;
            Name = name;
            Description = description;
            CourseCode = courseCode;
            this.section = section;
            Instructor = instructor;
            //Schedule = schedule;
        }
        
    }
}
