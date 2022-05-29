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
    public partial class DeleteCourseDetails : ContentPage
    {       
        FirebaseClient firebase = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");
        DeleteCourseDB services = new DeleteCourseDB();

        public DeleteCourseDetails( string studentName,string studentNumber,string description,string divisionNumber,string courseNumber )
        {

            DateTime date2 = new DateTime(2022, 6, 2, 12, 00, 00);
            DateTime date1 = new DateTime(2022, 5, 31, 12, 00, 00);



            // 12/25/2015 10:30:00 AM }
            InitializeComponent();
                if (DateTime.Now>=date1 && DateTime.Now<=date2)

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

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void reject_Clicked(object sender, EventArgs e)
        {
            await services.DeletrOrder(Snumshow.Text);
            App.Current.MainPage.DisplayAlert("Alert", "Order rejected successfully ", "OK");

        }


        private void accept_Clicked(object sender, EventArgs e)
        {
            DeleteCourseModel register = new DeleteCourseModel()
            {
                StudentName = nameshow.Text,
                 
                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                DivisionNumber = Dnumshow.Text,
                Description = descriptionshow.Text
            };
            firebase.Child("DrHamedaccept").PostAsync(register);
            App.Current.MainPage.DisplayAlert("Alert", "You accept the  order successfully ", "OK");


        }


        private void Go_Clicked(object sender, EventArgs e)
        {

           
            DeleteCourseModel register = new DeleteCourseModel()
            {

                StudentName = nameshow.Text,

                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                DivisionNumber = Dnumshow.Text,
                Description = descriptionshow.Text
            };
            firebase.Child("acceptDeleteToAhmad").PostAsync(register);
             App.Current.MainPage.DisplayAlert("Alert", "The order convert successfully ", "OK");




        }





    }
}