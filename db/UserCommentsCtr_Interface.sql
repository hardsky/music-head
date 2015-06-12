SET NAMES 'utf8';
/*UserComments control; Code = 35*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comments:", "lbCommentLabel", 35, site_language.Id , "UserComments control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAddComment", 35, site_language.Id , "UserComments control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарии:", "lbCommentLabel", 35, site_language.Id , "UserComments control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAddComment", 35, site_language.Id , "UserComments control" from site_language where LangCode = "ru";
