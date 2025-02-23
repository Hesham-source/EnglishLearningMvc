﻿using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface IQuestionRepoistory
    {
        int Delete(int id);
        List<Question> GetAllByLevelId(int id);
        Question GetById(int id);
        int Insert(Question question);
        int Update(int id, Question question);

    }
}