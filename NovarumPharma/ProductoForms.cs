using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NovarumPharma
{
    public partial class ProductoForms : Form
    {
        Validacion val = new Validacion();
        public static string dato1 { get; set; }
        public ProductoForms()
        {
            InitializeComponent();
        }
        Datos dato = new Datos();
        private static ProductoForms Instancia;
        public static ProductoForms DefInstancia
        {
            get
            {
                if (Instancia == null || Instancia.IsDisposed)
                    Instancia = new ProductoForms();
                return Instancia;
            }
            set
            {
                Instancia = value;
            }
        }
        string strinActualizarGrid = "select i.cod_insumo AS [Cod Nº],p.Nombre AS Proveedor,i.cod_cat AS [Cod Cat],i.nombre AS [Nombre Insumo],ir.cantMP AS [Cant % MP],ir.KLxInusmo AS [Kg/Lts por insumo],ir.GrInsumo AS [Gr por Insumo],ir.MgrInsumo AS [Mgr por Insumo],pi.un AS UN,pi.precioConIVA AS [Precion C/IVA],ir.CostoConIVA AS [Costo con IVA] FROM Insumos i,Proveedores p,Proveedor_Insumo pi,Receta r,Insumos_Receta ir where i.cod_insumo=pi.cod_insumo and pi.id_proveedor=p.id_proveedor and i.cod_insumo=ir.cod_insumo and ir.id_receta=r.id_receta";// ORDER BY i.cod_insumo ASC 

        private void txtCod_KeyUp(object sender, KeyEventArgs e)
        {
            //si no ahi nada en el txtobox
            if (txtCod.Text == "")
            {

            }
            //a medida que teclea el codigo se cargan los datos correspondientes en los textbos pasados por parametro, en base al txtcod=codigo
            else
            {
                dato.cargarTXBoxInsumos(txtCod, txtNomProveedor, txtNomInsumo, txtCodCat, txtPrecioUnitarioPesos, TxtUnidad);
                eRP.Clear();
            }
        }

        private void ProductoForms_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBuscarPorPorducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBuscarPorPorducto.Text == "")
            {
                dgProductos.DataSource = null;
                dgProductos.Refresh();
            }
            else
            {
                dato.actualizaGrid(dgProductos, strinActualizarGrid + " and r.nombre like'%" + txtBuscarPorPorducto.Text + "%';","Insumos");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {
                eRP.SetError(txtNombreProducto, "Ingrese El Nombre del Producto");

                if (txtCod.Text == "")
                {
                    eRP.SetError(txtCod, "Ingrese al menos un Insumo");
                }
                if (txtPorcentajeMP.Text == "")
                {
                    eRP.SetError(txtPorcentajeMP, "Ingrese el porcentaje para este Insumo");
                }
                if (txtUnidadesAcotizar.Text == "")
                {
                    eRP.SetError(txtUnidadesAcotizar, "Ingrese las Unidades a cotizar");
                }
                if (txtPresentacionGrMl.Text == "")
                {
                    eRP.SetError(txtPresentacionGrMl, "Ingrese la presentacion en Gr o Ml");
                }
            }
            else
            {
                //Producto p = new Producto();
                //p.Nombre = txtNombreProducto.Text;
                //p.PresentacionGM = Convert.ToDecimal(txtPresentacionGrMl.Text);
                //p.CostoconIVA = Convert.ToDecimal(txtCosto.Text);
                
                string estado = "repetido";
                if (estado == dato.validarExistenciaInsumoreceta(Convert.ToInt32(txtCod.Text),Convert.ToInt32(txtIdReceta.Text)))
                {
                    MessageBox.Show("Este insumo se encuentra ya en este producto");
                }
                else
                {
                    if (dato.ValidarExistenciaProducto(txtNombreProducto.Text) == "esta")
                    {
                        MessageBox.Show("Este Producto ya existe");
                    }
                    else
                    {
                        MessageBox.Show("creara El producto");
                    }
                    //string insert0 = "INSERT INTO Producto(nombre,presentacionGM,costoConIVA) VALUES('" + p.Nombre + "','" + p.PresentacionGM + "','" + p.CostoconIVA + "')";
                    //string insert1 = "INSERT INTO Receta(id_producto,nombre) VALUES()";
                    //string insert2 = "INSERT INTO Insumos_Receta(cod_insumo,id_receta,cantMP) VALUES(1,1,20)";
                    //dato.ejecutarQuery(insert0);
                    //dato.ejecutarQuery(insert1);
                    //dato.ejecutarQuery(insert2);
                    MessageBox.Show("Se agrego el Registro", "joia");
                }
                
            }

        }

        private void txtNombreProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {

            }
            else
            {
                dato.cargarDatoProducto(txtNombreProducto, txtIdReceta);
                dato.actualizaGrid(dgProductos, strinActualizarGrid + " and r.nombre like'%" + txtNombreProducto.Text + "%';", "Insumos");
                lvNombreDelProducto.Text = txtNombreProducto.Text;
                eRP.Clear();
            }
            
        }

        private void txtPorcentajeMP_KeyUp(object sender, KeyEventArgs e)
        {
            Validacion.ValidaDecimales((TextBox)sender);
            eRP.Clear();
        }

        private void txtUnidadesAcotizar_KeyUp(object sender, KeyEventArgs e)
        {
            
            if ((txtPresentacionGrMl.Text == "") && (txtUnidadesAcotizar.Text == ""))
            {

            }
            else
            {
                Double dat1 = 0;
                Double.TryParse(txtPresentacionGrMl.Text, out dat1);

                Double dat2 = 0;
                Double.TryParse(txtUnidadesAcotizar.Text, out dat2);

                txtcantPedidaKiloLitro.Text = (dat1 * dat2 / 1000).ToString("00.000");
            }
            eRP.Clear();
        }

        private void txtPresentacionGrMl_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtPresentacionGrMl.Text == "") && (txtUnidadesAcotizar.Text == ""))
            {

            }
            else
            {
                Decimal dat1 = 0;
                Decimal.TryParse(txtPresentacionGrMl.Text, out dat1);

                Decimal dat2 = 0;
                Decimal.TryParse(txtUnidadesAcotizar.Text, out dat2);

                txtcantPedidaKiloLitro.Text = (dat1 * dat2 / 1000).ToString("00.000");
            }
            eRP.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BuscarInsumo m = new BuscarInsumo();
            m.Show();
        }

        private void txtPresentacionGrMl_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtUnidadesAcotizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtCodCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloNumeros(e);
        }

        private void txtPorcentajeMP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == ".")
            {
                e.Handled = true;
                this.txtPorcentajeMP.Text += ",";
                SendKeys.Send("{END}");
            }
            Decimal dat1 = 0;
            Decimal.TryParse(txtcantPedidaKiloLitro.Text, out dat1);

            Decimal dat2 = 0;
            Decimal.TryParse(txtPorcentajeMP.Text, out dat2);

            txtkllt.Text = ((dat1 * dat2) / 100).ToString();
            txtGr.Text = ((Convert.ToDecimal(txtkllt.Text) * 1000)).ToString("00.000");
            txtMgr.Text = ((Convert.ToDecimal(txtGr.Text) * 1000)).ToString("00.0000");
            if (TxtUnidad.Text == "Kg")
            {
                txtCosto.Text = (Convert.ToDecimal(txtkllt.Text) * Convert.ToDecimal(txtPrecioUnitarioPesos.Text)).ToString("00.000"); 
            }
        }
    }
}
