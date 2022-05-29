using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App74.Models;
using App74.ViewModels;
using App74.Services;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage2 : ContentPage
    {
        public AdminPage2()
        {
            InitializeComponent();
            registerListView.IsVisible = false;
            deleteListView.IsVisible = false;
            changeListView.IsVisible = false;

        }




        protected override void OnAppearing()
        {


        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            deleteListView.BindingContext = new DeleteCourseAdminViewModel();
            deleteListView.IsVisible = true;
            registerListView.IsVisible = false;
            changeListView.IsVisible = false;


        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            registerListView.BindingContext = new RegisterCourseAdminViewModel();
            deleteListView.IsVisible = false;
            changeListView.IsVisible = false;

            registerListView.IsVisible = true;

        }

        private async void Button3_Clicked(object sender, EventArgs e)
        {
            changeListView.BindingContext = new ChangeCourseAdminViewModel();
            deleteListView.IsVisible = false;
            changeListView.IsVisible = true;

            registerListView.IsVisible = false;

        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {



            var mydetails = e.Item as DeleteCourseModel;
            App.Current.MainPage = new DeleteCourseDetailsAdmin(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber, mydetails.CourseNumber, mydetails.Email);



        }

        private async void ListView2_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as CourseRegisterModel;
            App.Current.MainPage = new registerCourseDetailsAdmin(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber, mydetails.CourseNumber, mydetails.Email);



        }

        private async void ListView3_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            var mydetails = e.Item as ChangeCourseTime;
            App.Current.MainPage = new ChangeCourseDetailsAdmin(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.CurrentDivision,mydetails.NewDivision, mydetails.CourseNumber, mydetails.Email);



        }
    }
}