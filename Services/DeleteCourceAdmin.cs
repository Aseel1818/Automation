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
    public class DeleteCourceAdmin
    {
        FirebaseClient client;

        public DeleteCourceAdmin()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<DeleteCourseModel> getaccept()
        {
            var StudentData = client.Child("acceptDeleteToAhmad").AsObservable<DeleteCourseModel>().AsObservableCollection();

            return StudentData;


            
        }
        public async Task DeletrOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrAhmadDeleteaccept").OnceAsync<DeleteCourseModel>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrAhmadDeleteaccept").DeleteAsync();

        }
      








    }
}