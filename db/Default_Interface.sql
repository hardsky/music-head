SET NAMES 'utf8';
/*Default page; Code = 38*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Events", "lbLabelAfisha", 38, site_language.Id , "default page" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "TODAY", "lbLabelToday", 38, site_language.Id , "default page" from site_language where LangCode = "en";

/*–усский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "јфиша", "lbLabelAfisha", 38, site_language.Id , "default page" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "—≈√ќƒЌя", "lbLabelToday", 38, site_language.Id , "default page" from site_language where LangCode = "ru";
