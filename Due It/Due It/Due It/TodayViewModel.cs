using System;
using System.Collections.Generic;
using System.Text;

namespace Due_It
{
    public class TodayViewModel
    {
        private DateTime currentTime = DateTime.Now;

        public string CurrentTime { get { return currentTime.ToString("h:mm tt"); } }

        
    }
}
