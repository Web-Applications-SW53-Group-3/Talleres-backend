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
        private static List<Employer> employers = new List<Employer>
        {
            new Employer { Id = 1, Name = "Steve", Lastname = "Roger", Dni = "123456789" },
            new Employer { Id = 2, Name = "Jennifer", Lastname = "Espinoza", Dni = "987654321" },
            new Employer { Id = 3 , Name = "Jhon", Lastname = "Doe", Dni = "123456789" },
            new Employer { Id = 4, Name = "Richard", Lastname = "Smith", Dni = "987655321" },
        };
        
        // GET: api/Employer
        [HttpGet]
        public List<Employer> Get()
        {
            return employers;
        }   

        // GET: api/Employer/5
        [HttpGet("{id}", Name = "Get")]
        public Employer Get(int id)
        {
            Employer employer = new Employer();
            employer.Id = id;
            employer.Name = "Employer ";
            employer.Lastname = id.ToString();
            employer.Dni = "87654321";
            return employer;
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Employer employer)
        {
            try
            {
                if (string.IsNullOrEmpty(employer.Name))
                {
                    return BadRequest("Employer name is required."); // 400 Bad Request
                }

                if (employer.Name == "employer")
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
        public IActionResult Put(int id, [FromBody] Employer employer)
        {
            try
            {
                Employer employerToUpdate = employers.First(e => e.Id == id);

                employerToUpdate.Id = employer.Id;
                employerToUpdate.Dni = employer.Dni;
                employerToUpdate.Name = employer.Name;
                employerToUpdate.Lastname = employer.Lastname;
            }
            catch (InvalidOperationException)
            {
                //Si el id recibido no existe
                return UnprocessableEntity("Invalid employer Id");
            }

            return Ok();
        }
        
        // PATCH: api/Employer/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] string value)
        {
            try
            {
                Employer employerToUpdate = employers.FirstOrDefault(e => e.Id == id);
                if (value == null || value=="")
                {
                    return StatusCode(400);
                }
                else
                {
                    employerToUpdate.Name = value;
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                // Devolver una respuesta de error con detalles
                var errorResponse = new
                {
                    message = "An error occurred while processing the request.",
                    details = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
        
        // DELETE: api/Employer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
