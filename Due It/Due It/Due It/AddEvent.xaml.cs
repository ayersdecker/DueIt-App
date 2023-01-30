using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Due_It
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvent : ContentPage
    {
        public AddEvent()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            if (FormValidated())
            {
                // Instance of Database to store new Event
                var database = new Database();

                // Create Default Const.
                Block block = new Block();

                // Add parameters into Default Const.
                block.Name = NameEntry.Text;
                block.Description = DescriptionEntry.Text;
                block.Repeat = RepeatPicker.SelectedIndex;

                // Call method to store new Event
                _ = database.SaveBlockItemAsync(block);

                Navigation.PopAsync();
            }
        }
        private bool FormValidated()
        {
            bool result = true;

            if (NameEntry.Text == "" || NameEntry.Text == null) { result = false; }
            if (DescriptionEntry.Text == "" || DescriptionEntry.Text == null) { result = false; }
            if (RepeatPicker.SelectedItem == null) { result = false; }

            return result;

        }
    }
}