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
    public class CourseExaminationSlotController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public CourseExaminationSlotController(ApplicationDbContext db,
                                               IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        //GET api/room
        [HttpGet]
        public IActionResult Index()
        {
            var CourseSlots = _db.CourseExaminationSlots.Include(x => x.Course)
                                                        .Include(x => x.ExaminationSlot)
                                                        .GroupBy(x => x.CourseId)
                                                        .ToList();

            return Ok(CourseSlots);
        }
        
       [HttpGet("semesterid={id}")]
        public IActionResult GetExaminationCourseBySemester(long id)
        {
            var CourseSlot = (from c  in _db.Courses
                             join e in _db.CourseExaminationSlots on c.Id equals e.CourseId
                             join x in _db.ExaminationSlots on  e.ExaminationSlotId equals x.Id
                             where x.SemesterId == id
                             select new {
                                 c.Id,
                                 Code = c.Code.Trim(),
                                 Name = c.NameEn,
                                 c.FacultyId,
                                 c.DepartmentId,
                                 TotalSection = c.Sections.Where(x => x.SemesterId == id).Count(),
                                 TotalStudent = c.Sections.Where(x => x.SemesterId == id).Sum(y => y.SeatUsed),
                                 Slot = new {
                                    Id = x.Id,
                                    x.ExaminationTypeId,
                                    Date = x.Date,
                                    TimeStart = x.TimeStart,
                                    TimeEnd = x.TimeEnd
                                 }
                             }).ToList()
                             .GroupBy(o => o.Id)
                             .Select(u => new { 
                                 u.First().Id,
                                 u.First().Code,
                                 u.First().Name,
                                 u.First().FacultyId,
                                 u.First().DepartmentId,
                                 u.First().TotalSection,
                                 u.First().TotalStudent,
                                 Midterm = u.Where(p => p.Slot.ExaminationTypeId == 1).Select(p => new {
                                     Id = p.Slot.Id,
                                     Date = p.Slot.Date,
                                     TimeStart = p.Slot.TimeStart,
                                     TimeEnd = p.Slot.TimeEnd
                                 }).FirstOrDefault(),
                                 Final = u.Where(p => p.Slot.ExaminationTypeId == 2).Select(p => new {
                                     Id = p.Slot.Id,
                                     Date = p.Slot.Date,
                                     TimeStart = p.Slot.TimeStart,
                                     TimeEnd = p.Slot.TimeEnd
                                 }).FirstOrDefault(),
                             })
                             .Where(u => u.TotalSection != 0)
                             .ToList();

                                                        
            return Ok(CourseSlot);
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]CourseExaminationSlot model)
        {
            if (ModelState.IsValid)
            {
                _db.CourseExaminationSlots.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]CourseExaminationSlot model)
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
            CourseExaminationSlot model = Find(id);
            try
            {
                _db.CourseExaminationSlots.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private CourseExaminationSlot Find(long? id) 
        {
            return _db.CourseExaminationSlots.Find(id);
        }

    }
}
