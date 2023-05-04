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
        private QATaskAPIEntities1 Connection = new QATaskAPIEntities1();

        [HttpGet]
        [Route("api/user/get/{id}")]
        public IHttpActionResult GetUser(String name)
        {
            var foundUser = Connection.Product.FirstOrDefault(x => x.Name == name);
            
            if (foundUser == null)
            {
                return BadRequest("user not found");
            }

            return Ok(new
            {
                foundUser.Name, 
                foundUser.Cost
            });
        }
        
        [HttpGet]
        [Route("api/users/get/")]
        public IHttpActionResult GetUsers()
        {
            var list = Connection.Product.ToList();

            if (list == null)
            {
                return BadRequest();
            }
            return Ok(new { list });
        }

        [HttpPost]
        [Route("api/user/post/")]
        public IHttpActionResult Post(Product product)
        {
            if (product != null)
            {
                Connection.Product.Add(product);
                Connection.SaveChanges();
                return Ok("add succes!");
            }
            return BadRequest("something wrong!");

        }

        [HttpDelete]
        [Route("api/user/delete/{name}")]
        public IHttpActionResult DeleteUser(String name)
        {
            var product = Connection.Product.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return BadRequest("user not found");
            }

            Connection.Product.Remove(product);
            Connection.SaveChanges();
            return Ok(true);
        }

        [HttpPut]
        [Route("api/user/put/{id}")]
        public async Task<IHttpActionResult>  PutUser(int? id)
        {
            var user = Connection.Product.FirstOrDefault(x => x.ID == id);

            if (user == null)
            {
                return BadRequest("user not found");
            }

            Connection.Entry(user).State = EntityState.Modified;
            Connection.SaveChanges();
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
