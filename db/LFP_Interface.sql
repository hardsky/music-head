SET NAMES 'utf8';
/*LFP page; Code = 37*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Language:", "lbLabelLanguage", 37, site_language.Id , "LFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Country:", "lbLabelCountry", 37, site_language.Id , "LFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "City:", "lbLabelCity", 37, site_language.Id , "LFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Looking For:", "lbLabelLooking", 37, site_language.Id , "LFP page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 37, site_language.Id , "LFP page" from site_language where LangCode = "en";
/*gvSearchMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Band", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 0 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Looking For...", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 1 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 2 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 3 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Country", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 4 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "City", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 5 from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 6 from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Язык:", "lbLabelLanguage", 37, site_language.Id , "LFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Страна:", "lbLabelCountry", 37, site_language.Id , "LFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Город:", "lbLabelCity", 37, site_language.Id , "LFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Looking For:", "lbLabelLooking", 37, site_language.Id , "LFP page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Find!", "btnFind", 37, site_language.Id , "LFP page" from site_language where LangCode = "ru";
/*gvSearchMembers*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Band", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 0 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Looking For...", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 1 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Comment", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 2 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Language", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 3 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Country", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 4 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "City", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 5 from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment, MultipleCont, ColumnIdx) 
select "Created", "gvSearchMembers", 37, site_language.Id , "LFP page", 1, 6 from site_language where LangCode = "ru";
