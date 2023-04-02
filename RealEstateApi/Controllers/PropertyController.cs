using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_EstateApi.Models;
using Real_EstateApi.Repository.InMemory;

namespace Real_EstateApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        PropertyInMemoryRepository _repo = new PropertyInMemoryRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            // status - http responce
            // ok 200 status code - json 
            return Ok(_repo.GetAllpropertys()); // json or xml
        }

        [HttpGet("propertyId")]
        public IActionResult GetById([FromRoute] int propertyId) // model binding 
        {
            var property = _repo.GetpropertyById(propertyId);
            if (property == null)
                return BadRequest("No resource found");
            return Ok(property); // json or xml
        }

        [HttpDelete("propertyId")]
        public IActionResult Delete([FromRoute] int propertyId) // model binding 
        {
            var property = _repo.GetpropertyById(propertyId);
            if (property == null)
                return BadRequest("No resource found");
            return Ok(_repo.Deleteproperty(propertyId)); // json or xml
        }

        [HttpPost]
        public IActionResult Addproperty([FromBody] Property property) // model binding // validation
        {
            if (property == null)
                return BadRequest("No resource found");
            if (ModelState.IsValid)
            {
                return Ok(_repo.Addproperty(property)); // json or xml
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{propertyId}")]
        public IActionResult Updateproperty([FromBody] Property property, [FromRoute] int propertyId) // model binding // validation
        {
            if (property == null)
                return BadRequest("No resource found");
            if (ModelState.IsValid)
            {
                return Ok(_repo.Updateproperty(propertyId, property)); // json or xml
            }
            return BadRequest(ModelState);
        }
    }
}
