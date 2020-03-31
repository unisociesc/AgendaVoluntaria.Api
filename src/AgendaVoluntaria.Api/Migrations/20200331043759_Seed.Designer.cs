﻿// <auto-generated />
using System;
using AgendaVoluntaria.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgendaVoluntaria.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200331043759_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVolunteer")
                        .HasColumnType("uuid");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdShift");

                    b.HasIndex("IdVolunteer");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Psico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Psicos");
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MaxVolunteer")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                            CreateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ghmeyer0@gmail.com",
                            Name = "Gabriel Helko Meyer",
                            Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600",
                            Role = "admin",
                            UpdateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"),
                            CreateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ricardo.pfitscher@unisociesc.com.br",
                            Name = "Ricardo Pfitscher",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            Role = "admin",
                            UpdateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1e9e0000-6d1c-bc1b-eb06-08d7d524408d"),
                            CreateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eslin@eslin.com",
                            Name = "Éslin Makicine Martins",
                            Password = "abad878fb17fb8710d8ac8c4612f379ee0ff9a0ad530bbe9729b7256f178f7bd",
                            Role = "admin",
                            UpdateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3a480000-248f-9e93-51c3-08d7d5261675"),
                            CreateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johnnyrtrentin@gmail.com",
                            Name = "johnny",
                            Password = "98bb0701a145990b4f0e0880398010d97c3d24eb189e8c80f818f6bc062a86d0",
                            Role = "admin",
                            UpdateAt = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid");

                    b.Property<bool>("NeedPsico")
                        .HasColumnType("boolean");

                    b.Property<int>("Ra")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Volunteers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("60180000-5e87-f520-b74d-08d7d52122bd"),
                            Course = "Engenharia",
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdUser = new Guid("95cf0000-dbca-d9ec-3724-08d7d51e7020"),
                            NeedPsico = false,
                            Ra = 121815278,
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.VolunteerShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdVolunteer")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdShift");

                    b.HasIndex("IdVolunteer");

                    b.ToTable("VolunteerShifts");
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Attendance", b =>
                {
                    b.HasOne("AgendaVoluntaria.Api.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("IdShift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaVoluntaria.Api.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("IdVolunteer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Psico", b =>
                {
                    b.HasOne("AgendaVoluntaria.Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.Volunteer", b =>
                {
                    b.HasOne("AgendaVoluntaria.Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaVoluntaria.Api.Models.VolunteerShift", b =>
                {
                    b.HasOne("AgendaVoluntaria.Api.Models.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("IdShift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgendaVoluntaria.Api.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("IdVolunteer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
