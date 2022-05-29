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
    public partial class ChangeCourseDetails : ContentPage
    {       
        FirebaseClient firebase = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");
        ChangeCourseTimeDB services = new ChangeCourseTimeDB();

        public ChangeCourseDetails( string studentName,string studentNumber,string description,string cdivisionNumber, string ndivisionNumber,string courseNumber ,string email)
        {

            DateTime date2 = new DateTime(2022, 6, 2, 12, 00, 00);
            DateTime date1 = new DateTime(2022, 5, 31, 12, 00, 00);



            
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
            await services.DeleteChangeOrder(Snumshow.Text);
            DeleteCourseModel delete = new DeleteCourseModel()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your change course time  Order rejected from Dr Hamed"

            };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "Order rejected successfully ", "OK");

        }


        private void accept_Clicked(object sender, EventArgs e)
        {
            ChangeCourseTime register = new ChangeCourseTime()
            {
                StudentName = nameshow.Text,
                CurrentDivision= CDnumshow.Text, 
                NewDivision= NDnumshow.Text,
                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                Description = descriptionshow.Text,
                Email = emailshow.Text

            };
            firebase.Child("DrHamedChangeaccept").PostAsync(register);


        ChangeCourseTime deletes = new ChangeCourseTime()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your  Change Course Time Order accepted from Dr Hamed , Please wait the results"

        };
            firebase.Child("StudentNotification").PostAsync(deletes);

            App.Current.MainPage.DisplayAlert("Alert", "You accept the  order successfully ", "OK");


        }


        private void Go_Clicked(object sender, EventArgs e)
        {


        ChangeCourseTime register = new ChangeCourseTime()
            {

                StudentName = nameshow.Text,
                Email= emailshow.Text,
                StudentNumber = Snumshow.Text,
                CourseNumber = cnumshow.Text,
                CurrentDivision = CDnumshow.Text,
                NewDivision = NDnumshow.Text,
                Description = descriptionshow.Text
            };
            firebase.Child("acceptChangeToAhmad").PostAsync(register);

              ChangeCourseTime delete = new ChangeCourseTime()
            {
                StudentName = nameshow.Text,
                StudentNumber = Snumshow.Text,
                Email = emailshow.Text,
                Notification = "Your  Change Course Time Order Converted to Dr Ahmad "

    };
            firebase.Child("StudentNotification").PostAsync(delete);
            App.Current.MainPage.DisplayAlert("Alert", "The  order converted successfully ", "OK");




        }





    }
}