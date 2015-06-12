SET NAMES 'utf8';
/*AboutComponets control; Code = 43*/
/*English*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "I would like to thank
            <ul>
				<li>
				 Степанов Алексей for design &nbsp;<a href=\"http://www.free-lance.ru/users/alrg\">[alrg]</a>
				</li>
                <li>
                 creators of&nbsp; <a href=\"http://musicplayer.sourceforge.net/\">\"XSPF Web Music Player\"</a>
                </li>
                <li>
                 creators of&nbsp; <a href=\"http://flowplayer.org\">\"Flowplayer\"</a>
                </li>
                <li>
                 BrainJar for &nbsp; <a href=\"http://www.codeproject.com/KB/aspnet/CaptchaImage.aspx\">\"CAPTCHA Image\"</a>
                </li>
            </ul>", "lbDisc", 43, site_language.Id , "AboutComponets control" from site_language where LangCode = "en";

/*Русский*/
insert into site_interface (Text, Control_Id, Code, LangId, Comment) 
select "Хочу поблагодарить
            <ul>
				<li>
				 Степанова Алексея за дизайн &nbsp;<a href=\"http://www.free-lance.ru/users/alrg\">[alrg]</a>
				</li>
                <li>
                 создателей&nbsp; <a href=\"http://musicplayer.sourceforge.net/\">\"XSPF Web Music Player\"</a>
                </li>
                <li>
                 создателей&nbsp; <a href=\"http://flowplayer.org\">\"Flowplayer\"</a>
                </li>
                <li>
                 BrainJar за &nbsp; <a href=\"http://www.codeproject.com/KB/aspnet/CaptchaImage.aspx\">\"CAPTCHA Image\"</a>
                </li>
            </ul>", "lbDisc", 43, site_language.Id , "AboutComponets control" from site_language where LangCode = "ru";
			