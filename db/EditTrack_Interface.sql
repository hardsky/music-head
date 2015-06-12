SET NAMES 'utf8';
/*EditTrack page; Code = 24*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "File:", "lbLabelFile", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Change", "btnChangeFile", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnUplCancel", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Description:", "lbLabelDescr", 24, site_language.Id , "Clip page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Visibility:", "lbLabelVisib", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "bntCancel", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Файл:", "lbLabelFile", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Изменить", "btnChangeFile", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "btnUplCancel", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Описание:", "lbLabelDescr", 24, site_language.Id , "Clip page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видимость:", "lbLabelVisib", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "bntCancel", 24, site_language.Id , "EditTrack page" from site_language where LangCode = "ru";
