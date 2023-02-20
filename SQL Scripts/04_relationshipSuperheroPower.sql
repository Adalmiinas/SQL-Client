CREATE TABLE SuperheroPower(
	SuperheroId int NOT NULL,
	SPowerId int NOT NULL
	CONSTRAINT PK_SuperheroPower PRIMARY KEY (SuperheroId, SPowerId),
	CONSTRAINT FK_SuperheroPower_Superhero FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId),
	CONSTRAINT FK_SuperheroPower_SPower FOREIGN KEY (SPowerId) REFERENCES SPower(SPowerId),
)