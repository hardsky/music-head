SET NAMES 'utf8';
/*ChartLyrics control; Code = 46*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Rating:", "lbLabelRating", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "To page", "hlToPage", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comments", "hlComments", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Рейтинг:", "lbLabelRating", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "На страницу", "hlToPage", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарии", "hlComments", 46, site_language.Id , "ChartLyrics control" from site_language where LangCode = "ru";
