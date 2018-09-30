namespace BooksAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        authorId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.authorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 256),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        genre = c.String(maxLength: 100),
                        publishDate = c.DateTime(nullable: false),
                        description = c.String(),
                        authorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bookId)
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
