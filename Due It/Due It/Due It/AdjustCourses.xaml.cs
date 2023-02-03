using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdjustCourses : ContentPage
    {
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>() { };
        
        public AdjustCourses()
        {
            Courses.Add(new Course() { Name = "Science"});
            Courses.Add(new Course() { Name = "History" });
            Courses.Add(new Course() { Name = "PF 1"});
            ObservableCollection<Course> courses = new ObservableCollection<Course>();
            courses = Courses;
            NavigationPage.SetHasNavigationBar(this, false);
            CourseView.ItemsSource = courses;
            InitializeComponent();
            BindingContext = this;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCourse());
        }
    }
}