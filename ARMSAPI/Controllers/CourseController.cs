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
    public class CourseController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public CourseController(ApplicationDbContext db,
                                IExceptionManager exceptionManager) : base(db)
        {
            _exceptionManager = exceptionManager;
        }
        

        //GET api/room
        public IActionResult Index()
        {             
                                     
           var courses = _db.Courses.Select(x => new 
                                                 {
                                                     x.Id,
                                                     Code = x.Code.Trim(),
                                                     x.NameEn,
                                                     x.AcademicLevelId,
                                                     x.FacultyId,
                                                     x.DepartmentId,
                                                     x.CreatedAt,
                                                     x.CreatedBy,
                                                     x.IsActive
                                                 })
                                    .IgnoreQueryFilters()
                                    .ToList();
                                    
            return Ok(courses);
        }

        [HttpGet("Selectlist")]
        public IActionResult Selectlist() 
        {
            var courses = _db.Courses.Select(x => new 
                                                  {
                                                      x.Id,
                                                      Code = x.Code.Trim(),
                                                      x.FacultyId,
                                                      x.DepartmentId
                                                  })
                                     .ToList();

            return Ok(courses);
        }

        [HttpGet("StudyCourse/SelectList/SemesterId={id}")]
        public IActionResult GetStudyCourse(long id)
        {
            var studyCourses = _db.Courses.Include(x => x.Sections)
                                          .Where(x => x.Sections.Any(y => y.SemesterId == id))
                                          .Select(x => new 
                                                       {
                                                           Id = x.Id,
                                                           Code = x.Code.Trim(),
                                                           FacultyId = x.FacultyId,
                                                           DepartmentId = x.DepartmentId,
                                                       })
                                          .ToList();

            return Ok(studyCourses);
        }


        [HttpGet("StudyCourses/semesterid={id}")]
        public IActionResult GetAllStudyCourses(long id)
        {
            var StudyCourses = _db.Courses.Include(x => x.Sections)
                                          .Include(x => x.Faculty)
                                          .Include(x => x.Department)
                                          .Include(x => x.CourseExaminationSlots)
                                              .ThenInclude(x => x.ExaminationSlot)
                                          .Where(x => x.Sections.Any(y => y.SemesterId == id))
                                          .Select(x => new
                                                       {
                                                           CourseId = x.Id,
                                                           Coursecode = x.Code.Trim(),
                                                           CourseName = x.NameEn,
                                                           FacultyName = x.Faculty.NameEn,
                                                           DepartmentName = x.Department.NameEn,
                                                           IsMidterm = x.CourseExaminationSlots.Any(y => y.ExaminationSlot.ExaminationTypeId == 1),
                                                           IsFinal = x.CourseExaminationSlots.Any(y => y.ExaminationSlot.ExaminationTypeId == 2)
                                                       })
                                          .ToList();
            
            return Ok(StudyCourses);
        }
       
        [HttpGet("courseid={id},semesterid={semesterId}")]
        public IActionResult Details(long id,long semesterId)
        {
            var section = _db.Sections.Include(x => x.Course)
                                      .Where(x => x.CourseId == id
                                                  && x.SemesterId == semesterId)
                                      .GroupBy(x => x.CourseId)
                                      .Select(x => new
                                                   {
                                                       Id = x.FirstOrDefault().CourseId,
                                                       CourseName = x.FirstOrDefault().Course.NameEn,
                                                       CourseCode = x.FirstOrDefault().Course.Code.Trim(),
                                                       Section = x
                                                   })
                                      .ToList();

            return Ok(section);
        }
        
        [HttpGet("count")]
        public IActionResult CoursesCount()
        {
            var Count = _db.Courses.Count();

            return Ok(Count);
        }

        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Course model)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]Course model)
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
            Course model = Find(id);
            try
            {
                _db.Courses.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Course Find(long? id) 
        {
            return _db.Courses.Find(id);
        }

    }
}
