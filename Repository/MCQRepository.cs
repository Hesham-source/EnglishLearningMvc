using EnglishLearning.Models;
using System.Linq;

using EnglishLearning.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnglishLearning.Repository
{
    public class MCQRepository : IMCQRepository
    {
        ApplicationDbContext Context;
        //public MCQRepository(ApplicationDbContext Contect)
        //{
        //    this.Context = Contect;
        //}
        public MCQRepository()
        {
            Context = new ApplicationDbContext();
        }
        public List<MCQ> GetAllBylevelId(int id)
        {
            return Context.MCQs.Where(q => q.Level_Id == id).ToList();  //Get all MCQ in selected level
        }
        public MCQ GetById(int id)
        {
            return Context.MCQs.FirstOrDefault(q => q.Id == id); //Get all MCQ in selected level
        }
        public MCQ GetOneWithChoices(int id) // Get one MCQ questions with his Choices
        {
            return Context.MCQs.Include(q => q.Choices).FirstOrDefault(q => q.Id == id);
        }

        public int Insert(MCQ mcq)
        {
            Context.MCQs.Add(mcq);
            return Context.SaveChanges();
        }

        public int Update(int id, MCQ Mcq)
        {                                         // updata MCQ questuins and choices
            MCQ MCQUpdated = GetOneWithChoices(id);
            if (MCQUpdated != null)
            {
                MCQUpdated.Id = Mcq.Id;
                MCQUpdated.Text = Mcq.Text;
                MCQUpdated.CorrectAnswer = Mcq.CorrectAnswer;
                MCQUpdated.Choices = Mcq.Choices;

                return Context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            MCQ McqDeleted = Context.MCQs.FirstOrDefault(q => q.Id == id); ;
            if (McqDeleted != null)
            {
                Context.MCQs.Remove(McqDeleted);
            }
            else
            {
                throw new NullReferenceException();
            }
            return Context.SaveChanges();
        }
    }
}
