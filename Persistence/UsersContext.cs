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

      

        public DbSet<AcademicStaff> AcademicStaffs { get; set; }

        //public DbSet<Photo> Photos { get; set; }
        public DbSet<AdministrativeStaff> AdministrativeStaffs { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<CityCategory> CityCategories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Generation> Generations { get; set; }

        public DbSet<StudentsLectureGroup> StudentsLectureGroups { get; set; }

        public DbSet<LectureGroup> LectureGroups { get; set; }

        public DbSet<StudentsSpecialization> StudentsSpecializations { get; set; }

        //    public DbSet<Role> Roless { get; set; }
        //public DbSet<Street> Streets { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<UsersFaculty> UsersFaculties { get; set; }

       public DbSet<AcademicLevel> AcademicLevels { get; set; }

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
                    .HasConstraintName("sssss")
                    .OnDelete(DeleteBehavior.Cascade);

              //  ac.Property(e => e.AcademicStaffId).ValueGeneratedNever();

                ac.HasOne(d => d.User)
                .WithOne(p => p.AcademicStaff)
                .HasForeignKey<AcademicStaff>(d => d.AcademicStaffId)
                .HasConstraintName("userAcademicStaff")
                 .OnDelete(DeleteBehavior.Cascade);
            });
                
           
            //administrative staff

            builder.Entity<AdministrativeStaff>()
                .HasOne(d => d.User)
                .WithOne(p => p.AdministrativeStaff)
                .HasForeignKey<AdministrativeStaff>(d => d.AdministrativeStaffId)
                .HasConstraintName("userAdministrativeStaff")
                 .OnDelete(DeleteBehavior.Cascade);


            //student
            builder.Entity<Student>(us =>
            {
                us.HasOne(g => g.Generation)
                    .WithMany(s => s.Students)
                    .HasForeignKey(fk => fk.GenerationId)
                    .HasConstraintName("Student_Generation")
                    .OnDelete(DeleteBehavior.Cascade);

                us.HasOne(d => d.User)
                .WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .HasConstraintName("UserStudentISA")
                 .OnDelete(DeleteBehavior.Cascade);
            });
                

            //user 
            builder.Entity<User>()
               .HasOne(s => s.City)
               .WithMany(u => u.Users)
               .HasForeignKey(fk => fk.CityId)
               .HasConstraintName("City_users")
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
               .HasOne(s => s.Student)
               .WithOne(u => u.User);


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
                .HasConstraintName("CityCategory_Cities")
                .OnDelete(DeleteBehavior.Cascade);

                y.HasOne(c => c.Country)
                .WithMany(cit => cit.Cities)
                .HasForeignKey(fk => fk.CountryId)
                .HasConstraintName("Country_Cities")
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
                .HasConstraintName("User_UsersFaculites")
                .HasForeignKey(fk => fk.UserID);



            //StudentsLectureGroup
            builder.Entity<StudentsLectureGroup>(x => x.HasKey(s => new { s.StudentId, s.LectureGroupId }));

            builder.Entity<StudentsLectureGroup>()
                .HasOne(u => u.Student)
                .WithMany(uf => uf.LectureGroups)
                .HasConstraintName("Student_LectureGroup")
                .HasForeignKey(fk => fk.StudentId);

      


            //StudentsSpecialization
            builder.Entity<StudentsSpecialization>(x => x.HasKey(s => new { s.StudentId, s.SpecializationId }));

            builder.Entity<StudentsSpecialization>()
                .HasOne(u => u.Student)
                .WithMany(uf => uf.Specializations)
                .HasConstraintName("Student_Specializations")
                .HasForeignKey(fk => fk.StudentId);


        }
    }
}
