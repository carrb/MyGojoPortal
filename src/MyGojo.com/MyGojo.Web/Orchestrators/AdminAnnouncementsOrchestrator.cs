using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using Utility.Logging;

namespace MyGojo.Web.Orchestrators
{
    public class AdminAnnouncementsOrchestrator : IAdminAnnouncementsOrchestrator
    {
        private readonly ILogger _logger;
        private readonly MongoRepository<Announcement> _repository;


        public AdminAnnouncementsOrchestrator(MongoRepository<Announcement> repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository;
        }


        public IEnumerable<Announcement> GetAll()
        {
            try
            {
                var foundAnnouncements = _repository.All().ToList();

                if (foundAnnouncements.Count == 0)
                {
                    return null;
                }

                return foundAnnouncements;
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                _logger.Info(ex.GetType().ToString());
                return new[] { new Announcement { Title = "No Announcements" } };
            }    
        }
        
        public Announcement GetDetailsById(string id)
        {
            try
            {
                var foundAnnouncement = _repository.GetById(id);
                return foundAnnouncement;
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                _logger.Info(ex.GetType().ToString());
                return null;
            } 
        }

        public void Insert(Announcement announcement)
        {
            try
            {
                _logger.Info("Orchestrating an Insert!");
                _repository.Add(announcement);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                _logger.Info(ex.GetType().ToString());
            } 
            
        }
 

    }
}