using System;
using System.Linq;
using System.Threading.Tasks;
using ARMSAPI.Data;
using ARMSAPI.Interfaces;
using ARMSAPI.Models;
using ARMSAPI.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ARMSAPI.Controllers
{
     [Route("api/[controller]")]
    public class SectionController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public SectionController(ApplicationDbContext db,
                                 IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        
        [HttpGet("SelectList/semesterId={Id}")]
        public IActionResult SelectList(long Id)
        {
            var sectionSelectList = _db.Sections.Where(x => x.SemesterId == Id)
                                                .Select(x => new
                                                             {
                                                                 x.Id,
                                                                 x.Number,
                                                                 x.CourseId,
                                                                 x.SeatUsed
                                                             })
                                                .ToList();

            return Ok(sectionSelectList);
        }

        [HttpGet("count")]
        public IActionResult SectionsCount()
        {
            var Count = _db.Sections.Count();

            return Ok(Count);
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Section model)
        {
            if (ModelState.IsValid)
            {
                _db.Sections.Add(model);
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

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,[FromBody]Section model)
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
            Section model = Find(id);
            try
            {
                _db.Sections.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Section Find(long? id) 
        {
            return _db.Sections.Find(id);
        }

    }
}
