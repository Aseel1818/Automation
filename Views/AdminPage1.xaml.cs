using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App74.Models;
using App74.ViewModels;
using Firebase.Database;
using Xamarin.Essentials;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage1 : ContentPage
    {
        public AdminPage1()
        {
            InitializeComponent();
            
            registerListView.IsVisible = false;
            deleteListView.IsVisible = false;
            changeListView.IsVisible = false;




        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
            

            var mydetails = e.Item as DeleteCourseModel;
            App.Current.MainPage=new DeleteCourseDetails(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber,mydetails.CourseNumber,mydetails.Email);



        }

        private async void ListView2_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            

            var mydetails = e.Item as CourseRegisterModel;
            App.Current.MainPage = new RegisterCourseDetails(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber, mydetails.CourseNumber, mydetails.Email);



        }

        private async void ListView3_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as ChangeCourseTime;
            App.Current.MainPage = new ChangeCourseDetails(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.CurrentDivision,mydetails.NewDivision, mydetails.CourseNumber, mydetails.Email);



        }







        protected override  void OnAppearing()
        {
           
           
        }


        private async void Button1_Clicked(object sender, EventArgs e)
        {
            deleteListView.BindingContext = new DeleteCourseModelView();
            deleteListView.IsVisible = true;
            registerListView.IsVisible = false;
            changeListView.IsVisible = false;


        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            registerListView.BindingContext = new RegisterCourseModelView();
            deleteListView.IsVisible = false;
            changeListView.IsVisible = false;

            registerListView.IsVisible = true;

        }


       private async void Button3_Clicked(object sender, EventArgs e)
        {
            changeListView.BindingContext = new ChangeCourseModelView();
            deleteListView.IsVisible = false;
            changeListView.IsVisible = true;

            
            registerListView.IsVisible = false;

        }

    }
}