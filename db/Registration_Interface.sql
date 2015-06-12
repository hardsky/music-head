SET NAMES 'utf8';
/*Registration page; Code = 37*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "E-mail:", "lbLabelEmail", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Password:", "lbLabelPsw", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Retype Password:", "lbLabelRePsw", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Site Name:", "lbLabelName", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Enter the code shown above:", "lbLabelCaptcha", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Refresh", "btnRefresh", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Note: If you cannot read the numbers in the above<br/>image, click \"Refresh\" button to generate a new one.)</em>", "lbLabelCaptchaNotice", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Register!", "btnRegister", 37, site_language.Id , "Registration page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "E-mail:", "lbLabelEmail", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Пароль:", "lbLabelPsw", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Повторите пароль:", "lbLabelRePsw", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Имя на сайте:", "lbLabelName", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Введите код указанный выше:", "lbLabelCaptcha", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Обновить", "btnRefresh", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Примечание: Если вы не можете прочесть символы на картинке,<br/> нажмите кнопку \"Обновить\", чтобы сгенерить новый код.)</em>", "lbLabelCaptchaNotice", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnRegister", 37, site_language.Id , "Registration page" from site_language where LangCode = "ru";
