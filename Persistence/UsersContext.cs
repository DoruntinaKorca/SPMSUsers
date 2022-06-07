using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UsersContext : IdentityDbContext<User, IdentityRole<Guid>,Guid>
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

       // public DbSet<User> Users { get; set; }

        public DbSet<AcademicLevel> AcademicLevels { get; set; }

        public DbSet<AcademicStaff> AcademicStaffs { get; set; }

        public DbSet<AdministrativeStaff> AdministrativeStaffs { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<CityCategory> CityCategories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Generation> Generations { get; set; }

    //    public DbSet<Role> Roless { get; set; }
        //public DbSet<Street> Streets { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<UsersFaculty> UsersFaculties { get; set; }

        //     public DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //academic staff
            builder.Entity<AcademicStaff>(ac =>
            {
                ac.HasOne(al => al.AcademicLevel)
                    .WithMany(a => a.AcademicStaff)
                    .HasForeignKey(fk => fk.AcademicLevelId)
                    .OnDelete(DeleteBehavior.Cascade);

                ac.Property(e => e.AcademicStaffId).ValueGeneratedNever();

                ac.HasOne(d => d.User)
                .WithOne(p => p.AcademicStaff)
                .HasForeignKey<AcademicStaff>(d => d.AcademicStaffId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
                

            //administrative staff

            builder.Entity<AdministrativeStaff>()
                .HasOne(d => d.User)
                .WithOne(p => p.AdministrativeStaff)
                .HasForeignKey<AdministrativeStaff>(d => d.AdministrativeStaffId)
                 .OnDelete(DeleteBehavior.Cascade);


            //student
            builder.Entity<Student>(us =>
            {
                us.HasOne(g => g.Generation)
                    .WithMany(s => s.Students)
                    .HasForeignKey(fk => fk.GenerationId)
                    .OnDelete(DeleteBehavior.Cascade);

                us.HasOne(d => d.User)
                .WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
                

            //user 
            builder.Entity<User>()
               .HasOne(s => s.City)
               .WithMany(u => u.Users)
               .HasForeignKey(fk => fk.CityId)
               .OnDelete(DeleteBehavior.Cascade);

    


            //usersRole
            /*
            builder.Entity<UsersRoles>(x => {
            x.HasKey(ur => new { ur.RoleId, ur.UserId });

                x.HasOne(u => u.User)
               .WithMany(r => r.Roles)
               .HasForeignKey(fk => fk.UserId);

                x.HasOne(r => r.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(fk => fk.RoleId);

            });



*/


            //City

            builder.Entity<City>(y=> { 
            
            y.HasOne(c => c.CityCategory)
                .WithMany(cr => cr.Cities)
                .HasForeignKey(fk => fk.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

                y.HasOne(c => c.Country)
                .WithMany(cit => cit.Cities)
                .HasForeignKey(fk => fk.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
            });





            //street
            /*
            builder.Entity<Street>()
                .HasOne(c => c.City)
                .WithMany(s => s.Streets)
                .HasForeignKey(fk => fk.CityId)
                .OnDelete(DeleteBehavior.Cascade); */

            //UsersFaculty
            builder.Entity<UsersFaculty>(x => x.HasKey(u => new { u.UserID,u.FacultyID }));

            builder.Entity<UsersFaculty>()
                .HasOne(u=>u.User)
                .WithMany(uf=>uf.UsersFaculties)
                .HasForeignKey(fk => fk.UserID);

        }
    }
}
