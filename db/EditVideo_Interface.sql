SET NAMES 'utf8';
/*EditVideo page; Code = 26*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "File:", "lbLabelFile", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Change", "btnChangeFile", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnUplCancel", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Description:", "lbLabelDescr", 26, site_language.Id , "Clip page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Visibility:", "lbLabelVisib", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "bntCancel", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Файл:", "lbLabelFile", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Изменить", "btnChangeFile", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "btnUplCancel", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Описание:", "lbLabelDescr", 26, site_language.Id , "Clip page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видимость:", "lbLabelVisib", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "bntCancel", 26, site_language.Id , "EditVideo page" from site_language where LangCode = "ru";
