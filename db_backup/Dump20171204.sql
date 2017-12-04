CREATE DATABASE  IF NOT EXISTS `axiata` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `axiata`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: axiata
-- ------------------------------------------------------
-- Server version	5.7.20-log

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
-- Table structure for table `dim_time`
--

DROP TABLE IF EXISTS `dim_time`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dim_time` (
  `ID` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `Month` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dim_time`
--

LOCK TABLES `dim_time` WRITE;
/*!40000 ALTER TABLE `dim_time` DISABLE KEYS */;
INSERT INTO `dim_time` VALUES (1,2015,1),(2,2015,2),(3,2015,3),(4,2015,4),(5,2015,5),(6,2015,6),(7,2015,7),(8,2015,8),(9,2015,9),(10,2015,10),(11,2015,11),(12,2015,12),(13,2016,1),(14,2016,2),(15,2016,3),(16,2016,4),(17,2016,5),(18,2016,6),(19,2016,7),(20,2016,8),(21,2016,9),(22,2016,10),(23,2016,11),(24,2016,12),(25,2017,1),(26,2017,2),(27,2017,3),(28,2017,4),(29,2017,5),(30,2017,6),(31,2017,7),(32,2017,8),(33,2017,9),(34,2017,10),(35,2017,11),(36,2017,12),(37,2018,1),(38,2018,2),(39,2018,3),(40,2018,4),(41,2018,5),(42,2018,6),(43,2018,7),(44,2018,8),(45,2018,9),(46,2018,10),(47,2018,11),(48,2018,12),(49,2019,1),(50,2019,2),(51,2019,3),(52,2019,4),(53,2019,5),(54,2019,6),(55,2019,7),(56,2019,8),(57,2019,9),(58,2019,10),(59,2019,11),(60,2019,12),(61,2020,1),(62,2020,2),(63,2020,3),(64,2020,4),(65,2020,5),(66,2020,6),(67,2020,7),(68,2020,8),(69,2020,9),(70,2020,10),(71,2020,11),(72,2020,12),(73,2021,1),(74,2021,2),(75,2021,3),(76,2021,4),(77,2021,5),(78,2021,6),(79,2021,7),(80,2021,8),(81,2021,9),(82,2021,10),(83,2021,11),(84,2021,12);
/*!40000 ALTER TABLE `dim_time` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_cc_rate`
--

DROP TABLE IF EXISTS `tb_cc_rate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_cc_rate` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `currency` varchar(45) DEFAULT NULL,
  `year` varchar(45) DEFAULT NULL,
  `cc_rate_value` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `month_id` int(11) DEFAULT NULL,
  `edit_mode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=796 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_cc_rate`
--

LOCK TABLES `tb_cc_rate` WRITE;
/*!40000 ALTER TABLE `tb_cc_rate` DISABLE KEYS */;
INSERT INTO `tb_cc_rate` VALUES (580,'MYR','2016','123','Jan',1,'0'),(581,'MYR','2016','123','Feb',2,'0'),(582,'MYR','2016','123','Mar',3,'0'),(583,'MYR','2016','123','Apr',4,'0'),(584,'MYR','2016','123','May',5,'0'),(585,'MYR','2016','123','Jun',6,'0'),(586,'MYR','2016','123','Jul',7,'0'),(587,'MYR','2016','123','Aug',8,'0'),(588,'MYR','2016','123','Sep',9,'0'),(589,'MYR','2016','123','Oct',10,'0'),(590,'MYR','2016','123','Nov',11,'0'),(591,'MYR','2016','123','Dec',12,'0'),(592,'IDR','2016','852.72','Jan',1,'0'),(593,'IDR','2016','852.72','Feb',2,'0'),(594,'IDR','2016','852.72','Mar',3,'0'),(595,'IDR','2016','852.72','Apr',4,'0'),(596,'IDR','2016','852.72','May',5,'0'),(597,'IDR','2016','852.72','Jun',6,'0'),(598,'IDR','2016','852.72','Jul',7,'0'),(599,'IDR','2016','852.72','Aug',8,'0'),(600,'IDR','2016','852.72','Sep',9,'0'),(601,'IDR','2016','852.72','Oct',10,'0'),(602,'IDR','2016','852.72','Nov',11,'0'),(603,'IDR','2016','852.72','Dec',12,'0'),(604,'LKR','2016','74.96','Jan',1,'0'),(605,'LKR','2016','74.96','Feb',2,'0'),(606,'LKR','2016','74.96','Mar',3,'0'),(607,'LKR','2016','74.96','Apr',4,'0'),(608,'LKR','2016','74.96','May',5,'0'),(609,'LKR','2016','74.96','Jun',6,'0'),(610,'LKR','2016','74.96','Jul',7,'0'),(611,'LKR','2016','74.96','Aug',8,'0'),(612,'LKR','2016','74.96','Sep',9,'0'),(613,'LKR','2016','74.96','Oct',10,'0'),(614,'LKR','2016','74.96','Nov',11,'0'),(615,'LKR','2016','74.96','Dec',12,'0'),(616,'BDT','2016','78.6645','Jan',1,'0'),(617,'BDT','2016','78.6645','Feb',2,'0'),(618,'BDT','2016','78.6645','Mar',3,'0'),(619,'BDT','2016','78.6645','Apr',4,'0'),(620,'BDT','2016','78.6645','May',5,'0'),(621,'BDT','2016','78.6645','Jun',6,'0'),(622,'BDT','2016','78.6645','Jul',7,'0'),(623,'BDT','2016','78.6645','Aug',8,'0'),(624,'BDT','2016','78.6645','Sep',9,'0'),(625,'BDT','2016','78.6645','Oct',10,'0'),(626,'BDT','2016','78.6645','Nov',11,'0'),(627,'BDT','2016','78.6645','Dec',12,'0'),(628,'INR','2016','7.245345','Jan',1,'0'),(629,'INR','2016','7.245345','Feb',2,'0'),(630,'INR','2016','7.245345','Mar',3,'0'),(631,'INR','2016','7.245345','Apr',4,'0'),(632,'INR','2016','7.245345','May',5,'0'),(633,'INR','2016','7.245345','Jun',6,'0'),(634,'INR','2016','7.245345','Jul',7,'0'),(635,'INR','2016','7.245345','Aug',8,'0'),(636,'INR','2016','7.245345','Sep',9,'0'),(637,'INR','2016','7.245345','Oct',10,'0'),(638,'INR','2016','7.245345','Nov',11,'0'),(639,'INR','2016','7.245345','Dec',12,'0'),(640,'AUD','2016','879','Jan',1,'0'),(641,'AUD','2016','879','Feb',2,'0'),(642,'AUD','2016','879','Mar',3,'0'),(643,'AUD','2016','879','Apr',4,'0'),(644,'AUD','2016','879','May',5,'0'),(645,'AUD','2016','879','Jun',6,'0'),(646,'AUD','2016','879','Jul',7,'0'),(647,'AUD','2016','879','Aug',8,'0'),(648,'AUD','2016','879','Sep',9,'0'),(649,'AUD','2016','879','Oct',10,'0'),(650,'AUD','2016','879','Nov',11,'0'),(651,'AUD','2016','879','Dec',12,'0'),(724,'MYR','2015','87','Jan',1,'0'),(725,'MYR','2015','87','Feb',2,'0'),(726,'MYR','2015','87','Mar',3,'0'),(727,'MYR','2015','87','Apr',4,'0'),(728,'MYR','2015','87','May',5,'0'),(729,'MYR','2015','87','Jun',6,'0'),(730,'MYR','2015','87','Jul',7,'0'),(731,'MYR','2015','87','Aug',8,'0'),(732,'MYR','2015','87','Sep',9,'0'),(733,'MYR','2015','87','Oct',10,'0'),(734,'MYR','2015','87','Nov',11,'0'),(735,'MYR','2015','87','Dec',12,'0'),(736,'IDR','2015','98','Jan',1,'0'),(737,'IDR','2015','98','Feb',2,'0'),(738,'IDR','2015','98','Mar',3,'0'),(739,'IDR','2015','98','Apr',4,'0'),(740,'IDR','2015','98','May',5,'0'),(741,'IDR','2015','98','Jun',6,'0'),(742,'IDR','2015','98','Jul',7,'0'),(743,'IDR','2015','98','Aug',8,'0'),(744,'IDR','2015','98','Sep',9,'0'),(745,'IDR','2015','98','Oct',10,'0'),(746,'IDR','2015','98','Nov',11,'0'),(747,'IDR','2015','98','Dec',12,'0'),(748,'LKR','2015','84','Jan',1,'0'),(749,'LKR','2015','84','Feb',2,'0'),(750,'LKR','2015','84','Mar',3,'0'),(751,'LKR','2015','84','Apr',4,'0'),(752,'LKR','2015','84','May',5,'0'),(753,'LKR','2015','84','Jun',6,'0'),(754,'LKR','2015','84','Jul',7,'0'),(755,'LKR','2015','84','Aug',8,'0'),(756,'LKR','2015','84','Sep',9,'0'),(757,'LKR','2015','84','Oct',10,'0'),(758,'LKR','2015','84','Nov',11,'0'),(759,'LKR','2015','84','Dec',12,'0'),(760,'BDT','2015','52','Jan',1,'0'),(761,'BDT','2015','52','Feb',2,'0'),(762,'BDT','2015','52','Mar',3,'0'),(763,'BDT','2015','52','Apr',4,'0'),(764,'BDT','2015','52','May',5,'0'),(765,'BDT','2015','52','Jun',6,'0'),(766,'BDT','2015','52','Jul',7,'0'),(767,'BDT','2015','52','Aug',8,'0'),(768,'BDT','2015','52','Sep',9,'0'),(769,'BDT','2015','52','Oct',10,'0'),(770,'BDT','2015','52','Nov',11,'0'),(771,'BDT','2015','52','Dec',12,'0'),(772,'INR','2015','63','Jan',1,'0'),(773,'INR','2015','63','Feb',2,'0'),(774,'INR','2015','63','Mar',3,'0'),(775,'INR','2015','63','Apr',4,'0'),(776,'INR','2015','63','May',5,'0'),(777,'INR','2015','63','Jun',6,'0'),(778,'INR','2015','63','Jul',7,'0'),(779,'INR','2015','63','Aug',8,'0'),(780,'INR','2015','63','Sep',9,'0'),(781,'INR','2015','63','Oct',10,'0'),(782,'INR','2015','63','Nov',11,'0'),(783,'INR','2015','63','Dec',12,'0'),(784,'AUD','2015','98','Jan',1,'0'),(785,'AUD','2015','98','Feb',2,'0'),(786,'AUD','2015','98','Mar',3,'0'),(787,'AUD','2015','98','Apr',4,'0'),(788,'AUD','2015','98','May',5,'0'),(789,'AUD','2015','98','Jun',6,'0'),(790,'AUD','2015','98','Jul',7,'0'),(791,'AUD','2015','98','Aug',8,'0'),(792,'AUD','2015','98','Sep',9,'0'),(793,'AUD','2015','98','Oct',10,'0'),(794,'AUD','2015','98','Nov',11,'0'),(795,'AUD','2015','98','Dec',12,'0');
/*!40000 ALTER TABLE `tb_cc_rate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_countries`
--

DROP TABLE IF EXISTS `tb_countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_countries` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `country_name` varchar(50) NOT NULL,
  `currency_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_countries`
--

LOCK TABLES `tb_countries` WRITE;
/*!40000 ALTER TABLE `tb_countries` DISABLE KEYS */;
INSERT INTO `tb_countries` VALUES (1,'Malaysia','MYR'),(2,'Cambodia','KHR'),(3,'Indonesia','IDR'),(4,'Srilanka','LKR'),(5,'Bangladesh','BDT');
/*!40000 ALTER TABLE `tb_countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_fc_to_usd_actual`
--

DROP TABLE IF EXISTS `tb_fc_to_usd_actual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_fc_to_usd_actual` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `currency` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `year` varchar(45) DEFAULT NULL,
  `quarter` varchar(45) DEFAULT NULL,
  `value` varchar(45) DEFAULT NULL,
  `month_id` int(11) DEFAULT NULL,
  `edit_mode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=600 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_fc_to_usd_actual`
--

LOCK TABLES `tb_fc_to_usd_actual` WRITE;
/*!40000 ALTER TABLE `tb_fc_to_usd_actual` DISABLE KEYS */;
INSERT INTO `tb_fc_to_usd_actual` VALUES (311,'MYR','Jan','2016','Q1','4.334',1,'0'),(312,'IDR','Jan','2016','Q1','113870.03',1,'0'),(313,'LKR','Jan','2016','Q1','11.1235',1,'0'),(314,'BDT','Jan','2016','Q1','95.967',1,'0'),(315,'INR','Jan','2016','Q1','79.657',1,'0'),(316,'AUD','Jan','2016','Q1','45.6598',1,'0'),(317,'MYR','Feb','2016','Q1','4.123',2,'0'),(318,'IDR','Feb','2016','Q1','135321.05',2,'0'),(319,'LKR','Feb','2016','Q1','12.659',2,'0'),(320,'BDT','Feb','2016','Q1','94.6598',2,'0'),(321,'INR','Feb','2016','Q1','80.3265',2,'0'),(322,'AUD','Feb','2016','Q1','40.6598',2,'0'),(323,'MYR','Mar','2016','Q1','4.022',3,'0'),(324,'IDR','Mar','2016','Q1','13180.21',3,'0'),(325,'LKR','Mar','2016','Q1','12.65',3,'0'),(326,'BDT','Mar','2016','Q1','95.789',3,'0'),(327,'INR','Mar','2016','Q1','80.2659',3,'0'),(328,'AUD','Mar','2016','Q1','42.6569',3,'0'),(329,'MYR','Apr','2016','Q2','3.102',4,'0'),(330,'IDR','Apr','2016','Q2','13177.22',4,'0'),(331,'LKR','Apr','2016','Q2','12.65987',4,'0'),(332,'BDT','Apr','2016','Q2','96.236',4,'0'),(333,'INR','Apr','2016','Q2','81.6598',4,'0'),(334,'AUD','Apr','2016','Q2','46.2659',4,'0'),(335,'MYR','May','2016','Q2','3.120',5,'0'),(336,'IDR','May','2016','Q2','13144.26',5,'0'),(337,'LKR','May','2016','Q2','12.8978',5,'0'),(338,'BDT','May','2016','Q2','99.852',5,'0'),(339,'INR','May','2016','Q2','77.6598',5,'0'),(340,'AUD','May','2016','Q2','44.6598',5,'0'),(341,'MYR','Jun','2016','Q2','3.750',6,'0'),(342,'IDR','Jun','2016','Q2','1.0',6,'0'),(343,'LKR','Jun','2016','Q2','12.951',6,'0'),(344,'BDT','Jun','2016','Q2','91.4569',6,'0'),(345,'INR','Jun','2016','Q2','72.6598',6,'0'),(346,'AUD','Jun','2016','Q2','43.9875',6,'0'),(347,'MYR','Jul','2016','Q3','1.000',7,'0'),(348,'IDR','Jul','2016','Q3','1.0',7,'0'),(349,'LKR','Jul','2016','Q3','14.6598',7,'0'),(350,'BDT','Jul','2016','Q3','97.6541',7,'0'),(351,'INR','Jul','2016','Q3','79.6564',7,'0'),(352,'AUD','Jul','2016','Q3','41.2546',7,'0'),(353,'MYR','Aug','2016','Q3','1.000',8,'0'),(354,'IDR','Aug','2016','Q3','1.0',8,'0'),(355,'LKR','Aug','2016','Q3','11.654',8,'0'),(356,'BDT','Aug','2016','Q3','92.548',8,'0'),(357,'INR','Aug','2016','Q3','80.1546',8,'0'),(358,'AUD','Aug','2016','Q3','45.5674',8,'0'),(359,'MYR','Sep','2016','Q3','1.000',9,'0'),(360,'IDR','Sep','2016','Q3','1.0',9,'0'),(361,'LKR','Sep','2016','Q3','12.987',9,'0'),(362,'BDT','Sep','2016','Q3','93.236',9,'0'),(363,'INR','Sep','2016','Q3','78.654',9,'0'),(364,'AUD','Sep','2016','Q3','43.6598',9,'0'),(365,'MYR','Oct','2016','Q4','1.000',10,'0'),(366,'IDR','Oct','2016','Q4','1.0',10,'0'),(367,'LKR','Oct','2016','Q4','1278',10,'0'),(368,'BDT','Oct','2016','Q4','9223',10,'0'),(369,'INR','Oct','2016','Q4','7998',10,'0'),(370,'AUD','Oct','2016','Q4','45',10,'0'),(371,'MYR','Nov','2016','Q4','1127',11,'0'),(372,'IDR','Nov','2016','Q4','1223',11,'0'),(373,'LKR','Nov','2016','Q4','143',11,'0'),(374,'BDT','Nov','2016','Q4','934',11,'0'),(375,'INR','Nov','2016','Q4','80233',11,'0'),(376,'AUD','Nov','2016','Q4','47',11,'0'),(377,'MYR','Dec','2016','Q4','12',12,'1'),(378,'IDR','Dec','2016','Q4','2',12,'1'),(379,'LKR','Dec','2016','Q4','3',12,'1'),(380,'BDT','Dec','2016','Q4','4',12,'1'),(381,'INR','Dec','2016','Q4','5',12,'1'),(382,'AUD','Dec','2016','Q4','6',12,'1'),(528,'MYR','Jan','2015','Q1','123',1,'0'),(529,'IDR','Jan','2015','Q1','112',1,'0'),(530,'LKR','Jan','2015','Q1','113',1,'0'),(531,'BDT','Jan','2015','Q1','12',1,'0'),(532,'INR','Jan','2015','Q1','3',1,'0'),(533,'AUD','Jan','2015','Q1','4',1,'0'),(534,'MYR','Feb','2015','Q1','',2,'1'),(535,'IDR','Feb','2015','Q1','',2,'1'),(536,'LKR','Feb','2015','Q1','',2,'1'),(537,'BDT','Feb','2015','Q1','',2,'1'),(538,'INR','Feb','2015','Q1','',2,'1'),(539,'AUD','Feb','2015','Q1','',2,'1'),(540,'MYR','Mar','2015','Q1','',3,'1'),(541,'IDR','Mar','2015','Q1','',3,'1'),(542,'LKR','Mar','2015','Q1','',3,'1'),(543,'BDT','Mar','2015','Q1','',3,'1'),(544,'INR','Mar','2015','Q1','',3,'1'),(545,'AUD','Mar','2015','Q1','',3,'1'),(546,'MYR','Apr','2015','Q2','',4,'1'),(547,'IDR','Apr','2015','Q2','',4,'1'),(548,'LKR','Apr','2015','Q2','',4,'1'),(549,'BDT','Apr','2015','Q2','',4,'1'),(550,'INR','Apr','2015','Q2','',4,'1'),(551,'AUD','Apr','2015','Q2','',4,'1'),(552,'MYR','May','2015','Q2','',5,'1'),(553,'IDR','May','2015','Q2','',5,'1'),(554,'LKR','May','2015','Q2','',5,'1'),(555,'BDT','May','2015','Q2','',5,'1'),(556,'INR','May','2015','Q2','',5,'1'),(557,'AUD','May','2015','Q2','',5,'1'),(558,'MYR','Jun','2015','Q2','',6,'1'),(559,'IDR','Jun','2015','Q2','',6,'1'),(560,'LKR','Jun','2015','Q2','',6,'1'),(561,'BDT','Jun','2015','Q2','',6,'1'),(562,'INR','Jun','2015','Q2','',6,'1'),(563,'AUD','Jun','2015','Q2','',6,'1'),(564,'MYR','Jul','2015','Q3','',7,'1'),(565,'IDR','Jul','2015','Q3','',7,'1'),(566,'LKR','Jul','2015','Q3','',7,'1'),(567,'BDT','Jul','2015','Q3','',7,'1'),(568,'INR','Jul','2015','Q3','',7,'1'),(569,'AUD','Jul','2015','Q3','',7,'1'),(570,'MYR','Aug','2015','Q3','',8,'1'),(571,'IDR','Aug','2015','Q3','',8,'1'),(572,'LKR','Aug','2015','Q3','',8,'1'),(573,'BDT','Aug','2015','Q3','',8,'1'),(574,'INR','Aug','2015','Q3','',8,'1'),(575,'AUD','Aug','2015','Q3','',8,'1'),(576,'MYR','Sep','2015','Q3','',9,'1'),(577,'IDR','Sep','2015','Q3','',9,'1'),(578,'LKR','Sep','2015','Q3','',9,'1'),(579,'BDT','Sep','2015','Q3','',9,'1'),(580,'INR','Sep','2015','Q3','',9,'1'),(581,'AUD','Sep','2015','Q3','',9,'1'),(582,'MYR','Oct','2015','Q4','',10,'1'),(583,'IDR','Oct','2015','Q4','',10,'1'),(584,'LKR','Oct','2015','Q4','',10,'1'),(585,'BDT','Oct','2015','Q4','',10,'1'),(586,'INR','Oct','2015','Q4','',10,'1'),(587,'AUD','Oct','2015','Q4','',10,'1'),(588,'MYR','Nov','2015','Q4','',11,'1'),(589,'IDR','Nov','2015','Q4','',11,'1'),(590,'LKR','Nov','2015','Q4','',11,'1'),(591,'BDT','Nov','2015','Q4','',11,'1'),(592,'INR','Nov','2015','Q4','',11,'1'),(593,'AUD','Nov','2015','Q4','',11,'1'),(594,'MYR','Dec','2015','Q4','',12,'1'),(595,'IDR','Dec','2015','Q4','',12,'1'),(596,'LKR','Dec','2015','Q4','',12,'1'),(597,'BDT','Dec','2015','Q4','',12,'1'),(598,'INR','Dec','2015','Q4','',12,'1'),(599,'AUD','Dec','2015','Q4','',12,'1');
/*!40000 ALTER TABLE `tb_fc_to_usd_actual` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_report_data`
--

DROP TABLE IF EXISTS `tb_report_data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_report_data` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `year` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `vertical` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `r_gmv` float DEFAULT NULL,
  `r_gr` varchar(45) DEFAULT NULL,
  `dc_network` varchar(45) DEFAULT NULL,
  `dc_direct_labor` varchar(45) DEFAULT NULL,
  `dc_commissions` varchar(45) DEFAULT NULL,
  `dc_others` varchar(45) DEFAULT NULL,
  `dc_gross_profit` varchar(45) DEFAULT NULL,
  `o_manpower` varchar(45) DEFAULT NULL,
  `o_travelling` varchar(45) DEFAULT NULL,
  `o_it_charges` varchar(45) DEFAULT NULL,
  `o_marketing_costs` varchar(45) DEFAULT NULL,
  `o_professional_charges` varchar(45) DEFAULT NULL,
  `o_others` varchar(45) DEFAULT NULL,
  `ebitda` varchar(45) DEFAULT NULL,
  `depreciation` varchar(45) DEFAULT NULL,
  `net_interest` varchar(45) DEFAULT NULL,
  `others` varchar(45) DEFAULT NULL,
  `share_of_results` varchar(45) DEFAULT NULL,
  `tax` varchar(45) DEFAULT NULL,
  `profit_after_tax` varchar(45) DEFAULT NULL,
  `ads_equity_share` varchar(45) DEFAULT NULL,
  `month_id` int(11) DEFAULT NULL,
  `currency` varchar(45) DEFAULT NULL,
  `edit_mode` varchar(45) DEFAULT NULL,
  `DateId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_report_data`
--

LOCK TABLES `tb_report_data` WRITE;
/*!40000 ALTER TABLE `tb_report_data` DISABLE KEYS */;
INSERT INTO `tb_report_data` VALUES (1,'2016','Jan','Malaysia','Advertising','Local Currency',10.25,'47.26','54.32','77.25','25.36','10.25','10.25','98.23','10.25','10.25','77.25','10.25','25.36',NULL,'25.36','13.55','25.36','25.36','25.36','25.36','77.25',1,'MYR','0',13),(2,'2016','Feb','Malaysia','Advertising','Local Currency',11.15,'33.21','54.12','17.26','14.56','25.36','25.36','25.36','98.23','98.23','98.23','14.56','98.23',NULL,'77.25','14.56','13.55','13.55','77.25','77.25','10.25',2,'MYR','1',14),(3,'2016','Mar','Malaysia','Advertising','Local Currency',12.32,'22.25','69.11','25.36','98.23','25.36','98.23','14.56','13.55','13.55','98.23','98.23','14.56',NULL,'14.56','13.55','13.55','14.56','77.25','77.25','10.25',3,'MYR','1',15),(4,'2016','Apr','Malaysia','Advertising','Local Currency',13.55,'32.26','74.21','10.25','77.25','98.23','98.23','25.36','98.23','98.23','25.36','77.25','25.36',NULL,'14.56','13.55','25.36','14.56','14.56','14.56','25.36',4,'MYR','1',16),(5,'2016','May','Malaysia','Advertising','Local Currency',14.56,'65.21','98.23','13.55','98.23','25.36','98.23','98.23','10.25','77.25','98.23','98.23','98.23',NULL,'14.56','77.25','13.55','77.25','77.25','14.56','10.25',5,'MYR','1',17),(6,'2016','Jun','Malaysia','Advertising','Local Currency',17.26,'65.14','25.32','25.36','98.23','77.25','13.55','10.25','14.56','98.23','25.36','98.23','98.23',NULL,'13.55','13.55','25.36','14.56','25.36','14.56','25.36',6,'MYR','1',18),(8,'2016','Aug','Malaysia','Financial Services','Local Currency',77.25,'95.65','33.21','13.55','98.23','10.25','25.36','77.25','98.23','14.56','98.23','13.55','98.23',NULL,'25.36','77.25','13.55','14.56','14.56','77.25','10.25',8,'MYR','1',20),(9,'2016','Sep','Malaysia','Financial Services','Local Currency',54.14,'74.24','21.21','25.36','10.25','13.55','98.23','98.23','25.36','10.25','25.36','98.23','77.25',NULL,'25.36','13.55','77.25','13.55','77.25','25.36','25.36',9,'MYR','1',21),(10,'2016','Oct','Malaysia','Financial Services','Local Currency',54.32,'21.25','69.64','25.36','14.56','98.23','77.25','25.36','25.36','98.23','98.23','25.36','25.36',NULL,'98.23','10.25','13.55','77.25','25.36','14.56','14.56',10,'MYR','1',22),(11,'2016','Nov','Malaysia','Financial Services','Local Currency',25.36,'25.32','21.75','10.25','10.25','25.36','14.56','98.23','98.23','98.23','14.56','10.25','98.23',NULL,'14.56','13.55','13.55','77.25','14.56','14.56','10.25',11,'MYR','1',23),(12,'2016','Dec','Malaysia','Financial Services','Local Currency',33.25,'33.33','25.36','77.25','13.55','14.56','98.23','25.36','98.23','25.36','98.23','98.23','14.56',NULL,'14.56','14.56','77.25','10.25','14.56','14.56','13.55',12,'MYR','1',24),(15,'2016','Jul','Malaysia','Financial Services','Local Currency',28,'2000','278','2','2','2','1716','2','2','2','2222','2','2','-516','214','2','2','2','2','-738','25',7,'MYR','0',19),(16,'2016','Dec','Malaysia','Advertising','Local Currency',20,'20','20','20','20','20','-60','20','20','20','20','20','20','-180','20','20','20','20','20','-280','20',12,'MYR','0',24),(17,'2015','Jan','Indonesia','Advertising','Local Currency',12,'12','2','2','2','2','4','2','2','2','2','2','2','-8','2','2','2','2','2','-18','25',1,'IDR','0',1),(28,'2015','Jan','Indonesia','Advertising','Actual',0.027,'0.027','0.004','0.004','0.004','0.004','0.009','0.004','0.004','0.004','0.004','0.004','0.004','-0.018','0.004','0.004','0.004','0.004','0.004','-0.040','25',1,'IDR','0',1),(29,'2015','Jan','Indonesia','Advertising','CC',0.031,'0.031','0.005','0.005','0.005','0.005','0.010','0.005','0.005','0.005','0.005','0.005','0.005','-0.020','0.005','0.005','0.005','0.005','0.005','-0.046','25',1,'IDR','0',1);
/*!40000 ALTER TABLE `tb_report_data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_setup_budget`
--

DROP TABLE IF EXISTS `tb_setup_budget`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_setup_budget` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `year` varchar(45) DEFAULT NULL,
  `month` varchar(45) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `vertical` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `r_gmv` varchar(45) DEFAULT NULL,
  `r_gr` varchar(45) DEFAULT NULL,
  `dc_network` varchar(45) DEFAULT NULL,
  `dc_direct_labor` varchar(45) DEFAULT NULL,
  `dc_commissions` varchar(45) DEFAULT NULL,
  `dc_others` varchar(45) DEFAULT NULL,
  `dc_gross_profit` varchar(45) DEFAULT NULL,
  `o_manpower` varchar(45) DEFAULT NULL,
  `o_travelling` varchar(45) DEFAULT NULL,
  `o_it_charges` varchar(45) DEFAULT NULL,
  `o_marketing_costs` varchar(45) DEFAULT NULL,
  `o_professional_charges` varchar(45) DEFAULT NULL,
  `o_others` varchar(45) DEFAULT NULL,
  `ebitda` varchar(45) DEFAULT NULL,
  `depreciation` varchar(45) DEFAULT NULL,
  `net_interest` varchar(45) DEFAULT NULL,
  `others` varchar(45) DEFAULT NULL,
  `share_of_results` varchar(45) DEFAULT NULL,
  `tax` varchar(45) DEFAULT NULL,
  `profit_after_tax` varchar(45) DEFAULT NULL,
  `month_id` int(11) DEFAULT NULL,
  `currency` varchar(45) DEFAULT NULL,
  `edit_mode` varchar(45) DEFAULT NULL,
  `DateId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_setup_budget`
--

LOCK TABLES `tb_setup_budget` WRITE;
/*!40000 ALTER TABLE `tb_setup_budget` DISABLE KEYS */;
INSERT INTO `tb_setup_budget` VALUES (1,'2016','Jan','Malaysia','Advertising','Local Currency','33.251','1000.369','33.2533','54.32','98.23','33.25','781.3157','54.32','33.25','11.15','33.25','54.32','33.25','561.7757','11.15','33.25','33.25','33.25','54.32','396.5557',1,'MYR','0',13),(2,'2016','Feb','Malaysia','Advertising','Local Currency','54.32123','5400.32','33.25','98.23','98.23','33.25','5137.36','11.15','33.25','54.32','33.25','33.25','54.32','4917.82','11.15','54.32','11.15','11.15','33.25','4796.80',2,'MYR','0',14),(3,'2016','Mar','Malaysia','Advertising','Local Currency','33.2599','33.2555','98.23','33.25','33.25','33.25','-164.7245','11.15','11.15','54.32','33.25','11.15','33.25','-318.9945','11.15','11.15','33.25','11.15','11.15','-396.8445',3,'MYR','0',15),(4,'2016','Apr','Malaysia','Advertising','Actual','54.32','54.32','54.32','98.23','33.25','33.25','54.32','33.25','33.25','11.15','54.32','33.25','11.15','65','33.25','33.25','11.15','33.25','33.25','54.32',4,'MYR','0',16),(5,'2016','May','Malaysia','Advertising','Actual','98.23','98.23','33.25','33.25','33.25','98.23','54.32','11.15','33.25','54.32','33.25','54.32','33.25','9','11.15','33.25','33.25','11.15','11.15','33.25',5,'MYR','0',17),(6,'2016','Jun','Malaysia','Advertising','Actual','33.25','33.25','33.25','54.32','33.25','98.23','98.23','11.15','11.15','11.15','54.32','33.25','11.15','53','33.25','33.25','11.15','11.15','33.25','11.15',6,'MYR','0',18),(7,'2016','Jul','Malaysia','Financial Services','Local Currency','54.32','54.32','98.23','33.25','98.23','98.23','98.23','33.25','54.32','33.25','11.15','11.15','54.32','2','11.15','11.15','11.15','33.25','11.15','33.25',7,'MYR','0',19),(8,'2016','Aug','Malaysia','Financial Services','Actual','98.23','98.23','54.32','98.23','54.32','54.32','54.32','11.15','11.15','33.25','54.32','33.25','11.15','65','33.25','11.15','33.25','11.15','33.25','11.15',8,'MYR','0',20),(9,'2016','Sep','Malaysia','Financial Services','Actual','54.32','33.25','98.23','33.25','54.32','54.32','33.25','33.25','54.32','33.25','11.15','54.32','33.25','65','33.25','11.15','54.32','33.25','54.32','33.25',9,'MYR','0',21),(31,'2016','Feb','Malaysia','Advertising','Actual','13.925','1384.357','8.524','25.181','25.181','8.524','1316.948','2.858','8.524','13.925','8.524','8.524','13.925','1260.669','2.858','13.925','2.858','2.858','8.524','1229.646',2,'MYR','0',14),(32,'2016','Feb','Malaysia','Advertising','CC','13.925','1384.357','8.524','25.181','25.181','8.524','1316.948','2.858','8.524','13.925','8.524','8.524','13.925','1260.669','2.858','13.925','2.858','2.858','8.524','1229.646',2,'MYR','0',14),(35,'2016','Jan','Malaysia','Advertising','Actual','0.426','12.825','0.426','0.696','1.259','0.426','10.017','0.696','0.426','0.143','0.426','0.696','0.426','7.202','0.143','0.426','0.426','0.426','0.696','5.084',1,'MYR','0',13),(36,'2016','Jan','Malaysia','Advertising','CC','0.426','12.825','0.426','0.696','1.259','0.426','10.017','0.696','0.426','0.143','0.426','0.696','0.426','7.202','0.143','0.426','0.426','0.426','0.696','5.084',1,'MYR','0',13),(37,'2016','Dec','Malaysia','Advertising','Local Currency','10','10','10','10','10','10','-30','10','10','10','10','10','10','-90','10','10','10','10','10','-140',12,'MYR','0',24),(41,'2016','Nov','Malaysia','Advertising','Local Currency','2','200','2','2','2','2','192','2','2','2','2','2','2','180','2','2','2','2','2','170',11,'MYR','0',23),(42,'2016','Nov','Malaysia','Advertising','Actual','0.016','1.626','0.016','0.016','0.016','0.016','1.561','0.016','0.016','0.016','0.016','0.016','0.016','1.463','0.016','0.016','0.016','0.016','0.016','1.382',11,'MYR','0',23),(43,'2016','Nov','Malaysia','Advertising','CC','0.016','1.626','0.016','0.016','0.016','0.016','1.561','0.016','0.016','0.016','0.016','0.016','0.016','1.463','0.016','0.016','0.016','0.016','0.016','1.382',11,'MYR','0',23),(44,'2016','Nov','Malaysia','Financial Services','Local Currency','95','959','959','9','9','9','-27','9','9','9','9','9','9','-81','9','9','9','9','9','-126',11,'MYR','1',23),(47,'2016','Dec','Malaysia','Advertising','Actual','0.081','0.081','0.081','0.081','0.081','0.081','-0.244','0.081','0.081','0.081','0.081','0.081','0.081','-0.732','0.081','0.081','0.081','0.081','0.081','-1.138',12,'MYR','0',24),(48,'2016','Dec','Malaysia','Advertising','CC','0.081','0.081','0.081','0.081','0.081','0.081','-0.244','0.081','0.081','0.081','0.081','0.081','0.081','-0.732','0.081','0.081','0.081','0.081','0.081','-1.138',12,'MYR','0',24),(49,'2015','Jan','Cambodia','Financial Services','Local Currency','23','23','2','2','2','2','15','2','2','2','2','2','2','3','2','2','2','2','2','-7',1,'USD','0',1),(50,'2015','Jan','Cambodia','Financial Services','Actual','23','23','2','2','2','2','15','2','2','2','2','2','2','3','2','2','2','2','2','-7',1,'USD','0',1),(51,'2015','Jan','Cambodia','Financial Services','CC','23','23','2','2','2','2','15','2','2','2','2','2','2','3','2','2','2','2','2','-7',1,'USD','0',1),(52,'2015','Jan','Indonesia','Advertising','Local Currency','123','1123','9','9','9','9','1087','9','9','9','9','9','9','1033','9','9','9','9','9','988',1,'IDR','0',1),(53,'2015','Jan','Indonesia','Advertising','Actual','1.255','11.459','0.092','0.092','0.092','0.092','11.092','0.092','0.092','0.092','0.092','0.092','0.092','10.541','0.092','0.092','0.092','0.092','0.092','10.082',1,'IDR','0',1),(54,'2015','Jan','Indonesia','Advertising','CC','1.255','11.459','0.092','0.092','0.092','0.092','11.092','0.092','0.092','0.092','0.092','0.092','0.092','10.541','0.092','0.092','0.092','0.092','0.092','10.082',1,'IDR','0',1),(55,'2015','Feb','Indonesia','Advertising','Local Currency','654','951','1','2','3','4','941','5','6','7','8','9','10','896','12','45','6','98','7','728',2,'IDR','0',2),(56,'2015','Feb','Indonesia','Advertising','Actual','6.673','9.704','0.010','0.020','0.031','0.041','9.602','0.051','0.061','0.071','0.082','0.092','0.102','9.143','0.122','0.459','0.061','1','0.071','7.429',2,'IDR','0',2),(57,'2015','Feb','Indonesia','Advertising','CC','6.673','9.704','0.010','0.020','0.031','0.041','9.602','0.051','0.061','0.071','0.082','0.092','0.102','9.143','0.122','0.459','0.061','1','0.071','7.429',2,'IDR','0',2),(58,'2016','Mar','Malaysia','Advertising','Actual','0.270','0.270','0.799','0.270','0.270','0.270','-1.339','0.091','0.091','0.442','0.270','0.091','0.270','-2.593','0.091','0.091','0.270','0.091','0.091','-3.226',3,'MYR','0',15),(59,'2016','Mar','Malaysia','Advertising','CC','0.270','0.270','0.799','0.270','0.270','0.270','-1.339','0.091','0.091','0.442','0.270','0.091','0.270','-2.593','0.091','0.091','0.270','0.091','0.091','-3.226',3,'MYR','0',15);
/*!40000 ALTER TABLE `tb_setup_budget` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_verticals`
--

DROP TABLE IF EXISTS `tb_verticals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_verticals` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vertical_name` varchar(50) NOT NULL,
  `currency_name` varchar(50) NOT NULL,
  `country_name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_verticals`
--

LOCK TABLES `tb_verticals` WRITE;
/*!40000 ALTER TABLE `tb_verticals` DISABLE KEYS */;
INSERT INTO `tb_verticals` VALUES (1,'Advertising','MYR','Malaysia'),(2,'Financial Services','MYR','Malaysia'),(3,'Advertising','IDR','Indonesia'),(4,'IOT','IDR','Indonesia'),(5,'CLOUD','IDR','Indonesia'),(6,'VAS','IDR','Indonesia'),(7,'Financial Services - XL - Tunai','IDR','Indonesia'),(8,'Financial Services - M - Banking','IDR','Indonesia'),(9,'Financial Services - IoU','IDR','Indonesia'),(10,'Platforms','IDR','Indonesia'),(11,'Financial Services - Boost','IDR','Indonesia'),(12,'Advertising','LKR','Sri Lanka'),(13,'Commerce','LKR','Sri Lanka'),(14,'Financial Services','LKR','Sri Lanka'),(15,'Platforms','LKR','Sri Lanka'),(16,'Others','LKR','Sri Lanka'),(17,'Advertising','BDT','Bangladesh'),(18,'Commerce','BDT','Bangladesh'),(19,'Financial Services','BDT','Bangladesh'),(20,'Platforms','BDT','Bangladesh'),(21,'Others','BDT','Bangladesh'),(22,'Financial Services','USD','Cambodia'),(23,'Corporate Centre','MYR','ADS CC'),(24,'Financial Services - Boost','MYR','ADS CC'),(25,'Platforms','MYR','ADS CC'),(26,'Digital Ventures - Wow.lk','LKR','Subsidiary'),(27,'Digital Ventures - WSO2.Telco','USD','Subsidiary'),(28,'Digital Ventures - Acknowledge','USD','Subsidiary'),(29,'Digital Ventures - Merchant Trade','MYR','Subsidiary'),(30,'Digital Ventures - VMD','MYR','Subsidiary'),(31,'Digital Ventures - ADA','MYR','Subsidiary'),(32,'Digital Ventures - 11st','MYR','JV / Associate'),(33,'Digital Ventures - Elevenia','IDR','JV / Associate'),(34,'Digital Ventures - Yonder','USD','JV / Associate'),(35,'Digital Ventures - StoreKing (India)','INR','JV / Associate'),(36,'Digital Ventures - StoreKing (Indonesia)','IDR','JV / Associate'),(37,'Digital Ventures - BIMA','USD','JV / Associate'),(38,'Digital Ventures - Unlockd','AUD','JV / Associate'),(39,'Digital Ventures - Etobee','USD','JV / Associate'),(40,'Digital Ventures - Digital Health','LKR','JV / Associate');
/*!40000 ALTER TABLE `tb_verticals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'axiata'
--

--
-- Dumping routines for database 'axiata'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-04 10:29:45
