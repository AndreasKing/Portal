namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnnounceTitle = c.String(nullable: false, maxLength: 100),
                        AnnounceText = c.String(),
                        AnnounceEndDate = c.DateTime(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FileStorage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileDescription = c.String(nullable: false, maxLength: 100),
                        FileUploadDate = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                        HomeImage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsPerm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(nullable: false, maxLength: 100),
                        EventDescription = c.String(),
                        EventLocation = c.String(nullable: false, maxLength: 510),
                        EventDate = c.DateTime(nullable: false),
                        EventTime = c.String(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        UploadedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeetingUserRSVP",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComingYorN = c.Boolean(),
                        RSVPNotes = c.String(maxLength: 250),
                        AdminRequirements = c.String(maxLength: 250),
                        UserRequirements = c.String(maxLength: 250),
                        AppUser_Id = c.String(maxLength: 128),
                        MeetingRSVP_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .ForeignKey("dbo.Meeting", t => t.MeetingRSVP_ID)
                .Index(t => t.AppUser_Id)
                .Index(t => t.MeetingRSVP_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserFName = c.String(),
                        UserMName = c.String(),
                        UserLName = c.String(),
                        UserDOB = c.DateTime(),
                        StartDate = c.DateTime(),
                        LastLogin = c.DateTime(),
                        UserAddress = c.String(),
                        PasswordChanged = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FileSubCat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileSubCatName = c.String(nullable: false),
                        FileCatFK = c.Int(nullable: false),
                        FlCat_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FileCat", t => t.FlCat_ID)
                .Index(t => t.FlCat_ID);
            
            CreateTable(
                "dbo.FileCat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileCatName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.FileStorageAnnouncement",
                c => new
                    {
                        FileStorage_ID = c.Int(nullable: false),
                        Announcement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileStorage_ID, t.Announcement_ID })
                .ForeignKey("dbo.FileStorage", t => t.FileStorage_ID, cascadeDelete: true)
                .ForeignKey("dbo.Announcement", t => t.Announcement_ID, cascadeDelete: true)
                .Index(t => t.FileStorage_ID)
                .Index(t => t.Announcement_ID);
            
            CreateTable(
                "dbo.RoleListAnnouncement",
                c => new
                    {
                        RoleList_ID = c.Int(nullable: false),
                        Announcement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleList_ID, t.Announcement_ID })
                .ForeignKey("dbo.RoleList", t => t.RoleList_ID, cascadeDelete: true)
                .ForeignKey("dbo.Announcement", t => t.Announcement_ID, cascadeDelete: true)
                .Index(t => t.RoleList_ID)
                .Index(t => t.Announcement_ID);
            
            CreateTable(
                "dbo.RoleListFileStorage",
                c => new
                    {
                        RoleList_ID = c.Int(nullable: false),
                        FileStorage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleList_ID, t.FileStorage_ID })
                .ForeignKey("dbo.RoleList", t => t.RoleList_ID, cascadeDelete: true)
                .ForeignKey("dbo.FileStorage", t => t.FileStorage_ID, cascadeDelete: true)
                .Index(t => t.RoleList_ID)
                .Index(t => t.FileStorage_ID);
            
            CreateTable(
                "dbo.MeetingFileStorage",
                c => new
                    {
                        Meeting_ID = c.Int(nullable: false),
                        FileStorage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_ID, t.FileStorage_ID })
                .ForeignKey("dbo.Meeting", t => t.Meeting_ID, cascadeDelete: true)
                .ForeignKey("dbo.FileStorage", t => t.FileStorage_ID, cascadeDelete: true)
                .Index(t => t.Meeting_ID)
                .Index(t => t.FileStorage_ID);
            
            CreateTable(
                "dbo.MeetingRoleList",
                c => new
                    {
                        Meeting_ID = c.Int(nullable: false),
                        RoleList_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_ID, t.RoleList_ID })
                .ForeignKey("dbo.Meeting", t => t.Meeting_ID, cascadeDelete: true)
                .ForeignKey("dbo.RoleList", t => t.RoleList_ID, cascadeDelete: true)
                .Index(t => t.Meeting_ID)
                .Index(t => t.RoleList_ID);
            
            CreateTable(
                "dbo.FileSubCatFileStorage",
                c => new
                    {
                        FileSubCat_ID = c.Int(nullable: false),
                        FileStorage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FileSubCat_ID, t.FileStorage_ID })
                .ForeignKey("dbo.FileSubCat", t => t.FileSubCat_ID, cascadeDelete: true)
                .ForeignKey("dbo.FileStorage", t => t.FileStorage_ID, cascadeDelete: true)
                .Index(t => t.FileSubCat_ID)
                .Index(t => t.FileStorage_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FileSubCat", "FlCat_ID", "dbo.FileCat");
            DropForeignKey("dbo.FileSubCatFileStorage", "FileStorage_ID", "dbo.FileStorage");
            DropForeignKey("dbo.FileSubCatFileStorage", "FileSubCat_ID", "dbo.FileSubCat");
            DropForeignKey("dbo.MeetingRoleList", "RoleList_ID", "dbo.RoleList");
            DropForeignKey("dbo.MeetingRoleList", "Meeting_ID", "dbo.Meeting");
            DropForeignKey("dbo.MeetingUserRSVP", "MeetingRSVP_ID", "dbo.Meeting");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MeetingUserRSVP", "AppUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MeetingFileStorage", "FileStorage_ID", "dbo.FileStorage");
            DropForeignKey("dbo.MeetingFileStorage", "Meeting_ID", "dbo.Meeting");
            DropForeignKey("dbo.RoleListFileStorage", "FileStorage_ID", "dbo.FileStorage");
            DropForeignKey("dbo.RoleListFileStorage", "RoleList_ID", "dbo.RoleList");
            DropForeignKey("dbo.RoleListAnnouncement", "Announcement_ID", "dbo.Announcement");
            DropForeignKey("dbo.RoleListAnnouncement", "RoleList_ID", "dbo.RoleList");
            DropForeignKey("dbo.FileStorageAnnouncement", "Announcement_ID", "dbo.Announcement");
            DropForeignKey("dbo.FileStorageAnnouncement", "FileStorage_ID", "dbo.FileStorage");
            DropIndex("dbo.FileSubCatFileStorage", new[] { "FileStorage_ID" });
            DropIndex("dbo.FileSubCatFileStorage", new[] { "FileSubCat_ID" });
            DropIndex("dbo.MeetingRoleList", new[] { "RoleList_ID" });
            DropIndex("dbo.MeetingRoleList", new[] { "Meeting_ID" });
            DropIndex("dbo.MeetingFileStorage", new[] { "FileStorage_ID" });
            DropIndex("dbo.MeetingFileStorage", new[] { "Meeting_ID" });
            DropIndex("dbo.RoleListFileStorage", new[] { "FileStorage_ID" });
            DropIndex("dbo.RoleListFileStorage", new[] { "RoleList_ID" });
            DropIndex("dbo.RoleListAnnouncement", new[] { "Announcement_ID" });
            DropIndex("dbo.RoleListAnnouncement", new[] { "RoleList_ID" });
            DropIndex("dbo.FileStorageAnnouncement", new[] { "Announcement_ID" });
            DropIndex("dbo.FileStorageAnnouncement", new[] { "FileStorage_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FileSubCat", new[] { "FlCat_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.MeetingUserRSVP", new[] { "MeetingRSVP_ID" });
            DropIndex("dbo.MeetingUserRSVP", new[] { "AppUser_Id" });
            DropTable("dbo.FileSubCatFileStorage");
            DropTable("dbo.MeetingRoleList");
            DropTable("dbo.MeetingFileStorage");
            DropTable("dbo.RoleListFileStorage");
            DropTable("dbo.RoleListAnnouncement");
            DropTable("dbo.FileStorageAnnouncement");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FileCat");
            DropTable("dbo.FileSubCat");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.MeetingUserRSVP");
            DropTable("dbo.Meeting");
            DropTable("dbo.RoleList");
            DropTable("dbo.FileStorage");
            DropTable("dbo.Announcement");
        }
    }
}
