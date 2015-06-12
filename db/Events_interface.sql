SET NAMES 'utf8';
/*Events page; Code = 57*/
/*English*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 57, site_language.Id , "Events page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 57, site_language.Id , "Events page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 57, site_language.Id , "Events page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 57, site_language.Id , "Events page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Date", "gvEvents", 57, site_language.Id , "Events page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Event", "gvEvents", 57, site_language.Id , "Events page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Country", "gvEvents", 57, site_language.Id , "Events page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "City", "gvEvents", 57, site_language.Id , "Events page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvEvents", 57, site_language.Id , "Events page", 1, 4 from site_language where LangCode = "en";

/*русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 57, site_language.Id , "Events page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 57, site_language.Id , "Events page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 57, site_language.Id , "Events page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 57, site_language.Id , "Events page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Дата", "gvEvents", 57, site_language.Id , "Events page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Концерт", "gvEvents", 57, site_language.Id , "Events page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Страна", "gvEvents", 57, site_language.Id , "Events page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Город", "gvEvents", 57, site_language.Id , "Events page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvEvents", 57, site_language.Id , "Events page", 1, 4 from site_language where LangCode = "ru";
