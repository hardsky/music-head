SET NAMES 'utf8';
/*MyBand page; Code = 28*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Band Name:", "lbNameTitle", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Description:", "lbDescrTitle", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Save", "btnSave", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnCancel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Members:", "lbMembersLabel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";

/*gvMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvMembers", 28, site_language.Id , "MyBand page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvMembers", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Invited:", "lbInvLabel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";

/*gvInvited*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Name", "gvInvited", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Message", "gvInvited", 28, site_language.Id , "MyBand page", 1, 2 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAddMember", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnRemoveInvite", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Name:", "lbLabelName", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Message:", "lbLabelMsg", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<strong>Enter the code shown above:</strong><br/>", "lbLabelCaptcha", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Refresh", "btnRefresh", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Note: If you cannot read the numbers in the above<br/>
image, click \"refresh\" button to generate a new one.)</em>", "lbLabelCaptchaNotice", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Invite", "btnInvite", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Cancel", "btnInvCancel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Languages:", "lbLabelLanguages", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";

/*gvLangs*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvLangs", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "en";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "New Language:", "lbLabelNewLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Add", "btnAddLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDeleteLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Название:", "lbNameTitle", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Описание:", "lbDescrTitle", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сохранить", "btnSave", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "btnCancel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Состав:", "lbMembersLabel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";

/*gvMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Имя", "gvMembers", 28, site_language.Id , "MyBand page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Комментарий", "gvMembers", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Приглашения:", "lbInvLabel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";

/*gvInvited*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Имя", "gvInvited", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Сообщение", "gvInvited", 28, site_language.Id , "MyBand page", 1, 2 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAddMember", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnRemoveInvite", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Имя:", "lbLabelName", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Сообщение:", "lbLabelMsg", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<strong>Введите код указанный выше:</strong><br/>", "lbLabelCaptcha", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Обновить", "btnRefresh", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<em>(Примечание: Если вы не можете прочесть символы на картинке,<br/> нажмите кнопку \"Обновить\", чтобы сгенерить новый код.)</em>", "lbLabelCaptchaNotice", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Пригласить", "btnInvite", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Отмена", "btnInvCancel", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Языки:", "lbLabelLanguages", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";

/*gvLangs*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Язык", "gvLangs", 28, site_language.Id , "MyBand page", 1, 1 from site_language where LangCode = "ru";

insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Новый язык:", "lbLabelNewLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Добавить", "btnAddLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDeleteLang", 28, site_language.Id , "MyBand page" from site_language where LangCode = "ru";
