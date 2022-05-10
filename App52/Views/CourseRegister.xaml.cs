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
    public partial class CourseRegister : ContentPage
    {
        public CourseRegister()
        {
            InitializeComponent();
            BindingContext = new CourseRegisterModelView();
        }


        private async void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = StudentName.Text;
                string num = StudentNumber.Text;
                string coursNumber = CourseNumber.Text;
                string DivNumber = divisionNumber.Text;
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
                if (string.IsNullOrEmpty(DivNumber))
                {
                    await DisplayAlert("Warning", "Please enter your  Division Number ", "Cancel");
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