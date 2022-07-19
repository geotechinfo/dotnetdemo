namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGenderDataTypeToIntTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "GenderId", c => c.Int(nullable: false));
            DropColumn("dbo.Clients", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "GenderId");
        }
    }
}
