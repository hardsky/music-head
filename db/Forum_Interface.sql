SET NAMES 'utf8';
/*Forum page; Code = 14*/
/*English*/
/*gvForum*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Forums", "gvForum", 14, site_language.Id , "Forum page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Subjects", "gvForum", 14, site_language.Id , "Forum page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Messages", "gvForum", 14, site_language.Id , "Forum page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Last Message", "gvForum", 14, site_language.Id , "Forum page", 1, 3 from site_language where LangCode = "en";

/*Русский*/
/*gvForum*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Форумы", "gvForum", 14, site_language.Id , "Forum page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Темы", "gvForum", 14, site_language.Id , "Forum page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Сообщения", "gvForum", 14, site_language.Id , "Forum page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Последнее сообщение", "gvForum", 14, site_language.Id , "Forum page", 1, 3 from site_language where LangCode = "ru";
