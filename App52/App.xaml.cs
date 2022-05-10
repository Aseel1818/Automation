using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App52.Views;
namespace App52
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DeleteCourseView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
