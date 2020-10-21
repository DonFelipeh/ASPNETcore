using System.Diagnostics;
using System.Linq;
using API.Entities;
using System.Collections.Generic;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //using system.Collection.Generic  for IEnumerable
        //using API.Entities for AppUser

        //Synchronous
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        //{
           //using system.Linq
        //  var users =_context.Users.ToList();  
        //  return await users;
        //}
        //public ActionResult<AppUser> GetUser(int id)
        //{
        //    var user =_context.Users.Find(id);
            
        //    return user;
        //}        
        public async Tasks<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //using Microsoft.EntityFrameworkCore;
            var users =_context.Users.ToListAsync(); 
            return await users;

        }
        //api/users/3
        [HttpGet("{id}")]
        public async Tasks<ActionResult<AppUser>> GetUser(int id)
        {
            var user =_context.Users.FindAsync(id);
            
            return await user;
        }
    }
}