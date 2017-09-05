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
        private void FormAdminInsumos_Load(object sender, EventArgs e)
        {
            dato.actualizaGrid(dgInsumos, strinActualizarGrid, "Insumos");
            if (editar == false)
            { grupNewEdit.Visible = false; }
        }
        Datos dato = new Datos();
        Boolean editar;
        string cod;
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
        string strinActualizarGrid = "select i.cod_insumo AS [Cod Nº],p.Nombre AS Proveedor,i.nombre AS Nombre,i.un AS UN,pi.precioSinIVAmonedaCotizada AS [Precio Sin IVA],pi.moneda AS Moneda,pi.precioSinIVAenPesos AS [Precios S/IVA en $],pi.iva AS IVA,pi.precioConIVA AS [Precion C/IVA],i.FechaActualizacion AS Actualizado from Insumos i,Proveedores p,Proveedor_Insumo pi where i.cod_insumo=pi.cod_insumo and pi.id_proveedor=p.id_proveedor ";

        private void btnSave_Click(object sender, EventArgs e)
        {

                Insumos i = new Insumos();
                i.Cod_Insumo = Convert.ToInt32(txtCod_insumo.Text);
                i.Nombre = txtNombre.Text;
                i.Un = cboUN.SelectedItem.ToString();
                i.Fechaactual = dt.Value;
                Error_Insumo.Clear();
                if (editar == false)
                {
                 
                    string queryIncert = "insert into Insumos(cod_insumo,nombre,un,FechaActualizacion) values('" + i.Cod_Insumo + "','" + i.Nombre + "','" + i.Un + "','"+ i.Fechaactual +"')";
                    dato.ejecutarQuery(queryIncert);
                    dato.actualizaGrid(dgInsumos, strinActualizarGrid, "Insumos");
                }
            
                else
                {
                    //string queryUpdate = "update Unidades set cod_unidad='" + u.pCod_unidad + "', abreviatura='" + u.pAbreviatura + "', denominacion='" + u.pDenominacion + "', cod_postal=" + u.pCod_postal + ", telefono='" + u.pTelefono + "' where Id=" + Id + ";";
                    //dato.ejecutarQuery(queryUpdate);
                    //dato.actualizaGrid(dgUnidades, strinActualizarGrid, "Unidades");
                }
                editar = false;
                txtCod_insumo.Clear();
                txtNombre.Clear();
                


        }
        

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

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dato.actualizaGrid(dgInsumos, strinActualizarGrid + "and i.nombre like'%" + txtBuscar.Text + "%';", "Insumos");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            grupNewEdit.Visible = true;
            btnSave.Enabled = true;
        }

        private void txtEdit1_Click(object sender, EventArgs e)
        {
            grupNewEdit.Visible = true;
            editar = true;
            cod = dgInsumos.CurrentRow.Cells[0].Value.ToString();
            txtCod_insumo.Text = dgInsumos.CurrentRow.Cells[0].Value.ToString();
            txtPnombre.Text = dgInsumos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgInsumos.CurrentRow.Cells[2].Value.ToString();
            cboUN.Text = dgInsumos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioSiva.Text = dgInsumos.CurrentRow.Cells[4].Value.ToString();
            cmbMoneda.Text = dgInsumos.CurrentRow.Cells[5].Value.ToString();
            txtPrecioSivaDolar.Text = dgInsumos.CurrentRow.Cells[6].Value.ToString();
            cmbIVA.Text = dgInsumos.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
