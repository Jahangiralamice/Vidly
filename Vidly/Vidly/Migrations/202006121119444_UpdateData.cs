namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Pay as You Go' where Id = 1");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Monthly' where Id = 2");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Quaterly' where Id = 3");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
