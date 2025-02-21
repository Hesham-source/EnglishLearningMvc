using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearning.Models
{
    [Table("MCQ")]
    public class MCQ: Question
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }

        public virtual List<choice> Choices { get; set; }
    }
}
