CREATE TABLE Stocks (
	Symbol VARCHAR(5) NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	FinvizRank INT,
	IndividualRating FLOAT NOT NULL,
	Type CHAR(1),
	CONSTRAINT SymbolConstraint CHECK (Symbol NOT LIKE '%[^A-Za-z]%')
);


CREATE TABLE StockPreferences (
	Stock VARCHAR(5) NOT NULL,
	Preference INT NOT NULL,
	Value VARCHAR(17) NOT NULL,
	CONSTRAINT PK_SymbolPref PRIMARY KEY (Stock, Preference),
	CONSTRAINT FK_Symbol FOREIGN KEY (Stock) REFERENCES Stocks(Symbol),
	CONSTRAINT FK_StockPref FOREIGN KEY (Preference) REFERENCES Preferences(Id)
);

INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('SPY','S&P 500',8.5,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('QQQ','NASDAQ',8.5,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('IWM','Russell 2000',8.5,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('IYY','Dow Jones',7.8,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('ZIV','Volatility',7.7,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('IEF','Bond Yields',3.4,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('FXI','China',7.7,'M');
INSERT INTO Stocks (Symbol, Name, IndividualRating, Type) VALUES ('IEV','Europe',7.8,'M');
INSERT INTO Stocks VALUES ('XLB','Basic Materials',5,6.8,'S');
INSERT INTO Stocks VALUES ('XLE','Energy',6,5.5,'S');
INSERT INTO Stocks VALUES ('XLF','Financial',2,8.1,'S');
INSERT INTO Stocks VALUES ('XLI','Industrial',3,7.9,'S');
INSERT INTO Stocks VALUES ('XLK','Technology',4,7.6,'S');
INSERT INTO Stocks VALUES ('XLP','Consumer Staples',9,5.3,'S');
INSERT INTO Stocks VALUES ('IYR','Real Estate',8,6,'S');
INSERT INTO Stocks VALUES ('XLU','Utilities',10,4.3,'S');
INSERT INTO Stocks VALUES ('XLV','Health Care',1,7.8,'S');
INSERT INTO Stocks VALUES ('XLY','Consumer Disc',7,6.3,'S');


DECLARE @Pref AS INT = (SELECT Id FROM Preferences WHERE Name = 'sma200');

INSERT INTO StockPreferences VALUES ('SPY', @Pref,'up');
INSERT INTO StockPreferences VALUES ('QQQ', @Pref,'up');
INSERT INTO StockPreferences VALUES ('IWM', @Pref,'up');
INSERT INTO StockPreferences VALUES ('IYY', @Pref,'up');
INSERT INTO StockPreferences VALUES ('ZIV', @Pref,'up');
INSERT INTO StockPreferences VALUES ('IEF', @Pref,'Down');
INSERT INTO StockPreferences VALUES ('FXI', @Pref,'up');
INSERT INTO StockPreferences VALUES ('IEV', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLB', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLE', @Pref,'upDown');
INSERT INTO StockPreferences VALUES ('XLF', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLI', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLK', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLP', @Pref,'upDown');
INSERT INTO StockPreferences VALUES ('IYR', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLU', @Pref,'upDown');
INSERT INTO StockPreferences VALUES ('XLV', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLY', @Pref,'up');

SET @Pref = (Select Id FROM Preferences WHERE Name = 'sma50');
INSERT INTO StockPreferences VALUES ('QQQ', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IWM', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IYY', @Pref,'above');
INSERT INTO StockPreferences VALUES ('ZIV', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IEF', @Pref,'below');
INSERT INTO StockPreferences VALUES ('FXI', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IEV', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLB', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLE', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLF', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLI', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLK', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLP', @Pref,'upDown');
INSERT INTO StockPreferences VALUES ('IYR', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLU', @Pref,'upDown');
INSERT INTO StockPreferences VALUES ('XLV', @Pref,'up');
INSERT INTO StockPreferences VALUES ('XLY', @Pref,'up');

SET @Pref = (Select Id FROM Preferences WHERE Name = 'sma20');
INSERT INTO StockPreferences VALUES ('QQQ', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IWM', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IYY', @Pref,'above');
INSERT INTO StockPreferences VALUES ('ZIV', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IEF', @Pref,'at');
INSERT INTO StockPreferences VALUES ('FXI', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IEV', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLB', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLE', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLF', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLI', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLK', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLP', @Pref,'above');
INSERT INTO StockPreferences VALUES ('IYR', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLU', @Pref,'below');
INSERT INTO StockPreferences VALUES ('XLV', @Pref,'above');
INSERT INTO StockPreferences VALUES ('XLY', @Pref,'above');

SET @Pref = (Select Id FROM Preferences WHERE Name = 'chartPattern');
INSERT INTO StockPreferences VALUES ('QQQ', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('IWM', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('IYY', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('ZIV', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('IEF', @Pref,'consolidation');
INSERT INTO StockPreferences VALUES ('FXI', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('IEV', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('XLB', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('XLE', @Pref,'consolidation');
INSERT INTO StockPreferences VALUES ('XLF', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('XLI', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('XLK', @Pref,'bull Run');
INSERT INTO StockPreferences VALUES ('XLP', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('IYR', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('XLU', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('XLV', @Pref,'bullConsolidation');
INSERT INTO StockPreferences VALUES ('XLY', @Pref,'bullConsolidation');

SET @Pref = (Select Id FROM Preferences WHERE Name = 'unexpectedItems');
INSERT INTO StockPreferences VALUES ('QQQ', @Pref,'noNews');
INSERT INTO StockPreferences VALUES ('IWM', @Pref,'average');
INSERT INTO StockPreferences VALUES ('IYY', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('ZIV', @Pref,'average');
INSERT INTO StockPreferences VALUES ('IEF', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('FXI', @Pref,'average');
INSERT INTO StockPreferences VALUES ('IEV', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLB', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLE', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLF', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLI', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLK', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLP', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('IYR', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLU', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLV', @Pref,'bad');
INSERT INTO StockPreferences VALUES ('XLY', @Pref,'bad');