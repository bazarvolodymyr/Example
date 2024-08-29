using DAL.EF;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

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
            //var oleg = new User() { Name = "Oleg" };
            //db.Users.Add(oleg);
            //db.SaveChanges();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            //var users = db.Users.ToList();
            //var users = new[]
            //{
            //    new { Name = "Oleg" },
            //    new { Name = "Ivan" }
            //};
            return Ok(_userRepo.GetAll());
        }
        /// <summary>
        /// Adds a single record
        /// </summary>
        /// <remarks>
        /// Sample body:
        /// <pre>
        /// {
        ///     "Id": 1,
        ///     "TimeStamp": "AAAAAAAAB+E="
        ///     "User": "Name",
        ///     
        /// }
        /// </pre>
        /// </remarks>
        /// <returns>Added record</returns>
        /// <response code="201">Found and updated the record</response>
        /// <response code="400">Bad request</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(201, "The execution was successful")]
        //[SwaggerResponse(400, "The request was invalid")]
        [HttpPost]
        public ActionResult AddOne(User entity)
        {
            //var newUser = new User { Name = entity.Name };
            //try
            //{
            //    db.Users.Add(newUser);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}
            //return CreatedAtAction("Create", new { id = entity.Id }, newUser);
            return Ok(entity);
        }

    }
}
