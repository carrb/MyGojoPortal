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
                var storedUsers = userRepository.All();

                foreach (var currentUser in App.CollectedUsers.Select(userEntry => userEntry.Value))
                {
                    var existingUserInfo = userRepository.GetSingle(u => u.AdLogin == currentUser.AdLogin);

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


        /*
                    var debugAllUsers = processor.AllUsers;


            using (var context = new MyGojoWebContext())
            {
                var repository = new UserRepository(context);
                var storedUsers = repository.All.ToList();

                foreach (var currentUser in debugAllUsers.Select(userEntry => userEntry.Value))
                {
                    var result = storedUsers.SingleOrDefault(u => u.AdLogin == currentUser.AdLogin);
             
                    if (result == null || result.Workspaces == null)
                    {
                        repository.InsertOrUpdate(currentUser);
                        continue;
                    }
                    
                    if (result.Workspaces.Equals(currentUser.Workspaces)) continue;
                    repository.InsertOrUpdate(currentUser);
                }
                repository.Save();
            }
            Console.WriteLine("\nDone.");
        }
         */
    }
}
