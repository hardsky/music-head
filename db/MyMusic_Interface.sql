SET NAMES 'utf8';
/*MyMusic page; Code = 20*/
/*English*/
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Description", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 5 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 20, site_language.Id , "MyMysic page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 20, site_language.Id , "MyMysic page" from site_language where LangCode = "en";

/*Русский*/
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Описание", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvMusic", 20, site_language.Id , "MyMusic page", 1, 5 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 20, site_language.Id , "MyMysic page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 20, site_language.Id , "MyMysic page" from site_language where LangCode = "ru";
