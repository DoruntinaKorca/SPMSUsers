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
        /*
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
                        ParentName = "Januz",
                        Surname = "Korca",
                        DateOfBirth = DateTime.Parse("1998-11-11"),

                    },
                     new User{
                        UserName="RilindB",
                        Email="rb47139@ubt-uni.net"
                    },
                      new User{
                        UserName="EndritM",
                        Email="em47593@ubt-uni.net"
                      }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$word1");
                }


                await context.SaveChangesAsync();

            }

        }*/
    }
}
