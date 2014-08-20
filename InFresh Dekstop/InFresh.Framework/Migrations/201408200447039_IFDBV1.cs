namespace InFresh.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IFDBV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SBDP",
                c => new
                    {
                        SDSDNO = c.String(nullable: false, maxLength: 15),
                        SDSDNM = c.String(nullable: false, maxLength: 30),
                        SDSDON = c.String(maxLength: 15),
                        SDADD1 = c.String(nullable: false, maxLength: 100),
                        SDADD2 = c.String(maxLength: 100),
                        SDCITY = c.String(maxLength: 30),
                        SDZPCD = c.String(maxLength: 5),
                        SDPHN1 = c.String(maxLength: 15),
                        SDFAX1 = c.String(maxLength: 15),
                        SDGELC = c.String(),
                        SDLGTD = c.Double(nullable: false),
                        SDLTTD = c.Double(nullable: false),
                        SDIURL = c.String(),
                        SDRMRK = c.String(),
                        SDSTAT = c.Int(nullable: false),
                        SDDTCR = c.String(maxLength: 20),
                        SDLSUP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SDSDNO);
            
            CreateTable(
                "dbo.ZTP1",
                c => new
                    {
                        T1T1NO = c.String(nullable: false, maxLength: 30),
                        T1T1NM = c.String(nullable: false, maxLength: 100),
                        T1T1TP = c.String(nullable: false, maxLength: 30),
                        T1ENTY = c.String(maxLength: 100),
                        T1APFR = c.String(maxLength: 100),
                        T1RMRK = c.String(),
                        T1STAT = c.Int(nullable: false),
                        T1DTCR = c.String(maxLength: 20),
                        T1LSUP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.T1T1NO);
            
            CreateTable(
                "dbo.ZTP2",
                c => new
                    {
                        T2T2NO = c.Int(nullable: false, identity: true),
                        T2T1NO = c.String(nullable: false, maxLength: 30),
                        T2SQCE = c.Int(nullable: false),
                        T2SRCE = c.String(maxLength: 100),
                        T2DSTN = c.String(maxLength: 100),
                        T2NMED = c.String(maxLength: 100),
                        T2RMRK = c.String(),
                        T2STAT = c.Int(nullable: false),
                        T2DTCR = c.String(maxLength: 20),
                        T2LSUP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.T2T2NO)
                .ForeignKey("dbo.ZTP1", t => t.T2T1NO, cascadeDelete: true)
                .Index(t => t.T2T1NO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZTP2", "T2T1NO", "dbo.ZTP1");
            DropIndex("dbo.ZTP2", new[] { "T2T1NO" });
            DropTable("dbo.ZTP2");
            DropTable("dbo.ZTP1");
            DropTable("dbo.SBDP");
        }
    }
}
