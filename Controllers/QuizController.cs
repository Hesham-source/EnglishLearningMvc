using Microsoft.AspNetCore.Mvc;
using EnglishLearning.Models;
using EnglishLearning.Models.ViewModel;
using EnglishLearning.Repository;
using System.Collections.Generic;

namespace EnglishLearning.Controllers
{
    public class QuizController : Controller
    {
        IQuestionRepoistory QuestionRepoistory;
        ILevelRepository LevelRepository;
        public QuizController(IQuestionRepoistory questionRepoistory, ILevelRepository levelRepository)
        {
            QuestionRepoistory = questionRepoistory;
            LevelRepository = levelRepository;

        }
        public IActionResult Index()
        {
           // List(Quiz)
            return View();
        }
    }
}
