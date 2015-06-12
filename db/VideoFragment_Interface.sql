SET NAMES 'utf8';
/*Finder control; Code = 13*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Author:", "lbLabelAuthor", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "More...", "hlMore", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Автор:", "lbLabelAuthor", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Подробнее...", "hlMore", 13, site_language.Id , "VideoFragment control" from site_language where LangCode = "ru";
