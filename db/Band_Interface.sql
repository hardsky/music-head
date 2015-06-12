SET NAMES 'utf8';
/*Bands page; Code = 9*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band Name:", "lbNameTitle", 9, site_language.Id , "Band page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Description:", "lbDescrTitle", 9, site_language.Id , "Band page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Members:", "lbLabelMembers", 9, site_language.Id , "Band page" from site_language where LangCode = "en";
/*gvMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvMembers", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvMembers", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Music:", "lbLabelMusic", 9, site_language.Id , "Band page" from site_language where LangCode = "en";
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvMusic", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvMusic", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvMusic", 9, site_language.Id , "Band page", 1, 2 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Lyrics:", "lbLabelLyrics", 9, site_language.Id , "Band page" from site_language where LangCode = "en";
/*gvLyrics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvLyrics", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvLyrics", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvLyrics", 9, site_language.Id , "Band page", 1, 2 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Video:", "lbLabelVideo", 9, site_language.Id , "Band page" from site_language where LangCode = "en";

/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Info", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#info" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Music", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#music" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Lyrics", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#lyrics" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Video", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#video" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название группы:", "lbNameTitle", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Описание:", "lbDescrTitle", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Состав:", "lbLabelMembers", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";
/*gvMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Имя", "gvMembers", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Коментарий", "gvMembers", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыка:", "lbLabelMusic", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";
/*gvMusic*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvMusic", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvMusic", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvMusic", 9, site_language.Id , "Band page", 1, 2 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стихи:", "lbLabelLyrics", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";
/*gvLyrics*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvLyrics", 9, site_language.Id , "Band page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvLyrics", 9, site_language.Id , "Band page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Создано", "gvLyrics", 9, site_language.Id , "Band page", 1, 2 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Видео:", "lbLabelVideo", 9, site_language.Id , "Band page" from site_language where LangCode = "ru";

/*Menu*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Информация", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#info" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Музыка", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#music" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Стихи", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#lyrics" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx, IsMenu, Url) 
select "Видео", "ctrBandMenu", 9, site_language.Id , "Band page", 0, 0, 1, "~/#video" from site_language where LangCode = "ru";

