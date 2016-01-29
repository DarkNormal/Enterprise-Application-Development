using PhoneBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBookAPI.Controllers
{
    public class PhoneBookController : ApiController
    {
        private List<PhoneEntry> phonebook;

        public PhoneBookController()
        {
            phonebook = new List<PhoneEntry>();
            phonebook.Add(new PhoneEntry("Mark", "0834732883", "Beechwood Lawns"));
            phonebook.Add(new PhoneEntry("Rob", "0475839388", "Whiteboork Lawns"));
            phonebook.Add(new PhoneEntry("Tom", "974950943580", "Crumlin Lawns"));
            phonebook.Add(new PhoneEntry("Del", "9843804580", "Newbridge Lawns"));
        }
        [Route("NameLookup")]
        public IHttpActionResult GetEntryViaName(string name)
        {
            var entry = phonebook.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                                 .Select(x => new {x.Address, x.PhoneNum }).ToList();
            if(entry.Count > 0)
            {
                return Json(entry);
            }
            else
            {
                return BadRequest("Phone Book entry not found with Name " + name);
            }
        }
        [Route("PhoneLookup")]
        public IHttpActionResult GetEntryViaPhone(string number)
        {
            var entry = phonebook.Where(x => x.PhoneNum.Equals(number, StringComparison.OrdinalIgnoreCase))
                                 .Select(x => new { x.Name , x.Address}).ToList();
            if (entry.Count > 0)
            {
                return Json(entry);
            }
            else
            {
                return BadRequest("Phone Book entry not found with Phone number " + number);
            }
        }
    }
}
