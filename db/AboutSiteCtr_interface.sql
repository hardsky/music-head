SET NAMES 'utf8';
/*AboutSite control; Code = 42*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<p>Music-head.net is a site for musician and all people, who like music.</p>
    <p>I hope, that music-head will help to create music, generate new ideas and find new music.<br /> 
    Poets can publish their lyrics, musician can share their music and fans can criticize these works. <br />
    Do you want to create a music band? Find people on music-head!</p>
    <p>
        All works,that published on music-head, belong to users, who upload its on site. 
        Works, comments and posts are matter of music-head users, and are expressions of their own thoughts.
        Opinion of site administration can be different.
    </p>", "lbDisc", 42, site_language.Id , "AboutSite control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "<p>Music-head.net это сайт для музыкантов и всех людей, кто интерисуется музыкой.</p>
    <p>Я надеюсь, что music-head поможет в создании и поиске новой музыки, генерации идей, завязывании новых интересных знакомств.
	Поэты могут опубликовать здесь свои стихи, музыканты поделиться музыкой, которую они создают, а фанаты получат возможность высказать все, что они думают об этом творчестве :)
	Вы хотите создать музыкальную группу? Найдите единомышленников на music-head!
    </p>
    <p>
	    Все работы, опубликованые на сайте, принадлежат пользователям, которые выложили их.
		Творчество, коментарии и сообщения - личное дело пользователей music-head.
		Мнение администрации сайта может не совпадать с мнением, высказываемым пользователями.
    </p>", "lbDisc", 42, site_language.Id , "AboutSite control" from site_language where LangCode = "ru";
