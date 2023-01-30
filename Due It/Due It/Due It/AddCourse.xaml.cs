using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCourse : ContentPage
    {
        public List<string> dayOptions = new List<string>
        {
            "Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"
        };
        public AddCourse()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            SetMainVisibility(true);
            dayPicker.ItemsSource= dayOptions;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void AddClassButton_Clicked(object sender, EventArgs e)
        {
            SetMainVisibility(false);
        }

        private void RemoveClassButton_Clicked(object sender, EventArgs e)
        {

        }
        private void SetMainVisibility(bool visibility)
        {
            if(visibility)
            {
                but1.Text = "Add Course";
                but2.IsVisible = true;
                but3.IsVisible = true; 
                but4.IsVisible = true;
                but5.IsVisible = true; 
                but6.IsVisible = true;
                but7.IsVisible = true;
                BackButton.IsVisible = true;
                NameEntry.IsVisible = true;
                DescriptionEntry.IsVisible = true;
                CodeEntry.IsVisible = true;
                SectionEntry.IsVisible = true;
                ProfessorEntry.IsVisible = true;
                AddedClasses.IsVisible = true;
                AddClassButton.IsVisible = true;
                RemoveClassButton.IsVisible = true;
                ClearButton.IsVisible = true;
                CreateButton.IsVisible = true;
                add1.IsVisible = false;
                addStartEntry.IsVisible = false;
                add2.IsVisible = false;
                addEndEntry.IsVisible = false;
                add3.IsVisible = false;
                dayPicker.IsVisible = false;
                addClearButton.IsVisible = false;
                addCreateButton.IsVisible = false;
            }
            else
            {
                but1.Text = "Add Class";
                but2.IsVisible = false;
                but3.IsVisible = false;
                but4.IsVisible = false;
                but5.IsVisible = false;
                but6.IsVisible = false;
                but7.IsVisible = false;
                NameEntry.IsVisible = false;
                DescriptionEntry.IsVisible = false;
                CodeEntry.IsVisible = false;
                SectionEntry.IsVisible = false;
                ProfessorEntry.IsVisible = false;
                AddedClasses.IsVisible = false;
                AddClassButton.IsVisible = false;
                RemoveClassButton.IsVisible = false;
                ClearButton.IsVisible = false;
                CreateButton.IsVisible = false;
                add1.IsVisible = true;
                addStartEntry.IsVisible = true;
                add2.IsVisible= true;
                addEndEntry.IsVisible = true;
                add3.IsVisible = true;
                dayPicker.IsVisible = true;
                addClearButton.IsVisible = true;
                addCreateButton.IsVisible = true;
            }
        }



        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            if (FormValidated())
            {
                // Instance of Database to store new Course
                var database = new Database();

                // Create Default Const.
                Course course = new Course();

                // Add parameters into Default Const.
                course.Name = NameEntry.Text;
                course.Description = DescriptionEntry.Text;
                course.CourseCode = CodeEntry.Text;
                course.Section = double.Parse(SectionEntry.Text);
                course.Instructor = ProfessorEntry.Text;

                // Call method to store new Course
                _ = database.SaveCourseItemAsync(course);

                Navigation.PopAsync();
            }
        }
        private bool FormValidated()
        {
            bool result = true;
            
            if (NameEntry.Text == "" || NameEntry.Text == null) { result = false; }
            if (DescriptionEntry.Text == "" || DescriptionEntry.Text == null) { result = false; }
            if (CodeEntry.Text == "" || CodeEntry.Text == null) { result = false; }
            if (SectionEntry.Text == "" || SectionEntry.Text == null) { result = false; }
            if (ProfessorEntry.Text == "" || ProfessorEntry.Text == null) { result = false; }

            return result;

        }
    }
}