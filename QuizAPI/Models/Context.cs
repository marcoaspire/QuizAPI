using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();
            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "tbl_categories");
            });
            builder.Entity<Question>(entity =>
            {
                entity.ToTable(name: "tbl_questions");
            });
            builder.Entity<Answer>(entity =>
            {
                entity.ToTable(name: "tbl_answers");
            });
            //builder.Entity<Answer>()
            //    .HasIndex(c => new { c.PosibleAnswer, c.Correct})
            //    .IsUnique();

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
