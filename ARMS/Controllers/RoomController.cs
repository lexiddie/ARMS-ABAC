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
    [Route("Room")]
    public class RoomController : Controller
    {
        private static readonly ListProvider ListProvider = new ListProvider();
        private readonly MemoryCacheEntryOptions _options = new MemoryCacheEntryOptions();
        private readonly IMemoryCache _cache;

        public RoomController(IMemoryCache cache)
        {
            _options.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _options.SlidingExpiration = TimeSpan.FromMinutes(30);
            _cache = cache;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_cache.Get<string>("loadRooms")))
            {
                _cache.Set("loadRooms", JsonConvert.SerializeObject(ListProvider.LoadRooms()), _options);
            }
            var viewModel = new RoomViewModel { Rooms = _cache.Get<string>("loadRooms") };
            return PartialView("Index", viewModel);
        }

        [HttpPost]
        [Route("FilterTable")]
        public IActionResult FilterTable(RoomViewModel model)
        {
            var searchList = new List<Room>();
            var tempList = JsonConvert.DeserializeObject<List<Room>>(model.Rooms);
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
            model.Rooms = JsonConvert.SerializeObject(searchList);
            return PartialView("_Room", model);
        }
    }
}