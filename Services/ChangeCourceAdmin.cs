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
    public class ChangeCourceAdmin
    {
        FirebaseClient client;

        public ChangeCourceAdmin()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<ChangeCourseTime> getaccept()
        {
            var StudentData = client.Child("acceptChangeToAhmad").AsObservable<ChangeCourseTime>().AsObservableCollection();

            return StudentData;


            
        }
        public async Task DeletrOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrAhmadChangeaccept").OnceAsync<ChangeCourseTime>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrAhmadChangeaccept").DeleteAsync();

        }
      








    }
}