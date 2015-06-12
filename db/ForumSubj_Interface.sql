SET NAMES 'utf8';
/*ForumSubj page; Code = 16*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Forums", "hlForums", 16, site_language.Id , "ForumSubj page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Answer", "btnAnswer", 16, site_language.Id , "ForumSubj page" from site_language where LangCode = "en";
/*gvSubj*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Author", "gvSubj", 16, site_language.Id , "ForumSubj page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Message", "gvSubj", 16, site_language.Id , "ForumSubj page", 1, 1 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Форумы", "hlForums", 16, site_language.Id , "ForumSubj page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Ответить", "btnAnswer", 16, site_language.Id , "ForumSubj page" from site_language where LangCode = "ru";
/*gvSubj*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Автор", "gvSubj", 16, site_language.Id , "ForumSubj page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Сообщение", "gvSubj", 16, site_language.Id , "ForumSubj page", 1, 1 from site_language where LangCode = "ru";
