SET NAMES 'utf8';
/*Folks page; Code = 7*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Name:", "lbLabelName", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Way in Art:", "lbLabelWays", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Done something", "cbWorksExist", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Musical Instrument:", "lbLabelInstr", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Music Style:", "lbLabelStyle", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band:", "lbLabelBand", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Not in Band", "cbNotInBand", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLang", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 7, site_language.Id , "Folks page" from site_language where LangCode = "en";
/*gvArtists*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvArtists", 7, site_language.Id , "Folks page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Way", "gvArtists", 7, site_language.Id , "Folks page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Style", "gvArtists", 7, site_language.Id , "Folks page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Instruments", "gvArtists", 7, site_language.Id , "Folks page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Languages", "gvArtists", 7, site_language.Id , "Folks page", 1, 4 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Имя:", "lbLabelName", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Путь в искусстве:", "lbLabelWays", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Выложены работы", "cbWorksExist", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыкальный инструмент:", "lbLabelInstr", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Музыкальный стиль:", "lbLabelStyle", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группа:", "lbLabelBand", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Не в группе", "cbNotInBand", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLang", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Найти!", "btnFind", 7, site_language.Id , "Folks page" from site_language where LangCode = "ru";
/*gvArtists*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Имя", "gvArtists", 7, site_language.Id , "Folks page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Путь", "gvArtists", 7, site_language.Id , "Folks page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Стиль", "gvArtists", 7, site_language.Id , "Folks page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Инструмент", "gvArtists", 7, site_language.Id , "Folks page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Языки", "gvArtists", 7, site_language.Id , "Folks page", 1, 4 from site_language where LangCode = "ru";
