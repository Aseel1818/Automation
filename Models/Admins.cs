using System;
using System.Collections.Generic;
using System.Text;

namespace App74.Models
{
    internal class Admins
    {

        public string Key { get; set; } //To Store ID
        public string CoachId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public string Phone { get; set; }
        public string Password { get; set; }

        public string City { get; set; }
        public string Course { get; set; }

        public string Text { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }

    }
}
