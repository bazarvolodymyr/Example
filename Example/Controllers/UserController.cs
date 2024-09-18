using DAL.EF;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Example.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo) 
        { 
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRepo.GetAll());
        }
        
        [HttpPost]
        public ActionResult AddOne(User entity)
        {
            //var newUser = new User { Name = entity.Name };
            try
            {
                _userRepo.Add(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return CreatedAtAction(nameof(FindUsers), new { id = entity.Id }, entity);
            
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult FindUsers(int id)
        {
            return Ok(_userRepo.Find(id));
        }

    }
}
