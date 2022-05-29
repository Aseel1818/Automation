using App74.Models;
using App74.Services;
using App74.ViewModels;
using Firebase.Database;
using Firebase.Database.Query;
using System;

using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registerCourseDetailsAdmin : ContentPage
    {       
        FirebaseClient firebase = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");
        RegisterCourceAdmin services = new RegisterCourceAdmin();

        public registerCourseDetailsAdmin( string studentName,string studentNumber,string description,string divisionNumber,string courseNumber ,string email)
        {
            InitializeComponent();

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

      

        private async void reject_Clicked(object sender, EventArgs e)
        {
            await services.DeletrOrder(Snumshow.Text);
            CourseRegisterModel delete = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your register course Order rejected from Dr Ahmad"

            };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "Order rejected successfully ", "OK");

        }


        private void accept_Clicked(object sender, EventArgs e)
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
            firebase.Child("DrAhmadacceptRegister").PostAsync(register);
            CourseRegisterModel deletes = new CourseRegisterModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your register course Order accepted from Dr Ahmad , Please wait the results"

            };
            firebase.Child("StudentNotification").PostAsync(deletes);


            App.Current.MainPage.DisplayAlert("Alert", "You accept the  order successfully ", "OK");




        }





    }
}