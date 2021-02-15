using AutoMapper;
using Domain.Exams;
using Domain.Interfaces.Persistence;
using ExamsWebApp.Extensions;
using ExamsWebApp.Helpers;
using ExamsWebApp.Models.ExamViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public ActionResult List()
        {
            var viewModel = new List<GenericExamBasicDetailsVM>();
            long userId = User.GetLoggedInUserId<long>();
            var exams = _unitOfWork.Exams.GetAllExamsWithCoursesByTeacher(userId);
            foreach (var exam in exams)
            {
                var examViewModel = _mapper.Map<GenericExamBasicDetailsVM>(exam);
                viewModel.Add(examViewModel);
            }
            return View(viewModel);
        }

        // GET: ExamsController/Details/5
        [ActionName("Details")]
        public async Task<ActionResult> NotAssignedExamDetails(long id)
        {
            if (id <= 0)
                return NotFound();

            Exam exam= await _unitOfWork.Exams.GetNotAssignedFullExamAsync(id);

            if (exam==null)
                return NotFound();
            GenericExamExtendedDetails viewModel =_mapper.Map<GenericExamExtendedDetails>(exam);

            return View(viewModel);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult> AssignedExamDetails(long id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (id <= 0)
                return NotFound();


            return View("Details");
        }

        // GET: ExamsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CreateExamVM>> Create([FromBody] CreateExamVM createExamViewModel)
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
                catch (Exception)
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
        public async Task<ActionResult> Delete(long id, Actions returnAction)
        {
            var c=HttpContext.Request.Path;
            var exam = await _unitOfWork.Exams.GetExamWithQuestionsAndAnswerAsync(id);
            if (exam == null)
                return NotFound();

            _unitOfWork.Exams.Remove(exam);
            await _unitOfWork.SaveAsync();

            if (returnAction == Actions.Details)
            {
                AssignedExam assignedExam = exam as AssignedExam;
                if (assignedExam!=null)
                    return RedirectToAction(nameof(CoursesController.Details), "Courses", new { id = assignedExam.CourseId});
            }
            return RedirectToAction(nameof(List));
        }
    }
}
