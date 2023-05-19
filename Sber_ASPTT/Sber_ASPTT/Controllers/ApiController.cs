using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sber_ASPTT.Models;

namespace Sber_ASPTT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [CustomAuthorize(Roles = "Admin")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ApiController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllContacts")]
        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts;
        }

        [HttpGet]
        [Route("GetContactById")]
        public async Task<Contact> GetContactById(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return null;
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet]
        [Route("DeleteContactById")]
        public async Task<bool> DeleteContactById(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return false;
            var contact = new Contact() { Id = id};
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        [Route("ChangeContact")]
        public async Task<bool> ChangeContact([FromBody] Contact contact)
        {
            var dbContact = await _context.Contacts.FirstOrDefaultAsync(t => t.Id == contact.Id);
            if(dbContact == null)
                return false;
            dbContact.BirthDay = contact.BirthDay;
            dbContact.Name = contact.Name;
            dbContact.Email = contact.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        [Route("AddNewContact")]
        public async Task<Contact> AddNewContact([FromBody] Contact contact)
        {
            var dbContact = await _context.Contacts.AddAsync(contact); 
            await _context.SaveChangesAsync();
            return dbContact.Entity;
        }
    }
}
