using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using App52.ModelView;

namespace App52.Model
{
    public class ChangeCourseTime
    {


        public string SName { get; set; } 
        public int snum { get; set; }
        public string description { get; set; }

     
        public int cnum { get; set; }

        public int currentDivision { get; set; }
        public int newDivision { get; set; }



    }
}
