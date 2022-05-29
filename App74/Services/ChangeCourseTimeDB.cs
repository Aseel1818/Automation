using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App74.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
namespace App74.Services
{
    public class ChangeCourseTimeDB
    {
        FirebaseClient client;

        public ChangeCourseTimeDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<ChangeCourseTime> getStudent()
        {
            var CoachData = client.Child("ChangeCourseTime").AsObservable<ChangeCourseTime>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddChange(string sName, string Snum, string Cnum, string CurrentDivision, string NewDivision, string Description)
        {
            ChangeCourseTime change = new ChangeCourseTime() {
                StudentName= sName, 
                StudentNumber = Snum,
                CourseNumber = Cnum, 
                CurrentDivision = CurrentDivision,
                NewDivision = NewDivision,
                Description = Description
            };
            await client.Child("ChangeCourseTime").PostAsync(change);
        }

    }
}