using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QATaskAPI7.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/user/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            User user = new User();

            if (user == null)
            {
                return BadRequest();
            }

            user.Id = id;
            user.Name = "TestName";
            user.Email = "test@test.test";

            return Ok(new { user });
        }

        [HttpPost]
        [Route("api/user/")]
        public IHttpActionResult PosUser(User user)
        {
            User newUser = new User();
            newUser = user;

            return Ok();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
    }
}
