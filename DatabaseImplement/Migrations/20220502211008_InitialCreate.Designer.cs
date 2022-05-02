﻿// <auto-generated />
using System;
using DatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseImplement.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220502211008_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatabaseImplement.Models.Cure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cures");
                });

            modelBuilder.Entity("DatabaseImplement.Models.DiseaseStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CureId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfApplication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfRecovery")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CureId");

                    b.HasIndex("PatientId");

                    b.ToTable("DiseaseStories");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DatabaseImplement.Models.DiseaseStory", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Cure", "Cure")
                        .WithMany("DiseaseStories")
                        .HasForeignKey("CureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseImplement.Models.Patient", "Patient")
                        .WithMany("DiseaseStories")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cure");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Patient", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Cure", b =>
                {
                    b.Navigation("DiseaseStories");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Doctor", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Patient", b =>
                {
                    b.Navigation("DiseaseStories");
                });
#pragma warning restore 612, 618
        }
    }
}
