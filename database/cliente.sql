-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-11-2021 a las 17:08:25
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `mcsystem_pruebamc`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `idCliente` int(5) NOT NULL,
  `nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `app` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `apm` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `telefono` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `correo` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`idCliente`, `nombre`, `app`, `apm`, `telefono`, `correo`, `estatus`) VALUES
(1, 'Mostrtador', ' System', ' MC', '5569309482', 'contacto@mcsistem.com.mx', 1),
(2, 'Juan', 'Sanchez', ' Perez', '1512551', ' ', 1),
(3, 'Samanta', 'Tellez', 'Perez', '58236967', 'sams@gmail.com', 1),
(4, 'Jennifer', 'Morales', ' Rosas', '5510801566', 'jenni@gmail.com', 1),
(5, 'Steve', 'Hernandez', 'Jobs', '5625425552', 'jobs@apple.com', 1),
(6, 'Gilberto', 'Casas', 'Ramos', '85666', ' ', 1),
(7, 'Miriam', 'Hernandez', 'Pioquinto', '46484', ' miri@hotmail.com', 1),
(8, 'Romeo', 'Perez', 'Perez', '498498', ' ', 1),
(9, 'Salomon', 'Cuevas', 'Tellez', '45848649848', 'sal@gmail.com', 1),
(10, 'Maria Elena', 'Orozco', 'Gonzalez', '465165', 'oroc@gmail.com', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`idCliente`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `idCliente` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
