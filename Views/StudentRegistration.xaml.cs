using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App74.ViewModels;

namespace App74.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentRegistration : ContentPage
    {

        UserRepository _userRepository = new UserRepository();
        public StudentRegistration()
        {
            InitializeComponent();
            BindingContext = new StudentsModelView();
        }



        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string number = TxtNumber.Text;
                string confirmPassword = TxtConfirmPass.Text;


                if (string.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Please enter your name ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(number))
                {
                    await DisplayAlert("Warning", "Please enter your number ", "Cancel");
                    return;
                }
                if (number.Length < 8)
                {  
                    await DisplayAlert("Warning", "Student number should be 8 digits", "Cancel");
                    return;
                }


                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Please enter your email ", "Cancel");
                    return;
                }

                if (password.Length < 6)
                {
                    await DisplayAlert("Warning", "password should be more 6 digit", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Please enter your password ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Warning", "Please enter confirm password ", "Cancel");
                    return;
                }

                if (password != confirmPassword)
                {
                    await DisplayAlert("Warning", "password not match .. ", "Cancel");
                    return;
                }



                bool isSave = await _userRepository.Register(email, name, password);
                if (isSave)
                {
                    await DisplayAlert("Register user", "Regestiration compleated ", "ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Register user", "Regestiration faild ", "ok");

                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Warning", "EMAIL_EXISTS", "ok");
                }

            }


        }
        ///////////////////////////////////////////////////////





    }

    public class PhoneNumberMaskBehavior : Behavior<Entry>
    {
        public static PhoneNumberMaskBehavior Instance = new PhoneNumberMaskBehavior();

        ///  
        /// Attaches when the page is first created.  
        ///   

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        ///  
        /// Detaches when the page is destroyed.  
        ///   

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                // If the new value is longer than the old value, the user is  
                if (args.OldTextValue != null && args.NewTextValue.Length < args.OldTextValue.Length)
                    return;

                var value = args.NewTextValue;

                if (value.Length == 3)
                {
                    ((Entry)sender).Text += "-";
                    return;
                }

                if (value.Length == 7)
                {
                    ((Entry)sender).Text += "-";
                    return;
                }

                ((Entry)sender).Text = args.NewTextValue;
            }
        }
    }

    public class EntryLengthValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; } = 0;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // if Entry text is longer than valid length  
            if (entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1); // remove last char  

                entry.Text = entryText;
            }

            if (MinLength > 0)
                if (entry.Text.Length < this.MinLength)
                {
                    ((Entry)sender).TextColor = Color.Red;
                }
                else
                    ((Entry)sender).TextColor = Color.Black;
        }



    }
}