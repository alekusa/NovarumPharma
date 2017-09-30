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
    public partial class BuscarInsumo : Form
    {
        public BuscarInsumo()
        {
            InitializeComponent();
        }
        Validacion vali = new Validacion();
        Datos dato = new Datos();

        private void txtBuscarporCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                Error_Insumo.SetError(txtBuscarporCodigo, "Ingrese Solo Numeros");
                e.Handled = true;

            }
            if (txtBuscarporCodigo.Text == "") { }
            else
            {
                string BusquedaPorCodInsumo = "SELECT p.Nombre AS [Proveedor],i.nombre AS [Insumo],cod_cat AS [Categoria],precioConIVA AS [Precio Unitario Con IVA] FROM Proveedores p, Proveedor_Insumo pi, Insumos i WHERE p.id_proveedor=pi.id_proveedor and pi.cod_insumo=i.cod_insumo and i.cod_insumo=" + txtBuscarporCodigo.Text + "";
                dato.actualizaGrid(dgInsumos, BusquedaPorCodInsumo, "Insumos");
            }
        }

        private void txtBuscarporCodigo_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
