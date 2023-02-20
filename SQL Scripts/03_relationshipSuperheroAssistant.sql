ALTER TABLE Assistant
ADD SuperheroId int NOT NULL
FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId)