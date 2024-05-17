-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 05:32 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbmozaaapetshop`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbcart`
--

CREATE TABLE `tbcart` (
  `idCart` int(3) NOT NULL,
  `idRegis` int(3) NOT NULL,
  `KodeBarang` int(3) NOT NULL,
  `NamaBarang` text NOT NULL,
  `JumlahBarang` int(10) NOT NULL,
  `TotalHarga` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbcart`
--

INSERT INTO `tbcart` (`idCart`, `idRegis`, `KodeBarang`, `NamaBarang`, `JumlahBarang`, `TotalHarga`) VALUES
(55, 2, 1, 'Royal Canin', 2, 710000),
(56, 2, 9, 'Boneka CatNip', 1, 190000);

-- --------------------------------------------------------

--
-- Table structure for table `tborder`
--

CREATE TABLE `tborder` (
  `IdOrder` int(3) NOT NULL,
  `NamaPemesan` text NOT NULL,
  `KodeBarang` int(3) NOT NULL,
  `NamaBarang` text NOT NULL,
  `JumlahBarang` int(5) NOT NULL,
  `TotalHarga` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tborder`
--

INSERT INTO `tborder` (`IdOrder`, `NamaPemesan`, `KodeBarang`, `NamaBarang`, `JumlahBarang`, `TotalHarga`) VALUES
(20, 'sophy', 4, 'Pet Cargo', 1, 458900),
(21, 'wan', 4, 'Pet Cargo', 2, 917800),
(22, 'arinwi', 1, 'Royal Canin', 2, 710000),
(23, 'arinwi', 2, 'Bristle Brush', 1, 109000),
(24, 'arinwi', 2, 'Bristle Brush', 2, 218000),
(25, 'Nishikata', 5, 'Whiskas', 2, 100000),
(26, 'Nishikata', 6, 'Rumput Timothy', 1, 230000),
(27, 'sophy', 8, 'Vita Boost', 5, 2150000),
(28, 'wan', 4, 'Pet Cargo', 1, 458900);

-- --------------------------------------------------------

--
-- Table structure for table `tbpetshop`
--

CREATE TABLE `tbpetshop` (
  `KodeBarang` int(3) NOT NULL,
  `NamaBarang` text NOT NULL,
  `JenisBarang` text NOT NULL,
  `JenisHewan` text NOT NULL,
  `JumlahStok` int(11) NOT NULL,
  `Harga` int(11) NOT NULL,
  `Status` text NOT NULL,
  `TahunExp` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbpetshop`
--

INSERT INTO `tbpetshop` (`KodeBarang`, `NamaBarang`, `JenisBarang`, `JenisHewan`, `JumlahStok`, `Harga`, `Status`, `TahunExp`) VALUES
(1, 'Royal Canin', 'Makanan', 'Kucing, Anjing', 48, 355000, 'Ready', '2028'),
(2, 'Bristle Brush', 'Umum', 'Kucing', 32, 109000, 'Ready', '-'),
(3, 'serr', 'Makanan', 'Kelinci', 13, 1000000, 'Pre Order', '-'),
(4, 'Pet Cargo', 'Umum', 'Kelinci, Hamster', 7, 458900, 'Ready', '-'),
(5, 'Whiskas', 'Makanan', 'Kucing', 40, 50000, 'Ready', '2028'),
(6, 'Rumput Timothy', 'Makanan', 'Kelinci', 53, 230000, 'Ready', '2028'),
(7, 'Hamster Health', 'Suplemen', 'Hamster', 38, 400000, 'Ready', '2028'),
(8, 'Vita Boost', 'Suplemen', 'Kucing, Anjing', 10, 430000, 'Ready', '2029'),
(9, 'Boneka CatNip', 'Mainan', 'Kucing', 6, 190000, 'Pre Order', '-');

-- --------------------------------------------------------

--
-- Table structure for table `tbregis`
--

CREATE TABLE `tbregis` (
  `IdRegis` int(3) NOT NULL,
  `username` text NOT NULL,
  `email` text NOT NULL,
  `alamat` varchar(255) NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbregis`
--

INSERT INTO `tbregis` (`IdRegis`, `username`, `email`, `alamat`, `password`) VALUES
(1, 'sophy', 'sophyaw12@gmail.com', 'alam segar', '123'),
(2, 'Najwa', 'najwa1@gmail.com', 'belatuk', '12'),
(3, 'wan', 'wan@gmail.com', 'lobi D', '12'),
(4, 'Nishikata', 'Nishikata@gmail.com', 'Juanda', '12'),
(5, 'arinwi', 'arinwi@gmail.com', 'Jl. Rumah Saya', 'jagung');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbcart`
--
ALTER TABLE `tbcart`
  ADD PRIMARY KEY (`idCart`),
  ADD KEY `idRegis` (`idRegis`);

--
-- Indexes for table `tborder`
--
ALTER TABLE `tborder`
  ADD PRIMARY KEY (`IdOrder`),
  ADD KEY `KodeBarang` (`KodeBarang`);

--
-- Indexes for table `tbpetshop`
--
ALTER TABLE `tbpetshop`
  ADD PRIMARY KEY (`KodeBarang`);

--
-- Indexes for table `tbregis`
--
ALTER TABLE `tbregis`
  ADD PRIMARY KEY (`IdRegis`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbcart`
--
ALTER TABLE `tbcart`
  MODIFY `idCart` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT for table `tborder`
--
ALTER TABLE `tborder`
  MODIFY `IdOrder` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `tbregis`
--
ALTER TABLE `tbregis`
  MODIFY `IdRegis` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
