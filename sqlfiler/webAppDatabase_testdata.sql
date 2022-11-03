USE webAppDatabase;

delete from users;

insert into users (firstname, lastname, email, phone) 
values 
('Sandra', 'Høyland', 'sandra@email.com', '42424242'),
('Sarah', 'Kristiansen', 'sarah@email.com', '12345678'),
('Even', 'Foss', 'evan@email.com', '23456789'),
('Kasper', 'Forum', 'kasper@email.com', '34567891'),
('Sander', 'Aadal', 'sander@email.com', '45678912'),
('Oskar', 'Thomassen', 'oskar@email.com', '56789123'),
('Heidi', 'Klum', 'heidi@email.com', '98467364'),
('Karin', 'Pettersen', 'karin@email.com', '46453729'),
('Ola', 'Nordman', 'ola@email.com', '47205739'),
('Dagny', 'Olsen', 'dagny@email.com', '48302846'),
('Hans', 'Hansen', 'hans@email.com', '749284629'),
('Kåre', 'Klatremus', 'kaare@email.com', '7483'),
('Bob', 'Kåreland', 'bob@email.com', '572902745'),
('Lillian', 'Sabeltann', 'lillian@email.com', '520843254'),
('Monika', 'Meland', 'monika@email.com', '120438924'),
('Monica', 'Håland', 'monica@email.com', '58427472'),
('Britt Kari', 'Glienke', 'brittkari@email.com', '09560265'),
('Paul', 'Paulsen', 'paul@email.com', '947382045'),
('Leander', 'Iversen', 'leander@email.com', '5302754875'),
('John', 'Johnsen', 'john@email.com', '300452846');

select * from users;

delete from teamLeader;

insert into teamLeader (userId)
values
(1),
(2),
(3),
(4),
(5),
(6);

select * from teamleader;

delete from administrator;

insert into administrator (userId)
values
(1),
(8),
(9);

select * from administrator;

delete from team; 

insert into team (teamName) 
values 
('Salg og marked'),
('Produksjon'),
('Teknisk'),
('Logistikk'); 

select * from team; 

delete from subTeam;

insert into subTeam (teamId, subTeamName)
values
(1, 'Salg Norge'),
(1, 'Kundesenter'),
(1, 'Øst'),
(1, 'Sør/Vest'),
(1, 'Midt/Nord'),
(2, 'Produksjonsledelse'),
(2, 'Presse'),
(2, 'Kantlister'),
(2, 'Utfresing'),
(2, 'Lakkering'),
(2, 'Montering'),
(2, 'Karm'),
(2, 'Listing'),
(2, 'Glassmontering'),
(3, 'Systemutvikling & QA'),
(3, 'Servicesenter'),
(3, 'Vedlikehold'),
(4, 'Innkjøp'),
(4, 'Logistikk Lyngdal'),
(4, 'QL Rige');

select * from subTeam;

delete from suggestions;

insert into suggestions (title, description, userId, status)
values
('Vask opp', 'Dere må vaske opp i kantina', '3', 'Pending'),
('Kost gulvet', 'Dere må koste gulvet i møterom 1', '2', 'Act'),
('Lyspære', 'Må bytte lyspære ved inngangen', '5', 'Plan'),
('Fiks PC', 'PCene er for gamle, de fryser bare man skriver en setning', '7', 'Act'),
('Hierarkifeil', 'Vi føler at man ikke trenger teamleder i logistikk Lyngdal', '15', 'Do'),
('Ødelagte paller', 'Paller blir ødelagt veldig fort grunnet korte spikre', '20', 'Act'),
('Temperatur', 'Det er for kaldt i kantina', '1', 'Do'),
('Badet', 'Badet  trenger ny dør', '17', 'Do'),
('Treverk', 'Treverket er for dårlig i vår siste leveranse. Stammen var for gammel.', '18', 'Act'),
('Glassdør', 'Glassdør knuser for fort og det kommer glasskår overalt som ikke er bra :-(', '12', 'Study'),
('Kaldt gulv', 'Det er kaldt gulv i produksjonshallen', '17', 'Act'),
('Lys', 'Lys i gangen blinker', '17', 'Study'),
('Rake blader', 'Mya blader ved inngangen', '1', 'Do'),
('Oppvask', 'Det er mye oppvask som ikke er tatt', '5', 'Act');

select * from suggestions; 

delete from teamUser;

insert into teamUser (teamId, subTeamId, userId)
values 
(1, 1, 15),
(1, 2, 10), 
(1, 3, 12), 
(1, 4, 3), 
(2, 6, 1), 
(2, 14, 5),
(2, 16, 8), 
(3, 16, 2), 
(4, 19, 3), 
(2, 14, 4),
(1, 1, 6),
(1, 2, 7), 
(1, 3, 9), 
(1, 4, 11), 
(2, 6, 13), 
(2, 14, 14),
(2, 16, 16), 
(3, 17, 17), 
(2, 6, 18), 
(2, 14, 19);

select * from teamUser; 

delete from status;

insert into status (name)
values 
('Pending'), 
('Plan'), 
('Do'), 
('Study'),
('Act');

select * from status; 