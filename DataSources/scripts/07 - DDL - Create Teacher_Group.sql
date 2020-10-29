-- Имя придумано произвольно, не соответствует стандарту
CREATE TABLE Teacher_Group
(
      ID            INT PRIMARY KEY
    , [ID_Teachers] INT NOT NULL
    , [ID_Groups]   INT NOT NULL

    , FOREIGN KEY ([ID_Teachers])
      REFERENCES Teachers (ID)

    , FOREIGN KEY ([ID_Groups])
      REFERENCES Groups (ID)
);
