using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [Required]
        public string Query { get; set; }
        [Required]
        public int CategoryID { get; set; }

        //one to many(inverse)
        public virtual Category Category { get; set; }

        //one to many
        public List<Answer> Answers { get; set; }

    }
}
