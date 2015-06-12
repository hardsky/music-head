SET NAMES 'utf8';
/*MyLFB page; Code = 51*/
/*English*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Entries on this page indicate, that you want to join a band(s).", "lbPageNotice", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";
/*repeater*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Role in Band", "lbHeaderLooking", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comment", "lbHeaderComment", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "en";

/*Русский*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Оставляя здесь запись вы подаете знак, что хотите присоединиться к группе.", "lbPageNotice", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
/*repeater*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Роль в группе", "lbHeaderLooking", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарий", "lbHeaderComment", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "btnCancel", 51, site_language.Id , "MyLFB page" from site_language where LangCode = "ru";
