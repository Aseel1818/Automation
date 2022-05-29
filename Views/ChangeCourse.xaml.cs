using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App74.ViewModels;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeCourse : ContentPage
    {
        public ChangeCourse()
        {
            InitializeComponent();
            BindingContext = new ChangeCourseModelView();

        }
        private static string GetUserEmail { get; set; }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = studentName.Text;
                string num = studentNumber.Text;
                string coursNumber = CourseNumber.Text;
                string Description = description.Text;
                string email = studentemail.Text;
                string cudiv = currentdivNumber.Text;
                string newdiv = newdivNumber.Text;




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

                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Please enter Your Email  ", "Cancel");
                    return;
                }



                if (string.IsNullOrEmpty(coursNumber))
                {
                    await DisplayAlert("Warning", "Please enter your course Number ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(cudiv))
                {
                    await DisplayAlert("Warning", "Please enter your  Current Division Number ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(newdiv))
                {
                    await DisplayAlert("Warning", "Please enter your  New Division Number ", "Cancel");
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


            var oauthToken = await SecureStorage.GetAsync("UserName");
            GetUserEmail = oauthToken;

          
            

            

            App.Current.MainPage.DisplayAlert("Alert", "Change Course Time form saved successfuly ", "OK");


        }




    }
}