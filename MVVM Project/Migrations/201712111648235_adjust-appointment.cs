namespace Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustappointment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "AppointmentDate");
            DropColumn("dbo.Appointments", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "AppointmentDate", c => c.DateTime(nullable: false));
        }
    }
}
