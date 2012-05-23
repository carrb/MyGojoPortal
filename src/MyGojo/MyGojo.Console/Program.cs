using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace MyGojo.Console
{
    class Program
    {
        // Extendable Command Line Handler (ExtConsole NuGet Package) installed
        // See: http://extconsole.codeplex.com/
        static void Main(string[] args)
        {
            var siteUrl = "http://akr-spstage1";

            
            
            using (ClientContext context = new ClientContext(siteUrl))
            {
                // Get SharePoint site url
                context.Load(context.Site);
                context.ExecuteQuery();

                System.Console.WriteLine(context.Site.Url);
                System.Console.WriteLine();
                
                // Get SharePoint site lists titles
                context.Load(context.Web, web => web.Lists.Include(list => list.Title).Where(field => field.Hidden == false));
                context.ExecuteQuery();

                foreach (var list in context.Web.Lists)
                {
                    System.Console.WriteLine(list.Title);
                }
                System.Console.WriteLine();


                // Get users for a SharePoint site
                RoleAssignmentCollection roles = context.Web.RoleAssignments;
                context.Load(roles);
                context.ExecuteQuery();

                foreach (var role in roles)
                {
                    context.Load(role.Member);
                    context.ExecuteQuery();
                    System.Console.WriteLine(role.Member.LoginName);
                }
                System.Console.WriteLine();

                /*
                You can check for a specific user permission as given below
 
                    BasePermissions bp = new BasePermissions();
                    bp.Set(PermissionKind.AddListItems);
                    ClientResult<bool> manageWeb = context.Web.DoesUserHavePermissions(bp); context.ExecuteQuery();
 
                The above code snippet checks whether the user has AddListItems or not
                */


            }

            System.Console.ReadLine();

        }
    }
}
