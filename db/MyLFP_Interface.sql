SET NAMES 'utf8';
/*MyLFP page; Code = 50*/
/*English*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "You have a band(s) and you are looking for people, which want to join.", "lbPageNotice", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
/*repeater*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band", "lbHeaderBand", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Looking for..", "lbHeaderLooking", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comment", "lbHeaderComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Select a band.", "lbLabelSelectComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCoutry", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Looking for:", "lbLabelLooking", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Comment:", "lbLabelComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel:", "btnCancel", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "en";

/*Русский*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "У вас есть группа и вы ищете людей, которые захотят присоединиться.", "lbPageNotice", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
/*repeater*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа", "lbHeaderBand", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Ищу", "lbHeaderLooking", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарий", "lbHeaderComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Выберите группу.", "lbLabelSelectComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCoutry", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Ищу:", "lbLabelLooking", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Комментарий:", "lbLabelComment", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить:", "btnCancel", 50, site_language.Id , "MyLFP page" from site_language where LangCode = "ru";
