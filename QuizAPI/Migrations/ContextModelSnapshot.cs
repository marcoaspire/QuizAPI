﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAPI.Models;

namespace QuizAPI.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("QuizAPI.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<string>("PosibleAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("AnswerID");

                    b.HasIndex("QuestionID");

                    b.ToTable("tbl_answers");
                });

            modelBuilder.Entity("QuizAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryID");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("tbl_categories");
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.HasIndex("CategoryID");

                    b.ToTable("tbl_questions");
                });

            modelBuilder.Entity("QuizAPI.Models.Answer", b =>
                {
                    b.HasOne("QuizAPI.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.HasOne("QuizAPI.Models.Category", "Category")
                        .WithMany("Question")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("QuizAPI.Models.Category", b =>
                {
                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}