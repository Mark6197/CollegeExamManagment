using AutoMapper;
using Domain.Courses;
using Domain.Interfaces.Persistence;
using ExamsWebApp.Models.CourseViewModels;
using ExamsWebApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamsWebApp.Models.StudentViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamsWebApp.Models.ExamViewModels;
using Domain.Exams;
using ExamsWebApp.Mappers;

namespace ExamsWebApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {

            var viewModel = new List<CourseBasicDetailsVM>();
            long userId = User.GetLoggedInUserId<long>();
            var courses = await _unitOfWork.Courses.GetCoursesWithStudentsAsync(userId);
            foreach (var course in courses)
            {
                var courseViewModel = _mapper.Map<CourseBasicDetailsVM>(course);
                viewModel.Add(courseViewModel);
            }
            return View(viewModel);

        }

        public async Task<IActionResult> Details(long id)
        {
            if (id <= 0)
                return NotFound();

            Course course = await _unitOfWork.Courses.GetCourseWithStudentsAndExamsAsync(id);

            if (course == null)
                return NotFound();

            var viewModel = _mapper.Map<CourseExtendedDetailsVM>(course);

            ViewBag.ExamsSelectList = await GenerateExamsSelectList(course.TeacherId);

            ViewData["Title"] =$"{course.Name} Details";

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseVM createCourseViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            Course course = _mapper.Map<Course>(createCourseViewModel);
            course.TeacherId = User.GetLoggedInUserId<long>();
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var course = await _unitOfWork.Courses.GetAsync(id);

            if (course == null)
                return NotFound();

            var viewModel = _mapper.Map<EditCourseVM>(course);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, EditCourseVM editCourseViewModel)
        {
            if (id != editCourseViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    Course course = _mapper.Map<Course>(editCourseViewModel);
                    _unitOfWork.Courses.Update(course);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.Courses.IsExist(editCourseViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(editCourseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var course = await _unitOfWork.Courses.GetCourseWithFullExamsAsync(id);
            if (course == null)
                return NotFound();

            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> AssignExamToCourse(CreateAssignedExamVM createAssignedExamVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ExamsSelectList = await GenerateExamsSelectList(createAssignedExamVM.TeacherId);
                return PartialView("_CreateAssignedExamPartial", createAssignedExamVM);
            }

            var exam = await _unitOfWork.Exams.GetNotAssignedFullExamAsync(createAssignedExamVM.ExamId);
            if (exam == null)
            {
                ModelState.AddModelError(nameof(CreateAssignedExamVM.ExamId), "Exam Not Found");
            }

            var course = await _unitOfWork.Courses.GetAsync(createAssignedExamVM.CourseId);
            if (course == null)
            {
                ModelState.AddModelError("", "Course Not Found, Please Contact Admin");
            }
            else
            {
                if (course.StartDate > createAssignedExamVM.StartDate || course.FinishDate < createAssignedExamVM.StartDate)
                {
                    ModelState.AddModelError(nameof(CreateAssignedExamVM.StartDate),
                        $"Exam start date must be within course time limits: {course.StartDate.ToShortDateString()} - {course.FinishDate.ToShortDateString()}");
                }
                if (course.FinishDate < createAssignedExamVM.FinishDate || course.StartDate > createAssignedExamVM.FinishDate)
                {
                    ModelState.AddModelError(nameof(CreateAssignedExamVM.FinishDate),
                        $"Exam finish date must be within course time limits: {course.StartDate.ToShortDateString()} - {course.FinishDate.ToShortDateString()}");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.ExamsSelectList = await GenerateExamsSelectList(createAssignedExamVM.TeacherId);
                return PartialView("_CreateAssignedExamPartial", createAssignedExamVM);
            }

            AssignedExam assignedExam = _mapper.Map<AssignedExam>(createAssignedExamVM);

            assignedExam.Course = course;

            assignedExam.ExamType = ExamType.AssignedExam;

            CustomMappings.Map_Exam_To_AssignedExam(exam, assignedExam);

            createAssignedExamVM.IsCreated = true;

            await _unitOfWork.AssignedExams.AddAsync(assignedExam);
            await _unitOfWork.SaveAsync();

            return PartialView("_CreateAssignedExamPartial", createAssignedExamVM);
        }

        private async Task<List<SelectListItem>> GenerateExamsSelectList(long teacherId)
        {
            var exams = await _unitOfWork.Exams.GetNotAssignedExamsByTeacherAsync(teacherId);

            var examsSelectList = new List<SelectListItem>
            {
                new SelectListItem(exams.Count()>0 ? "Assign Exam" : "No exmas to assign", "0")
            };

            foreach (var exam in exams)
                examsSelectList.Add(new SelectListItem(exam.Title, exam.Id.ToString()));

            return examsSelectList;
        }
    }
}
