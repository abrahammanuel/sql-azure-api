using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using azureplatzi.Models;


namespace azureplatzi.Controllers
{
    [Route("api/[controller]")]
    //[azureplatzi]
    public class ContactController:  Controller
    {
        private ContactsContext contactsContext;


        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get()
        {
            return contactsContext.ContactSet.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(int id)
        {
            var selectedContact = (from c in contactsContext.ContactSet 
                                    where c.Identificador == id
                                    select c).FirstOrDefault();
            return selectedContact;


        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value)
        {
            Contacts newContact = value;
            contactsContext.ContactSet.Add(newContact);
            contactsContext.SaveChanges();
            return Ok("tu contacto ha sido agregado");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacts value)
        {
            Contacts updatedContact = value;
            var selectedElement = contactsContext.ContactSet.Find(id);
            selectedElement.Nombre = value.Nombre;
            selectedElement.Email = value.Email;
            contactsContext.SaveChanges();
            return Ok("contaco ha sido actualizado");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contacts selectedElement = contactsContext.ContactSet.Find(id);
            contactsContext.ContactSet.Remove(selectedElement);
            contactsContext.SaveChanges();
            return Ok($"contacto identificador:{id}  ha sido removido");
        }
        ~ContactController()
        {
            contactsContext.Dispose();
        }
        
    }
}