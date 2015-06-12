SET NAMES 'utf8';
/*UserLogin control; Code = 3*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Password Recovery", "hlForgotPsw", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Registration", "hlReg", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Login", "lbLabelLogin", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Authorization", "lbLabelAuth", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Remember Me", "RememberMe", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Забыли пароль?", "hlForgotPsw", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Регистрация", "hlReg", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Войти", "lbLabelLogin", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Авторизация", "lbLabelAuth", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Запомнить меня", "RememberMe", 3, site_language.Id , "Control UserLogin" from site_language where LangCode = "ru";
