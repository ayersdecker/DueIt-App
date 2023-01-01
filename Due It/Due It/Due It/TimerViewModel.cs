using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Schema;

namespace Due_It
{
    public class TimerViewModel
    {
        private int timerInterval;

        public int TimerInterval
        {
            get { return timerInterval; }
            set
            {
                timerInterval = value; //OnPropertyChanged();
            }
        }

		/*private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }*/

/* Link to stack overflow: https://stackoverflow.com/questions/3416903/stopwatch-that-counts-down-in-c-sharp */

    }
}
