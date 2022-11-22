using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Due_It
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TodayPage();

        }
    }
}
