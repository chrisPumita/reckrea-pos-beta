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
    class CONSULTA_Inventario : CONEXION
    {
        MySqlCommand cmd; //DICE COMO VA A PREGUNTAR
        MySqlDataReader reader;

        //CONSULTA DE CATEGORIAS

        //CRUD
        public List<CATEGORIAS> consultaCategorias()
        {
            List<CATEGORIAS> catDB = new List<CATEGORIAS>();
            CATEGORIAS tmpObj = null;
            try
            {
                string query = "SELECT * FROM categoria  ORDER BY `categoria`.`Nombre`  ASC";
                //EJECUCION DE COMANDO
                Cn.Open();
                    //imgConected
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                //Si tenemos registros entonces...
                if (reader.HasRows)
                {
                    //mientras los registros se vayan leyendo uno a uno
                    //se van creando obj y agregando a list de obj
                    while (reader.Read())
                    {
                        // captiramos los datos del reader
                        string[] row = {   reader.GetString(0), //0
                                           reader.GetString(1), //1
                                           reader.GetString(2) }; //2
                        //creamos el obj temporar de la clase CATEGORIAS
                        tmpObj = new CATEGORIAS(Convert.ToInt32(row[0]), row[1], Convert.ToInt32(row[2]));
                        //Agregamos el obj a una lista de obj de la clase CATEGORIAS
                        catDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {

                Form1.Instance.imgConected.Image = Properties.Resources.noConexion;
                MessageBox.Show("Error" + ex.ToString());
            }
            return catDB;
        }

        public bool AddUpdateCategoria(CATEGORIAS elemento, int opc)
        {
            bool bandera = false;
            try
            {
                string query = opc == 1 ? "INSERT INTO `categoria` (`idCategoria`, `Nombre`, `Estatus`) " +
                "VALUES (NULL, '" + elemento.Nombre + "', '" + elemento.Estatus + "')" 
                : "UPDATE `categoria` SET `Nombre` = '" + elemento.Nombre + "', `Estatus` = '" + elemento.Estatus + "' " +
                    " WHERE `categoria`.`idCategoria` = " + elemento.IdCategoria + " ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR ELEMENTO " + ex.ToString() );
            }
            return bandera;
        }

        // END CATEGORIA

        //CONSULTA DE MARCAS
        public List<MARCA> consultaMarcas()
        {
            List<MARCA> listaDB = new List<MARCA>();
            MARCA tmpObj = null;
            try
            {
                string query = "SELECT * FROM marca ORDER BY `marca`.`Nombre` ASC";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString(0), //0
                                           reader.GetString(1), //1
                                           reader.GetString(2) }; //2
                        tmpObj = new MARCA(Convert.ToInt32(row[0]), row[1], Convert.ToInt32(row[2]));
                        listaDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return listaDB;
        }

        public bool AddUpdateMarca(MARCA elemento, int opc)
        {
            bool bandera = false;
            try
            {
                string query = opc == 1 ? "INSERT INTO `marca` (`idMarca`, `nombre`, `estatus`) VALUES (NULL, '"+elemento.Nombre+"', '"+elemento.Estatus+"')"
                : "UPDATE `marca` SET `nombre` = '"+elemento.Nombre+"', `estatus` = '"+elemento.Estatus+"' WHERE `marca`.`idMarca` = "+elemento.IdMarca+" ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR MARCA " + ex.ToString());
            }
            return bandera;
        }

        //CONSULTA DE PROVEEDORES
        public List<PROVEEDOR> consultaProveedores()
        {
            List<PROVEEDOR> listaDB = new List<PROVEEDOR>();
            PROVEEDOR tmpObj = null;
            try
            {
                string query = "SELECT * FROM proveedor ORDER BY `proveedor`.`Nombre` ASC";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                //Si tenemos registros entonces...
                if (reader.HasRows)
                {
                    //mientras los registros se vayan leyendo uno a uno
                    //se van creando obj y agregando a list de obj
                    while (reader.Read())
                    {
                        // captiramos los datos del reader
                        string[] row = {   reader.GetString(0), //0
                                           reader.GetString(1), //1
                                           reader.GetString(2) }; //2
                        //creamos el obj temporar de la clase CATEGORIAS
                        tmpObj = new PROVEEDOR(Convert.ToInt32(row[0]), row[1], Convert.ToInt32(row[2]));
                        //Agregamos el obj a una lista de obj de la clase CATEGORIAS
                        listaDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return listaDB;
        }

        public bool AddUpdateProveedores(PROVEEDOR elemento, int opc)
        {
            bool bandera = false;
            try
            {
                string query = opc == 1 ? "INSERT INTO `proveedor` (`idProveedor`, `Nombre`, `Estatus`) VALUES (NULL, '"+elemento.Nombre+"', '"+elemento.Estatus+"')"
                : "UPDATE `proveedor` SET `Nombre` = '"+elemento.Nombre+"', `Estatus` = '"+elemento.Estatus+"' WHERE `proveedor`.`idProveedor` = "+elemento.IdProveedor+" ";
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR PROVEEDOR " + ex.ToString());
            }
            return bandera;
        }

        /*
         *********************************** P R O D U C T O S  **********************************
         *CRUDS
         */

        public bool AddUpdateProductos(PRODUCTO e, int opc)
        {
            bool bandera = false;
            try
            {
                ///////--------------------------------- 2020-01-02 05:17:17  yyyy-MM-dd HH:mm:ss FECHA FORMAT
                string insert = "INSERT INTO `producto` (`idProducto`, `Descripcion`, `CodigoInterno`, `codigoBarra`, `DiasGarantia`, `precioCompra`, `precioVenta`, `Descuento`, `stock`, `fechaCaptura`, `status`, `categoria_fk`, `marca_fk`, `proveedor_fk`) "+
                    " VALUES (NULL, '" + e.Descripcion + "', '" + e.CodigoInterno + "', '" + e.CodigoBarra + "', '" + e.DiasGarantia + "', '" + e.PrecioCompra + "', '" + 
                    e.PrecioVenta + "', '" + e.Descuento + "', '" + e.Stock + "', '" + e.FechaCaptura.ToString("yyyy-MM-dd HH:mm:ss") + "', '"+
                    e.Status+"', '"+e.Categoria_fk+"', '"+e.Marca_fk+"', '"+e.Proveedor_fk+"')";
                string update = "UPDATE `producto` SET "+
                    "`Descripcion` = '"+e.Descripcion+"', `CodigoInterno` = '"+e.CodigoInterno+"', `codigoBarra` = '"+e.CodigoBarra+
                    "', `DiasGarantia` = '"+e.DiasGarantia+"', `precioCompra` = '"+e.PrecioCompra+"', `precioVenta` = '"+e.PrecioVenta+
                    "', `Descuento` = '" + e.Descuento + "', `stock` = `stock` +  '" + e.Stock + "', `status` = '"+e.Status+
                    "', `categoria_fk` = '"+e.Categoria_fk+"', `marca_fk` = '"+e.Marca_fk+"', `proveedor_fk` = '"+e.Proveedor_fk+
                    "' WHERE `producto`.`idProducto` = "+e.IdProducto+" ";
                string query = opc == 1 ? insert: update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR PRODUCTO " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update Insert

        public bool UpdateStockProductos(DETAILS_Ticket ticket, int sumaresta)
        {
            bool bandera = false;
            try
            {
                ///////--------------------------------- 2020-01-02 05:17:17  yyyy-MM-dd HH:mm:ss FECHA FORMAT
                string update = "";
                for (int i = 0; i < ticket.ListaDetalles.Count; i++)
                {
                    update += " UPDATE `producto` SET `stock` = `stock` + '" + (ticket.ListaDetalles[i].Cantidad * sumaresta) + "' WHERE `producto`.`idProducto` = " + ticket.ListaDetalles[i].Producto.IdProducto + " ; ";
                }

                Cn.Open();
                cmd = new MySqlCommand(update, Cn);
                cmd.ExecuteReader();
                Cn.Close();
               
                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR LISTA DE PRODUCTOS " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update Insert

        public List<PRODUCTO> consultaProducto(string parametro)
        {
            //definimos la lista de productos como null
            List<PRODUCTO> listaDB = new List<PRODUCTO>();
            //creamos el Query en funcion del parametro
            string sSQL = "SELECT * FROM producto " + parametro + "  ORDER BY `descripcion`, `producto`.`stock` ASC";
            try
            {
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                reader = cmd.ExecuteReader();
                //Si tenemos registros entonces...
                if (reader.HasRows)
                {
                    //mientras los registros se vayan leyendo uno a uno
                    //se van creando obj y agregando a list de obj
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idProducto"), //0
                                           reader.GetString("Descripcion"), //1
                                           reader.GetString("CodigoInterno"), //2
                                           reader.GetString("codigoBarra"), //3
                                           reader.GetString("DiasGarantia"), //4
                                           reader.GetString("precioCompra"), //5
                                           reader.GetString("precioVenta"), //6
                                           reader.GetString("Descuento"), //7
                                           reader.GetString("stock"), //8
                                           reader.GetString("fechaCaptura"), //9
                                           reader.GetString("status"), //10
                                           reader.GetString("categoria_fk"), //11
                                           reader.GetString("marca_fk"), //12
                                           reader.GetString("proveedor_fk")  //13
                                       }; 
                        //Por orden; hacems conversion de variables
                         int idProducto = Convert.ToInt32(row[0]);
                         string descripcion	= row[1];
                         string codigoInterno = row[2];
                         string codigoBarra = row[3];
                         int diasGarantia = Convert.ToInt32(row[4]);
                         double precioCompra = Convert.ToDouble(row[5]);	
                         double precioVenta	= Convert.ToDouble(row[6]);
                         double descuento = Convert.ToDouble(row[7]);
                         double stock = Convert.ToDouble(row[8]);
                         DateTime fechaCaptura =  DateTime.Parse(row[9]);
                         int status	= Convert.ToInt32(row[10]);
                         int categoria_fk = Convert.ToInt32(row[11]);
                         int marca_fk = Convert.ToInt32(row[12]);
                         int proveedor_fk = Convert.ToInt32(row[13]);
                        //creamos el obj temporar de la clase CATEGORIAS
                        PRODUCTO tmpObj = new PRODUCTO(idProducto,descripcion,codigoInterno,codigoBarra,
                            diasGarantia,precioCompra,precioVenta,descuento,stock,fechaCaptura,status,
                            categoria_fk,marca_fk,proveedor_fk);

                        //Agregamos los obj a una lista de obj de la clase CATEGORIAS
                        if (tmpObj != null)
                            listaDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DB " + ex.ToString());
            }

            return listaDB;
        }
        //Fin clase Select

        public PRODUCTO buscarProducto(string parametro)
        {
            //definimos la lista de productos como null
            PRODUCTO tmpProducto = new PRODUCTO();
            //creamos el Query en funcion del parametro
            string sSQL = "SELECT * FROM `producto` WHERE `producto`.`idProducto` = '" + parametro + "' OR `producto`.`codigoBarra`  = '" + parametro + "'  OR  `producto`.`codigoInterno`  = '" + parametro + "'   ORDER BY `descripcion`, `producto`.`stock` ASC";
            try
            {
                Cn.Open();
                cmd = new MySqlCommand(sSQL, Cn);
                reader = cmd.ExecuteReader();
                //Si tenemos registros entonces...
                if (reader.HasRows)
                {
                    //mientras los registros se vayan leyendo uno a uno
                    //se van creando obj y agregando a list de obj
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idProducto"), //0
                                           reader.GetString("Descripcion"), //1
                                           reader.GetString("CodigoInterno"), //2
                                           reader.GetString("codigoBarra"), //3
                                           reader.GetString("DiasGarantia"), //4
                                           reader.GetString("precioCompra"), //5
                                           reader.GetString("precioVenta"), //6
                                           reader.GetString("Descuento"), //7
                                           reader.GetString("stock"), //8
                                           reader.GetString("fechaCaptura"), //9
                                           reader.GetString("status"), //10
                                           reader.GetString("categoria_fk"), //11
                                           reader.GetString("marca_fk"), //12
                                           reader.GetString("proveedor_fk")  //13
                                       };
                        //Por orden; hacems conversion de variables
                        int idProducto = Convert.ToInt32(row[0]);
                        string descripcion = row[1];
                        string codigoInterno = row[2];
                        string codigoBarra = row[3];
                        int diasGarantia = Convert.ToInt32(row[4]);
                        double precioCompra = Convert.ToDouble(row[5]);
                        double precioVenta = Convert.ToDouble(row[6]);
                        double descuento = Convert.ToDouble(row[7]);
                        double stock = Convert.ToDouble(row[8]);
                        DateTime fechaCaptura = DateTime.Parse(row[9]);
                        int status = Convert.ToInt32(row[10]);
                        int categoria_fk = Convert.ToInt32(row[11]);
                        int marca_fk = Convert.ToInt32(row[12]);
                        int proveedor_fk = Convert.ToInt32(row[13]);
                        //creamos el obj temporar de la clase CATEGORIAS
                        PRODUCTO tmpObj = new PRODUCTO(idProducto, descripcion, codigoInterno, codigoBarra,
                            diasGarantia, precioCompra, precioVenta, descuento, stock, fechaCaptura, status,
                            categoria_fk, marca_fk, proveedor_fk);

                        //Agregamos los obj a una lista de obj de la clase CATEGORIAS
                        if (tmpObj != null)
                            tmpProducto = tmpObj;
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DB al buscar producto " + ex.ToString());
            }

            return tmpProducto;
        }
    } // end class






}
