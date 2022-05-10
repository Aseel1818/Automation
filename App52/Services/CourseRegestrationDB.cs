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
    public class CourseRegestrationDB
    {
        FirebaseClient client;

        public CourseRegestrationDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<CourseRegisterModel> getStudent()
        {
            var StuedntData = client.Child("CourseRegestration").AsObservable<CourseRegisterModel>().AsObservableCollection();
            


            return StuedntData;



        }

       

        public async Task AddStudent(string sName, string Snum, string Cnum, string Divisionnumber, string Description)
        {
            CourseRegisterModel c =new CourseRegisterModel() { SName= sName, snum=Snum,cnum=Cnum,divisionnumber=Divisionnumber,description=Description };
            await client.Child("CourseRegestration").PostAsync(c);
        }

    }
}
