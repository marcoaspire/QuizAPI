using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Context : DbContext, IAnswerService
    {
        public Context() 
        { }
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

        public IEnumerable<Answer> Get()
        {
            throw new NotImplementedException();
        }

        public Answer Add(Answer newItem)
        {
            throw new NotImplementedException();
        }

        public Answer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void MarkAsModified(Answer item)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
    }
}
