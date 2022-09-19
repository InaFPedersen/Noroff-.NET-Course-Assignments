USE SuperheroesDb;

INSERT INTO Superheropower (PowerName, PowerDescription)
VALUES
('Fly', 'Gives the superhero the ability to fly'),
('Superstrength', 'Gives the superhero super strength'),
('Lazer', 'Gives the superhero ability to shoot lazer'),
('Superspeed', 'Makes the superhero run super fast');

INSERT INTO SuperheroPowers (SuperheroId, PowerId)
VALUES
(1, 1),
(1, 2),
(1, 3),
(3, 4);