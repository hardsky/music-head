SET NAMES 'utf8';
/*OutboxMessages control; Code = 31*/
/*English*/
/*gvOutbox*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Subject", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "To", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Sent", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 3 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Subject:", "lbLabelSubj", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "To:", "lbLabelTo", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Sent:", "lbLabelSent", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "en";

/*Русский*/
/*gvOutbox*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Тема", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Кому", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Отправлено", "gvOutbox", 31, site_language.Id , "OutboxMessages control", 1, 3 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Тема:", "lbLabelSubj", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Кому:", "lbLabelTo", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отправлено:", "lbLabelSent", 31, site_language.Id , "OutboxMessages control" from site_language where LangCode = "ru";
