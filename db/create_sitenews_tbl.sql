CREATE TABLE `site_news` (
`Id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`Title` varchar(128) NOT NULL,
`News_Text` varchar(512) NOT NULL,
`LangId` bigint UNSIGNED NOT NULL,
`Author` bigint UNSIGNED NOT NULL,
`Created` datetime NOT NULL,
`Updated` datetime NOT NULL,
PRIMARY KEY (`Id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;
