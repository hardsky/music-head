SET NAMES 'utf8';
/*Finder control; Code = 10*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Title:", "lbLabelTitle", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*You can specify 'part' of title. For an example, 'Very*' for search 'Very Cool Title'.", "lbLabelTitleNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Author:", "lbLabelAuthor", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Can specify 'part' of name.", "lbLabelAuthorNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Can specify 'part' of name.", "lbLabelBandNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Style:", "lbLabelStyle", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 10, site_language.Id , "Finder control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbLabelTitle", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Можно указать часть названия. К примеру, 'Очень*', чтобы найти 'Очень классное название'.", "lbLabelTitleNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Автор:", "lbLabelAuthor", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Можно указать часть имени.", "lbLabelAuthorNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "*Можно указать часть названия.", "lbLabelBandNote", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Стиль:", "lbLabelStyle", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 10, site_language.Id , "Finder control" from site_language where LangCode = "ru";
