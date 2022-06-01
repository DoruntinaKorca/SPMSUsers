using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser<Guid>
    {


   
        [Required]
        public String Name { get; set; }


        [Required]
        public String ParentName { get; set; }

        [Required]
        public String Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int AddressId { get; set; }

        public String ProfilePictureURL { get; set; }
        [Required]
        public String Gender { get; set; }

        [Required]
        public int PersonalNumber { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public virtual Student Student { get; set; }

        public virtual AcademicStaff AcademicStaff { get; set; }

        public virtual AdministrativeStaff AdministrativeStaff { get; set; }

        public virtual Street Address { get; set; }


    }

}



