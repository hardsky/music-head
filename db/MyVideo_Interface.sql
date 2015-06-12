SET NAMES 'utf8';
/*MyVideo page; Code = 25*/
/*English*/
/*gvVideo*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Description", "gvVideo", 25, site_language.Id , "MyVideo page", 1, 2 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 25, site_language.Id , "MyVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 25, site_language.Id , "MyVideo page" from site_language where LangCode = "en";

/*Русский*/
/*gvVideo*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Описание", "gvVideo", 25, site_language.Id , "MyVideo page", 1, 2 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 25, site_language.Id , "MyVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 25, site_language.Id , "MyVideo page" from site_language where LangCode = "ru";
