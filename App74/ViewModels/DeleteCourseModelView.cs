

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using App74.Models;
    using App74.Services;
    using MvvmHelpers;
    using Firebase.Database;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using App74.Views;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;

    namespace App74.ViewModels
{
        public class DeleteCourseModelView : BaseViewModel

        {


        public string StudentName { get; set; }
        public string Description { get; set; }

        public string StudentNumber { get; set; }
        public string CourseNumber { get; set; }

        public string DivisionNumber { get; set; }





        private DeleteCourseDB services;
            public Command AddStudentCommand { get; }

            private ObservableCollection<DeleteCourseModel> _coaches = new ObservableCollection<DeleteCourseModel>();



            public ObservableCollection<DeleteCourseModel> Coaches
            {
                get
                {


                    return _coaches;
                }
                set
                {
                    _coaches = value;
                    OnPropertyChanged();
                }
            }



            public DeleteCourseModelView()
            {



                services = new DeleteCourseDB();
                Coaches = services.getStudent();

                AddStudentCommand = new Command(async () => await AddStudenstAsync(StudentName, StudentNumber, CourseNumber, DivisionNumber, Description));

            }


            private async Task AddStudenstAsync(string sName, string Snum, string Cnum, string Divisionnumber, string description)
            {
                await services.AddStudent(sName, Snum, Cnum, Divisionnumber, description);
            }


        }
    }









   

