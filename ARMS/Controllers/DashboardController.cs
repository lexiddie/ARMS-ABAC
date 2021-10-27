using System;
using System.Collections.Generic;
using ARMS.Models;
using ARMS.Models.Completions;
using ARMS.Providers.Completion;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private static readonly CompletionProvider CompletionProvider = new CompletionProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public DashboardController(IMemoryCache cache)
        {
            _options.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _options.SlidingExpiration = TimeSpan.FromMinutes(30);
            _cache = cache;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return PartialView("Index");
        }

        [HttpPost]
        [Route("DashboardInsight")]
        public IActionResult DashboardInsight(long semesterId, long examinationTypeId)
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("completionCampuses")) || string.IsNullOrEmpty(_cache.Get<string>("completionBuildings")) || string.IsNullOrEmpty(_cache.Get<string>("completionRooms")))
            {
                _cache.Set("completionCampuses", JsonConvert.SerializeObject(CompletionProvider.CompletionCampuses()), _options);
                _cache.Set("completionBuildings", JsonConvert.SerializeObject(CompletionProvider.CompletionBuildings()), _options);
                _cache.Set("completionRooms", JsonConvert.SerializeObject(CompletionProvider.CompletionRooms()), _options);
            }
            var viewModel = new DashboardViewModel
            {
                SemesterId = semesterId,
                ExaminationTypeId = examinationTypeId,
                Campus = JsonConvert.DeserializeObject<List<CampusCompletion>>(_cache.Get<string>("completionCampuses")).Count,
                Building = JsonConvert.DeserializeObject<List<BuildingCompletion>>(_cache.Get<string>("completionBuildings")).Count,
                Room = JsonConvert.DeserializeObject<List<RoomCompletion>>(_cache.Get<string>("completionRooms")).Count,
                ExaminationCourse = CompletionProvider.CompletionExaminationCourses(semesterId, examinationTypeId).Count,
                AssignedCourse = CompletionProvider.CompletionAssignedCourses(semesterId, examinationTypeId).Count,
                UnassignedCourse = CompletionProvider.CompletionUnassignedCourses(semesterId, examinationTypeId).Count
            };
            
            return PartialView("_DashboardInsight", viewModel);
        }
        
        [HttpPost]
        [Route("ExaminationRoom")]
        public IActionResult ExaminationRoom(long examinationSlotId)
        {
            var viewModel = new DashboardViewModel
            {
                ExaminationSlotId = examinationSlotId,
                ExaminationRooms = JsonConvert.SerializeObject(ListProvider.LoadExaminationRooms(examinationSlotId))
            };
            return PartialView("_ExaminationRoomIndex", viewModel);
        }

        [HttpPost]
        [Route("ExaminationStudent")]
        public IActionResult ExaminationStudent(long examinationSlotId, long examinationRoomId, string examinationRoomName)
        {
            var viewModel = new DashboardViewModel
            {
                ExaminationRoomId = examinationRoomId,
                ExaminationSlotId = examinationSlotId,
                ExaminationRoomName = examinationRoomName,
                ExaminationStudents = JsonConvert.SerializeObject(ListProvider.LoadExaminationStudents(examinationRoomId, examinationSlotId))
            };
            return PartialView("_ExaminationStudent", viewModel);
        }

        [HttpPost]
        [Route("LoadExaminationSlots")]
        public IActionResult LoadExaminationSlots(long semesterId, long examinationTypeId)
        {
            return Json( new { examinationSlots = CompletionProvider.CompletionExaminationSlots(semesterId, examinationTypeId) } as dynamic);
        }

        [HttpPost]
        [Route("FilterExaminationRoom")]
        public IActionResult FilterExaminationRoom(RoomSearchViewModel data)
        {
            var searchList = new List<ExaminationRoom>();
            var tempList = JsonConvert.DeserializeObject<List<ExaminationRoom>>(data.Rooms);
            foreach (var item in tempList)
            {
                if (data.RoomId != 0)
                {
                    if (data.RoomId == item.Id)
                    {
                        searchList.Add(item);
                    }
                }
                else if (data.Floor != 0 && data.BuildingId == 0 && data.CampusId == 0)
                {
                    if (data.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                }
                else if (data.BuildingId != 0)
                {
                    if (data.BuildingId == item.BuildingId && data.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                    else if (data.BuildingId == item.BuildingId && data.Floor == 0)
                    {
                        searchList.Add(item);
                    }
                }
                else if (data.CampusId != 0)
                {
                    if (data.CampusId == item.CampusId && data.Floor == item.Floor)
                    {
                        searchList.Add(item);
                    }
                    else if (data.CampusId == item.CampusId && data.Floor == 0)
                    {
                        searchList.Add(item);
                    }
                }
                else
                {
                    searchList.Add(item);
                }
            }
            data.Rooms = JsonConvert.SerializeObject(searchList);
            var viewModel = new DashboardViewModel
            {
                ExaminationSlotId = data.ExaminationSlotId,
                ExaminationRooms = data.Rooms
            };
            return PartialView("_ExaminationRoom", viewModel);
        }
    }
}