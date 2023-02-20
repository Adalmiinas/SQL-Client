CREATE TABLE Superhero (
	SuperheroId int IDENTITY(1,1) PRIMARY KEY,
	SuperheroName nvarchar(20) NOT NULL,
	SuperheroAlias nvarchar(30),
	SuperheroOrigin nvarchar(30)
)

CREATE TABLE Assistant (
	AssistantId int IDENTITY(1,1) PRIMARY KEY,
	AssistantName nvarchar(20) NOT NULL
)

CREATE TABLE SPower (
	SPowerId int IDENTITY(1,1) PRIMARY KEY,
	SPowerName nvarchar(20) NOT NULL,
	SPowerDesc nvarchar(30)
)