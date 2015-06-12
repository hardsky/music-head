SET NAMES 'utf8';
/*MyLFBDetails control; Code = 52*/
/*English*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "[not defined on user page]", "lbLang", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCoutry", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Role in Band:", "lbLabelLooking", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comment:", "lbLabelComment", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "en";

/*Русский*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "[не определено на странице пользователя]", "lbLang", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCoutry", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Роль в группе:", "lbLabelLooking", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарий:", "lbLabelComment", 52, site_language.Id, "MyLFBDetails control" from site_language where LangCode = "ru";
