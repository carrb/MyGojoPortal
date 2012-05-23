if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CB97429A1891034]') AND parent_object_id = OBJECT_ID('[UserPermission]'))
  alter table [UserPermission]  drop constraint FK8CB97429A1891034
  
  
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CB974294D0D1A71]') AND parent_object_id = OBJECT_ID('[UserPermission]'))
  alter table [UserPermission]  drop constraint FK8CB974294D0D1A71
  
  
    if exists (select * from dbo.sysobjects where id = object_id(N'[Post]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Post]
  
    if exists (select * from dbo.sysobjects where id = object_id(N'[User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [User]
  
    if exists (select * from dbo.sysobjects where id = object_id(N'[UserPermission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [UserPermission]
  
    if exists (select * from dbo.sysobjects where id = object_id(N'[Workspace]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Workspace]
  
    create table [Post] (
        Id INT IDENTITY NOT NULL unique,
       PostGuid UNIQUEIDENTIFIER null unique,
       Title NVARCHAR(255) not null,
       Body NVARCHAR(255) not null,
       CreatedAt DATETIME null,
       primary key (Id)
    )
  
    create table [User] (
        Id INT IDENTITY NOT NULL unique,
       UserGuid UNIQUEIDENTIFIER null unique,
       AdLogin NVARCHAR(255) not null,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (Id)
    )
  
    create table [UserPermission] (
        Id INT IDENTITY NOT NULL unique,
       UserPermissionGuid UNIQUEIDENTIFIER null unique,
       SharePointMemberId INT null,
       Mask NVARCHAR(255) null,
       MemberIsAdmin TINYINT null,
       MemberIsGlobal TINYINT null,
       MemberIsUser TINYINT null,
       WorkspaceId INT null,
       UserId INT null,
       primary key (Id)
    )
  
    create table [Workspace] (
        Id INT IDENTITY NOT NULL unique,
       WorkspaceGuid UNIQUEIDENTIFIER null unique,
       Title NVARCHAR(255) null,
       Url NVARCHAR(255) not null,
       Priority INT null,
       IsEditable TINYINT null,
       IsVisible TINYINT null,
       primary key (Id)
    )
  
    alter table [UserPermission] 
        add constraint FK8CB97429A1891034 
        foreign key (WorkspaceId) 
        references [Workspace]
  
    alter table [UserPermission] 
        add constraint FK8CB974294D0D1A71 
        foreign key (UserId) 
        references [User]