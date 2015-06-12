CREATE TABLE `news` (
`Id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`Author` bigint UNSIGNED NOT NULL,
`Created` datetime NOT NULL,
`Title` varchar(128) NOT NULL,
`News_Text` varchar(255) NOT NULL,
`IsBand` bit NOT NULL,
`Who` bigint UNSIGNED NOT NULL COMMENT 'Author id or Band id',
PRIMARY KEY (`Id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;
