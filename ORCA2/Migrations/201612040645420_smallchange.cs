namespace ORCA2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expertises", "LinkedEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expertises", "LinkedEmail", c => c.String());
        }
    }
}
