CREATE DATABASE  IF NOT EXISTS `nmsdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `nmsdb`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: nmsdb
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('00000000000000_CreateIdentitySchema','2.0.1-rtm-125');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `announcement`
--

DROP TABLE IF EXISTS `announcement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `announcement` (
  `idannouncement` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `audiomessage` longblob NOT NULL,
  `audioname` varchar(45) NOT NULL,
  `audiosize` mediumint(9) NOT NULL,
  `repeattimes` int(11) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  `fkContact` int(11) DEFAULT NULL,
  `inProgress` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idannouncement`),
  KEY `Announcement_CustomerFK` (`fkCustomer`),
  KEY `Announcement_ContactFK` (`fkContact`)
) ENGINE=InnoDB AUTO_INCREMENT=1495 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `announcement`
--

LOCK TABLES `announcement` WRITE;
/*!40000 ALTER TABLE `announcement` DISABLE KEYS */;
/*!40000 ALTER TABLE `announcement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  KEY `IX_AspNetUserRoles_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(127) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('ef1c09cc-8f1b-49ad-b867-ccdb5a92f78d',0,'5aaab191-460a-4c1d-b32b-76f312ede71c','software@bistech.co.uk','\0','',NULL,'SOFTWARE@BISTECH.CO.UK','SOFTWARE@BISTECH.CO.UK','AQAAAAEAACcQAAAAEI4VGZlmvMVuV4u5yuwuT1Ds2d8RdllmhepsrLjmzurrLICHikTdSlLx33d/vnzrnQ==',NULL,'\0','fe1f7fa3-78e7-4c81-95b5-3eb7f6cd0b18','\0','software@bistech.co.uk');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `barring`
--

DROP TABLE IF EXISTS `barring`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `barring` (
  `idbarring` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(20) NOT NULL,
  `normalisedCode` varchar(20) NOT NULL,
  `description` varchar(100) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  `fkCustomer` int(11) DEFAULT NULL,
  PRIMARY KEY (`idbarring`)
) ENGINE=InnoDB AUTO_INCREMENT=844 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barring`
--

LOCK TABLES `barring` WRITE;
/*!40000 ALTER TABLE `barring` DISABLE KEYS */;
/*!40000 ALTER TABLE `barring` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blocking`
--

DROP TABLE IF EXISTS `blocking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blocking` (
  `idblocking` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(20) NOT NULL,
  `normalisedCode` varchar(20) NOT NULL,
  `description` varchar(100) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idblocking`)
) ENGINE=InnoDB AUTO_INCREMENT=3864 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blocking`
--

LOCK TABLES `blocking` WRITE;
/*!40000 ALTER TABLE `blocking` DISABLE KEYS */;
/*!40000 ALTER TABLE `blocking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carrier`
--

DROP TABLE IF EXISTS `carrier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carrier` (
  `idcarrier` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `domain` varchar(45) NOT NULL,
  `routingNumber` varchar(20) NOT NULL,
  `billingNumber` varchar(20) NOT NULL,
  `preference` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`idcarrier`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carrier`
--

LOCK TABLES `carrier` WRITE;
/*!40000 ALTER TABLE `carrier` DISABLE KEYS */;
/*!40000 ALTER TABLE `carrier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carrier_code`
--

DROP TABLE IF EXISTS `carrier_code`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carrier_code` (
  `idcarrier_code` int(11) NOT NULL AUTO_INCREMENT,
  `priority` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `fkCarrier` int(11) NOT NULL,
  `fkCode` int(11) NOT NULL,
  `fkLcr` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcarrier_code`),
  KEY `Carrier_CodeLcr` (`fkLcr`),
  KEY `Carrier_LcrCarrier` (`fkCarrier`),
  KEY `Carrier_LcrLcr` (`fkCode`),
  KEY `Carrier_CodeCode` (`fkCode`)
) ENGINE=InnoDB AUTO_INCREMENT=1021974 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carrier_code`
--

LOCK TABLES `carrier_code` WRITE;
/*!40000 ALTER TABLE `carrier_code` DISABLE KEYS */;
/*!40000 ALTER TABLE `carrier_code` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carrier_code_exception`
--

DROP TABLE IF EXISTS `carrier_code_exception`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carrier_code_exception` (
  `idcarrier_code_exception` int(11) NOT NULL AUTO_INCREMENT,
  `priority` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `fkCarrier` int(11) DEFAULT NULL,
  `fkCode` int(11) DEFAULT NULL,
  `fkExceptionLcr` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcarrier_code_exception`),
  KEY `CCE_Carrier` (`fkCarrier`),
  KEY `CCE_Code` (`fkCode`),
  KEY `CCE_ExceptionLcr` (`fkExceptionLcr`)
) ENGINE=InnoDB AUTO_INCREMENT=1034 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carrier_code_exception`
--

LOCK TABLES `carrier_code_exception` WRITE;
/*!40000 ALTER TABLE `carrier_code_exception` DISABLE KEYS */;
/*!40000 ALTER TABLE `carrier_code_exception` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carrier_number_exception`
--

DROP TABLE IF EXISTS `carrier_number_exception`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `carrier_number_exception` (
  `idcarrier_number_exception` int(11) NOT NULL AUTO_INCREMENT,
  `priority` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `fkCarrier` int(11) DEFAULT NULL,
  `fkExceptionNumber` int(11) DEFAULT NULL,
  `fkExceptionLcr` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcarrier_number_exception`),
  KEY `Carrier_CNE` (`fkCarrier`),
  KEY `ExceptionLcr_CNE` (`fkExceptionLcr`),
  KEY `ExceptionNumber_CNE` (`fkExceptionNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=11314 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carrier_number_exception`
--

LOCK TABLES `carrier_number_exception` WRITE;
/*!40000 ALTER TABLE `carrier_number_exception` DISABLE KEYS */;
/*!40000 ALTER TABLE `carrier_number_exception` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `code`
--

DROP TABLE IF EXISTS `code`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `code` (
  `idcode` int(11) NOT NULL AUTO_INCREMENT,
  `dialledNumber` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idcode`)
) ENGINE=InnoDB AUTO_INCREMENT=13995 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `code`
--

LOCK TABLES `code` WRITE;
/*!40000 ALTER TABLE `code` DISABLE KEYS */;
/*!40000 ALTER TABLE `code` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contact` (
  `idcontact` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `phoneNumber` varchar(20) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  `fkSite` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcontact`),
  KEY `ContactSite` (`fkSite`),
  KEY `fkCustomer` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=31684 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `idcustomer` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `routingNumber` varchar(20) DEFAULT NULL,
  `defaultBillingNumber` varchar(20) DEFAULT NULL,
  `nonGeo` int(11) NOT NULL DEFAULT '0',
  `fkExceptionLcr` int(11) DEFAULT NULL,
  `blockAnonymous` int(11) NOT NULL DEFAULT '0',
  `customercol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idcustomer`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `CustomerLcr` (`fkExceptionLcr`),
  KEY `Customer_ExceptionLcr` (`fkExceptionLcr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `daydetails`
--

DROP TABLE IF EXISTS `daydetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daydetails` (
  `iddayDetails` int(11) NOT NULL AUTO_INCREMENT,
  `day` varchar(10) DEFAULT NULL,
  `timeFrom` time DEFAULT NULL,
  `timeTo` time DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `fkPeriod` int(11) NOT NULL,
  PRIMARY KEY (`iddayDetails`),
  KEY `period_dayDetails` (`fkPeriod`)
) ENGINE=InnoDB AUTO_INCREMENT=101634 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daydetails`
--

LOCK TABLES `daydetails` WRITE;
/*!40000 ALTER TABLE `daydetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `daydetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exceptionlcr`
--

DROP TABLE IF EXISTS `exceptionlcr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exceptionlcr` (
  `idexceptionLcr` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idexceptionLcr`)
) ENGINE=InnoDB AUTO_INCREMENT=534 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exceptionlcr`
--

LOCK TABLES `exceptionlcr` WRITE;
/*!40000 ALTER TABLE `exceptionlcr` DISABLE KEYS */;
/*!40000 ALTER TABLE `exceptionlcr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exceptionnumber`
--

DROP TABLE IF EXISTS `exceptionnumber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exceptionnumber` (
  `idexceptionNumber` int(11) NOT NULL AUTO_INCREMENT,
  `number` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idexceptionNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=1854 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exceptionnumber`
--

LOCK TABLES `exceptionnumber` WRITE;
/*!40000 ALTER TABLE `exceptionnumber` DISABLE KEYS */;
/*!40000 ALTER TABLE `exceptionnumber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feature`
--

DROP TABLE IF EXISTS `feature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feature` (
  `idfeature` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `code` varchar(45) NOT NULL,
  PRIMARY KEY (`idfeature`),
  UNIQUE KEY `code_UNIQUE` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feature`
--

LOCK TABLES `feature` WRITE;
/*!40000 ALTER TABLE `feature` DISABLE KEYS */;
/*!40000 ALTER TABLE `feature` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feature_customer`
--

DROP TABLE IF EXISTS `feature_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feature_customer` (
  `idfeature_customer` int(11) NOT NULL AUTO_INCREMENT,
  `dateFrom` datetime NOT NULL,
  `dateTo` datetime DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `fkFeature` int(11) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idfeature_customer`),
  KEY `featureCustomer_FeatureFK` (`fkFeature`) USING BTREE,
  KEY `featureCustomer_Customer` (`fkCustomer`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=1674 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feature_customer`
--

LOCK TABLES `feature_customer` WRITE;
/*!40000 ALTER TABLE `feature_customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `feature_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group_template`
--

DROP TABLE IF EXISTS `group_template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `group_template` (
  `idgroupTemplate` int(11) NOT NULL AUTO_INCREMENT,
  `fkGroup` int(11) NOT NULL,
  `fkTemplate` int(11) NOT NULL,
  `priority` int(11) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  `fkRoutingGroup` int(11) DEFAULT NULL,
  PRIMARY KEY (`idgroupTemplate`),
  KEY `Group_GroupTemplate` (`fkGroup`),
  KEY `Template_GroupTemplate` (`fkTemplate`),
  KEY `RoutingGroup_GroupTemplate` (`fkRoutingGroup`)
) ENGINE=InnoDB AUTO_INCREMENT=18454 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group_template`
--

LOCK TABLES `group_template` WRITE;
/*!40000 ALTER TABLE `group_template` DISABLE KEYS */;
/*!40000 ALTER TABLE `group_template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ivr`
--

DROP TABLE IF EXISTS `ivr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ivr` (
  `idivr` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `audiomessage` longblob,
  `audioname` varchar(45) DEFAULT NULL,
  `audiosize` mediumint(9) DEFAULT NULL,
  `repeattimes` int(11) DEFAULT NULL,
  `timeout` int(11) NOT NULL DEFAULT '2',
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idivr`),
  KEY `Ivr_CustomerFK` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=464 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ivr`
--

LOCK TABLES `ivr` WRITE;
/*!40000 ALTER TABLE `ivr` DISABLE KEYS */;
/*!40000 ALTER TABLE `ivr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ivraction`
--

DROP TABLE IF EXISTS `ivraction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ivraction` (
  `idivraction` int(11) NOT NULL AUTO_INCREMENT,
  `digit` int(11) NOT NULL,
  `fkIvr` int(11) NOT NULL,
  `fkIvrDest` int(11) DEFAULT NULL,
  `fkContactDest` int(11) DEFAULT NULL,
  `fkAnnouncementDest` int(11) DEFAULT NULL,
  `fkMailboxDest` int(11) DEFAULT NULL,
  `voicemailMain` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idivraction`,`digit`),
  KEY `fk_ivr_ivraction` (`fkIvr`),
  KEY `fk_ivrDest_ivraction` (`fkIvrDest`),
  KEY `fk_contactDest_ivraction` (`fkContactDest`),
  KEY `fk_announcementDest_ivraction` (`fkAnnouncementDest`),
  KEY `fk_mailboxDest_ivraction` (`fkMailboxDest`)
) ENGINE=InnoDB AUTO_INCREMENT=4314 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ivraction`
--

LOCK TABLES `ivraction` WRITE;
/*!40000 ALTER TABLE `ivraction` DISABLE KEYS */;
/*!40000 ALTER TABLE `ivraction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lcr`
--

DROP TABLE IF EXISTS `lcr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lcr` (
  `idlcr` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idlcr`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lcr`
--

LOCK TABLES `lcr` WRITE;
/*!40000 ALTER TABLE `lcr` DISABLE KEYS */;
/*!40000 ALTER TABLE `lcr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `idlog` bigint(20) NOT NULL AUTO_INCREMENT,
  `action` varchar(45) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `table` varchar(45) NOT NULL,
  `attribute` varchar(45) DEFAULT NULL,
  `newValue` varchar(100) DEFAULT NULL,
  `idModified` int(11) DEFAULT NULL,
  `fkUser` int(11) NOT NULL,
  PRIMARY KEY (`idlog`),
  KEY `Log_Users` (`fkUser`)
) ENGINE=InnoDB AUTO_INCREMENT=3271756 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mailbox`
--

DROP TABLE IF EXISTS `mailbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mailbox` (
  `idmailbox` int(11) NOT NULL AUTO_INCREMENT,
  `pin` int(4) DEFAULT NULL,
  `name` varchar(45) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `sendEmail` int(11) NOT NULL DEFAULT '1',
  `deleteOpt` int(11) NOT NULL,
  `attachment` int(11) NOT NULL,
  `audiomessage` longblob,
  `audioname` varchar(45) DEFAULT NULL,
  `audiosize` mediumint(9) DEFAULT NULL,
  `fkNumber` int(11) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  `fax` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idmailbox`),
  KEY `Mailbox_NumberFK` (`fkNumber`),
  KEY `Mailbox_CustomerFK` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=2354 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mailbox`
--

LOCK TABLES `mailbox` WRITE;
/*!40000 ALTER TABLE `mailbox` DISABLE KEYS */;
/*!40000 ALTER TABLE `mailbox` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `number`
--

DROP TABLE IF EXISTS `number`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `number` (
  `idnumber` int(11) NOT NULL AUTO_INCREMENT,
  `number` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `fkCustomer` int(11) NOT NULL,
  `fkGroup` int(11) DEFAULT NULL,
  `activeDate` datetime DEFAULT NULL,
  `customerDescription` varchar(100) DEFAULT NULL,
  `ceaseDate` datetime DEFAULT NULL,
  PRIMARY KEY (`idnumber`),
  UNIQUE KEY `number_UNIQUE` (`number`),
  KEY `NumberCustomer` (`fkCustomer`),
  KEY `NumberGroup` (`fkGroup`)
) ENGINE=InnoDB AUTO_INCREMENT=941795 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `number`
--

LOCK TABLES `number` WRITE;
/*!40000 ALTER TABLE `number` DISABLE KEYS */;
/*!40000 ALTER TABLE `number` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `number_template`
--

DROP TABLE IF EXISTS `number_template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `number_template` (
  `idnumberTemplate` int(11) NOT NULL AUTO_INCREMENT,
  `fkNumber` int(11) NOT NULL,
  `fkTemplate` int(11) NOT NULL,
  `priority` int(11) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  `fkRoutingGroup` int(11) NOT NULL,
  PRIMARY KEY (`idnumberTemplate`),
  KEY `RoutingNumber` (`fkNumber`),
  KEY `RoutingTemplate` (`fkTemplate`),
  KEY `NumberTemplateRoutingGroup` (`fkRoutingGroup`)
) ENGINE=InnoDB AUTO_INCREMENT=54364 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `number_template`
--

LOCK TABLES `number_template` WRITE;
/*!40000 ALTER TABLE `number_template` DISABLE KEYS */;
/*!40000 ALTER TABLE `number_template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `numberformat`
--

DROP TABLE IF EXISTS `numberformat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numberformat` (
  `idnumberFormat` int(11) NOT NULL AUTO_INCREMENT,
  `numberFormat` varchar(3) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `name` varchar(20) NOT NULL,
  PRIMARY KEY (`idnumberFormat`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `numberformat`
--

LOCK TABLES `numberformat` WRITE;
/*!40000 ALTER TABLE `numberformat` DISABLE KEYS */;
/*!40000 ALTER TABLE `numberformat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `numbergroup`
--

DROP TABLE IF EXISTS `numbergroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numbergroup` (
  `idgroup` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idgroup`),
  KEY `GroupCustomer` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=10614 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `numbergroup`
--

LOCK TABLES `numbergroup` WRITE;
/*!40000 ALTER TABLE `numbergroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `numbergroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `period`
--

DROP TABLE IF EXISTS `period`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `period` (
  `idperiod` int(11) NOT NULL AUTO_INCREMENT,
  `timeFrom` time NOT NULL,
  `timeTo` time DEFAULT NULL,
  `dateFrom` date NOT NULL,
  `dateTo` date DEFAULT NULL,
  `frequency` varchar(45) DEFAULT NULL,
  `day` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `fkTemplate` int(11) NOT NULL,
  PRIMARY KEY (`idperiod`),
  KEY `PeriodTemplate` (`fkTemplate`)
) ENGINE=InnoDB AUTO_INCREMENT=14514 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `period`
--

LOCK TABLES `period` WRITE;
/*!40000 ALTER TABLE `period` DISABLE KEYS */;
/*!40000 ALTER TABLE `period` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report`
--

DROP TABLE IF EXISTS `report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `report` (
  `idreport` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idreport`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report`
--

LOCK TABLES `report` WRITE;
/*!40000 ALTER TABLE `report` DISABLE KEYS */;
/*!40000 ALTER TABLE `report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report_customer`
--

DROP TABLE IF EXISTS `report_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `report_customer` (
  `idreport_customer` int(11) NOT NULL AUTO_INCREMENT,
  `frequency` varchar(45) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '0',
  `email` varchar(100) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  `fkReport` int(11) NOT NULL,
  `fkReportConfiguration` int(11) DEFAULT NULL,
  PRIMARY KEY (`idreport_customer`)
) ENGINE=InnoDB AUTO_INCREMENT=1964 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report_customer`
--

LOCK TABLES `report_customer` WRITE;
/*!40000 ALTER TABLE `report_customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `report_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reportconfiguration`
--

DROP TABLE IF EXISTS `reportconfiguration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reportconfiguration` (
  `idreportConfiguration` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `fkUserProfile` int(11) NOT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idreportConfiguration`),
  KEY `fk_userprofiles_reportconfiguration` (`fkUserProfile`),
  KEY `fk_customer_reportconfiguration` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=3675 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reportconfiguration`
--

LOCK TABLES `reportconfiguration` WRITE;
/*!40000 ALTER TABLE `reportconfiguration` DISABLE KEYS */;
/*!40000 ALTER TABLE `reportconfiguration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reportconfiguration_number`
--

DROP TABLE IF EXISTS `reportconfiguration_number`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reportconfiguration_number` (
  `idreportconfiguration_number` int(11) NOT NULL AUTO_INCREMENT,
  `fkReportConfiguration` int(11) NOT NULL,
  `fkNumber` int(11) NOT NULL,
  PRIMARY KEY (`idreportconfiguration_number`),
  KEY `fk_reportconfiguration_rcn` (`fkReportConfiguration`),
  KEY `fk_number_rcn` (`fkNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=74414 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reportconfiguration_number`
--

LOCK TABLES `reportconfiguration_number` WRITE;
/*!40000 ALTER TABLE `reportconfiguration_number` DISABLE KEYS */;
/*!40000 ALTER TABLE `reportconfiguration_number` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routing`
--

DROP TABLE IF EXISTS `routing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routing` (
  `idrouting` int(11) NOT NULL AUTO_INCREMENT,
  `priority` int(11) DEFAULT NULL,
  `ringingTime` int(11) DEFAULT NULL,
  `fkContact` int(11) DEFAULT NULL,
  `fkSite` int(11) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  `fkRoutingGroup` int(11) DEFAULT NULL,
  `huntBusy` int(11) NOT NULL,
  `fkAnnouncement` int(11) DEFAULT NULL,
  `fkIvr` int(11) DEFAULT NULL,
  `fkMailbox` int(11) DEFAULT NULL,
  `voicemailMain` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idrouting`),
  KEY `ContactRouting` (`fkContact`),
  KEY `RoutingGroupRouting` (`fkRoutingGroup`),
  KEY `SiteRouting` (`fkSite`)
) ENGINE=InnoDB AUTO_INCREMENT=51304 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routing`
--

LOCK TABLES `routing` WRITE;
/*!40000 ALTER TABLE `routing` DISABLE KEYS */;
/*!40000 ALTER TABLE `routing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routinggroup`
--

DROP TABLE IF EXISTS `routinggroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routinggroup` (
  `idroutingGroup` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  `isUserGenerated` int(11) DEFAULT NULL,
  `fkCustomer` int(11) NOT NULL,
  `forking` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idroutingGroup`),
  KEY `RoutingGroupCustomer` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=39624 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routinggroup`
--

LOCK TABLES `routinggroup` WRITE;
/*!40000 ALTER TABLE `routinggroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `routinggroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `site`
--

DROP TABLE IF EXISTS `site`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `site` (
  `idsite` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `domain` varchar(45) NOT NULL,
  `fkNumberFormat` int(11) DEFAULT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idsite`),
  KEY `SiteCustomer` (`fkCustomer`),
  KEY `SiteNumberFormat` (`fkNumberFormat`)
) ENGINE=InnoDB AUTO_INCREMENT=8034 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `site`
--

LOCK TABLES `site` WRITE;
/*!40000 ALTER TABLE `site` DISABLE KEYS */;
/*!40000 ALTER TABLE `site` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `template`
--

DROP TABLE IF EXISTS `template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `template` (
  `idtemplate` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `fkCustomer` int(11) NOT NULL,
  PRIMARY KEY (`idtemplate`),
  KEY `templateCustomer` (`fkCustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=7964 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `template`
--

LOCK TABLES `template` WRITE;
/*!40000 ALTER TABLE `template` DISABLE KEYS */;
/*!40000 ALTER TABLE `template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_profiles`
--

DROP TABLE IF EXISTS `user_profiles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_profiles` (
  `iduser` int(11) NOT NULL,
  `idcustomer` int(11) DEFAULT NULL,
  `name` varchar(45) NOT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  PRIMARY KEY (`iduser`),
  KEY `UserProfiles_User` (`iduser`),
  KEY `UserProfiles_Customer` (`idcustomer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_profiles`
--

LOCK TABLES `user_profiles` WRITE;
/*!40000 ALTER TABLE `user_profiles` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_profiles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `view_accountandmissed`
--

DROP TABLE IF EXISTS `view_accountandmissed`;
/*!50001 DROP VIEW IF EXISTS `view_accountandmissed`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_accountandmissed` AS SELECT 
 1 AS `table_ref`,
 1 AS `method`,
 1 AS `sip_code`,
 1 AS `sip_reason`,
 1 AS `time`,
 1 AS `cust_no`,
 1 AS `called_no`,
 1 AS `dst_domain`,
 1 AS `calling_no`,
 1 AS `orig_called_no`,
 1 AS `privacy`,
 1 AS `callid`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_accountandmissed12hours`
--

DROP TABLE IF EXISTS `view_accountandmissed12hours`;
/*!50001 DROP VIEW IF EXISTS `view_accountandmissed12hours`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_accountandmissed12hours` AS SELECT 
 1 AS `table_ref`,
 1 AS `method`,
 1 AS `sip_code`,
 1 AS `sip_reason`,
 1 AS `time`,
 1 AS `cust_no`,
 1 AS `called_no`,
 1 AS `dst_domain`,
 1 AS `calling_no`,
 1 AS `orig_called_no`,
 1 AS `privacy`,
 1 AS `callid`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_accountandmissedforcallsrelated`
--

DROP TABLE IF EXISTS `view_accountandmissedforcallsrelated`;
/*!50001 DROP VIEW IF EXISTS `view_accountandmissedforcallsrelated`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_accountandmissedforcallsrelated` AS SELECT 
 1 AS `table_ref`,
 1 AS `method`,
 1 AS `sip_code`,
 1 AS `sip_reason`,
 1 AS `time`,
 1 AS `cust_no`,
 1 AS `called_no`,
 1 AS `dst_domain`,
 1 AS `calling_no`,
 1 AS `orig_called_no`,
 1 AS `privacy`,
 1 AS `callid`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_allowednumbertree`
--

DROP TABLE IF EXISTS `view_allowednumbertree`;
/*!50001 DROP VIEW IF EXISTS `view_allowednumbertree`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_allowednumbertree` AS SELECT 
 1 AS `tprefix`,
 1 AS `tvalue`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_mailbox`
--

DROP TABLE IF EXISTS `view_mailbox`;
/*!50001 DROP VIEW IF EXISTS `view_mailbox`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_mailbox` AS SELECT 
 1 AS `id`,
 1 AS `context`,
 1 AS `mailbox`,
 1 AS `password`,
 1 AS `fullname`,
 1 AS `email`,
 1 AS `attach`,
 1 AS `delete`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_normalisednumbers`
--

DROP TABLE IF EXISTS `view_normalisednumbers`;
/*!50001 DROP VIEW IF EXISTS `view_normalisednumbers`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_normalisednumbers` AS SELECT 
 1 AS `numberId`,
 1 AS `dialledNumber`,
 1 AS `description`,
 1 AS `customerNumber`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_numbertree`
--

DROP TABLE IF EXISTS `view_numbertree`;
/*!50001 DROP VIEW IF EXISTS `view_numbertree`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `view_numbertree` AS SELECT 
 1 AS `tprefix`,
 1 AS `tvalue`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `voicemessages`
--

DROP TABLE IF EXISTS `voicemessages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `voicemessages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `msgnum` int(11) NOT NULL DEFAULT '0',
  `dir` varchar(80) DEFAULT '',
  `context` varchar(80) DEFAULT '',
  `macrocontext` varchar(80) DEFAULT '',
  `callerid` varchar(40) DEFAULT '',
  `origtime` varchar(40) DEFAULT '',
  `duration` varchar(20) DEFAULT '',
  `flag` varchar(10) DEFAULT '',
  `mailboxuser` varchar(80) DEFAULT '',
  `mailboxcontext` varchar(80) DEFAULT '',
  `msg_id` varchar(80) DEFAULT '',
  `recording` longblob,
  PRIMARY KEY (`id`),
  KEY `dir` (`dir`)
) ENGINE=InnoDB AUTO_INCREMENT=21952 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `voicemessages`
--

LOCK TABLES `voicemessages` WRITE;
/*!40000 ALTER TABLE `voicemessages` DISABLE KEYS */;
/*!40000 ALTER TABLE `voicemessages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `view_accountandmissed`
--

/*!50001 DROP VIEW IF EXISTS `view_accountandmissed`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_accountandmissed` AS select 1 AS `table_ref`,1 AS `method`,1 AS `sip_code`,1 AS `sip_reason`,1 AS `time`,1 AS `cust_no`,1 AS `called_no`,1 AS `dst_domain`,1 AS `calling_no`,1 AS `orig_called_no`,1 AS `privacy`,1 AS `callid` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_accountandmissed12hours`
--

/*!50001 DROP VIEW IF EXISTS `view_accountandmissed12hours`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_accountandmissed12hours` AS select 1 AS `table_ref`,1 AS `method`,1 AS `sip_code`,1 AS `sip_reason`,1 AS `time`,1 AS `cust_no`,1 AS `called_no`,1 AS `dst_domain`,1 AS `calling_no`,1 AS `orig_called_no`,1 AS `privacy`,1 AS `callid` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_accountandmissedforcallsrelated`
--

/*!50001 DROP VIEW IF EXISTS `view_accountandmissedforcallsrelated`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_accountandmissedforcallsrelated` AS select 1 AS `table_ref`,1 AS `method`,1 AS `sip_code`,1 AS `sip_reason`,1 AS `time`,1 AS `cust_no`,1 AS `called_no`,1 AS `dst_domain`,1 AS `calling_no`,1 AS `orig_called_no`,1 AS `privacy`,1 AS `callid` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_allowednumbertree`
--

/*!50001 DROP VIEW IF EXISTS `view_allowednumbertree`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_allowednumbertree` AS select 1 AS `tprefix`,1 AS `tvalue` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_mailbox`
--

/*!50001 DROP VIEW IF EXISTS `view_mailbox`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_mailbox` AS select 1 AS `id`,1 AS `context`,1 AS `mailbox`,1 AS `password`,1 AS `fullname`,1 AS `email`,1 AS `attach`,1 AS `delete` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_normalisednumbers`
--

/*!50001 DROP VIEW IF EXISTS `view_normalisednumbers`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_normalisednumbers` AS select 1 AS `numberId`,1 AS `dialledNumber`,1 AS `description`,1 AS `customerNumber` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_numbertree`
--

/*!50001 DROP VIEW IF EXISTS `view_numbertree`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`nms`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `view_numbertree` AS select 1 AS `tprefix`,1 AS `tvalue` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-14 17:22:02
