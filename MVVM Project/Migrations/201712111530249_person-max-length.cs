namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personmaxlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "FristName", c => c.String(maxLength: 200));
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FristName", c => c.String());
        }
    }
}
