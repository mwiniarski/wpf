namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserindex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "UserId", c => c.String(nullable: false, maxLength: 32));
            CreateIndex("dbo.People", "UserId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", new[] { "UserId" });
            AlterColumn("dbo.People", "UserId", c => c.String());
        }
    }
}
