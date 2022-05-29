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
            BindingContext = new DeleteCourseAdminViewModel();
        }

        DeleteCourceAdmin services = new DeleteCourceAdmin();

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as DeleteCourseModel;
            App.Current.MainPage = new DeleteCourseDetailsAdmin(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber, mydetails.CourseNumber);



        }
        protected override void OnAppearing()
        {


        }

        private  async void delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}