using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface ITrueAndFalseRepository
    {
        int Delete(int id);
        List<TrueAndFalse> GetAllByLevelId(int id);
        TrueAndFalse GetById(int id);
        int Insert(TrueAndFalse trueAndFalse);
        int Update(int id, TrueAndFalse trueAndFalse);
    }
}