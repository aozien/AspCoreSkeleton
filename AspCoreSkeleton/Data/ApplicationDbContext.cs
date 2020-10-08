using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspCoreSkeletonZien.Models.Entities;
using AspCoreSkeletonZien.Models.Enums;

namespace AspCoreSkeletonZien.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /********************** Seeding the database ***************************/

            /*** Admin ***/
            string adminId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new List<IdentityUser> {
                new IdentityUser
                {
                    Id = adminId, // primary key
                    UserName = "admin@domain.com",
                    Email = "admin@domain.com",
                    NormalizedUserName = "ADMIN@DOMAIN.COM",
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    SecurityStamp = "SecurityStamp"
                }
            }.ToArray());

            /** Countries **/
            builder.Entity<Country>().HasData(new List<Country> {
                new Country { Id = 1, Name = "Egypt" },
                new Country { Id = 2, Name = "France" },
                new Country { Id = 3, Name = "United States" },

            }.ToArray());

            /** Cities **/
            builder.Entity<City>().HasData(new List<City> {
                new City { Id = 1, Name = "Cairo" , CountryId = 1},
                new City { Id = 2, Name = "Giza"  , CountryId = 1},
                new City { Id = 3, Name = "Alexandria"  , CountryId = 1},

                new City { Id = 4, Name = "Paris"  , CountryId = 2},
                new City { Id = 5, Name = "Lion"  , CountryId = 2},
                new City { Id = 6, Name = "Nice"  , CountryId = 2},


                new City { Id = 7, Name = "Alaska"  , CountryId = 3},
                new City { Id = 8, Name = "Texas"  , CountryId = 3},
                new City { Id = 9, Name = "California"  , CountryId = 3},


            }.ToArray());

            /** Cities **/
            builder.Entity<Member>().HasData(new List<Member> {
                new Member {
                    Id = 1,
                    FirstName="John",
                    LastName="Doe",
                    DateOfBirth=new DateTime(1990,11,4),
                    PhoneNumber="+20110000000",
                    CityId = 1,
                    EmailAddress= "email@domain.com",
                    Gender=Gender.Male,
                    MemberStatus = true,
                    UserProfileImage= "profile.jpg",
                    Notes ="Very Active member",
                },



            }.ToArray()); ;



        }

    }
}
