﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        //Majors
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            return View(major);
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            return View(major);
            
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }


        //Sates
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }


        [HttpPost]
        public ActionResult AddState(State state)
        {
            if(ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            return View(state);
        }

        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            State state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
            return View(state);
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbbreviation)
        {
            State state = StateRepository.Get(stateAbbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }


        //Courses
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");
            }
            return View(course);            
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            Course course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            return View(course);
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            Course course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}