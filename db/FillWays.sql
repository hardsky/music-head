SET NAMES 'utf8';

/*table ways*/
insert into ways (Description) values ('Critic');
insert into ways (Description) values ('Lyrics');
insert into ways (Description) values ('Music');
insert into ways (Description) values ('Video');

/*table waylocal*/
/*English*/
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Critic' as Text from ways, site_language where ways.Description = 'Critic' and site_language.LangCode="en");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Lyrics' as Text from ways, site_language where ways.Description = 'Lyrics' and site_language.LangCode="en");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Music' as Text from ways, site_language where ways.Description = 'Music' and site_language.LangCode="en");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Video' as Text from ways, site_language where ways.Description = 'Video' and site_language.LangCode="en");

/*Русский*/
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Критик' as Text from ways, site_language where ways.Description = 'Critic' and site_language.LangCode="ru");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Стихи' as Text from ways, site_language where ways.Description = 'Lyrics' and site_language.LangCode="ru");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Музыка' as Text from ways, site_language where ways.Description = 'Music' and site_language.LangCode="ru");
insert into waylocal (WayId, LangId, LangCode, Text) 
(select ways.Id as WayId, site_language.Id as LangId, site_language.LangCode, 'Видео' as Text from ways, site_language where ways.Description = 'Video' and site_language.LangCode="ru");
