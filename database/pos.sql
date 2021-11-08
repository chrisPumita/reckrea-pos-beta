-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-11-2021 a las 17:19:21
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
-- Estructura de tabla para la tabla `bitacora`
--

CREATE TABLE `bitacora` (
  `idBitacora` int(5) NOT NULL,
  `idOrdenServicio_fk` int(5) NOT NULL,
  `horaFecha` datetime NOT NULL,
  `descripcion` text COLLATE utf8_unicode_ci NOT NULL,
  `empleado` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `visible` tinyint(2) NOT NULL DEFAULT '1',
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cargo_abono`
--

CREATE TABLE `cargo_abono` (
  `idPago` int(5) NOT NULL,
  `idTicket_fk` int(5) NOT NULL,
  `idCorteCaja_fk` int(5) NOT NULL,
  `t_pago` tinyint(2) NOT NULL,
  `total_pago` decimal(10,2) NOT NULL DEFAULT '0.00',
  `fechaHora` datetime NOT NULL,
  `concepto` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `formaPago` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `idCategoria` int(5) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`idCategoria`, `nombre`, `estatus`) VALUES
(5, 'Periférico', 1),
(6, 'Consumible', 1),
(7, 'Alacenamiento', 1),
(8, 'Laptop', 1),
(9, 'Monitor', 1),
(10, 'PC', 1),
(11, 'Redes', 1),
(12, 'Bateria', 1),
(13, 'Impresora', 1),
(14, 'Cable', 1);

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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `corte_caja`
--

CREATE TABLE `corte_caja` (
  `idCorte` int(5) NOT NULL,
  `idEmpleado_FK` int(5) NOT NULL,
  `fechaHoraInicio` datetime NOT NULL,
  `fechaHoraFin` datetime DEFAULT NULL,
  `saldoInicial` decimal(10,2) NOT NULL DEFAULT '0.00',
  `saldoFinal` decimal(10,2) NOT NULL DEFAULT '0.00',
  `edoSesion` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cupon`
--

CREATE TABLE `cupon` (
  `idCupon` int(5) NOT NULL,
  `idPromo_fk` int(5) NOT NULL,
  `idTicket_fk` int(5) NOT NULL,
  `descuento` decimal(10,2) NOT NULL,
  `porcentaje` decimal(4,2) NOT NULL,
  `fechaCreacion` datetime NOT NULL,
  `fechaAplicacion` datetime DEFAULT NULL,
  `estatus` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `datosfiscales`
--

CREATE TABLE `datosfiscales` (
  `idDireccion` int(5) NOT NULL,
  `idCliente` int(5) NOT NULL,
  `razon` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `calle` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `noInt` varchar(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT '',
  `noExt` varchar(10) COLLATE utf8_unicode_ci DEFAULT 'NA',
  `colonia` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `del-mun` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `entidad` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `rfc` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `datosfiscales`
--

INSERT INTO `datosfiscales` (`idDireccion`, `idCliente`, `razon`, `calle`, `noInt`, `noExt`, `colonia`, `del-mun`, `entidad`, `rfc`) VALUES
(1, 1, 'Mc System', 'Montes de Oca', 'NA', '2', 'Juarez', 'Nicolas Romero', 'Estado de Mexico', 'MCS655'),
(2, 2, 'CONPUTADRA JN', 'Nardos', 'NA', '13', 'Colmena', 'Nicolas Romero', 'Estado de Mexico', 'JAN4154'),
(3, 7, 'Kinder Garden', 'Villa Victoria', 'NA', '8', 'Ajusco', 'Nicolas Romero', 'Estado de Mexico', 'JAN41545165'),
(7, 9, 'SALMONES SA', 'Peces Frescos', 'NA', '12', 'Tepito', 'Cuautemoc', 'CDMX', 'SLSM545'),
(8, 5, 'APPLE COMPUTER', 'Copertino', 'NA', '15', 'Copertino', 'Los Angeles', 'Californa', 'SLSM5450000');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_serv`
--

CREATE TABLE `detalle_serv` (
  `idDetalle_serv` int(5) NOT NULL,
  `idOrdenServicio_fk` int(5) NOT NULL,
  `idServicio_fk` int(5) NOT NULL,
  `cantidad` double NOT NULL,
  `costoU` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `costoVariable` tinyint(2) NOT NULL DEFAULT '0',
  `detalles` varchar(150) COLLATE utf8_unicode_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `detalle_serv`
--

INSERT INTO `detalle_serv` (`idDetalle_serv`, `idOrdenServicio_fk`, `idServicio_fk`, `cantidad`, `costoU`, `descuento`, `subtotal`, `costoVariable`, `detalles`) VALUES
(1, 1, 1, 1, '100.00', '0.00', '100.00', 0, ''),
(2, 2, 1, 1, '100.00', '0.00', '100.00', 0, ''),
(3, 3, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(4, 3, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(5, 4, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(6, 5, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(7, 6, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(8, 7, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(9, 8, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(10, 9, 3, 1, '320.00', '0.00', '0.00', 0, ''),
(11, 9, 1, 1, '100.00', '0.00', '0.00', 0, ''),
(12, 9, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(13, 10, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(14, 10, 1, 1, '100.00', '0.00', '100.00', 0, ''),
(15, 10, 2, 1, '50.00', '50.00', '50.00', 0, ''),
(16, 11, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(17, 11, 1, 0, '100.00', '0.00', '0.00', 1, ''),
(18, 11, 2, 0, '50.00', '50.00', '0.00', 1, ''),
(19, 12, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(20, 13, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(21, 14, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(22, 15, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(23, 16, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(24, 17, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(25, 18, 2, 1, '50.00', '50.00', '0.00', 0, ''),
(28, 19, 3, 1, '100.00', '0.00', '100.00', 1, ''),
(29, 1, 3, 1, '320.00', '0.00', '320.00', 0, ''),
(33, 19, 1, 1, '100.00', '0.00', '100.00', 0, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_vta`
--

CREATE TABLE `detalle_vta` (
  `idDetalle_vta` int(5) NOT NULL,
  `idTicket_fk` int(5) NOT NULL,
  `idProducto_fk` int(5) NOT NULL,
  `cantidad` double NOT NULL,
  `costoU` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `detalle_vta`
--

INSERT INTO `detalle_vta` (`idDetalle_vta`, `idTicket_fk`, `idProducto_fk`, `cantidad`, `costoU`, `descuento`, `subtotal`) VALUES
(1, 3, 4, 9, '471.00', '5.00', '466.30'),
(2, 3, 10, 9, '400.00', '5.00', '2370.00'),
(3, 3, 7, 9, '300.00', '50.00', '250.00'),
(4, 3, 5, 9, '288.00', '20.00', '268.00'),
(5, 4, 10, 11, '400.00', '5.00', '1185.00'),
(6, 4, 4, 11, '471.00', '5.00', '1864.00'),
(7, 4, 7, 11, '300.00', '50.00', '500.00'),
(8, 4, 5, 11, '288.00', '20.00', '536.00'),
(9, 5, 4, 9, '471.00', '5.00', '1398.00'),
(10, 5, 10, 9, '400.00', '5.00', '1185.00'),
(11, 5, 7, 9, '300.00', '50.00', '250.00'),
(12, 5, 5, 9, '288.00', '20.00', '536.00'),
(13, 6, 10, 3, '400.00', '5.00', '1185.00'),
(14, 7, 4, 2, '471.00', '5.00', '932.00'),
(15, 8, 4, 8, '471.00', '5.00', '466.00'),
(16, 8, 10, 8, '400.00', '5.00', '1185.00'),
(17, 8, 7, 8, '300.00', '50.00', '1000.00'),
(18, 9, 10, 1, '400.00', '5.00', '395.00'),
(19, 10, 10, 5, '400.00', '5.00', '790.00'),
(20, 10, 4, 5, '471.00', '5.00', '1398.00'),
(21, 11, 10, 5, '400.00', '5.00', '1185.00'),
(22, 11, 4, 5, '471.00', '5.00', '932.00'),
(23, 12, 10, 6, '400.00', '5.00', '790.00'),
(24, 12, 4, 6, '471.00', '5.00', '1864.00'),
(25, 13, 10, 1, '400.00', '5.00', '395.00'),
(26, 14, 10, 3, '400.00', '5.00', '1185.00'),
(27, 15, 10, 4, '400.00', '5.00', '395.00'),
(28, 15, 4, 4, '471.00', '5.00', '1398.00'),
(29, 16, 10, 1, '400.00', '5.00', '395.00'),
(30, 17, 10, 2, '400.00', '5.00', '790.00'),
(31, 18, 4, 10, '471.00', '5.00', '1398.00'),
(32, 18, 10, 10, '400.00', '5.00', '2765.00'),
(33, 19, 4, 8, '471.00', '5.00', '932.00'),
(34, 19, 10, 8, '400.00', '5.00', '2370.00'),
(35, 20, 9, 1, '14.00', '0.00', '14.00'),
(36, 30, 10, 1, '400.00', '5.00', '395.00'),
(37, 36, 5, 12, '288.00', '20.00', '804.00'),
(38, 36, 9, 12, '14.00', '0.00', '126.00'),
(39, 37, 4, 2, '471.00', '10.00', '461.00'),
(40, 37, 9, 2, '14.00', '0.00', '14.00'),
(41, 38, 10, 3, '400.00', '5.00', '395.00'),
(42, 38, 6, 3, '170.00', '0.00', '340.00'),
(43, 39, 11, 3, '120.00', '0.00', '240.00'),
(44, 39, 10, 3, '400.00', '5.00', '395.00'),
(45, 40, 5, 6, '288.00', '20.00', '536.00'),
(46, 40, 9, 6, '14.00', '0.00', '14.00'),
(47, 40, 10, 6, '400.00', '5.00', '1185.00'),
(48, 41, 9, 1, '14.00', '0.00', '14.00'),
(49, 41, 7, 1, '300.00', '50.00', '250.00'),
(50, 41, 5, 2, '288.00', '20.00', '536.00'),
(51, 41, 10, 4, '400.00', '5.00', '1580.00'),
(52, 42, 9, 2, '14.00', '0.00', '28.00'),
(53, 42, 7, 3, '300.00', '50.00', '750.00'),
(54, 46, 4, 1, '471.00', '10.00', '461.00'),
(55, 47, 4, 1, '471.00', '10.00', '461.00'),
(56, 48, 4, 1, '471.00', '10.00', '461.00'),
(64, 23, 6, 1, '170.00', '0.00', '170.00'),
(65, 23, 4, 1, '471.00', '10.00', '461.00'),
(66, 23, 4, 1, '471.00', '10.00', '461.00'),
(67, 23, 11, 1, '120.00', '0.00', '120.00'),
(89, 56, 7, 1, '300.00', '50.00', '250.00'),
(90, 56, 7, 1, '300.00', '50.00', '250.00'),
(91, 56, 10, 1, '400.00', '5.00', '395.00'),
(92, 56, 6, 1, '170.00', '0.00', '170.00'),
(93, 56, 11, 1, '120.00', '0.00', '120.00'),
(94, 56, 9, 1, '14.00', '0.00', '14.00'),
(95, 56, 7, 1, '300.00', '50.00', '250.00'),
(96, 56, 10, 1, '400.00', '5.00', '395.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `idEmpleado` int(5) NOT NULL,
  `nombre` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `app` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `apm` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `telefono` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `correo` varchar(50) DEFAULT NULL,
  `sexo` tinyint(2) NOT NULL,
  `nick` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `depto` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `fechaRegistro` datetime NOT NULL,
  `tipoCuenta` tinyint(2) NOT NULL,
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`idEmpleado`, `nombre`, `app`, `apm`, `telefono`, `correo`, `sexo`, `nick`, `password`, `depto`, `fechaRegistro`, `tipoCuenta`, `estatus`) VALUES
(1, 'Christian', 'Pioquinto', 'Hernández', '5565241529', 'christian.floppy@gmail.com', 0, 'chris', '4A7D1ED414474E4033AC29CCB8653D9B', 'Desarrollo', '2020-02-09 16:57:35', 0, 1),
(2, 'Jennifer', 'Morales', 'Rosas', '5512121212', 'jenni@gmail.com', 1, 'jenni', '4A7D1ED414474E4033AC29CCB8653D9B', 'Ventas', '2020-02-09 17:42:06', 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `equipo`
--

CREATE TABLE `equipo` (
  `idEquipo` int(5) NOT NULL,
  `idCliente_fk` int(5) NOT NULL,
  `categoria_fk` int(5) NOT NULL,
  `marca_fk` int(5) NOT NULL,
  `modelo` varchar(50) DEFAULT NULL,
  `no_serie` varchar(50) DEFAULT NULL,
  `fechaRegistro` datetime NOT NULL,
  `detalles` text NOT NULL,
  `estado` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `equipo`
--

INSERT INTO `equipo` (`idEquipo`, `idCliente_fk`, `categoria_fk`, `marca_fk`, `modelo`, `no_serie`, `fechaRegistro`, `detalles`, `estado`) VALUES
(1, 4, 8, 2, 'Pavilion G4', '', '2020-07-15 00:00:00', 'Color negra, 13\"', 1),
(2, 6, 13, 9, 'TX100', 'XXXXXX', '2020-07-16 00:00:00', '4 Tintas', 0),
(3, 9, 13, 1, 'MK3434', 'XXXXXX', '2020-10-27 00:00:00', '4 TINTAS', 1),
(4, 7, 10, 2, 'FDVD', 'XXXXXX', '2020-10-31 00:00:00', 'BN', 1),
(5, 3, 9, 5, 'VGF', 'XXXXXX', '2020-10-31 00:00:00', 'VGF', 1),
(6, 8, 8, 2, 'G41212', 'XXXXXX', '2020-11-07 00:00:00', 'PENTIUM 4 NEGRA', 1),
(7, 8, 7, 5, '256SS', 'XXXXXX', '2020-11-07 00:00:00', '1 TB', 1),
(8, 2, 12, 5, 'ADATA100', 'XXXXXX', '2020-11-07 00:00:00', '1 TB', 1),
(9, 5, 9, 2, 'LOHUBHJ', 'XXXXXX', '2020-11-07 00:00:00', '22\"', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marca`
--

CREATE TABLE `marca` (
  `idMarca` int(5) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `marca`
--

INSERT INTO `marca` (`idMarca`, `nombre`, `estatus`) VALUES
(1, 'Genius', 1),
(2, 'HP', 1),
(3, 'BesChoise', 1),
(4, 'MERCUSYS', 1),
(5, 'ADATA', 1),
(6, 'Logitec', 1),
(7, 'INNOVA', 1),
(8, 'Kingstong', 1),
(9, 'Epson', 1),
(10, 'LG', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `orden_serivicio`
--

CREATE TABLE `orden_serivicio` (
  `idOrdenServicio` int(5) NOT NULL,
  `idTicket_fk` int(5) NOT NULL,
  `idEquipo_fk` int(5) NOT NULL,
  `reporte_cliente` varchar(150) COLLATE utf8_unicode_ci NOT NULL,
  `diagnositco_tecnico` varchar(200) COLLATE utf8_unicode_ci DEFAULT 'Pendiente',
  `fechaIngreso` datetime NOT NULL,
  `fechaEntregaEstimada` datetime NOT NULL,
  `fechaTerminoCancel` datetime DEFAULT NULL,
  `FechaEntregaFinal` datetime DEFAULT NULL,
  `notas` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `notasOcultas` varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  `estado_service` tinyint(2) NOT NULL DEFAULT '1' COMMENT '0.Cancelado, 1 En servicio,2 En espera de entrega, 3, entregado'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `orden_serivicio`
--

INSERT INTO `orden_serivicio` (`idOrdenServicio`, `idTicket_fk`, `idEquipo_fk`, `reporte_cliente`, `diagnositco_tecnico`, `fechaIngreso`, `fechaEntregaEstimada`, `fechaTerminoCancel`, `FechaEntregaFinal`, `notas`, `notasOcultas`, `estado_service`) VALUES
(1, 23, 1, 'No enciende, tiene priblemas', 'Pendiente', '2020-07-15 15:46:34', '2020-07-30 09:00:00', '2020-11-21 17:53:37', '2020-11-21 17:40:38', 'Deja cargador \r\n', '', 3),
(2, 24, 2, 'Imprime borroso, se atoran las hojas', '', '2020-07-16 16:38:43', '2020-07-31 09:00:00', NULL, NULL, 'NO Deja cable \r\n', '', 0),
(3, 29, 2, 'Muy lenta', ' ', '2020-07-16 16:48:54', '2020-07-31 09:00:00', '2020-11-21 17:41:08', NULL, 'Requiere clave: *********\r\nDeja algun periferico: (especifique)', 'patitofeo', 3),
(4, 31, 1, 'La pila no funciona', '', '2020-07-17 17:21:59', '2020-08-12 09:00:00', NULL, NULL, 'NO Deja cargador \r\n', '', 3),
(5, 32, 1, 'NO enciende', ' ', '2020-07-17 18:41:10', '2020-08-01 09:00:00', '2020-11-21 17:53:42', '2020-11-21 17:42:31', 'Deja cargador \r\n', '', 3),
(6, 33, 2, 'Revision', ' ', '2020-07-17 18:48:30', '2020-08-01 09:00:00', NULL, NULL, 'Deja cable \r\n', '', 1),
(7, 34, 1, 'No enciende de nuevo', '', '2020-07-20 18:44:20', '2020-08-04 09:00:00', NULL, NULL, 'Deja cargador \r\n', '', 1),
(8, 35, 3, 'MANCHA LA IMPRESION', '', '2020-10-27 15:45:09', '2020-11-11 09:00:00', '2020-11-21 18:00:20', '2020-11-21 17:53:50', 'SIN CABLES', '', 2),
(9, 43, 4, 'SIN DETALLE', '', '2020-10-31 18:55:32', '2020-11-15 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\n', '', 1),
(10, 44, 3, 'X', '', '2020-10-31 19:01:08', '2020-11-15 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\n', '', 1),
(11, 45, 5, 'NO ENCIENDE', '', '2020-10-31 19:06:55', '2020-11-03 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\nDEJA CABLE \r\nREQUIERE CLAVE: ***********************\r\nDEJA ALGUN PERIFERICO: (ESPECI', 'Ingrese clave de sesión', 1),
(12, 49, 8, 'RESPALDO', '', '2020-11-07 16:28:41', '2020-11-22 09:00:00', '2020-11-21 18:00:42', '2020-11-21 18:01:11', 'DEJA CARGADOR \r\n', '', 3),
(13, 50, 4, 'NO PRENDE', '', '2020-11-07 16:32:55', '2020-11-22 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\n', '', 1),
(14, 51, 1, 'NO PRNEDE', '', '2020-11-07 16:35:18', '2020-11-22 09:00:00', NULL, NULL, 'REQUIERE CLAVE: ****\r\n', ' d d', 1),
(15, 52, 9, 'NO PRNEDE', '', '2020-11-07 16:47:29', '2020-11-22 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\n', '', 1),
(16, 53, 3, 'ERRORES', '', '2020-11-07 16:48:16', '2020-11-22 09:00:00', NULL, NULL, 'DEJA CARGADOR \r\n', '', 1),
(17, 54, 3, 'VFG', '', '2020-11-07 16:49:26', '2020-11-22 09:00:00', NULL, NULL, 'DEJA ALGUN PERIFERICO: (ESPECIFIQUE)', '', 1),
(18, 55, 1, 'NO PRN', '', '2020-11-07 16:50:47', '2020-11-22 09:00:00', '2020-11-21 17:53:19', '2020-11-21 17:46:00', 'DEJA ALGUN PERIFERICO: (ESPECIFIQUE)', '', 3),
(19, 56, 2, ' JDK', '', '2020-11-07 16:51:35', '2020-11-22 09:00:00', NULL, NULL, 'DEJA ALGUN PERIFERICO: (ESPECIFIQUE)', '', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `idProducto` int(5) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `codigoInterno` varchar(20) NOT NULL,
  `codigoBarra` varchar(50) DEFAULT NULL,
  `diasGarantia` int(5) NOT NULL DEFAULT '0',
  `precioCompra` decimal(10,2) NOT NULL,
  `precioVenta` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL DEFAULT '0.00',
  `stock` double NOT NULL DEFAULT '0',
  `fechaCaptura` datetime NOT NULL,
  `status` tinyint(2) NOT NULL,
  `categoria_fk` int(5) NOT NULL,
  `marca_fk` int(5) NOT NULL,
  `proveedor_fk` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`idProducto`, `descripcion`, `codigoInterno`, `codigoBarra`, `diasGarantia`, `precioCompra`, `precioVenta`, `descuento`, `stock`, `fechaCaptura`, `status`, `categoria_fk`, `marca_fk`, `proveedor_fk`) VALUES
(4, 'Cargador', '24EN204LKGZ', '111111', 30, '300.00', '471.00', '10.00', -1, '2020-01-19 12:14:11', 1, 11, 4, 3),
(5, 'PowerBank Green Litio PT100', '24EN20TZM6A', '7501943493940', 7, '200.00', '288.00', '20.00', -6, '2020-01-02 12:18:40', 1, 12, 5, 3),
(6, 'Mouse Alambrico DX100', '24EN20TWTE9', '7501031310012', 0, '100.00', '170.00', '0.00', 4, '2020-01-21 12:22:14', 1, 5, 1, 3),
(7, 'Teclado Alambico/numérico', '25EN20DBQAD', '15612511', 7, '150.00', '300.00', '50.00', 11, '2020-01-14 12:23:45', 1, 5, 6, 2),
(9, 'Laptop Dell', '24EN20HGRFF', '7501438310943', 0, '10.00', '14.00', '0.00', -11, '2020-01-24 13:42:23', 1, 10, 4, 2),
(10, 'Router Wireless N 300 Mbps', '24EN204KKISD', '222222', 30, '300.00', '400.00', '5.00', -8, '2020-01-25 18:09:49', 1, 11, 4, 3),
(11, 'Memoria 8GB Morada', '27EN20M1E6N', 'NA', 0, '100.00', '120.00', '0.00', 3, '2020-01-27 11:04:15', 1, 7, 8, 1),
(12, 'Memorua USB 16GB', '19NO20G9IW8', 'NA', 7, '20.00', '50.00', '0.00', 0, '2020-11-19 18:05:35', 1, 12, 2, 3),
(13, 'Monitor NA', '19NO203B9Q5', 'NA', 0, '50.00', '80.00', '0.00', 1, '2020-11-19 18:07:05', 1, 14, 10, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `promocion`
--

CREATE TABLE `promocion` (
  `idPromo` int(5) NOT NULL,
  `codigo` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `descripcion` text COLLATE utf8_unicode_ci NOT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFin` datetime NOT NULL,
  `cantidad` decimal(5,2) NOT NULL,
  `porcentaje` decimal(5,2) NOT NULL,
  `noCodigos` int(5) NOT NULL,
  `md5Code` text COLLATE utf8_unicode_ci NOT NULL,
  `estatus` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `idProveedor` int(5) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`idProveedor`, `nombre`, `estatus`) VALUES
(1, 'CompuGadget', 1),
(2, 'Plaza de la Tecnología', 1),
(3, 'COMPUcom', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE `servicio` (
  `idServicio` int(5) NOT NULL,
  `descripcion` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `codigoInterno` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `diasGarantia` int(4) NOT NULL DEFAULT '0',
  `precioLista` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL DEFAULT '0.00',
  `estatus` tinyint(2) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `servicio`
--

INSERT INTO `servicio` (`idServicio`, `descripcion`, `codigoInterno`, `diasGarantia`, `precioLista`, `descuento`, `estatus`) VALUES
(1, 'Instalaccion Office', 'OF20', 0, '100.00', '0.00', 1),
(2, 'Revisión', 'REV', 0, '50.00', '50.00', 1),
(3, 'Cambio Sistema (OFFICE + ANTIVURUS 1A)', 'OSC', 0, '320.00', '0.00', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sesion`
--

CREATE TABLE `sesion` (
  `idSesion` int(5) NOT NULL,
  `idCorteCaja_fk` int(5) NOT NULL,
  `fechaHoraInicio` datetime NOT NULL,
  `fechaHoraFin` datetime DEFAULT NULL,
  `IP_equipo` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `tipoSesion` tinyint(2) NOT NULL,
  `edoSesion` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_vta`
--

CREATE TABLE `ticket_vta` (
  `idTicket` int(5) NOT NULL,
  `idCliente_fk` int(5) NOT NULL,
  `idEmpleado_fk` int(5) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL,
  `iva` decimal(10,2) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `modoPago` tinyint(2) NOT NULL,
  `facturar` tinyint(1) NOT NULL DEFAULT '0',
  `edoFactura` tinyint(1) NOT NULL DEFAULT '0',
  `noFactura` varchar(15) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `estado` tinyint(1) NOT NULL,
  `codigoTIcket` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `ticket_vta`
--

INSERT INTO `ticket_vta` (`idTicket`, `idCliente_fk`, `idEmpleado_fk`, `fechaHora`, `subtotal`, `descuento`, `iva`, `total`, `modoPago`, `facturar`, `edoFactura`, `noFactura`, `estado`, `codigoTIcket`) VALUES
(1, 1, 1, '2020-02-11 10:56:42', '7100.00', '115.00', '0.00', '6985.00', 1, 0, 0, '0', 0, ''),
(2, 1, 1, '2020-02-11 21:48:58', '4818.00', '150.00', '747.00', '4668.00', 0, 1, 0, '0', 0, ''),
(3, 1, 1, '2020-02-11 21:53:53', '3459.00', '105.00', '0.00', '3354.00', 0, 0, 0, '0', 0, ''),
(4, 1, 1, '2020-02-11 22:06:26', '4260.00', '175.00', '653.60', '4085.00', 0, 1, 0, '0', 0, ''),
(5, 1, 1, '2020-02-11 22:10:28', '3489.00', '120.00', '539.04', '3908.04', 0, 1, 0, '0', 0, ''),
(6, 7, 1, '2020-02-11 22:17:34', '1200.00', '15.00', '189.60', '1374.60', 0, 1, 0, '0', 0, ''),
(7, 9, 1, '2020-02-11 22:19:19', '942.00', '10.00', '149.12', '1081.12', 0, 1, 0, '0', 0, ''),
(8, 7, 1, '2020-02-11 22:56:02', '2871.00', '220.00', '424.16', '3075.16', 3, 1, 0, '0', 0, ''),
(9, 9, 1, '2020-02-11 22:58:47', '400.00', '5.00', '63.20', '458.20', 0, 1, 0, '0', 0, ''),
(10, 7, 1, '2020-02-13 22:55:40', '2213.00', '25.00', '350.08', '2538.08', 0, 1, 0, '0', 0, ''),
(11, 7, 1, '2020-02-13 22:59:59', '2142.00', '25.00', '338.72', '2455.72', 0, 1, 0, '0', 0, ''),
(12, 7, 1, '2020-02-13 23:01:25', '2684.00', '30.00', '424.64', '3078.64', 0, 1, 0, '0', 0, ''),
(13, 7, 1, '2020-02-13 23:03:17', '400.00', '5.00', '63.20', '458.20', 0, 1, 0, '0', 0, ''),
(14, 1, 1, '2020-02-13 23:06:54', '1200.00', '15.00', '0.00', '1185.00', 0, 0, 0, '0', 0, ''),
(15, 7, 1, '2020-02-13 23:11:20', '1813.00', '20.00', '286.88', '2079.88', 0, 1, 0, '0', 0, ''),
(16, 7, 1, '2020-02-13 23:12:38', '400.00', '5.00', '63.20', '458.20', 0, 1, 0, '0', 0, ''),
(17, 7, 1, '2020-02-13 23:14:27', '800.00', '10.00', '126.40', '916.40', 0, 1, 0, '0', 0, ''),
(18, 7, 1, '2020-02-13 23:30:04', '4213.00', '50.00', '666.08', '4829.08', 0, 1, 0, '0', 0, ''),
(19, 5, 1, '2020-02-15 16:02:21', '3342.00', '40.00', '528.32', '3830.32', 3, 1, 0, '0', 0, ''),
(20, 1, 1, '2020-07-09 13:29:42', '14.00', '0.00', '0.00', '14.00', 0, 0, 0, '0', 0, 'VT850109H200'),
(21, 4, 1, '2020-07-15 15:09:21', '100.00', '0.00', '16.00', '132.00', 0, 0, 0, '0', 0, 'OS643315H200'),
(22, 4, 1, '2020-07-15 15:46:36', '100.00', '0.00', '16.00', '132.00', 0, 0, 0, '0', 0, 'OS744615H200'),
(23, 4, 1, '2020-07-15 15:46:36', '100.00', '0.00', '0.00', '1632.00', 0, 0, 0, '0', 0, 'OS817915H2022'),
(24, 6, 1, '2020-07-16 16:38:45', '100.00', '0.00', '16.00', '132.00', 0, 0, 0, '0', 0, 'OS197516H200'),
(25, 6, 1, '2020-07-16 16:46:45', '0.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'OS317416H200'),
(26, 6, 1, '2020-07-16 16:47:17', '0.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'OS391616H200'),
(27, 6, 1, '2020-07-16 16:47:33', '320.00', '50.00', '51.20', '422.40', 0, 0, 0, '0', 0, 'OS233016H200'),
(28, 6, 1, '2020-07-16 16:48:12', '320.00', '0.00', '51.20', '422.40', 0, 0, 0, '0', 0, 'OS965616H200'),
(29, 6, 1, '2020-07-16 16:48:55', '320.00', '50.00', '51.20', '422.40', 0, 0, 0, '0', 0, 'OS847416H200'),
(30, 1, 1, '2020-07-17 14:55:03', '400.00', '5.00', '0.00', '395.00', 0, 0, 0, '0', 0, 'VT027517H200'),
(31, 4, 1, '2020-07-17 17:22:00', '320.00', '0.00', '51.20', '422.40', 0, 0, 0, '0', 0, 'OS132317H200'),
(32, 4, 1, '2020-07-17 18:41:12', '0.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'OS489717H200'),
(33, 6, 1, '2020-07-17 18:48:32', '0.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'OS656417H200'),
(34, 4, 1, '2020-07-20 18:44:22', '0.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'OS443020H200'),
(35, 9, 1, '2020-10-27 15:45:10', '50.00', '0.00', '522.00', '972.00', 0, 0, 0, '0', 0, 'ORD101427K20'),
(36, 1, 1, '2020-10-29 15:06:02', '990.00', '60.00', '0.00', '930.00', 0, 0, 0, '0', 1, 'VT782829K200'),
(37, 1, 1, '2020-10-29 17:02:23', '485.00', '10.00', '0.00', '475.00', 0, 0, 0, '0', 1, 'VT562529K200'),
(38, 1, 1, '2020-10-29 17:21:03', '740.00', '5.00', '0.00', '735.00', 0, 0, 0, '0', 1, 'VT542029K200'),
(39, 1, 1, '2020-10-29 17:23:21', '640.00', '5.00', '0.00', '635.00', 0, 0, 0, '0', 1, 'VT375529K200'),
(40, 1, 1, '2020-10-29 17:25:08', '1790.00', '55.00', '0.00', '1735.00', 0, 0, 0, '0', 1, 'VT617129K200'),
(41, 1, 1, '2020-10-29 17:37:21', '2490.00', '110.00', '0.00', '2380.00', 0, 0, 0, '0', 1, 'VT881029K200'),
(42, 1, 1, '2020-10-29 17:40:51', '928.00', '150.00', '0.00', '778.00', 0, 0, 0, '0', 1, 'VT785029K200'),
(43, 7, 1, '2020-10-31 18:55:33', '470.00', '50.00', '0.00', '420.00', 0, 0, 0, '0', 0, 'ORD548631K20'),
(44, 9, 1, '2020-10-31 19:01:09', '470.00', '50.00', '0.00', '420.00', 0, 0, 0, '0', 0, 'ORD509731K20'),
(45, 3, 1, '2020-10-31 19:06:56', '470.00', '50.00', '0.00', '420.00', 0, 0, 0, '0', 0, 'ORD302131K20'),
(46, 1, 1, '2020-11-04 18:35:57', '471.00', '10.00', '0.00', '461.00', 0, 0, 0, '0', 1, 'VT633904L200'),
(47, 1, 1, '2020-11-04 18:37:10', '471.00', '10.00', '0.00', '461.00', 0, 0, 0, '0', 1, 'VT800904L200'),
(48, 1, 1, '2020-11-04 18:39:05', '471.00', '10.00', '0.00', '461.00', 0, 0, 0, '0', 1, 'VT765004L200'),
(49, 2, 1, '2020-11-07 16:28:47', '320.00', '0.00', '0.00', '320.00', 0, 0, 0, '0', 0, 'ORD820107L20'),
(50, 7, 1, '2020-11-07 16:33:01', '50.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'ORD719807L20'),
(51, 4, 1, '2020-11-07 16:35:19', '50.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'ORD650107L20'),
(52, 5, 1, '2020-11-07 16:47:30', '50.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'ORD717707L20'),
(53, 9, 1, '2020-11-07 16:48:17', '320.00', '0.00', '0.00', '320.00', 0, 0, 0, '0', 0, 'ORD202507L20'),
(54, 9, 1, '2020-11-07 16:49:27', '320.00', '0.00', '0.00', '320.00', 0, 0, 0, '0', 0, 'ORD827807L20'),
(55, 4, 1, '2020-11-07 16:50:49', '50.00', '50.00', '0.00', '0.00', 0, 0, 0, '0', 0, 'ORD706707L20'),
(56, 6, 1, '2020-11-07 16:51:36', '1884.00', '160.00', '327.04', '2371.04', 0, 1, 0, '0', 0, 'ORD623307L20');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD PRIMARY KEY (`idBitacora`),
  ADD KEY `idOrdenServicio_fk` (`idOrdenServicio_fk`);

--
-- Indices de la tabla `cargo_abono`
--
ALTER TABLE `cargo_abono`
  ADD PRIMARY KEY (`idPago`),
  ADD KEY `idTicket_fk` (`idTicket_fk`),
  ADD KEY `idCorteCaja_fk` (`idCorteCaja_fk`);

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`idCategoria`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`idCliente`);

--
-- Indices de la tabla `corte_caja`
--
ALTER TABLE `corte_caja`
  ADD PRIMARY KEY (`idCorte`),
  ADD KEY `idEmpleado_FK` (`idEmpleado_FK`);

--
-- Indices de la tabla `cupon`
--
ALTER TABLE `cupon`
  ADD PRIMARY KEY (`idCupon`),
  ADD KEY `idPromo_fk` (`idPromo_fk`),
  ADD KEY `idTicket_fk` (`idTicket_fk`);

--
-- Indices de la tabla `datosfiscales`
--
ALTER TABLE `datosfiscales`
  ADD PRIMARY KEY (`idDireccion`),
  ADD KEY `idCliente` (`idCliente`);

--
-- Indices de la tabla `detalle_serv`
--
ALTER TABLE `detalle_serv`
  ADD PRIMARY KEY (`idDetalle_serv`),
  ADD KEY `idOrdenServicio_fk` (`idOrdenServicio_fk`),
  ADD KEY `idServicio_fk` (`idServicio_fk`);

--
-- Indices de la tabla `detalle_vta`
--
ALTER TABLE `detalle_vta`
  ADD PRIMARY KEY (`idDetalle_vta`),
  ADD KEY `idTicket_fk` (`idTicket_fk`),
  ADD KEY `idProducto_fk` (`idProducto_fk`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`idEmpleado`);

--
-- Indices de la tabla `equipo`
--
ALTER TABLE `equipo`
  ADD PRIMARY KEY (`idEquipo`),
  ADD KEY `idCliente_fk` (`idCliente_fk`),
  ADD KEY `categoria_fk` (`categoria_fk`),
  ADD KEY `marca_fk` (`marca_fk`);

--
-- Indices de la tabla `marca`
--
ALTER TABLE `marca`
  ADD PRIMARY KEY (`idMarca`);

--
-- Indices de la tabla `orden_serivicio`
--
ALTER TABLE `orden_serivicio`
  ADD PRIMARY KEY (`idOrdenServicio`),
  ADD KEY `idTicket_fk` (`idTicket_fk`),
  ADD KEY `idEquipo_fk` (`idEquipo_fk`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`idProducto`),
  ADD KEY `categoria_fk` (`categoria_fk`),
  ADD KEY `marca_fk` (`marca_fk`),
  ADD KEY `proveedor_fk` (`proveedor_fk`);

--
-- Indices de la tabla `promocion`
--
ALTER TABLE `promocion`
  ADD PRIMARY KEY (`idPromo`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`idProveedor`);

--
-- Indices de la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD PRIMARY KEY (`idServicio`);

--
-- Indices de la tabla `sesion`
--
ALTER TABLE `sesion`
  ADD PRIMARY KEY (`idSesion`),
  ADD KEY `idCorteCaja_fk` (`idCorteCaja_fk`);

--
-- Indices de la tabla `ticket_vta`
--
ALTER TABLE `ticket_vta`
  ADD PRIMARY KEY (`idTicket`),
  ADD KEY `idCliente_fk` (`idCliente_fk`),
  ADD KEY `idEmpleado_fk` (`idEmpleado_fk`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  MODIFY `idBitacora` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cargo_abono`
--
ALTER TABLE `cargo_abono`
  MODIFY `idPago` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `idCategoria` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `idCliente` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `corte_caja`
--
ALTER TABLE `corte_caja`
  MODIFY `idCorte` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `cupon`
--
ALTER TABLE `cupon`
  MODIFY `idCupon` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `datosfiscales`
--
ALTER TABLE `datosfiscales`
  MODIFY `idDireccion` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `detalle_serv`
--
ALTER TABLE `detalle_serv`
  MODIFY `idDetalle_serv` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT de la tabla `detalle_vta`
--
ALTER TABLE `detalle_vta`
  MODIFY `idDetalle_vta` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=97;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `idEmpleado` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `equipo`
--
ALTER TABLE `equipo`
  MODIFY `idEquipo` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `marca`
--
ALTER TABLE `marca`
  MODIFY `idMarca` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `orden_serivicio`
--
ALTER TABLE `orden_serivicio`
  MODIFY `idOrdenServicio` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `idProducto` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `promocion`
--
ALTER TABLE `promocion`
  MODIFY `idPromo` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `idProveedor` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `idServicio` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `sesion`
--
ALTER TABLE `sesion`
  MODIFY `idSesion` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ticket_vta`
--
ALTER TABLE `ticket_vta`
  MODIFY `idTicket` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD CONSTRAINT `bitacora_ibfk_1` FOREIGN KEY (`idOrdenServicio_fk`) REFERENCES `orden_serivicio` (`idOrdenServicio`);

--
-- Filtros para la tabla `cargo_abono`
--
ALTER TABLE `cargo_abono`
  ADD CONSTRAINT `cargo_abono_ibfk_1` FOREIGN KEY (`idCorteCaja_fk`) REFERENCES `corte_caja` (`idCorte`),
  ADD CONSTRAINT `cargo_abono_ibfk_2` FOREIGN KEY (`idTicket_fk`) REFERENCES `ticket_vta` (`idTicket`);

--
-- Filtros para la tabla `corte_caja`
--
ALTER TABLE `corte_caja`
  ADD CONSTRAINT `corte_caja_ibfk_1` FOREIGN KEY (`idEmpleado_FK`) REFERENCES `empleado` (`idEmpleado`);

--
-- Filtros para la tabla `cupon`
--
ALTER TABLE `cupon`
  ADD CONSTRAINT `cupon_ibfk_1` FOREIGN KEY (`idPromo_fk`) REFERENCES `promocion` (`idPromo`),
  ADD CONSTRAINT `cupon_ibfk_2` FOREIGN KEY (`idTicket_fk`) REFERENCES `ticket_vta` (`idTicket`);

--
-- Filtros para la tabla `datosfiscales`
--
ALTER TABLE `datosfiscales`
  ADD CONSTRAINT `datosFiscales_ibfk_1` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idCliente`);

--
-- Filtros para la tabla `detalle_serv`
--
ALTER TABLE `detalle_serv`
  ADD CONSTRAINT `detalle_serv_ibfk_1` FOREIGN KEY (`idServicio_fk`) REFERENCES `servicio` (`idServicio`),
  ADD CONSTRAINT `detalle_serv_ibfk_2` FOREIGN KEY (`idOrdenServicio_fk`) REFERENCES `orden_serivicio` (`idOrdenServicio`);

--
-- Filtros para la tabla `detalle_vta`
--
ALTER TABLE `detalle_vta`
  ADD CONSTRAINT `detalle_vta_ibfk_1` FOREIGN KEY (`idTicket_fk`) REFERENCES `ticket_vta` (`idTicket`),
  ADD CONSTRAINT `detalle_vta_ibfk_2` FOREIGN KEY (`idProducto_fk`) REFERENCES `producto` (`idProducto`);

--
-- Filtros para la tabla `equipo`
--
ALTER TABLE `equipo`
  ADD CONSTRAINT `equipo_ibfk_1` FOREIGN KEY (`idCliente_fk`) REFERENCES `cliente` (`idCliente`),
  ADD CONSTRAINT `equipo_ibfk_2` FOREIGN KEY (`categoria_fk`) REFERENCES `categoria` (`idCategoria`),
  ADD CONSTRAINT `equipo_ibfk_3` FOREIGN KEY (`marca_fk`) REFERENCES `marca` (`idMarca`);

--
-- Filtros para la tabla `orden_serivicio`
--
ALTER TABLE `orden_serivicio`
  ADD CONSTRAINT `orden_serivicio_ibfk_1` FOREIGN KEY (`idEquipo_fk`) REFERENCES `equipo` (`idEquipo`),
  ADD CONSTRAINT `orden_serivicio_ibfk_2` FOREIGN KEY (`idTicket_fk`) REFERENCES `ticket_vta` (`idTicket`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`proveedor_fk`) REFERENCES `proveedor` (`idProveedor`),
  ADD CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`categoria_fk`) REFERENCES `categoria` (`idCategoria`),
  ADD CONSTRAINT `producto_ibfk_3` FOREIGN KEY (`marca_fk`) REFERENCES `marca` (`idMarca`);

--
-- Filtros para la tabla `sesion`
--
ALTER TABLE `sesion`
  ADD CONSTRAINT `sesion_ibfk_1` FOREIGN KEY (`idCorteCaja_fk`) REFERENCES `corte_caja` (`idCorte`);

--
-- Filtros para la tabla `ticket_vta`
--
ALTER TABLE `ticket_vta`
  ADD CONSTRAINT `ticket_vta_ibfk_1` FOREIGN KEY (`idCliente_fk`) REFERENCES `cliente` (`idCliente`),
  ADD CONSTRAINT `ticket_vta_ibfk_2` FOREIGN KEY (`idEmpleado_fk`) REFERENCES `empleado` (`idEmpleado`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
