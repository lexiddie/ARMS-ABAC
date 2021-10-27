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
    public class SemesterController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public SemesterController(ApplicationDbContext db,
                                  IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        [HttpGet("SelectList")]
        public IActionResult SelectList()
        {
            var semesters = _db.Semesters.Where(x => x.AcademicLevelId == 3)
                                         .Select(x => new 
                                                      {
                                                          Id = x.Id,
                                                          x.AcademicLevelId,
                                                          x.AcademicYear,
                                                          x.Term,
                                                          x.IsCurrent                                     
                                                      })
                                         .ToList();

            return Ok(semesters);
        }
        
        [HttpGet()]
        public IActionResult details()
        {
            var semesters = (from semester in _db.Semesters
                             join slot in _db.ExaminationSlots on semester.Id equals slot.SemesterId into joinedSlot
                             from resultSlot in joinedSlot.DefaultIfEmpty()
                             where semester.AcademicLevelId == 3
                             select new 
                                    {
                                        Semester = semester,
                                        ExaminationSlot = resultSlot
                                    })
                             .IgnoreQueryFilters()
                             .ToList()
                             .GroupBy(x => x.Semester.Id)
                             .Select(x => new 
                                          {
                                              Id = x.Key,
                                              AcademicLevelId = x.First().Semester.AcademicLevelId,
                                              AcademicYear = x.First().Semester.AcademicYear,
                                              Term = x.First().Semester.Term,
                                              TotalWeekCount = x.First().Semester.TotalWeeksCount,
                                              IsCurrent = x.First().Semester.IsCurrent,
                                              StartedDate = x.First().Semester.StartedDate,
                                              EndedDate = x.First().Semester.EndedDate,
                                              MidtermStartDate = x?.Where(y => y.ExaminationSlot?.ExaminationTypeId == 1)
                                                                  ?.OrderBy(y => y.ExaminationSlot?.Date)
                                                                  ?.Select( y => y.ExaminationSlot?.Date)
                                                                  ?.FirstOrDefault() ?? default(DateTime),
                                              MidtermEndDate = x?.Where(y => y.ExaminationSlot?.ExaminationTypeId == 1)
                                                                 ?.OrderByDescending(y => y.ExaminationSlot?.Date)
                                                                 ?.Select(y => y.ExaminationSlot?.Date)
                                                                 ?.FirstOrDefault() ?? default(DateTime),
                                              FinalStartDate = x?.Where(y => y.ExaminationSlot?.ExaminationTypeId == 2)
                                                                ?.OrderBy(y => y.ExaminationSlot.Date)
                                                                ?.Select(y => y.ExaminationSlot?.Date)
                                                                ?.FirstOrDefault() ?? default(DateTime),
                                              FinalEndDate = x?.Where(y => y.ExaminationSlot?.ExaminationTypeId == 2)
                                                              ?.OrderByDescending(y => y.ExaminationSlot?.Date)
                                                              ?.Select(y => y.ExaminationSlot?.Date)
                                                              ?.FirstOrDefault() ?? default(DateTime),
                                              CreatedAt = x.First().Semester.CreatedAt,
                                              CreatedBy = x.First().Semester.CreatedBy,
                                              IsActive = x.First().Semester.IsActive

                                          })
                             .ToList();

            return Ok(semesters);
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Semester model)
        {
            if (ModelState.IsValid)
            {
                _db.Semesters.Add(model);
                try
                {
                    _db.SaveChanges();
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
                       return Ok(Message.UnableToCreate);
                    }
                    
                }
            }

            return Ok(Message.ModelError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,[FromBody]Semester model)
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
            Semester model = Find(id);
            try
            {
                _db.Semesters.Remove(model);
                _db.SaveChanges();
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }

            return Ok(Message.DeleteSuccessful);
        }

        private Semester Find(long? id) 
        {
            return _db.Semesters.Find(id);
        }

    }
}
