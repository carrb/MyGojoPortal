using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MyGojo.Web.Infrastructure.Bundles
{
    public class LessTransform : IBundleTransform
    {
        #region Implementation of IBundleTransform

        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }

        #endregion
    }
}