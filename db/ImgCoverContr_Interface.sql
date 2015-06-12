SET NAMES 'utf8';
/*ImageCover control; Code = 56*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Image Cover:", "lbLabelCover", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Change", "btnChangeCover", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "en";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Delete", "btnDelete", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Обложка:", "lbLabelCover", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Изменить", "btnChangeCover", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "ru";
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Удалить", "btnDelete", 56, site_language.Id , "ImageCover control" from site_language where LangCode = "ru";
