using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App74.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

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
            var StudentData = client.Child("ChangeCourseTime").AsObservable<ChangeCourseTime>().AsObservableCollection();

            return StudentData;



        }

        public async Task DeleteChangeOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrHamedChangeTimeaccept").OnceAsync<ChangeCourseTime>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrHamedChangeTimeaccept").DeleteAsync();

        }





        public async Task AddStudent(string sName, string Snum, string email, string Cnum, string currentDivisionnumber, string newDivisionnumber, string Description)
        {
            ChangeCourseTime delete = new ChangeCourseTime()
            {
                StudentName = sName,
                StudentNumber = Snum,
                CourseNumber = Cnum,
                CurrentDivision=currentDivisionnumber,
                NewDivision=newDivisionnumber,
                Description = Description,
                Email = email
            };
            await client.Child("ChangeCourseTime").PostAsync(delete);
        }





    }
}