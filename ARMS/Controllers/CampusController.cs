using System;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Campus")]
    public class CampusController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public CampusController(IMemoryCache cache)
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
        
        [HttpGet]
        [Route("Campus")]
        public IActionResult Campus()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("loadCampuses")))
            {
                _cache.Set("loadCampuses", JsonConvert.SerializeObject(ListProvider.LoadCampuses()), _options);
            }
            var viewModel = new CampusViewModel { Campuses = _cache.Get<string>("loadCampuses") };
            return PartialView("_Campus", viewModel);
        }

        [HttpPost]
        [Route("Building")]
        public IActionResult Building(long campusId, string campusName)
        {
            var viewModel = new CampusViewModel
            {
                CampusId = campusId,
                CampusName = campusName,
                Buildings = JsonConvert.SerializeObject(ListProvider.LoadBuildings(campusId))
            };
            return PartialView("_Building", viewModel);
        }

        [HttpPost]
        [Route("Room")]
        public IActionResult Room(long campusId, string campusName, long buildingId, string buildingName)
        {
            var viewModel = new CampusViewModel
            {
                CampusId = campusId,
                CampusName = campusName,
                BuildingId = buildingId,
                BuildingName = buildingName,
                Rooms = JsonConvert.SerializeObject(ListProvider.LoadRooms(buildingId))
            };
            return PartialView("_Room", viewModel);
        }
    }
}