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
    public partial class ChangeCourseDetailsAdmin : ContentPage
    {       
        FirebaseClient firebase = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");
        ChangeCourceAdmin services = new ChangeCourceAdmin();

        public ChangeCourseDetailsAdmin( string studentName,string studentNumber,string description,string cdivisionNumber, string ndivisionNumber, string courseNumber ,string email)
        {
            InitializeComponent();

            nameshow.Text = studentName;
            Snumshow.Text = studentNumber;
            CDnumshow.Text = cdivisionNumber;
            NDnumshow.Text = ndivisionNumber;

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
            DeleteCourseModel delete = new DeleteCourseModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your Change Course Time Order rejected from Dr Ahmad"

            };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "Order rejected successfully ", "OK");

        }


        private void accept_Clicked(object sender, EventArgs e)
        {
            ChangeCourseTime register = new ChangeCourseTime()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
               CurrentDivision= CDnumshow.Text,
               NewDivision= NDnumshow.Text,
                Description = descriptionshow.Text,
                Email = emailshow.Text
            };
            firebase.Child("DrAhmadChangeaccept").PostAsync(register);
            ChangeCourseTime deletes = new ChangeCourseTime()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your Change Course Time  Order accepted from Dr Ahmad , Please wait the results"

            };
            firebase.Child("StudentNotification").PostAsync(deletes);


            App.Current.MainPage.DisplayAlert("Alert", "You accept the  order successfully ", "OK");




        }





    }
}