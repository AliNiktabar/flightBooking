namespace flightbooking_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdminLogin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 10),
                        AdminPassword = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.tblFlightBooking",
                c => new
                    {
                        bId = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false, maxLength: 40),
                        To = c.String(nullable: false, maxLength: 40),
                        DDate = c.DateTime(nullable: false),
                        DTime = c.String(maxLength: 15),
                        SeatType = c.String(maxLength: 25),
                        planeInfo_PlaneId = c.Int(),
                    })
                .PrimaryKey(t => t.bId)
                .ForeignKey("dbo.tblAdminPlane", t => t.planeInfo_PlaneId)
                .Index(t => t.planeInfo_PlaneId);
            
            CreateTable(
                "dbo.tblAdminPlane",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        AirplaneName = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.tblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 10),
                        CPassword = c.String(maxLength: 10),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFlightBooking", "planeInfo_PlaneId", "dbo.tblAdminPlane");
            DropIndex("dbo.tblFlightBooking", new[] { "planeInfo_PlaneId" });
            DropTable("dbo.tblUserAccount");
            DropTable("dbo.tblAdminPlane");
            DropTable("dbo.tblFlightBooking");
            DropTable("dbo.tblAdminLogin");
        }
    }
}
