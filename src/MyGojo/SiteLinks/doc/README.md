# SiteLinks.exe

SiteLinks.exe is a .NET 4.5 console application that sequentially iterates over a list of SharePoint 2010 site collections in a specific SharePoint web application. When "processing" each web site and web subsite it recursively finds in a web application, it stores both the web details, referenced by url, and the AD user logins that have access to the Web.  It then persists this information (all Webs in all specified site collections along with all the associated AD user logins that have access, keyed by login.

### Architecture/Process Flow

Read/Import configuration settings that specify SharePoint web application and site collections to process.

Use a SiteCollectionProcessor to process each site collection.

Use a SiteProcessor to recursively process each site and subsite in site collection.

