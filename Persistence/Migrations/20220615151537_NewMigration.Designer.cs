﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20220615151537_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Domain.AcademicLevel", b =>
                {
                    b.Property<int>("AcademicLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AcademicLevelId");

                    b.ToTable("AcademicLevels");
                });

            modelBuilder.Entity("Domain.AcademicStaff", b =>
                {
                    b.Property<Guid>("AcademicStaffId")
                        .HasColumnType("TEXT");

                    b.Property<int>("AcademicLevelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AcademicStaffId");

                    b.HasIndex("AcademicLevelId");

                    b.ToTable("AcademicStaffs");
                });

            modelBuilder.Entity("Domain.AdministrativeStaff", b =>
                {
                    b.Property<Guid>("AdministrativeStaffId")
                        .HasColumnType("TEXT");

                    b.HasKey("AdministrativeStaffId");

                    b.ToTable("AdministrativeStaffs");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ZIPCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("CityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Domain.CityCategory", b =>
                {
                    b.Property<int>("CityCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CityCategoryId");

                    b.ToTable("CityCategories");
                });

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Generation", b =>
                {
                    b.Property<int>("GenerationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("GenerationId");

                    b.ToTable("Generations");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FileNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenerationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId");

                    b.HasIndex("GenerationId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.StudentsLectureGroup", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("LectureGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "LectureGroupId");

                    b.ToTable("StudentsLectureGroups");
                });

            modelBuilder.Entity("Domain.StudentsSpecialization", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "SpecializationId");

                    b.ToTable("StudentsSpecializations");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressDetails")
                        .HasColumnType("TEXT");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonalNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.UsersFaculty", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserID", "FacultyID");

                    b.ToTable("UsersFaculties");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.AcademicStaff", b =>
                {
                    b.HasOne("Domain.AcademicLevel", "AcademicLevel")
                        .WithMany("AcademicStaff")
                        .HasForeignKey("AcademicLevelId")
                        .HasConstraintName("staffLevel_Academic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithOne("AcademicStaff")
                        .HasForeignKey("Domain.AcademicStaff", "AcademicStaffId")
                        .HasConstraintName("userAcademicStaff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicLevel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.AdministrativeStaff", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithOne("AdministrativeStaff")
                        .HasForeignKey("Domain.AdministrativeStaff", "AdministrativeStaffId")
                        .HasConstraintName("userAdministrativeStaff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.HasOne("Domain.CityCategory", "CityCategory")
                        .WithMany("Cities")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("CityCategory_Cities")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("Country_Cities")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityCategory");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.Generation", "Generation")
                        .WithMany("Students")
                        .HasForeignKey("GenerationId")
                        .HasConstraintName("Student_Generation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("Domain.Student", "StudentId")
                        .HasConstraintName("UserStudentISA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.StudentsLectureGroup", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany("LectureGroups")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("Student_LectureGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.StudentsSpecialization", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany("Specializations")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("Student_Specializations")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .HasConstraintName("City_users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.UsersFaculty", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("UsersFaculties")
                        .HasForeignKey("UserID")
                        .HasConstraintName("User_UsersFaculites")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AcademicLevel", b =>
                {
                    b.Navigation("AcademicStaff");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.CityCategory", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Generation", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Navigation("LectureGroups");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("AcademicStaff");

                    b.Navigation("AdministrativeStaff");

                    b.Navigation("Student");

                    b.Navigation("UsersFaculties");
                });
#pragma warning restore 612, 618
        }
    }
}
