create table PLAYERS
(
	 ID 		int identity
	,FirstName		nvarchar(64)
	,LastName		nvarchar(64)
	,Username		nvarchar(64)
	,Email		nvarchar(64)
	,Password		nvarchar(30)
	,constraint PK_PLAYER primary key (ID)
);

---------------------------------------------------------------------------------------------------------------

CREATE PROC AddPlayer
@FirstName nvarchar(64),
@LastName nvarchar(64),
@Username nvarchar(64),
@Email nvarchar(64),
@Password nvarchar(30)

AS

insert into PLAYERS 
   (FirstName, LastName, Username, Email, Password)
values
   (@FirstName, @LastName, @Username, @Email, @Password);

---------------------------------------------------------------------------------------------------------------

CREATE PROC UNAuthenticity
@Username nvarchar(64)

AS

Select Username from PLAYERS where Username = @Username;

---------------------------------------------------------------------------------------------------------------

CREATE PROC UserLogin
@Username nvarchar(64),
@Password nvarchar(30)

AS

Select Username, Password from PLAYERS where Username = @Username and Password = @Password;

---------------------------------------------------------------------------------------------------------------

CREATE PROC ViewInformation
@Username nvarchar(64)

AS

Select FirstName, LastName, Email from PLAYERS where Username = @Username;

---------------------------------------------------------------------------------------------------------------

CREATE PROC EmailAuthenticity
@Email nvarchar(64)

AS

Select Email from PLAYERS where Email = @Email;
