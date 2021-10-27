using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ARMS.Models;
using ARMS.Models.Completions;
using ARMS.Providers.API;
using ARMS.Providers.Completion;
using ARMS.Providers.List;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ApiProvider ApiProvider = new ApiProvider();
        private static readonly ListProvider ListProvider = new ListProvider();
        private static readonly CompletionProvider CompletionProvider = new CompletionProvider();
        private readonly MemoryCacheEntryOptions _temporaryOptions = new MemoryCacheEntryOptions();
        private readonly MemoryCacheEntryOptions _permanentOptions = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        private static readonly string[] CampusColors = { "DD2C00", "2196F3", "673AB7", "FF5722", "FFEB3B" };

        public HomeController(IMemoryCache cache)
        {
            _temporaryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _temporaryOptions.SlidingExpiration = TimeSpan.FromMinutes(30);
            _permanentOptions.SetPriority(CacheItemPriority.NeverRemove);
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorPage()
        {
            return PartialView("ErrorPage");
        }

        public IActionResult CurrentDateTime()
        {
            return Json(new { dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") } as dynamic);
        }

        public IActionResult CheckLogin()
        {
            if (!_cache.Get<bool>("isLogin"))
            {
                _cache.Set("isLogin", false, _permanentOptions);
            }
            var current = new { isLogin = _cache.Get<bool>("isLogin") } as dynamic;
            return Json(current);
        }

        public IActionResult VerifyLogin(string username, string password)
        {
            // if (username != "admin" || password != "123") return Json(new { isSuccess = false } as dynamic);
            if (password != "123") return Json(new { isSuccess = false } as dynamic);
            _cache.Set("isLogin", true, _permanentOptions);
            _cache.Set("loginUsername", username, _permanentOptions);
            return Json(new { isSuccess = true, loginUsername = username } as dynamic);
        }

        public IActionResult Logout()
        {
            _cache.Set("isLogin", false, _permanentOptions);
            return Json(new { isSuccess = true } as dynamic);
        }

        public IActionResult CompletionSemesters()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionSemesters")))
            {
                _cache.Set("completionSemesters", JsonConvert.SerializeObject(CompletionProvider.CompletionSemesters()), _temporaryOptions);
            }
            var semesters = JsonConvert.DeserializeObject<List<SemesterCompletion>>(_cache.Get<string>("completionSemesters"));
            return Json(semesters);
        }

        public IActionResult CompletionSessions(long semesterId)
        {
            var sessions = CompletionProvider.CompletionSessions(semesterId);
            return Json(sessions);
        }

        public IActionResult CompletionCourses()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionCourses")))
            {
                _cache.Set("completionCourses", JsonConvert.SerializeObject(CompletionProvider.CompletionCourses()), _temporaryOptions);
            }
            var courses = JsonConvert.DeserializeObject<List<CourseCompletion>>(_cache.Get<string>("completionCourses"));
            return Json(courses);
        }

        public IActionResult CompletionFaculties()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionFaculties")))
            {
                _cache.Set("completionFaculties", JsonConvert.SerializeObject(CompletionProvider.CompletionFaculties()), _temporaryOptions);
            }
            var faculties = JsonConvert.DeserializeObject<List<FacultyCompletion>>(_cache.Get<string>("completionFaculties"));
            return Json(faculties);
        }

        public IActionResult CompletionDepartments()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionDepartments")))
            {
                _cache.Set("completionDepartments", JsonConvert.SerializeObject(CompletionProvider.CompletionDepartments()), _temporaryOptions);
            }
            var departments = JsonConvert.DeserializeObject<List<DepartmentCompletion>>(_cache.Get<string>("completionDepartments"));
            return Json(departments);
        }

        public IActionResult CompletionCampuses()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionCampuses")))
            {
                _cache.Set("completionCampuses", JsonConvert.SerializeObject(CompletionProvider.CompletionCampuses()), _temporaryOptions);
            }
            var campuses = JsonConvert.DeserializeObject<List<CampusCompletion>>(_cache.Get<string>("completionCampuses"));
            return Json(campuses);
        }

        public IActionResult CompletionBuildings()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionBuildings")))
            {
                _cache.Set("completionBuildings", JsonConvert.SerializeObject(CompletionProvider.CompletionBuildings()), _temporaryOptions);
            }
            var buildings = JsonConvert.DeserializeObject<List<BuildingCompletion>>(_cache.Get<string>("completionBuildings"));
            return Json(buildings);
        }

        public IActionResult CompletionRooms()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionRooms")))
            {
                _cache.Set("completionRooms", JsonConvert.SerializeObject(CompletionProvider.CompletionRooms()), _temporaryOptions);
            }
            var rooms = JsonConvert.DeserializeObject<List<RoomCompletion>>(_cache.Get<string>("completionRooms"));
            return Json(rooms);
        }

        public IActionResult LoadUnassignedCourses(long semesterId, long examinationTypeId)
        {
            var unassignedCourses = ListProvider.LoadUnassignedCourses(semesterId, examinationTypeId);
            return Json(unassignedCourses);
        }

        public IActionResult LoadExaminationSections(long semesterId, long courseId)
        {
            Console.WriteLine($"Checking SemesterId {semesterId} & CourseId {courseId}");
            var examinationSections = ListProvider.LoadExaminationSections(semesterId, courseId);
            Console.WriteLine($"Checking result of ExaminationSection {examinationSections.Count}");
            return Json(examinationSections);
        }

        public IActionResult CompletionAvailableRooms(long examinationSlotId)
        {
            var availableRooms = CompletionProvider.CompletionAvailableRooms(examinationSlotId);
            return Json(availableRooms);
        }

        public IActionResult LoadCampusColors()
        {
            var colors = CampusColors.Select(i => new { color = i }).Cast<dynamic>().ToList();
            return Json(colors);
        }

        public IActionResult LoadBrowses()
        {
            // var browses = new[] { Url.Action("SearchStudent", "Browse"), Url.Action("ConflictStudent", "Browse"), Url.Action("ExaminationSeating", "Browse"), Url.Action("SystemLog", "Browse") };
            var browses = new[] { Url.Action("ConflictStudent", "Browse"), Url.Action("ExaminationSeating", "Browse"), Url.Action("SystemLog", "Browse") };
            return Json(browses.Select(i => new {id = Index(), url = i}).Cast<dynamic>().ToList());
        }
        
        public IActionResult LoadManuals()
        {
            var manuals = new[] { Url.Action("AssignedCourse", "Manual"), Url.Action("UnassignedCourse", "Manual"), Url.Action("ManualAssign", "Manual") };
            return Json(manuals.Select(i => new {id = Index(), url = i}).Cast<dynamic>().ToList());
        }
        
        public IActionResult LoadAutomates()
        {
            var manuals = new[] { Url.Action("AssignedCourse", "Automate"), Url.Action("UnassignedCourse", "Automate") };
            return Json(manuals.Select(i => new {id = Index(), url = i}).Cast<dynamic>().ToList());
        }

        public IActionResult LoadExaminationUsedRoom(long semesterId, long examinationTypeId)
        {
            return Json(new { totalUsedRoom = ListProvider.LoadExaminationUsedRoom(semesterId, examinationTypeId).TotalUsedRoom } as dynamic);
        }
        
        public IActionResult ActivateManual(long courseId, long examinationSlotId, string roomIds)
        {
            var manualArrangement = new ManualArrangement
            {
                CourseId = courseId,
                ExaminationSlotId = examinationSlotId,
                RoomIds = JsonConvert.DeserializeObject<List<long>>(roomIds),
                User = _cache.Get<string>("loginUsername")
            };
            return Json(new { isSuccess = ApiProvider.ApiActivateManual(manualArrangement).Result.IsSuccess } as dynamic);
        }

        public IActionResult ActivateAutomate(long semesterId, long examinationTypeId)
        {
            var automateArrangement = new AutomateArrangement
            {
                SemesterId = semesterId,
                ExaminationTypeId = examinationTypeId,
                User = _cache.Get<string>("loginUsername")
            };
            return Json(new { isSuccess = ApiProvider.ApiActivateAutomate(automateArrangement).Result.IsSuccess } as dynamic);
        }
        
        public IActionResult DissolvedCourse(long courseId, long examinationSlotId)
        {
            var dissolveCourse = new DissolvedCourse
            {
                CourseId = courseId,    
                ExaminationSlotId = examinationSlotId,
                User = _cache.Get<string>("loginUsername")
            };
            return Json(new { isSuccess = ApiProvider.ApiDissolvedCourse(dissolveCourse).Result.IsSuccess } as dynamic);
        }
        
        public IActionResult DissolvedCourses(long semesterId, long examinationTypeId, long code)
        {
            var dissolveCourses = new DissolvedCourses
            {
                SemesterId = semesterId,    
                ExaminationTypeId = examinationTypeId,
                Code = code,
                User = _cache.Get<string>("loginUsername")
            };
            return Json(new { isSuccess = ApiProvider.ApiDissolvedCourses(dissolveCourses).Result.IsSuccess } as dynamic);
        }
    }
}