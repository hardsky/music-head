SET NAMES 'utf8';
/*News page; Code = 48*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Site News", "hLabelSiteNews", 48, site_language.Id , "News page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Новости сайта", "hLabelSiteNews", 48, site_language.Id , "News page" from site_language where LangCode = "ru";
