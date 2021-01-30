using AutoMapper;
using Domain.Courses;
using Domain.Exams;
using Domain.Interfaces.Persistence;
using ExamsWebApp.Areas.Identity.Data;
using ExamsWebApp.Extensions;
using ExamsWebApp.Models.ExamViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamsWebApp.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: ExamsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExamsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamsController/Create
        public async Task<ActionResult> Create()
        {
            long userId = User.GetLoggedInUserId<long>();
            var courses = await _unitOfWork.Courses.GetCoursesByTeacherIdAsync(userId);
            var courseSelectList = new List<SelectListItem>
            {
                new SelectListItem(courses.Count()>0 ? "No course assigned" : "No courses yet", "0")
            };

            foreach (var course in courses)
                courseSelectList.Add(new SelectListItem(course.Name, course.Id.ToString()));

            ViewBag.Courses = courseSelectList;
            return View();
        }

        // POST: ExamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CreateExamViewModel>> Create([FromBody] CreateExamViewModel createExamViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exam = _mapper.Map<Exam>(createExamViewModel);
                    exam.TeacherId = User.GetLoggedInUserId<long>();
                    for (int i = 0; i < exam.Questions.Count; i++)
                    {
                        exam.Questions[i].QuestionNumInExam = i + 1;

                        for (int j = 0; j < exam.Questions[i].Answers.Count; j++)
                        {
                            exam.Questions[i].Answers[j].AnswerNumInQuestion = j + 1;
                        }
                    }
                    await _unitOfWork.Exams.AddAsync(exam);
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            return View();
        }


        // GET: ExamsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
