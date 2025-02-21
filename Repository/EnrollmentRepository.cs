using EnglishLearning.Data;
using EnglishLearning.Models;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearning.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        ApplicationDbContext context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Enrollment> GetAll()
        {
            return context.Enrollments.ToList();
        }

        public List<Enrollment> getstudentsOfCourse(int id)
        {
            return context.Enrollments.Where(e => e.CourseId == id).ToList();
        }
        public Enrollment GetById(int id)
        {
            return context.Enrollments.FirstOrDefault(x => x.Id == id);
        }
        public Enrollment GetEnrollmentByCourseId(int id)
        {
            return context.Enrollments.FirstOrDefault(x => x.CourseId == id);
        }
        public int Insert(Enrollment newEnroll)
        {
            context.Enrollments.Add(newEnroll);
            return context.SaveChanges();
        }

        public int Update(int id, Enrollment enrollment)
        {
            Enrollment oldEnroll = GetById(id);
            if (oldEnroll != null)
            {
                oldEnroll.CourseId = enrollment.CourseId;
                oldEnroll.Date = enrollment.Date;
                oldEnroll.CourseDegree = enrollment.CourseDegree;


                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Enrollment enrollment = GetById(id);

            context.Enrollments.Remove(enrollment);
            return context.SaveChanges();
        }

    }
}
