namespace BulletPower.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_Create_User_Role : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Desciprtion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Credits = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
