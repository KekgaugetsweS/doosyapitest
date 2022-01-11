-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2022 at 12:04 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `doploy-test`
--

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `id` varchar(255) CHARACTER SET latin1 NOT NULL,
  `firstname` varchar(255) CHARACTER SET latin1 DEFAULT NULL,
  `surname` varchar(255) CHARACTER SET latin1 DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `createdBy` varchar(255) CHARACTER SET latin1 DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  `status` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`id`, `firstname`, `surname`, `gender`, `createdBy`, `dateCreated`, `status`) VALUES
('', 'kg', 'sebati', 1, '2', '2022-01-11', 1),
('1', 'kg', 'sebati', 1, '2', '2022-01-11', 1),
('21', 'kg', 'sebati', 1, '2', '2022-01-11', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
