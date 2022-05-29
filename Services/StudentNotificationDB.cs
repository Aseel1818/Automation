using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App74.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using Xamarin.Essentials;

namespace App74.Services
{
    public class StudentNotificationDB
    {
        FirebaseClient client;

        public StudentNotificationDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }


        private static string GetUserEmail { get; set; }


        public async Task<List<DeleteCourseModel>> GetAllByEmail()
        {

            return (await client.Child("StudentNotification").OnceAsync<DeleteCourseModel>()).Select(item => new DeleteCourseModel
            {
                StudentName = item.Object.StudentName,
                Notification=item.Object.Notification,
                Email=item.Object.Email,
                StudentNumber=item.Object.StudentNumber,
                

            }).Where(c => c.Email.Contains("hamayelmuna@gmail.com")).ToList();
        }

      



    }
}