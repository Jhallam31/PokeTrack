namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMoveTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pokemon", "Move_MoveID", "dbo.Move");
            DropIndex("dbo.Pokemon", new[] { "Move_MoveID" });
            DropColumn("dbo.Pokemon", "Move_MoveID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pokemon", "Move_MoveID", c => c.Int());
            CreateIndex("dbo.Pokemon", "Move_MoveID");
            AddForeignKey("dbo.Pokemon", "Move_MoveID", "dbo.Move", "MoveID");
        }
    }
}
