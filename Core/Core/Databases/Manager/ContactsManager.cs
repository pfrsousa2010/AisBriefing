using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Databases
{
    public class ContactsManager: BaseManager<Contact>
    {
        public override IQueryable<Contact> GetIncludes(IQueryable<Contact> entities)
        {
            return entities.Include(contact => contact.Group);
        }
    }
}
