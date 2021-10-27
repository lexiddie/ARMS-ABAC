using System.Linq;
using ARMSAPI.Data;
using ARMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        public StudentController(ApplicationDbContext db) : base(db) { }

        public IActionResult StudentExamScheduleWithNullCourse(long semesterId, long examinationTypeId, string studentCode)
        {
            var joinedStudentSeats = (from student in _db.StudentStudyCourses.Include(x => x.Section)
                                                                          .Include(x => x.Course)
                                                                          .Include(x => x.Student)
                                                                          .Where(x => x.Student.Code == studentCode)
                                   join seat in _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                                          .Include(x => x.Student)
                                                                          .Include(x => x.Room)
                                                                          .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                                      && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                                      && x.Student.Code == studentCode)
                                        on student.SectionId equals seat.SectionId into joinedSeat
                                   from resultSeat in joinedSeat.DefaultIfEmpty()
                                   join courseSlot in _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                                                                                .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                                            && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                        on student.CourseId equals courseSlot.CourseId into joinedCourseSlot
                                   from resultCourseSlot in joinedCourseSlot.DefaultIfEmpty()
                                   select new 
                                          {
                                              StudentStudyCourse = student,
                                              ExaminationSeat = resultSeat,
                                              CourseSlot = resultCourseSlot
                                          }).ToList();

            if (joinedStudentSeats.Count == 0)
            {
                return Ok(new { IsSuccess = false, Response = Message.StudentNotFound });
            }

            var studentSchedule = new
                                  {
                                      Id = joinedStudentSeats.First().StudentStudyCourse.StudentId,
                                      StudentCode = joinedStudentSeats.First().StudentStudyCourse.Student.Code,
                                      FirstName = joinedStudentSeats.First().StudentStudyCourse.Student.FirstNameEn,
                                      LastName = joinedStudentSeats.First().StudentStudyCourse.Student.LastNameEn,
                                      ExaminationCourses = joinedStudentSeats.Select(x => new
                                                                                          {
                                                                                              Id = x.StudentStudyCourse.CourseId,
                                                                                              Code = x.StudentStudyCourse.Course.Code,
                                                                                              Name = x.StudentStudyCourse.Course.NameEn,
                                                                                              SectionNumber = x.StudentStudyCourse.Section.Number,
                                                                                              RoomName = x.ExaminationSeat?.Room?.Name ?? null,
                                                                                              Seat = x.ExaminationSeat?.RowSeat ?? null,
                                                                                              ExamDate = x.CourseSlot?.ExaminationSlot.Date ?? null,
                                                                                              StartTime = x.CourseSlot?.ExaminationSlot?.TimeStart ?? null,
                                                                                              EndTime = x.CourseSlot?.ExaminationSlot?.TimeEnd ?? null
                                                                                          })
                                                                             .ToList()
                                  };

            return Ok(new { IsSuccess = true, Respomse = studentSchedule });
        }

        [HttpGet("semesterId={semesterId},examinationTypeId={examinationTypeId},studentCode={studentCode}")]
        public IActionResult StudentExamSchedule(long semesterId, long examinationTypeId, string studentCode)
        {
            var joinedStudentSeats = (from student in _db.StudentStudyCourses.Include(x => x.Course)
                                                                             .Include(x => x.Student)
                                                                             .Include(x => x.Section)
                                                                             .Where(x => x.Student.Code == studentCode
                                                                                         && x.SemesterId == semesterId)
                                     join seat in _db.SeatArrangementResults.Include(x => x.ExaminationSlot)
                                                                            .Include(x => x.Student)
                                                                            .Include(x => x.Room)
                                                                            .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                                        && x.ExaminationSlot.ExaminationTypeId == examinationTypeId
                                                                                        && x.Student.Code == studentCode)
                                          on student.SectionId equals seat.SectionId into joinedSeat
                                     from resultSeat in joinedSeat.DefaultIfEmpty()
                                     join courseSlot in _db.CourseExaminationSlots.Include(x => x.ExaminationSlot)
                                                                                  .Where(x => x.ExaminationSlot.SemesterId == semesterId
                                                                                              && x.ExaminationSlot.ExaminationTypeId == examinationTypeId)
                                          on student.CourseId equals courseSlot.CourseId into joinedCourseSlot
                                     from resultCourseSlot in joinedCourseSlot.DefaultIfEmpty()
                                     select new 
                                            {
                                                StudentStudyCourse = student,
                                                ExaminationSeat = resultSeat,
                                                CourseSlot = resultCourseSlot
                                            })
                                     .ToList();

            if (joinedStudentSeats.Count == 0)
            {
                return BadRequest();
            }

            var studentSchedule = new
                                  {
                                      Id = joinedStudentSeats.First().StudentStudyCourse.StudentId,
                                      StudentCode = joinedStudentSeats.First().StudentStudyCourse.Student.Code,
                                      FirstName = joinedStudentSeats.First().StudentStudyCourse.Student.FirstNameEn,
                                      LastName = joinedStudentSeats.First().StudentStudyCourse.Student.LastNameEn,
                                      ExaminationCourses = joinedStudentSeats.Select(x => new
                                                                                          {
                                                                                              Id = x.StudentStudyCourse.CourseId,
                                                                                              Code = x.StudentStudyCourse.Course.Code,
                                                                                              Name = x.StudentStudyCourse.Course.NameEn,
                                                                                              SectionNumber = x.StudentStudyCourse.Section.Number,
                                                                                              RoomName = x.ExaminationSeat?.Room?.Name ?? null,
                                                                                              Seat = x.ExaminationSeat?.RowSeat ?? null,
                                                                                              ExamDate = x.CourseSlot?.ExaminationSlot.Date ?? null,
                                                                                              StartTime = x.CourseSlot?.ExaminationSlot?.TimeStart ?? null,
                                                                                              EndTime = x.CourseSlot?.ExaminationSlot?.TimeEnd ?? null
                                                                                          })
                                                                             .Where(x => x.ExamDate != null)
                                                                             .Distinct()
                                                                             .ToList()
                                  };

            return Ok(studentSchedule);
        }
    }
}
