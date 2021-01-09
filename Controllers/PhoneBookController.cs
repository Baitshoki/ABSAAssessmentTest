using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBAPI_MVC_PB.Models;
using System.Net.Http;

namespace WEBAPI_MVC_PB.Controllers
{
    public class PhoneBookController : Controller
    {
        DB_PHONEBOOKEntities db = new DB_PHONEBOOKEntities();
        // GET: PhoneBook
        public ActionResult Index()
        {
            IEnumerable<PhoneBook> pbobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/PhoneBookCrud");

            var consumeapi = hc.GetAsync("PhoneBookCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<PhoneBook>>();
                displaydata.Wait();

                pbobj = displaydata.Result;
            }
            return View(pbobj);
            // return View(db.PhoneBooks.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhoneBook insertentry)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/PhoneBookCrud");

            var insertrecord = hc.PostAsJsonAsync<PhoneBook>("PhoneBookCrud", insertentry);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            PhoneBookClass pbobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/");

            var consumeapi = hc.GetAsync("PhoneBookCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<PhoneBookClass>();
                displaydata.Wait();
                pbobj = displaydata.Result;
            }
            return View(pbobj);
        }

        public ActionResult Edit(int id)
        {
            PhoneBookClass pbobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/");

            var consumeapi = hc.GetAsync("PhoneBookCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<PhoneBookClass>();
                displaydata.Wait();
                pbobj = displaydata.Result;
            }
            return View(pbobj);
        }

        [HttpPost]
        public ActionResult Edit(PhoneBookClass pbc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/PhoneBookCrud");

            var insertrecord = hc.PutAsJsonAsync<PhoneBookClass>("PhoneBookCrud", pbc);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Entry Not Updated...!";
            }

            return View(pbc);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:62805/api/PhoneBookCrud");

            var delrecord = hc.DeleteAsync("PhoneBookCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}