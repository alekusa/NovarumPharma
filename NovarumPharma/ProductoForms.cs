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
        funciones func = new funciones();
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
        string strinActualizarGrid = "select i.cod_insumo AS [Cod Nº],p.Nombre AS Proveedor,i.cod_cat AS [Cod Cat],i.nombre AS [Nombre Insumo],ir.cantMP AS [Cant % MP],ir.KLxInusmo AS [Kg/Lts por insumo],ir.GrInsumo AS [Gr por Insumo],ir.MgrInsumo AS [Mgr por Insumo],pi.un AS UN,pi.precioConIVA AS [Precion C/IVA],ir.CostoConIVA AS [Costo con IVA] FROM Insumos i,Proveedores p,Proveedor_Insumo pi,Receta r,Insumos_Receta ir,Producto pr where i.cod_insumo=pi.cod_insumo and pi.id_proveedor=p.id_proveedor and i.cod_insumo=ir.cod_insumo and ir.id_receta=r.id_receta and pr.id_producto=r.id_producto";// ORDER BY i.cod_insumo ASC 

        private void txtCod_KeyUp(object sender, KeyEventArgs e)
        {
            //si no ahi nada en el txtobox
            if (txtCod.Text=="")
            {
                txtNomProveedor.Clear();
                txtCodCat.Clear();
                txtNomInsumo.Clear();
                TxtUnidad.Clear();
                txtPrecioUnitarioPesos.Clear();
                txtCod.Clear();
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
            if (txtCod.Text == "")
            {
                eRP.SetError(txtCod, "Ingrese un Insumo");

                if (txtNombreProducto.Text == "")
                {
                    eRP.SetError(txtNombreProducto, "Ingrese El nombre del producto");
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

                string estado = "repe";
                if (dato.ValidarExistenciaProducto(txtNombreProducto.Text) == "esta")
                
                {
                    if(estado == dato.validarExistenciaInsumoreceta(Convert.ToInt32(txtCod.Text), Convert.ToInt32(txtIdReceta.Text)))
                    {
                        MessageBox.Show("este insumo se encuentra en el producto");
                        func.limpiar(panel1);
                    
                    }
                    else
                    {
                        if (dato.ValidarExistenciaInsumo(Convert.ToInt32(txtCod.Text)) == 0)
                        {
                            if ((Convert.ToInt32(lblSumaPorcentaje.Text))+(Convert.ToInt32(txtPorcentajeMP.Text))>100 )
                            {
                                eRP.SetError(txtPorcentajeMP,"Esta Superando el 100%");
                            }
                            else
                            {
                                MessageBox.Show("se Agregara este insumo al producto");
                                dato.ejecutarQuery("INSERT INTO Insumos_Receta VALUES('" + txtCod.Text + "','" + txtIdReceta.Text + "','" + txtPorcentajeMP.Text + "','" + txtkllt.Text + "','" + txtGr.Text + "','" + txtMgr.Text + "','" + txtCosto.Text + "')");
                                dato.actualizaGrid(dgProductos, strinActualizarGrid + " and r.nombre like'%" + txtNombreProducto.Text + "%';", "Insumos");
                                sumaPorcentajeMP();
                                func.limpiar(panel1);
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Necesita Crear Este Insumo");

                        }
                        
                    }
                        

                }
                else
                {
                    MessageBox.Show("este producto No existe");

                    Producto p = new Producto();
                    p.Nombre = txtNombreProducto.Text;
                    p.PresentacionGM = Convert.ToDecimal(txtPresentacionGrMl.Text);
                    p.CostoconIVA = Convert.ToDecimal(txtCosto.Text);

                    string NewProducto = "INSERT INTO Producto(nombre,presentacionGM,costoConIVA) VALUES('" + p.Nombre + "','" + p.PresentacionGM + "','" + p.CostoconIVA + "')";
                    dato.ejecutarQuery(NewProducto);
                    dato.recuperarIDproducto(txtNombreProducto,txtIdProducto,txtPresentacionGrMl);

                    string insert1 = "INSERT INTO Receta(id_producto,nombre) VALUES('"+Convert.ToInt32(txtIdProducto.Text)+"','Fabrica "+txtNombreProducto.Text+"')";
                    dato.ejecutarQuery(insert1);

                    dato.cargarDatoProducto(txtNombreProducto,txtIdReceta);

                    string insert2 = "INSERT INTO Insumos_Receta VALUES('"+txtCod.Text+"',"+Convert.ToInt32(txtIdReceta.Text)+",'"+txtPorcentajeMP.Text+"','"+txtkllt.Text+"','"+txtGr.Text+"','"+txtMgr.Text+"','"+txtCosto.Text+"')";
                                        
                    dato.ejecutarQuery(insert2);

                    dato.actualizaGrid(dgProductos, strinActualizarGrid + " and pr.nombre like'" + txtNombreProducto.Text + "';", "Insumos");

                    sumaPorcentajeMP();
                    func.limpiar(panel1);

                }

            }

        }

        private void txtNombreProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNombreProducto.Text == "")
            {
                txtIdReceta.Text = "";
                txtIdProducto.Text = "";
                dgProductos.DataSource = null;
                dgProductos.Refresh();
                lvNombreDelProducto.Text = "";
                lblSumaPorcentaje.Text = "0";
            }
            else
            {
                
                dato.cargarDatoProducto(txtNombreProducto, txtIdReceta);
                dato.recuperarIDproducto(txtNombreProducto, txtIdProducto, txtPresentacionGrMl);
                dato.actualizaGrid(dgProductos, strinActualizarGrid + " and pr.nombre ='" + txtNombreProducto.Text + "';", "Insumos");
                this.dgProductos.Columns[0].Frozen = true;
                lvNombreDelProducto.Text = txtNombreProducto.Text;
                eRP.Clear();
                sumaPorcentajeMP();
                
            }

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            
        }

        private void sumaPorcentajeMP()
        {
            double suma = 0;
            foreach (DataGridViewRow row in dgProductos.Rows)
            {
                suma += (double)row.Cells[4].Value;
            }
            lblSumaPorcentaje.Text = Convert.ToString(suma);
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
            //si teclea una coma(,) se cargara un Punto (.) para cargar en la base de datos decimales
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

        private void button1_Click(object sender, EventArgs e)
        {
            //desde la funcion updateporcentaje se le pasan tres parametros, el valor a updatear, el codigo del isnumo, el id del producto
            dato.UpdatePorcentaje(Convert.ToString(dgProductos.CurrentCell.Value),codigo,txtIdReceta.Text);
            //Actualiza el datagridview con el porcentaje updateado
            dato.actualizaGrid(dgProductos, strinActualizarGrid + " and r.nombre like'%" + txtNombreProducto.Text + "%';", "Insumos");
            //suma los porcentajes y los muestra en el lbl
            sumaPorcentajeMP();
        }
        public string codigo;
        //capturar valores de la fila seleccionada con el mause
        private void dgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //captura el valor de la columna 0 correspondiente a codigo del insumo
                codigo = dgProductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
                
            

            
        }

        
    }
}
