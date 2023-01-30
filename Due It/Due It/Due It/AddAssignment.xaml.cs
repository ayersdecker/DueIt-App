using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssignment : ContentPage
    {
        public AddAssignment()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            if (FormValidated())
            {   
                // Instance of Database to store new Assignment
                var database = new Database();

                // Create Default Const.
                Assignment assignment = new Assignment();

                // Add parameters into Default Const.
                assignment.Name = NameEntry.Text;
                assignment.Description = DescriptionEntry.Text;
                assignment.Course = CourseEntry.SelectedIndex.ToString(); //TODO Connect ID to courseID
                assignment.DueDate = DueDateEntry.Date;
                assignment.DueTime = DueTimeEntry.Time;
                assignment.AsnCompletionTime = TimeToComplete.SelectedIndex;

                // Call method to store new Assignment
                _ = database.SaveAssignmentItemAsync(assignment);

                Navigation.PopAsync();
            }
        }
        private bool FormValidated()
        {
            bool result = true;
            if (NameEntry.Text == "" || NameEntry.Text == null)                                         { result = false; }
            if (DescriptionEntry.Text == "" || DescriptionEntry.Text == null)                           { result = false; }
            if (CourseEntry.SelectedIndex == -1)                                                         { result = false; }
            if (DueDateEntry.Date < DateTime.Now.Date)                                                  { result = false; }
            if (DueDateEntry.Date == DateTime.Now.Date && DueTimeEntry.Time < DateTime.Now.TimeOfDay)   { result = false; }
            if (TimeToComplete.SelectedIndex == -1)                                                      { result = false; }
            if (Low.IsChecked == false && Medium.IsChecked == false && High.IsChecked == false)         { result = false; }

            return result;

        }
    }
}