using System;
using ARMS.Providers;
using ARMS.Providers.List;
using ARMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ARMS.Controllers
{
    [Route("Building")]
    public class BuildingController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public BuildingController(IMemoryCache cache)
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
        [Route("Building")]
        public IActionResult Building()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("loadBuildings")))
            {
                _cache.Set("loadBuildings", JsonConvert.SerializeObject(ListProvider.LoadBuildings()), _options);
            }
            var viewModel = new BuildingViewModel { Buildings = _cache.Get<string>("loadBuildings") };
            return PartialView("_Building", viewModel);
        }

        [HttpPost]
        [Route("Room")]
        public IActionResult Room(long buildingId, string buildingName)
        {
            var viewModel = new BuildingViewModel
            {
                BuildingId = buildingId,
                BuildingName = buildingName,
                Rooms = JsonConvert.SerializeObject(ListProvider.LoadRooms(buildingId))
            };
            return PartialView("_Room", viewModel);
        }

    }
}