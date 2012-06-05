using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;

namespace MyGojo.Security.Claims
{
    //      http://www.microsoft.com/en-us/server-cloud/identity-access-management/trial.aspx
    // See: http://blogs.msdn.com/b/eugeniop/archive/2010/04/03/wif-and-mvc-how-it-works.aspx
    //      http://msdn.microsoft.com/en-us/library/hh446524
    //      http://blogs.msdn.com/b/rickandy/archive/2012/03/23/securing-your-asp-net-mvc-4-app-and-the-new-allowanonymous-attribute.aspx
    //      http://msdn.microsoft.com/en-us/magazine/ee335707.aspx
    //      http://blogs.msdn.com/b/alikl/archive/2010/09/18/windows-identity-foundation-wif-by-example-part-iii-how-to-implement-claims-based-authorization-for-asp-net-application.aspx


    class SimpleClaimsAuthoirzationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            bool result = false;

            string requestedResource = context.Resource.First<Claim>().Value;
            string requestedAction = context.Action.First<Claim>().Value;
            string userName = context.Principal.Identity.Name;

            //evaluate the user against requested resource and acton
            //and make a decision.
            //return false to deny access or true to grant it.
            result = EvaluateAccessRequest(requestedResource, requestedAction, userName);

            return result;
        }


        private static bool EvaluateAccessRequest(string requestedResource, string requestedAction, string userName)
        {
            return true;
        }


    }
}
