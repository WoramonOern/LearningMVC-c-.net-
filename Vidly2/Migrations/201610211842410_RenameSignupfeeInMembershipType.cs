namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameSignupfeeInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            Sql("UPDATE MembershipTypes SET SignUpFee = SignUpFree");
            DropColumn("dbo.MembershipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFree", c => c.Short(nullable: false));
            Sql("UPDATE MembershipTypes SET SignUpFree = SignUpFee");
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
