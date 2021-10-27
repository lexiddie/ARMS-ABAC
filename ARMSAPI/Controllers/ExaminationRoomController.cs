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
    public class ExaminationRoomController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        protected readonly ILogProvider _logProvider;
        protected readonly IExaminationRoomProvider _examinationRoomProvider;
        protected readonly IFirebaseProvider _firebaseProvider;
        public ExaminationRoomController(ApplicationDbContext db,
                                         IExceptionManager exceptionManager,
                                         ILogProvider logProvider,
                                         IExaminationRoomProvider examinationRoomProvider,
                                         IFirebaseProvider firebaseProvider) : base(db)
        { 
            _exceptionManager = exceptionManager;
            _logProvider = logProvider;
            _examinationRoomProvider = examinationRoomProvider;
            _firebaseProvider = firebaseProvider;
        }
         
        [HttpGet("explore/semesterid={semesterId},ExaminationTypeId={examinationTypeId}")]
        //GET api/room
        public IActionResult Index(long semesterId,long examinationTypeId)
        {
            var examinationRooms =  _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                        .Include(x => x.Course)
                                                            .ThenInclude(x => x.Sections)
                                                        .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                    && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                        .ToList()
                                                        .GroupBy(x => x.CourseId)
                                                        .Select(x => new
                                                                     {
                                                                         CourseId = x.Key,
                                                                         CourseName = x.FirstOrDefault().Course.NameEn,
                                                                         CourseCode = x.FirstOrDefault().Course.Code,
                                                                         FacultyId = x.FirstOrDefault().Course.FacultyId,
                                                                         DepartmentId = x.FirstOrDefault().Course.DepartmentId,
                                                                         TotalSection = x.GroupBy(y => y.SectionId).Count(),
                                                                         TotalStudent = x.Sum(y => y.TotalSeatUsed),
                                                                         TotalRoom = x.GroupBy(y => y.RoomId).Count(),
                                                                         ExaminationSlot = x.Select(y => new 
                                                                                                         {
                                                                                                             Id = y.ExaminationSlotId,
                                                                                                             Date = y.ExaminationSlot.Date,
                                                                                                             TimeStart = y.ExaminationSlot.TimeStart,
                                                                                                             TimeEnd = y.ExaminationSlot.TimeEnd
                                                                                                         })
                                                                                            .FirstOrDefault(),
                                                                         CreatedAt = x.FirstOrDefault().CreatedAt,
                                                                         CreatedBy = Message.CreatedByAutoManual(x.FirstOrDefault().IsAuto, x.FirstOrDefault().CreatedBy)
                                                                     })
                                                        .ToList();
           

            return Ok(examinationRooms);
        }

        [HttpGet("Manual/semesterid={semesterId},ExaminationTypeId={examinationTypeId}")]
        //GET api/room
        public IActionResult Manual(long semesterId,long examinationTypeId)
        {
            var examinationRooms =  _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                        .Include(x => x.Course)
                                                            .ThenInclude(x => x.Sections)
                                                        .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                    && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                    && !x.IsAuto)
                                                        .ToList()
                                                        .GroupBy(x => x.CourseId)
                                                        .Select(x => new
                                                                     {
                                                                         CourseId = x.Key,
                                                                         CourseName = x.FirstOrDefault().Course.NameEn,
                                                                         CourseCode = x.FirstOrDefault().Course.Code,
                                                                         FacultyId = x.FirstOrDefault().Course.FacultyId,
                                                                         DepartmentId = x.FirstOrDefault().Course.DepartmentId,
                                                                         TotalSection = x.GroupBy(y => y.SectionId).Count(),
                                                                         TotalStudent = x.Sum(y => y.TotalSeatUsed),
                                                                         TotalRoom = x.GroupBy(y => y.RoomId).Count(),
                                                                         ExaminationSlot = x.Select(y => new 
                                                                                                         {
                                                                                                             Id = y.ExaminationSlotId,
                                                                                                             Date = y.ExaminationSlot.Date,
                                                                                                             TimeStart = y.ExaminationSlot.TimeStart,
                                                                                                             TimeEnd = y.ExaminationSlot.TimeEnd
                                                                                                         })
                                                                                            .FirstOrDefault(),
                                                                         CreatedAt = x.FirstOrDefault().CreatedAt,
                                                                         CreatedBy = Message.CreatedByAutoManual(x.FirstOrDefault().IsAuto, x.FirstOrDefault().CreatedBy)
                                                                     })
                                                        .ToList();
            
            return Ok(examinationRooms);
        }

        [HttpGet("Auto/semesterid={semesterId},ExaminationTypeId={examinationTypeId}")]
        //GET api/room
        public IActionResult Auto(long semesterId,long examinationTypeId)
        {
            var examinationRooms =  _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                        .Include(x => x.Course)
                                                            .ThenInclude(x => x.Sections)
                                                        .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                    && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                    && x.IsAuto)
                                                        .ToList()
                                                        .GroupBy(x => x.CourseId)
                                                        .Select(x => new
                                                                     {
                                                                         CourseId = x.Key,
                                                                         CourseName = x.FirstOrDefault().Course.NameEn,
                                                                         CourseCode = x.FirstOrDefault().Course.Code,
                                                                         FacultyId = x.FirstOrDefault().Course.FacultyId,
                                                                         DepartmentId = x.FirstOrDefault().Course.DepartmentId,
                                                                         TotalSection = x.GroupBy(y => y.SectionId).Count(),
                                                                         TotalStudent = x.Sum(y => y.TotalSeatUsed),
                                                                         TotalRoom = x.GroupBy(y => y.RoomId).Count(),
                                                                         ExaminationSlot = x.Select(y => new 
                                                                                                         {
                                                                                                             Id = y.ExaminationSlotId,
                                                                                                             Date = y.ExaminationSlot.Date,
                                                                                                             TimeStart = y.ExaminationSlot.TimeStart,
                                                                                                             TimeEnd = y.ExaminationSlot.TimeEnd
                                                                                                         })
                                                                                            .FirstOrDefault(),
                                                                         CreatedAt = x.FirstOrDefault().CreatedAt,
                                                                         CreatedBy = Message.CreatedByAutoManual(x.FirstOrDefault().IsAuto, x.FirstOrDefault().CreatedBy)
                                                                     })
                                                        .ToList();

            return Ok(examinationRooms);
        }

        [HttpGet("detail/semesterid={semesterId},ExaminationTypeId={examinationTypeId},courseid={courseId}")]
        public IActionResult Details(long semesterId, long examinationTypeId, long courseId)
        {
            var courseDetail = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                   .Include(x => x.Course)
                                                   .Include(x => x.Room)
                                                   .Where(x => x.CourseId == courseId
                                                               && x.ExaminationSlot.SemesterId == semesterId
                                                               && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                   .ToList()
                                                   .GroupBy(x => new { x.RoomId, x.ExaminationSlotId })
                                                   .Select(x => new
                                                                {
                                                                    Id = x.Key.RoomId,
                                                                    Name = x.FirstOrDefault().Room.Name,
                                                                    TotalSection = x.GroupBy(y => y.SectionId).Count(),
                                                                    TotalSeat = x.FirstOrDefault().Room.ExamCapacity,
                                                                    TotalStudent = x.Sum(y => y.TotalSeatUsed),
                                                                    ExaminationSlot = x.Select( y => new
                                                                                                     {
                                                                                                         Id = y.ExaminationSlotId,
                                                                                                         Date = y.ExaminationSlot.Date,
                                                                                                         TimeStart = y.ExaminationSlot.TimeStart,
                                                                                                         TimeEnd = y.ExaminationSlot.TimeEnd
                                                                                                     })
                                                                                       .FirstOrDefault(),
                                                                    CreatedAt = x.FirstOrDefault().CreatedAt,
                                                                    CreatedBy = Message.CreatedByAutoManual(x.FirstOrDefault().IsAuto, x.FirstOrDefault().CreatedBy)
                                                                })
                                                   .ToList();
            return Ok(courseDetail);
        }

        [HttpGet("AvailableRoom/ExaminationSlotId={id}")]
        public IActionResult GetRoomByExaminationSlot(long id)
        {
            var usedRooms = _db.ExaminationRooms
                               .Where(x => x.ExaminationSlotId == id)
                               .Select(x => x.RoomId)
                               .Distinct()
                               .ToList();

            var avb_room = _db.Rooms.Include(x => x.Building)
                                    .Where(x => !usedRooms.Contains(x.Id) && x.ExamCapacity != 0 && x.IsActive )
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

            return Ok(avb_room);
        }
        
        [HttpGet("AssignedRoom/ExaminationSlotId={id}")]
        public IActionResult GetAssignedRoom(long id)
        {
            var assignedRooms = _db.ExaminationRooms.Include(x => x.Section)
                                                    .Include(x => x.Room)
                                                        .ThenInclude(x => x.Building)
                                                    .Where(x => x.ExaminationSlotId == id)
                                                    .ToList()
                                                    .GroupBy(x => x.RoomId)
                                                    .Select(x => new
                                                                 {
                                                                     Id = x.Key,
                                                                     Name = x.FirstOrDefault().Room.Name,
                                                                     BuildingName = x.First().Room.Building.NameEn,
                                                                     TotalSection = x.GroupBy(y => y.SectionId).Count(),
                                                                     TotalStudent = x.Sum(y => y.TotalSeatUsed)
                                                                 })
                                                    .ToList();

            return Ok(assignedRooms);
        }
        
        [HttpGet("AssignedRoomCount/Semesterid={id},ExaminationTypeid={typeid}")]
        public IActionResult GetAssignedRoomCount(long id, long typeid)
        {
            var roomCount = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                .Where(x => x.ExaminationSlot.SemesterId == id
                                                            && x.ExaminationSlot.ExaminationTypeId == typeid)
                                                .GroupBy(x => x.RoomId)
                                                .Count();

            return Ok(new { totalUsedRoom = roomCount });
        }

        [HttpGet("ExaminationSlotId={id}")]
        public IActionResult GetExaminationRoomBySlot(long id)
        {
            var rooms = _db.ExaminationRooms.Include(x => x.Room)
                                                .ThenInclude(x => x.Building)
                                                .ThenInclude(x => x.Campus)
                                            .Where(x => x.ExaminationSlotId == id)
                                            .ToList()
                                            .GroupBy(x => x.RoomId)
                                            .Select(x => new
                                                         {
                                                             Id = x.Key,
                                                             Name = x.FirstOrDefault().Room.Name,
                                                             CampusId = x.FirstOrDefault().Room.CampusId,
                                                             CampusName = x.FirstOrDefault().Room.Building.Campus.NameEn,
                                                             BuildingId = x.FirstOrDefault().Room.BuildingId,
                                                             BuildingName = x.FirstOrDefault().Room.Building.NameEn,
                                                             TotalSection = x.Select(y => y.SectionId).Distinct().Count(),
                                                             TotalStudent = x.Sum(y => y.TotalSeatUsed),
                                                             Floor = x.FirstOrDefault().Room.Floor,
                                                             TotalSeat = x.FirstOrDefault().Room.ExamCapacity,
                                                             CreatedAt = x.FirstOrDefault().Room.CreatedAt,
                                                             CreatedBy = Message.CreatedByAutoManual(x.FirstOrDefault().IsAuto, x.FirstOrDefault().CreatedBy)
                                                         })
                                            .ToList();

            return Ok(rooms);
        }

        [HttpGet("detail/courseid={id},roomid={roomid},examinationslotid={slotid}")]
        public IActionResult SeatArrangementDetails(long id, long slotid, long roomid)
        {
           var SeatsArrangement = _db.SeatArrangementResults.Include(x => x.Student)
                                                            .Include(x => x.Section)
                                                            .Where(x => x.CourseId == id 
                                                                        && x.ExaminationSlotId == slotid
                                                                        && x.RoomId == roomid)
                                                            .Select(x => new 
                                                                         {
                                                                             Id = x.StudentId,
                                                                             Code = x.Student.Code,
                                                                             FirstName = x.Student.FirstNameEn,
                                                                             LastName = x.Student.LastNameEn,
                                                                             SectionNumber = x.Section.Number,
                                                                             SeatNumber = x.SeatNumber,
                                                                             RowNumber = x.RowNumber,
                                                                             CreatedAt = x.CreatedAt,
                                                                             CreatedBy = x.CreatedBy,
                                                                             IsActive = x.IsActive
                                                                         })
                                                            .IgnoreQueryFilters()
                                                            .ToList();
                                                            
            return Ok(SeatsArrangement);
        }
        //  [HttpGet("ExamConflict/semesterid={id},ExaminationTypeid={typeid}")]
        // public IActionResult ExamConflictResult(long id, long typeid)
        // {
        //     var examrooms = _db.ExaminationRooms.Where(x => x.ExaminationSlot.SemesterId ==id 
        //                                                     && x.ExaminationSlot.ExaminationTypeId == typeid).ToList();
        //     var conflicts = _db.ExaminationRooms.Where(x => x.ExaminationSlot.SemesterId ==id 
        //                                                     && x.ExaminationSlot.ExaminationTypeId == typeid)
        //                                         .Select(x => new 
        //                                         {   
        //                                             Course = examrooms.Where(y => y.CourseId != x.CourseId
        //                                                                         && y.ExaminationSlotId == x.ExaminationSlotId
        //                                                                         && y.RoomId == x.RoomId)
        //                                                                 .Select()
        //                                         }).ToList(); 
                                                            
        //     return Ok(SeatsArrangement);
        // }
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]ExaminationRoom model)
        {
            if (ModelState.IsValid)
            {
                _db.ExaminationRooms.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]ExaminationRoom model)
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
            ExaminationRoom model = Find(id);
            try
            {
                _db.ExaminationRooms.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        /* 
        !- 1 = Manual
        !- 2 = Auto
        !- 3 = Both
        */  

        [HttpPost("DissolveCourses")]
        public async Task<IActionResult> Dissolve([FromBody] DissolveCourseViewModel model)
        {
            (int, int) result;
            await _firebaseProvider.IsDissolving();
            try 
            {
                if (model.Code == 1)
                {
                    result =  _examinationRoomProvider.RemoveAllManualAssign(model.SemesterId, model.ExaminationTypeId);
                } 
                else if (model.Code == 2)
                {
                    result =  _examinationRoomProvider.RemoveAllAutoAssign(model.SemesterId, model.ExaminationTypeId);
                }
                else if (model.Code == 3)
                {
                    result =  _examinationRoomProvider.RemoveAll(model.SemesterId, model.ExaminationTypeId);
                }
                else 
                {
                    await _firebaseProvider.FinishDissolving();
                    return BadRequest(new {
                        IsSuccess = false,
                        Response = Message.InvalidDissolvingCode
                    });
                }
            }
            catch
            {
                await _firebaseProvider.FinishDissolving();
                return StatusCode(500, new { IsSuccess = false, Response = Message.ErrorOccurred });
            }

            if (result.Item1 == 0 && result.Item2 == 0)
            {
                await _firebaseProvider.FinishDissolving();
                return Ok(new
                          {
                              IsSuccess = false,
                              Response= Message.NoDataToDissolve
                          });
            }
            else
            {
                await _firebaseProvider.FinishDissolving();
                _logProvider.RecordDissolved(model.Code, model.User, model.SemesterId, model.ExaminationTypeId);
                return Ok(new 
                          {
                              IsSuccess = true,
                              Response = new 
                                         {
                                             ExaminationRoomRemoved = result.Item1,
                                             SeatArrangementRemoved = result.Item2
                                         }
                          });
            }
        }

        [HttpPost("DissolveCourse")]
        public async Task<IActionResult> DissolveByCourseId([FromBody] DissolveCourseViewModel model)
        {
            await _firebaseProvider.IsDissolving();
            var deleteExaminationRoomList = _db.ExaminationRooms.Where(x => x.CourseId == model.CourseId
                                                                            && x.ExaminationSlotId == model.ExaminationSlotId);

            var deleteSeatList = _db.SeatArrangementResults.Where(x => x.CourseId == model.CourseId
                                                                       && x.ExaminationSlotId == model.ExaminationSlotId);
            
            var countExamRoom = deleteExaminationRoomList.Count();
            var countSeat = deleteSeatList.Count();

            if (countExamRoom == 0 && countSeat == 0)
            {
                await _firebaseProvider.FinishDissolving();
                return Ok(new
                          {
                              IsSuccess = false,
                              Response = Message.NoDataToDissolve
                          });
            }

            try
            {
                var courseName = _db.Courses.SingleOrDefault(x => x.Id == model.CourseId)?.CodeAndName;
                var examinationSlot = _db.ExaminationSlots.SingleOrDefault(x => x.Id == model.ExaminationSlotId);
                _logProvider.RecordDissolved(courseName, model.User, examinationSlot.SemesterId, examinationSlot.ExaminationTypeId);

                using (var context = new ApplicationDbContextChild())
                {
                    await context.BulkDeleteAsync<ExaminationRoom>(deleteExaminationRoomList);
                    await context.BulkDeleteAsync<SeatArrangementResult>(deleteSeatList);
                }
                
            }
            catch
            {
                await _firebaseProvider.FinishDissolving();
                return StatusCode(500, new { IsSuccess = false, Response = Message.ErrorOccurred });
            }
            
            await _firebaseProvider.FinishDissolving();
            return Ok(new
                      {
                          IsSuccess = true,
                          Response = new 
                                     {
                                        ExaminationRoomRemoved = countExamRoom,
                                        SeatArrangementRemoved = countSeat
                                     }
                      });
        }
        private ExaminationRoom Find(long? id) 
        {
            return _db.ExaminationRooms.Find(id);
        }

    }
}
