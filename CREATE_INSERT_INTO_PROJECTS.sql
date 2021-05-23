CREATE TABLE PROJECTS (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(1000),
	Description VARCHAR(1000)
);

CREATE TABLE PROJECT_LINKS (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ProjectId INT NOT NULL,
	Url VARCHAR(200) NOT NULL,
	Website VARCHAR(30) NOT NULL,
	CONSTRAINT FK_LINKS FOREIGN KEY (ProjectId) REFERENCES PROJECTS(Id)
);

INSERT INTO PROJECTS (Name, Description) VALUES ('Top Down Analysis', 'Top down analysis of the market');
INSERT INTO PROJECTS (Name, Description) VALUES ('Stock Screener', 'A desktop application that utilizes Selenium to scrape three different websites for specific stock information.  The user can select to scrape the websites using two different screeners.  The first screener has the user select specific preferences to use, eliminating any items that do not fit the selected criteria.  The second allows the user to upload a preformatted document that contains the stock symbols that they want to scrape.  The information is then compiled into tables for the user to view the information.  There they can save them as multiple different file types (.docx, .xlsx, .html, and .xml).');
INSERT INTO PROJECTS (Name, Description) VALUES ('ASP.Net MVC Resume', 'Resume and portfolio as an ASP.Net MVC webiste');

INSERT INTO PROJECT_LINKS (ProjectId, Url, Website) VALUES ((SELECT Id FROM PROJECTS WHERE Name = 'Top Down Analysis'), 'https://github.com/nbernardo-hp/Top-Down-Analysis', 'GitHub');
INSERT INTO PROJECT_LINKS (ProjectId, Url, Website) VALUES ((SELECT Id FROM PROJECTS WHERE Name = 'Stock Screener'), 'https://github.com/nbernardo-hp/Screener', 'GitHub');
INSERT INTO PROJECT_LINKS (ProjectId, Url, Website) VALUES ((SELECT Id FROM PROJECTS WHERE Name = 'ASP.Net MVC Resume'), 'https://github.com/nbernardo-hp/Projects/tree/master/Projects', 'GitHub');
INSERT INTO PROJECT_LINKS (ProjectId, Url, Website) VALUES ((SELECT Id FROM PROJECTS WHERE Name = 'ASP.Net MVC Resume'), '/Home/Resume', 'ASP.Net MVC');
INSERT INTO PROJECT_LINKS (ProjectId, Url, Website) VALUES ((SELECT Id FROM PROJECTS WHERE Name = 'Top Down Analysis'), '/Stocks/TopDownAnalysis', 'ASP.Net MVC');