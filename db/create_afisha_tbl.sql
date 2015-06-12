CREATE TABLE `afisha` (
`Id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`Event_name` varchar(128) NOT NULL,
`Description` varchar(512) NOT NULL,
`Event_datetime` datetime NOT NULL,
`Who` bigint UNSIGNED NOT NULL COMMENT 'author or his band (wehere he is leader)',
`IsBand` bit COMMENT 'true if band',
`Created` datetime NOT NULL,
`AuthorId` bigint UNSIGNED NOT NULL,
PRIMARY KEY (`Id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;
