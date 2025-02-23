﻿using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface IMCQRepository
    {
        int Delete(int id);
        List<MCQ> GetAllBylevelId(int id);
        MCQ GetById(int id);
        MCQ GetOneWithChoices(int id);
        int Insert(MCQ mcq);
        int Update(int id, MCQ Mcq);
    }
}