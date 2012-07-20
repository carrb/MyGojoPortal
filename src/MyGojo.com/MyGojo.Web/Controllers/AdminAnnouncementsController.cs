using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamSongs.MongoRepository;
using MongoDB.Bson;
using MyGojo.Data.Model;
using MyGojo.Web.Orchestrators;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class AdminAnnouncementsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAdminAnnouncementsOrchestrator _orchestrator;


        public AdminAnnouncementsController(IAdminAnnouncementsOrchestrator orchestrator, ILogger logger)
        {
            _logger = logger;
            _orchestrator = orchestrator;
        }



        //
        // GET: /AdminAnnouncements/

        public ActionResult Index()
        {
            var model = _orchestrator.GetAll();
            return View(model);
        }


        //
        // GET: /AdminAnnouncements/Details/5

        public ActionResult Details(ObjectId id)
        {
            var model = _orchestrator.GetDetailsById(id.ToString());
            return View(model);
        }


        //
        // GET: /AdminAnnouncements/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminAnnouncements/Create

        [HttpPost]
        public ActionResult Create(Announcement announcement)
        {
            if (!ModelState.IsValid) return View();

            _orchestrator.Insert(announcement);

            return RedirectToAction("Index");



        }

    }
}
