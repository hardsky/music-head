SET NAMES 'utf8';
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Music" as Subj from site_language where site_language.LangCode="en";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Lyrics" as Subj from site_language where site_language.LangCode="en";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Video" as Subj from site_language where site_language.LangCode="en";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "General Discussion" as Subj from site_language where site_language.LangCode="en";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "About Site" as Subj from site_language where site_language.LangCode="en";

insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Музыка" as Subj from site_language where site_language.LangCode="ru";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Лирика" as Subj from site_language where site_language.LangCode="ru";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Видео" as Subj from site_language where site_language.LangCode="ru";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "Общий" as Subj from site_language where site_language.LangCode="ru";
insert into forum_main (LangId, Subj) 
select site_language.id as LangId, "О сайте" as Subj from site_language where site_language.LangCode="ru";
