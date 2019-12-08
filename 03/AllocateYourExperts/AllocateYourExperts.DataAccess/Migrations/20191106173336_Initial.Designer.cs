﻿// <auto-generated />
using System;
using AllocateYourExperts.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllocateYourExperts.DataAccess.Migrations
{
    [DbContext(typeof(AYEDbContext))]
    [Migration("20191106173336_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllocateYourExperts.DataAccess.Expert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                            Name = "Christian"
                        },
                        new
                        {
                            Id = new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                            Name = "Mirela"
                        },
                        new
                        {
                            Id = new Guid("28e9d5c5-623d-4d9d-94bc-c03891384daa"),
                            Name = "Anton"
                        },
                        new
                        {
                            Id = new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                            Name = "Lena"
                        },
                        new
                        {
                            Id = new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                            Name = "Håkan"
                        },
                        new
                        {
                            Id = new Guid("91f29e45-000a-46c4-93ac-bf50d6bb6164"),
                            Name = "Josefine"
                        },
                        new
                        {
                            Id = new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"),
                            Name = "Henrik"
                        },
                        new
                        {
                            Id = new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"),
                            Name = "Veronica"
                        },
                        new
                        {
                            Id = new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                            Name = "Robin"
                        });
                });

            modelBuilder.Entity("AllocateYourExperts.DataAccess.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81e6357e-f10e-4019-af7b-7f0141306166"),
                            EndDate = new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            Name = "Project 1",
                            StartDate = new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"),
                            EndDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "Project 2",
                            StartDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"),
                            EndDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "Project 3",
                            StartDate = new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AllocateYourExperts.DataAccess.ProjectExpertRole", b =>
                {
                    b.Property<Guid>("ExpertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExpertId", "ProjectId", "RoleId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.ToTable("ProjectExpertRole");

                    b.HasData(
                        new
                        {
                            ExpertId = new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                            ProjectId = new Guid("81e6357e-f10e-4019-af7b-7f0141306166"),
                            RoleId = new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0")
                        },
                        new
                        {
                            ExpertId = new Guid("fa1a4754-9dc6-4ecc-8cef-61f9624249bb"),
                            ProjectId = new Guid("81e6357e-f10e-4019-af7b-7f0141306166"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        },
                        new
                        {
                            ExpertId = new Guid("603212be-05a5-4ea3-956d-94b83438fd8a"),
                            ProjectId = new Guid("81e6357e-f10e-4019-af7b-7f0141306166"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        },
                        new
                        {
                            ExpertId = new Guid("a5794b8e-4dca-4b3b-8691-351c76740826"),
                            ProjectId = new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"),
                            RoleId = new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0")
                        },
                        new
                        {
                            ExpertId = new Guid("3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be"),
                            ProjectId = new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        },
                        new
                        {
                            ExpertId = new Guid("0023e810-eb0a-4309-9b9a-55f4656cddb4"),
                            ProjectId = new Guid("1e4d6c43-7998-4f94-a06c-1db42db4cc55"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        },
                        new
                        {
                            ExpertId = new Guid("e0a47365-6e76-4ed8-9504-7bee877a31d5"),
                            ProjectId = new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        },
                        new
                        {
                            ExpertId = new Guid("c94570ab-a13b-45f6-aec1-fc4994f7da17"),
                            ProjectId = new Guid("e7819413-0aa7-4885-b45e-d3a8ecbc4339"),
                            RoleId = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475")
                        });
                });

            modelBuilder.Entity("AllocateYourExperts.DataAccess.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("757e44bb-84a9-4457-adc1-85d3a323ffb0"),
                            Name = "Leader"
                        },
                        new
                        {
                            Id = new Guid("c0aa725f-3804-4fe9-a51f-74c3e7780475"),
                            Name = "Member"
                        });
                });

            modelBuilder.Entity("AllocateYourExperts.DataAccess.ProjectExpertRole", b =>
                {
                    b.HasOne("AllocateYourExperts.DataAccess.Expert", "Expert")
                        .WithMany("ExpertProjects")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllocateYourExperts.DataAccess.Project", "Project")
                        .WithMany("ProjectExperts")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllocateYourExperts.DataAccess.Role", "Role")
                        .WithMany("ProjectExpertRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
