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
    public class RegisterCourceAdmin
    {
        FirebaseClient client;

        public RegisterCourceAdmin()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<CourseRegisterModel> getaccept()
        {
            var StudentData = client.Child("acceptregistrationToAhmad").AsObservable<CourseRegisterModel>().AsObservableCollection();

            return StudentData;



        }
        public async Task DeletrOrder(string studentNumber)
        {
            var toDeleteOrder = (await client.Child("DrAhmadacceptRegister").OnceAsync<CourseRegisterModel>()).FirstOrDefault(order => order.Object.StudentNumber == studentNumber);

            await client.Child("DrAhmadacceptRegister").DeleteAsync();

        }
      








    }
}