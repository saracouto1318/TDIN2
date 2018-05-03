CREATE TABLE User(
    idUser INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(50) NOT NULL
);

CREATE TABLE Department(
    idDepartment INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE Ticket(
    idTicket INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    idSender INTEGER NOT NULL,
    idSolver INTEGER,
    title VARCHAR(500) NOT NULL,
    description VARCHAR(1000000) NOT NULL,
    dateTime DATETIME NOT NULL,
    status VARCHAR(50) DEFAULT ('unassigned'),
    FOREIGN KEY (idSender) REFERENCES User(idUser)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (idSolver) REFERENCES User(idUser)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

CREATE TABLE SecondaryQuestions(
    idQuestion INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    idTicket INTEGER NOT NULL,
    idSender INTEGER NOT NULL,
    idDepartment INTEGER,
    question VARCHAR(1000000) NOT NULL,
	response VARCHAR(1000000) NOT NULL,
    dateTime DATETIME NOT NULL,
    FOREIGN KEY (idTicket) REFERENCES Ticket(idTicket)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (idSender) REFERENCES User(idUser)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (idDepartment) REFERENCES Department(idDepartment)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

CREATE TABLE Email(
    idEmail INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    idSender INTEGER NOT NULL,
    idReceiver INTEGER NOT NULL,
    idTicket INTEGER NOT NULL,
    content VARCHAR(1000000) NOT NULL,
    dateTime DATETIME NOT NULL,
    FOREIGN KEY (idTicket) REFERENCES Ticket(idTicket)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (idSender) REFERENCES User(idUser)
        ON DELETE SET NULL
        ON UPDATE CASCADE,
    FOREIGN KEY (idReceiver) REFERENCES User(idReceiver)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

CREATE TABLE Session(
    sessionID int NOT NULL PRIMARY KEY,
    userID varchar(50) NOT NULL,
    FOREIGN KEY (idUser) REFERENCES User(idUser)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);