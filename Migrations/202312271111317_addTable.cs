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
                        bCusName = c.String(nullable: false),
                        bCusAddress = c.String(nullable: false),
                        bCusEmail = c.String(nullable: false),
                        bCusSeats = c.Int(nullable: false),
                        bCusPhoneNum = c.String(nullable: false),
                        ResId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bId)
                .ForeignKey("dbo.tblTicketReservation", t => t.ResId, cascadeDelete: true)
                .Index(t => t.ResId);
            
            CreateTable(
                "dbo.tblTicketReservation",
                c => new
                    {
                        ResId = c.Int(nullable: false, identity: true),
                        ResFrom = c.String(nullable: false),
                        ResTo = c.String(nullable: false),
                        ResDepDate = c.String(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        planeSeat = c.Int(nullable: false),
                        ResTicketPrice = c.Single(nullable: false),
                        ResPlaneType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.tblAirplanPlane", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.tblAirplanPlane",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        AirplaneName = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
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
            DropForeignKey("dbo.tblFlightBooking", "ResId", "dbo.tblTicketReservation");
            DropForeignKey("dbo.tblTicketReservation", "PlaneId", "dbo.tblAirplanPlane");
            DropIndex("dbo.tblTicketReservation", new[] { "PlaneId" });
            DropIndex("dbo.tblFlightBooking", new[] { "ResId" });
            DropTable("dbo.tblUserAccount");
            DropTable("dbo.tblAirplanPlane");
            DropTable("dbo.tblTicketReservation");
            DropTable("dbo.tblFlightBooking");
            DropTable("dbo.tblAdminLogin");
        }
    }
}
