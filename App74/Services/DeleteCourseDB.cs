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

        public async Task DeletrOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrHamedaccept").OnceAsync<DeleteCourseModel>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrHamedaccept").DeleteAsync();

        }


       


        public async Task AddStudent(string sName, string Snum, string Cnum, string Divisionnumber, string Description)
        {
            DeleteCourseModel delete = new DeleteCourseModel() { 
                StudentName = sName,
                StudentNumber = Snum,
                CourseNumber = Cnum, 
                DivisionNumber = Divisionnumber, 
                Description = Description
            };
            await client.Child("DeleteCourse").PostAsync(delete);
        }


        public async Task<List<DeleteCourseModel>> GetAll()
        {
            return (await client.Child(nameof(DeleteCourseModel)).OnceAsync<DeleteCourseModel>()).Select(item => new DeleteCourseModel
            {
                StudentName = item.Object.StudentName,
                Description = item.Object.Description
            } ).ToList();
           
        }


    }
}