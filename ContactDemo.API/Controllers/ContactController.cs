using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDemo.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        private readonly string errorMessage = "Specified contact not found";

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var result = await contactRepository.GetContacts();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result = await contactRepository.GetContact(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(errorMessage);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var objToDelete = await contactRepository.GetContact(id);

            if (objToDelete == null)
            {
                return NotFound(errorMessage);
            }
            else
            {
                await contactRepository.DeleteContact(id);

                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            await contactRepository.AddContact(contact);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            var objToDelete = await contactRepository.GetContact(contact.Id);

            if (objToDelete == null)
            {
                return NotFound(errorMessage);
            }

            await contactRepository.UpdateContact(contact);

            return Ok();
        }
    }
}
