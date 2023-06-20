using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Interfaces;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private IFetchJson fetchJson;

        public HomeController(IFetchJson fetchJson)
        {
            this.fetchJson = fetchJson;
        }


        // GET: HomeController
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
            
        }

        // GET: HomeController/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            return Ok("API reached");
        }

        // GET: HomeController/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GetApiData
        [HttpGet]
        [Route("FetchTasksList/{id}")]
        public ActionResult<ChangeSets> FetchTasksList(int id)
        {
            var responsetask = Task.Run(() => { return this.fetchJson.FetchTasksListAsync(id); });
            ChangeSets response = responsetask.Result;

            return Ok(response);
        }
    }
}
