-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Feb 11, 2024 at 10:21 PM
-- Server version: 8.2.0
-- PHP Version: 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mts_database`
--

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `ClientID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) NOT NULL,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  PRIMARY KEY (`ClientID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`ClientID`, `Username`, `FirstName`, `LastName`) VALUES
(3, 'radovan.draskovic', 'Radovan', 'Draskovic'),
(6, 'marija.jolovic', 'Marija', 'Jolovic'),
(7, 'damjan.pavlovic', 'Damjan', 'Pavlovic'),
(8, 'andjelina.maksimovic', 'Andjelina', 'Maksimovic'),
(10, 'uros.mladenovic', 'Uros', 'Mladenovic');

-- --------------------------------------------------------

--
-- Table structure for table `clientpacket`
--

DROP TABLE IF EXISTS `clientpacket`;
CREATE TABLE IF NOT EXISTS `clientpacket` (
  `ClientID` int NOT NULL,
  `PacketID` int NOT NULL,
  PRIMARY KEY (`ClientID`,`PacketID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `clientpacket`
--

INSERT INTO `clientpacket` (`ClientID`, `PacketID`) VALUES
(3, 10);

-- --------------------------------------------------------

--
-- Table structure for table `combpacket`
--

DROP TABLE IF EXISTS `combpacket`;
CREATE TABLE IF NOT EXISTS `combpacket` (
  `PacketID` int NOT NULL,
  `InternetPacketID` int NOT NULL,
  `TVPacketID` int NOT NULL,
  KEY `FK_PacketID_Comb` (`PacketID`),
  KEY `FK_Int_Packet` (`InternetPacketID`),
  KEY `FK_TV_Packet` (`TVPacketID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `combpacket`
--

INSERT INTO `combpacket` (`PacketID`, `InternetPacketID`, `TVPacketID`) VALUES
(12, 11, 10),
(15, 11, 13);

-- --------------------------------------------------------

--
-- Table structure for table `internetpacket`
--

DROP TABLE IF EXISTS `internetpacket`;
CREATE TABLE IF NOT EXISTS `internetpacket` (
  `PacketID` int NOT NULL,
  `DownloadSpeed` int NOT NULL,
  `UploadSpeed` int NOT NULL,
  KEY `FK_PacketID_Internet` (`PacketID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `internetpacket`
--

INSERT INTO `internetpacket` (`PacketID`, `DownloadSpeed`, `UploadSpeed`) VALUES
(11, 30, 15);

-- --------------------------------------------------------

--
-- Table structure for table `packet`
--

DROP TABLE IF EXISTS `packet`;
CREATE TABLE IF NOT EXISTS `packet` (
  `PacketID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Price` float NOT NULL,
  PRIMARY KEY (`PacketID`),
  UNIQUE KEY `Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `packet`
--

INSERT INTO `packet` (`PacketID`, `Name`, `Price`) VALUES
(10, 'TV 50', 750),
(11, 'NET 30', 1250),
(12, 'BOX 1', 1500),
(13, 'TV 100', 1000),
(15, 'BOX 2', 1999);

-- --------------------------------------------------------

--
-- Table structure for table `tvpacket`
--

DROP TABLE IF EXISTS `tvpacket`;
CREATE TABLE IF NOT EXISTS `tvpacket` (
  `PacketID` int NOT NULL,
  `NumberOfChannels` int NOT NULL,
  KEY `FK_PacketTV` (`PacketID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tvpacket`
--

INSERT INTO `tvpacket` (`PacketID`, `NumberOfChannels`) VALUES
(10, 50),
(13, 100);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `clientpacket`
--
ALTER TABLE `clientpacket`
  ADD CONSTRAINT `FK_Client` FOREIGN KEY (`ClientID`) REFERENCES `client` (`ClientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `combpacket`
--
ALTER TABLE `combpacket`
  ADD CONSTRAINT `FK_Int_Packet` FOREIGN KEY (`InternetPacketID`) REFERENCES `internetpacket` (`PacketID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_PacketID_Comb` FOREIGN KEY (`PacketID`) REFERENCES `packet` (`PacketID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_TV_Packet` FOREIGN KEY (`TVPacketID`) REFERENCES `tvpacket` (`PacketID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `internetpacket`
--
ALTER TABLE `internetpacket`
  ADD CONSTRAINT `FK_PacketID_Internet` FOREIGN KEY (`PacketID`) REFERENCES `packet` (`PacketID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tvpacket`
--
ALTER TABLE `tvpacket`
  ADD CONSTRAINT `FK_PacketTV` FOREIGN KEY (`PacketID`) REFERENCES `packet` (`PacketID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
