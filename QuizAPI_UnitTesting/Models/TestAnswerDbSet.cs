using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizAPI.Models;


namespace QuizAPI_UnitTesting.Models
{
    class TestAnswerDbSet : TestDbSet<Answer>
    {
        public TestAnswerDbSet(TestDbSet<Answer> answers)
        {
        }
        public TestAnswerDbSet()
        {
        }
        public override Answer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(answer => answer.AnswerID == (int)keyValues.Single());
        }
    }
}
