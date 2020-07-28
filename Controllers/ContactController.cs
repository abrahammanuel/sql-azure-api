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
        public IEnumerable<Contacts> Get()
        {
            return contactsContext.ContactSet.ToList();
        }
        ~ContactController()
        {
            contactsContext.Dispose();
        }
        
    }
}