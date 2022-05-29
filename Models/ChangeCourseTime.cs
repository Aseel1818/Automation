using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using App74.ViewModels;

namespace App74.Models
{
    public class ChangeCourseTime
    {
        public string StudentName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public string CourseNumber { get; set; }
        public string CurrentDivision { get; set; }
        public string NewDivision { get; set; }
        public string Notification { get; set; }


    }
}