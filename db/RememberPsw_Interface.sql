SET NAMES 'utf8';
/*Remember PSW page; Code = 58*/
/*English*/

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "* Email error", "lblEmailErr", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "New Password:", "lbLabelPsw", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Repeat New Password:", "lbLabelPswRepeat", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "* Error, when repeat password", "lblErrNotice", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Send!", "btnSend", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "en";

/*русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "* Ошибка в email", "lblEmailErr", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Новый пароль:", "lbLabelPsw", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Подтвердить пароль:", "lbLabelPswRepeat", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "* Ошибка при повторе пароля", "lblErrNotice", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отправить!", "btnSend", 58, site_language.Id , "RememberPsw page" from site_language where LangCode = "ru";
