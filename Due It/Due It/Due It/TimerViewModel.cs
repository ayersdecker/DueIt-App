using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Xml.Schema;
using Xamarin.Forms;
using System.Timers;
using System.Net;

namespace Due_It
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private DateTime currentTime = DateTime.Now;

        public string CurrentTime { get { return currentTime.ToString("h:mm tt"); } }

        private System.Timers.Timer _timer;
        private int secTimerInterval;
        private int minTimerInterval;
        private int hourTimerInterval;
        private bool running = false;

        private string colon = ":";
        public string Colon { get { return colon; } set { } }
        public int MinTimerInterval
        {

            set
            {
                if (minTimerInterval != value)
                {
                    minTimerInterval = value;
                    OnPropertyChanged();
                }
                if (minTimerInterval < 0 && hourTimerInterval > 0)
                {
                    minTimerInterval = 59;
                    HourTimerInterval -= 1;
                    OnPropertyChanged();
                }
                if (minTimerInterval < 0)
                {
                    minTimerInterval = 0;
                    OnPropertyChanged();
                }
                
                if (minTimerInterval > 59)
                {

                    HourTimerInterval += 1;
                    minTimerInterval = 0;
                    OnPropertyChanged();
                }
                

            }
            get { return minTimerInterval; }
        }
        public int SecTimerInterval
        {
            get { return secTimerInterval; }
            set {

                if (secTimerInterval != value)
                {
                    secTimerInterval = value;
                    OnPropertyChanged();
                }
                if (minTimerInterval == 0 && hourTimerInterval == 0 && secTimerInterval == 0)
                {
                    if (running)
                    {
                        _timer.Stop();
                        running = false;
                        OnPropertyChanged();
                    }

                }
                if(minTimerInterval >= 0 && secTimerInterval < 0) 
                { 
                    secTimerInterval = 59; 
                    minTimerInterval -= 1; 
                    OnPropertyChanged();
                }
                if (secTimerInterval < 0)
                {
                    secTimerInterval = 0;
                }
            }
        }
        public int HourTimerInterval
        {

            set
            {
                if (hourTimerInterval != value)
                {
                    hourTimerInterval = value;
                    OnPropertyChanged();
                }
                if (hourTimerInterval < 0)
                {
                    hourTimerInterval = 0;
                    OnPropertyChanged();
                }

            }
            get { return hourTimerInterval; }
        }

        public ICommand AddHour => new Command(
            execute: () =>
            {
                HourTimerInterval += 1;
                OnPropertyChanged();
            },
            canExecute: () => true);
        public ICommand SubHour => new Command(
            execute: () =>
            {
                HourTimerInterval -= 1;
                OnPropertyChanged();
            },
            canExecute: () => true);
        public ICommand AddMin => new Command(
            execute: () =>
            {
                MinTimerInterval += 1;
                OnPropertyChanged();
            },
            canExecute: () => true);
        public ICommand SubMin => new Command(
            execute: () =>
            {
                MinTimerInterval -= 1;
                OnPropertyChanged();
            },
            canExecute: () => true);
        public ICommand StartToggle => new Command(
            execute: () =>
            {
                if (!running)
                {
                    _timer = new System.Timers.Timer(1000);
                    _timer.Elapsed += TimerElapsed;
                   
                    _timer.Start();
                    running= true;
                    OnPropertyChanged();
                }
                
            },
            canExecute: () => true);
        public ICommand PauseToggle => new Command(
            execute: () =>
            {
                _timer.Stop();
                running= false;
                OnPropertyChanged();
            },
            canExecute: () => true);
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            bool flag = false;
            Device.BeginInvokeOnMainThread(() =>
            {   if(MinTimerInterval == 0 && HourTimerInterval == 0 && SecTimerInterval == 0) { SecTimerInterval = 0; }
                if((MinTimerInterval > 0 || HourTimerInterval > 0) && SecTimerInterval == 0) { MinTimerInterval -= 1; SecTimerInterval = 59; flag = true; }
                if(!(MinTimerInterval == 0 && HourTimerInterval == 0 && SecTimerInterval==0))
                if(!flag) SecTimerInterval -= 1;
                flag = false;
                OnPropertyChanged();
            });
        }
        public ICommand ClearToggle => new Command(
            execute: () =>
            {   
                HourTimerInterval = 0;
                MinTimerInterval = 0;
                SecTimerInterval= 0;
                _timer.Stop();
                running= false;
                OnPropertyChanged();
            },
            canExecute: () => true);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /* Link to stack overflow: https://stackoverflow.com/questions/3416903/stopwatch-that-counts-down-in-c-sharp */

    }
}
