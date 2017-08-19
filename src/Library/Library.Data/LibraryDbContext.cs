using Library.Data.Models;

namespace Library.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class LibraryDbContext : DbContext
	{
		public LibraryDbContext()
			: base("name=LibraryDbContext")
		{
		}

		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>()
				.HasMany(e => e.Books)
				.WithMany(e => e.Authors)
				.Map(m => m.ToTable("BookAuthors").MapLeftKey("AuthorId").MapRightKey("BookId"));

			modelBuilder.Entity<Book>()
				.Property(e => e.ISBN)
				.IsFixedLength();
		}
	}
}
