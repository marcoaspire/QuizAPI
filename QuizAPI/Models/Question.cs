using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizAPI.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [Required]
        [JsonPropertyName("Question")]
        public string Query { get; set; }
        [Required]
        public int CategoryID { get; set; }

        //one to many(inverse)
        public virtual Category Category { get; set; }

        //one to many
        public List<Answer> Answers { get; set; }

    }
}
