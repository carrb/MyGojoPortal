using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace SiteLinks.Tests.Fakes
{
    public class FakeClientContext : ClientRuntimeContext
    {
        public FakeClientContext()
            : this("http://akr-spstage1") {}

        public FakeClientContext(string webFullUrl) : base(webFullUrl)
        {

        }
    }
}
