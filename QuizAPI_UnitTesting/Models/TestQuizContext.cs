using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPI_UnitTesting.Models
{
    class TestQuizContext: IAnswerService
    {
        public TestQuizContext()
        {
           this.Answers = new TestAnswerDbSet();
           this.Questions= new TestQuestionDbSet();
           this.Categories= new TestCategoryDbSet();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Answer answer) { }
        public void Dispose() { }

        public IEnumerable<Answer> Get()
        {
            throw new NotImplementedException();
        }
        //answer
        public Answer Add(Answer newItem)
        {
            this.Answers.Add(newItem);
            return newItem;
        }

        public Answer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        //category
        public Category Add(Category newItem)
        {
            this.Categories.Add(newItem);
            return newItem;
        }
        //question
        public Question Add(Question newItem)
        {
            this.Questions.Add(newItem);
            return newItem;
        }

        public void MarkAsModified(Category item)
        {}

        public void MarkAsModified(Question item)
        {}
    }
}
