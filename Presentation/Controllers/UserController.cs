using Application.User.Commands;
using Application.User.Queries;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers 
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private GetUserQuery GetUserQuery;
        private CreateUserCommand CreateUserCommand;

        public UserController(GetUserQuery getUserQuery, CreateUserCommand createUserCommand)
        {
            GetUserQuery = getUserQuery;
            CreateUserCommand = createUserCommand;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult getUser(string id)
        {
            try {
                return Ok(GetUserQuery.getById(id));
            } catch (UserNotFoundException e) {
                return NotFound(e.Message);
            }
        }

        [Route("{username}/{name}/{lastname}/{email}")]
        [HttpPost]
        public ActionResult<User> createUser(string username, string name, string lastname, string email)
        {
            try {
                CreateUserCommand.handle(username, name, lastname, email);
            } catch (UserExistsByEmailException e) {
                return NotFound(e.Message);
            }

            return Ok("User created successfully.");
        }
    }

}