using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App52.Model;
using App52.Services;
using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using App52.Views;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using SolrNet.Utils;

namespace App52.ModelView
{
    public class DeleteCourseModelView : BaseViewModel

    {


        public string SName { get; set; }
        public string description { get; set; }

        public string snum { get; set; }
        public string cnum { get; set; }

        public string divisionnumber { get; set; }

        



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

            AddStudentCommand = new Command(async () => await AddCoachAsync(SName, snum, cnum, divisionnumber, description));

        }


        private async Task AddCoachAsync(string sName, string Snum, string Cnum, string Divisionnumber, string Description)
        {
            await services.AddStudent(sName, Snum, Cnum, Divisionnumber, Description);
        }
    }
}









