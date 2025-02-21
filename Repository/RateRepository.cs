using Microsoft.EntityFrameworkCore;
using EnglishLearning.Data;
using EnglishLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishLearning.Repository
{
    public class RateRepository : IRateRepository
    {
        ApplicationDbContext context;//= new ApplicationDbContext();
        //public RateRepository(ApplicationDbContext _Context)
        //{
        //    context = _Context;
        //}

        public RateRepository()
        {
            id = Guid.NewGuid();
            context = new ApplicationDbContext();
        }
        public Guid id { get; set; }

        public List<Rate> GetAll()
        {
            return context.Rates.Include(r => r.Course).ToList();
        }
        public Rate GetById(int id)
        {
            return context.Rates.Include(r => r.Course).FirstOrDefault(c => c.ID == id);
        }
        public int Insert(Rate rate)
        {
            context.Rates.Add(rate);
            return context.SaveChanges();
        }
        public int update(int id, Rate _rate)
        {
            Rate rate = context.Rates.Include(r => r.Course).FirstOrDefault(r => r.ID == id);
            if (rate != null)
            {
                rate.Stars = _rate.Stars;
                rate.Course_ID = _rate.Course_ID;
                rate.User_ID = _rate.User_ID;
                return context.SaveChanges();
            }
            return 0;
        }
        public int delete(int id)
        {
            Rate rate = GetById(id);
            if (rate != null)
            {
                context.Rates.Remove(rate);
            }
            else
            {
                throw new NullReferenceException();
            }
            return context.SaveChanges();
        }
        public List<Rate> GetByCourseId(int id)
        {
            List<Rate> rate = context.Rates.Where(r => r.Course_ID == id).ToList();
            return rate;
        }
        public Rate GetByIdCourse(int courseID)
        {
         return context.Rates.Include(x => x.Course).Where(x => x.Course_ID == courseID).FirstOrDefault();
        }
    }
}
