SET NAMES 'utf8';
/*WriteSiteNews page; Code = 55*/
/*English*/
/*gvNews*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Date", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "News", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 3 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Site Language:", "lbLabelLang", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "SaveButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Clear", "ClearButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "CancelButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "lbLabelPrev", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "PreviewButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "en";

/*Русский*/
/*gvNews*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Дата", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Новости", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvNews", 55, site_language.Id , "WriteSiteNews page", 1, 3 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык сайта:", "lbLabelLang", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "SaveButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Очистить", "ClearButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "CancelButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Предпросмотр", "lbLabelPrev", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Предпросмотр", "PreviewButton", 55, site_language.Id, "WriteSiteNews page" from site_language where LangCode = "ru";
