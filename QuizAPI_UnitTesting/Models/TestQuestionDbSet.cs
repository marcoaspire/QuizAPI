using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPI_UnitTesting.Models
{
    class TestQuestionDbSet : TestDbSet<Question>
    {
        public override Question Find(params object[] keyValues)
        {
            return this.SingleOrDefault(question => question.QuestionID == (int)keyValues.Single());
        }
    }
}
