CREATE TABLE `looking_band` (
`Id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`LookingFor` varchar(80) NOT NULL COMMENT 'Looking for role in group',
`Country` varchar(80),
`City` varchar(80),
`Language` varchar(45),
`Comment` varchar(255),
`Style` varchar(80),
`Created` datetime,
`Creater` bigint UNSIGNED NOT NULL,
PRIMARY KEY (`Id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;
