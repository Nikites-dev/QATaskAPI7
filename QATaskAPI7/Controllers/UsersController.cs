using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using QATaskAPI7.Models;

namespace QATaskAPI7.Controllers
{
    public class UsersController : ApiController
    {
        private QATaskAPIEntities3 Connection = new QATaskAPIEntities3();

        [HttpGet]
        [Route("api/user/get/{name}")]
        public IHttpActionResult GetUser(String name)
        {
            var foundUser = Connection.User.FirstOrDefault(x => x.Name == name);
            
            if (foundUser == null)
            {
                return BadRequest("user not found");
            }

            return Ok(new
            {
                foundUser.Name, 
                foundUser.Age
            });
        }
        
        [HttpGet]
        [Route("api/users/get/")]
        public IHttpActionResult GetUsers()
        {
            var list = Connection.User.ToList();

            if (list == null)
            {
                return BadRequest();
            }
            return Ok(list.Select(u => new
            { u.Id, u.Name, u.Age, RoleName = u.Role.Name }));
        }

        [HttpPost]
        [Route("api/user/post/")]
        public IHttpActionResult Post(User user)
        {
            if (user != null)
            {
                Connection.User.Add(user);
                Connection.SaveChanges();
                return Ok("add succes!");
            }
            return BadRequest("something wrong!");

        }

        [HttpDelete]
        [Route("api/user/delete/{name}")]
        public IHttpActionResult DeleteUser(String name)
        {
            var product = Connection.User.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return BadRequest("user not found");
            }

            Connection.User.Remove(product);
            Connection.SaveChanges();
            return Ok(true);
        }

        [HttpPut]
        [Route("api/user/put/{id}")]
        public async Task<IHttpActionResult>  PutUser(int? id)
        {
            var user = Connection.User.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("user not found");
            }

            Connection.Entry(user).State = EntityState.Modified;
            Connection.SaveChanges();
            return Ok();
        }
    }
    
}
