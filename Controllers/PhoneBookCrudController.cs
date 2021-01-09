using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using WEBAPI_MVC_PB.Models;

namespace WEBAPI_MVC_PB.Controllers
{
    public class PhoneBookCrudController : ApiController
    {
        DB_PHONEBOOKEntities db = new DB_PHONEBOOKEntities();
        public IHttpActionResult getEntries()
        {           
            var results = db.PhoneBooks.ToList();
            return Ok(results);
        }

        [HttpPost]
        public IHttpActionResult entryinsert(PhoneBook entryinsert)
        {
            db.PhoneBooks.Add(entryinsert);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult getEntryId(int id)
        {
            PhoneBookClass entrydetail = null;
            entrydetail = db.PhoneBooks.Where(x => x.Id == id).Select(x => new PhoneBookClass()
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
            }).FirstOrDefault<PhoneBookClass>();

            if(entrydetail == null)
            {
                return NotFound();
            }
            return Ok(entrydetail);
        }

        public IHttpActionResult Put(PhoneBookClass pbc)
        {
            var updateentry = db.PhoneBooks.Where(x => x.Id == pbc.Id).FirstOrDefault<PhoneBook>();
            if(updateentry!= null)
            {
                updateentry.Id = pbc.Id;
                updateentry.Name = pbc.Name;
                updateentry.PhoneNumber = pbc.PhoneNumber;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var entrydel = db.PhoneBooks.Where(x => x.Id == id).FirstOrDefault();
            db.Entry(entrydel).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
     }
}
