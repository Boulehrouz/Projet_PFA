﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet_PFA.Models;

#nullable disable

namespace Projet_PFA.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230511131532_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserAuthentifierSequence");

            modelBuilder.Entity("Projet_PFA.Models.Absence", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int?>("SuperviseurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("SuperviseurId");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("Projet_PFA.Models.HeuresSupp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Duree")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("SuperviseurId")
                        .HasColumnType("int");

                    b.Property<string>("Unitee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("SuperviseurId");

                    b.ToTable("HeuresSupp");
                });

            modelBuilder.Entity("Projet_PFA.Models.Penalite", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<float>("Sanction")
                        .HasColumnType("real");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Penalite");
                });

            modelBuilder.Entity("Projet_PFA.Models.Pointage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HeureEntree")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HeureSortie")
                        .HasColumnType("datetime2");

                    b.Property<int>("SuperviseurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("SuperviseurId");

                    b.ToTable("Pointage");
                });

            modelBuilder.Entity("Projet_PFA.Models.Retard", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Duree")
                        .HasColumnType("int");

                    b.Property<int?>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int?>("SuperviseurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("SuperviseurId");

                    b.ToTable("Retard");
                });

            modelBuilder.Entity("Projet_PFA.Models.Supplementaire", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<float>("Prime")
                        .HasColumnType("real");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplementaire");
                });

            modelBuilder.Entity("Projet_PFA.Models.UserAuthentifier", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserAuthentifierSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int?>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateNaissance")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RIB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Salaire")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAuthentifier");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Projet_PFA.Models.Directeur", b =>
                {
                    b.HasBaseType("Projet_PFA.Models.UserAuthentifier");

                    b.ToTable("Directeur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Employer", b =>
                {
                    b.HasBaseType("Projet_PFA.Models.UserAuthentifier");

                    b.Property<int?>("SuperviseurId")
                        .HasColumnType("int");

                    b.HasIndex("SuperviseurId");

                    b.ToTable("Employer");
                });

            modelBuilder.Entity("Projet_PFA.Models.Superviseur", b =>
                {
                    b.HasBaseType("Projet_PFA.Models.UserAuthentifier");

                    b.Property<int>("DirecteurId")
                        .HasColumnType("int");

                    b.Property<int>("SubstitutionId")
                        .HasColumnType("int");

                    b.HasIndex("DirecteurId");

                    b.HasIndex("SubstitutionId");

                    b.ToTable("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Absence", b =>
                {
                    b.HasOne("Projet_PFA.Models.Employer", "Employer")
                        .WithMany("Absences")
                        .HasForeignKey("EmployerId");

                    b.HasOne("Projet_PFA.Models.Superviseur", "Superviseur")
                        .WithMany("Absences")
                        .HasForeignKey("SuperviseurId");

                    b.Navigation("Employer");

                    b.Navigation("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.HeuresSupp", b =>
                {
                    b.HasOne("Projet_PFA.Models.Employer", "Employer")
                        .WithMany("HeuresSupps")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet_PFA.Models.Superviseur", "Superviseur")
                        .WithMany("HeuresSupps")
                        .HasForeignKey("SuperviseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Pointage", b =>
                {
                    b.HasOne("Projet_PFA.Models.Employer", "Employer")
                        .WithMany("Pointages")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet_PFA.Models.Superviseur", "Superviseur")
                        .WithMany("Pointages")
                        .HasForeignKey("SuperviseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Retard", b =>
                {
                    b.HasOne("Projet_PFA.Models.Employer", "Employer")
                        .WithMany("Retards")
                        .HasForeignKey("EmployerId");

                    b.HasOne("Projet_PFA.Models.Superviseur", "Superviseur")
                        .WithMany("Retards")
                        .HasForeignKey("SuperviseurId");

                    b.Navigation("Employer");

                    b.Navigation("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Employer", b =>
                {
                    b.HasOne("Projet_PFA.Models.Superviseur", "Superviseur")
                        .WithMany("Employers")
                        .HasForeignKey("SuperviseurId");

                    b.Navigation("Superviseur");
                });

            modelBuilder.Entity("Projet_PFA.Models.Superviseur", b =>
                {
                    b.HasOne("Projet_PFA.Models.Directeur", "Directeur")
                        .WithMany("Superviseurs")
                        .HasForeignKey("DirecteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet_PFA.Models.Superviseur", "substitution")
                        .WithMany()
                        .HasForeignKey("SubstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Directeur");

                    b.Navigation("substitution");
                });

            modelBuilder.Entity("Projet_PFA.Models.Directeur", b =>
                {
                    b.Navigation("Superviseurs");
                });

            modelBuilder.Entity("Projet_PFA.Models.Employer", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("HeuresSupps");

                    b.Navigation("Pointages");

                    b.Navigation("Retards");
                });

            modelBuilder.Entity("Projet_PFA.Models.Superviseur", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Employers");

                    b.Navigation("HeuresSupps");

                    b.Navigation("Pointages");

                    b.Navigation("Retards");
                });
#pragma warning restore 612, 618
        }
    }
}