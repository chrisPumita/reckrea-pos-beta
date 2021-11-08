using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    class CONSULTA_Ventas : CONEXION
    {
        MySqlCommand cmd; //DICE COMO VA A PREGUNTAR
        MySqlDataReader reader;
        public bool guardaActualizaTicket(DETAILS_Ticket Ticket, int opc)
        {
            bool bandera = false;
            string insert = "INSERT INTO `ticket_vta` (`idTicket`, `idCliente_fk`, `idEmpleado_fk`, `fechaHora`, `subtotal`, "+
                " `Descuento`, `iva`, `total`, `modoPago`, `Facturar`, `edoFactura`, `NoFactura`, `Estado`, `codigoTIcket`) " +
                " VALUES (NULL, '" + Ticket.Cliente.Id + "', '" + Ticket.Empleado.Id + "', '" + Ticket.FechaHora.ToString("yyyy-MM-dd HH:mm:ss") +
                "', '"+Ticket.Subtotal+"', '"+Ticket.Descuento+"', '"+Ticket.Iva+"', '"+(Ticket.Total+Ticket.Iva)+"', '"+Ticket.FormaPago+"', '"+Ticket.Facturar+
                "', '" + Ticket.EstadoFactura + "', '" + Ticket.NoFactura + "', '" + Ticket.EstatusTicket + "','" + Ticket.CodigoTicket + "')";
            string update = "UPDATE `ticket_vta` SET "+
                " `subtotal` = '" + Ticket.Subtotal + "', `descuento` = '" + Ticket.Descuento + "', `iva` = '" + Ticket.Iva + "', `total` = '" + Ticket.Total + "', `modoPago` = '" + Ticket.FormaPago + "', `facturar` = '" + Ticket.Facturar
                + "', `edoFactura` = '" + Ticket.EstadoFactura + "', `noFactura` = '" + Ticket.NoFactura + "', `estado` = '" + Ticket.EstatusTicket + "' WHERE `ticket_vta`.`idTicket` = " +Ticket.IdTicket;
            
            string sSQL = opc == 1 ? insert : update;
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
                MessageBox.Show("ERROR AL PROCESAR AL TICKET " + ex.ToString());
            }
            return bandera;
        }

        public bool agregaDetalles(DETAILS_Ticket ticketData,string tipo)
        {
            bool bandera = false;
            string sSQL = "";
            switch (tipo)
            {
                case "VENTA":
                    sSQL = "INSERT INTO `detalle_vta` (`idDetalle_vta`, `idTicket_fk`, `idProducto_fk`, `Cantidad`, `costoU`, `Descuento`, `subtotal`)  VALUES  ";
                    for (int i = 0; i < ticketData.ListaDetalles.Count; i++)
                    {
                        sSQL += " (NULL, '" + ticketData.IdTicket + "', '" + ticketData.ListaDetalles[i].Producto.IdProducto + "', '"
                            + ticketData.ListaDetalles[i].Cantidad + "', '" + ticketData.ListaDetalles[i].Producto.PrecioVenta + "', '"
                            + ticketData.ListaDetalles[i].Producto.Descuento + "', '" + ticketData.ListaDetalles[i].Subtotal + "')";
                        if (i + 1 < (ticketData.ListaDetalles.Count))
                            sSQL += ", ";
                    }
                    break;
                case "SERVICIO":
                    sSQL = "INSERT INTO `orden_serivicio` (`idOrdenServicio`, `idTicket_fk`, `idEquipo_fk`, `reporte_cliente`, `diagnositco_tecnico`, `fechaIngreso`, `fechaEntregaEstimada`, `fechaTerminoCancel`, `FechaEntregaFinal`, `notas`, `notasOcultas`, `estado_service`) VALUES  ";
                    
                    for (int i = 0; i < ticketData.ListaOrdenesServicios.Count; i++)
                    {
                        
                        sSQL += " (NULL,  '" + ticketData.IdTicket + "', '" + ticketData.ListaOrdenesServicios[i].Equipo.IdEquipo + "', '" + ticketData.ListaOrdenesServicios[i].Reporte_cliente + "', '', '" + ticketData.ListaOrdenesServicios[i].FechaIngreso.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + ticketData.ListaOrdenesServicios[i].FechaEntregaEstimada.ToString("yyyy-MM-dd HH:mm:ss") + "', NULL, NULL, '" + ticketData.ListaOrdenesServicios[i].Notas + "', '" + ticketData.ListaOrdenesServicios[i].NotasOcultas + "', '1' )";
                        if (i + 1 < (ticketData.ListaOrdenesServicios.Count))
                            sSQL += ", ";
                    }
                    break;
                default:
                    MessageBox.Show("ERROR AL GUARDAR LAS ORDENES DE SERVICIO");
                    break;
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

        public bool updateDetallesVta(DETAIL_producto p, int operacion, int noTIcket)
        {
            bool bandera = false;
            string update = "UPDATE `detalle_vta` SET `cantidad` = '" + p.Cantidad + "', `descuento` = '" + (p.Cantidad *  p.Producto.Descuento)
                + "', `subtotal` = '" + (p.Cantidad * (p.Producto.PrecioVenta - p.Producto.Descuento)) + "' WHERE `detalle_vta`.`idDetalle_vta` = " + p.IdMovDetalleProducto + "  ";
            string insert = " INSERT INTO `detalle_vta` (`idDetalle_vta`, `idTicket_fk`, `idProducto_fk`, `cantidad`, `costoU`, `descuento`, `subtotal`) VALUES "+
                " (NULL, '" + noTIcket + "', '" + p.Producto.IdProducto + "', '" + p.Cantidad + "', '" + p.Producto.PrecioVenta + "', '" + p.Producto.Descuento + "', '" + p.Subtotal + "') ";
            
            string sSQL = operacion == 1 ? insert : update;
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
                MessageBox.Show("ERROR AL PROCESAR EL PRODUCTO " + ex.ToString());
            }
            return bandera;
        }


        public bool eliminaDetalleVenta(int noOPeracion)
        {
            bool bandera = false;
            string sSQL ="DELETE FROM `detalle_vta` WHERE `detalle_vta`.`idDetalle_vta` = " + noOPeracion;
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
                MessageBox.Show("ERROR AL PROCESAR EL PRODUCTO " + ex.ToString());
            }
            return bandera;
        }
        /// 
        /// 

        public bool addCargoAbono()
        {
            bool bandera = false;
            string sSQL = "INSERT";

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
                MessageBox.Show("ERROR AL PROCESAR AL EMPELADO " + ex.ToString());
            }
            return bandera;
        }

        public int getUltimoID(string table)
        {
            string SSQL = "";
            int id = 0;
            switch (table)
            {
                case "VENTA":
                    SSQL = "SELECT MAX(`idTicket`) AS ULTIMO FROM `ticket_vta` ";
                    break;
                case "SERVICIO":
                    SSQL = "SELECT MAX(`idTicket`) AS ULTIMO FROM `ticket_vta` ";
                    break;
                default:
                    break;

            }

            Cn.Open();
            cmd = new MySqlCommand(SSQL, Cn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetString("ULTIMO"));
                }
            }
            Cn.Close();
            return id;
        }

        public DETAILS_Ticket ConsultaTicket(int idTicket)
        {
            DETAILS_Ticket tmpObj = null;
            //Haciendo la consulta del ticket
            try
            {
                string query = "SELECT * FROM `ticket_vta` WHERE `ticket_vta`.`idTicket` = " + idTicket;
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = {   reader.GetString("idTicket"), //0
                                           reader.GetString("idCliente_fk"), //1
                                           reader.GetString("idEmpleado_fk"), //2
                                           reader.GetString("fechaHora"), //3
                                           reader.GetString("subtotal"), //4
                                           reader.GetString("descuento"), //5
                                           reader.GetString("iva"), //6
                                           reader.GetString("total"), //7
                                           reader.GetString("modopago"), //8
                                           reader.GetString("facturar"), //9
                                           reader.GetString("edoFactura"), //10
                                           reader.GetString("noFactura"), //11
                                           reader.GetString("estado"), //12
                                           reader.GetString("codigoTIcket") //13
                                       };

                        tmpObj = new DETAILS_Ticket();
                        tmpObj.IdTicket = Convert.ToInt32(row[0]);
                        CONSULTA_Personas people = new CONSULTA_Personas();
                        List<CLIENTE> listCLiente = new List<CLIENTE>();
                        listCLiente = people.ConsultaClientes("WHERE idCliente = " + row[1]);
                        tmpObj.Cliente = listCLiente[0];

                        List<EMPLEADO> listEmp = new List<EMPLEADO>();
                        listEmp = people.ConsultaEmpleados(" WHERE idEmpleado =" + row[2]);
                        tmpObj.Empleado = listEmp[0];

                        tmpObj.FechaHora = DateTime.Parse(row[3]);
                        tmpObj.Subtotal = Convert.ToDouble(row[4]);
                        tmpObj.Descuento =  Convert.ToDouble(row[5]);
                        tmpObj.Iva =  Convert.ToDouble(row[6]);
                        tmpObj.Total =Convert.ToDouble(row[7]);
                        tmpObj.FormaPago = Convert.ToInt32(row[8]);
                        tmpObj.Facturar =0;
                        tmpObj.EstadoFactura = 0;
                        tmpObj.NoFactura = Convert.ToInt32(row[11]);
                        tmpObj.EstatusTicket = 0;
                        tmpObj.CodigoTicket = row[13];
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return tmpObj;
        }


        /// SELECT `detalle_vta`.`cantidad`, `detalle_vta`.`costoU`, `detalle_vta`.`descuento`, `detalle_vta`.`subtotal`  FROM `detalle_vta`,  `producto` WHERE `producto`.`idProducto` = `detalle_vta`.`idProducto_fk` AND `detalle_vta`.`idTicket_fk` = 9


        public List<DETAIL_producto> ConsultaDetallestIcket(int idTicket)
        {
            List<DETAIL_producto> lsProductos = new List<DETAIL_producto>();
            DETAIL_producto tmpObj = null;
            //Haciendo la consulta del ticket
            try
            {
                string query = "SELECT   `producto`.`descripcion`, `detalle_vta`.`cantidad`, `detalle_vta`.`costoU`, `detalle_vta`.`descuento`, `detalle_vta`.`idDetalle_vta`, `detalle_vta`.`subtotal`  "+
                    "FROM `detalle_vta`,  `producto` WHERE `producto`.`idProducto` = `detalle_vta`.`idProducto_fk` AND `detalle_vta`.`idTicket_fk` =  " + idTicket;
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = {   reader.GetString("descripcion"), //0
                                           reader.GetString("cantidad"), //1
                                           reader.GetString("costoU"), //2
                                           reader.GetString("descuento"), //3
                                           reader.GetString("subtotal"), //4
                                           reader.GetString("idDetalle_vta") //5
                                       };

                        tmpObj = new DETAIL_producto();
                        PRODUCTO p = new PRODUCTO();
                        tmpObj.Producto = p;
                        tmpObj.Producto.Descripcion = row[0];
                        tmpObj.Cantidad = Convert.ToInt32(row[1]);
                        tmpObj.Producto.PrecioVenta = Convert.ToDouble(row[2]);
                        tmpObj.Producto.Descuento = Convert.ToDouble(row[3]);
                        tmpObj.Subtotal = Convert.ToDouble(row[4]);
                    tmpObj.IdMovDetalleProducto = Convert.ToInt32(row[5]);
                        lsProductos.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return lsProductos;
        }



        public List<DETAILS_Ticket> ConsultaTicket(string p)
        {

            CONSULTA_Personas people = new CONSULTA_Personas();

            List<DETAILS_Ticket> listObj = new List<DETAILS_Ticket>();
            List<CLIENTE> listClientes = new List<CLIENTE>();
            List<EMPLEADO> listEmpleados = new List<EMPLEADO>();

            listClientes =  people.ConsultaClientes(" ");
            listEmpleados = people.ConsultaEmpleados(" ");

            DETAILS_Ticket tmpObj = null;
            //Haciendo la consulta del ticket
            try
            {
                string query = "SELECT * FROM `ticket_vta`  "+p;
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string[] row = {   reader.GetString("idTicket"), //0
                                           reader.GetString("idCliente_fk"), //1
                                           reader.GetString("idEmpleado_fk"), //2
                                           reader.GetString("fechaHora"), //3
                                           reader.GetString("subtotal"), //4
                                           reader.GetString("descuento"), //5
                                           reader.GetString("iva"), //6
                                           reader.GetString("total"), //7
                                           reader.GetString("modopago"), //8
                                           reader.GetString("facturar"), //9
                                           reader.GetString("edoFactura"), //10
                                           reader.GetString("noFactura"), //11
                                           reader.GetString("estado"), //12
                                           reader.GetString("codigoTIcket") //13
                                       };

                        tmpObj = new DETAILS_Ticket();
                        tmpObj.IdTicket = Convert.ToInt32(row[0]);
                        //_EQUIPOS.Find(x => x.IdEquipo == idEquipo);
                        tmpObj.Cliente = listClientes.Find(x => x.Id == Convert.ToInt32(row[1]));
                        tmpObj.Empleado = listEmpleados.Find(x=>x.Id == Convert.ToInt32(row[2]));
                        tmpObj.FechaHora = DateTime.Parse(row[3]);
                        tmpObj.Subtotal = Convert.ToDouble(row[4]);
                        tmpObj.Descuento = Convert.ToDouble(row[5]);
                        tmpObj.Iva = Convert.ToDouble(row[6]);
                        tmpObj.Total = Convert.ToDouble(row[7]);
                        tmpObj.FormaPago = Convert.ToInt32(row[8]);
                        tmpObj.Facturar = 0;
                        tmpObj.EstadoFactura = 0;
                        tmpObj.NoFactura = Convert.ToInt32(row[11]);
                        tmpObj.EstatusTicket = Convert.ToInt32(row[12]);
                        tmpObj.CodigoTicket = row[13];
                        listObj.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la consulta de ventas" + ex.ToString());
            }
            return listObj;
        }
    }
}
