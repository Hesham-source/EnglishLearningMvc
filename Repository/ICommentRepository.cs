using EnglishLearning.Models;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface ICommentRepository
    {
        int Delete(int id);
        List<Comment> GetAll(int id);
        Comment getbyid(int id);
        int Insert(Comment newcomment);
        int Update(int id, Comment comment);
    }
}