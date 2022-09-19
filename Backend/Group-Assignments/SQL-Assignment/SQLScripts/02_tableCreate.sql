USE SuperheroesDb;

CREATE TABLE Superhero (
	Id int PRIMARY KEY IDENTITY(1,1),
	SuperheroName nvarchar(50),
	Alias nvarchar(50),
	Origin nvarchar(50)
);

CREATE TABLE Assistant (
	Id int PRIMARY KEY IDENTITY(1,1),
	AssistantName nvarchar(50)
);

CREATE TABLE Superheropower (
	Id int PRIMARY KEY IDENTITY(1,1),
	PowerName nvarchar(50),
	PowerDescription nvarchar(50)
);