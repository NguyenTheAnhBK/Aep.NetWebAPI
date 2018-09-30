namespace BookService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 256),
                        year = c.Int(nullable: false),
                        genre = c.String(maxLength: 200),
                        authorId = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Authors", t => t.authorId, cascadeDelete: true)
                .Index(t => t.authorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "authorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "authorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
