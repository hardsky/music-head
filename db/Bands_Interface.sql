SET NAMES 'utf8';
/*Bands page; Code = 8*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Name:", "lbLabelName", 8, site_language.Id , "Bands page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "You can specify 'part' of name. For an example, 'Very*' for search 'Very Cool Band'.", "lbLabelNameNotice", 8, site_language.Id , "Bands page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 8, site_language.Id , "Bands page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 8, site_language.Id , "Bands page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 8, site_language.Id , "Bands page" from site_language where LangCode = "en";
/*gvBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvBands", 8, site_language.Id , "Bands page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvBands", 8, site_language.Id , "Bands page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Languages", "gvBands", 8, site_language.Id , "Bands page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Leader", "gvBands", 8, site_language.Id , "Bands page", 1, 3 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelName", 8, site_language.Id , "Bands page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Вы можете задать часть названия. К примеру 'Очень*', чтобы найти группу с названием 'Очень крутая группа'.", "lbLabelNameNotice", 8, site_language.Id , "Bands page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 8, site_language.Id , "Bands page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 8, site_language.Id , "Bands page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 8, site_language.Id , "Bands page" from site_language where LangCode = "ru";
/*gvBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvBands", 8, site_language.Id , "Bands page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvBands", 8, site_language.Id , "Bands page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Языки", "gvBands", 8, site_language.Id , "Bands page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Лидер", "gvBands", 8, site_language.Id , "Bands page", 1, 3 from site_language where LangCode = "ru";
