using System;
using System.Linq;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Semester")]
    public class SemesterController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public SemesterController(IMemoryCache cache)
        {
            _options.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _options.SlidingExpiration = TimeSpan.FromMinutes(30);
            _cache = cache;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("loadSemesters")))
            {
                _cache.Set("loadSemesters", JsonConvert.SerializeObject(ListProvider.LoadSemesters().OrderBy(x => x.AcademicYear).Reverse()), _options);
            }
            var viewModel = new SemesterViewModel { Semesters = _cache.Get<string>("loadSemesters") };
            return PartialView("Index", viewModel);
        }
    }
}