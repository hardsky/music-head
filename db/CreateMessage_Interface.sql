SET NAMES 'utf8';
/*CreateMessage page; Code = 34*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "To:", "lbLabelTo", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Subject:", "lbLabelSubj", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Send", "btnSend", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Preview", "btnPreview", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Enter the code shown above:", "lbLabelCaptcha", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Refresh", "btnRefresh", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Note: If you cannot read the numbers in the above<br/>image, click \"Refresh\" button to generate a new one.)</em>", "lbLabelCaptchaNotice", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Кому:", "lbLabelTo", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Тема:", "lbLabelSubj", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отправить", "btnSend", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отменить", "btnCancel", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Предпросмотр", "btnPreview", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Введите код указанный выше:", "lbLabelCaptcha", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Обновить", "btnRefresh", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Примечание: Если вы не можете прочесть символы на картинке,<br/> нажмите кнопку \"Обновить\", чтобы сгенерить новый код.)</em>", "lbLabelCaptchaNotice", 34, site_language.Id , "CreateMessage page" from site_language where LangCode = "ru";
