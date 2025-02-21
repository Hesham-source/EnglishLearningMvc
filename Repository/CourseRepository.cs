using Microsoft.EntityFrameworkCore;
using EnglishLearning.Data;
using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearning.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ApplicationDbContext context;

        //public CourseRepository(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}
        public CourseRepository()
        {
            context = new ApplicationDbContext();
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(c=>c.Level).ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Include(c=>c.Level).FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Course newCourse)
        {
            context.Courses.Add(newCourse);
            return context.SaveChanges();
        }

        public int Update(int id, Course course)
        {
            Course oldcrs = GetById(id);
            if (oldcrs != null)
            {
                oldcrs.Name = course.Name;
                oldcrs.Date = course.Date;
                oldcrs.Level_Id = course.Level_Id;
                oldcrs.User_Id = course.User_Id;

                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Course oldcrs = GetById(id);
            if (oldcrs != null)
            {
                context.Courses.Remove(oldcrs);
            }
            else
            {
                throw new NullReferenceException();
            }
            return context.SaveChanges();
        }
    }
}
