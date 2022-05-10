﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App52.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
namespace App52.Services
{
    public class DeleteCourseDB
    {
        FirebaseClient client;

        public DeleteCourseDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<DeleteCourseModel> getStudent()
        {
            var StudentData = client.Child("DeleteCourse").AsObservable<DeleteCourseModel>().AsObservableCollection();



            return StudentData;



        }



        public async Task AddStudent(string sName, string Snum, string Cnum, string Divisionnumber, string Description)
        {
            DeleteCourseModel c = new DeleteCourseModel() { SName = sName, snum = Snum, cnum = Cnum, divisionnumber = Divisionnumber, description = Description };
            await client.Child("DeleteCourse").PostAsync(c);
        }

    }
}
