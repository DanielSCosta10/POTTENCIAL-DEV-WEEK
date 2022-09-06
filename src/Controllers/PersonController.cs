using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{

    private DatabaseContext _context{ get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }
    [HttpGet]
    public ActionResult<List<Person>> Get(){
        var result = _context.Persons.Include(p => p.contracts).ToList();
        if(!result.Any()){
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Post([FromBody]Person person){
        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return BadRequest(new {
                message = "Person not created",
                status = HttpStatusCode.BadRequest
            });
        }
        return Created("Created", person);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute]int id, [FromBody]Person person){
        
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null) {
            return NotFound(new {
                message = "Person not found!",
                status = HttpStatusCode.NotFound
            }); 
        }

        try 
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        } 
        catch (System.Exception)
        {
            return BadRequest(new {
                message = $"Person with id {id} not updated",
                status = HttpStatusCode.BadRequest
            }); 
        }

        return Ok(new {
            message = $"Person with id {id} updated",
            status = HttpStatusCode.OK
        }); 
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id){
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);
        if(result is null){
            return BadRequest(new {
                message = "invalid request, content not found",
                status = HttpStatusCode.BadRequest
            });
        }
        _context.Persons.Remove(result);
        _context.SaveChanges();

        return Ok(new {
            message = $"Person deleted with id {id}",
            status = HttpStatusCode.OK
        });
    }
} 