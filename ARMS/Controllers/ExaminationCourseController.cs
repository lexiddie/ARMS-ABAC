using System.Collections.Generic;
using ARMS.Models;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("ExaminationCourse")]
    public class ExaminationCourseController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var viewModel = new ExaminationCourseViewModel();
            return PartialView("Index", viewModel);
        }

        [HttpPost]
        [Route("ExaminationCourse")]
        public IActionResult ExaminationCourse(long semesterId)
        {
            var viewModel = new ExaminationCourseViewModel
            {
                SemesterId = semesterId,
                ExaminationCourses = JsonConvert.SerializeObject(ListProvider.LoadExaminationCourses(semesterId))
            };
            return PartialView("_ExaminationCourseIndex", viewModel);
        }

        [HttpPost]
        [Route("Section")]
        public IActionResult Section(long semesterId, long courseId, string courseCodeName)
        {
            var viewModel = new ExaminationCourseViewModel
            {
                SemesterId = semesterId,
                CourseId = courseId,
                CourseCodeName = courseCodeName,
                Sections = JsonConvert.SerializeObject(ListProvider.LoadSections(courseId, semesterId))
            };
            return PartialView("_Section", viewModel);
        }

        [Route("Student")]
        public IActionResult Student(long semesterId, long courseId, string courseCodeName, long sectionId, string sectionNumber)
        {
            var viewModel = new ExaminationCourseViewModel
            {
                SemesterId = semesterId,
                CourseId = courseId,
                CourseCodeName = courseCodeName,
                SectionId = sectionId,
                SectionNumber = sectionNumber,
                Students = JsonConvert.SerializeObject(ListProvider.LoadStudents(sectionId))
            };
            return PartialView("_Student", viewModel);
        }

        [HttpPost]
        [Route("FilterExaminationCourse")]
        public IActionResult FilterExaminationCourse(ExaminationCourseSearchViewModel data)
        {
            var searchList = new List<ExaminationCourse>();
            var tempList = JsonConvert.DeserializeObject<List<ExaminationCourse>>(data.ExaminationCourses);
            foreach (var item in tempList)
            {
                if (data.CourseId != 0)
                {
                    if (data.CourseId == item.Id)
                    {
                        searchList.Add(item);
                    }
                }
                else if (data.DepartmentId != 0)
                {
                    if (data.DepartmentId == item.DepartmentId)
                    {
                        searchList.Add(item);
                    }
                }
                else if (data.FacultyId != 0)
                {
                    if (data.FacultyId == item.FacultyId)
                    {
                        searchList.Add(item);
                    }
                }
                else
                {
                    searchList.Add(item);
                }
            }
            var viewModel = new ExaminationCourseViewModel
            {
                SemesterId = data.SemesterId,
                ExaminationCourses = JsonConvert.SerializeObject(searchList)
            };
            data.ExaminationCourses = JsonConvert.SerializeObject(searchList);
            return PartialView("_ExaminationCourse", viewModel);
        }
    }
}