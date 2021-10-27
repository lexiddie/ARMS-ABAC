using System;
using System.Linq;
using System.Threading.Tasks;
using ARMSAPI.Data;
using ARMSAPI.Interfaces;
using ARMSAPI.Models;
using ARMSAPI.Models.DataModels.MasterTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public RoomController(ApplicationDbContext db,
                              IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
    
        //GET api/room
        public IActionResult Index()
        {
           var rooms = _db.Rooms.Include(x => x.Building)
                                    .ThenInclude(x => x.Campus)
                                .Select(x => new 
                                             {
                                                 x.Id,
                                                 x.Name,
                                                 x.Floor,
                                                 x.ExamCapacity,
                                                 x.ExamRows,
                                                 x.BuildingId,
                                                 BuildingName = x.Building.NameEn,
                                                 x.Building.CampusId,
                                                 CampusName = x.Building.Campus.NameEn,
                                                 x.CreatedAt,
                                                 x.CreatedBy,
                                                 x.IsAllowAutoAssign,
                                                 x.IsActive,
                                             })      
                                .IgnoreQueryFilters() 
                                .ToList();
                                    
            return Ok(rooms);
        }

        [HttpGet("SelectList")]
        public IActionResult SelectList()
        {
            var rooms = _db.Rooms.Include(x => x.Building)
                                 .Select(x => new 
                                              {
                                                  x.Id,
                                                  x.Name,
                                                  x.Building.CampusId,
                                                  x.BuildingId,
                                                  x.ExamCapacity,
                                                  x.Floor
                                              })
                                 .ToList();
            
            return Ok(rooms);
        }    
        
        [HttpGet("buildingid={buildid}")]
        public IActionResult RoomsByCampusAndBuilding(long buildId)
        {
            var rooms = _db.Rooms.Where(x => x.BuildingId == buildId)
                                 .Select(x => new 
                                              {
                                                  x.Id,
                                                  x.Name,
                                                  x.Floor,
                                                  x.ExamCapacity,
                                                  x.ExamRows,
                                                  x.CreatedAt,
                                                  x.CreatedBy,
                                                  x.IsActive,
                                              })
                                 .ToList();
            
            return Ok(rooms);
        }

        [HttpPost("UpdateIsAllowAutoAssign")]
        public IActionResult UpdateIsAllowAutoAssign([FromBody] UpdateRoomIsAllowAutoAssign model)
        {
            var room = _db.Rooms.SingleOrDefault(x => x.Id == model.Id);

            if (room != null)
            {
                try
                {
                    room.IsAllowAutoAssign = model.Status;
                    _db.SaveChanges();

                    return Ok(new { IsSuccess = true });
                }
                catch
                {
                    return Ok(new { IsSuccess = false });
                }
            }
            else
            {
                return Ok(new { IsSuccess = false });
            }
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Room model)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Add(model);
                try
                {
                    _db.SaveChanges();
                    return Ok(Message.CreateSuccessful);;
                }
                catch(Exception e)
                {
                    if (_exceptionManager.IsDuplicatedEntityCode(e))
                    {
                        return Ok(Message.DuplicatedCode);
                    }
                    else
                    {
                       return Ok(Message.UnableToCreate);
                    }
                }
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,[FromBody]Room model)
        {
            
            if (ModelState.IsValid)
            {
                _db.Entry(model).State = EntityState.Modified;
                try
                {
                    await _db.SaveChangesAsync();
                    return Ok(Message.EditSuccessful);
                }
                catch(Exception e)
                {
                    if (_exceptionManager.IsDuplicatedEntityCode(e))
                    {
                        return Ok(Message.DuplicatedCode);
                    }
                    else
                    {
                        return Ok(Message.UnableToEdit);
                    } 
                }
            }
            else 
            { 
                return Ok(Message.ModelError);
            }       
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            Room model = Find(id);
            try
            {
                _db.Rooms.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Room Find(long? id) 
        {
            return _db.Rooms.Find(id);
        }

    }
}
