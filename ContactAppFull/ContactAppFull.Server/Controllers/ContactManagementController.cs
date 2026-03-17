using Microsoft.AspNetCore.Mvc;
using ContactAppFull.Server.ModelDto;
using ContactAppFull.Server.Model;
using ContactAppFull.Server.Storage;
namespace ContactAppFull.Server.Controllers;
public class ContactManagementController : BaseController
{
    private readonly IPaginationStorage storage;

    public ContactManagementController(IPaginationStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        Contact res = storage.Add(contact);
        if (res!=null) return Created();
        return Conflict("Контакт с таким уже ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContacts());
    }

    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> GetContact(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id");

        Contact contact = storage.GetContactById(id);
        if (contact == null)
            return NotFound("Контакт не найден");
        else
        {
            return Ok(contact);
        }
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        bool res = storage.UpdateContact(contactDto, id);
        if (res) return Ok();
        return Conflict("Контакт с таким ID не существует");
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool res = storage.Remove(id);
        if (res) return Ok();
        return BadRequest("Ошибка id");
    }
}
