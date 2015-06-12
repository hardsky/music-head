SET NAMES 'utf8';
/*Finder control; Code = 11*/
/*English*/
/*gvLirics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvLirics", 11, site_language.Id , "Lirics page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvLirics", 11, site_language.Id , "Lirics page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvLirics", 11, site_language.Id , "Lirics page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvLirics", 11, site_language.Id , "Lirics page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvLirics", 11, site_language.Id , "Lirics page", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Updated", "gvLirics", 11, site_language.Id , "Lirics page", 1, 5 from site_language where LangCode = "en";

/*Русский*/
/*gvLirics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvLirics", 11, site_language.Id , "Lirics page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvLirics", 11, site_language.Id , "Lirics page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvLirics", 11, site_language.Id , "Lirics page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvLirics", 11, site_language.Id , "Lirics page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvLirics", 11, site_language.Id , "Lirics page", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Обновлено", "gvLirics", 11, site_language.Id , "Lirics page", 1, 5 from site_language where LangCode = "ru";
