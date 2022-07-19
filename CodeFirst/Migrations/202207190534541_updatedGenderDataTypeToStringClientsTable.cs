namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedGenderDataTypeToStringClientsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "GenderId");
            DropTable("dbo.Genders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clients", "GenderId", c => c.Int(nullable: false));
            DropColumn("dbo.Clients", "Gender");
        }
    }
}
