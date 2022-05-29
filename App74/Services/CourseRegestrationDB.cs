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
            CourseRegisterModel register = new CourseRegisterModel() {
                StudentName = sName, 
                StudentNumber = Snum,
                CourseNumber = Cnum,
                DivisionNumber = Divisionnumber, 
                Description = Description };

            await client.Child("CourseRegestration").PostAsync(register);
        }

    }
}