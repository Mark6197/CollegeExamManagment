﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Shared;

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDomainDbContext))]
    [Migration("20210116182408_ChangedQuestionAndAnswerTextToNotNull")]
    partial class ChangedQuestionAndAnswerTextToNotNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<long>("CoursesId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentsId")
                        .HasColumnType("bigint");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("Domain.Courses.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("Date");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Exams.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("AnswerNumInQuestion")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Domain.Exams.Exam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("AutoPointsCalculation")
                        .HasColumnType("bit");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("Time");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("Date");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Domain.Exams.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<int>("QuestionNumInExam")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Domain.Users.Students.Student", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<long>("StudentNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Users.Students.StudentExam", b =>
                {
                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.HasKey("StudentId", "ExamId");

                    b.HasIndex("ExamId");

                    b.ToTable("StudentExam");
                });

            modelBuilder.Entity("Domain.Users.Students.StudentQuestion", b =>
                {
                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.HasKey("StudentId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("StudentQuestion");
                });

            modelBuilder.Entity("Domain.Users.Teachers.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TeacherNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Domain.Courses.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Users.Students.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Courses.Course", b =>
                {
                    b.HasOne("Domain.Users.Teachers.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Domain.Exams.Answer", b =>
                {
                    b.HasOne("Domain.Exams.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Exams.Exam", b =>
                {
                    b.HasOne("Domain.Courses.Course", null)
                        .WithMany("Exams")
                        .HasForeignKey("CourseId");

                    b.HasOne("Domain.Users.Teachers.Teacher", null)
                        .WithMany("Exams")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Exams.Question", b =>
                {
                    b.HasOne("Domain.Exams.Exam", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Users.Students.StudentExam", b =>
                {
                    b.HasOne("Domain.Exams.Exam", null)
                        .WithMany("StudentsExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Users.Students.Student", null)
                        .WithMany("StudentsExams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Users.Students.StudentQuestion", b =>
                {
                    b.HasOne("Domain.Exams.Question", null)
                        .WithMany("StudentsQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Users.Students.Student", null)
                        .WithMany("StudentQuestion")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Courses.Course", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Domain.Exams.Exam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("StudentsExams");
                });

            modelBuilder.Entity("Domain.Exams.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("StudentsQuestions");
                });

            modelBuilder.Entity("Domain.Users.Students.Student", b =>
                {
                    b.Navigation("StudentQuestion");

                    b.Navigation("StudentsExams");
                });

            modelBuilder.Entity("Domain.Users.Teachers.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
