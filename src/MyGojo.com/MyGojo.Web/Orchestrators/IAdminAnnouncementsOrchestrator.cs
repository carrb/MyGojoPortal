using System.Collections.Generic;
using MyGojo.Data.Model;

namespace MyGojo.Web.Orchestrators
{
    public interface IAdminAnnouncementsOrchestrator
    {
        IEnumerable<Announcement> GetAll();
        Announcement GetDetailsById(string id);
        void Insert(Announcement announcement);
    }
}