SET NAMES 'utf8';
/*ForumMessage page; Code = 17*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Subject:", "lbLabelSubj", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAdd", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "btnPreview", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Enter the code shown above:", "lbLabelCaptcha", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Refresh", "btnRefresh", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Note: If you cannot read the numbers in the above<br/>image, click \"Refresh\" button to generate a new one.)</em>", "lbLabelCaptchaNotice", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Тема:", "lbLabelSubj", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отправить", "btnAdd", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "btnCancel", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Предпросмотр", "btnPreview", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Введите код указанный выше:", "lbLabelCaptcha", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Обновить", "btnRefresh", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Примечание: Если вы не можете прочесть символы на картинке,<br/> нажмите кнопку \"Обновить\", чтобы сгенерить новый код.)</em>", "lbLabelCaptchaNotice", 17, site_language.Id , "ForumMessage page" from site_language where LangCode = "ru";
