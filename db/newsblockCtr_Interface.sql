SET NAMES 'utf8';
/*NewsBlock control; Code = 47*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "more...", "lnkGo", 47, site_language.Id , "NewsBlock control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "далее...", "lnkGo", 42, site_language.Id , "NewsBlock control" from site_language where LangCode = "ru";
