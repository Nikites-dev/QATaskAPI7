using QATaskAPI7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace QATaskAPI7.Controllers
{
    public class RolesController : ApiController
    {
        QATaskAPIEntities3 connection = new QATaskAPIEntities3();

        [HttpGet]
        [Route("api/roles/get")]
        public IHttpActionResult GetAllRoles()
        {
            return Ok(connection.Role.Select(r => new
            { r.RoleId, r.Name }));
        }

        [HttpGet]
        [Route("api/roles/{name}")]
        public IHttpActionResult GetRole(string name)
        {
            var role = connection.Role.FirstOrDefault(x => x.Name == name);

            if (role == null)
            {
                return BadRequest("Такой роли не существует!");
            }

            return Ok(new
            {
                role.RoleId,
                role.Name
            });
        }
    }
}