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
    public class RoomTypeController : BaseController
    {
        protected readonly IExceptionManager _exceptionManager; 
        public RoomTypeController(ApplicationDbContext db,
                                  IExceptionManager exceptionManager) : base(db)
        { 
            _exceptionManager = exceptionManager;
        }
        

        //GET api/room
        public IActionResult Index()
        {
            return Ok(_db.RoomTypes.ToList());
        }
        
        //POST api/room from body
        [HttpPost]
        public IActionResult Create([FromBody]RoomType model)
        {
            if (ModelState.IsValid)
            {
                _db.RoomTypes.Add(model);
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
        public async Task<IActionResult> Edit(long id,[FromBody]RoomType model)
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
            RoomType model = Find(id);
            try
            {
                _db.RoomTypes.Remove(model);
                _db.SaveChanges();
                return Ok(Message.DeleteSuccessful);
            }
            catch
            {
                return Ok(Message.UnableToDelete);
            }
        }

        private  RoomType Find(long? id) 
        {
            return _db.RoomTypes.Find(id);
        }

    }
}
