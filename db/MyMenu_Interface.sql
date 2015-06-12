SET NAMES 'utf8';
/*MyMenuControl; Code = 5*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My Lyrics", "hlLyrics", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My Music", "hlMusic", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My Video", "hlVideo", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My Bands", "hlBands", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My Invites", "hlInvites", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Messages", "hlMessages", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Settings", "hlSettings", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Logout", "btnLogOut", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My LFP", "hlLFP", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My LFB", "hlLFB", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Мои стихи", "hlLyrics", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Моя музыка", "hlMusic", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Мои видео", "hlVideo", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Мои группы", "hlBands", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Приглашения", "hlInvites", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сообщения", "hlMessages", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Настройки", "hlSettings", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Выйти", "btnLogOut", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Мой ПЛ", "hlLFP", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Мой ПГ", "hlLFB", 5, site_language.Id , "Control MyMenu" from site_language where LangCode = "ru";
