SET NAMES 'utf8';
/*MainMenuControl; Code = 1*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Home", "hlHome", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Folks", "hlArtists", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Bands", "hlGroups", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Lyrics", "hlLyrics", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Music", "hlMusic", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Video", "hlVideo", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Forum", "hlForum", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "About", "hlAbout", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Search", "hlLFG", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Начало", "hlHome", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Народ", "hlArtists", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группы", "hlGroups", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стихи", "hlLyrics", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыка", "hlMusic", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видео", "hlVideo", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Форум", "hlForum", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "О сайте", "hlAbout", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Поиск", "hlLFG", 1, site_language.Id , "Control MainMenu" from site_language where LangCode = "ru";
