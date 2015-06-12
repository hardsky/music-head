SET NAMES 'utf8';
/*LFP control; Code = 40*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "There are signs from bands, that they are looking for people.", "lbPageNotice", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Looking For:", "lbLabelLooking", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 40, site_language.Id , "LFP control" from site_language where LangCode = "en";
/*gvSearchMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Band", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Looking For...", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Country", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "City", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 5 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 6 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Здесь сообщения от групп, которые ищут музыкантов", "lbPageNotice", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Ищут:", "lbLabelLooking", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 40, site_language.Id , "LFP control" from site_language where LangCode = "ru";
/*gvSearchMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Группа", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Ищет", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Комментарий", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Страна", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Город", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 5 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvSearchMembers", 40, site_language.Id , "LFP control", 1, 6 from site_language where LangCode = "ru";
