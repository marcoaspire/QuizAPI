using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPI_UnitTesting
{
    class AnswerFake : Context
    {
        public override DbSet<Answer> Answers { get; set; }
        public List<Answer> Answers2 { get; set; }

        public AnswerFake()
        {
            Answers2 = new List<Answer>()
            {
                new Answer() {
                    AnswerID = 1,
                    Correct = true,
                    PosibleAnswer = "Something",
                    QuestionID = 1
                },
                new Answer() {
                    AnswerID = 2,
                    Correct = false,
                    PosibleAnswer = "Something bad",
                    QuestionID = 1
                }
            };
        }



        public Answer Add(Answer newItem)
        {
            Answers.Add(newItem);
            return newItem;
        }

        public  IEnumerable<Answer> Get()
        {
            return Answers;
        }

        public  Answer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public  void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
