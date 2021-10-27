using System;
using System.Linq;
using System.Threading.Tasks;
using ARMSAPI.Data;
using ARMSAPI.Interfaces;
using ARMSAPI.Models;
using ARMSAPI.Models.DataModels;
using ARMSAPI.Models.DataModels.MasterTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Controllers
{
     [Route("api/[controller]")]
    public class StudentStudyCourseController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public StudentStudyCourseController(ApplicationDbContext db,
                                            IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        //GET api/room
        public IActionResult Index()
        {
            var studentstudycourses = _db.StudentStudyCourses.Include(x => x.Course)
                                                             .Include(x => x.Section)
                                                             .ToList();
                                                             
            return Ok(studentstudycourses);
        }


        [HttpGet("courseid={id},semesterid={semid}")]
        public IActionResult GetStudentsByCourseAndSemester(long id,long semid)
        {
            var students = _db.StudentStudyCourses.Include(x => x.Student)
                                                  .Include(x => x.Section)
                                                  .Where(x => x.CourseId == id 
                                                              && x.SemesterId== semid)
                                                  .ToList();
                                                  
            return Ok(students);
        }
        [HttpGet("sectionid={id},semesterid={semid}")]
        public IActionResult GetStudentsBySectionAndSemester(long id,long semid)
        {
            var students = _db.StudentStudyCourses.Include(x => x.Student)
                                                  .Include(x => x.Section)
                                                  .Where(x => x.SectionId == id 
                                                              && x.SemesterId== semid)
                                                  .ToList();                                   

            return Ok(students);
        }
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]StudyCourse model)
        {
            if (ModelState.IsValid)
            {
                _db.StudentStudyCourses.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]Faculty model)
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
            Faculty model = Find(id);
            try
            {
                _db.Faculties.Remove(model);
                _db.SaveChanges();
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }

            return Ok(Message.DeleteSuccessful);
        }

        private Faculty Find(long? id) 
        {
            return _db.Faculties.Find(id);
        }

    }
}
