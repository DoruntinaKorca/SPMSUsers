using Application.DTOs.CityDtos;
using Application.DTOs.CountryDtos;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDtos
{
    public class GeneralUserResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string ParentName { get; set; }


        public string Surname { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string AddressDetails { get; set; }


        public string ProfilePictureURL { get; set; }

        public string Gender { get; set; }

        //  public  String Street { get; set; }
        public CityDto City { get; set; }
        //  public CityCategory CityCategory { get; set; }
        public CountryWOCityDto Country { get; set; }


        public int PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        //   public City City { get; set; }

        public DateTime DateRegistered { get; set; }

        //  public virtual Street Address { get; set; }

        // public Guid RoleId { get; set; }

        public RoleDto Role { get; set; }

        //   public String RoleName { get; set; }
    }
}
