using EnglishLearning.Models.ViewModel;
using System.Collections.Generic;

namespace EnglishLearning.Repository
{
    public interface IBAox
    {
        void Delete(int id);
        List<Table> GetAll();
        Table GetById(int id);
        void Insert(Table newCourse);
        void Update(int id, Table Table);
    }
}
