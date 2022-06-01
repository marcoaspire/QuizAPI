using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public string PosibleAnswer { get; set; }
        [Required]

        public int QuestionID { get; set; }

        public bool Correct { get; set; }

        //one to many(inverse)
        public virtual Question Question { get; set; }

    }
}
