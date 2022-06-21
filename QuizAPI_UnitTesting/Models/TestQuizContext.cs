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

    }
}
