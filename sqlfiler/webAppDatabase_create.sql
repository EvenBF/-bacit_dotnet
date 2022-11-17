USE webAppDatabase;

drop table teamUser;
drop table suggestions;
drop table administrator;
drop table teamLeader;
drop table users;
drop table subTeam;
drop table team;
drop table status;

CREATE TABLE status(
    statusName varchar(20) DEFAULT "Pending"  primary key
);

CREATE TABLE team (
    teamId INT auto_increment primary key, 
    teamName VARCHAR(20) NOT NULL
);

CREATE TABLE subTeam (
    subTeamId INT auto_increment primary key, 
    subTeamName VARCHAR(20) NOT NULL,
    teamId INT, 
    CONSTRAINT subTeamFK
    FOREIGN KEY (teamId) REFERENCES team(teamId)
);

CREATE TABLE users (
    userId INT auto_increment PRIMARY KEY,
    firstname VARCHAR(20) NOT NULL,
    lastname VARCHAR(20) NOT NULL,
    email VARCHAR(30) NOT NULL,
    phone VARCHAR(12) NOT NULL
);

CREATE TABLE teamLeader (
    leaderId INT auto_increment PRIMARY KEY,
    userId INT,
    CONSTRAINT userLeaderFK 
    FOREIGN KEY (userId) REFERENCES users(userId)
);

CREATE TABLE administrator (
    adminId INT auto_increment PRIMARY KEY,
    userId INT,
    CONSTRAINT userAdminFK 
    FOREIGN KEY (userId) REFERENCES users(userId)
);

CREATE TABLE suggestions (
    sugId int auto_increment primary key,
    title varchar(20) NOT NULL,
    teamId INT NOT NULL DEFAULT 1,
    description varchar(500) NOT NULL,
    TimeStamp TIMESTAMP,
    userId INT,
    statusName varchar(20) default "Pending",
    CONSTRAINT userFK
    FOREIGN KEY (userId) REFERENCES users(userId),
    CONSTRAINT teamFK
    FOREIGN KEY (teamId) REFERENCES team(teamId),
    CONSTRAINT statusName
    FOREIGN KEY (statusName) REFERENCES status(statusName)
);

CREATE TABLE teamUser (
    teamId INT,
    subTeamId INT,
    userId INT, 
    TimeStamp TIMESTAMP,
    CONSTRAINT teamUserPK
    PRIMARY KEY (teamId, userId),
    CONSTRAINT userTeamFK
    FOREIGN KEY (userId) REFERENCES users(userId),
    CONSTRAINT teamUserFK
    FOREIGN KEY (teamId) REFERENCES team(teamId),
    CONSTRAINT subFK 
    FOREIGN KEY (subTeamId) REFERENCES subTeam(subTeamId)
);




