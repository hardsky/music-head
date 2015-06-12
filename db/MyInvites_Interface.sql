SET NAMES 'utf8';
/*MyInvites page; Code = 29*/
/*English*/
/*gvInvites*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Band", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Inviter", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Message", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Invited", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 4 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Accept", "btnAccept", 29, site_language.Id , "MyInvites page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 29, site_language.Id , "MyInvites page" from site_language where LangCode = "en";

/*Русский*/
/*gvInvites*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Группа", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Пригласивший", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Сообщение", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Дата", "gvInvites", 29, site_language.Id , "MyInvites page", 1, 4 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Принять", "btnAccept", 29, site_language.Id , "MyInvites page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 29, site_language.Id , "MyInvites page" from site_language where LangCode = "ru";
