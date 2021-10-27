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
    public class DepartmentController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public DepartmentController(ApplicationDbContext db,
                                    IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        //GET api/room
        [HttpGet("SelectList")]
        public IActionResult Index()
        {
            var departments = _db.Departments.Select(x => new   
                                                          {
                                                              x.Id,
                                                              x.NameEn,
                                                              x.FacultyId
                                                          })
                                             .ToList();
                                             
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var department = _db.Departments.Include(x => x.Faculty)
                                            .SingleOrDefault(x => x.Id == id);
                                       
            return Ok(department);
        }

        
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Department model)
        {
            if (ModelState.IsValid)
            {
                _db.Departments.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]Department model)
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
            Department model = Find(id);
            try
            {
                _db.Departments.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Department Find(long? id) 
        {
            return _db.Departments.Find(id);
        }

    }
}
