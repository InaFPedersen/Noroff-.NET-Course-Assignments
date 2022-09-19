
USE SuperheroesDb;

CREATE TABLE SuperheroPowers
(
	SuperheroId int NOT NULL FOREIGN KEY REFERENCES Superhero(Id),
	PowerId int NOT NULL FOREIGN KEY REFERENCES Superheropower(Id)
);

ALTER TABLE SuperheroPowers
	ADD CONSTRAINT pk_myConstraint PRIMARY KEY (SuperheroId, PowerId);