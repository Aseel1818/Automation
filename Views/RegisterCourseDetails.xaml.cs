using App74.Models;
using App74.Services;
using App74.ViewModels;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCourseDetails : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");
        RegisterCourseDB services = new RegisterCourseDB();

        public RegisterCourseDetails(string studentName, string studentNumber, string description, string divisionNumber, string courseNumber, string email)
        {

            DateTime date2 = new DateTime(2022, 6, 2, 12, 00, 00);
            DateTime date1 = new DateTime(2022, 5, 28, 12, 00, 00);




            InitializeComponent();
            if (DateTime.Now >= date1 && DateTime.Now <= date2)

            {
                gotoButton.IsVisible = false;
                acceptButton.IsVisible = true;

            }
            else
            {
                gotoButton.IsVisible = true;
                acceptButton.IsVisible = false;
            }



            nameshow.Text = studentName;
            Snumshow.Text = studentNumber;
            Dnumshow.Text = divisionNumber;
            descriptionshow.Text = description;
            cnumshow.Text = courseNumber;
            emailshow.Text = email;



        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void reject2_Clicked(object sender, EventArgs e)
        {
            await services.DeletrRegisterOrder(Snumshow.Text);
            CourseRegisterModel delete = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your Course Registration Order rejected from Dr Hamed"

            };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "Order rejected successfully ", "OK");

        }


        private void accept2_Clicked(object sender, EventArgs e)
        {
            CourseRegisterModel register = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,

                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                DivisionNumber = Dnumshow.Text,
                Description = descriptionshow.Text,
                Email = emailshow.Text

            };
            firebase.Child("DrHamedacceptRegister").PostAsync(register);


            CourseRegisterModel deletes = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your Course Registration Order accepted from Dr Hamed , Please wait the results"

            };
            firebase.Child("StudentNotification").PostAsync(deletes);

            App.Current.MainPage.DisplayAlert("Alert", "You accept the  order successfully ", "OK");


        }


        private void Go2_Clicked(object sender, EventArgs e)
        {


            CourseRegisterModel register = new CourseRegisterModel()
            {

                StudentName = nameshow.Text,
                Email=emailshow.Text,
                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                DivisionNumber = Dnumshow.Text,
                Description = descriptionshow.Text
            };
            firebase.Child("acceptregistrationToAhmad").PostAsync(register);
            CourseRegisterModel delete = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your Course Registration Order Converted to Dr Ahmad "

            };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "The order convert successfully ", "OK");




        }





    }
}