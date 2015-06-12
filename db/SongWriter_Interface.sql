SET NAMES 'utf8';
/*SongWriter page; Code = 19*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Visibility:", "lbLabelVisib", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "SaveButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Clear", "ClearButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "CancelButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "lbLabelPrev", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "PreviewButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видимость:", "lbLabelVisib", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "SaveButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Очистить", "ClearButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "CancelButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Предпросмотр", "lbLabelPrev", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Посмотреть", "PreviewButton", 19, site_language.Id , "SongWriter page" from site_language where LangCode = "ru";
