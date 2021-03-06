﻿using System;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using MyGojo.Data.Mongo.Model;
using NLog;

namespace SiteLinks.Processors
{
    public class AccountPermissionsProcessor//  : IAccountPermissionsProcessor
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



                        // Can Use to Get Permission to site type if needed!
                        //
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
