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

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage1 : ContentPage
    {
        public AdminPage1()
        {
            InitializeComponent();
            BindingContext = new DeleteCourseModelView();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as DeleteCourseModel;
            App.Current.MainPage=new DeleteCourseDetails(mydetails.StudentName, mydetails.StudentNumber, mydetails.Description, mydetails.DivisionNumber,mydetails.CourseNumber);



        }
        protected override  void OnAppearing()
        {
           
           
        }
    }
}