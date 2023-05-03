using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace QATaskAPI7.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/user/get/{id}")]
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
        
        [HttpGet]
        [Route("api/users/get/")]
        public IHttpActionResult GetUsers()
        {
            List<User> list = new List<User>();
            User user = new User();

            if (user == null)
            {
                return BadRequest();
            }

            user.Id = 2;
            user.Name = "TestName";
            user.Email = "test@test.test";
            
            list.Add(user);
            list.Add(user);
            list.Add(user);
            list.Add(user);

            return Ok(new { list });
        }

        [HttpPost]
        [Route("api/user/post/")]
        public IHttpActionResult Post(int id, String name, String email)
        {
            User newUser = new User();
            newUser.Id = id;
            newUser.Email = email;
            newUser.Name = name;

            return Ok(newUser);
        }

        [HttpDelete]
        [Route("api/user/delete/{name}")]
        public IHttpActionResult DeleteUser(String name)
        {
          
           return Ok();
        }

        [HttpPut]
        [Route("api/user/put/{id}")]
        public async Task<IHttpActionResult>  PutUser(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
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
