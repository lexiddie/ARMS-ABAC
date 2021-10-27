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
    public class CampusController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public CampusController(ApplicationDbContext db,
                                IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        
        public IActionResult Index()
        {
            var campuses = _db.Campuses.Include(x => x.Buildings)
                                       .Select(x => new 
                                                    {
                                                        x.Id,
                                                        x.NameEn,
                                                        x.NameTh,
                                                        TotalBuilding = x.Buildings.Count(),
                                                        x.CreatedAt,
                                                        x.CreatedBy,
                                                        x.IsActive
                                                    })
                                       .IgnoreQueryFilters()
                                       .ToList();
            
            return Ok(campuses);
        }    

        [HttpGet("SelectList")]
        public IActionResult SelectList()
        {
            var campuses = _db.Campuses.Select(x => new 
                                                    {
                                                        x.Id,
                                                        x.NameEn,
                                                    })
                                       .ToList();
            
            return Ok(campuses);
        }    

        [HttpPost]
        public IActionResult Create([FromBody]Campus model)
        {
            if (ModelState.IsValid)
            {
                _db.Campuses.Add(model);
                try
                {
                    _db.SaveChanges();
                    return Ok(Message.CreateSuccessful);
                }
                catch (Exception e)
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
        public async Task<IActionResult> Edit(long? id,[FromBody]Campus model)
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
            Campus model = Find(id);
            try
            {
                _db.Campuses.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Campus Find(long? id) 
        {
            return _db.Campuses.Find(id);
        }

        
    }
}