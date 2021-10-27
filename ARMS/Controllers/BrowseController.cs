using System;
using System.Collections.Generic;
using System.Linq;
using ARMS.Models;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Browse")]
    public class BrowseController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return PartialView("Index");
        }

        [HttpGet]
        [Route("SearchStudent")]
        public IActionResult SearchStudent()    
        {
            return PartialView("_SearchStudent");
        }

        [HttpPost]
        [Route("InquiryStudent")]
        public IActionResult InquiryStudent(long semesterId, long examinationTypeId, string studentCode, string semesterText, string sessionText)
        {
            var viewModel = new BrowseViewModel
            {
                SemesterText = semesterText,
                SessionText = sessionText,
                InquiryStudent = ListProvider.LoadInquiryStudent(semesterId, examinationTypeId, studentCode)
            };
            return PartialView("_InquiryStudent", viewModel);
        }
        
        [HttpPost]
        [Route("ConflictStudent")]
        public IActionResult ConflictStudent(long semesterId, long examinationTypeId, string sessionText)
        {
            var viewModel = new ConflictStudentViewModel
            {
                SessionText = sessionText,
                ConflictStudents = JsonConvert.SerializeObject(ListProvider.LoadConflictStudents(semesterId, examinationTypeId))
            };
            return PartialView("_ConflictStudent", viewModel);
        }
        
        [HttpPost]
        [Route("ConflictCourse")]
        public IActionResult ConflictCourse(string studentCode, string studentName, string examinationDateTime, string courseIds)
        {
            var conflictCourseIds = JsonConvert.DeserializeObject<List<long>>(courseIds);
            var viewModel = new ConflictCourseViewModel
            {
                StudentCode = studentCode,
                StudentName = studentName,
                ExaminationDateTime = examinationDateTime,
                CourseIds = conflictCourseIds,
                ConflictCourses = JsonConvert.SerializeObject(LoadConflictCourses(conflictCourseIds))
            };
            return PartialView("_ConflictCourse", viewModel);
        }

        private static List<ConflictCourse> LoadConflictCourses(IEnumerable<long> items)
        {
            var conflictCourses = new List<ConflictCourse>();
            var courses = ListProvider.LoadCourses();
            foreach (var i in items)
            {
                var conflictCourse = new ConflictCourse();
                foreach (var j in courses.Where(j => i == j.Id))
                {
                    conflictCourse.FacultyName = j.Faculty.Abbreviation;
                    conflictCourse.DepartmentName = j.Department.NameEn;
                    conflictCourse.CodeAndName = j.CodeAndName;
                    break;
                }
                conflictCourses.Add(conflictCourse);
            }
            return conflictCourses;
        }

        [HttpGet]
        [Route("ExaminationSeating")]
        public IActionResult ExaminationSeating()
        {
            return PartialView("_ExaminationSeating");
        }
        
        [HttpPost]
        [Route("SeatingRoom")]
        public IActionResult SeatingRoom(long semesterId, long examinationTypeId)
        {
            var seatingRooms = JsonConvert.SerializeObject(ListProvider.LoadSeatingRooms(semesterId, examinationTypeId));
            return Json(seatingRooms);
        }
        
        
        [HttpPost]
        [Route("SeatingStudent")]
        public IActionResult SeatingStudent(SeatingStudentViewModel model)
        {
            var seatingRoom = JsonConvert.DeserializeObject<SeatingRoom>(model.SeatingRoom);
            seatingRoom.SeatingStudents =
                ListProvider.LoadSeatingStudents(model.SemesterId, seatingRoom.ExaminationSlotId, seatingRoom.Id);
            Console.WriteLine($"Checking RoomId {seatingRoom.Id}, ExaminationSlotId {seatingRoom.ExaminationSlotId}");
            model.SeatingRoom = JsonConvert.SerializeObject(seatingRoom);
            return PartialView("_SeatingStudent", model);
        }
        
        [HttpPost]
        [Route("PreviewReport")]
        public IActionResult PreviewReport(SeatingStudentViewModel model)
        {
            var seatingRoom = JsonConvert.DeserializeObject<SeatingRoom>(model.SeatingRoom);
            seatingRoom.SeatingStudents =
                ListProvider.LoadSeatingStudents(model.SemesterId, seatingRoom.ExaminationSlotId, seatingRoom.Id);
            Console.WriteLine($"Checking RoomId {seatingRoom.Id}, ExaminationSlotId {seatingRoom.ExaminationSlotId}");
            model.SeatingRoom = JsonConvert.SerializeObject(seatingRoom);
            return PartialView("_PreviewReport", model);
        }

        [HttpPost]
        [Route("PreviewContent")]
        public IActionResult PreviewContent(SeatingStudentViewModel model)
        {
            return PartialView("_PreviewContent", model);
        }

        [HttpPost]
        [Route("SystemLog")]
        public IActionResult SystemLog(long semesterId, long examinationTypeId)
        {
            var viewModel = new SystemLogViewModel
            {
                SystemLogs = JsonConvert.SerializeObject(ListProvider.LoadAssignmentLogs(semesterId, examinationTypeId))
            };
            return PartialView("_SystemLog", viewModel);
        }

        [HttpPost]
        [Route("FilterSeatingRoom")]
        public IActionResult FilterSeatingRoom(SeatingRoomViewModel model)
        {
            var searchList = new List<SeatingRoom>();
            var tempList = JsonConvert.DeserializeObject<List<SeatingRoom>>(model.SeatingRooms);
            foreach (var item in tempList)
            {
                if (model.RoomId != 0)
                {
                    if (model.RoomId == item.Id)
                    {
                        searchList.Add(item);
                    }
                }
                else if (model.Floor != 0 && model.BuildingId == 0 && model.CampusId == 0)
                {
                    if (model.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                }
                else if (model.BuildingId != 0)
                {
                    if (model.BuildingId == item.BuildingId && model.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                    else if (model.BuildingId == item.BuildingId && model.Floor == 0)
                    {
                        searchList.Add(item);
                    }
                }
                else if (model.CampusId != 0)
                {
                    if (model.CampusId == item.CampusId && model.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                    else if (model.CampusId == item.CampusId && model.Floor == 0)
                    {
                        searchList.Add(item);
                    }
                }
                else
                {
                    searchList.Add(item);
                }
            }
            model.SeatingRooms = JsonConvert.SerializeObject(searchList);
            return PartialView("_SeatingRoom", model);
        }
    }
}