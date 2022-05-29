using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App74.Models;
using App74.Services;
using App74.Views;

using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace App74.ViewModels
{
    class StudentsModelView : BaseViewModel

    {
        public string Email { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public int StudentNumber { get; set; }





        private StudentDB Services;
        public Command AddStudentsCommand { get; }
       

        private ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Getstudents
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }



        public StudentsModelView()
        {
            Services = new StudentDB();
            Getstudents = Services.GetStudents();
            AddStudentsCommand = new Command(async () => await AddStudentsAsync(Name, Email ,  Password, StudentNumber));
        }
        private async Task AddStudentsAsync(string name, string email, string password, int studentNumber)
        {
            await Services.AddStudents(Name=name,Email=email,Password=password, StudentNumber= studentNumber);
        }

       

    }
}

    

        





