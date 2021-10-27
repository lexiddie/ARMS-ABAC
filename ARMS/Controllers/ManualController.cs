using System;
using System.Collections.Generic;
using ARMS.Models;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Manual")]
    public class ManualController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return PartialView("Index");
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
                AssignedCourses = JsonConvert.SerializeObject(ListProvider.LoadManual(semesterId, examinationTypeId))
            };
            return PartialView("_AssignedCourseIndex", viewModel);
        }

        [HttpPost]
        [Route("UnassignedCourse")]
        public IActionResult UnassignedCourse(long semesterId, long examinationTypeId, string sessionText)
        {
            var viewModel = new UnassignedCourseViewModel
            {
                SessionText = sessionText,
                UnassignedCourses = JsonConvert.SerializeObject(ListProvider.LoadUnassignedCourses(semesterId, examinationTypeId))
            };
            return PartialView("_UnassignedCourseIndex", viewModel);
        }

        [HttpGet]
        [Route("ManualAssign")]
        public IActionResult ManualAssign()
        {
            return PartialView("_ManualAssign");
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


        [HttpPost]
        [Route("FilterUnassignedCourse")]
        public IActionResult FilterUnassignedCourse(CourseSearchViewModel data)
        {
            var searchList = new List<UnassignedCourse>();
            var tempList = JsonConvert.DeserializeObject<List<UnassignedCourse>>(data.Courses);
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
            var viewModel = new UnassignedCourseViewModel
            {
                SessionText = data.SessionText,
                UnassignedCourses = JsonConvert.SerializeObject(searchList)
            };
            return PartialView("_UnassignedCourse", viewModel);
        }
    }
}