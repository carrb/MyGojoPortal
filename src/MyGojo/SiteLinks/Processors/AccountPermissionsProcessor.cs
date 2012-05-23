using System;
using Microsoft.SharePoint.Client;
using NLog;

namespace SiteLinks.Processors
{
    public class AccountPermissionsProcessor : IAccountPermissionsProcessor
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        ///  Constructor
        public AccountPermissionsProcessor(string siteUrl)
        {
            GetSitePermissions(siteUrl);
        }


        public void GetSitePermissions(string url)
        {
            try
            {
                using (ClientContext context = new ClientContext(url))
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

                        Console.WriteLine(role.Member.LoginName);


                        if (!App.CollectedUsers.ContainsKey(role.Member.LoginName))
                        {
                            App.CollectedUsers.Add(role.Member.LoginName, url);    
                        }



                        //foreach (RoleDefinition def in role.RoleDefinitionBindings)
                        //{
                        //    // enumerate the enum and check each perm type to see if the perm is included
                        //    string[] keys = Enum.GetNames(typeof (PermissionKind));
                        //    BasePermissions bp = def.BasePermissions;
                        //
                        //    foreach (string key in keys)
                        //    {
                        //        if (bp.Has((PermissionKind) Enum.Parse(typeof (PermissionKind), key)))
                        //        {
                        //            Console.WriteLine(key);
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error creating ClientContext and getting site RoleAssignments: {0}", ex.Message);
            }
        }

    }
}
