-- ----------------------------------------------------------------------
-- MySQL Migration Toolkit
-- SQL Create Script
-- ----------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

CREATE DATABASE IF NOT EXISTS `gb_x_music118`
  CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `gb_x_music118`;
-- -------------------------------------
-- Tables

DROP TABLE IF EXISTS `gb_x_music118`.`bandlanguages`;
CREATE TABLE `gb_x_music118`.`bandlanguages` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `BandId` BIGINT(20) unsigned NOT NULL,
  `Language` VARCHAR(45) NOT NULL,
  `Deleted` BIT NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`bands`;
CREATE TABLE `gb_x_music118`.`bands` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(255) NOT NULL,
  `Deleted` BIT NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `Updater` BIGINT(20) unsigned NOT NULL,
  `Creater` BIGINT(20) unsigned NOT NULL,
  `Leader` BIGINT(20) unsigned NOT NULL,
  `State` SMALLINT(5) unsigned NOT NULL DEFAULT '0',
  `Style` VARCHAR(80) NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`comments`;
CREATE TABLE `gb_x_music118`.`comments` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubjId` BIGINT(20) unsigned NOT NULL DEFAULT '0',
  `Msg` VARCHAR(1024) NULL,
  `Author` BIGINT(20) NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `SubjTableId` SMALLINT(5) unsigned NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`commentsubjtables`;
CREATE TABLE `gb_x_music118`.`commentsubjtables` (
  `Id` SMALLINT(5) unsigned NOT NULL,
  `TableName` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`forum`;
CREATE TABLE `gb_x_music118`.`forum` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubjId` BIGINT(20) unsigned NOT NULL,
  `Text` VARCHAR(2048) NOT NULL,
  `AuthorId` BIGINT(20) unsigned NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`forum_main`;
CREATE TABLE `gb_x_music118`.`forum_main` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `LangId` BIGINT(20) unsigned NOT NULL,
  `Subj` VARCHAR(80) NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`forum_subj`;
CREATE TABLE `gb_x_music118`.`forum_subj` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `main_forum_id` BIGINT(20) unsigned NOT NULL,
  `Subj` VARCHAR(80) NOT NULL,
  `AuthorId` BIGINT(20) unsigned NOT NULL,
  `Created` DATETIME NULL,
  `Updated` DATETIME NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`images`;
CREATE TABLE `gb_x_music118`.`images` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NULL,
  `Description` VARCHAR(512) NULL,
  `FileName` VARCHAR(255) NOT NULL,
  `BandId` BIGINT(20) unsigned NULL,
  `Visibility` SMALLINT(6) NOT NULL,
  `Deleted` BIT NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `Author` BIGINT(20) unsigned NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`instruments`;
CREATE TABLE `gb_x_music118`.`instruments` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `Instrument` VARCHAR(100) NOT NULL,
  `Deleted` BIT NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`invites`;
CREATE TABLE `gb_x_music118`.`invites` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubjId` BIGINT(20) unsigned NOT NULL,
  `SubjTableId` BIGINT(20) unsigned NOT NULL,
  `MainUserId` BIGINT(20) unsigned NOT NULL,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `Created` DATETIME NOT NULL,
  `Msg` VARCHAR(256) NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`lyrics`;
CREATE TABLE `gb_x_music118`.`lyrics` (
  `id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Text` VARCHAR(2048) NULL,
  `Author` BIGINT(20) unsigned NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `Name` VARCHAR(100) NULL,
  `Deleted` BIT NOT NULL,
  `Style` VARCHAR(80) NULL,
  `Language` VARCHAR(45) NULL,
  `Visibility` SMALLINT(6) NULL,
  `BandId` BIGINT(20) unsigned NULL,
  PRIMARY KEY (`id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`messages`;
CREATE TABLE `gb_x_music118`.`messages` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubjId` BIGINT(20) unsigned NOT NULL,
  `Msg` VARCHAR(1024) NOT NULL,
  `FromId` BIGINT(20) unsigned NOT NULL,
  `ToId` BIGINT(20) unsigned NOT NULL,
  `Created` DATETIME NOT NULL,
  `SenderDelete` BIT NOT NULL,
  `RecipientDelete` BIT NOT NULL,
  `IsReaded` BIT NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`music`;
CREATE TABLE `gb_x_music118`.`music` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NULL,
  `FileName` VARCHAR(255) NULL,
  `Description` VARCHAR(512) NULL,
  `Style` VARCHAR(80) NULL,
  `BandId` BIGINT(20) unsigned NULL,
  `Visibility` SMALLINT(6) NOT NULL,
  `Deleted` BIT NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `Language` VARCHAR(45) NULL,
  `Author` BIGINT(20) unsigned NOT NULL,
  `ImgId` BIGINT(20) unsigned NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`rates`;
CREATE TABLE `gb_x_music118`.`rates` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubjId` BIGINT(20) unsigned NOT NULL,
  `Vote` SMALLINT(6) NOT NULL,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `SubjTableId` SMALLINT(5) unsigned NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`site_interface`;
CREATE TABLE `gb_x_music118`.`site_interface` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Text` VARCHAR(2048) NOT NULL,
  `Control_Id` VARCHAR(80) NOT NULL,
  `Code` BIGINT(20) unsigned NOT NULL,
  `LangId` BIGINT(20) unsigned NOT NULL,
  `Comment` VARCHAR(100) NOT NULL,
  `MultipleCont` BIT NULL,
  `ColumnIdx` INT(10) unsigned NULL,
  `SubControlId` varchar(80) NULL COMMENT 'controls in repeater',
  `IsMenu` BIT NULL COMMENT 'for vertical menu',
  `Url` varchar(512) NULL COMMENT 'for vertical menu',
  `MenuOrder` int NULL COMMENT 'for vertical menu',
  `IsForAdmin` bit NULL COMMENT 'only for admin',
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`site_language`;
CREATE TABLE `gb_x_music118`.`site_language` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `LangCode` VARCHAR(3) NOT NULL,
  `Text` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`, `LangCode`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`subjects`;
CREATE TABLE `gb_x_music118`.`subjects` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Subj` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`userinfo`;
CREATE TABLE `gb_x_music118`.`userinfo` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(30) NOT NULL,
  `PswHash` VARCHAR(48) NOT NULL,
  `SiteName` VARCHAR(45) NOT NULL,
  `Updated` DATETIME NULL,
  `UpdateUser` BIGINT(20) unsigned NULL,
  `Created` DATETIME NOT NULL,
  `OwnInfo` VARCHAR(512) NULL,
  `Country` VARCHAR(80) NULL,
  `City` VARCHAR(80) NULL,
  `Deleted` BIT NOT NULL,
  `UserPicId` BIGINT(20) unsigned NULL,
  `TimeZone` INT(11) NULL,
  `IsAdmin` BIT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`userlanguages`;
CREATE TABLE `gb_x_music118`.`userlanguages` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `Language` VARCHAR(45) NOT NULL,
  `Deleted` BIT NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`userstyles`;
CREATE TABLE `gb_x_music118`.`userstyles` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `StyleName` VARCHAR(80) NOT NULL,
  PRIMARY KEY (`Id`, `UserId`, `StyleName`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`usertoband`;
CREATE TABLE `gb_x_music118`.`usertoband` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `BandId` BIGINT(20) unsigned NOT NULL,
  `Deleted` BIT NOT NULL,
  `Updater` BIGINT(20) unsigned NOT NULL,
  `Updated` DATETIME NOT NULL,
  `Comment` VARCHAR(255) NULL,
  `IsLeader` BIT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`userways`;
CREATE TABLE `gb_x_music118`.`userways` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` BIGINT(20) unsigned NOT NULL,
  `WayId` BIGINT(20) unsigned NOT NULL,
  `Deleted` BIT NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`video`;
CREATE TABLE `gb_x_music118`.`video` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(100) NULL,
  `FileName` VARCHAR(100) NULL,
  `Description` VARCHAR(512) NULL,
  `BandId` BIGINT(20) unsigned NULL,
  `Visibility` SMALLINT(6) NOT NULL,
  `Deleted` BIT NOT NULL,
  `Created` DATETIME NOT NULL,
  `Updated` DATETIME NOT NULL,
  `ImgId` BIGINT(20) unsigned NULL,
  `Language` VARCHAR(45) NULL,
  `Style` VARCHAR(80) NULL,
  `Author` BIGINT(20) unsigned NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`waylocal`;
CREATE TABLE `gb_x_music118`.`waylocal` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `WayId` BIGINT(20) unsigned NOT NULL,
  `LangCode` VARCHAR(3) NOT NULL,
  `Text` VARCHAR(45) NOT NULL,
  `LangId` BIGINT(20) unsigned NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

DROP TABLE IF EXISTS `gb_x_music118`.`ways`;
CREATE TABLE `gb_x_music118`.`ways` (
  `Id` BIGINT(20) unsigned NOT NULL AUTO_INCREMENT,
  `Description` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB
CHARACTER SET utf8 COLLATE utf8_unicode_ci;



SET FOREIGN_KEY_CHECKS = 1;

-- ----------------------------------------------------------------------
-- EOF

