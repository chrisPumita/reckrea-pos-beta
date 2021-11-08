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
    class CONSULTA_Personas : CONEXION
    {
        MySqlCommand cmd; //DICE COMO VA A PREGUNTAR
        MySqlDataReader reader;

        ////CRUD DE CLIENTES
        //public List<CLIENTE> ConsultaClientes(string filtro)
        //{
        //    List<CLIENTE> listCLientesDB = new List<CLIENTE>();
        //    CLIENTE tmpObj;
        //    try
        //    {
        //        string query = "SELECT * FROM `cliente` " + filtro + " ORDER BY `cliente`.`nombre`  ASC ";
        //        //EJECUCION DE COMANDO
        //        Cn.Open();
        //        cmd = new MySqlCommand(query, Cn);
        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                string[] row = {   reader.GetString("idCliente"), //0
        //                                   reader.GetString("nombre"), //1
        //                                   reader.GetString("app"), //2
        //                                   reader.GetString("apm"), //3
        //                                   reader.GetString("telefono"), //4
        //                                   reader.GetString("correo"), //5
        //                                   reader.GetString("estatus") // 6
        //                               };

        //                tmpObj = new CLIENTE();
        //                tmpObj.Id = Convert.ToInt32(row[0]);
        //                tmpObj.Nombre = row[1];
        //                tmpObj.App = row[2];
        //                tmpObj.Apm = row[3];
        //                tmpObj.Telefono = row[4];
        //                tmpObj.Correo = row[5];
        //                tmpObj.Estatus = Convert.ToInt32(row[6]) == 1 ? 1 : 0;
        //                CONSULTA_Personas tmpCOnexion = new CONSULTA_Personas();
        //                DIRECCION_FISCAL direccion = tmpCOnexion.buscaDatosFiscales(tmpObj);
        //                if (direccion != null)
        //                    tmpObj.DatosDiscales = direccion;
        //                listCLientesDB.Add(tmpObj);
        //            }
        //        }
        //        Cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error" + ex.ToString());
        //    }
        //    return listCLientesDB;
        //}

        //CRUD DE CLIENTES
        public List<CLIENTE> ConsultaClientes(string filtro)
        {
            List<CLIENTE> listCLientesDB = new List<CLIENTE>();
            CLIENTE tmpObj;
            try
            {
                string query = "SELECT * FROM `cliente` " + filtro + " ORDER BY `cliente`.`nombre`  ASC ";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idCliente"), //0
                                           reader.GetString("nombre"), //1
                                           reader.GetString("app"), //2
                                           reader.GetString("apm"), //3
                                           reader.GetString("telefono"), //4
                                           reader.GetString("correo"), //5
                                           reader.GetString("estatus") // 6
                                       };

                        tmpObj = new CLIENTE();
                        tmpObj.Id = Convert.ToInt32(row[0]);
                        tmpObj.Nombre = row[1];
                        tmpObj.App = row[2];
                        tmpObj.Apm = row[3];
                        tmpObj.Telefono = row[4];
                        tmpObj.Correo = row[5];
                        tmpObj.Estatus = Convert.ToInt32(row[6]) == 1 ? 1 : 0;
 
                        listCLientesDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return listCLientesDB;
        }

        private DIRECCION_FISCAL buscaDatosFiscales(CLIENTE cliente)
        {
            DIRECCION_FISCAL tmpObj = null;
            try
            {
                string query = "SELECT * FROM `datosfiscales` WHERE `idCliente` =  " + cliente.Id;
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idDireccion"), //0
                                           reader.GetString("idCliente"), //1
                                           reader.GetString("razon"), //2
                                           reader.GetString("calle"), //3
                                           reader.GetString("noInt"), //4
                                           reader.GetString("noExt"), //5
                                           reader.GetString("colonia"), //6
                                           reader.GetString("del-mun"), //7
                                           reader.GetString("entidad"), //8
                                           reader.GetString("rfc") //8
                                       };

                        tmpObj = new DIRECCION_FISCAL();;
                        tmpObj.IdDireccion = Convert.ToInt32(row[0]);
                        tmpObj.Razon = row[2];
                        tmpObj.Calle = row[3];
                        tmpObj.NoInt = row[4];
                        tmpObj.NoExt = row[5];
                        tmpObj.Colonia = row[6];
                        tmpObj.Del_mun = row[7];
                        tmpObj.Entidad = row[8];
                        tmpObj.Rfc = row[9];
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
        //NCOMPLETO
        public List<CLIENTE> ConsultaClientesFiscales(string filtro)
        {
            List<CLIENTE> listCLientesDB = new List<CLIENTE>();
            CLIENTE tmpObj;
            try
            {
                string query = "SELECT `cliente`.`idCliente`, `cliente`.`nombre`, `cliente`.`app`, `cliente`.`apm`,"+
                    " `cliente`.`telefono`, `cliente`.`correo`, `cliente`.`Estatus`, `datosFiscales`.`idDireccion`,  " +
                    "`datosFiscales`.`idCliente`,  `datosFiscales`.`razon`,  `datosFiscales`.`calle`,  `datosFiscales`.`noInt`,  " +
                    "`datosFiscales`.`noExt`,  `datosFiscales`.`colonia`,  `datosFiscales`.`del-mun`,  `datosFiscales`.`entidad`,  " +
                    "`datosFiscales`.`rfc` FROM `datosFiscales`,`cliente` WHERE  `cliente`.`idCliente` =  `datosFiscales`.`idCliente` " +
                    filtro + "  ORDER BY `cliente`.`nombre`  ASC";
                //EJECUCION DE COMANDO
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idCliente"), //0
                                           reader.GetString("nombre"), //1
                                           reader.GetString("app"), //2
                                           reader.GetString("apm"), //3
                                           reader.GetString("telefono"), //4
                                           reader.GetString("correo"), //5
                                           reader.GetString("nombre"), //1
                                           reader.GetString("app"), //2
                                           reader.GetString("apm"), //3
                                           reader.GetString("telefono"), //4
                                           reader.GetString("correo"), //5
                                           reader.GetString("nombre"), //1
                                           reader.GetString("app"), //2
                                           reader.GetString("apm"), //3
                                           reader.GetString("telefono"), //4
                                           reader.GetString("correo"), //5
                                           reader.GetString("Estatus") // 6
                                       };

                        tmpObj = new CLIENTE();
                        tmpObj.Id = Convert.ToInt32(row[0]);
                        tmpObj.Nombre = row[1];
                        tmpObj.App = row[2];
                        tmpObj.Apm = row[3];
                        tmpObj.Telefono = row[4];
                        tmpObj.Correo = row[5];
                        tmpObj.Estatus = Convert.ToInt32(row[6]) == 1 ? 1 : 0;
                       // tmpObj.DatosDiscales = row[5];
                        listCLientesDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return listCLientesDB;
        }

         public bool AddUpdateClientes(CLIENTE cliente, int opc)
        {
            bool bandera = false;
            try
            {
                string insert = "INSERT INTO `cliente` " +
                    " (`idCliente`, `nombre`, `app`, `apm`, `telefono`, `correo`, `estatus`) VALUES" +
                    " (NULL, '" + cliente.Nombre + "', '" + cliente.App + "', '" + cliente.Apm + "', '" + cliente.Telefono + "', '" + cliente.Correo + "', '" + cliente.Estatus + "');";
                string update = "UPDATE `cliente` SET `nombre` = '" + cliente.Nombre + "', `app` = '" + cliente.App + "', `apm` = '" + cliente.Apm + "', " +
                    " `telefono` = '" + cliente.Telefono + "', `correo` = '" + cliente.Correo + "', `Estatus` = '" + cliente.Estatus + "' " +
                    " WHERE `cliente`.`idCliente` = " + cliente.Id + " ";
                string query = opc == 1 ? insert : update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL CLIENTE " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update Insert

        public bool AddUpdateDatosFiscales(DIRECCION_FISCAL factura, CLIENTE cliente, int opc)
        {
            bool bandera = false;
            try
            {
                //string NoInterior = factura.NoExt == "" ? "NULL" : factura.NoExt;
                string insert = "INSERT INTO `datosfiscales` "+
                    " (`idDireccion`, `idCliente`, `razon`, `calle`, `noInt`, `noExt`, `colonia`, `del-mun`, `entidad`, `rfc`) VALUES "+
                    " (NULL, '"+cliente.Id+"', '"+factura.Razon+"', '"+factura.Calle+"', '"+factura.NoInt+"', '"+factura.NoExt+"',"+
                    " '"+factura.Colonia+"', '"+factura.Del_mun+"', '"+factura.Entidad+"', '"+factura.Rfc+"');";
                string update = "UPDATE `datosfiscales` SET `razon` = '" + factura.Razon + "', `calle` = '" + factura.Calle + "', "+
                    " `noInt` = '" + factura.NoInt + "', `noExt` = '"+factura.NoExt+"', `colonia` = '"+factura.Colonia+"', "+
                    " `del-mun` = '"+factura.Del_mun+"', `entidad` = '"+factura.Entidad+"', `rfc` = '"+factura.Rfc+"' "+
                    " WHERE `datosfiscales`.`idDireccion` = "+factura.IdDireccion+" AND `datosfiscales`.`idCliente` = "+cliente.Id+" ";
                string query = opc == 1 ? insert : update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL CLIENTE " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update Insert

        //CRUD DE CLIENTES

        //CRUD DE EMPLEADOS
        public List<EMPLEADO> ConsultaEmpleados(string filtro)
        {
            List<EMPLEADO> listEmpleadosDB = new List<EMPLEADO>();
            EMPLEADO tmpObj;
            try
            {
                string query = "SELECT * FROM `empleado` " + filtro + " ORDER BY `empleado`.`nombre`  ASC";
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
                        string[] row = {   reader.GetString("idEmpleado"), //0
                                           reader.GetString("nombre"), //1
                                           reader.GetString("app"), //2
                                           reader.GetString("apm"), //3
                                           reader.GetString("telefono"), //4
                                           reader.GetString("correo"), //5
                                           reader.GetString("sexo"), //6
                                           reader.GetString("nick"), //7
                                           reader.GetString("password"), //8
                                           reader.GetString("depto"), //9
                                           reader.GetString("FechaRegistro"), //10
                                           reader.GetString("tipoCuenta"), //11
                                           reader.GetString("Estatus") // 12
                                       };

                        tmpObj = new EMPLEADO();
                        tmpObj.Id = Convert.ToInt32(row[0]);
                        tmpObj.Nombre = row[1];
                        tmpObj.App = row[2];
                        tmpObj.Apm = row[3];
                        tmpObj.Telefono = row[4];
                        tmpObj.Correo = row[5];
                        tmpObj.Sexo = Convert.ToInt32(row[6]) == 1 ? 1:0;
                        tmpObj.Nick = row[7];
                        tmpObj.Password = row[8];
                        tmpObj.Depto = row[9];
                        tmpObj.FechaRegistro = DateTime.Parse(row[10]);
                        tmpObj.TipoCuenta = Convert.ToInt32(row[11]);
                        tmpObj.Estatus = Convert.ToInt32(row[12]) == 1 ? 1:0;
                        listEmpleadosDB.Add(tmpObj);
                    }
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
            return listEmpleadosDB;
        }

        public bool AddUpdateEmpleado(EMPLEADO emp, int opc)
        {
            bool bandera = false;
            try
            {
                string insert = "INSERT INTO `empleado` "+
                    " (`idEmpleado`, `nombre`, `app`, `apm`, `telefono`, `correo`, `sexo`, `nick`, `password`, `depto`, `FechaRegistro`, `tipoCuenta`, `Estatus`) "+
                    " VALUES (NULL, '" + emp.Nombre + "', '" + emp.App + "', '" + emp.Apm + "', '" + emp.Telefono + "', '" + emp.Correo + "', '" + emp.Sexo + "', '" 
                    + emp.Nick + "', '" + emp.Password + "', '" + emp.Depto + "', '" + emp.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss")+ "', '"+emp.TipoCuenta+"', '"+emp.Estatus+"')";
                string update = "UPDATE `empleado` SET `nombre` = '"+emp.Nombre+"', `app` = '"+emp.App+"', `apm` = '"+emp.Apm+"', `telefono` = '"+emp.Telefono +
                    "', `correo` = '"+emp.Correo+"', `sexo` = '"+emp.Sexo+"', `nick` = '"+emp.Nick+"', `password` = '"+emp.Password+"', `depto` = '"+emp.Depto+
                    "', `tipoCuenta` = '"+emp.TipoCuenta+"', `estatus` = '"+emp.Estatus+"' WHERE `empleado`.`idEmpleado` = " + emp.Id;
                string query = opc == 1 ? insert : update;
                Cn.Open();
                cmd = new MySqlCommand(query, Cn);
                cmd.ExecuteReader();
                bandera = true;
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR AL EMPELADO " + ex.ToString());
            }
            return bandera;
        } // FIN CLASE Update Insert


        public int getUltimoID(string table)
        {
            string SSQL = "";
            int id = 0;
            switch (table)
            {
                case "Cliente":
                    SSQL = "SELECT MAX(`idCliente`) AS ULTIMO FROM `cliente` ";
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

        //CRUD DE EMPLEADOS
    }
}
