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
    class StudentDB
    {
        FirebaseClient client;

        public StudentDB()
        {
            client = new FirebaseClient("https://capregestration-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Student> GetStudents()
        {
            var TraineeData = client.Child("Student").AsObservable<Student>().AsObservableCollection();
            return TraineeData;
        }



        


        public async Task AddStudents( string name, string email , string password, int studentNumber)
        {
           


            Student c =new Student()
            {
                
                Name = name,
                Email = email, 
                Password = password,
                StudentNumber = studentNumber

            };
            await client.Child("Student").PostAsync(c);
    }



}
}
