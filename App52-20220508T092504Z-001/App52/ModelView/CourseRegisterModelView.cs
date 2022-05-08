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
    public class CourseRegisterModelView : BaseViewModel

    {


        public string SName { get; set; }
        public string description { get; set; }

        public int snum { get; set; }
        public int cnum{ get; set; }

        public int divisionnumber { get; set; }




        private CourseRegestrationDB services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<CourseRegisterModel> _coaches = new ObservableCollection<CourseRegisterModel>();

      

        public ObservableCollection<CourseRegisterModel> Coaches
        {
            get {
                

                return _coaches;
                 }
            set
            {
                _coaches = value;
                OnPropertyChanged();
            }
        }



        public CourseRegisterModelView()
        {

         

            services = new CourseRegestrationDB();
            Coaches = services.getCoach();
            
            AddCoachesCommand = new Command(async () => await AddCoachAsync( SName, snum, cnum, divisionnumber, description));

        }


        private async Task AddCoachAsync( string  sName,int Snum,int Cnum,int Divisionnumber,string Description)
        {
            await services.AddCoach(  sName, Snum, Cnum,  Divisionnumber,  Description);
        }
    }
}

    

        





