﻿using Microsoft.AspNetCore.Mvc;
using EnglishLearning.Models;
using EnglishLearning.Repository;
using System.Collections.Generic;

namespace EnglishLearning.Controllers
{
    public class LevelsController : Controller
    {
        ILevelRepository levelRepository;

        public LevelsController(ILevelRepository levelRepository)
        {
            this.levelRepository = levelRepository;
        }

        public IActionResult Index()
        {
            List<Level> levels = levelRepository.GetAll();

            return View(levels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Level level)
        {
            if (level.Name !=null)
            {
                levelRepository.Insert(level);
                return RedirectToAction("Index");
            }
            return View("New",level); // Mahran: view name is create not new  Mahran
        }

        public IActionResult Edit(int id)
        {
           Level level = levelRepository.GetById(id);

            return View("Edit", level);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Level newlevel)
        {
            if (ModelState.IsValid == true)
            {

              levelRepository.Update(id, newlevel);
                return RedirectToAction("Index");
            }
            return View("Edit", newlevel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
           Level level = levelRepository.GetById(id);
            return View(level);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           levelRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
