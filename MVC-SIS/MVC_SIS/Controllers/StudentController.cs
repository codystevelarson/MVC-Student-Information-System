﻿using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());

            viewModel.Student = new Student()
            {
                Address = new Address()
                {
                    State = new State()
                    {
                        StateAbbreviation = "",
                        StateName = "PLACEHOLDER"
                    }
                },
                Major = new Major()
                {
                    MajorId = -1,
                    MajorName = "PLACEHOLDER"
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);

            if (ModelState.IsValid)
            {
                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
            }
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            Student student = StudentRepository.Get(id);
            StudentVM viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            if(student.Courses != null)
            {
                foreach (Course course in student.Courses)
                {
                    viewModel.SelectedCourseIds.Add(course.CourseId);
                }
            }
            viewModel.Student = student;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();
            foreach (var id in studentVM.SelectedCourseIds)
            {
                studentVM.Student.Courses.Add(CourseRepository.Get(id));
            }

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);

            if (ModelState.IsValid)
            {
                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            }
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());
            return View(studentVM);
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            Student student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

    }
}