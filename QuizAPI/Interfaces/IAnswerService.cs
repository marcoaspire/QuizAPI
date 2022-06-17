using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Interfaces
{
    public interface IAnswerService : IDisposable
    {
        IEnumerable<Answer> Get();
        Answer Add(Answer newItem);
        Answer GetById(Guid id);
        void Remove(Guid id);

        public DbSet<Answer> Answers { get;set; }

        //
        int SaveChanges();
        void MarkAsModified(Answer item);

    }
}
