using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface IExamRepository
    {
        int Delete(int id);
        List<Exam> GetAll();
        Exam GetById(int id);
        int Insert(Exam newExam);
        int Update(int id, Exam exam);
    }
}