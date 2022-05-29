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
    public class RegisterCourseDB
    {
        FirebaseClient client;

        public RegisterCourseDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<CourseRegisterModel> getStudent()
        {
            var StudentData = client.Child("RegisterCourse").AsObservable<CourseRegisterModel>().AsObservableCollection();

            return StudentData;



        }

        public async Task DeletrRegisterOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrHamedacceptRegister").OnceAsync<CourseRegisterModel>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrHamedacceptRegister").DeleteAsync();

        }





        public async Task AddStudent(string sName, string Snum, string email, string Cnum, string Divisionnumber, string Description)
        {
            CourseRegisterModel delete = new CourseRegisterModel()
            {
                StudentName = sName,
                StudentNumber = Snum,
                CourseNumber = Cnum,
                DivisionNumber = Divisionnumber,
                Description = Description,
                Email = email
            };
            await client.Child("RegisterCourse").PostAsync(delete);
        }





    }
}