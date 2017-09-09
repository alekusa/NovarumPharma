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
    public partial class AdminInsumos : Form
    {
        
        Datos dato = new Datos();
        Boolean editar;
        string cod;
        string strinActualizarGrid = "select i.cod_insumo AS [Cod Nº],p.Nombre AS Proveedor,i.nombre AS Nombre,pi.un AS UN,pi.precioSinIVAmonedaCotizada AS [Precio Sin IVA],pi.moneda AS Moneda,pi.precioSinIVAenPesos AS [Precios S/IVA en $],pi.iva AS IVA,pi.precioConIVA AS [Precion C/IVA],pi.FechaActualizacion AS Actualizado FROM Insumos i,Proveedores p,Proveedor_Insumo pi where i.cod_insumo=pi.cod_insumo and pi.id_proveedor=p.id_proveedor ";

        private void FormAdminInsumos_Load(object sender, EventArgs e)
        {
            txtPrecioDolar.Text = Convert.ToString(dato.CalcularDolar());
            dato.actualizaGrid(dgInsumos, strinActualizarGrid, "Insumos");
            if (editar == false)
            { grupNewEdit.Visible = false; }
        }
        public AdminInsumos()
        {
            InitializeComponent();
        }
        private static AdminInsumos Instancia;
        public static AdminInsumos DefInstancia
        {
            get
            {
                if (Instancia == null || Instancia.IsDisposed)
                    Instancia = new AdminInsumos();
                return Instancia;
            }
            set
            {
                Instancia = value;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Insumos i = new Insumos();
            ProveedorInsumo pi = new ProveedorInsumo();
            Proveedor p = new Proveedor();

            p.NombreProveedor = txtPnombre.Text;
            i.Nombre = txtNombre.Text;
            pi.Un = cboUN.SelectedItem.ToString();
            pi.Iva = Convert.ToDouble(cmbIVA.SelectedItem.ToString());
            pi.Moneda = cmbMoneda.SelectedItem.ToString();
            pi.PrecioSinIVAenPesos = Convert.ToDouble(txtPrecioSiva.Text);
            pi.Moneda = cmbMoneda.SelectedItem.ToString();
            pi.FechaActualizacion = dt.Value;
            pi.PrecioSinIVAmonedaCotizada = pi.PrecioSinIVAenPesos / dato.CalcularDolar();
           
                string queryUpdate = "UPDATE Proveedor_Insumo pi, Insumos i, Proveedores p SET p.nombre = '"+ p.NombreProveedor +"', i.nombre = '"+ i.Nombre+"', pi.un = '"+pi.Un+ "', pi.precioSinIVAenPesos = '" + pi.PrecioSinIVAenPesos + "', pi.iva = '" + pi.Iva + "', pi.moneda = '" + pi.Moneda + "', pi.FechaActualizacion = '" + pi.FechaActualizacion+ "', pi.precioSinIVAmonedaCotizada = '" + pi.PrecioSinIVAmonedaCotizada + "' WHERE pi.cod_insumo=" + cod+" and i.cod_insumo = pi.cod_insumo and pi.id_proveedor = p.id_proveedor";
                dato.ejecutarQuery(queryUpdate);
                dato.actualizaGrid(dgInsumos, strinActualizarGrid, "Proveedor_Insumo");
            
            txtCod_insumo.Clear();
            txtPnombre.Clear();
            txtNombre.Clear();
            txtPrecioSiva.Clear();
            txtPrecioSivaDolar.Clear();
            txtPrecionCiva.Clear();




        }

        //validaciones
        private void txtCod_insumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo numeros
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                Error_Insumo.Clear();
            }
            //deje usar backespace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                Error_Insumo.Clear();
            }
            else
            {
                Error_Insumo.SetError(txtCod_insumo, "Ingrese Solo Numeros");
                e.Handled = true;
                
            }
            
           
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }

        

        

        private void txtEdit1_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            grupNewEdit.Visible = true;
            editar = true;
            cod = dgInsumos.CurrentRow.Cells[0].Value.ToString();
            txtCod_insumo.Text = dgInsumos.CurrentRow.Cells[0].Value.ToString();
            txtPnombre.Text = dgInsumos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgInsumos.CurrentRow.Cells[2].Value.ToString();
            cboUN.Text = dgInsumos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioSiva.Text = dgInsumos.CurrentRow.Cells[6].Value.ToString();
            cmbMoneda.Text = dgInsumos.CurrentRow.Cells[5].Value.ToString();
            txtPrecioSivaDolar.Text = dgInsumos.CurrentRow.Cells[4].Value.ToString();
            cmbIVA.Text = dgInsumos.CurrentRow.Cells[7].Value.ToString();
            txtPrecionCiva.Text = dgInsumos.CurrentRow.Cells[8].Value.ToString();
            dt.Text = dgInsumos.CurrentRow.Cells[9].Value.ToString();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dato.actualizaGrid(dgInsumos, strinActualizarGrid + "and i.nombre like'%" + txtBuscar.Text + "%';", "Insumos");
        }

        private void txtbuscarProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            dato.actualizaGrid(dgInsumos, strinActualizarGrid + "and p.Nombre like'%" + txtbuscarProveedor.Text + "%';", "Insumos");
        }
    }
}
