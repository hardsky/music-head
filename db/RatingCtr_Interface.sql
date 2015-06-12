SET NAMES 'utf8';
/*Rating control; Code = 36*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Rating:", "lbRating", 36, site_language.Id , "Rating control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Рейтинг:", "lbRating", 36, site_language.Id , "Rating control" from site_language where LangCode = "ru";
