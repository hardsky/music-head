SET NAMES 'utf8';
/*MyLyrics page; Code = 18*/
/*English*/
/*gvLirics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Updated", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 3 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 18, site_language.Id , "MyLyrics page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 18, site_language.Id , "MyLyrics page" from site_language where LangCode = "en";

/*Русский*/
/*gvLirics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Обновлено", "gvLirics", 18, site_language.Id , "MyLyrics page", 1, 3 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 18, site_language.Id , "MyLyrics page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 18, site_language.Id , "MyLyrics page" from site_language where LangCode = "ru";
