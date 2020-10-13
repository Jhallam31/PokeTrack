namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstNewMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Move",
                c => new
                    {
                        MoveID = c.Int(nullable: false, identity: true),
                        MoveName = c.String(nullable: false),
                        Description = c.String(),
                        Accuracy = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoveID)
                .ForeignKey("dbo.Type", t => t.TypeID, cascadeDelete: false)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        PokemonCount = c.Int(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        PokemonID = c.Int(nullable: false, identity: true),
                        PokemonName = c.String(nullable: false),
                        BaseExperience = c.Int(nullable: false),
                        TypeID1 = c.Int(),
                        TypeID2 = c.Int(),
                        MoveOneID = c.Int(nullable: false),
                        MoveTwoID = c.Int(),
                        MoveThreeID = c.Int(),
                        MoveFourID = c.Int(),
                    })
                .PrimaryKey(t => t.PokemonID)
                .ForeignKey("dbo.Move", t => t.MoveFourID)
                .ForeignKey("dbo.Move", t => t.MoveOneID, cascadeDelete: false)
                .ForeignKey("dbo.Move", t => t.MoveThreeID)
                .ForeignKey("dbo.Move", t => t.MoveTwoID)
                .ForeignKey("dbo.Type", t => t.TypeID1)
                .ForeignKey("dbo.Type", t => t.TypeID2)
                .Index(t => t.TypeID1)
                .Index(t => t.TypeID2)
                .Index(t => t.MoveOneID)
                .Index(t => t.MoveTwoID)
                .Index(t => t.MoveThreeID)
                .Index(t => t.MoveFourID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Move", "TypeID", "dbo.Type");
            DropForeignKey("dbo.Pokemon", "TypeID2", "dbo.Type");
            DropForeignKey("dbo.Pokemon", "TypeID1", "dbo.Type");
            DropForeignKey("dbo.Pokemon", "MoveTwoID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveThreeID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveOneID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveFourID", "dbo.Move");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pokemon", new[] { "MoveFourID" });
            DropIndex("dbo.Pokemon", new[] { "MoveThreeID" });
            DropIndex("dbo.Pokemon", new[] { "MoveTwoID" });
            DropIndex("dbo.Pokemon", new[] { "MoveOneID" });
            DropIndex("dbo.Pokemon", new[] { "TypeID2" });
            DropIndex("dbo.Pokemon", new[] { "TypeID1" });
            DropIndex("dbo.Move", new[] { "TypeID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Pokemon");
            DropTable("dbo.Type");
            DropTable("dbo.Move");
        }
    }
}
