SET NAMES 'utf8';
/*MyRaider page; Code = 53*/
/*English*/
/*gvAfisha*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Date", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Title", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Description", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Who", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 4 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Date:", "lbLabelDate", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "DD.MM.YY", "lbDate", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Hour:", "lbLabelH", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Minute:", "lbLabelMin", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Event:", "lbLabelEvent", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Description:", "lbLabelDescr", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbCountry", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbCity", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Who:", "lbLabelWho", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "en";

/*Русский*/
/*gvAfisha*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Дата", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Название", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Описание", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Кто", "gvAfisha", 53, site_language.Id, "MyRaider page", 1, 4 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAdd", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Дата:", "lbLabelDate", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "ДД.MM.ГГ", "lbDate", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Часы:", "lbLabelH", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Минуты:", "lbLabelMin", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Событие:", "lbLabelEvent", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Описание:", "lbLabelDescr", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbCountry", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbCity", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Кто:", "lbLabelWho", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "btnCancel", 53, site_language.Id, "MyRaider page" from site_language where LangCode = "ru";
