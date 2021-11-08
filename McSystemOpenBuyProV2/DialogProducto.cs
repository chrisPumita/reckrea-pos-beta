using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McSystemOpenBuyProV2
{
    public partial class DialogProducto : Form
    {
        int[] categoria, proveedor, marca;
        PRODUCTO _producto;
        int Accion;
        //@overgroud
        public DialogProducto(int accion)
        {
            this.Accion = accion;
            InitializeComponent();
            verficaAccion(accion);
            txtCodeIn.Text = generaCodigo();
            txtDesc.Focus();
        }

        //editar un Producto con sobrecarga
        public DialogProducto(int accion, PRODUCTO p)
        {
            this.Accion = accion;
            this._producto = p;
            InitializeComponent();
            verficaAccion(accion);
            lblTitulo.Text = "Actualziar datos de " + p.Descripcion;
            btnAccion.Text = "Actualizar";
            cargaDatos(p);
            txtDesc.Focus();
            //Cargar  los datos del Producto
        }
        private void cargaDatos(PRODUCTO p)
        {
            txtDesc.Text = p.Descripcion;
            //elegir el elemento por medio de la lista de arrays del areglo
            for (int i = 0; i < categoria.Count(); i++)
                if (p.Categoria_fk == categoria[i])
                    cboCategoria.SelectedIndex = i;

            for (int i = 0; i < marca.Count(); i++)
                if (p.Marca_fk == marca[i])
                    CBOMarca.SelectedIndex = i;

            for (int i = 0; i < proveedor.Count(); i++)
                if (p.Proveedor_fk == proveedor[i])
                    CBOProveedor.SelectedIndex = i;
            //dias de la garantia
            try
            {
                int dias =Convert.ToInt32(p.DiasGarantia);
                switch (dias)
                {
                    case 7:
                        rbn7.Checked = true;
                        break;
                    case 15:
                        rbn15.Checked = true;
                        break;
                    case 30:
                        rbn30.Checked = true;
                        break;
                    default:
                        rbnn.Checked = true;
                        numericSpiner.Value = Convert.ToDecimal(dias);
                        break;
                }
            }
            catch (Exception)
            {
                rbnNA.Checked = true;
            }

            txtExistencias.Text =Convert.ToString(p.Stock);
            cboStatus.Checked = p.Status == 1 ? true : false;
            txtCodeIn.Text = p.CodigoInterno;
            txtBarCode.Text = p.CodigoBarra;
            txtCompra.Text =Convert.ToString(p.PrecioCompra);
            numericDescuento.Value =Convert.ToDecimal(p.Descuento);
            numericGanancia.Value = Convert.ToDecimal(p.PrecioVenta-p.PrecioCompra);
            calculaGananciaNumeric();
        }
        private void verficaAccion(int a)
        {
            //independientemente de la accion vamos a cargar los valores de las listas desplegables
            cargarListas();
            if (a == 0)//Va a editar
            {
                lblTitulo.Text = "Editar Producto";
                btnAccion.Text = "Guardar";
            }
            else
            {
                lblTitulo.Text = "Agregar Nuevo Producto";
                btnAccion.Text = "Agregar";
            }
        }

        private void guardarDatos()
        {
            PRODUCTO p = verificaDatos();
            if (p != null)
            {
                // enviar el obj a la bd para que sea almacenada o actualziada
                CONSULTA_Inventario cn = new CONSULTA_Inventario();
                if (Accion == 1) /// GUardamos nuevo Producto
                    if (cn.AddUpdateProductos(p, 1))
                    {
                        MessageBox.Show("Se ha agregado el Producto: [" + p.Descripcion + "] a $" + p.PrecioVenta);
                        limpiar(); // limpiamos para ambos casos
                    }
                    else
                        MessageBox.Show("Imposible guardar el Producto. Revise que no este repitiendo el Codigo Interno");
                else // editamos el Producto encapsulado
                    if (cn.AddUpdateProductos(p, 0))
                    {
                        this.Close();
                        MessageBox.Show("Se ha editado el Producto: [" + p.Descripcion + "] a $" + p.PrecioVenta);
                        
                    }
                    else
                        MessageBox.Show("Imposible editar el Producto. Revise que no este repitiendo el Codigo Interno");
            }
            else
                MessageBox.Show("NO SE GUARDO NADA");
        }

        private PRODUCTO verificaDatos()
        {
            PRODUCTO obj = null;
                        //verificamos que los datos sean correctos o no esten vacios
            int idProducto = Accion == 1 ? 0 : _producto.IdProducto;
            string descripcion = txtDesc.Text;
            string codigoInterno = txtCodeIn.Text;
            string codigoBarra = txtBarCode.Text;
            int diasGarantia;
            //Obteniengo garantia
            if (rbnNA.Checked) diasGarantia = 0;
            else if (rbn7.Checked) diasGarantia = 7;
            else if (rbn15.Checked) diasGarantia = 15;
            else if (rbn30.Checked) diasGarantia = 30;
            else diasGarantia = Convert.ToInt32(numericSpiner.Value);

            double precioCompra = Convert.ToDouble(txtCompra.Text);
            double precioVenta = Convert.ToDouble(txtVenta.Text) + Convert.ToDouble(numericDescuento.Value);
            double stock = Convert.ToDouble(numericAddStock.Value);
            double descuento = Convert.ToDouble(numericDescuento.Value);
            DateTime fechaCaptura = DateTime.Now;
            int status = cboStatus.Checked ? 1:0;

            if (codigoInterno == "")
                codigoInterno = generaCodigo();

            if (codigoBarra == "")
                codigoBarra = "NA";

            int categoria_fk = -1;
            int marca_fk = -1;
            int proveedor_fk = -1;
            try {categoria_fk =categoria[cboCategoria.SelectedIndex];}
            catch (Exception) { MessageBox.Show("Debe elegir una Categoria, si no existe agreguela."); return null; }

            try {marca_fk = marca[CBOMarca.SelectedIndex];}
            catch (Exception) { MessageBox.Show("Debe elegir una Marca, si no existe agreguela."); return null; }

            try {proveedor_fk = proveedor[CBOProveedor.SelectedIndex]; }
            catch (Exception) { MessageBox.Show("Debe elegir un proveedor, si no existe agreguelo."); return null; }

            if (descripcion != "")
                //si hay Descripcion
                if (!(precioVenta < precioCompra))
                    obj = new PRODUCTO(idProducto, descripcion, codigoInterno, codigoBarra, diasGarantia, precioCompra, precioVenta, descuento,stock,fechaCaptura,status,categoria_fk,marca_fk,proveedor_fk);
                else
                    MessageBox.Show("El precio de compra, no puede ser mayor al precio de venta");
            else
                MessageBox.Show("Debe escribir una desripción");

            //construir aquo el obj
            return obj;
        }

           private void cargarListas()
           {
               cboCategoria.Items.Clear();
               CBOMarca.Items.Clear();
               CBOProveedor.Items.Clear();
               CONSULTA_Inventario consulta = new CONSULTA_Inventario();
               List<CATEGORIAS> listaCat = consulta.consultaCategorias();
               List<MARCA> listaMar = consulta.consultaMarcas();
               List<PROVEEDOR> listaPro = consulta.consultaProveedores();

               if (listaCat != null){
                   categoria = new int[listaCat.Count];
                   for (int i = 0; i < listaCat.Count; i++)
                   {
                       if (listaCat[i].Estatus != 0) // va para todas
                       {
                           categoria[i] = listaCat[i].IdCategoria;
                           cboCategoria.Items.Add(listaCat[i].Nombre);
                       }
                   }
               }

               if (listaMar != null){
                   marca = new int[listaMar.Count];
                   for (int i = 0; i < listaMar.Count; i++)
                   {
                       if (listaMar[i].Estatus != 0) // va para todas
                       {
                           marca[i] = listaMar[i].IdMarca;
                           CBOMarca.Items.Add(listaMar[i].Nombre);
                       }
                   }
               }
               if (listaPro != null){
                   proveedor = new int[listaPro.Count];
                   for (int i = 0; i < listaPro.Count; i++)
                   {
                       if (listaPro[i].Estatus != 0)
                       {
                           proveedor[i] = listaPro[i].IdProveedor;
                           CBOProveedor.Items.Add(listaPro[i].Nombre);
                       }
                   }
               }
           }

           private void calculaGananciaBarra()
           {
              try 
	            {
                    double costo = Convert.ToDouble(txtCompra.Text);
                    lblPorcentajeBarra.Text = (System.Math.Round(barraPorcentaje.Value / 1.0)).ToString() + " %";
                    double v_porcentaje = System.Math.Round(barraPorcentaje.Value / 1.0);
                    double ganancia = Convert.ToDouble((v_porcentaje * costo / (barraPorcentaje.Maximum / (barraPorcentaje.Maximum/100))));
                    double costoTotal = costo + ganancia;
                  // hacemos operaciones con lso datos proporcionados
                    numericGanancia.Value = Convert.ToDecimal(ganancia);
                    double descuento = Convert.ToDouble(numericDescuento.Value);
                    txtVenta.Text = Convert.ToString(costoTotal - descuento);
                    lblGanancaDes.Text = "$" + Convert.ToString(ganancia - descuento);
                    grupoGanancia.Text = "Subtotal: $" + (costo + ganancia);
	            }
	            catch (Exception)
	            {
                    barraPorcentaje.Value = 0;
	            }
           }

           private void calculaGananciaNumeric()
           {
               try
               {
                   //tomar los datos del numeric y actualizar la barra
                   double costo = Convert.ToDouble(txtCompra.Text);
                   double ganancia = Convert.ToDouble(numericGanancia.Value);
                   //obtengo el valor del numeric
                   double subtotal = costo + ganancia;
                   int porcentaje = Convert.ToInt32(((ganancia * 100) / costo));
                   if (porcentaje <= barraPorcentaje.Maximum)
                       barraPorcentaje.Value = porcentaje;
                   else
                       barraPorcentaje.Value = barraPorcentaje.Maximum;
                   lblPorcentajeBarra.Text = porcentaje + " %";
                   // hacemos operaciones con lso datos proporcionados
                   double descuento = Convert.ToDouble(numericDescuento.Value);
                   double costoTotal = subtotal - descuento;
                   txtVenta.Text = Convert.ToString(costoTotal);
                   lblGanancaDes.Text = "$" + Convert.ToString(ganancia - descuento);
                   grupoGanancia.Text = "Subtotal: $" + (costo + ganancia);
               }
               catch (Exception)
               {
                   barraPorcentaje.Value = 0;
                   numericGanancia.Value = 0;
                   numericDescuento.Value = 0;
               }
           }

           private string generaCodigo()
           {
               Random obj = new Random();
               string sCadena = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
               int longitud = sCadena.Length;
               char cletra;
               int nlongitud = 5;
               string sNuevacadena = string.Empty;
               for (int i = 0; i < nlongitud; i++)
               {
                   cletra = sCadena[obj.Next(longitud)];
                   sNuevacadena += cletra.ToString();
               }

               DateTime hf = DateTime.Now;
               string year = hf.ToString("yyyy");
               int month = Convert.ToInt32(hf.ToString("MM"));
               string m = "";
               switch (month)
               {
                   case 1:
                       m = "EN";
                       break;
                   case 2:
                       m = "FE";
                       break;
                   case 3:
                       m = "MA";
                       break;
                   case 4:
                       m = "AB";
                       break;
                   case 5:
                       m = "MY";
                       break;
                   case 6:
                       m = "JU";
                       break;
                   case 7:
                       m = "JL";
                       break;
                   case 8:
                       m = "AG";
                       break;
                   case 9:
                       m = "SE";
                       break;
                   case 10:
                       m = "OC";
                       break;
                   case 11:
                       m = "NO";
                       break;
                   case 12:
                       m = "DI";
                       break;
                   default:
                       m = "JC";
                       break;
               }
               string codeH = hf.ToString("dd") + m + year.Substring(2,2);
               return codeH+sNuevacadena;
           }

           private void limpiar()
           {
               txtDesc.Clear();
               cboCategoria.SelectedIndex = 0;
               CBOMarca.SelectedIndex = 0;
               rbnNA.Checked = true;
               CBOProveedor.SelectedIndex = 0;
               txtExistencias.Text = "0";
               numericAddStock.Value = 1;
               txtCodeIn.Text = generaCodigo();
               txtBarCode.Clear();
               txtCompra.Text = "0";
               barraPorcentaje.Value = 0;
               numericGanancia.Value = 0;
               numericDescuento.Value = 0;
               txtVenta.Text = "0";
               cboStatus.Checked = true;
           }

        /// 
        /// ////////////////////////

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogElementos addCategoria  = new DialogElementos(0,1);
            addCategoria.ShowDialog();
            //regrescar
            cargarListas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogElementos addCategoria = new DialogElementos(2,1);
            addCategoria.ShowDialog();
            cargarListas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogElementos addCategoria = new DialogElementos(1,1);
            addCategoria.ShowDialog();
            cargarListas();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            guardarDatos();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            calculaGananciaBarra();
        }

        private void txtCompra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double numero = Convert.ToDouble(txtCompra.Text);
                if (numero <= 0)
                {
                    txtCompra.Focus();
                    txtCompra.SelectAll();
                    txtCompra.Text = "0.0";
                    numericDescuento.Value = 0;
                    numericGanancia.Value = 0;
                    lblPorcentajeBarra.Text = "0 %";
                    txtVenta.Text = "0.0";
                }
                    calculaGananciaNumeric();
            }
            catch (Exception)
            {
                txtCompra.Text = "0.0";
                txtCompra.Focus();
                txtCompra.SelectAll();
            }
            
        }
        
        private void numericDescuento_ValueChanged(object sender, EventArgs e)
        {
            calculaGananciaNumeric();
        }

        private void numericGanancia_ValueChanged(object sender, EventArgs e)
        {
            calculaGananciaNumeric();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCodeIn.Text = generaCodigo();
        }
    }
}
