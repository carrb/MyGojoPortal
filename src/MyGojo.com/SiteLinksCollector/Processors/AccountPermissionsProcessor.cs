using System;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using MyGojo.Data.Model;
using NLog;

namespace SiteLinksCollector.Processors
{
    public class AccountPermissionsProcessor
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly string thisUrl;
        private readonly List<UserInfo> thisUserList; 


        ///  Constructor
        public AccountPermissionsProcessor(string siteUrl, List<UserInfo> siteUsers)
        {
            thisUrl = siteUrl;
            thisUserList = siteUsers;
        }


        public List<UserInfo> GetSitePermissions()
        {
            try
            {
                using (ClientContext context = new ClientContext(thisUrl))
                {
                    RoleAssignmentCollection roles = context.Web.RoleAssignments;
                    context.Load(roles);
                    context.ExecuteQuery();

                    foreach (RoleAssignment role in roles)
                    {
                        context.Load(role.Member);
                        context.Load(role.RoleDefinitionBindings);
                        context.Load(roles);
                        context.ExecuteQuery();

                        var currentUser = new UserInfo(role.Member.LoginName);

                        if (thisUserList.Contains(currentUser)) continue;
                        thisUserList.Add(currentUser);
                       

                        if (App.CollectedUsers.ContainsKey(role.Member.LoginName)) continue;
                        App.CollectedUsers.Add(role.Member.LoginName, new UserInfo{AdLogin = role.Member.LoginName, Sites = new List<SiteInfo>()});
                        Console.WriteLine("Added: " + role.Member.LoginName);
                    }

                    return thisUserList;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error creating ClientContext and getting site RoleAssignments: {0}", ex.Message);
                return thisUserList;
            }
        }

    }
}
