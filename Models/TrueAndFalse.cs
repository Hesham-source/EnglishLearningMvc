using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearning.Models
{
    [Table("TrueAndFalse")]
    public class TrueAndFalse :Question
    {
        public  string Text { get; set; }
        public bool Answer { get; set; }
    }
}
