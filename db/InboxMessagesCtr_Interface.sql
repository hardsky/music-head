SET NAMES 'utf8';
/*InboxMessages control; Code = 32*/
/*English*/
/*gvInbox*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Subject", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "From", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Received", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 3 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Subject:", "lbLabelSubj", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "From:", "lbLabelFrom", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Received:", "lbLabelRec", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "en";

/*Русский*/
/*gvInbox*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Тема", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "От кого", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Получено", "gvInbox", 32, site_language.Id , "InboxMessages control", 1, 3 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Тема:", "lbLabelSubj", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "От кого:", "lbLabelFrom", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Получено:", "lbLabelRec", 32, site_language.Id , "InboxMessages control" from site_language where LangCode = "ru";
