namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Authors",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 512),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Books",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Title = c.String(nullable: false),
            //            ISBN = c.String(maxLength: 13, fixedLength: true),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.BookAuthors",
            //    c => new
            //        {
            //            AuthorId = c.Int(nullable: false),
            //            BookId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.AuthorId, t.BookId })
            //    .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
            //    .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
            //    .Index(t => t.AuthorId)
            //    .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            //DropForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors");
            //DropIndex("dbo.BookAuthors", new[] { "BookId" });
            //DropIndex("dbo.BookAuthors", new[] { "AuthorId" });
            //DropTable("dbo.BookAuthors");
            //DropTable("dbo.Books");
            //DropTable("dbo.Authors");
        }
    }
}
