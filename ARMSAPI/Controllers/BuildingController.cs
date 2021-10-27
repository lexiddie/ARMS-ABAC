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
    public class BuildingController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public BuildingController(ApplicationDbContext db,
                                  IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        //GET api/building
        public IActionResult Index()
        {
           var buildings = _db.Buildings.Include(x => x.Campus)
                                        .Include(x => x.Rooms)
                                        .Select(x => new 
                                                {
                                                    x.Id,
                                                    x.NameEn,
                                                    x.NameTh,
                                                    CampusId = x.CampusId,
                                                    CampusName = x.Campus.NameEn,
                                                    x.Description,
                                                    FloorNumber = x.Rooms.Select(y => y.Floor).DefaultIfEmpty(0).Max(),
                                                    TotalRoom = x.Rooms.Count(),
                                                    x.CreatedAt,
                                                    x.CreatedBy,
                                                    x.IsActive
                                                })
                                        .ToList();
           return Ok(buildings);
        }

        [HttpGet("campusid={id}")]
        public IActionResult BuildingsByCampusId(long id)
        {
            var buildings = _db.Buildings.Include(x => x.Rooms)
                                         .Where(x => x.CampusId == id)
                                         .Select(x => new 
                                                      {
                                                        x.Id,
                                                        x.NameEn,
                                                        x.NameTh,
                                                        x.Description,
                                                        FloorNumber = x.Rooms.Select(y => y.Floor).DefaultIfEmpty(0).Max(),
                                                        TotalRoom = x.Rooms.Count(),
                                                        x.CreatedAt,
                                                        x.CreatedBy,
                                                        x.IsActive
                                                      })
                                         .ToList();

            return Ok(buildings);
        }
        [HttpGet("SelectList")]
        public IActionResult SelectList()
        {
            var campuses = _db.Buildings.Select(x => new 
                                                {
                                                    x.Id,
                                                    x.CampusId,
                                                    x.NameEn,
                                                    FloorNumber = x.Rooms.Select(y => y.Floor).DefaultIfEmpty(0).Max(),
                                                })
                                        .ToList();
            
            return Ok(campuses);
        }    
       
        //POST api/Building from body
        [HttpPost]
        public IActionResult Create([FromBody]Building model)
        {
            if (ModelState.IsValid)
            {
                _db.Buildings.Add(model);
                try
                {
                    _db.SaveChanges();
                    return Ok(Message.CreateSuccessful);
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

            return Ok(Message.ModelError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,[FromBody]Building model)
        {
            
            if (ModelState.IsValid )
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
            Building model = Find(id);
            try
            {
                _db.Buildings.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Building Find(long? id) 
        {
            return _db.Buildings.Find(id);
        }

    }
}