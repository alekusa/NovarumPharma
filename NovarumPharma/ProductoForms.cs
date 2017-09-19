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
            //si no ahi nada en el textobox
            if (txtCod.Text == "")
            {

            }
            //a medida que teclea el codigo se cargan los datos correspondientes en los textbos pasados por parametro, en base al txtcod=codigo
            else
            {
                dato.cargarTXT(txtCod, txtNomProveedor, txtNomInsumo, txtCodCat);
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
                eRP.SetError(txtNombreProducto,"Ingrese El Nombre del Producto");
            }
            if (txtCod.Text == "")
            {
                eRP.SetError(txtCod, "Ingrese al menos un Insumo");
            }
            if (txtPorcentajeMP.Text == "")
            {
                eRP.SetError(txtPorcentajeMP, "Ingrese el porcentaje para este Insumo");
            }
            if(txtUnidadesAcotizar.Text == "")
            {
                eRP.SetError(txtUnidadesAcotizar,"Ingrese las Unidades a cotizar");
            }
            if (txtPresentacionGrMl.Text == "")
            {
                eRP.SetError(txtPresentacionGrMl, "Ingrese la presentacion en Gr o Ml");
            }
        }

        private void txtNombreProducto_KeyUp(object sender, KeyEventArgs e)
        {
            lvNombreDelProducto.Text = txtNombreProducto.Text;
            eRP.Clear();
        }

        private void txtPorcentajeMP_KeyUp(object sender, KeyEventArgs e)
        {
            eRP.Clear();
        }

        private void txtUnidadesAcotizar_KeyUp(object sender, KeyEventArgs e)
        {
            eRP.Clear();
        }

        private void txtPresentacionGrMl_KeyUp(object sender, KeyEventArgs e)
        {
            eRP.Clear();
        }
    }
}
