SET NAMES 'utf8';
/*Art page; Code = 6*/
/*English*/

/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Lyrics", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLyrics.aspx", 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Music", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyMusic.aspx", 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Video", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyVideo.aspx", 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Groups", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyBands.aspx", 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Invitations", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyInvites.aspx", 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Messages", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/Messages.aspx", 5 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Looking for People", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLFP.aspx", 6 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Looking for Group", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLFB.aspx", 7 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My Events", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyRaider.aspx", 8 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "My News", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyNews.aspx", 9 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder, IsForAdmin) 
select "Site News", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/WriteSiteNews.aspx", 10, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Settings", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyArt.aspx", 11 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Ways in Art:", "lbLabelWays", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Info:", "lbLabelInfo", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Musical Instruments:", "lbLabelInstrs", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Styles:", "lbLabelStyles", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Languages:", "lbLabelLanguages", 6, site_language.Id , "Art page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Lyrics:", "lbLabelLyrics", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Music:", "lbLabelMusic", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Video:", "lbLabelVideo", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Bands:", "lbLabelBands", 6, site_language.Id , "Art page" from site_language where LangCode = "en";

/*rpLyrics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title", "lbLabelLyricsTitle", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band", "lbLabelLyricsBand", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style", "lbLabelLyricsStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language", "lbLabelLyricsLang", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
/*rpMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title", "lbLabelMusicTitle", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band", "lbLabelMusicBand", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style", "lbLabelMusicStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language", "lbLabelMusicLang", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
/*rpBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Name", "lbLabelBandName", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style", "lbLabelBandStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language", "lbLabelBandLang", 6, site_language.Id , "Art page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Leader", "lbLabelBandLeader", 6, site_language.Id , "Art page" from site_language where LangCode = "en";

/*Русский*/
/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои стихи", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLyrics.aspx", 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Моя музыка", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyMusic.aspx", 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои видео", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyVideo.aspx", 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои группы", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyBands.aspx", 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Приглашения", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyInvites.aspx", 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Сообщения", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/Messages.aspx", 5 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Поиск людей", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLFP.aspx", 6 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Поиск групп", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyLFB.aspx", 7 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои концерты", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyRaider.aspx", 8 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Мои новости", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyNews.aspx", 9 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder, IsForAdmin) 
select "Новости сайта", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/WriteSiteNews.aspx", 10, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url, MenuOrder) 
select "Настройки", "ctrMyMenu", 6, site_language.Id , "Art page", 0, 0, 1, "~/MyArt.aspx", 11 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Пути в искусстве:", "lbLabelWays", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Инфа:", "lbLabelInfo", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыкальные инструменты:", "lbLabelInstrs", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стили:", "lbLabelStyles", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Языки:", "lbLabelLanguages", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стихи:", "lbLabelLyrics", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыка:", "lbLabelMusic", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видео:", "lbLabelVideo", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группы:", "lbLabelBands", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";

/*rpLyrics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название", "lbLabelLyricsTitle", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа", "lbLabelLyricsBand", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль", "lbLabelLyricsStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык", "lbLabelLyricsLang", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
/*rpMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название", "lbLabelMusicTitle", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа", "lbLabelMusicBand", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль", "lbLabelMusicStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык", "lbLabelMusicLang", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
/*rpBands*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название", "lbLabelBandName", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль", "lbLabelBandStyle", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык", "lbLabelBandLang", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Лидер", "lbLabelBandLeader", 6, site_language.Id , "Art page" from site_language where LangCode = "ru";
