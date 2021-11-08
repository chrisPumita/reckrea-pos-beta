using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace McSystemOpenBuyProV2
{
    class CONSULTA_Servicio : CONEXION
    {
        MySqlCommand cmd; //DICE COMO VA A PREGUNTAR
        MySqlDataReader reader;

        List<CLIENTE> _CLIENTES;
        List<EMPLEADO> _EMPLEADOS;
        List<EQUIPO> _EQUIPOS;
        List<DETAILS_Ticket> _TICKET;
        List<OrdenServicio> _ORDENDES_SERVICE;
        List<SERVICIO> _SERVICIO; 

        //CRUD DE EQUIPO
        public List<EQUIPO> ConsultaEquipos(string filtro)
        {
            List<EQUIPO> _EQUIPOS = new List<EQUIPO>();
            EQUIPO tmpObj;
            try
            {
                string query = "SELECT * FROM `equipo`  " + filtro + " ORDER BY `equipo`.`fechaRegistro`  DESC ";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         * idEquipo	idCliente_fk	categoria_fk	marca_fk	Modelo	no_serie	fechaRegistro	detalles	estado
                         */
                        string[] row = {   reader.GetString("idEquipo"), //0
                                           reader.GetString("idCliente_fk"), //1
                                           reader.GetString("categoria_fk"), //2
                                           reader.GetString("marca_fk"), //3
                                           reader.GetString("Modelo"), //4
                                           reader.GetString("no_serie"), //5
                                           reader.GetString("fechaRegistro"), //6
                                           reader.GetString("detalles"), //7
                                           reader.GetString("estado") // 8
                                       };

                        tmpObj = new EQUIPO();
                        tmpObj.IdEquipo = Convert.ToInt32(row[0]);
                        tmpObj.IdClienteFk = Convert.ToInt32(row[1]);
                        tmpObj.IdCategoriaFk = Convert.ToInt32(row[2]);
                        tmpObj.IdMarcaFk = Convert.ToInt32(row[3]);
                        tmpObj.Modelo = row[4];
                        tmpObj.No_serie = row[5];
                        tmpObj.FechaRegistro = DateTime.Parse(row[6]);
                        tmpObj.Detalles = row[7];
                        tmpObj.Estado = Convert.ToInt32(row[8]) == 1 ? 1 : 0;

                        _EQUIPOS.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return _EQUIPOS;
        }

        //CRUD DE EQUIPO
        public EQUIPO ConsultaEquipo(int id)
        {
            EQUIPO tmpObj = new EQUIPO();
            try
            {
                string query = "SELECT * FROM `equipo`  WHERE idEquipo = " + id;
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         * idEquipo	idCliente_fk	categoria_fk	marca_fk	Modelo	no_serie	fechaRegistro	detalles	estado
                         */
                        string[] row = {   reader.GetString("idEquipo"), //0
                                           reader.GetString("idCliente_fk"), //1
                                           reader.GetString("categoria_fk"), //2
                                           reader.GetString("marca_fk"), //3
                                           reader.GetString("Modelo"), //4
                                           reader.GetString("no_serie"), //5
                                           reader.GetString("fechaRegistro"), //6
                                           reader.GetString("detalles"), //7
                                           reader.GetString("estado") // 8
                                       };

                        tmpObj = new EQUIPO();
                        tmpObj.IdEquipo = Convert.ToInt32(row[0]);
                        tmpObj.IdClienteFk = Convert.ToInt32(row[1]);
                        tmpObj.IdCategoriaFk = Convert.ToInt32(row[2]);
                        tmpObj.IdMarcaFk = Convert.ToInt32(row[3]);
                        tmpObj.Modelo = row[4];
                        tmpObj.No_serie = row[5];
                        tmpObj.FechaRegistro = DateTime.Parse(row[6]);
                        tmpObj.Detalles = row[7];
                        tmpObj.Estado = Convert.ToInt32(row[8]) == 1 ? 1 : 0;
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar equipo" + ex.ToString());
            }
            return tmpObj;
        }

        public bool AddUpdateEquipo(EQUIPO equipo, int opc)
        {
            bool bandera = false;
            try
            {
                equipo.No_serie = equipo.No_serie == "" ? "XXXXXX" : equipo.No_serie ;
                string insert = "INSERT INTO `equipo` (`idEquipo`, `idCliente_fk`, `categoria_fk`, `marca_fk`, `modelo`, `no_serie`, "+
                    " `fechaRegistro`, `detalles`, `estado`) VALUES "+
                    " (NULL, '" + equipo.IdClienteFk + "', '" + equipo.IdCategoriaFk + "', '" + equipo.IdMarcaFk + "', '" + equipo.Modelo +
                    "', '" + equipo.No_serie + "', '" + equipo.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + equipo.Detalles + "', '" + equipo.Estado + "')";
                string update = "UPDATE `equipo` SET `idCliente_fk` = '" + equipo.IdClienteFk + "', `categoria_fk` = '" + equipo.IdCategoriaFk +
                    "', `marca_fk` = '" + equipo.IdMarcaFk + "', `modelo` = '" + equipo.Modelo + "', `no_serie` = '" + equipo.No_serie +
                    "', `detalles` = '" + equipo.Detalles + "', `estado` = '" + equipo.Estado + "' WHERE `equipo`.`idEquipo` = " + equipo.IdEquipo + " ";
                string query = opc == 1 ? insert : update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR EL EQUIPO " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update UPDATE INSERT de Equipo


        public List<OrdenServicio> ConsultaServiciosPanel(string filtro)
        {
            _ORDENDES_SERVICE = new List<OrdenServicio>();
            OrdenServicio tmpObj;
            try
            {
                string query = "SELECT  `orden_serivicio`.`idOrdenServicio` , `ticket_vta`.`codigoTIcket`, CONCAT(`cliente`.`nombre`,' ', `cliente`.`app`,' ',`cliente`.`apm`) AS nameCLIENTE, " +
                    " CONCAT(`categoria`.`nombre`,' ', `marca`.`nombre`,' ', `equipo`.`modelo`,' ', `equipo`.`detalles`) AS detalles, `orden_serivicio`.`reporte_cliente`, "+
                    " `orden_serivicio`.`fechaIngreso`, `orden_serivicio`.`estado_service` FROM `ticket_vta`, `orden_serivicio`,  cliente, `categoria`, `marca`,`equipo` " +
                    " WHERE " + filtro + " `orden_serivicio`.`idTicket_fk` = `ticket_vta`.`idTicket` AND `cliente`.`idCliente` = `ticket_vta`.`idCliente_fk` AND `marca`.`idMarca` = `equipo`.`marca_fk` AND `orden_serivicio`.`idEquipo_fk` = `equipo`.`idEquipo` AND `categoria`.`idCategoria` = `equipo`.`categoria_fk` ORDER BY `orden_serivicio`.`fechaIngreso` DESC  ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tmpObj = new OrdenServicio();
                        DETAILS_Ticket tk = new DETAILS_Ticket();
                        tk.CodigoTicket = reader.GetString("codigoTIcket");
                        CLIENTE c = new CLIENTE();
                        c.Nombre = reader.GetString("nameCLIENTE");
                        tk.Cliente = c; 
                        tmpObj.Ticket = tk;
                        EQUIPO eq = new EQUIPO();
                        eq.Detalles = reader.GetString("detalles");
                        tmpObj.Equipo = eq;
                        tmpObj.Reporte_cliente = reader.GetString("reporte_cliente");
                        tmpObj.FechaIngreso = DateTime.Parse(reader.GetString("fechaIngreso"));
                        tmpObj.IdOrdenServicio =Convert.ToInt32(reader.GetString("idOrdenServicio"));
                        tmpObj.Estado_service = Convert.ToInt32(reader.GetString("estado_service"));

                        _ORDENDES_SERVICE.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return _ORDENDES_SERVICE;
        }

        public OrdenServicio ConsultaOrdenServicioDetalles(string NoTicketOrden)
        {

            OrdenServicio order = null;
            try
            {
                string query = "SELECT `cliente`.`idCliente`, `cliente`.`telefono`,  `cliente`.`correo`, CONCAT(`cliente`.`nombre`,' ', `cliente`.`app`,' ',`cliente`.`apm`) AS nameCLIENTE, "+
                    "  `empleado`.`idEmpleado`,  CONCAT(`empleado`.`nombre`,' ', `empleado`.`app`) AS nameEMPLEADO,  `orden_serivicio`.`idOrdenServicio`, "+
                    " `orden_serivicio`.`reporte_cliente`,  `orden_serivicio`.`notas`, `orden_serivicio`.`fechaIngreso`,  `orden_serivicio`.`fechaEntregaEstimada`, "+
                    "  `orden_serivicio`.`estado_service`,  `orden_serivicio`.`fechaTerminoCancel`,  `orden_serivicio`.`FechaEntregaFinal` ,  `orden_serivicio`.`notasOcultas`,  `orden_serivicio`.`diagnositco_tecnico`,  "+
                    "   `ticket_vta`.`codigoTIcket`,`ticket_vta`.`idTicket`, `ticket_vta`.`subtotal`, `ticket_vta`.`descuento` ,  `ticket_vta`.`iva` ,`ticket_vta`.`total`, `ticket_vta`.`facturar`, "+
                    " `equipo`.`idEquipo`,  `equipo`.`no_serie`, CONCAT(`categoria`.`nombre`, ' ',`marca`.`nombre`,' ', `equipo`.`modelo`) AS equipo, " +
                    " `equipo`.`detalles` FROM  `ticket_vta`, `orden_serivicio`, `categoria`, `marca`,`equipo`, `cliente`, `empleado` "+
                    " WHERE `orden_serivicio`.`idTicket_fk` =  `ticket_vta`.`idTicket` AND `marca`.`idMarca` = `equipo`.`marca_fk` "+
                    " AND `orden_serivicio`.`idEquipo_fk` = `equipo`.`idEquipo`  AND `cliente`.`idCliente` = `ticket_vta`.`idCliente_fk` "+
                    " AND `categoria`.`idCategoria` =  `equipo`.`categoria_fk` AND `empleado`.`idEmpleado`  = `ticket_vta`.`idEmpleado_fk` "+
                    " AND `ticket_vta`.`codigoTIcket` = '" + NoTicketOrden + "' ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EQUIPO eq = new EQUIPO();
                        eq.IdEquipo = Convert.ToInt32(reader.GetString("idEquipo"));
                        eq.No_serie = reader.GetString("no_serie");
                        eq.MarcaName = reader.GetString("equipo");
                        eq.Detalles = reader.GetString("detalles");

                        CLIENTE c = new CLIENTE();
                        //Llenando los datos del cliente
                        c.Id = Convert.ToInt32(reader.GetString("idCliente"));
                        c.Nombre = reader.GetString("nameCLIENTE");
                        c.Telefono = reader.GetString("telefono");
                        c.Correo = reader.GetString("correo");

                        //llenando datos del empleado
                        EMPLEADO e = new EMPLEADO();
                        e.Id = Convert.ToInt32(reader.GetString("idEmpleado"));
                        e.Nombre = reader.GetString("nameEMPLEADO");

                        DETAILS_Ticket tk = new DETAILS_Ticket();
                        //llenando info de la orden de del ticket
                        tk.CodigoTicket = reader.GetString("codigoTIcket");
                        tk.IdTicket = Convert.ToInt32(reader.GetString("idTicket"));
                        tk.Subtotal = Convert.ToDouble(reader.GetString("subtotal"));
                        tk.Descuento = Convert.ToDouble(reader.GetString("descuento"));
                        tk.Iva = Convert.ToDouble(reader.GetString("iva"));
                        tk.Total = Convert.ToDouble(reader.GetString("total"));
                        tk.Facturar = reader.GetString("facturar")== "1" ? 1:0;

                        tk.Cliente = c;
                        tk.Empleado = e;

                        order = new OrdenServicio();
                        order.IdOrdenServicio = Convert.ToInt32(reader.GetString("idOrdenServicio"));
                        order.Reporte_cliente = reader.GetString("reporte_cliente");
                        order.Notas = reader.GetString("notas");
                        order.FechaIngreso = DateTime.Parse(reader.GetString("fechaIngreso"));
                        order.FechaEntregaEstimada = DateTime.Parse(reader.GetString("fechaEntregaEstimada"));
 
                        order.Estado_service = Convert.ToInt32(reader.GetString("estado_service"));
                        if (order.Estado_service == 0 || order.Estado_service == 2)
                        {
                            try
                            {
                                order.FechaTerminoCancel = DateTime.Parse(reader.GetString("fechaTerminoCancel"));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex);
                            }
                        }

                        if ( order.Estado_service == 3)
                        {
                            try
                            {
                                order.FechaEntregaFinal1 = DateTime.Parse(reader.GetString("FechaEntregaFinal"));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("" + ex);
                            }
                        }
                        order.NotasOcultas = reader.GetString("notasOcultas");
                        order.Diagnositco_tecnico = reader.GetString("diagnositco_tecnico");
                        order.Equipo = eq;
                        order.Ticket = tk;

                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return order;
        }



        public List<OrdenServicio> ConsultaOrdenesServicios(string filtro)
        {
            _ORDENDES_SERVICE = new List<OrdenServicio>();

            CONSULTA_Ventas conTk = new CONSULTA_Ventas();
            CONSULTA_Servicio conEquipo = new CONSULTA_Servicio();
            _EQUIPOS = conEquipo.ConsultaEquipos(" ");
            _TICKET = conTk.ConsultaTicket(" ");
            OrdenServicio tmpObj;
            try
            {
                string query = "SELECT * FROM `orden_serivicio` " + filtro + " ORDER BY `orden_serivicio`.`fechaIngreso` DESC ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        

                        tmpObj = new OrdenServicio();
                        tmpObj.IdOrdenServicio = Convert.ToInt32(reader.GetString("idOrdenServicio"));
                       
                        int IDTIcker = Convert.ToInt32(reader.GetString("idTicket_fk"));
                        tmpObj.Ticket = conTk.ConsultaTicket(IDTIcker);
                        int idEquipo = Convert.ToInt32(reader.GetString("idEquipo_fk"));
                        tmpObj.Equipo = _EQUIPOS.Find(x => x.IdEquipo == idEquipo);

                        tmpObj.Reporte_cliente = reader.GetString("reporte_cliente");
                        tmpObj.Diagnositco_tecnico = reader.GetString("diagnositco_tecnico")== null ? "NA" : reader.GetString("diagnositco_tecnico");
                        tmpObj.FechaIngreso = DateTime.Parse(reader.GetString("fechaIngreso"));
                        tmpObj.FechaEntregaEstimada = DateTime.Parse(reader.GetString("fechaIngreso"));
                        try
                        { tmpObj.FechaTerminoCancel = DateTime.Parse(reader.GetString("fechaTerminoCancel"));}
                        catch (Exception e)
                        { tmpObj.FechaTerminoCancel = DateTime.Parse("2000-01-01 00:00:00"); }

                        try
                        { tmpObj.FechaEntregaFinal1 = DateTime.Parse(reader.GetString("fechaEntregaFinal")); }
                        catch (Exception e)
                        { tmpObj.FechaEntregaFinal1 = DateTime.Parse("2000-01-01 00:00:00"); }

                        tmpObj.Notas = reader.GetString("notas");
                        tmpObj.NotasOcultas = reader.GetString("notasOcultas");

                        tmpObj.Estado_service = Convert.ToInt32(reader.GetString("estado_service"));

                        _ORDENDES_SERVICE.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return _ORDENDES_SERVICE;
        }


        //CRUD DE EQUIPO
        public List<SERVICIO> ConsultaServicios(string filtro)
        {
           _SERVICIO = new List<SERVICIO>();
            SERVICIO tmpObj;
            try
            {
                string query = "SELECT * FROM `servicio`   " + filtro + " ORDER BY `servicio`.`descripcion` ASC ";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         * idServicio 	descripcion 	codigoInterno 	diasGarantia 	precioLista 	descuento 	estatus
                         */
                        string[] row = {   reader.GetString("idServicio"), //0
                                           reader.GetString("descripcion"), //1
                                           reader.GetString("codigoInterno"), //2
                                           reader.GetString("diasGarantia"), //3
                                           reader.GetString("precioLista"), //4
                                           reader.GetString("descuento"), //5
                                           reader.GetString("estatus") // 6
                                       };

                        tmpObj = new SERVICIO();
                        tmpObj.IdServicio = Convert.ToInt32(row[0]);
                        tmpObj.Descripcion = row[1];
                        tmpObj.CodigoInterno = row[2];
                        tmpObj.DiasGarantia = Convert.ToInt32(row[3]);
                        tmpObj.PrecioLista = Convert.ToDouble(row[4]);
                        tmpObj.Descuento = Convert.ToDouble(row[5]);
                        tmpObj.Estatus = Convert.ToInt32(row[6]);

                        _SERVICIO.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return _SERVICIO;
        }

        //CRUD DE EQUIPO
        public List<DETAILS_Servicio> ConsultaMisServicios(int idOrdenServicio)
        {
            List<DETAILS_Servicio> _LS_SERVICIO = new List<DETAILS_Servicio>();

            DETAILS_Servicio tmpObj;
            try
            {
                string query = "SELECT `detalle_serv`.`idDetalle_serv`, `detalle_serv`.`idServicio_fk`, `detalle_serv`.`cantidad`, `detalle_serv`.`costoU`, " +
                    " `detalle_serv`.`descuento` ,  `detalle_serv`.`subtotal` , `detalle_serv`.`costoVariable`,  `detalle_serv`.`detalles`, `servicio`.`descripcion` , " +
                    " `servicio`.`codigoInterno`,`servicio`.`diasGarantia` FROM `servicio` ,`detalle_serv` WHERE `detalle_serv`.`idServicio_fk`=`servicio`.`idServicio` "+
                    " AND `detalle_serv`.`idOrdenServicio_fk` = " + idOrdenServicio + " ORDER BY `detalle_serv`.`idServicio_fk` ASC ";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         * idServicio 	descripcion 	codigoInterno 	diasGarantia 	precioLista 	descuento 	estatus
                         */
                        string[] row = {   
                                        
                                        reader.GetString("idServicio_fk"), //0
                                        reader.GetString("cantidad"), //1
                                        reader.GetString("costoU"), //2
                                        reader.GetString("descuento"),//3
                                        reader.GetString("subtotal"), //4
                                        reader.GetString("costoVariable"), //5
                                        reader.GetString("detalles"), //6
                                        //DE SERVICIO
                                        reader.GetString("descripcion"), //7
                                        reader.GetString("codigoInterno"), //8
                                        reader.GetString("idDetalle_serv") // 9
                                       };

                        tmpObj = new DETAILS_Servicio();
                        SERVICIO serv = new SERVICIO();
                        serv.IdServicio = Convert.ToInt32(row[0]);
                        serv.CodigoInterno = row[8];
                        serv.Descripcion = row[7];
                        tmpObj.Servicio = serv;
                        //// details for obj added
                        tmpObj.Cantidad = Convert.ToDouble(row[1]);
                       tmpObj.CostoU = Convert.ToDouble(row[2]);
                       tmpObj.Desc = Convert.ToDouble(row[3]);
                       tmpObj.Subtotal = Convert.ToDouble(row[4]);
                       tmpObj.Detalles = row[6];
                       tmpObj.IdDetalle_serv = Convert.ToInt32(row[9]);

                       _LS_SERVICIO.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return _LS_SERVICIO;
        }




        public bool AddUpdateServicio(SERVICIO service, int opc)
        {
            bool bandera = false;
            try
            {
                string insert = "INSERT INTO `servicio` "+
                    " (`idServicio`, `descripcion`, `codigoInterno`, `diasGarantia`, `precioLista`, `descuento`, `estatus`) VALUES "+
                    " (NULL, '" + service.Descripcion + "', '" + service.CodigoInterno + "', '" + service.DiasGarantia + "', '" + service.PrecioLista + "', '" + service.Descuento + "', '" + service.Estatus + "');";
                string update = "UPDATE `servicio` SET "+
                    " `descripcion` = '" + service.Descripcion + "', `codigoInterno` = '" + service.CodigoInterno + "', `diasGarantia` = '" + service.DiasGarantia +
                    "', `precioLista` = '" + service.PrecioLista + "', `descuento` = '" + service.Descuento + "', `estatus` = '" + service.Estatus + "' WHERE `servicio`.`idServicio` = " + service.IdServicio + " ";
                string query = opc == 1 ? insert : update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR EL SERVICIO " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update UPDATE INSERT de Equipo



        public bool agregaDetalleServicios(DETAILS_Ticket ticketPrincipal)
        {
            bool bandera = false;
            string sSQL = "";
            List<OrdenServicio> listaOrdenes = new List<OrdenServicio>();
            for (int i = 0; i <  ticketPrincipal.ListaOrdenesServicios.Count; i++)
            {
                listaOrdenes.Add(ticketPrincipal.ListaOrdenesServicios[i]);
            }
            sSQL = "INSERT INTO `detalle_serv` (`idDetalle_serv`, `idOrdenServicio_fk`, `idServicio_fk`, `cantidad`, `costoU`, `descuento`, `subtotal`, `costoVariable`) VALUES  ";
            for (int i = 0; i < listaOrdenes.Count; i++)
            {
                for (int j = 0; j < listaOrdenes[i].ListaServiciosDetails.Count; j++)
                {
                    sSQL += " (NULL, '" + listaOrdenes[i].IdOrdenServicio + "', '" + listaOrdenes[i].ListaServiciosDetails[j].Servicio.IdServicio + "', '" + listaOrdenes[i].ListaServiciosDetails[j].Cantidad + "', '" + listaOrdenes[i].ListaServiciosDetails[j].Servicio.PrecioLista + "', '" + listaOrdenes[i].ListaServiciosDetails[j].Servicio.Descuento + "', '" + listaOrdenes[i].ListaServiciosDetails[j].Subtotal + "', '" + (0) + "')";
                    if (j + 1 < (listaOrdenes[i].ListaServiciosDetails.Count))
                        sSQL += ", ";
                }
            }

            try
            {
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL la orden " + ex.ToString());
            }
            return bandera;
        }

        public bool agregaUnDetalleServicio(DETAILS_Servicio servicioAdd, int idOrden)
        {
            bool bandera = false;
            string sSQL = "INSERT INTO `detalle_serv` (`idDetalle_serv`, `idOrdenServicio_fk`, `idServicio_fk`, `cantidad`, `costoU`, `descuento`, `subtotal`, `costoVariable`, `detalles`) "+
                " VALUES (NULL, '" + idOrden + "', '" + servicioAdd.Servicio.IdServicio + "', '" + servicioAdd.Cantidad + "', '" + servicioAdd.CostoU + "', '" + servicioAdd.Desc + "', '" + servicioAdd.Subtotal + "', '" + servicioAdd.PrecioVariable + "', '" + servicioAdd.Detalles + "') ";
            try
            {
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL la orden " + ex.ToString());
            }
            return bandera;
        }

        public bool BorraMovOrder(int noMov, int tipo)
        {
            //1 -_> Servicio 
            //2 --> Articulo
            bool bandera = false;
            string sSQLServicio = "DELETE FROM `detalle_serv` WHERE `detalle_serv`.`idDetalle_serv` =  " + noMov;
            string sSQLProducto = "";
            string sSQL = tipo == 1 ? sSQLServicio : sSQLProducto;
            try
            {
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL la orden " + ex.ToString());
            }
            return bandera;
        }

        /// <summary>
        /// DELETE FROM `detalle_serv` WHERE `detalle_serv`.`idDetalle_serv` = 1"
        /// </summary>
        /// <param name="detalleServ"></param>
        /// <returns></returns>

        public bool UpdateDetallesServicio(DETAILS_Servicio detalleServ)
        {
            bool bandera = false;
            try
            {
                string sql = "UPDATE `detalle_serv` SET `cantidad` = '" + detalleServ.Cantidad + "', `costoU` = '" + detalleServ.CostoU + "', `descuento` = '" + detalleServ.Desc +
                    "', `subtotal` = '" + detalleServ.Subtotal + "', `costoVariable` = '" + detalleServ.PrecioVariable + "', `detalles` = '" + detalleServ.Detalles +
                    "' WHERE `detalle_serv`.`idDetalle_serv` = " + detalleServ.IdDetalle_serv + " ";
                Cn.Open();
                cmd = new MySqlCommand(sql, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR EL DATO " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update UPDATE INSERT de Equipo




        public int[] GetIdsOrderServicios(DETAILS_Ticket ticket)
        {
            int[] ids = new int[ticket.ListaOrdenesServicios.Count];
            string SSQL = "SELECT `idOrdenServicio` AS ID FROM `orden_serivicio` WHERE `idTicket_fk` = " + ticket.IdTicket + "  ";

            Cn.Open();
            cmd = new MySqlCommand(SSQL, Cn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int contador = 0;
                while (reader.Read())
                {
                    ids[contador] = Convert.ToInt32(reader.GetString("ID"));
                    contador++;
                }
            }
            Cn.Close();
            return ids;
        }


        public bool ActualizaEstadoOrdenServicio(OrdenServicio orden, int estado)
        {
            bool bandera = false;
            try
            {
                string sSQL = "";
                switch (estado)
                {
                    case 0:
                        //El estado pasara a cancelado
                        sSQL = "UPDATE `orden_serivicio` SET `fechaTerminoCancel` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  + "',  `estado_service` = '0' WHERE `orden_serivicio`.`idOrdenServicio` =  "+orden.IdOrdenServicio;
                        break;
                    case 1:
                        //El estado pasara a cancelado
                        sSQL = "UPDATE `orden_serivicio` SET   `estado_service` = '1' WHERE `orden_serivicio`.`idOrdenServicio` =  " + orden.IdOrdenServicio;
                        break;
                    case 2:
                        //El estado pasara a terminado
                        sSQL = "UPDATE `orden_serivicio` SET `fechaTerminoCancel` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',  `estado_service` = '2' WHERE `orden_serivicio`.`idOrdenServicio` =  " + orden.IdOrdenServicio;
                        break;
                    case 3:
                        //El estado pasara a entregado
                        sSQL = "UPDATE `orden_serivicio` SET `fechaEntregaFinal` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',  `estado_service` = '3' WHERE `orden_serivicio`.`idOrdenServicio` =  " + orden.IdOrdenServicio;
                        break;
                    default:
                        break;
                }
                
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR EL SERVICIO " + ex.ToString());
            }
            return bandera;
        } // 




    }
}
