using System;
using System.Collections.Generic;
using System.Linq;
using DreamSongs.MongoRepository;
using MyGojo.Data.Model;
using NLog;

namespace SiteLinksCollector.Persisters
{
    public class UserInfoPersister
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
      

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
                var storedUsers = userRepository.All();

                foreach (var currentUser in App.CollectedUsers.Select(userEntry => userEntry.Value))
                {
                    UserInfo user = currentUser; // to avoid closure issues
                    var existingUserInfo = userRepository.GetSingle(u => u.AdLogin == user.AdLogin);

                    if (existingUserInfo == null)
                    {
                        userRepository.Add(currentUser);
                        continue;
                    }

                    userRepository.Delete(existingUserInfo);
                    userRepository.Add(currentUser);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error persisting users: {0}", ex.Message);
            }
        }
    }
}
