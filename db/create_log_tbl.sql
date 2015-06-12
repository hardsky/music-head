CREATE TABLE `jamlog` (
`id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`entry_type` smallint NOT NULL,
`entry_source` varchar(80) NOT NULL,
`entry_msg` varchar(2048) NOT NULL,
`created` datetime NOT NULL,
PRIMARY KEY (`id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;