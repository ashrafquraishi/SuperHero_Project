namespace Super_Heroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmethods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperHeroModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuperHeroName = c.String(),
                        primarysuperheroability = c.String(),
                        secondarysuperheroability = c.String(),
                        alterego = c.String(),
                        catchPhrase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SuperHeroModels");
        }
    }
}
