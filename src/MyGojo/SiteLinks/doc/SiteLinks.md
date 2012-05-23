# SiteLinks.exe


### Overview

SiteLinks.exe is a command line tool for gathering all SharePoint 2010 site collections, sites, and subsites in a particular SharePoint 2010 farm, that are in a defined scope.

For each site, the users and their permissions are gathered, then for each user, sites they have permission to access are stored in a hash (user --> sites), for lookup.

These site, users, and mappings between (many-to-many) are then persisted.

