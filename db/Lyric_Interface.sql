SET NAMES 'utf8';
/*Lyric page; Code = 21*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Author:", "lbLabelAuthor", 21, site_language.Id , "Lyric page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Автор:", "lbLabelAuthor", 21, site_language.Id , "Lyric page" from site_language where LangCode = "ru";
