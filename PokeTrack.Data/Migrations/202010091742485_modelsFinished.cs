namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsFinished : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Move",
                c => new
                    {
                        MoveID = c.Int(nullable: false, identity: true),
                        MoveName = c.String(nullable: false),
                        Accuracy = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        PokemonCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoveID);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        PokemonID = c.Int(nullable: false, identity: true),
                        PokemonName = c.String(nullable: false),
                        BaseExperience = c.Int(nullable: false),
                        PokemonTypeID = c.Int(nullable: false),
                        MoveOneID = c.Int(nullable: false),
                        MoveTwoID = c.Int(nullable: false),
                        MoveThreeID = c.Int(nullable: false),
                        MoveFourID = c.Int(nullable: false),
                        Move_MoveID = c.Int(),
                    })
                .PrimaryKey(t => t.PokemonID)
                .ForeignKey("dbo.Move", t => t.MoveFourID, cascadeDelete: false)
                .ForeignKey("dbo.Move", t => t.MoveOneID, cascadeDelete: false)
                .ForeignKey("dbo.Move", t => t.MoveThreeID, cascadeDelete: false)
                .ForeignKey("dbo.Move", t => t.MoveTwoID, cascadeDelete: false)
                .ForeignKey("dbo.PokemonType", t => t.PokemonTypeID)
                .ForeignKey("dbo.Move", t => t.Move_MoveID)
                .Index(t => t.PokemonTypeID)
                .Index(t => t.MoveOneID)
                .Index(t => t.MoveTwoID)
                .Index(t => t.MoveThreeID)
                .Index(t => t.MoveFourID)
                .Index(t => t.Move_MoveID);
            
            CreateTable(
                "dbo.PokemonType",
                c => new
                    {
                        PokemonTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        PokemonCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonTypeID);
            
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
            DropForeignKey("dbo.Pokemon", "Move_MoveID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "PokemonTypeID", "dbo.PokemonType");
            DropForeignKey("dbo.Pokemon", "MoveTwoID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveThreeID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveOneID", "dbo.Move");
            DropForeignKey("dbo.Pokemon", "MoveFourID", "dbo.Move");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pokemon", new[] { "Move_MoveID" });
            DropIndex("dbo.Pokemon", new[] { "MoveFourID" });
            DropIndex("dbo.Pokemon", new[] { "MoveThreeID" });
            DropIndex("dbo.Pokemon", new[] { "MoveTwoID" });
            DropIndex("dbo.Pokemon", new[] { "MoveOneID" });
            DropIndex("dbo.Pokemon", new[] { "PokemonTypeID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PokemonType");
            DropTable("dbo.Pokemon");
            DropTable("dbo.Move");
        }
    }
}
