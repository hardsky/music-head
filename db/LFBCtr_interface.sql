SET NAMES 'utf8';
/*LFB control; Code = 41*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "There are signs from people, who are looking for band.", "lbPageNotice", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Role in Band:", "lbLabelRole", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 41, site_language.Id , "LFB control" from site_language where LangCode = "en";
/*gvSearchBand*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Artist", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Role in Band", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Country", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 5 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "City", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 6 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 7 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Здесь сообщения от музыкантов, которые ищут группу", "lbPageNotice", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Роль в группе:", "lbLabelRole", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 41, site_language.Id , "LFB control" from site_language where LangCode = "ru";
/*gvSearchBand*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Музыкант", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Роль", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Комментарий", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Страна", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 5 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Город", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 6 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvSearchBand", 41, site_language.Id , "LFB control", 1, 7 from site_language where LangCode = "ru";
