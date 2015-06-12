SET NAMES 'utf8';
/*Finder control; Code = 12*/
/*English*/
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvMusic", 12, site_language.Id , "Music page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvMusic", 12, site_language.Id , "Music page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Band", "gvMusic", 12, site_language.Id , "Music page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvMusic", 12, site_language.Id , "Music page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvMusic", 12, site_language.Id , "Music page", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvMusic", 12, site_language.Id , "Music page", 1, 5 from site_language where LangCode = "en";

/*Русский*/
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvMusic", 12, site_language.Id , "Music page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvMusic", 12, site_language.Id , "Music page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Группа", "gvMusic", 12, site_language.Id , "Music page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvMusic", 12, site_language.Id , "Music page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvMusic", 12, site_language.Id , "Music page", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvMusic", 12, site_language.Id , "Music page", 1, 5 from site_language where LangCode = "ru";
