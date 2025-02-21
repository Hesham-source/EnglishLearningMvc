using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface ICourseRepository
    {
        int Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        int Insert(Course newCourse);
        int Update(int id, Course course);
    }
}