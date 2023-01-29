using System;
using SQLite;

namespace Due_It
{
    public class Monad
    {
        /// <summary>
        /// Holds the time value that the event starts 
        /// </summary>
		private int start;
        /// <summary>
        /// Holds the time value that the event ends
        /// </summary>
		private int end;
        /// <summary>
        /// Holds the day of the week it takes place
        /// </summary>
        private DayOfWeek date;


        public int Start { get { return start; } set {  start = value; } }
		public int End { get { return end; } set { end = value; } }
        public DayOfWeek Date { get { return date; } set { date = value; } }

        public Monad()
        { start = 0; end = 0; date = DayOfWeek.Monday; }
        public Monad(int _start, int _end, DayOfWeek _date) { start = _start; end = _end; date = _date; }


        public override string ToString() { return $"{Date:d} [{TimeCypher(Start)} - {TimeCypher(End)}]"; }
        public double TimeCypher(int input) { return (input % 4 == 0) ? input / 4 : (input / 4) + ((input % 4)*(0.25)); }
        public bool IsToday() { return date == DateTime.Today.DayOfWeek; }
        public bool IsThisWeek() { return date >= DateTime.Today.DayOfWeek && date <= DateTime.Today.AddDays(6).DayOfWeek; }



    }
}
