﻿using System.Collections.Generic;

namespace EnglishLearning.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Course> Courses { get; set; }
        public virtual List<Question> Questions { get; set; } 

    }
}
