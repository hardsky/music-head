SET NAMES 'utf8';
/*SubForum page; Code = 15*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Forums", "hlForums", 15, site_language.Id , "SubForum page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Create", "btnCreate", 15, site_language.Id , "SubForum page" from site_language where LangCode = "en";
/*gvForum*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Subjects", "gvForum", 15, site_language.Id , "SubForum page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvForum", 15, site_language.Id , "SubForum page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Messages", "gvForum", 15, site_language.Id , "SubForum page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Last Message", "gvForum", 15, site_language.Id , "SubForum page", 1, 3 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Форумы", "hlForums", 15, site_language.Id , "SubForum page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Создать", "btnCreate", 15, site_language.Id , "SubForum page" from site_language where LangCode = "ru";
/*gvForum*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Темы", "gvForum", 15, site_language.Id , "SubForum page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvForum", 15, site_language.Id , "SubForum page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Сообщения", "gvForum", 15, site_language.Id , "SubForum page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Последнее сообщение", "gvForum", 15, site_language.Id , "SubForum page", 1, 3 from site_language where LangCode = "ru";
