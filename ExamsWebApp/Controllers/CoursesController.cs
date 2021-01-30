using AutoMapper;
using Domain.Courses;
using Domain.Interfaces.Persistence;
using ExamsWebApp.Areas.Identity.Data;
using ExamsWebApp.Models.CourseViewModels;
using ExamsWebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamsWebApp.Models.StudentViewModels;

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

            var viewModel = new List<CourseBasicDetailsViewModel>();
            long userId = User.GetLoggedInUserId<long>();
            var courses = await _unitOfWork.Courses.GetCoursesWithStudentsByTeacherIdAsync(userId);
            foreach (var course in courses)
            {
                var courseViewModel = _mapper.Map<CourseBasicDetailsViewModel>(course);
                viewModel.Add(courseViewModel);
            }
            return View(viewModel);

        }

        public IActionResult Details(long? id)
        {
            if (id == null)
                return NotFound();

            var course = _unitOfWork.Courses.GetCourseWithStudents(id);

            if (course == null)
                return NotFound();

            var viewModel = new CourseExtendedDetailsViewModel();
            viewModel.Details = _mapper.Map<CourseBasicDetailsViewModel>(course);
            foreach (var student in course.Students)
            {
                var studentViewModel = _mapper.Map<StudentViewModel>(student);
                viewModel.Students.Add(studentViewModel);
            }

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseViewModel createCourseViewModel)
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

            var viewModel = _mapper.Map<EditCourseViewModel>(course);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, EditCourseViewModel editCourseViewModel)
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
            var course = await _unitOfWork.Courses.GetAsync(id);
            if (course == null)
                return NotFound();

            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(List));
        }
    }
}
