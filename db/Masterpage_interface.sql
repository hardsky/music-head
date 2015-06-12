SET NAMES 'utf8';
/*MasterPage; Code = 45*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Registration", "hlReg", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Authorization", "hlAvt", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "My page", "hlMyPage", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "[Logout]", "lnkbLogout", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Bands <small>▼</small>", "lbLabelMasterBands", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Search", "tbMasterSearch", 45, site_language.Id , "MasterPage" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Регистрация", "hlReg", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Авторизация", "hlAvt", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Личная страничка", "hlMyPage", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "[Выйти]", "lnkbLogout", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Группы <small>▼</small>", "lbLabelMasterBands", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Поиск", "tbMasterSearch", 45, site_language.Id , "MasterPage" from site_language where LangCode = "ru";
