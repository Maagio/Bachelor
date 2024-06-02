using Microsoft.AspNetCore.Mvc;
using Radiologi___Backend.Models;
using Radiologi___Backend.Storage;

namespace Radiologi___Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private IClassDB db = new ClassDB();

        [HttpPost]
        public void CreateClass(Class newClass)
        {
            db.CreateClass(newClass);
        }

        [HttpGet("{classId}", Name = "GetClassById")]
        public Class GetClassById(string classId)
        {
            Class newClass = db.GetClassById(classId);

            return newClass;
        }
    }
}
