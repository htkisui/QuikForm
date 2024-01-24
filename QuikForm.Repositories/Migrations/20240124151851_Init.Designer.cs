﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuikForm.Repositories;

#nullable disable

namespace QuikForm.Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240124151851_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuikForm.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("QuikForm.Entities.FieldRecord", b =>
                {
                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.Property<string>("CustomAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FieldId", "RecordId");

                    b.HasIndex("RecordId");

                    b.ToTable("FieldRecords");
                });

            modelBuilder.Entity("QuikForm.Entities.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("QuikForm.Entities.Input", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inputs");
                });

            modelBuilder.Entity("QuikForm.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("InputId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("InputId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuikForm.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("QuikForm.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuikForm.Entities.Field", b =>
                {
                    b.HasOne("QuikForm.Entities.Question", "Question")
                        .WithMany("Fields")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuikForm.Entities.FieldRecord", b =>
                {
                    b.HasOne("QuikForm.Entities.Field", "Field")
                        .WithMany("FieldRecords")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuikForm.Entities.Record", "Record")
                        .WithMany("FieldRecords")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("QuikForm.Entities.Form", b =>
                {
                    b.HasOne("QuikForm.Entities.User", "User")
                        .WithMany("Forms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuikForm.Entities.Question", b =>
                {
                    b.HasOne("QuikForm.Entities.Form", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuikForm.Entities.Input", "Input")
                        .WithMany("Questions")
                        .HasForeignKey("InputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Input");
                });

            modelBuilder.Entity("QuikForm.Entities.Record", b =>
                {
                    b.HasOne("QuikForm.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuikForm.Entities.Field", b =>
                {
                    b.Navigation("FieldRecords");
                });

            modelBuilder.Entity("QuikForm.Entities.Form", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("QuikForm.Entities.Input", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("QuikForm.Entities.Question", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("QuikForm.Entities.Record", b =>
                {
                    b.Navigation("FieldRecords");
                });

            modelBuilder.Entity("QuikForm.Entities.User", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
