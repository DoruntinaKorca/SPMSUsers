using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(UsersContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User{
                        UserName="DoruntinaK",
                        Email="dk40651@ubt-uni.net",
                        Name = "Doruntina",
                        ParentName = "Jane Doe",
                        Surname = "Korca",
                        DateOfBirth = DateTime.Parse("1998-11-11"),
                        AddressId = 1,
                        ProfilePictureURL = null,
                        Gender = "Female",
                        PersonalNumber = 12345678,
                        DateRegistered = DateTime.Parse("2019-09-09"),
                        Address = null
                    },
                     new User{
                        UserName="EndritM",
                        Email="em47593@ubt-uni.net",
                        Name = "Endrit",
                        ParentName = "John Doe",
                        Surname = "Makolli",
                        DateOfBirth = DateTime.Parse("2001-02-02"),
                        AddressId = 2,
                        ProfilePictureURL = null,
                        Gender = "Male",
                        PersonalNumber = 12345648,
                        DateRegistered = DateTime.Parse("2019-10-09"),
                        Address = null
                    },
                      new User{
                        UserName="RilindB",
                        Email="rb47139@ubt-uni.net",
                        Name = "Rilind",
                        ParentName = "John Doe",
                        Surname = "Bicaj",
                        DateOfBirth = DateTime.Parse("2001-12-12"),
                        AddressId = 3,
                        ProfilePictureURL = null,
                        Gender = "Male",
                        PersonalNumber = 34920392,
                        DateRegistered = DateTime.Parse("2019-09-09"),
                        Address = null
                    },
                       new User{
                        UserName="MedinaSh",
                        Email="medina.shamolli@ubt-uni.net",
                        Name = "Medina",
                        ParentName = "John Doe",
                        Surname = "Shamolli",
                        DateOfBirth = DateTime.Parse("1994-11-11"),
                        AddressId = 1,
                        ProfilePictureURL = null,
                        Gender = "Female",
                        PersonalNumber = 10293322,
                        DateRegistered = DateTime.Parse("2014-09-09"),
                        Address = null
                    },
                        new User{
                        UserName="RamizH",
                        Email="Ramiz.hoxha@ubt-uni.net",
                        Name = "Ramiz",
                        ParentName = "John Doe",
                        Surname = "Hoxha",
                        DateOfBirth = DateTime.Parse("1975-09-09"),
                        AddressId = 2,
                        ProfilePictureURL = null,
                        Gender = "Male",
                        PersonalNumber = 29345534,
                        DateRegistered = DateTime.Parse("2002-09-09"),
                        Address = null
                    },
                         new User{
                        UserName="Skender",
                        Email="skender.doe@ubt-uni.net",
                        Name = "Skender",
                        ParentName = "John Doe",
                        Surname = "Doe",
                        DateOfBirth = DateTime.Parse("1988-02-11"),
                        AddressId = 3,
                        ProfilePictureURL = null,
                        Gender = "Male",
                        PersonalNumber = 39443443,
                        DateRegistered = DateTime.Parse("2012-09-09"),
                        Address = null
                    },
                          new User{
                        UserName="ArberK",
                        Email="arber.kadriu@ubt-uni.net",
                        Name = "Arber",
                        ParentName = "John Doe",
                        Surname = "Kadriu",
                        DateOfBirth = DateTime.Parse("1997-03-11"),
                        AddressId = 1,
                        ProfilePictureURL = null,
                        Gender = "Male",
                        PersonalNumber = 93443232,
                        DateRegistered = DateTime.Parse("2016-09-09"),
                        Address = null
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$word1");
                }


                await context.SaveChangesAsync();

            }

        }
    }
}
