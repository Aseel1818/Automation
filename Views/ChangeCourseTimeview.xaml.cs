using App52.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App52.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeCourseTimeview : ContentPage
    {
        public ChangeCourseTimeview()
        {
            InitializeComponent();
            BindingContext = new ChangeCourseTimeViewModel();

        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = Sname.Text;
                string num = Snum.Text;
                string coursNumber = CoursNumberText.Text;
                string currentDiv = currentdivText.Text;
                string newDiv= newDivisiontxt.Text;
                string Description = description.Text;




                if (string.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Please enter Your Name  ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(num))
                {
                    await DisplayAlert("Warning", "Please enter Your Number  ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(coursNumber))
                {
                    await DisplayAlert("Warning", "Please enter your course Number ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(currentDiv))
                {
                    await DisplayAlert("Warning", "Please enter your current Division ", "Cancel");
                    return;
                }


                if (string.IsNullOrEmpty(newDiv))
                {
                    await DisplayAlert("Warning", "Please enter your Course ", "Cancel");
                    return;
                }

             
         

                if (string.IsNullOrEmpty(Description))
                {
                    await DisplayAlert("Warning", "Please enter Description ", "Cancel");
                    return;
                }
                

  
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Warning", "EMAIL_EXISTS", "ok");
                }

            }
        }
    }
}