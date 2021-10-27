using Microsoft.AspNetCore.Mvc;
using ARMSAPI.Data;

namespace ARMSAPI.Controllers
{
    // [Authorize]
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _db;
        public BaseController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
