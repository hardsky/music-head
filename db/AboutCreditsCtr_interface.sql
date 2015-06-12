SET NAMES 'utf8';
/*AboutCredits control; Code = 44*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<p>Design - Степанов Алексей <a href=\"http://www.free-lance.ru/users/alrg\">[alrg]</a> </p>
		<p>Idea, programming, design to html&css - Михайлов Николай <a href=\"http://www.music-head.net/folks/hardsky\">[hardsky]</a></p>
		", "lbDisc", 44, site_language.Id , "AboutCredits control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<p>Дизайн - Степанов Алексей <a href=\"http://www.free-lance.ru/users/alrg\">[alrg]</a> </p>
		<p>Идея, программирование, дизайн в html&css - Михайлов Николай <a href=\"http://www.music-head.net/folks/hardsky\">[hardsky]</a></p>
		", "lbDisc", 44, site_language.Id , "AboutCredits control" from site_language where LangCode = "ru";
