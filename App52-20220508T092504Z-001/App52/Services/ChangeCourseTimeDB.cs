using System;
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
    public class ChangeCourseTimeDB
    {
        FirebaseClient client;

        public ChangeCourseTimeDB()
        {
            client = new FirebaseClient("https://cap-registration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<ChangeCourseTime> getCoach()
        {
            var CoachData = client.Child("ChangeCourseTime").AsObservable<ChangeCourseTime>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddChange(string sName, int Snum, int Cnum,  int CurrentDivision, int NewDivision, string Description)
        {
            ChangeCourseTime c = new ChangeCourseTime() { SName = sName, snum = Snum, cnum = Cnum, currentDivision=CurrentDivision,newDivision=NewDivision, description = Description };
            await client.Child("ChangeCourseTime").PostAsync(c);
        }

    }
}
