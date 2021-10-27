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
    public class ExaminationSlotController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public ExaminationSlotController(ApplicationDbContext db,
                                         IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }

        [HttpGet("SelectList/SemesterId={sid},ExaminationTypeId={slotId}")]
        public IActionResult ExaminationSlotBySemesterAndType(long sid, long slotId)
        {
            var result = _db.ExaminationSlots.Where(x => x.SemesterId == sid
                                                         && x.ExaminationTypeId == slotId)
                                             .Select(x => new
                                                          {
                                                              x.Id,
                                                              x.Date,
                                                              x.TimeStart,
                                                              x.TimeEnd
                                                          })
                                             .ToList();
                
            return Ok(result);
        }
        
         [HttpGet("Session/SelectList")]
        public IActionResult SessionsSelectList()
        {
            var slots = _db.ExaminationSlots.Include(x => x.ExaminationType)
                                            .GroupBy(x => new { x.SemesterId, x.ExaminationTypeId })
                                            .Select(x => new 
                                                         {
                                                             x.Key.SemesterId,
                                                             x.Key.ExaminationTypeId,
                                                             x.FirstOrDefault().ExaminationType.NameEn
                                                         })
                                            .ToList();

                              
            return Ok(slots);
        }
       
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]ExaminationSlot model)
        {
            if (ModelState.IsValid)
            {
                _db.ExaminationSlots.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]ExaminationSlot model)
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
            ExaminationSlot model = Find(id);
            try
            {
                _db.ExaminationSlots.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private ExaminationSlot Find(long? id) 
        {
            return _db.ExaminationSlots.Find(id);
        }
        

    }
}
