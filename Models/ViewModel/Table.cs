using EnglishLearning.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearning.Models.ViewModel
{
    public class Table
    {
        public int ID { get; set; }
        public string ApplicationUserID { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserID")]
        public virtual ApplicationUser ApplicationUsers { get; set; }
        public int Course { get; set; }
        [NotMapped]
        [ForeignKey("Course")]
        public virtual Course Courses { get; set; }
        public DateTime Date { get; set; }
    }
}
