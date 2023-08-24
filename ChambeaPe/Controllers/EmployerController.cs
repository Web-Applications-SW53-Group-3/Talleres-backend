using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChambeaPe.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChambeaPe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        // GET: api/Employer
        [HttpGet]
        public IEnumerable<Employer> Get()
        {
            IEnumerable<Employer> employers = new List<Employer>
            {
                new Employer { id = 1, name = "Steve", lastname = "Roger", dni = "123456789" },
                new Employer { id = 2, name = "Jennifer", lastname = "Espinoza", dni = "987654321" }
            };
            return employers;
        }   

        // GET: api/Employer/5
        [HttpGet("{id}", Name = "Get")]
        public Employer Get(int id)
        {
            Employer employer = new Employer();
            employer.id = id;
            employer.name = "Employer ";
            employer.lastname = id.ToString();
            employer.dni = "87654321";
            return employer;
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Employer employer)
        {
            try
            {
                if (string.IsNullOrEmpty(employer.name))
                {
                    return BadRequest("Employer name is required."); // 400 Bad Request
                }

                if (employer.name == "employer")
                {
                    throw new Exception("Unexpected error");
                }


                return StatusCode(201); // 201 Created
            }
            catch (Exception ex)
            {

                var errorResponse = new
                {
                    message = "An error occurred while processing the request.",
                    details = ex.Message
                };

                return StatusCode(500, errorResponse); // 500 Internal Server Error
            }
        }


        // PUT: api/Employer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Employer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
