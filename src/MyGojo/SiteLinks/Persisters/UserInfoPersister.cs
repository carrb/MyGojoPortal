using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamSongs.MongoRepository;
using MyGojo.Data.Mongo.Model;
using NLog;

namespace SiteLinks.Persisters
{
    public class UserInfoPersister
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        

        // Constructor
        public UserInfoPersister(IDictionary<string, UserInfo> collectedUsers)
        {
            PersistUserInfo(collectedUsers);
        }



        public void PersistUserInfo(IDictionary<string, UserInfo> users)
        {
            try
            {
                MongoRepository<UserInfo> userRepository = new MongoRepository<UserInfo>();  

                foreach (var user in App.CollectedUsers)
                {
                    userRepository.Add(user.Value);
                }
      

            }
            catch (Exception ex)
            {
                logger.Error("Error persisting users: {0}", ex.Message);
            }
        }
    }
}
