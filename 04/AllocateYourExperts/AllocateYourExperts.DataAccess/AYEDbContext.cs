using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.DataAccess
{
    public class AYEDbContext : DbContext
    {
        public AYEDbContext(DbContextOptions<AYEDbContext> options)
            : base(options)
        {

        }

        public DbSet<Expert> Experts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectExpertRole>().HasKey(pe => new { pe.ExpertId, pe.ProjectId, pe.RoleId });

            builder.Entity<Expert>().HasData(
                new Expert()
                {
                    Id = Guid.Parse("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                    FirstName = "Christian",
                    LastName = "Griffin",
                    Email = "chrille@somemail.com",
                    Gender = "Male"
                },
                new Expert()
                {
                    Id = Guid.Parse("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                    FirstName = "Mirela",
                    LastName = "Flummoic",
                    Email = "lela@somemail.com",
                    Gender = "Female"
                },
                new Expert()
                {
                    Id = Guid.Parse("28e9d5c5-623d-4d9d-94bc-c03891384daa"),
                    FirstName = "Anton",
                    LastName = "Andersson",
                    Email = "anton@somemail.com",
                    Gender = "Male"
                },
                new Expert()
                {
                    Id = Guid.Parse("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                    FirstName = "Lena",
                    LastName = "Tapper",
                    Email = "lena@somemail.com",
                    Gender = "Female"
                },
                new Expert()
                {
                    Id = Guid.Parse("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                    FirstName = "Håkan",
                    LastName = "Fridolfsson",
                    Email = "hakan@somemail.com",
                    Gender = "Male"

                },
                new Expert()
                {
                    Id = Guid.Parse("91f29e45-000a-46c4-93ac-bf50d6bb6164"),
                    FirstName = "Josefine",
                    LastName = "Flygmaskin",
                    Email = "jossan@somemail.com",
                    Gender = "Female"
                },
                new Expert()
                {
                    Id = Guid.Parse("603212be-05a5-4ea3-956d-94b83438fd8a"),
                    FirstName = "Henrik",
                    LastName = "Holmqvist",
                    Email = "henke@somemail.com",
                    Gender = "Male"
                },
                new Expert()
                {
                    Id = Guid.Parse("a5794b8e-4dca-4b3b-8691-351c76740826"),
                    FirstName = "Veronica",
                    LastName = "Molin",
                    Email = "virre@somemail.com",
                    Gender = "Female"
                },
                new Expert()
                {
                    Id = Guid.Parse("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                    FirstName = "Robin",
                    LastName = "Törna",
                    Email = "robin@somemail.com",
                    Gender = "Male"
                },
                 new Expert()
                 {
                     Id = Guid.Parse("f066fcbb-ebd2-4018-a38c-56e5b02047bd"),
                     FirstName = "Jonas",
                     LastName = "Argman",
                     Email = "jonas@somemail.com",
                     Gender = "Male"
                 }
                );

            builder.Entity<Project>().HasData(
                new Project()
                {
                    Id = Guid.Parse("81e6357e-f10e-4019-af7b-7f0141306166"),
                    Name = "Project 1",
                    StartDate = DateTime.Parse("2018-06-01"),
                    EndDate = DateTime.Parse("2019-05-01"),
                    IsActive = false,
                    IsCompleted = true
                },
                new Project()
                {
                    Id = Guid.Parse("1e4d6c43-7998-4f94-a06c-1db42db4cc55"),
                    Name = "Project 2",
                    StartDate = DateTime.Parse("2019-07-01"),
                    EndDate = DateTime.Parse("2020-01-01"),
                    IsActive = true,
                    IsCompleted = false
                },
                new Project()
                {
                    Id = Guid.Parse("e7819413-0aa7-4885-b45e-d3a8ecbc4339"),
                    Name = "Project 3",
                    StartDate = DateTime.Parse("2019-11-01"),
                    EndDate = DateTime.Parse("2020-11-01"),
                    IsActive = true,
                    IsCompleted = false
                },
                 new Project()
                 {
                     Id = Guid.Parse("08271ef0-710d-4208-8ae0-bffc5d5a07cd"),
                     Name = "Project 4",
                     StartDate = DateTime.Parse("2019-11-18"),
                     EndDate = DateTime.Parse("2020-12-01"),
                     IsActive = true,
                     IsCompleted = false
                 }
                );

            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("757e44bb-84a9-4457-adc1-85d3a323ffb0"),
                    Name = "Leader"
                },
                 new Role()
                 {
                     Id = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"),
                     Name = "Member"
                 }
                );

            builder.Entity<ProjectExpertRole>().HasData(
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("81e6357e-f10e-4019-af7b-7f0141306166"), // Project 1
                    ExpertId = Guid.Parse("c94570ab-a13b-45f6-aec1-fc4994f7da17"), // Christian
                    RoleId = Guid.Parse("757e44bb-84a9-4457-adc1-85d3a323ffb0"), // Leader
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("81e6357e-f10e-4019-af7b-7f0141306166"), // Project 1
                    ExpertId = Guid.Parse("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"), // Lena
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"),  // Member
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("81e6357e-f10e-4019-af7b-7f0141306166"), // Project 1
                    ExpertId = Guid.Parse("603212be-05a5-4ea3-956d-94b83438fd8a"), // Henrik
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"), // Member
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), // Project2
                    ExpertId = Guid.Parse("a5794b8e-4dca-4b3b-8691-351c76740826"), // Veronica
                    RoleId = Guid.Parse("757e44bb-84a9-4457-adc1-85d3a323ffb0"), // Leader
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), // Project 2
                    ExpertId = Guid.Parse("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), // Håkan
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"),  // Member
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("1e4d6c43-7998-4f94-a06c-1db42db4cc55"), // Project 2
                    ExpertId = Guid.Parse("0023e810-eb0a-4309-9b9a-55f4656cddb4"), // Robin
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"), // Member
                },
                new ProjectExpertRole()
                {
                    ProjectId = Guid.Parse("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), // Project 3
                    ExpertId = Guid.Parse("e0a47365-6e76-4ed8-9504-7bee877a31d5"), // Mirela
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"), // Member
                },
                new ProjectExpertRole() 
                {
                    ProjectId = Guid.Parse("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), // Project 3
                    ExpertId = Guid.Parse("c94570ab-a13b-45f6-aec1-fc4994f7da17"), // Christian
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"),  // Member
                },
                 new ProjectExpertRole()
                 {
                     ProjectId = Guid.Parse("e7819413-0aa7-4885-b45e-d3a8ecbc4339"), // Project 3
                     ExpertId = Guid.Parse("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"), // Håkan
                     RoleId = Guid.Parse("757e44bb-84a9-4457-adc1-85d3a323ffb0"),  // Leader
                 },
                 new ProjectExpertRole()
                 {
                     ProjectId = Guid.Parse("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), // Project 4
                     ExpertId = Guid.Parse("c94570ab-a13b-45f6-aec1-fc4994f7da17"), // Christian
                     RoleId = Guid.Parse("757e44bb-84a9-4457-adc1-85d3a323ffb0"),  // Leader
                 },
                 new ProjectExpertRole()
                 {
                     ProjectId = Guid.Parse("08271ef0-710d-4208-8ae0-bffc5d5a07cd"), // Project 4
                     ExpertId = Guid.Parse("f066fcbb-ebd2-4018-a38c-56e5b02047bd"), // Jonas
                     RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475"),  // Member
                 }                 
                );
         
        }
    }
}
