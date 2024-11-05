using Microsoft.AspNetCore.Mvc;
using BidOneSimpleFormApi_Kevin.DataAccess.Models;
using BidOneSimpleFormApi_Kevin.Services;

namespace BidOneSimpleFormApi_Kevin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person == null || string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                return BadRequest("Invalid person data.");
            }

            var createdPerson = await _personService.AddPersonAsync(person);
            return CreatedAtAction(nameof(Post), createdPerson);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.GetAllPersons();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}
