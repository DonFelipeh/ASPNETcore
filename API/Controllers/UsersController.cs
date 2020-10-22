using API.Data;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
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
      
        //using system.Collection.Generic  for IEnumerable
        //using API.Entities for AppUser
        //Synchronous
/*      public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
         //using system.Linq
         var users =_context.Users.ToList();  
         return users;
        } */
         [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //using Microsoft.EntityFrameworkCore;
            var users = await _context.Users.ToListAsync(); 
            return users;
        }       
      
/*      public ActionResult<AppUser> GetUser(int id)
        {
            var user =_context.Users.Find(id);           
            return user;
        }  */
         [HttpGet("{id}")]  //api/users/3
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);         
            return user;
        }
        
    }
}