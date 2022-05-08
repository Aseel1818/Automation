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

        public int snum { get; set; }
        public int cnum { get; set; }

 

        public int currentDivision { get; set; }
        public int newDivision { get; set; }


        private ChangeCourseTimeDB services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<Model.ChangeCourseTime> _coaches = new ObservableCollection<Model.ChangeCourseTime>();



        public ObservableCollection<Model.ChangeCourseTime> Coaches
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



        public ChangeCourseTimeViewModel()
        {

             

       

              services = new ChangeCourseTimeDB();
            Coaches = services.getCoach();

            AddCoachesCommand = new Command(async () => await AddChangeAsync(SName, snum, cnum,currentDivision , newDivision, description));

        }


        private async Task AddChangeAsync(string sName, int Snum, int Cnum,int CurrentDivision, int NewDivision, string Description)
        {
            await services.AddChange(sName, Snum, Cnum,CurrentDivision, NewDivision, Description);
        }
    }
}









