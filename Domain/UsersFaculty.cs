using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsersFaculty
    {

        public int FacultyID { get; set; }
        public Guid UserID { get; set; }

        public User User { get; set; }

      
    }
}
