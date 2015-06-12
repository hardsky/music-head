CREATE TABLE `looking_people` (
`Id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
`BandId` bigint UNSIGNED,
`Country` varchar(80),
`City` varchar(80),
`Language` varchar(45),
`LookingFor` varchar(80),
`Comment` varchar(255),
`Created` datetime,
`Creater` bigint UNSIGNED,
PRIMARY KEY (`Id`)  )
ENGINE = InnoDB
CHARACTER SET utf8
COLLATE utf8_unicode_ci;

