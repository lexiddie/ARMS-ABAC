using System.Collections.Generic;
using System.Linq;
using ARMS.Models;
using ARMS.Models.Completions;
using ARMS.Providers.Completion;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Explore")]
    public class ExploreController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private static readonly CompletionProvider CompletionProvider = new CompletionProvider();

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return PartialView("Index");
        }

        [HttpPost]
        [Route("ExploreInsight")]
        public IActionResult ExploreInsight(long semesterId, long examinationTypeId)
        {
            var studyCourses = CompletionProvider.CompletionStudyCourses(semesterId);
            var studySections = CompletionProvider.CompletionSections(semesterId);
            var examinationCourses = CompletionProvider.CompletionExaminationCourses(semesterId, examinationTypeId);
            var examinationSections = LoadExaminationSections(studySections, examinationCourses);
            var viewModel = new ExploreViewModel
            {
                SemesterId = semesterId,
                ExaminationTypeId = examinationTypeId,
                StudyCourse = studyCourses.Count,
                StudySection = studySections.Count,
                StudySeat = studySections.Sum(item => item.SeatUsed),
                ExaminationCourse = examinationCourses.Count,
                ExaminationSection = examinationSections.Count,
                ExaminationSeat = examinationSections.Sum(item => item.SeatUsed)
            };

            return PartialView("_ExploreInsight", viewModel);
        }

        [HttpPost]
        [Route("AssignedCourse")]
        public IActionResult AssignedCourse(long semesterId, long examinationTypeId, string sessionText)
        {
            var viewModel = new AssignedCourseViewModel
            {
                SemesterId = semesterId,
                ExaminationTypeId = examinationTypeId,
                SessionText = sessionText,
                AssignedCourses = JsonConvert.SerializeObject(ListProvider.LoadExplore(semesterId, examinationTypeId))
            };
            return PartialView("_AssignedCourseIndex", viewModel);
        }

        [HttpPost]
        [Route("ExaminationRoom")]
        public IActionResult ExaminationRoom(long semesterId, long examinationTypeId, long examinationSlotId, long courseId, string courseCodeName)
        {
            var viewModel = new ExaminationRoomViewModel
            {
                SemesterId = semesterId,
                ExaminationTypeId = examinationTypeId,
                ExaminationSlotId = examinationSlotId,
                CourseId = courseId,
                CourseCodeName = courseCodeName,
                ExaminationRooms = JsonConvert.SerializeObject(ListProvider.LoadExaminationRooms(semesterId, examinationTypeId, courseId))
            };
            return PartialView("_ExaminationRoom", viewModel);
        }

        [HttpPost]
        [Route("ExaminationStudent")]
        public IActionResult ExaminationStudent(long examinationSlotId, long courseId, string courseCodeName, long roomId, string roomName)
        {
            var viewModel = new ExaminationStudentViewModel
            {
                ExaminationSlotId = examinationSlotId,
                CourseId = courseId,
                CourseCodeName = courseCodeName,
                RoomId = roomId,
                RoomName = roomName,
                ExaminationStudents = JsonConvert.SerializeObject(ListProvider.LoadExaminationStudents(courseId, roomId, examinationSlotId))
            };
            return PartialView("_ExaminationStudent", viewModel);
        }


        [HttpPost]
        [Route("FilterAssignedCourse")]
        public IActionResult FilterAssignedCourse(CourseSearchViewModel data)
        {
            var searchList = new List<AssignedCourse>();
            var tempList = JsonConvert.DeserializeObject<List<AssignedCourse>>(data.Courses);
            foreach (var item in tempList)
            {
                if (data.CourseId != 0)
                {
                    if (data.CourseId == item.CourseId)
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
            var viewModel = new AssignedCourseViewModel
            {
                SemesterId = data.SemesterId,
                ExaminationTypeId = data.ExaminationTypeId,
                SessionText = data.SessionText,
                AssignedCourses = JsonConvert.SerializeObject(searchList)
            };
            return PartialView("_AssignedCourse", viewModel);
        }

        private static List<SectionCompletion> LoadExaminationSections(IReadOnlyCollection<SectionCompletion> studySections, IEnumerable<CourseCompletion> examinationCourses)
        {
            var list = new List<SectionCompletion>();
            foreach (var i in examinationCourses)
            {
                list.AddRange(studySections.Where(j => i.Id == j.CourseId));
            }
            return list;
        }
    }
}