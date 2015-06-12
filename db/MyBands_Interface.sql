SET NAMES 'utf8';
/*MyBands page; Code = 27*/
/*English*/
/*gvBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvBands", 27, site_language.Id , "MyBands page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Description", "gvBands", 27, site_language.Id , "MyBands page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Languages", "gvBands", 27, site_language.Id , "MyBands page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Leader", "gvBands", 27, site_language.Id , "MyBands page", 1, 4 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Create New", "btnCreate", 27, site_language.Id , "MyBands page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Leave", "btnLeave", 27, site_language.Id , "MyBands page" from site_language where LangCode = "en";

/*Русский*/
/*gvBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvBands", 27, site_language.Id , "MyBands page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Описание", "gvBands", 27, site_language.Id , "MyBands page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Языки", "gvBands", 27, site_language.Id , "MyBands page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Лидер", "gvBands", 27, site_language.Id , "MyBands page", 1, 4 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Создать", "btnCreate", 27, site_language.Id , "MyBands page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Покинуть", "btnLeave", 27, site_language.Id , "MyBands page" from site_language where LangCode = "ru";
