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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // POST: api/Employer
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
