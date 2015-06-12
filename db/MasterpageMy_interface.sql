SET NAMES 'utf8';
/*MasterPageMy page; Code = 49*/
/*English*/

/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Lyrics", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLyrics.aspx", 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Music", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyMusic.aspx", 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Video", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyVideo.aspx", 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Groups", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyBands.aspx", 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Invitations", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyInvites.aspx", 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Messages", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/Messages.aspx", 5 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Looking for People", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLFP.aspx", 6 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Looking for Group", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLFB.aspx", 7 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Events", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyRaider.aspx", 8 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My News", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyNews.aspx", 9 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder, IsForAdmin) 
select "Site News", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/WriteSiteNews.aspx", 10, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Settings", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyArt.aspx", 11 from site_language where LangCode = "en";

/*Русский*/

/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои стихи", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLyrics.aspx", 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Моя музыка", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyMusic.aspx", 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои видео", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyVideo.aspx", 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои группы", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyBands.aspx", 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Приглашения", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyInvites.aspx", 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Сообщения", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/Messages.aspx", 5 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Поиск людей", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLFP.aspx", 6 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Поиск групп", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyLFB.aspx", 7 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои концерты", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyRaider.aspx", 8 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои новости", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyNews.aspx", 9 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder, IsForAdmin) 
select "Новости сайта", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/WriteSiteNews.aspx", 10, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Настройки", "ctrMyMenu", 49, site_language.Id , "MasterPageMy", 0, 0, 1, "~/MyArt.aspx", 11 from site_language where LangCode = "ru";
