CREATE TABLE Preferences (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(15) NOT NULL,
);

CREATE TABLE SubPreferences (
	Preference INT NOT NULL,
	Name VARCHAR(17) NOT NULL,
	Value FLOAT NOT NULL,
	CONSTRAINT FK_Pref FOREIGN KEY (Preference) REFERENCES Preferences(Id),
	CONSTRAINT PK_PrefName PRIMARY KEY (Preference, Name)
);

INSERT INTO Preferences (Name) VALUES ('sma200');
INSERT INTO Preferences (Name) VALUES ('sma50');
INSERT INTO Preferences (Name) VALUES ('sma20');
INSERT INTO Preferences (Name) VALUES ('chartPattern');
INSERT INTO Preferences (Name) VALUES ('unexpectedItems');

INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma200'), 'up', 10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma200'), 'upDown', 5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma200'), 'down', 0);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma50'), 'above', 10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma20'), 'above', 10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma50'), 'at', 5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma20'), 'at', 5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma50'), 'below', 0);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'sma20'), 'below', 0);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'chartPattern'), 'bullRun', 10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'chartPattern'), 'bullConsolidation', 5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'chartPattern'), 'consolidation', 0);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'chartPattern'), 'bearConsolidation', -5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'chartPattern'), 'bearRun', -10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'veryGood', 10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'good', 5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'average', 0);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'bad', -5);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'veryBad', -10);
INSERT INTO SubPreferences (Preference, Name, Value) VALUES ((SELECT Id FROM Preferences P WHERE P.Name = 'unexpectedItems'), 'noNews', 0);