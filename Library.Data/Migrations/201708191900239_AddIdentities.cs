namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentities : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "FK_BookAuthors_Authors");
            //DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "FK_BookAuthors_Books");
            DropPrimaryKey("dbo.Authors", "PK_Authors");
            DropPrimaryKey("dbo.Books", "PK_Books");
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
            AddPrimaryKey("dbo.Authors", "Id");
            AddForeignKey("dbo.BookAuthors", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
