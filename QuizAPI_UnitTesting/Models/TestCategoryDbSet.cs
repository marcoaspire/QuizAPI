using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPI_UnitTesting.Models
{
    class TestCategoryDbSet : TestDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            return this.SingleOrDefault(category => category.CategoryID == (int)keyValues.Single());
        }
    }
}
