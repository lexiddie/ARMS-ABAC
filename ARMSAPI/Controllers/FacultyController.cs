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
    public class FacultyController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public FacultyController(ApplicationDbContext db,
                                 IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }

        //GET api/room
        [HttpGet("SelectList")]
        public IActionResult Index()
        {
            var faculties = _db.Faculties.Select(x => new 
                                                      {
                                                          x.Id,
                                                          x.Abbreviation
                                                      })
                                         .ToList();

            return Ok(faculties);
        }
        [HttpGet("{id}")]
        public IActionResult Details(long id)
        {
            var faculty = _db.Faculties.Include(x => x.Departments)
                                       .SingleOrDefault(x => x.Id == id);

            return Ok(faculty);
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]Faculty model)
        {
            if (ModelState.IsValid)
            {
                _db.Faculties.Add(model);
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
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private Faculty Find(long? id) 
        {
            return _db.Faculties.Find(id);
        }

    }
}
