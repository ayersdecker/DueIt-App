using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
// Class: Block
// Description: Used to Block off sections of time within Schedule OBJ 
//
namespace Due_It
{
    internal class Block
    {

        
        // Holds different time periods selectable to block off different times for --> Used for repeatPeriod/RepeatPeriod
        string[] periods = new string[] {"Never", "Daily", "Weekly", "Monthly"};

        //Stores the name of the Block
        private string name;
        //Stores general description given to Block
        private string description;
        //Stores selected weekday via Enum --> Sunday = 0, Monday = 1 ...
        private DayOfWeek dayOfWeek;
        //Stores selected time of day
        private TimeSlot timeOfDayStart;
        private TimeSlot timeOfDayEnd;
        private string repeatPeriod;
        public string RepeatPeriod
        {
            get { return repeatPeriod; }
            set
            {
                for (int i = 0; i < periods.Length; i++){ if (value == periods[i]){repeatPeriod = value;}}
                if (repeatPeriod != value){ repeatPeriod = periods[0]; }
            }
        }
    }
}
