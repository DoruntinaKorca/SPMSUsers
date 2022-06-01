using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PersonalProfileDto
    {
        public Guid Id { get; set; }

        public String Name { get; set; }


 
        public String ParentName { get; set; }


        public String Surname { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        public int AddressId { get; set; }

        public String ProfilePictureURL { get; set; }
        
        public String Gender { get; set; }

        public  String Street { get; set; }
       public String City { get; set; }
        public String CityCategory { get; set; }
       public String Country { get; set; }


        public int PersonalNumber { get; set; }

     //   public City City { get; set; }

        public DateTime DateRegistered { get; set; }

      //  public virtual Street Address { get; set; }
    }
}
