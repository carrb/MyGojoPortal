/* - Query to get all the top level site collections 
SELECT SiteId AS SiteGuid, Id AS WebGuid, FullUrl AS Url, Title, Author, TimeCreated
FROM dbo.Webs
WHERE (ParentWebId IS NULL) */

/* – Query to get all the child sites in a site collection 
SELECT SiteId AS SiteGuid, Id AS WebGuid, FullUrl AS Url, Title, Author, TimeCreated
FROM dbo.Webs
WHERE (NOT (ParentWebId IS NULL))
ORDER BY SiteGuid */

/* – Query to get all the SharePoint groups in a site collection 
SELECT dbo.Webs.SiteId, dbo.Webs.Id, dbo.Webs.FullUrl, dbo.Webs.Title, dbo.Groups.ID AS Expr1, 
dbo.Groups.Title AS Expr2, dbo.Groups.Description
FROM dbo.Groups INNER JOIN
dbo.Webs ON dbo.Groups.SiteId = dbo.Webs.SiteId */

/* – Query to get all the users in a site collection 
SELECT dbo.Webs.SiteId, dbo.Webs.Id, dbo.Webs.FullUrl, dbo.Webs.Title, dbo.UserInfo.tp_ID, 
dbo.UserInfo.tp_DomainGroup, dbo.UserInfo.tp_SiteAdmin, dbo.UserInfo.tp_Title, dbo.UserInfo.tp_Email
FROM dbo.UserInfo INNER JOIN
dbo.Webs ON dbo.UserInfo.tp_SiteID = dbo.Webs.SiteId */

/* – Query to get all the members of the SharePoint Groups 
SELECT dbo.Groups.ID, dbo.Groups.Title, dbo.UserInfo.tp_Title, dbo.UserInfo.tp_Login
FROM dbo.GroupMembership INNER JOIN
dbo.Groups ON dbo.GroupMembership.SiteId = dbo.Groups.SiteId INNER JOIN
dbo.UserInfo ON dbo.GroupMembership.MemberId = dbo.UserInfo.tp_ID */

/* – Query to get all the sites where a specific feature is activated
SELECT dbo.Webs.Id AS WebGuid, dbo.Webs.Title AS WebTitle, dbo.Webs.FullUrl AS WebUrl, dbo.Features.FeatureId, 
dbo.Features.TimeActivated
FROM dbo.Features INNER JOIN
dbo.Webs ON dbo.Features.SiteId = dbo.Webs.SiteId AND dbo.Features.WebId = dbo.Webs.Id
WHERE (dbo.Features.FeatureId = '00BFEA71-D1CE-42de-9C63-A44004CE0104') */

/* – Query to get all the users assigned to roles 
SELECT dbo.Webs.Id, dbo.Webs.Title, dbo.Webs.FullUrl, dbo.Roles.RoleId, dbo.Roles.Title AS RoleTitle, 
dbo.UserInfo.tp_Title, dbo.UserInfo.tp_Login
FROM dbo.RoleAssignment INNER JOIN
dbo.Roles ON dbo.RoleAssignment.SiteId = dbo.Roles.SiteId AND 
dbo.RoleAssignment.RoleId = dbo.Roles.RoleId INNER JOIN
dbo.Webs ON dbo.Roles.SiteId = dbo.Webs.SiteId AND dbo.Roles.WebId = dbo.Webs.Id INNER JOIN
dbo.UserInfo ON dbo.RoleAssignment.PrincipalId = dbo.UserInfo.tp_ID   */

/* – Query to get all the SharePoint groups assigned to roles  
SELECT dbo.Webs.Id, dbo.Webs.Title, dbo.Webs.FullUrl, dbo.Roles.RoleId, dbo.Roles.Title AS RoleTitle, 
dbo.Groups.Title AS GroupName
FROM dbo.RoleAssignment INNER JOIN
dbo.Roles ON dbo.RoleAssignment.SiteId = dbo.Roles.SiteId AND 
dbo.RoleAssignment.RoleId = dbo.Roles.RoleId INNER JOIN
dbo.Webs ON dbo.Roles.SiteId = dbo.Webs.SiteId AND dbo.Roles.WebId = dbo.Webs.Id INNER JOIN
dbo.Groups ON dbo.RoleAssignment.SiteId = dbo.Groups.SiteId AND 
dbo.RoleAssignment.PrincipalId = dbo.Groups.ID   */
