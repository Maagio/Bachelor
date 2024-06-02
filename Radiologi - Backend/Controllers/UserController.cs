using Microsoft.AspNetCore.Mvc;
using Radiologi___Backend.Models;
using Radiologi___Backend.Storage;

namespace Radiologi___Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserDB db = new UserDB();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{Id}", Name = "GetUserById")]
        public User GetUserById(string Id)
        {
            User foundUser = db.FindUserById(Id);

            return foundUser;
        }

        [HttpGet("Classes/{userId}", Name = "GetClassesByUserId")]
        public List<string> GetClassesByUserId(string userId)
        {
            List<string> classes = db.GetClassesByUserId(userId);

            return classes;
        }

        [HttpPost("{Name}", Name = "GetByName")]
        public User Login (User user)
        {
            User foundUser = db.FindUser(user);

            return foundUser;
        }

        [HttpPost]
        public void CreateUser(User user)
        {
            db.CreateUser(user);
        }
    }
}