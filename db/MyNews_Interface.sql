SET NAMES 'utf8';
/*MyNews page; Code = 54*/
/*English*/
/*gvNews*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Date", "gvNews", 54, site_language.Id , "MyNews page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "News", "gvNews", 54, site_language.Id , "MyNews page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Who", "gvNews", 54, site_language.Id , "MyNews page", 1, 3 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Text:", "lbLabelText", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Who:", "lbLabelWho", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 54, site_language.Id, "MyNews page" from site_language where LangCode = "en";

/*Русский*/
/*gvNews*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Дата", "gvNews", 54, site_language.Id , "MyNews page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Новости", "gvNews", 54, site_language.Id , "MyNews page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Кто", "gvNews", 54, site_language.Id , "MyNews page", 1, 3 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Текст:", "lbLabelText", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Кто:", "lbLabelWho", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "btnCancel", 54, site_language.Id, "MyNews page" from site_language where LangCode = "ru";
