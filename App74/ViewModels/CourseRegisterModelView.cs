﻿using System;
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
    public class CourseRegisterModelView : BaseViewModel

    {


        public string SName { get; set; }
        public string description { get; set; }

        public string snum { get; set; }
        public string cnum { get; set; }

        public string divisionnumber { get; set; }




        private CourseRegestrationDB services;
        public Command AddStudentCommand { get; }

        private ObservableCollection<CourseRegisterModel> _coaches = new ObservableCollection<CourseRegisterModel>();



        public ObservableCollection<CourseRegisterModel> Coaches
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



        public CourseRegisterModelView()
        {



            services = new CourseRegestrationDB();
            Coaches = services.getStudent();

            AddStudentCommand = new Command(async () => await AddCoachAsync(SName, snum, cnum, divisionnumber, description));

        }


        private async Task AddCoachAsync(string sName, string Snum, string Cnum, string Divisionnumber, string Description)
        {
            await services.AddStudent(sName, Snum, Cnum, Divisionnumber, Description);
        }
    }
}








