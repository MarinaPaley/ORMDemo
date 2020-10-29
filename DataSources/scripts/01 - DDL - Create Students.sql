create table Students
(
      ID          int           primary key
    , [ID_Groups] int           not null
    , Name        nvarchar(255) not null

    , foreign key([ID_Groups])
      references Groups(ID)
);
