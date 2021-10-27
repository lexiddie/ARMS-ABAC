using System;
using System.Collections.Generic;
using ARMS.Models;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Course")]
    public class CourseController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public CourseController(IMemoryCache cache)
        {
            _options.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _options.SlidingExpiration = TimeSpan.FromMinutes(30);
            _cache = cache;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("loadCourses")))
            {
                _cache.Set("loadCourses", JsonConvert.SerializeObject(ListProvider.LoadCourses()), _options);
            }
            var viewModel = new CourseViewModel { Courses = _cache.Get<string>("loadCourses") };
            return PartialView("~/Views/Course/Index.cshtml", viewModel);
        }

        [HttpPost]
        [Route("FilterCourse")]
        public IActionResult FilterCourse(CourseViewModel model)
        {
            var searchList = new List<Course>();
            var tempList = JsonConvert.DeserializeObject<List<Course>>(model.Courses);
            foreach (var item in tempList)
            {
                if (model.CourseId != 0)
                {
                    if (model.CourseId == item.Id)
                    {
                        searchList.Add(item);
                    }
                }
                else if (model.DepartmentId != 0)
                {
                    if (model.DepartmentId == item.DepartmentId)
                    {
                        searchList.Add(item);
                    }
                }
                else if (model.FacultyId != 0)
                {
                    if (model.FacultyId == item.FacultyId)
                    {
                        searchList.Add(item);
                    }
                }
                else
                {
                    searchList.Add(item);
                }
            }
            model.Courses = JsonConvert.SerializeObject(searchList);
            return PartialView("_Course", model);
        }
    }
}