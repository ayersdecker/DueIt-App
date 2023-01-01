using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Schema;

namespace Due_It
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private int timerInterval;


        public int TimerInterval
        {
            get { return timerInterval; }
            set
            {
                timerInterval = value;
                OnPropertyChanged(nameof(timerInterval));
            }
        }

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string timer)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(timer)));
        }

/* Link to stack overflow: https://stackoverflow.com/questions/3416903/stopwatch-that-counts-down-in-c-sharp */

    }
}
