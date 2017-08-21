
--DROP PROCEDURE Book_Insert 
CREATE PROCEDURE Book_Insert 
	(
		@Title nvarchar(max),
		@ISBN nchar(13)
	)
AS
BEGIN
	INSERT dbo.Books(Title, ISBN)
	VALUES(@Title, @ISBN)

	SELECT SCOPE_IDENTITY() AS Id
END
GO


CREATE PROCEDURE Book_Update 
	(
		@Id int,
		@Title nvarchar(max),
		@ISBN nchar(13)
	)
AS
BEGIN
	UPDATE dbo.Books
	SET Title = @Title, ISBN = @ISBN
	WHERE Id = @Id
END
GO

CREATE PROCEDURE Book_Delete 
	(
		@Id int
	)
AS
BEGIN
	DELETE dbo.Books
	WHERE Id = @Id
END
GO

