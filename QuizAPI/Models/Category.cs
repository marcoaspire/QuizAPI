using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Category
    {
            [Key]
            public int CategoryID { get; set; }

            [Required]
            public string CategoryName { get; set; }
            //one to many
            public List<Question> Question { get; set; }

    }
    public struct CategoryResponse
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }

        public List<Answer> Answers { get; set; }

    }
}
