using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Controllers
{
    public class AdminAnnouncementsController : Controller
    {
        private readonly ILogger _logger;
        private readonly MongoRepository<Announcement> _repository;


        public AdminAnnouncementsController(MongoRepository<Announcement> repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository;
            _logger.Info("AdminAnnouncementsController created...this logger was injected!");
        }



        //
        // GET: /AdminAnnouncements/

        public ActionResult Index()
        {
            _logger.Info("Entering Index ActionMethod...");
            ViewBag.Message = "Retrieving Announcements...";

            try
            {
                var foundAnnouncements = _repository.All().ToList();

                if (foundAnnouncements.Count == 0)
                {
                    ViewBag.Message = "No Announcements Found";
                }

                return View(foundAnnouncements);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "No Announcements currently exist in Announcement table of DB";
                _logger.Info(ViewBag.Message, ex);

                return View();
            }
        }


        //
        // GET: /AdminAnnouncements/Create

        public ActionResult Create()
        {
            return View();
        }

    }
}
