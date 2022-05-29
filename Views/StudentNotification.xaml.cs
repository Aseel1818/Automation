using App74.Services;
using App74.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentNotification : ContentPage
    {
        public StudentNotification()
        {
            InitializeComponent();
            
        }

        StudentNotificationDB studentRepository = new StudentNotificationDB();


        protected override async void OnAppearing()
        {
            var coaches = await studentRepository.GetAllByEmail();
            notificationListView.ItemsSource = null;
            notificationListView.ItemsSource = coaches;
            notificationListView.IsRefreshing = false;


        }


    }
}