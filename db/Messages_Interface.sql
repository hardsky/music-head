SET NAMES 'utf8';
/*Messages page; Code = 30*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Create Message", "btnCreate", 30, site_language.Id , "Messages page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Создать сообщение", "btnCreate", 30, site_language.Id , "Messages page" from site_language where LangCode = "ru";
