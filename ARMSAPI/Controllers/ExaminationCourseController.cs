using System.Linq;
using ARMSAPI.Data;
using ARMSAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExaminationCourseController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public ExaminationCourseController(ApplicationDbContext db) : base(db)
        { }
     
        [HttpGet("GetSection/CourseId={courseId},SemesterId={semesterId}")]
        public IActionResult GetSectionByCourseAndSemester(long courseId, long semesterId)
        {
            var sections = _db.Sections.Where(x => x.CourseId == courseId
                                                    && x.SemesterId == semesterId )
                                       .Select(x => new
                                                    {
                                                        Id = x.Id,
                                                        Number = x.Number,
                                                        SeatUsed = x.SeatUsed,
                                                        CreatedBy = x.CreatedBy,
                                                        CreatedAt = x.CreatedAt,
                                                        IsActive = x.IsActive
                                                    })
                                       .ToList();

            return Ok(sections);
        }

        [HttpGet("GetStudent/SectionId={id}")]
        public IActionResult GetStudentFromSection(long id)
        {
            var result = _db.StudentStudyCourses.Include(x => x.Student)
                                                .Include(x => x.Section)
                                                .Where(x => x.SectionId == id )
                                                .Select(x => new
                                                             {
                                                                 StudentId = x.StudentId,
                                                                 Code = x.Student.Code,
                                                                 FirstName = x.Student.FirstNameEn,
                                                                 LastName = x.Student.LastNameEn,
                                                                 x.Student.CreatedAt,
                                                                 x.Student.CreatedBy,
                                                                 x.Student.IsActive
                                                             })
                                                .OrderBy(x => x.Code)
                                                .ToList();
            
            return Ok(result);
        }

        [HttpGet("unassigned/semesterid={semesterId},ExaminationTypeId={examinationTypeId}")]
        //GET api/room
        public IActionResult GetAllUnassignedCourses(long semesterId, long examinationTypeId)
        {
            var assignedCourseIds = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                        .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                    && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                        .Select(x => x.CourseId )
                                                        .Distinct()
                                                        .ToList();
            
            var unassignedCourses = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                                                              .Include(x => x.Course)
                                                                  .ThenInclude(x => x.Sections)
                                                              .Where(x => !assignedCourseIds.Contains(x.CourseId)
                                                                          && x.ExaminationSlot.SemesterId == semesterId
                                                                          && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                              .OrderBy(x => x.Course.Code)
                                                              .Select(x => new
                                                                           {
                                                                               Id = x.CourseId,
                                                                               Name = x.Course.NameEn,
                                                                               Code = x.Course.Code,
                                                                               FacultyId = x.Course.FacultyId,
                                                                               DepartmentId = x.Course.DepartmentId,
                                                                               ExaminationSlot = new 
                                                                                                 {
                                                                                                     Id = x.ExaminationSlotId,
                                                                                                     Date = x.ExaminationSlot.Date,
                                                                                                     TimeStart = x.ExaminationSlot.TimeStart,
                                                                                                     TimeEnd = x.ExaminationSlot.TimeEnd
                                                                                                 },
                                                                               TotalSection = x.Course.Sections.Count(y => y.SemesterId == semesterId),
                                                                               TotalStudent = x.Course.Sections.Where(y => y.SemesterId == semesterId)
                                                                                                               .Sum(y => y.SeatUsed)
                                                                           })
                                                              .Where(x => x.TotalSection != 0)
                                                              .Distinct()
                                                              .ToList();
            // var assignedCourseIds = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
            //                                             .Where(x => x.ExaminationSlot.SemesterId == semesterId
            //                                                         && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
            //                                             .Select(x => new{ x.CourseId, x.TotalSeatUsed })
            //                                             .Distinct()
            //                                             .ToList();
            //
            // var unassignedCourses = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
            //                                                   .Include(x => x.Course)
            //                                                       .ThenInclude(x => x.Sections)
            //                                                   .Where(x => !assignedCourseIds.Select(y => y.CourseId).Contains(x.CourseId)
            //                                                               && assignedCourseIds.Where(y => y.CourseId == x.CourseId).Sum(y => y.TotalSeatUsed) != x.Course.Sections.Sum(o => o.SeatUsed)
            //                                                               && x.ExaminationSlot.SemesterId == semesterId
            //                                                               && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
            //                                                   .OrderBy(x => x.Course.Code)
            //                                                   .Select(x => new
            //                                                                {
            //                                                                    Id = x.CourseId,
            //                                                                    Name = x.Course.NameEn,
            //                                                                    Code = x.Course.Code,
            //                                                                    FacultyId = x.Course.FacultyId,
            //                                                                    DepartmentId = x.Course.DepartmentId,
            //                                                                    ExaminationSlot = new 
            //                                                                                      {
            //                                                                                          Id = x.ExaminationSlotId,
            //                                                                                          Date = x.ExaminationSlot.Date,
            //                                                                                          TimeStart = x.ExaminationSlot.TimeStart,
            //                                                                                          TimeEnd = x.ExaminationSlot.TimeEnd
            //                                                                                      },
            //                                                                    TotalSection = x.Course.Sections.Count(y => y.SemesterId == semesterId),
            //                                                                    TotalStudent = x.Course.Sections.Where(y => y.SemesterId == semesterId)
            //                                                                                                    .Sum(y => y.SeatUsed)
            //                                                                })
            //                                                   .Where(x => x.TotalSection != 0)
            //                                                   .Distinct()
            //                                                   .ToList();

            return Ok(unassignedCourses);
        }

        [HttpGet("unassigned/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}")]
        public IActionResult SelectListUnassigned(long semesterId, long examinationTypeId)
        {
            var assignedCourseIds = _db.ExaminationRooms.Include(x => x.ExaminationSlot)
                                                        .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                    && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                        .Select(x => x.CourseId)
                                                        .Distinct()
                                                        .ToList();

            var unassignedCourses = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                                                              .Include(x => x.Course)
                                                              .Where(x => !assignedCourseIds.Contains(x.CourseId)
                                                                          && x.ExaminationSlot.SemesterId == semesterId
                                                                          && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                          && x.Course.Sections.Any(y => y.SemesterId == semesterId))
                                                              .OrderBy(x => x.Course.Code)
                                                              .Select(x => new
                                                                           {
                                                                               Id = x.CourseId,
                                                                               Code = x.Course.Code,
                                                                               FacultyId = x.Course.FacultyId,
                                                                               DepartmentId = x.Course.DepartmentId
                                                                           })
                                                              .Distinct()
                                                              .ToList();
            return Ok(unassignedCourses);
        }

        [HttpGet("assigned/SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}")]
        public IActionResult SelectListAssigned(long semesterId, long examinationTypeId)
        {
            var assignedCourses = _db.ExaminationRooms.Include(x => x.Course)
                                                      .Include(x => x.ExaminationSlot)
                                                      .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                  && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                                      .OrderBy(x => x.Course.Code)
                                                      .Select(x => new
                                                                   {
                                                                       Id = x.CourseId,
                                                                       Code = x.Course.Code,
                                                                       FacultyId = x.Course.FacultyId,
                                                                       DepartmentId = x.Course.DepartmentId
                                                                   })
                                                      .Distinct()
                                                      .ToList();
            return Ok(assignedCourses);
        }
        
        [HttpGet("sectionlist/Semesterid={id},Courseid={courseId}")]
        public IActionResult GetSectionsByCourseAndSlot(long id, long courseId) 
        {
            var sections = _db.Sections.Where(x => x.CourseId == courseId && x.SemesterId == id)
                                        .Select(x => new
                                            {
                                                Id = x.Id,
                                                Number = x.Number,
                                                CampusId = x.SectionDetails.FirstOrDefault().CampusId,
                                                CampusName = x.SectionDetails.FirstOrDefault().Campus.NameEn,
                                                SeatUsed = x.SeatUsed
                                            })
                                            .ToList();

          
            return Ok(sections);              
        }

        [HttpGet("SelectList/SemesterId={semesterId},ExaminationTypeId={examinationTypeId}")]
        public IActionResult SelectList(long semesterId, long examinationTypeId)
        {
            var result = _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                                                   .Include(x => x.Course)
                                                        .ThenInclude(x => x.Sections)
                                                   .Where(x => x.ExaminationSlot.SemesterId == semesterId 
                                                               && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                               && x.Course.Sections.Any(y => y.SemesterId == semesterId))
                                                   .OrderBy(x => x.Course.Code)
                                                   .Select(x => new
                                                                {
                                                                    Id = x.CourseId,
                                                                    Code = x.Course.Code,
                                                                    FacultyId = x.Course.FacultyId,
                                                                    DepartmentId =x.Course.DepartmentId
                                                                })
                                                   .Distinct()
                                                   .ToList();

            return Ok(result);
        }
    }
}
