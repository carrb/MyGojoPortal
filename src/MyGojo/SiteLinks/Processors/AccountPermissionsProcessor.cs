using System;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using NLog;

namespace SiteLinks.Processors
{
    public class AccountPermissionsProcessor : IAccountPermissionsProcessor
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        ///  Constructor
        public AccountPermissionsProcessor(string siteUrl, List<string> siteUsers)
        {
            GetSitePermissions(siteUrl, siteUsers);
        }


        public void GetSitePermissions(string url, List<string> userList)
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

                        


                        if (!userList.Contains(role.Member.LoginName))
                        {
                            userList.Add(role.Member.LoginName);
                            Console.WriteLine("Added: " + role.Member.LoginName);
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
