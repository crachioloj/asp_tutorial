namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class SeedUsers : DbMigration
  {
    public override void Up()
    {
      Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'962a5b74-9c0d-41ec-a531-bf6d242ba953', N'guest@vidly.com', 0, N'APkTJ4N+dA5OA7nKbB5azAx8r5EGEPYssOb6MFjwRav7AqSvAJTBKpp+R8vgN4dLtA==', N'3dd30a53-f3d8-4003-8f46-0847919690eb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf97c917-b050-42aa-97e1-1362162db055', N'admin@vidly.com', 0, N'AHQ9TX6hDlKPCKAY9UjjRFrn0EgvGCrHD/pcW3Ul9hiLWf0RLVwHOrni9s/vmUDGkw==', N'59182346-7442-495f-b0db-bb37855f72dc', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'95408ce0-6686-4007-8fc1-4b7984073925', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cf97c917-b050-42aa-97e1-1362162db055', N'95408ce0-6686-4007-8fc1-4b7984073925')"
      );
    }

    public override void Down()
    {
    }
  }
}
