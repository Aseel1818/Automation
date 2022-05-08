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
    public class DeleteCourseDB
    {
        FirebaseClient client;

        public DeleteCourseDB()
        {
            client = new FirebaseClient("https://cap-registration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<DeleteCourseModel> getCoach()
        {
            var CoachData = client.Child("DeleteCourse").AsObservable<DeleteCourseModel>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddCoach(string sName, int Snum, int Cnum, int Divisionnumber, string Description)
        {
            DeleteCourseModel c = new DeleteCourseModel() { SName = sName, snum = Snum, cnum = Cnum, divisionnumber = Divisionnumber, description = Description };
            await client.Child("DeleteCourse").PostAsync(c);
        }

    }
}
