using System.Linq;
using System.Threading.Tasks;
using ARMSAPI.Data;
using ARMSAPI.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ARMSAPI.Models;

namespace ARMSAPI.Controllers
{
     [Route("api/[controller]")]
    public class SeatArrangementResultController : BaseController
    {
        public SeatArrangementResultController(ApplicationDbContext db) : base(db) { }

        [HttpGet("RoomId={roomId},ExaminationSlotId={examinationSlotId}")] 
        public IActionResult GetStudentByExaminationRoom(long roomId, long examinationSlotId)
        {
            var result = _db.SeatArrangementResults.Include(x => x.Student)
                                                   .Include(x => x.Section)
                                                   .Where(x => x.RoomId == roomId 
                                                               && x.ExaminationSlotId == examinationSlotId)
                                                   .Select(x => new 
                                                                {
                                                                    x.StudentId,
                                                                    x.Student.Code,
                                                                    FirstName = x.Student.FirstNameEn,
                                                                    LastName = x.Student.LastNameEn,
                                                                    SectionNumber = x.Section.Number,
                                                                    x.SeatNumber,
                                                                    x.RowNumber,
                                                                    CreatedAt = x.CreatedAt,
                                                                    CreatedBy = Message.CreatedByAutoManual(x.IsAuto, x.CreatedBy),
                                                                    x.Student.IsActive
                                                                });
            
            return Ok(result);
        }
        [HttpGet("SemesterId={semesterId},Examinationtypeid={examinationTypeId}")]
        public IActionResult ExaminationSeatingReport(long semesterId, long examinationTypeId)
        {
            var seatings = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                    .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                    .GroupBy(x => new { x.ExaminationSlotId, x.RoomId })
                                                    .Select(x => new
                                                                 {
                                                                     ExaminationSlotId = x.Key.ExaminationSlotId,
                                                                     RoomId = x.Key.RoomId,
                                                                     ExaminationStudents = x.Count()
                                                                 })
                                                    .ToList();
            
            return Ok(seatings);
        }
        [HttpGet("ExaminationSlotId={slotId},Examinationroomid={roomId}")]
        public IActionResult ExaminationSeatings(long slotId, long roomId)
        {
            var seatings = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                              .Include(x => x.Course)
                                                    .Where(x => x.ExaminationSlotId == slotId
                                                                && x.RoomId== roomId)
                                                    .Select(x => new
                                                                 {
                                                                     CourseId = x.CourseId,
                                                                     CourseCode = x.Course.Code,
                                                                     Id = x.StudentId,
                                                                    SectionId = x.SectionId,
                                                                    Row = x.RowNumber,
                                                                    Seat = x.SeatNumber
                                                                 })
                                                    .ToList();
            
            return Ok(seatings);
        }

        //Exam Conflict
        [HttpGet("ExamConflicts/Semesterid={id},ExaminationTypeid={typeId}")]
        public IActionResult GetExamTimeConflictResults(long id, long typeId) 
        {
            var conflicts = (from s in _db.StudentStudyCourses
                             join e in _db.CourseExaminationSlots on s.CourseId equals e.CourseId into joinedC
                             from e in joinedC.DefaultIfEmpty()
                             join x in _db.ExaminationSlots on e.ExaminationSlotId equals x.Id into joined
                             from x in joined.DefaultIfEmpty()
                             where x.ExaminationTypeId == typeId && x.SemesterId == id && s.SemesterId == id
                             select new 
                                    {
                                        s.StudentId,
                                        e.CourseId,
                                        ExaminationSlotId = x.Id,
                                        x.SemesterId,
                                        x.ExaminationTypeId
                                    })
                             .GroupBy(x => x.ExaminationSlotId)
                             .Select(x => x.GroupBy(y => y.StudentId))
                             .Select(x => x.Select(y => y.Select(z => new 
                                                                      {
                                                                          z.StudentId,
                                                                          z.CourseId,
                                                                          z.ExaminationSlotId,
                                                                      })
                                                         .Distinct())
                                           .Where(z => z.Count() > 1))
                             .ToList();
                    
            var newconflict = conflicts.SelectMany(j => j.Select(k => new 
                                                                      {
                                                                          StudentId = k.First().StudentId,
                                                                          CourseIds = k.Select(p => new 
                                                                                                    {
                                                                                                        Id = p.CourseId
                                                                                                    }),
                                                                          ExaminationSlotId = k.First().ExaminationSlotId    
                                                
                                                                      }))
                                       .ToList();
            
            // return Ok(newconflict);
            // var conflicts = _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
            //                                           .Where(x => x.ExaminationSlot.SemesterId == id
            //                                                         && x.ExaminationSlot.ExaminationTypeId == typeId)
            //                                           .GroupBy(x => new {x.ExaminationSlotId, x.StudentId})
            //                                           .Where(x => x.Count() > 1)
            //                                           .Select(x => new 
            //                                                        {
            //                                                            StudentId = x.Key.StudentId,
            //                                                            CourseIds = x.Select(y => new 
            //                                                                                     {
            //                                                                                         Id = y.CourseId
            //                                                                                     }),
            //                                                            ExaminationSlotId = x.Key.ExaminationSlotId
            //                                                        })
            //                                           .ToList();
            return Ok(newconflict);
        }

        [HttpGet("Student/Selectlist/semesterid={id}")]
        public IActionResult GetStudents(long id) 
        {
            var students = _db.Students.Where(x => x.StudyCourses.Any(y => y.SemesterId == id))
                                       .Select(x => new
                                                    {
                                                        Id = x.Id,
                                                        Code = x.Code,
                                                        FirstName = x.FirstNameEn,
                                                        LastName = x.LastNameEn
                                                    })
                                       .ToList();
            return Ok(students);
        }        

        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]SeatArrangementResult model)
        {
            if (ModelState.IsValid)
            {
                _db.SeatArrangementResults.Add(model);
                try
                {
                    _db.SaveChanges();
                    return Ok(Message.CreateSuccessful);;
                }
                catch
                {
                    return Ok(Message.UnableToCreate);                    
                }
            }

            return Ok(Message.ModelError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,[FromBody]SeatArrangementResult model)
        {
            
            if (ModelState.IsValid )
            {
                _db.Entry(model).State = EntityState.Modified;
                try
                {
                    await _db.SaveChangesAsync();
                    return Ok(Message.EditSuccessful);
                }
                catch
                {
                    return Ok(Message.UnableToEdit);
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
            SeatArrangementResult model = Find(id);
            try
            {
                _db.SeatArrangementResults.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private SeatArrangementResult Find(long? id) 
        {
            return _db.SeatArrangementResults.Find(id);
        }

    }
}
