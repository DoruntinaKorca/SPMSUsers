using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GeneralUserResponse
    {
        public Guid Id { get; set; }

        public String FirstName { get; set; }

        public String Email { get; set; }

        public String ParentName { get; set; }


        public String Surname { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        public String AddressDetails { get; set; }


        public String ProfilePictureURL { get; set; }
        
        public String Gender { get; set; }

      //  public  String Street { get; set; }
       public CityDto City { get; set; }
      //  public CityCategory CityCategory { get; set; }
       public CountryDto Country { get; set; }


        public int PersonalNumber { get; set; }

        public String PhoneNumber { get; set; }

        //   public City City { get; set; }

        public DateTime DateRegistered { get; set; }

        //  public virtual Street Address { get; set; }

       // public Guid RoleId { get; set; }

        public RoleDto Role { get; set; }

        //   public String RoleName { get; set; }
    }
}
