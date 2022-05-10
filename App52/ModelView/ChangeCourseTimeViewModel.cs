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
    public class ChangeCourseTimeViewModel : BaseViewModel

    {


        public string SName { get; set; }
        public string description { get; set; }
        public string snum { get; set; }
        public string cnum { get; set; }
        public string currentDivision { get; set; }
        public string newDivision { get; set; }


        private ChangeCourseTimeDB services;
        public Command AddStudentCommand { get; }

        private ObservableCollection<Model.ChangeCourseTime> _student = new ObservableCollection<Model.ChangeCourseTime>();



        public ObservableCollection<Model.ChangeCourseTime> Students
        {
            get
            {


                return _student;
            }
            set
            {
                _student = value;
                OnPropertyChanged();
            }
        }



        public ChangeCourseTimeViewModel()
        { 

              services = new ChangeCourseTimeDB();
              Students = services.getStudent();

            AddStudentCommand = new Command(async () => await AddChangeAsync(SName, snum, cnum,currentDivision , newDivision, description));

        }


        private async Task AddChangeAsync(string sName, string Snum, string Cnum,string CurrentDivision, string NewDivision, string Description)
        {
            await services.AddChange(sName, Snum, Cnum,CurrentDivision, NewDivision, Description);
        }
    }
}









