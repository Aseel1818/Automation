using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App74.ViewModels;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string webAPIKey = "AIzaSyDpu1gSJuQcqsZapONHPLzbfgG70pFiNT4";

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

       
        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(TxtEmail.Text, TxtPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
               
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
              
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password ",  "OK");
            }


        }


        private async void registerTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StudentRegistration());
        }
    }
}