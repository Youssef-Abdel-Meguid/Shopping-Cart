namespace ShoppingCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSidebarToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sidebars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sidebars");
        }
    }
}
