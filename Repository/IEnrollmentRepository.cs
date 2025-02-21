using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface IEnrollmentRepository
    {
        int Delete(int id);
        List<Enrollment> GetAll();
        Enrollment GetById(int id);
        Enrollment GetEnrollmentByCourseId(int id);
        List<Enrollment> getstudentsOfCourse(int id);
        int Insert(Enrollment newEnroll);
        int Update(int id, Enrollment enrollment);
    }
}